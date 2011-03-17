using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoPapel.UI.MVC.Models
{
    public class Post
    {
        private ICollection<Tag> tags;

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public virtual User User { get; set; }
        public DateTime PublishDate { get; set; }
        public virtual ICollection<Tag> Tags { get { return tags; } set { tags = value; } }

        public Post()
        {
            tags = new List<Tag>();
        }

        public void AddTag(Tag tag)
        {
            if (!tags.Contains(tag))
            {
                tags.Add(tag);
            }
        }
    }
}