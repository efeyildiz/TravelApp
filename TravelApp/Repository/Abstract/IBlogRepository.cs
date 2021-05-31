using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelApp.Models;

namespace TravelApp.Repository.Abstract
{
    public interface IBlogRepository
    {
        Blog GetByID(int blogId);
        IQueryable<Blog> GetAll();
        void AddBlog(Blog entity);
        void UpdateBlog(Blog entity);
        void SaveBlog(Blog entity);
        void DeleteBlog(int blogId);
    }
}
