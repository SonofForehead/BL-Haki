using MelonLoader;
using UnityEngine;

namespace BLHaki
{
    public class HakiAudioManager : MelonMod
    {
        public static GameObject HakiManager;
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            HakiManager = new GameObject("HakiManager");
            HakiManager.AddComponent<AudioSource>();
            HakiManager.GetComponent<AudioSource>().playOnAwake = false;
        }

        public static void Play(AudioClip clip)
        {
            HakiManager.GetComponent<AudioSource>().PlayOneShot(clip, 0.2f);
        }
    }
}