using System;

namespace RecordTypesTest
{
    class Program
    {

        record TestRecord(string MyFirstName, string MyLastName);

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var dateTimeNow = DateTime.Now;

            var blogPost1 = new BlogPost("My first blog post", "My User Name", "This is my post", dateTimeNow);
            var blogPost2 = new BlogPost("My first blog post", "My User Name", "This is my post", dateTimeNow);
            
            Console.WriteLine("Is blog post are equal: " + blogPost1.Equals(blogPost2));

            var newBlogPost = blogPost2 with { Post = "My second blog post" }; //new BlogPost("My second blog post", "Andriy Kostiv", "This is my post", dateTimeNow);

           var (title, _, _, date) = newBlogPost;

            Console.WriteLine(title);
            Console.WriteLine(date);
            Console.WriteLine();

            


            var me = new TestRecord("My FirstName", "My LastName");

            
            
        }
    }


}
