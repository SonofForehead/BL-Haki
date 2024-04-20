using UnityEngine;

namespace BLHaki
{
    public class HakiAudioManager
    {
        public static GameObject spawnAudioObject;
        public static void Play(AudioClip clip)
        {
            AudioSource getAudio = spawnAudioObject.GetComponent<AudioSource>();
            getAudio.PlayOneShot(clip, 0.2f);
        }
    }
}