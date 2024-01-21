using ExamPre6.Business.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPre6.Business.Service.Interfaces
{
    public interface IAccountService
    {
        Task Login(LoginViewModel vm);
    }
}
