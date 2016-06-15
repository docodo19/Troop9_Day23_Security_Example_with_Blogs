using HotDog.Models;
using HotDog.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotDog.Services
{
    public class BlogService : IBlogService
    {
        private IGenericRepository _repo;
        public BlogService(IGenericRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Returns all active blogs
        /// </summary>
        /// <returns></returns>
        public List<Blog> GetAllActiveBlogs()
        {
            // only queries blogs that are marked IsActive to true into a list
            var blogs = _repo.Query<Blog>().Where(b => b.IsActive == true).ToList();
            return blogs;
        }

        /// <summary>
        /// Returns a list of blogs that are associated with the current logged in user and is also set to IsActive true
        /// </summary>
        /// <returns></returns>
        public List<Blog> GetUserBlogs(string id)
        {
            var user = _repo.Query<ApplicationUser>().Where(u => u.Id == id).Include(u => u.Blogs).FirstOrDefault();
            user.Blogs = user.Blogs.Where(b => b.IsActive == true).ToList();
            var blogs = user.Blogs.ToList();
            return blogs;
        }

        /// <summary>
        /// Returns all blogs (including the ones that has IsActive set to false)
        /// </summary>
        /// <returns></returns>
        public List<Blog> GetAllBlogs()
        {
            var blogs = _repo.Query<Blog>().ToList();
            return blogs;
        }

        /// <summary>
        /// Creates a new blog user the user
        /// </summary>
        /// <param name="blog"></param>
        /// <param name="id"></param>
        public void SaveBlog(Blog blog, string id)
        {
            var user = _repo.Query<ApplicationUser>().Where(u => u.Id == id).Include(u => u.Blogs).FirstOrDefault();
            user.Blogs.Add(blog);
            _repo.SaveChanges();
        }



    }
}
