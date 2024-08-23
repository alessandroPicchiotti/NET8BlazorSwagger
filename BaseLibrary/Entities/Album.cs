using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
    public class Album
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
     
            public int userId { get; set; }
            public int id { get; set; }
            public string title { get; set; } = "";
        


    }
}
