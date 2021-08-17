using Microsoft.Azure.Cosmos.Table;
//using Microsoft.Azure.Storage;

namespace WebApplicationFetch
{
    public partial class Program
    {
        public class LogEntity : TableEntity
        {
            public LogEntity(string ticks, string logInformation)
            {
                this.PartitionKey = logInformation; this.RowKey = ticks;
            }
            public LogEntity() { }
        }
    }
}
