using System.Text;
using OpenXmlPowerTools;
using SharpDocx;

namespace Eudwia.Server.Features.Documents;

public class DocumentService
{
    private readonly ILogger<DocumentService> _logger;

    public DocumentService(ILogger<DocumentService> logger)
    {
        _logger = logger;
    }
    
    public async Task<MemoryStream> GenerateDocument(IFormFile template, object data)
    {
        var path = Path.GetTempFileName();
        await using (var fileStream = new FileStream(path, FileMode.Create))
        {
            await template.CopyToAsync(fileStream);
        }

        try
        {
            var document = DocumentFactory.Create(path, data, forceCompile: false);
            return document.Generate();

        }
        catch (SharpDocxCompilationException sdce)
        {
            var sb = new StringBuilder(sdce.Errors);
            sb.AppendLine(sdce.SourceCode);
            _logger.LogError(sb.ToString());
            throw;
        }
        finally
        {
            File.Delete(path);
        }
    }
    
    public async Task<Stream> GenerateMergedDocument(IFormFile template, IEnumerable<object> data)
    {
        var pages = new List<MemoryStream>();
        foreach (var o in data)
        {
            pages.Add(await GenerateDocument(template, o));
        }
        var merged = MergeDocuments(pages);
        merged.Position = 0;
        return merged;
    }
    
    private static Stream MergeDocuments(List<MemoryStream> files)
    {
        var outputFileStream = new MemoryStream();
        var sources = new List<Source>();

        foreach (var file in files)
        {
            var openXmlPowerToolsDocument = new OpenXmlPowerToolsDocument(Guid.NewGuid().ToString(), file);
            var document = new WmlDocument(openXmlPowerToolsDocument);
            var source = new Source(document, true);
            sources.Add(source);
        }

        MergeXmlDocuments(outputFileStream, sources);
        return outputFileStream;
    }

    private static void MergeXmlDocuments(Stream outStream, List<Source> sources)
    {
        var buildDocument = DocumentBuilder.BuildDocument(sources);
        buildDocument.WriteByteArray(outStream);
    }
}