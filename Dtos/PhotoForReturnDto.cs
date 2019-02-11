using System;

namespace WebApp.API.Controllers
{
    internal class PhotoForReturnDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Desription { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }

        public string PublicId { get; set; }  
    }
}