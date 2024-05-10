using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models.Gallery
{
    public class ImageViewModel
    {
        [Required]
        public string Name { get; set; }

        public long Size { get; set; }

        public string Path { get; set; }

    }
}