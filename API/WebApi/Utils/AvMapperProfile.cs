using AutoMapper;
using ExtremeClassified.Domain.Identity;
using ExtremeClassified.Domain.Portal;
//using ExtremeClassified.WebApi.Dtos.Account;
using ExtremeClassified.WebApi.Dtos.Identity;
using ExtremeClassified.WebApi.Dtos.Portal;

namespace ExtremeClassified.WebApi.Utils
{
    public class AvMapperProfile : Profile
    {
        public AvMapperProfile()
        {
            //Account
         /*   CreateMap<RegisterDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(dest => dest.Password))
                .ForMember(dest => dest.NameField, opt => opt.MapFrom(dest => dest.UserName));

            CreateMap<User, UserDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(dest => dest.NameField))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(dest => dest.KeyField));*/

          /*  CreateMap<UserAddressDto, UserAddress>()
               .ForMember(dest => dest.NameField, opt => opt.MapFrom(dest => dest.AddressType))
               .ForMember(dest => dest.KeyField, opt => opt.Ignore());*/


            //Catalogue
            CreateMap<CatalogueMaster, CatalogueMasterDto>()
                .ForMember(dest => dest.MasterId, opt => opt.MapFrom(dest => dest.KeyField))
                .ForMember(dest => dest.CatalogueName, opt => opt.MapFrom(dest => dest.NameField));

            CreateMap<CatalogueDetail, CatalogueDetailDto>()
             .ForMember(dest => dest.DetailId, opt => opt.MapFrom(dest => dest.KeyField))
             .ForMember(dest => dest.Name, opt => opt.MapFrom(dest => dest.NameField));

            //Portal
            CreateMap<PortalCountry, PortalDto>()
               .ForMember(dest => dest.CountryID, opt => opt.MapFrom(dest => dest.KeyField))
               .ForMember(dest => dest.CountryName, opt => opt.MapFrom(dest => dest.NameField));

            CreateMap<CountryAdministrativeDivision, CountryAdministrativeDivisionDto>()
               .ForMember(dest => dest.id, opt => opt.MapFrom(dest => dest.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(dest => dest.Name));



            #region Identity

            //Group
            CreateMap<Group, GroupDto>()
                .ForMember(dest => dest.GroupId, opt => opt.MapFrom(dest => dest.KeyField))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(dest => dest.NameField));

            CreateMap<GroupDto, Group>()
             .ForMember(dest => dest.KeyField, opt => opt.Ignore())
             .ForMember(dest => dest.NameField, opt => opt.MapFrom(src => src.Name));
            //Role
            CreateMap<Role, RoleDto>()
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(dest => dest.KeyField))
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(dest => dest.NameField));

            CreateMap<RoleDto, Role>()
             .ForMember(dest => dest.KeyField, opt => opt.Ignore())
             .ForMember(dest => dest.NameField, opt => opt.MapFrom(dest => dest.RoleName));
            //UserAccess
            CreateMap<UserAccess, UserAccessDto>()
                .ForMember(dest => dest.uaccessend, opt => opt.MapFrom(dest => dest.KeyField))
                .ForMember(dest => dest.uaccessname, opt => opt.MapFrom(dest => dest.NameField));

            CreateMap<UserAccessDto, UserAccess>()
             .ForMember(dest => dest.KeyField, opt => opt.Ignore())
             .ForMember(dest => dest.NameField, opt => opt.MapFrom(dest => dest.uaccessname));
            #endregion
            //UserActivity
            CreateMap<UserActivity, UserActivityDto>()
               .ForMember(dest => dest.UserActivityId, opt => opt.MapFrom(dest => dest.UserId));
         
            CreateMap<UserActivityDto, UserActivity>()
             .ForMember(dest => dest.UserId, opt => opt.MapFrom(dest => dest.UserActivityId));
            //userAdress in my dto addreskey'////////
            CreateMap<UserAddress, UserAddressDto>()
               .ForMember(dest => dest.UserAddressId, opt => opt.MapFrom(dest => dest.KeyField))
               .ForMember(dest => dest.UserAddresskey, opt => opt.MapFrom(dest => dest.NameField));

