namespace HaberPortal.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kullanicilar")]
    public partial class Kullanicilar
    {
        public int id { get; set; }

        [DisplayName("Kullanýcý Adý")]
        [Required]
        public string username { get; set; }

        [DisplayName("Þifre")]
        [DataType(DataType.Password)]
        [Required]
        public string password { get; set; }
    }
}
