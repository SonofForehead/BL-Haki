using BoneLib;
using MelonLoader;
using UnityEngine;

namespace BLHaki
{
    public class ArmamentLogic : MelonMod
    {
        public static void ActivateArmHaki()
        { 
            if (!HakiAudioManager.HakiManager.GetComponent<AudioSource>().isPlaying)
            {
                HakiAudioManager.Play(HakiMain.armamentSFX);
            }
        }
    }
}