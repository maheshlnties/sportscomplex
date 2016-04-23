using System;

namespace SportsComplex.Models
{
    public class News
    {
        public string Id { get; set; }

        public string Content { get; set; }

        //public string Image { get; set; }

        public bool Highlight { get; set; }

        public DateTime PostedOn { get; set; }

        public DateTime ExpiresOn { get; set; }
    }
}