using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;

namespace Elements.Quantity.DiagnosticAnalyzers;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class QuantityToStringDiagnosticAnalyzer : DiagnosticAnalyzer
{
    private const string TargetInterfaceName = "Elements.Quantity.IQuantity";

    public const string DiagnosticId = "YDMSEQ001";

    public static readonly DiagnosticDescriptor Rule = new(
        DiagnosticId,
        "Quantity ToString Override Missing",
        "Quantity '{0}' must override the ToString() method. Usually, this is calling 'this.FormatAuto()' and returning its result.",
        "Design",
        DiagnosticSeverity.Error,
        true,
        "This enforces that all Quantity types override the ToString() method to provide a meaningful string representation of the quantity."
    );

    /// <inheritdoc/>
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => [Rule];

    /// <summary>
    /// Initializes the analyzer and registers the actions to be performed.
    /// </summary>
    /// <param name="ctx">The main analysis context.</param>
    public override void Initialize(AnalysisContext ctx)
    {
        ctx.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        ctx.EnableConcurrentExecution();
        ctx.RegisterSymbolAction(AnalyzeQuantityToString, SymbolKind.NamedType);
    }

    /// <summary>
    /// Analyzes the code and report an error if the quantity type does not contain a <c>ToString</c> override.
    /// </summary>
    /// <param name="ctx">The symbol analysis context.</param>
    private void AnalyzeQuantityToString(SymbolAnalysisContext ctx)
    {
        var typeSymbol = (INamedTypeSymbol)ctx.Symbol;

        if (typeSymbol.TypeKind != TypeKind.Struct)
        {
            return;
        }

        var quantityInterface = ctx.Compilation.GetTypeByMetadataName(TargetInterfaceName);

        if (quantityInterface is null)
        {
            return;
        }

        var implementsTarget = typeSymbol.AllInterfaces.Any(i => i.Equals(quantityInterface, SymbolEqualityComparer.Default));

        if (!implementsTarget)
        {
            return;
        }

        var toStringMethod = typeSymbol.GetMembers("ToString");
        var hasOverride = toStringMethod.Any(m => m is IMethodSymbol method && method.IsOverride && method.ReturnType.SpecialType == SpecialType.System_String && method.Parameters.Length == 0);

        if (!hasOverride)
        {
            ctx.ReportDiagnostic(Diagnostic.Create(Rule, typeSymbol.Locations[0], typeSymbol.Name, quantityInterface.Name));
        }
    }
}
