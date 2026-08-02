using Elements.Quantity.DiagnosticAnalyzers;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Elements.Quantity.Tests.DiagnosticAnalyzers;

[TestClass]
public sealed class QuantityToStringDiagnosticAnalyzerTests
{
    /// <summary>
    /// Verifies that the <see cref="QuantityToStringDiagnosticAnalyzer"/> correctly identifies and reports
    /// diagnostics for missing <c>ToString</c> overrides on quantities.
    /// </summary>
    /// <returns></returns>
    [TestMethod]
    public async Task AnalyzeCode_MissingToString_ReportError()
    {
        var analyzerTest = CreateAnalyzerTest("""
            using Elements.Quantity;

            public readonly struct [|MockQuantity|] : IQuantity<MockQuantity> { }
            """
        );

        await analyzerTest.RunAsync();
    }

    /// <summary>
    /// Verifies that the <see cref="QuantityToStringDiagnosticAnalyzer"/> does not report diagnostics for
    /// quantities that correctly override the <c>ToString</c> method.
    /// </summary>
    /// <returns></returns>
    [TestMethod]
    public async Task AnalyzeCode_HasToString_NoErrorReported()
    {
        var analyzerTest = CreateAnalyzerTest("""
            using Elements.Quantity;

            public readonly struct MockQuantity : IQuantity<MockQuantity>
            {
                public override string ToString() => this.FormatAuto();
            }
            """
        );

        await analyzerTest.RunAsync();
    }

    /// <summary>
    /// Creates a new instance of the analyzer test with the provided source code.
    /// </summary>
    /// <param name="testCode">The source code to analyze.</param>
    /// <returns>The analyzer test instance.</returns>
    private static CSharpAnalyzerTest<QuantityToStringDiagnosticAnalyzer, DefaultVerifier> CreateAnalyzerTest(string testCode) =>
        new()
        {
            ReferenceAssemblies = ReferenceAssemblies.Net.Net100,
            TestState =
            {
                AdditionalReferences =
                {
                    typeof(IQuantity).Assembly
                }
            },
            CompilerDiagnostics = CompilerDiagnostics.None,
            TestCode = testCode
        };
}
