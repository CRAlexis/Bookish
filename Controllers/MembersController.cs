using Bookish.Models.View;
using Bookish.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bookish.Controllers
{

    [Route("[controller]")]
    public class MembersController : Controller
    {
        private readonly IMembersService _membersService;

        public MembersController(IMembersService membersService)
        {
            _membersService = membersService;
        }
        

        [HttpGet("")]
        public IActionResult MembersList()
        {
            var members = _membersService.GetAll();
            var viewModel = new MembersViewModel
            {
                Members = members
            };
            
            return View(viewModel);
        }
        
        [HttpGet("{id}")]
        public IActionResult MemberPage(int id)
        {
            var viewModel = _membersService.GetById(id);
            
            return View(viewModel);
        }
        
    }
}
