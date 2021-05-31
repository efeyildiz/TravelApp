using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelApp.Models;
using TravelApp.Repository.Abstract;

namespace TravelApp.Repository.Concrete
{
    public class EfBlogRepository : IBlogRepository
    {
        private TravelContext context;

        public EfBlogRepository(TravelContext _context)
        {
            context = _context;
        }

        public void AddBlog(Blog entity)
        {
            context.Blogs.Add(entity);
            context.SaveChanges();
        }

        public void DeleteBlog(int blogId)
        {
            var blog = context.Blogs.FirstOrDefault(p => p.BlogId == blogId);
            if (blog != null)
            {
                context.Blogs.Remove(blog);
                context.SaveChanges();
            }
        }

        public IQueryable<Blog> GetAll()
        {
            return context.Blogs;
        }

        public Blog GetByID(int blogId)
        {
            return context.Blogs.FirstOrDefault(p => p.BlogId == blogId);
        }

        public void SaveBlog(Blog entity)
        {
            if (entity.BlogId == 0 )
            {
                context.Blogs.Add(entity);
            }
            else
            {
                var blog = GetByID(entity.BlogId);

                if (blog != null)
                {
                    blog.BlogTittle = entity.BlogTittle;
                    blog.BlogDescription = entity.BlogDescription;
                    blog.BlogBody = entity.BlogBody;
                    blog.BlogImage = entity.BlogImage;
                    blog.isShared = entity.isShared;
                    blog.isSlider = entity.isSlider;

                }
            }
            context.SaveChanges();
        }

        public void UpdateBlog(Blog entity)
        {
            var blog = GetByID(entity.BlogId);

            if (blog != null)
            {
                blog.BlogTittle = entity.BlogTittle;
                blog.BlogDescription = entity.BlogDescription;
                blog.BlogBody = entity.BlogBody;
                blog.BlogImage = entity.BlogImage;
                blog.isShared = entity.isShared;
                blog.isSlider = entity.isSlider;

                context.SaveChanges();
            }
            context.SaveChanges();
        }
    }
}
