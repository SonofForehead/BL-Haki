using MelonLoader;
using UnityEngine;

namespace BLHaki
{
    public class ArmamentLogic : MelonMod
    {
        public static MeshRenderer meshRenderer;

        public static void ActivateArmHaki()
        {
            //meshRenderer.material = Assets.Materials.armamentMat;

            if (!HakiAudioManager.HakiManager.GetComponent<AudioSource>().isPlaying)
            {
                HakiAudioManager.Play(HakiMain.armamentSFX);
            }
        }
    }
}