using Newtonsoft.Json;

namespace WebApplicationFetch
{
    public partial class Program
    {
        public class DataObject
        {
            public string API { get; set; }
            public string Description { get; set; }
            public string Auth { get; set; }
            public bool HTTPS { get; set; }
            public string Cors { get; set; }
            public string Link { get; set; }
            public string Category { get; set; }
            public long EntryTime { get; set; }

            public string SerializedObject()
            {
                return JsonConvert.SerializeObject(this);
            }

            public bool Contains(string key)
            {
                bool result = false;
                if (API.Contains(key)) result = true;
                if (Description.Contains(key)) result = true;
                if (Auth.Contains(key)) result = true;
                if (Cors.Contains(key)) result = true;
                if (Link.Contains(key)) result = true;
                if (Category.Contains(key)) result = true;              
                return result;
            }

            public string ToString()
            {
                return $"API: {API}\nDescription: {Description}\nAuth: {Auth}\nCors: {Cors}\nLink: {Link}\nHTTPS: {HTTPS}\nCategory: {Category}";             
            }

            public DataObject ()
            {

            }
        }
    }
}
