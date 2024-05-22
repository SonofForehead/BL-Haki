using BoneLib;
using MelonLoader;
using SLZ.Marrow.VoidLogic;
using SLZ.Rig;
using UnityEngine;

namespace BLHaki
{
    public class ArmamentMain : MelonMod
    {
        public static bool armamentEnabled;

        public static void OnEnable(bool enable)
        {
            if(enable)
            {
                armamentEnabled = true;
            }
            else
            {
                armamentEnabled = false;
            }
        }

        public static void ActivateArmHaki()
        {
            if (HakiAudioManager.HakiManager.GetComponent<AudioSource>().isPlaying != true)
            {
                HakiAudioManager.Play(HakiMain.ArmamentSFX);
            }
        }
    }
}