namespace DesktopClearArchitecture.Infrastructure.Benchs;

using BenchmarkDotNet.Running;

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