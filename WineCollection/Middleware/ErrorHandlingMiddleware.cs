using WineCollection.Exceptions;

namespace WineCollection.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (NotFoundException notFoundException)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(notFoundException.Message);
            }
            catch (BadRequestException badRequestException)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(badRequestException.Message);
            }
            catch (ForbidException forbidException)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync(forbidException.Message);
            }
            catch (EmailIsTakenException emailIsTakenException)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(emailIsTakenException.Message);
            }
            catch (CellarIsFullException cellarIsFullException)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync(cellarIsFullException.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong!");
            }
        }
    }
}
