using UnityEngine;

namespace BLHaki
{
        public class HakiAudioManager
        {
            public static GameObject HakiManager;
            public static void Play(AudioClip clip)
            {
                AudioSource getAudio = HakiManager.GetComponent<AudioSource>();
                getAudio.PlayOneShot(clip, 1f);
            }
        }
}