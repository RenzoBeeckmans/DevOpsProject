using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevopsWPF.Models
{
    class Club : IComparable<Club>
    {
       
        public string Name { get; set; }
        public Club()
        {
        }
        public Club(string name)
        {
            Name = name;
        }

        public int CompareTo(Club other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
