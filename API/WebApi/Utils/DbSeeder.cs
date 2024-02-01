using ExtremeClassified.BusinessLogic;
using ExtremeClassified.Core;
using ExtremeClassified.Domain.Portal;
using ExtremeClassified.WebApi.Dtos.Account;
using ExtremeClassified.WebApi.Functions;

namespace ExtremeClassified.WebApi.Utils
{
    public static class DbSeeder
    {
        public static void SeedDummyUsers(UserFunctions accountfunctions)
        {
            var users = new RegisterDto[] {
            new RegisterDto
            {
                UserName="user001@email.com",
                Email="user001@email.com",
                FirstName="User",
                LastName="001",
                Title="Mr",
                CompanyId=1,
                Industry="Testing",
                JobTitle="Dummy",
                PhoneNumber="00000000",
                Password="123456",
            },
            new RegisterDto
            {
                UserName="user002@email.com",
                Email="user002@email.com",
                FirstName="User",
                LastName="002",
                Title="Mr",
                CompanyId=1,
                Industry="Testing",
                JobTitle="Dummy",
                PhoneNumber="00000000",
                Password="123456",
            },
            new RegisterDto
            {
                UserName="user003@email.com",
                Email="user003@email.com",
                FirstName="User",
                LastName="003",
                Title="Mr",
                CompanyId=1,
                Industry="Testing",
                JobTitle="Dummy",
                PhoneNumber="00000000",
                Password="123456",
            },
            new RegisterDto
            {
                UserName="user004@email.com",
                Email="user004@email.com",
                FirstName="User",
                LastName="004",
                Title="Mr",
                CompanyId=1,
                Industry="Testing",
                JobTitle="Dummy",
                PhoneNumber="00000000",
                Password="123456",
            },
            new RegisterDto
            {
                UserName="user005@email.com",
                Email="user005@email.com",
                FirstName="User",
                LastName="005",
                Title="Mr",
                CompanyId=1,
                Industry="Testing",
                JobTitle="Dummy",
                PhoneNumber="00000000",
                Password="123456",
            }
            };

            accountfunctions.SeedUsers(users);
        }
        public static void SeedCountries(string connStr)
        {
            var bll = new BLL<PortalCountry>(connStr);
            var countryList = new PortalCountry[]
            {
                  new PortalCountry
                {
                    Active = true,
                    Capital="Islamabad",
                    ContinentCode="PK",
                    CreationDate=DateTime.Now,
                    CurrencyCode="PKR",
                    ISO="PK",
                    ISO3="PAK",
                    LangCode=LangCode.EN.ToString(),
                    ISONumeric=586,
                    NameField="Pakistan",
                  },
                       new PortalCountry
                {
                    Active = true,
                    Capital="Abu Dhabi",
                    ContinentCode="AE",
                    CreationDate=DateTime.Now,
                    CurrencyCode="DHR",
                    ISO="PK",
                    ISO3="UAE",
                    LangCode=LangCode.EN.ToString(),
                    ISONumeric=784,
                    NameField="United Arab Emirates",
                  }
            };

            try
            {
                countryList.ToList().ForEach(c =>
                {
                    var country = bll.GetEntityByName(c.NameField);
                    if (country != null)
                        return;

                    bll.Add(c);
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                bll.Dispose();
            }
        }

    }

}
