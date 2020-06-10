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

        [DisplayName("Kullan�c� Ad�")]
        [Required]
        public string username { get; set; }

        [DisplayName("�ifre")]
        [DataType(DataType.Password)]
        [Required]
        public string password { get; set; }
    }
}
