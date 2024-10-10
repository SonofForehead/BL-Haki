using MelonLoader;
using UnityEngine;
using Jevil.PostProcessing;
using Jevil;
using HarmonyLib;
using Il2CppSLZ.VRMK;

namespace BLHaki
{
    public class ArmamentLogic : MelonMod
    {
        public static bool hakiActivated = false;
        public static void ActivateArmHaki()
        {

            if (!HakiAudioManager.HakiManager.GetComponent<AudioSource>().isPlaying)
            {
                HakiAudioManager.Play(HakiMain.armamentSFX);
                hakiActivated = true;
            }
        }
    }

    [HarmonyPatch(typeof(Avatar), "ComputeBaseStats")]
    public static class StatChange
    {
        public static void PostFix(Avatar __instance)
        {
            __instance._strengthUpper *= 10;
            //if (!__instance) { return; }

//            if(ArmamentLogic.hakiActivated && HakiBoneMenu.armBool == true)
//            {
//                MelonLogger.Msg("Changed!");
//                __instance._strengthUpper *= 10;
//            }
        }
    }

}