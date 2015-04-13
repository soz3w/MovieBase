using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moviebase.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Country { get; set; }
        public ushort Year { get; set; }
    }
}
