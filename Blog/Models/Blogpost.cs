using System;

namespace Blog.Models
{
    public class Blogpost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public string Author { get; set; }
    }
}
