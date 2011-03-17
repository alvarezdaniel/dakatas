using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoPapel.UI.MVC.Models
{
    public class User
    {
        private ICollection<Post> posts;
        
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Post> Posts { get { return posts; } set { posts = value; } }

        public User()
        {
            posts = new List<Post>();
        }

        public void AddPost(Post post)
        {
            if (!posts.Contains(post))
            {
                posts.Add(post);
                post.User = this;
            }
        }
    }
}
