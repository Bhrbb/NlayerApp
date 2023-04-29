using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Nlayer.Core.Dtos;

namespace Nlayer.Api.Filters
{
    
    public class ValidateFilterAtribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)//hata var mı yok mu
            {
                var errors = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                //hata sınıfı
                context.Result=new BadRequestObjectResult(CustomResponseDto<NoContentDto>.Fail(400,errors));
              

            }
        }
    }
}
