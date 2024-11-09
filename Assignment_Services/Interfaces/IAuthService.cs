using Assignment_BusinessObjects;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Services.Interfaces
{
    public interface IAuthService
    {
        Task<AppResponse<object>> SignUp(string name, string email, string password);
        Task<AppResponse<object>> SignIn(string email, string password);
        Task<AppResponse<object>> SignOut();
    }
}
