using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace TestGeneratorLib
{
    public class CodeAnalyzer
    {
        public NamespaceData Analyse(string code)
        {
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            CompilationUnitSyntax root = tree.GetCompilationUnitRoot();
            var namespaceDecalaration = root.Members.OfType<NamespaceDeclarationSyntax>().First();
            var classDeclaration = namespaceDecalaration.Members.OfType<ClassDeclarationSyntax>().First();
            var methodDeclaration = classDeclaration.Members.OfType<MethodDeclarationSyntax>().Where(method => method.Modifiers.Where(modifier => modifier.Kind() == SyntaxKind.PublicKeyword).Any());

            IEnumerable<MethodData> methods = methodDeclaration.Select(method => new MethodData(method.Identifier.ToString()));
            ClassData classes = new ClassData(classDeclaration.Identifier.ToString(), methods);
            NamespaceData namespaces = new NamespaceData(namespaceDecalaration.Name.ToString(), classes);

            return namespaces;
        }
    }
}
