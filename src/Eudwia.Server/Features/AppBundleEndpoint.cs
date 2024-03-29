﻿using Microsoft.AspNetCore.Mvc;

namespace Eudwia.Server.Features;

[ApiController]
public class BundleEndpoint : ControllerBase
{
    private readonly IWebHostEnvironment _env;

    public BundleEndpoint(IWebHostEnvironment env)
    {
        _env = env;
    }

    [HttpGet("app.bundle")]
    public IResult Handle(HttpContext context)
    {
        string? contentEncoding = null;
        var contentType = "multipart/form-data; boundary=\"--0a7e8441d64b4bf89086b85e59523b7d\"";
        var fileName = "app.bundle";

        var acceptEncodings = context.Request.Headers.AcceptEncoding;
        if (Microsoft.Net.Http.Headers.StringWithQualityHeaderValue.TryParseList(acceptEncodings, out var encodings))
        {
            if (encodings.Any(e => e.Value == "br"))
            {
                contentEncoding = "br";
                fileName += ".br";
            }
            else if (encodings.Any(e => e.Value == "gzip"))
            {
                contentEncoding = "gzip";
                fileName += ".gz";
            }
        }
        if (contentEncoding != null)
        {
            context.Response.Headers.ContentEncoding = contentEncoding;
        }
        return Results.File(_env.WebRootFileProvider.GetFileInfo(fileName).CreateReadStream(), contentType);
    }
}