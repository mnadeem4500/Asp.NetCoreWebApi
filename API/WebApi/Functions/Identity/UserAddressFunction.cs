using AutoMapper;
using ExtremeClassified.BusinessLogic;
using ExtremeClassified.BusinessLogic.Identity;
using ExtremeClassified.Core;
using ExtremeClassified.Domain.Identity;
using ExtremeClassified.WebApi.Dtos.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace ExtremeClassified.WebApi.Functions.Identity
{
    public class UserAddressFunction
    {
          
        private readonly ApplicationSettings settings;
        private readonly ILogger logger;
        private readonly IMapper mapper;
        public UserAddressFunction(IOptions<ApplicationSettings> options, ILoggerFactory loggerFactory, IMapper iMapper)
        {
            settings = options.Value;
            logger = loggerFactory.CreateLogger<UserAddressFunction>();
            mapper = iMapper;
        }
        public List<UserAddressDto> GetAll(bool onlyActive = true)
        {
            var bll = new BLL<UserAddress>(settings.ConnectionString);
            try
            {
                var entities = bll.GetAll();

                return mapper.Map<List<UserAddressDto>>(entities);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            finally
            {
                bll?.Dispose();
            }
            return new List<UserAddressDto>();
        }
        public UserAddressDto GetById(int id)
        {
            var bll = new BLL<UserAddress>(settings.ConnectionString);
            
            try
            {
                var entities = bll.GetEntityById(id);
                var addressmapper = mapper.Map<UserAddress, UserAddressDto>(entities);
                return  addressmapper;
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { bll?.Dispose(); }

            return null;
        }
        public string Update(UserAddressDto address)
        {
            var bll = new BLL<UserAddress>(settings.ConnectionString);
            try
            {
                var useraddress = bll.GetEntityById(address.UserAddressId);
                if (useraddress == null)
                    return OperationResponse.NotFound.ToString();                
                useraddress.NameField    =   address.UserAddresskey;
                useraddress.State        =   address.State;
                useraddress.Country      =   address.Country;
                useraddress.City         =   address.City;
                useraddress.PostalCode   =   address.PostalCode;
                useraddress.Street1      =   address.Street1;
                useraddress.Active       =   address.Active;
                useraddress.UserId       =   address.UserId;
                                
                bll.Update(useraddress);

                return OperationResponse.Updated.ToString();
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { bll?.Dispose(); }

            return OperationResponse.Error.ToString();
        }
        public string Create(UserAddressDto address)
        {
            var gbll = new BLL<UserAddress>(settings.ConnectionString);
            try
            {
                var entites = mapper.Map<UserAddressDto, UserAddress>(address);
             /*   entites.NameField = address.UserAddresskey;
                entites.State = address.State;
                entites.Country = address.Country;
                entites.City = address.City;
                entites.PostalCode = address.PostalCode;
                entites.Street1 = address.Street1;
                entites.UserId = address.UserId;*/
                entites.Active = address.Active;
                entites.CreationDate = address.CreationDate;                
                gbll.Add(entites);
                return entites.KeyField;

            }

            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { gbll?.Dispose(); }

            return OperationResponse.Error.ToString();

        }

        public string Remove(UserAddressDto user)
        {
            var dbll = new BLL<UserAddress>(settings.ConnectionString);
            try
            {
                var userdelet = dbll.GetEntityById(user.UserAddressId);
                if (userdelet == null)
                {
                    return OperationResponse.NotFound.ToString();
                }
                dbll.Remove(userdelet);
                return OperationResponse.Deleted.ToString();
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { dbll?.Dispose(); }

            return OperationResponse.Error.ToString();


        }

    }

}
