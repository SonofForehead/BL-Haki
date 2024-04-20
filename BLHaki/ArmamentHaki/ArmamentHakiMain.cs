using MelonLoader;

namespace BLHaki
{
    public class ArmamentMain : MelonMod
    {
        public static void ActivateHaki()
        {
            HakiAudioManager.Play(HakiMain.ArmamentSFX);
        }
    }
}