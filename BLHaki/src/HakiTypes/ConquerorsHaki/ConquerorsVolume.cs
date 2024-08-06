using MelonLoader;
//using UnityEngine.Rendering;
//using UnityEngine.Rendering.Universal;

namespace BLHaki
{
    public class ConquerorsVolume : MelonMod
    {
        //public static Volume hakiVolume;

        public static void VolumeOnLoad() // Issues with this: Profile name isnt being changed, though the components are getting added.And the settings are either not effecting anything(likely), or arent getting changed.
        {
            //HakiAudioManager.HakiManager.AddComponent<Volume>();
            //hakiVolume = HakiAudioManager.HakiManager.GetComponent<Volume>();
           // hakiVolume.profile.name = "hakiProfile";
            //hakiVolume.profile.Add<ColorAdjustments>(true);
            //hakiVolume.profile.Add<ChromaticAberration>(true);
            //hakiVolume.profile.components[1].Cast<ColorAdjustments>().IsActive();
           // hakiVolume.profile.components[1].Cast<ColorAdjustments>().postExposure.value = 3;
            //hakiVolume.profile.components[2].Cast<ChromaticAberration>().IsActive();
            //hakiVolume.profile.components[2].Cast<ChromaticAberration>().intensity.value = 1;

            //MelonLogger.Msg(hakiVolume.profile.components[1].Cast<ColorAdjustments>().postExposure.value);
           // MelonLogger.Msg(hakiVolume.profile.components[2].Cast<ChromaticAberration>().intensity.value);

            

        }

    }
}