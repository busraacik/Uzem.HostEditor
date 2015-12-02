using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HostEditor.Models
{
    [MetadataType(typeof(CategoryMetadata))]
    public partial class Category
    {

    }
    public class CategoryMetadata
    {
        [Display(Name = "KategoriId")]
        public int CategoryId { get; set; }


        [Display(Name = "Kategori")]
        [Required]
        public string Name { get; set; }
    }
}