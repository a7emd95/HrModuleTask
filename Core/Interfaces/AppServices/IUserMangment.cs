using Core.Models.UserMangment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.AppServices
{
    public interface IUserMangment
    {
        void Login(LoginModel loginModel); 
    }
}
