using System.IO;
using AudioImportLib;
using BoneLib;
using Il2CppSLZ.Player;
using MelonLoader;
using MelonLoader.Utils;
using UnityEngine;

namespace BLHaki
{
    public static class BuildInfo
    {
        public const string Name = "BLHaki";
        public const string Author = "SonofForehead";
        public const string Version = "0.0.0";
        public const string Company = null;
        public const string DownloadLink = null;
    }

    public class HakiMain : MelonMod
    {
        static string path_UserData = MelonEnvironment.UserDataDirectory;
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
            //ConquerorsVolume.VolumeOnLoad();

            // Armament Haki
            if (BoneLib.Player.RigManager)
            {
                ArmamentLogic.meshRenderer = Player.RigManager.GetComponentInChildren<MeshRenderer>();
            }
        }

        public override void OnUpdate()
        {
            ConquerorsLogic.ConquerorsHakiLogic();
        }
    }
}