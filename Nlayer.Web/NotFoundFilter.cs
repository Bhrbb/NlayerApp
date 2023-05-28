using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Nlayer.Core.Dtos;
using Nlayer.Core.Models;
using Nlayer.Core.Services;

namespace Nlayer.Web
{
    public class NotFoundFilter<T>:IAsyncActionFilter where T: BaseEntity
    {
        private readonly IService<T> _service;
        public NotFoundFilter(IService<T> service)
        {
            _service = service;
        }
        //public  Task OnActionExecutionAsync(ActionExecutedContext context,ActionExecutionDelegate next)
        //{
        //    var idValue = context.ActionArguments.Values.FirstOrDefault();
        //    if (idValue == null)
        //    {
        //        await next.Invoke();
        //    }
        //    var id = (int)idValue;

        //    var anyEntity = await _service.AnyAsync(x => x.Id == id);

        //    if (anyEntity)
        //    {
        //        await next.Invoke();
        //        return;
        //    }
        //    var errorViewModel = new ErrorViewModel();
        //    errorViewModel.Errors.Add($"{typeof(T).Name} ({id}) is not Found");
        //    context.Result = new RedirectToActionResult("Error", "Home", errorViewModel);


        //}

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValue = context.ActionArguments.Values.FirstOrDefault();
            if (idValue == null)
            {
                await next.Invoke();
            }
            var id = (int)idValue;

            var anyEntity = await _service.AnyAsync(x => x.Id == id);

            if (anyEntity)
            {
                await next.Invoke();
                return;
            }
            var errorViewModel = new ErrorViewModel();
            errorViewModel.Errors.Add($"{typeof(T).Name} ({id}) is not Found");
            context.Result = new RedirectToActionResult("Error", "Home", errorViewModel);
        }
    }
}
