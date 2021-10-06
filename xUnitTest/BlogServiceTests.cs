using DataLayer;
using Microsoft.EntityFrameworkCore;
using QueryingData.Models;
using ServiceLayer;
using System;
using System.Linq;
using Xunit;

namespace xUnitTest
{
    public class BlogServiceTests
    {
        [Fact]
        public void Add_writes_to_database()
        {
            // ARRANGE: Create option object with InMemoryDatabase
            var options = new DbContextOptionsBuilder<BloggingContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            // ACT: Run the test against one instance of the context
            using (var context = new BloggingContext(options))
            {
                var service = new BlogService(context);
                service.Add("http://sample.com");
            }

            // ASSERT: Use a separate instance of the context to verify correct data was saved to database
            using (var context = new BloggingContext(options))
            {
                Assert.Equal(1, context.Blogs.Count());
                Assert.Equal("http://sample.com", context.Blogs.Single().Url);
            }
        }

        [Fact]
        public void Find_searches_url()
        {
            var options = new DbContextOptionsBuilder<BloggingContext>()
                .UseInMemoryDatabase(databaseName: "Find_searches_url")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new BloggingContext(options))
            {
                context.Blogs.Add(new Blog { Url = "http://sample.com/cats" });
                context.Blogs.Add(new Blog { Url = "http://sample.com/catfish" });
                context.Blogs.Add(new Blog { Url = "http://sample.com/dogs" });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new BloggingContext(options))
            {
                var service = new BlogService(context);
                var result = service.Find("cat");
                Assert.Equal(2, result.Count());
            }
        }
    }
}
