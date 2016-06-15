using System.Collections.Generic;
using HotDog.Models;

namespace HotDog.Services
{
    public interface IBlogService
    {
        List<Blog> GetAllActiveBlogs();
        List<Blog> GetAllBlogs();
        List<Blog> GetUserBlogs(string id);
    }
}