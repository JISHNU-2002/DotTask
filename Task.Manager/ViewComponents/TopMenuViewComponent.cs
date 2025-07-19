using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManager.Service.Repository.Interface;

namespace WebApp.Demo.ViewComponents
{
    public class TopMenuViewComponent : ViewComponent
    {
        private readonly IMenuRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TopMenuViewComponent(IMenuRepository repository,
            IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var user = _httpContextAccessor.HttpContext.User;
            //var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
            //var menu = await _repository.GetMenuRolePermissionAsync(userId);    
            var menu = await _repository.GetAllMenu();
            return View("Default", menu);
        }
    }
}