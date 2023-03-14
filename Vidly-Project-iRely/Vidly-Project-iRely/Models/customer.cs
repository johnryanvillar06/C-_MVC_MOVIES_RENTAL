using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vidly_Project_iRely.Models
{
    public partial class customer
    {

        [DisplayName("Customer ID")]
        public int id { get; set; }

        [DisplayName("Customer Name")]
        public string customername { get; set; }

        [DisplayName("Address")]
        public string address { get; set; }

        [DisplayName("Mobile")]
        public string mobile { get; set; }
    }

    public class CustomerMap : EntityTypeConfiguration<customer>
    {
        public CustomerMap()
        {
            // Set display names for columns using Fluent API
            this.Property(c => c.id).HasColumnName("Customer ID");
            this.Property(c => c.customername).HasColumnName("Customer Name ");
            this.Property(c => c.address).HasColumnName("Address");
            this.Property(c => c.mobile).HasColumnName("Mobile");
        }
    }
}
 