using FluentAssertions;

using NetArchTest.Rules;

using RichillCapital.TraderStudio.Mobile.ViewModels;

namespace RichillCapital.TraderStudio.Mobile.ArchitectureTests.Rules;

public sealed class DesignRuleTests
{
    [Fact]
    public void ViewModel_Should_HaveViewModelSuffix()
    {
        var result = Types.InAssembly(typeof(MauiProgram).Assembly)
            .That()
            .ImplementInterface(typeof(IViewModel))
            .Should().HaveNameEndingWith(nameof(ViewModel))
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
}