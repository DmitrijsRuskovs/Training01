using System.Threading.Tasks;
using System;
using System.Text;
using System.IO;
using System.Threading;
using System.Net.Http;
using System.Text.Json;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.Storage;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WebApplicationFetch
{
    public partial class Program
    {
        private static string _storageConnection = "DefaultEndpointsProtocol=https;AccountName=dmitrijsruskovsstorage;AccountKey=lVID53s4Oj5yNyB1s45D3DFVvHaPR5TakoWgZmowJ8ZKDxvSlvqS/Al447uTKg/vg8696skvC13jKwHmGzEbtg==;EndpointSuffix=core.windows.net";
        private static string _tableName = "PublicApiLogs";
        private static string _blobName = "dmitrijsblob";
        private static string _fileName = @"Save.txt";

        public static async void ShowLogData(CloudTable usedTable, DateTime start, DateTime end)
        {
            TableQuery<LogEntity> query = new TableQuery<LogEntity>();         
            foreach (LogEntity entity in usedTable.ExecuteQuery(query))
            {
                long queryTicks = Int64.Parse(entity.PartitionKey);
                if (queryTicks >= start.Ticks && queryTicks <= end.Ticks)
                {
                    Console.WriteLine(entity.PartitionKey + " / " + entity.RowKey);
                }
            }
        }

        public static async void ShowBlobData(string keyWord)
        {
            using (StreamReader file = new StreamReader(_fileName))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    var item = JsonConvert.DeserializeObject<DataObject>(line);
                    if (item.Contains(keyWord))
                    {
                        Console.WriteLine(item.ToString()+"\n"+new string('.',50));
                    }
                }
                file.Close();
            }
        }

        public static async void GetData(CloudTable usedTable)
        {
            string baseUrl = "https://api.publicapis.org/random?auth=null";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            if (data != null)
                            {                               
                                Console.WriteLine(content.ReadAsStringAsync().Result);
                                var item = System.Text.Json.JsonSerializer.Deserialize<DataObjects>(content.ReadAsStringAsync().Result);                           
                                foreach (var dataEntry in item.entries)
                                {                                                                       
                                    if (dataEntry!=null)
                                    {
                                        dataEntry.EntryTime = DateTime.Now.Ticks;
                                        await InsertTableEntity(usedTable, "Success: " + dataEntry.API, dataEntry.EntryTime.ToString());
                                        using (StreamWriter sw = File.AppendText(_fileName)) sw.WriteLine(dataEntry.SerializedObject());
                                    }
                                    else
                                    {
                                        await InsertTableEntity(usedTable, "Failure: no or invalid data received", DateTime.Now.Ticks.ToString());
                                    }
                                }
                                
                            }
                            else
                            {
                                await InsertTableEntity(usedTable, "Failure: no data received", DateTime.Now.Ticks.ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {              
                Console.WriteLine("Exception Hit!!!!!!!");
                Console.WriteLine(exception);
                await InsertTableEntity(usedTable, "Failure: exception thrown", DateTime.Now.Ticks.ToString());
            }
        }

        public static async Task<string> InsertTableEntity(CloudTable p_tbl, string message, string rowKey)
        {                     
            TableOperation insertOperation = TableOperation.InsertOrMerge(new TableEntity(rowKey, message));
            TableResult result = await p_tbl.ExecuteAsync(insertOperation);            
            Console.WriteLine("Data Added to Azure tables");
            return "Data added";
        }

        public static void DisplayMenu()
        {
            //Console.Clear();
            Console.WriteLine(new string('-', 45));
            Console.WriteLine("| 1 - Fetch Data from public API            |");
            Console.WriteLine("| 2 - Review fetch Log for a defined period |");
            Console.WriteLine("| 3 - Review Data for a defined fetch       |");
            Console.WriteLine("| 0 - Exit                                  |");
            Console.WriteLine(new string('-', 45));
        }

        public static void Main(string[] args)
        {
            Microsoft.Azure.Cosmos.Table.CloudStorageAccount storageAccount = Microsoft.Azure.Cosmos.Table.CloudStorageAccount.Parse(_storageConnection);
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient(new TableClientConfiguration());            
            CloudTable table = tableClient.GetTableReference(_tableName);
            table.CreateIfNotExists();
            
            Microsoft.Azure.Storage.CloudStorageAccount storageAccount2 = Microsoft.Azure.Storage.CloudStorageAccount.Parse(_storageConnection);
            CloudBlobClient blobClient = storageAccount2.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(_blobName);
            container.CreateIfNotExists();
            CloudBlockBlob blob = container.GetBlockBlobReference(_blobName);
            blob.DownloadToFile(_fileName, FileMode.Create);
            blob.Properties.ContentType = "application/json";
            char key = '5';
            while (key != '0')
            {
                DisplayMenu();
                key = Console.ReadKey().KeyChar;
                if (key=='1') //Start Data Fetch
                {
                    Console.Write("Enter number of fetches: ");
                    int count = int.Parse(Console.ReadLine());
                    Console.Write("Enter time period in seconds: ");
                    double time = double.Parse(Console.ReadLine());
                    for (int i = 1; i <= count; i++)
                    {
                        GetData(table);
                        Thread.Sleep((int)(time * 1000));
                    }
                    Thread.Sleep(2000);
                    blob.UploadFromFile(_fileName);
                }
                if (key == '2') // Show Logs in table
                {
                    Console.Clear();
                    Console.WriteLine("Date/time format:  '2021-05-05 22:12' or just ENTER for whole period");
                    Console.Write("Enter start point : ");
                    string line = Console.ReadLine();
                    DateTime startDateTime = (line =="")? new DateTime(DateTime.MinValue.Ticks) : DateTime.ParseExact(line, "yyyy-MM-dd HH:mm", null);
                    Console.Write("Enter end point   : ");
                    line = Console.ReadLine();
                    DateTime endDateTime = (line == "") ? new DateTime(DateTime.MaxValue.Ticks) : DateTime.ParseExact(line, "yyyy-MM-dd HH:mm", null);                   
                    ShowLogData(table, startDateTime, endDateTime);
                }
                if (key == '3') // Show specific Logs in blob
                {
                    Console.Clear();                 
                    Console.Write("Enter key word to query from Blob: ");                   
                    ShowBlobData(Console.ReadLine());
                }

            }            
        }
    }
}
