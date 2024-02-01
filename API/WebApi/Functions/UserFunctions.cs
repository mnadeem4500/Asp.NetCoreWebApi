using AutoMapper;
using Microsoft.Extensions.Options;
using System.Reflection;
using ExtremeClassified.WebApi.Dtos.Account;
using ExtremeClassified.WebApi.Utils;
using ExtremeClassified.Core;
using ExtremeClassified.BusinessLogic;
using ExtremeClassified.Domain.Identity;
using ExtremeClassified.WebApi.Dtos.Identity;

namespace ExtremeClassified.WebApi.Functions
{
    public class UserFunctions
    {
        private readonly ApplicationSettings settings;
        private readonly ILogger logger;
        private readonly IMapper mapper;
        private readonly AvPasswordHasher passwordHasher;
        public UserFunctions(IOptions<ApplicationSettings> options, ILoggerFactory loggerFactory, IMapper mapper, AvPasswordHasher passwordHasher)
        {
            settings = options.Value;
            logger = loggerFactory.CreateLogger<UserFunctions>();
            this.mapper = mapper;
            this.passwordHasher = passwordHasher;
        }

        public string SeedUsers(params RegisterDto[] users)
        {
            var userBll = new BLL<User>(settings.ConnectionString); //new UserBLL(settings.PortalConnStr);
            try
            {
                users.ToList().ForEach(user =>
                {
                    var oldEntity = userBll.GetEntityByName(user.UserName);
                    if (oldEntity is not null)
                    {
                        return;
                    }
                    var account = mapper.Map<RegisterDto, User>(user);
                    account.CreationDate = DateTime.Now;
                    account.EmailConfirmed = true;
                    account.PhoneNumberConfirmed = true;
                    account.PasswordHash = passwordHasher.HashPassword(account.PasswordHash);
                    userBll.Add(account);
                });
                return OperationResponse.Created.ToString();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            finally
            {
                userBll?.Dispose();
            }

            return OperationResponse.Error.ToString();
        }
        public string CreateUser(RegisterDto user)
        {
            var userBll = new BLL<User>(settings.ConnectionString); //new UserBLL(settings.PortalConnStr);

            try
            {
                var account = mapper.Map<RegisterDto, User>(user);
                // if (user.UserType == UserType.Application)
                account.PasswordHash = passwordHasher.HashPassword(account.PasswordHash);
                //else
                //    account.PasswordHash = "NA";

                account.CreationDate = DateTime.Now;
                userBll.Add(account);

                return account.KeyField;
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally
            {
                userBll?.Dispose();
            }

            return OperationResponse.Error.ToString();
        }

        public string CreateUpdateADUser(RegisterDto user)
        {
            var userBll = new BLL<User>(settings.ConnectionString);

            try
            {
                var existUser = userBll.GetEntityByName(user.UserName);
                if (existUser is null)
                {
                    var account = mapper.Map<RegisterDto, User>(user);
                    // if (user.UserType == UserType.Application)
                    account.PasswordHash = passwordHasher.HashPassword(account.PasswordHash);
                    // else
                    //   account.PasswordHash = "NA";

                    account.CreationDate = DateTime.Now;
                    userBll.Add(account);

                    return account.KeyField;
                }
                else
                {
                    existUser.Email = user.Email;
                    existUser.FirstName = user.FirstName;
                    existUser.LastName = user.LastName;
                    existUser.EmailConfirmed = true;
                    existUser.Active = true;

                    userBll.Update(existUser);

                    return existUser.KeyField;
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally
            {
                userBll?.Dispose();
            }

            return OperationResponse.Error.ToString();
        }

        public UserDto ValidateUserLogin(LoginDto login)
        {
            var userBll = new BLL<User>(settings.ConnectionString);
            try
            {
                var user = userBll.GetEntityByName(login.UserName);
                if (user == null)
                    return null;
                if (passwordHasher.VerifyHashedPassword(user.PasswordHash, login.Password) == Microsoft.AspNetCore.Identity.PasswordVerificationResult.Failed)
                    return null;

                var userDto = mapper.Map<User, UserDto>(user);
                return userDto;
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally
            {
                userBll?.Dispose();
            }

            return null;
        }

        public List<UserDto> GetAllActiveUsers()
        {
            var bll = new BLL<User>(settings.ConnectionString);
            var users = new List<UserDto>();
            try
            {
                var entities = bll.GetAll(true);
                users = mapper.Map<List<User>, List<UserDto>>(entities.ToList());
                return users;
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { bll?.Dispose(); }

            return users;
        }

        public UserDto GetById(string userId)
        {
            var bll = new BLL<User>(settings.ConnectionString);
            try
            {
                var entities = bll.GetEntityById(userId);
                var user = mapper.Map<User, UserDto>(entities);
                return user;
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { bll?.Dispose(); }

            return null;
        }

        public UserDto GetAddress(string userId)
        {
            var bll = new BLL<UserAddress>(settings.ConnectionString);
            try
            {
                var entity = bll.GetAll(x => x.UserId.Equals(userId)).FirstOrDefault();
                var add = mapper.Map<UserAddress, UserAddressDto>(entity);
                return add;
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { bll?.Dispose(); }

            return null;
        }

        public string UpdateProfile(UserDto user)
        {
            var bll = new BLL<User>(settings.ConnectionString);
            try
            {
                var oldUser = bll.GetEntityById(user.UserId);
                if (oldUser == null)
                    return OperationResponse.NotFound.ToString();

                oldUser.FirstName = user.FirstName;
                oldUser.LastName = user.LastName;
                oldUser.Industry = user.Industry;
                oldUser.JobTitle = user.JobTitle;
                oldUser.Title = user.Title;

                bll.Update(oldUser);

                return OperationResponse.Updated.ToString();
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { bll?.Dispose(); }

            return OperationResponse.Error.ToString();
        }

        public string AddAddress(UserAddressDto address)
        {
            var bll = new BLL<UserAddress>(settings.ConnectionString);
            try
            {
                var entity = mapper.Map<UserAddress>(address);
                entity.CreationDate = DateTime.Now;
                entity.CreatedUser = address.UserId;
                bll.Add(entity);
                return OperationResponse.Created.ToString();
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { bll?.Dispose(); }

            return OperationResponse.Error.ToString();
        }

        public string UpdateAddress(UserAddressDto address)
        {
            var bll = new BLL<UserAddress>(settings.ConnectionString);
            try
            {
                var oldAddress = bll.GetEntityById(address.AddressId);
                if (oldAddress == null)
                    return OperationResponse.NotFound.ToString();

                oldAddress.Street1 = address.Street1;
                oldAddress.Street2 = address.Street2;
                oldAddress.City = address.City;
                oldAddress.Country = address.Country;
                oldAddress.State = address.State;
                oldAddress.ModifiedDate = DateTime.Now;
                oldAddress.ModifiedUser = address.UserId;

                bll.Update(oldAddress);

                return OperationResponse.Updated.ToString();
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { bll?.Dispose(); }

            return OperationResponse.Error.ToString();

        }

        public string UpdatePassword(ChangePasswordDto dto)
        {
            var bll = new BLL<User>(settings.ConnectionString);
            try
            {
                var user = bll.GetEntityById(dto.UserId);
                if (user == null)
                    return OperationResponse.NotFound.ToString();
                if (passwordHasher.VerifyHashedPassword(user.PasswordHash, dto.OldPassaowrd) == Microsoft.AspNetCore.Identity.PasswordVerificationResult.Failed)
                    return OperationResponse.NotMatched.ToString();

                user.PasswordHash = passwordHasher.HashPassword(dto.NewPassword);

                bll.Update(user);
                return OperationResponse.Updated.ToString();
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally
            {
                bll?.Dispose();
            }

            return OperationResponse.Error.ToString();
        }

    }
}
