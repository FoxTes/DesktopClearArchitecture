using BenchmarkDotNet.Running;

namespace DesktopClearArchitecture.Infrastructure.Bench;

/// <summary>
/// Main.
/// </summary>
public static class Program
{
    private static void Main()
    {
        BenchmarkRunner.Run<ServicesBench>();
    }
}