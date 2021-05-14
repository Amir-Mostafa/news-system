using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace day5_asp.Models
{
    public class user
    {
        public int id { get; set; }


        public string name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public int age { get; set; }
        public string address { get; set; }
        public string img { get; set; }

        public user()
        {
            mynews = new List<news>();
        }
        public virtual List<news> mynews { set; get; }
        
    }

}