namespace HaberPortal.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Haber")]
    public partial class Haber
    {
        public int id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string baslik { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string resim_yolu { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string icerik { get; set; }

        public int kategori_id { get; set; }

        public DateTime tarih { get; set; }

        public virtual Kategori Kategori { get; set; }
    }
}
