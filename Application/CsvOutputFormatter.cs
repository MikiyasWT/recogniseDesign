using System.Text;
using Entities.Dto;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

namespace Application;

public class CsvOutputFormatter : TextOutputFormatter
{
    public CsvOutputFormatter()
    {
        SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
        SupportedEncodings.Add(Encoding.UTF8);
        SupportedEncodings.Add(Encoding.Unicode);

    }

    protected override bool CanWriteType(Type? type)
    {
        if(typeof(ScrappedDataDto).IsAssignableFrom(type) || typeof(IEnumerable<ScrappedDataDto>).IsAssignableFrom(type) )
        {
           return base.CanWriteType(type);
        }
        return false;
    }

    public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
    {
        var response = context.HttpContext.Response;
        var buffer = new StringBuilder();

        if(context.Object is IEnumerable<ScrappedDataDto>)
        {
            foreach ( var scrappedData in (IEnumerable<ScrappedDataDto>)context.Object)
            {
                 FormatCsv(buffer, scrappedData);
            }
        }
        else{
            FormatCsv(buffer, (ScrappedDataDto)context.Object);
        }
        await response.WriteAsync(buffer.ToString());
    }

    public static void FormatCsv(StringBuilder buffer, ScrappedDataDto scrappedData){
        buffer.AppendLine($"{scrappedData.Id}, \"{scrappedData.Title}, \"{scrappedData.Seller},  \"{scrappedData.Price}, \" {scrappedData.Detail} \" ");
    }
}