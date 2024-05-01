using BoneLib;
using MelonLoader;
using UnityEngine;

namespace BLHaki
{
    public class ArmamentMain : MelonMod
    {
        public static void OnSetEnabled(bool enable)
        {
            if(enable && Player.rigManager.physicsRig.rightHand.physHand.forceMultiplier == 0)
            {
                Player.rigManager.physicsRig.rightHand.physHand.forceMultiplier = 1;
            }
        }
        public static void ActivateHaki()
        {
            if (HakiAudioManager.HakiManager.GetComponent<AudioSource>().isPlaying != true)
            {
                HakiAudioManager.Play(HakiMain.ArmamentSFX);
            }
        }
    } 
}