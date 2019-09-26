using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Runpath.Helpers;
using Runpath.Models;
using Runpath.Processors;

namespace Runpath.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private IRequestProcessor RequestProcessor;
        public UsersController()
        {
            RequestProcessor = new RequestProcessor();
        }

        [HttpGet("[action]")]
        public IEnumerable<User> GetUsers()
        {
            var requestUrl = $"{ApiHelper.base_url}/users";
            var users = RequestProcessor.Process<List<User>>(requestUrl);

            return users;
        }

        [HttpGet("[action]/{id}")]
        public User GetUser()
        {
            var requestUrl = $"{ApiHelper.base_url}/users";
            var user = RequestProcessor.Process<User>(requestUrl);

            return user;
        }
    }
}
