using System.Net.Http;
using System.Web.Http;
using The_Store.OperationMessengers.Base;

namespace The_Store.Controllers.Common
{
    public abstract class BaseApiController : ApiController
    {
        public HttpResponseException CreateApiError(BaseOperationOut response)
        {
           var url = Request?.RequestUri?.ToString();

           string message = string.Format("Error in url:{0}, error:{1}, Stack trace: {2}, Inner exception: {3} - {4}", url, response.Error?.Message, response.Error?.StackTrace, response.Error?.InnerException?.Message, response.Error?.InnerException?.StackTrace);

            // Log or send mail with error

            var errorResponse = Request.CreateErrorResponse(System.Net.HttpStatusCode.InternalServerError, message);
            throw new HttpResponseException(errorResponse);
        }
    }
}
