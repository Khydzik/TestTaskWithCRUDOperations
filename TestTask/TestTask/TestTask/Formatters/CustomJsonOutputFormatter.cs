using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Buffers;
using System.Text;
using TestTask.Web.Extensions;
using TestTask.Web.Models;

namespace TestTask.Web.Formatters
{
    public class CustomJsonOutputFormatter : JsonOutputFormatter
    {

        public CustomJsonOutputFormatter() : base(JsonSerializerSettingsProvider.CreateSerializerSettings(), ArrayPool<char>.Shared)
        {
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            JsonOutputWrapper<object> apiResponse = new JsonOutputWrapper<object> { Result = context.Object };

            await context.HttpContext.Response.WriteJson(apiResponse);
        }

    }
}

