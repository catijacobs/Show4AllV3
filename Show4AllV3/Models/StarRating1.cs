using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Show4AllV3.Models
{
    public class StarRating1
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Shows> Shows { get; set; }
    }
}
