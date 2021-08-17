using System.Collections.Generic;
using Newtonsoft.Json;
//using Microsoft.Azure.Storage;

namespace WebApplicationFetch
{
    public partial class Program
    {

        public class DataObjects
        {
            public int count { get; set; }
            public List<DataObject> entries { get; set; }
           
            public DataObjects()
            {
            }
            public string SerializedObject()
            {
                return JsonConvert.SerializeObject(this);
            }

            public void Add(DataObject _object)
            {
                if (_object != null)
                {
                    entries.Add(_object);
                }
            }
        }
    }
}
