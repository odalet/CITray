using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: AssemblyTitle(ThisAssembly.Title)]
[assembly: AssemblyDescription(ThisAssembly.Description)]
[assembly: AssemblyInformationalVersion(ThisAssembly.InformationalVersion)]
[assembly: AssemblyFileVersion(ThisAssembly.FileVersion)]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCulture("")]

[assembly: InternalsVisibleTo("CITray")]
[assembly: InternalsVisibleTo("CITray.Api")]

internal static partial class ThisAssembly
{
    public const string InformationalVersion = thisVersion;
    public const string FileVersion = thisVersion;

    public const string Title = "CITray.Core";
    public const string Description = "Core services for CITray";

    /// <summary>
    /// Gets the build number for this assembly (or zero if it is not set).
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "System.Int32.TryParse(System.String,System.Int32@)")]
    public static int BuildNumber
    {
        get
        {
            int buildNumber = 0;
            int.TryParse(buildNumberAsString, out buildNumber);
            return buildNumber;
        }
    }

    private const string thisVersion = ProductVersion + "." + buildNumberAsString;
}
