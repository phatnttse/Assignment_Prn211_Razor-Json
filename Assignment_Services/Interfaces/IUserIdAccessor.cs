using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Services.Interfaces
{
    public interface IUserIdAccessor
    {
        string GetCurrentUserId();
    }
}
