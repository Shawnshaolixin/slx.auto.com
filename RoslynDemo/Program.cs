using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace RoslynCodeGenExample
{
    internal class Program
    {
        private static async Task Main()
        {
            var path = Directory.GetCurrentDirectory();
            var fileStream = File.OpenRead(Path.Combine(path, "schema.json"));

            var schema = await JsonSerializer.DeserializeAsync<Schema>(fileStream, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            var members = schema?.Types.Select(t => CreateClass(t.TypeName)).ToArray() ?? Array.Empty<MemberDeclarationSyntax>();

            var ns = NamespaceDeclaration(ParseName("CodeGen")).AddMembers(members);
            ClassDeclarationSyntax CreateClass(string name) =>
          ClassDeclaration(Identifier(name))
              .AddModifiers(Token(SyntaxKind.PublicKeyword));
            Directory.CreateDirectory(@"c:\code-gen");
            var streamWriter = new StreamWriter(@"c:\code-gen\generated.cs", false);
            ns.NormalizeWhitespace().WriteTo(streamWriter);
            Console.WriteLine("创建成功");
            Console.ReadKey();
        }
    }

    public class Schema
    {
        public IReadOnlyCollection<SchemaTypes> Types { get; set; } = Array.Empty<SchemaTypes>();
    }

    public class SchemaTypes
    {
        public string TypeName { get; set; } = string.Empty;
        public IReadOnlyCollection<string> Properties { get; set; } = Array.Empty<string>();
    }
}
