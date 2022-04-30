using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DatabaseLayer
{
    public class LablePostModel
    {
        [Required]
        public string LableName { get; set; }
    }
}