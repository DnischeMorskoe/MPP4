using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGenerationLib
{
    public class CodeAnalyzer
    {
        public void Analyse(string code)
        {
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            CompilationUnitSyntax root = tree.GetCompilationUnitRoot();
            var namespaceDecalaration = root.Members.OfType<NamespaceDeclarationSyntax>().First();
            var classDeclaration = namespaceDecalaration.Members.OfType<ClassDeclarationSyntax>().First();
            var methodDeclaration = classDeclaration.Members.OfType<MethodDeclarationSyntax>().Where(method => method.Modifiers.Where(modifier => modifier.Kind() == SyntaxKind.PublicKeyword).Any());

        }
    }
}
