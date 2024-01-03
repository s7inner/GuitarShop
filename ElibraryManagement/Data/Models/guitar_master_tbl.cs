using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElibraryManagement.Data.Models
{
    public class guitar_master_tbl
    {
        public int Id { get; set; }
        public string guitar_name { get; set; }
        public string guitar_type { get; set; }
        public string guitar_color { get; set; }
        public string guitar_weight { get; set; }
        public string guitar_material { get; set; }
        public string number_of_strings { get; set; }
        public string guitar_price { get; set; }
        public string guitar_img_link { get; set; }
        public string publisher_name { get; set; }
        public string publish_date { get; set; }
        public string guitar_description { get; set; }

    }
}