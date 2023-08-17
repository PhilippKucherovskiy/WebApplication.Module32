using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Module32.Models.Db;

namespace WebApplication.Module32
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
    }
}
