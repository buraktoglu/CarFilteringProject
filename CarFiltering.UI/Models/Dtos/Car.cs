using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarFiltering.UI.Models.Dtos
{
    public class Car
    {
        public string title { get; set; }
        
        public string brand { get; set; }
        
        public string model { get; set; }
        
        public string year { get; set; }
        
        public string price { get; set; }
        
        public string trans { get; set; }
        
        public string extcolor { get; set; }
    }
}
