using System.Collections.Generic;
using Bookish.Models.Database;
using Microsoft.AspNetCore.Mvc;

namespace Bookish.Controllers
{
    public class MemberController : Controller
    {
        // GET One
        [HttpGet("members-json")]

        public List<string> MembersJSON()
        {
            var res = new Member().GetAllAsJSON();
            return res;
        }
        
        [HttpGet("member-json")]

        public string MemberJSON(int memId)
        {
            var res = new Member().GetOneAsJSON(memId);
            return res;
        }
    }
}