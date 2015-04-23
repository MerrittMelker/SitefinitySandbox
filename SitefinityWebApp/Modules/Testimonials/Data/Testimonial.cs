using System;

namespace SitefinityWebApp.Modules.Testimonials.Data
{
    public class Testimonial
    {
        public Testimonial()
        {
            DatePosted = DateTime.Now;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Text { get; set; }
        public DateTime DatePosted { get; set; }
        public decimal Rating { get; set; }
        public bool Published { get; set; }
        public string UrlName { get; set; }
    }
}