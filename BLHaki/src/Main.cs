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
        static string path_UserData = MelonUtils.UserDataDirectory;
        public static string HakiSFXPath = path_UserData + "/BLHakiSFX";
        public static AudioClip armamentSFX;
        public static AudioClip conquerorSFX;

        public override void OnInitializeMelon()
        {
            HakiBoneMenu.CreateBoneMenu();
            Directory.CreateDirectory(HakiSFXPath);
            armamentSFX = API.LoadAudioClip($"{path_UserData}/BLHakiSFX/armamenthakisfx.wav");
            conquerorSFX = API.LoadAudioClip($"{path_UserData}/BLHakiSFX/conquerorshakisfx.wav");
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            // Add Gameobject + audio
            HakiAudioManager.HakiManager = new GameObject("HakiManager");
            int triggerLayer = LayerMask.NameToLayer("Trigger");
            HakiAudioManager.HakiManager.layer = triggerLayer;
            HakiAudioManager.HakiManager.AddComponent<AudioSource>();
            HakiAudioManager.HakiManager.GetComponent<AudioSource>().playOnAwake = false;

            // Conquerors Haki
            ConquerorsLogic.ConquerorsComponents();
            ConquerorsVolume.VolumeOnLoad();
        }

        public override void OnUpdate()
        {
            ConquerorsLogic.ConquerorsHakiLogic();
        }

        //static void CreateAssetFolders()
        //{
            //Directory.CreateDirectory(HakiSFXPath);
        //}
    }
}