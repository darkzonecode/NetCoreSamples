using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordTypesTest
{
    internal record BlogPost
    {
        public string Title { get; }

        public string Author { get; }

        public string Post { get; init; }

        public DateTime Date { get; }

        public BlogPost(string title, string author, string post, DateTime date)
        {
            Title = title;
            Author = author;
            Post = post;
            Date = date;
        }

        internal void Deconstruct(out object title, out object author, out object post, out object date)
        {
            title = Title;
            author = Author;
            post = Post;
            date = Date;
        }
    }
}
