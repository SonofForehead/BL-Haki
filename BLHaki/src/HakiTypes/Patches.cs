using SLZ.VRMK;

namespace BLHaki
{
    [HarmonyLib.HarmonyPatch(typeof(Avatar), "Awake")]
    public static class DisableForcePull
    {
        public static void Postfix(Avatar __instance)
        {
            
        }
    }
}
