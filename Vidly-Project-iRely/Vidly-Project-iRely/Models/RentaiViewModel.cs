using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly_Project_iRely.Models
{
    public class RentaiViewModel
    {
        public int id { get; set; }
        public string movieid { get; set; }

        public string customername { get; set; }

        public string available { get; set; }
        public Nullable<int> customerid { get; set; }
        public Nullable<int> fee { get; set; }
        public Nullable<System.DateTime> startdate { get; set; }

        public Nullable<System.DateTime> enddate { get; set; }
    }
}