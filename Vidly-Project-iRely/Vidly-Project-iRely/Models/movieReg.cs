using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Vidly_Project_iRely.Models
{

    

    public partial class movieReg
    {

        public int id { get; set; }
        [DisplayName("Movie No# Ref")]
        public string movieno { get; set; }

        [DisplayName("Movie Title")]
        public string movietitle { get; set; }

        [DisplayName("Genre")]
        public string genre { get; set; }

        [DisplayName("Available")]
        public string available { get; set; }
    }


   
}
