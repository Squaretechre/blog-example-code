using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Xunit;

namespace RuntimeCompilation.MathematicalOperations
{
    public class MathematicalOperationShould
    {
        [Fact]
        public void add_two_numbers_together()
        {
            var add = new Add();
            Assert.Equal(20, add.Execute(10, 10));
        }

        [Fact]
        public void subtract_one_number_from_another()
        {
            var subtract = new Subtract();
            Assert.Equal(5, subtract.Execute(10, 5));
        }

        [Fact]
        public void load_source_from_disk_and_compile_it_at_runtime()
        {
            var source = File.ReadAllText(@"MathematicalOperations\source.txt");

            var maxLanguageVersion = Enum
                .GetValues(typeof(LanguageVersion))
                .Cast<LanguageVersion>()
                .Max();

            var options = new CSharpParseOptions(maxLanguageVersion);
            var syntaxTree = CSharpSyntaxTree.ParseText(source, options);

            var references = new List<MetadataReference>
            {
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(IMathematicalOperation).Assembly.Location)
            };

            var syntaxTrees = new List<SyntaxTree> {syntaxTree};
            var compilationOptions = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary);

            var compilation = CSharpCompilation.Create(
                "InMemoryAssembly",
                options: compilationOptions,
                references: references,
                syntaxTrees: syntaxTrees);

            var stream = new MemoryStream();
            compilation.Emit(stream);

            var assembly = Assembly.Load(stream.ToArray());
            var type = assembly.GetType("DynamicOperations.Multiply");
            var instance = (IMathematicalOperation) Activator.CreateInstance(type);

            Assert.Equal(9, instance.Execute(3, 3));
        }
    }
}