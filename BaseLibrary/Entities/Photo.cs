using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
    public class Photo
    {
        public int albumId { get; set; }
        public int id { get; set; }
        public string title { get; set; } = string.Empty;
        public string url { get; set; } = string.Empty;
        public string thumbnailUrl { get; set; } = string.Empty;
    }
}
