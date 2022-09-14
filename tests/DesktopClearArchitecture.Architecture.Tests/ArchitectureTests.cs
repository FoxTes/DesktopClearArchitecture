namespace DesktopClearArchitecture.Architecture.Tests;

using Application.Dtos;
using Infrastructure.Models;
using Domain.Common;
using FluentAssertions;
using NetArchTest.Rules;
using Xunit;

public class ArchitectureTests
{
    private const string DomainNamespace = "DesktopClearArchitecture.Domain";
    private const string ApplicationNamespace = "DesktopClearArchitecture.Application";
    private const string InfrastructureNamespace = "DesktopClearArchitecture.Infrastructure";
    private const string InfrastructureIdentityNamespace = "DesktopClearArchitecture.Infrastructure.Identity";
    private const string InfrastructurePersistenceNamespace = "DesktopClearArchitecture.Infrastructure.Persistence";
    private const string ClientNamespace = "DesktopClearArchitecture.Client";
    private const string ClientSharedNamespace = "DesktopClearArchitecture.Shared";

    [Fact]
    public void DomainShouldNotHaveDependencyOnOtherProject()
    {
        var assembly = typeof(BaseEntity).Assembly;

        var otherProject = new[]
        {
            ApplicationNamespace,
            InfrastructureNamespace,
            InfrastructureIdentityNamespace,
            InfrastructurePersistenceNamespace,
            ClientNamespace,
            ClientSharedNamespace
        };

        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherProject)
            .GetResult();

        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void AplicationShouldNotHaveDependencyOnOtherProject()
    {
        var assembly = typeof(SongDto).Assembly;

        var otherProject = new[]
        {
            InfrastructureNamespace,
            InfrastructureIdentityNamespace,
            InfrastructurePersistenceNamespace,
            ClientNamespace,
            ClientSharedNamespace
        };

        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherProject)
            .GetResult();

        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void InfrastructureShouldNotHaveDependencyOnOtherProject()
    {
        var assembly = typeof(GameList).Assembly;

        var otherProject = new[]
        {
            ClientNamespace,
            ClientSharedNamespace
        };

        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherProject)
            .GetResult();

        testResult.IsSuccessful.Should().BeTrue();
    }
}