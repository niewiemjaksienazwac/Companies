using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentationLayer.Models
{
    public class ValidationModel
    {
        public bool isValid { get; set; }

        public List<string> ValidationMessages { get; set; }
    }
}