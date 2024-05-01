using PuppetMasta;

namespace BLHaki
{
    [HarmonyLib.HarmonyPatch(typeof(PuppetMaster), "Awake")]
    public static class DisableForcePull
    {
        public static void Postfix(PuppetMaster __instance)
        {
            if (BoneMenu.IsEnabled)
            {
                __instance.activeState = PuppetMaster.State.Dead;
            }
            else
            {
                return;
            }
        }
    }
}