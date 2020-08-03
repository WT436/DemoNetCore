using B5_ApiTutorial.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B5_ApiTutorial.Services
{
    public interface IIdentitiService
    {
        Task<AuThenticationResult> AuThenticationResultAsync(string email, string pass);
    }
}
