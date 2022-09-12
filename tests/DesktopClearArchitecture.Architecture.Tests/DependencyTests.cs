namespace DesktopClearArchitecture.Architecture.Tests
{
    using Xunit;

    /// <summary>
    /// Tests.
    /// </summary>
    public class DependencyTests
    {
        private const string DomainNamespace = "DesktopClearArchitecture.Domain";

        [Fact]
        public void DomainShouldNotHaveDependencyToOtherProject()
        {
            var assembly = typeof(Domain).
        }
    }
}