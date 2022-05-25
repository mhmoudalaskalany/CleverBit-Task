using System;
using System.Net;
using System.Threading.Tasks;
using BackendCore.Common.Core;
using BackendCore.Common.DTO.Login;
using BackendCore.Common.DTO.User;
using BackendCore.Common.Extensions;
using BackendCore.Entities.Entities;
using BackendCore.Service.Services.Base;
using BackendCore.Service.Services.Identity.Account;

namespace BackendCore.Service.Services.Account
{
    public class AccountService : BaseService<User,AddUserDto, UserDto, Guid , Guid?>, IAccountService
    {
        private readonly ITokenService _tokenBusiness;
        public AccountService(IServiceBaseParameter<User> businessBaseParameter, ITokenService tokenBusiness) : base(businessBaseParameter)
        {
            _tokenBusiness = tokenBusiness;
        }

        #region Public Methods
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<IFinalResult> Login(LoginParameters parameters)
        {
            var user = await UnitOfWork.Repository.FirstOrDefaultAsync(q => q.UserName == parameters.Username && !q.IsDeleted, disableTracking: false);
            if (user == null) return ResponseResult.PostResult(status: HttpStatusCode.BadRequest,
                message: "Wrong Username or Password");
            var rightPass = CryptoHasher.VerifyHashedPassword(user.Password, parameters.Password);
            if (!rightPass) return ResponseResult.PostResult(status: HttpStatusCode.NotFound, message: "Wrong Password");
            var userDto = Mapper.Map<User, UserDto>(user);
            var userLoginReturn = _tokenBusiness.GenerateJsonWebToken(userDto);
            return ResponseResult.PostResult(userLoginReturn, status: HttpStatusCode.OK, message: HttpStatusCode.OK.ToString());
        }
       

        #endregion


    }
}