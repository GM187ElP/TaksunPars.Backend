using IAM.Application.Interfaces;
using IAM.Domain.Entities;
using Isopoh.Cryptography.Argon2;
using MediatR;
using Microsoft.Extensions.Configuration;
using Shared;
using Shared.Interfaces;

namespace IAM.Application.Handlers.Commands
{
    public class UserRegisterationCommandHandler : IRequestHandler<UserRegisterationCommand, ResultStatus>
    {
        private readonly IUserRepository _repo;
        private readonly IConfiguration _configuration;
        private readonly IEmployeeLookupService _employeeLookupService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _secret;

        public UserRegisterationCommandHandler(IUserRepository repo, IConfiguration configuration, IEmployeeLookupService employeeLookupService,IUnitOfWork unitOfWork,string secret)
        {
            _repo = repo;
            _configuration = configuration;
            _employeeLookupService = employeeLookupService;
            _unitOfWork = unitOfWork;
            _secret = secret;
        }

        public async Task<ResultStatus> Handle(UserRegisterationCommand request, CancellationToken cancellationToken)
        {
            var username = request.Dto.Username.Trim();
            var password = request.Dto.Password;

            var result = new ResultStatus();

            if(await _repo.FindByUsernameAsync(username)!=null)
            {
                result.Errors.Add($"User with national id: {username} exists");
                return result;
            }    

            var employeeId = await _employeeLookupService.GetEmployeeIdByNationalIdAsync(username, cancellationToken);
            if (employeeId == null || employeeId == Guid.Empty)
            {
                result.Errors.Add("You are not an employee of this Company");
                return result;
            }

            //var secret = _configuration["PasswordSalt"];
            if (string.IsNullOrEmpty(_secret))
            {
                result.Errors.Add("Password key not configured.");
                return result;
            }

            var hashedPassword = Argon2.Hash(password, _secret);

            var user = new User
            {
                Username = username,
                PasswordHash = hashedPassword,
                PersonnelId = employeeId.Value
            };

            await _unitOfWork.ExecuteInTransactionAsync(async (tc) =>
            {
                await _repo.AddAsync(user);

            }, cancellationToken);

            result.IsPartialySuccess = _unitOfWork.Result > 0;
            if(!result.IsPartialySuccess)
                result.Errors.Add("User not saved for unknown reason");

            return result;
        }
    }
}
