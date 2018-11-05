using Xunit;
using TaskHouseApi.Controllers;
using TaskHouseApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using TaskHouseApi.Model;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace TaskHouseUnitTests
{
    public class FakeEmpolyerRepository : TaskHouseApi.Repositories.IEmployerRepository
    {
        private static List<Empolyer> empolyerCache;

        public FakeUserRepository()
        {
            empolyerCache = new List<Empolyer>()
            {
                new Empolyer()
                {
                    Id = 1,
                    Username = "1234",
                    Password = "+z490sXHo5u0qsSaxbBqEk9KsJtGqNhD8I8mVBdDJls=", //1234
                    Email = "test@test.com",
                    FirstName = "Bob1",
                    LastName = "Bobsen1",
                    Salt = "upYKQSsrlub5JAID61/6pA=="
                },
                new Empolyer()
                {
                    Id = 2,
                    Username = "root",
                    Password = "gCekoOdivUyOosjAz2wP9X+8TEEpe/LWJekDuvXV8bQ=", //root
                    Email = "test@test.com",
                    FirstName = "Bob2",
                    LastName = "Bobsen2",
                    Salt = "Ci1Zm+9HbvPCvVpBLcSFug==",

                },
                new Empolyer()
                {
                    Id = 3,
                    Username = "hej",
                    Password = "dpvq1pIWkY9SudflCKrW6tqCItErcBljM1GhNPWlUmg=", //hej
                    Email = "test@test.com",
                    FirstName = "Bob3",
                    LastName = "Bobsen3",
                    Salt = "U+cUJhQU56X+OCiGF9hb1g=="
                },
            };
        }

        public async Task<Empolyer> CreateAsync(Empolyer e)
        {

            empolyerCache.Add(e);
            return e;

        }

        public async Task<IEnumerable<Empolyer>> RetrieveAllAsync()
        {
            return empolyerCache;

        }

        public async Task<Empolyer> RetrieveSpecificAsync(LoginModel loginModel)
        {
            return empolyerCache
                .Single(
                    user => user.Username == loginModel.Username
                    && user.Password == loginModel.Password
                );
            //return (await RetrieveAllAsync())
            //    .Single(user => user.Username == loginModel.Username && user.Password == loginModel.Password);
        }

        public async Task<User> RetrieveAsync(int Id)
        {
            return userCache.Where(u => u.Id == Id).SingleOrDefault();

    
        }

        public async Task<Employer> UpdateAsync(int Id, Employer e)
        {
            Employer old = empolyerCache.Where(user => user.Id == Id).SingleOrDefault();
            int index = empolyerCache.IndexOf(old);

            empolyerCache[index] = e;
            return e;

        }

        public async Task<bool> DeleteAsync(int Id)
        {
            User empolyer = empolyerCache.Where(u => u.Id == Id).SingleOrDefault();

            if (empolyer == null) return false;

            empolyerCache.Remove(employer);

            return true;



        }
    }
}


