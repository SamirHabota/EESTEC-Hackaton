using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Web.Viewmodels
{
    public class NewDocumentVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Extension { get; set; }
        public IFormFile File { get; set; }
        public string Description { get; set; }
        public int WordCounter { get; set; }
        public int CharCounter { get; set; }
    }
}
