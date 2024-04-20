using System.IO;
using AudioImportLib;
using MelonLoader;
using UnityEngine;

namespace BLHaki
{
    public static class BuildInfo
    {
        public const string Name = "BLHaki";
        public const string Author = "Son of Forehead";
        public const string Version = "0.0.0";
        public const string DownloadLink = null;
        public const string Company = null;
    }

    public class HakiMain : MelonMod
    {
        static readonly string path_UserData = MelonUtils.UserDataDirectory;
        public static string HakiSFXPath = path_UserData + "/BLHakiSFX";
        public static AudioClip ArmamentSFX;
        public override void OnInitializeMelon()
        {
            BoneMenu.CreateBoneMenu();
            CreateAssetFolders();
            LoadAudio();
        }
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            HakiAudioManager.spawnAudioObject = new GameObject("HakiAudioManager");
            HakiAudioManager.spawnAudioObject.AddComponent<AudioSource>();
            HakiAudioManager.spawnAudioObject.GetComponent<AudioSource>().playOnAwake = false;
        }
        private static void LoadAudio()
        {
            ArmamentSFX = API.LoadAudioClip($"{path_UserData}/BLHakiSFX/HakiArmamentSFX.wav");
        }
        static void CreateAssetFolders()
        {
            Directory.CreateDirectory(HakiSFXPath);
        }
    }
}