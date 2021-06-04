using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Infrastructure;

namespace BLL.Interfaces
{
    interface IUserService
    {
        Task<OperationDetails> Create(UserAccountDTO userDto);
        Task<ClaimsIdentity> Authenticate(UserAccountDTO userDto);
        Task SetInitialData(UserAccountDTO adminDto, List<string> roles);
    }
}
