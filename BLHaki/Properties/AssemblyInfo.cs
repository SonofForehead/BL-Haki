using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using MelonLoader;
[assembly: AssemblyTrademark(BLHaki.BuildInfo.Company)]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
[assembly: MelonInfo(typeof(BLHaki.HakiMain), BLHaki.BuildInfo.Name, BLHaki.BuildInfo.Version, BLHaki.BuildInfo.Author, BLHaki.BuildInfo.DownloadLink)]


// Create and Setup a MelonModGame to mark a Mod as Universal or Compatible with specific Games.
// If no MelonModGameAttribute is found or any of the Values for any MelonModGame on the Mod is null or empty it will be assumed the Mod is Universal.
// Values for MelonModGame can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame(null, null)]