            CreateMap<UserAddressDto, UserAddress>()
             .ForMember(dest => dest.KeyField, opt => opt.Ignore())
             .ForMember(dest => dest.NameField, opt => opt.MapFrom(dest => dest.UserAddresskey));
            // UserDevice
            CreateMap<UserDevice, UserDeviceDto>()
               .ForMember(dest => dest.UserDeviceId, opt => opt.MapFrom(dest => dest.DeviceId))
               .ForMember(dest => dest.DevicName, opt => opt.MapFrom(dest => dest.DeviceName));

            CreateMap<UserDeviceDto, UserDevice>()
             .ForMember(dest => dest.KeyField, opt => opt.Ignore())
             .ForMember(dest => dest.DeviceName, opt => opt.MapFrom(dest => dest.DevicName));
            ///UserGroupDto
            CreateMap<UserGroup, UserGroupDto>()
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(dest => dest.UserId))
               .ForMember(dest => dest.GroupId, opt => opt.MapFrom(dest => dest.GroupId));

            CreateMap<UserGroupDto, UserGroup>()
             .ForMember(dest => dest.KeyField, opt => opt.Ignore())
             .ForMember(dest => dest.GroupId, opt => opt.MapFrom(dest => dest.UserId));
            ///Login Provider
            CreateMap<UserLogin, LoginProviderDto>()
               .ForMember(dest => dest.UserName, opt => opt.MapFrom(dest => dest.LoginProvider))
               .ForMember(dest => dest.Paswword, opt => opt.MapFrom(dest => dest.ProviderKey));

            CreateMap<LoginProviderDto, UserLogin>()
             .ForMember(dest => dest.LoginProvider, opt => opt.Ignore())
             .ForMember(dest => dest.ProviderKey, opt => opt.MapFrom(dest => dest.Paswword));
            ///User paswoord History
            CreateMap<UserPwdHistory, UserPwdHistoryDto>()
               .ForMember(dest => dest.UserhistoryId, opt => opt.MapFrom(dest => dest.UserId))
               .ForMember(dest => dest.UserPassword, opt => opt.MapFrom(dest => dest.Password));

            CreateMap<UserPwdHistoryDto, UserPwdHistory>()
             .ForMember(dest => dest.UserId, opt => opt.Ignore())
             .ForMember(dest => dest.Password, opt => opt.MapFrom(dest => dest.UserPassword));
            ///User Rigion
            CreateMap<UserRegion, UserRegionDto>()
              .ForMember(dest => dest.RegionId, (IMemberConfigurationExpression<UserRegion, UserRegionDto, object> opt) => opt.MapFrom(dest => dest.Id))
              .ForMember(dest => dest.UserId, (IMemberConfigurationExpression<UserRegion, UserRegionDto, UserRegionDto.UserId> opt) => opt.MapFrom(dest => dest.UserId));

            CreateMap<UserRegionDto, UserRegion>()
             .ForMember(dest => dest.Id, opt => opt.Ignore())
             .ForMember(dest => dest.UserId, opt => opt.MapFrom(dest => dest.UserId));
            ///User ROle
            CreateMap<UserRole, UserRoleDto>()
               .ForMember(dest => dest.RoleId, opt => opt.MapFrom(dest => dest.RoleId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(dest => dest.UserId));

            CreateMap<UserRoleDto, UserRole>()
             .ForMember(dest => dest.RoleId, opt => opt.Ignore())
             .ForMember(dest => dest.UserId, opt => opt.MapFrom(dest => dest.UserId));
            ///Token 
            CreateMap<UserToken, UserTokenDto>()
              .ForMember(dest => dest.TokenValue, opt => opt.MapFrom(dest => dest.Id))
               .ForMember(dest => dest.TokenUserId, opt => opt.MapFrom(dest => dest.UserId));

            CreateMap<UserTokenDto, UserToken>()
             .ForMember(dest => dest.Id, opt => opt.Ignore())
             .ForMember(dest => dest.UserId, opt => opt.MapFrom(dest => dest.TokenUserId));


        }
    }
}
