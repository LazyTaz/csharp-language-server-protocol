using FluentAssertions;
using OmniSharp.Extensions.LanguageServer.Protocol.Client.Capabilities;
using OmniSharp.Extensions.LanguageServer.Protocol.Serialization;
using OmniSharp.Extensions.LanguageServer.Protocol.Server.Capabilities;
using TestingUtils;
using Xunit;

namespace Lsp.Tests.Capabilities.Server
{
    public class TextDocumentSyncKindTests
    {
        [Theory]
        [JsonFixture]
        public void SimpleTest(string expected)
        {
            var model = TextDocumentSyncKind.Full;
            var result = Fixture.SerializeObject(model);

            result.Should().Be(expected);

            var deresult = new LspSerializer(ClientVersion.Lsp3).DeserializeObject<TextDocumentSyncKind>(expected);
            deresult.Should().Be(model);
        }
    }
}
