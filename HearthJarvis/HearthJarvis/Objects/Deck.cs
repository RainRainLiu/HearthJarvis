using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthJarvis.Objects
{
    public class Deck
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Hero { get; set; }
        public bool IsWild { get; set; }
        public List<string> Card_ID { get; set; } = new List<string>();
    }
}
