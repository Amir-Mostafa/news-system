using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace day5_asp.Models
{
    public class catalog
    {

        public int id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }

        public catalog()
        {
            news = new List<news>();
         }

        public virtual List<news> news { get; set; }
    }
}