using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Publication
    {
        
        public string title { get; set; }
        public int YearOfPublication { get; set; }
        public DateTime AvailableFrom { get; set; }
        public string Type { get; set; }
        public int Ranking { get; set; }
        public List<string> Authors { get; set; }
        public string doi{get;set;}
        public string cite_as{get;set; }
        public override string ToString()
        {
            return title + ' ' + YearOfPublication + ' ' + AvailableFrom + ' ' + Type + ' ' + Ranking + ' ' + Authors + ' ' + doi + ' ' + cite_as;
        }
    }
}