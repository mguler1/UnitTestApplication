using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplication.Services
{
    public class IdentityValidateService : IIdentityValidateService
    {
        public bool IsValid(string IdentityNumber)
        {
            return true;
        }
    }
}
