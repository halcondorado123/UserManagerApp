using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Extensions
{
    public static class ControllerHelper
    {
        public static async Task<IActionResult> HandleRequestAsync(Func<Task<IActionResult>> action)
        {
            try
            {
                return await action();
            }
            catch (ArgumentNullException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return new NotFoundObjectResult(ex.Message);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"Internal error: {ex.Message}")
                {
                    StatusCode = 500
                };
            }
        }
    }
}
