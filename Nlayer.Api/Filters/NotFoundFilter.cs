using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using Nlayer.Core.Dtos;
using Nlayer.Core.Models;
using Nlayer.Core.Services;

namespace Nlayer.Api.Filters
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T: BaseEntity
    {
        private readonly IService<T> _service;
        public NotFoundFilter(IService<T> service)
        {
            _service= service;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            
            var idValue= context.ActionArguments.Values.FirstOrDefault();
            if (idValue == null)
            {
                await next.Invoke();
            }
            var id=(int)idValue;

            var anyEntity = await _service.AnyAsync(x => x.Id == id);

            if (anyEntity )
            {
                await next.Invoke();
                return;
            }
            context.Result = new NotFoundObjectResult(CustomResponseDto<NoContentDto>.Fail(404, $"{typeof(T).Name}({id}) not found"));




            throw new NotImplementedException();
        }
    }
}
