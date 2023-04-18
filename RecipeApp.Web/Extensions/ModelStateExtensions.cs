using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AspNetCore.Identity.Extensions
{
    public static class ModelStateExtensions
    {

        public static void AddModelErrorList(this ModelStateDictionary modelstate, List<string> Errors)
        {
            Errors.ForEach(x =>
            {
                modelstate.AddModelError(string.Empty, x);

            });
        }
    }
}
