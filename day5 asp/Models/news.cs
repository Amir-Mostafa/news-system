using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace day5_asp.Models
{
    public class news
    {
        public int id { get; set; }
        public string title { get; set; }
        public string bref { get; set; }
        public string details{ get; set; }
        public DateTime date { get; set; }
        public string img { get; set; }
        public string attach { get; set; }
        public int userID{ get; set; }

        public int catID { get; set; }

        [ForeignKey("catalog")]
        
        public int? cat_id { get; set; }


        [ForeignKey("myuser")]
        public int? user_id { get; set; }
        public virtual user myuser{ set; get; }
        public virtual catalog catalog { set; get; }


    }
}