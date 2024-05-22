using UnityEngine;
using System.Timers;
using MelonLoader;
using BoneLib;
using SLZ.Marrow.VoidLogic;
using SLZ.VFX;

namespace BLHaki
{
    public class ConquerorsLogic : MelonMod
    {
        public static void ActivateConquerorsHaki()
        {
            if (HakiAudioManager.HakiManager.GetComponent<AudioSource>().isPlaying == false)
            {
                HakiAudioManager.Play(HakiMain.ConquerorSFX);
            }
        }
    }
}