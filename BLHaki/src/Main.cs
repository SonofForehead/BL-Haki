using System.IO;
using AudioImportLib;
using BoneLib;
using CSCore;
using Il2CppSLZ.Marrow;
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
        public const string Version = "1.0.0";
        public const string Company = null;
        public const string DownloadLink = null;
    }

    public class HakiMain : MelonMod
    {
        static string path_UserData = MelonEnvironment.UserDataDirectory;
        public static string HakiSFXPath = path_UserData + "/BLHakiSFX";
        public static AudioClip armamentSFX;
        public static AudioClip conquerorSFX;
        public static AudioSource audioSource;

        public override void OnInitializeMelon()
        {
            Haki.Resources.Bundles.Assets.LoadConquerorsAssets();
            Haki.Resources.Bundles.Assets.LoadArmamentAssets();
            HakiBoneMenu.CreateBoneMenu();
            Directory.CreateDirectory(HakiSFXPath);
            armamentSFX = API.LoadAudioClip($"{path_UserData}/BLHakiSFX/armamenthakisfx.wav");
            conquerorSFX = API.LoadAudioClip($"{path_UserData}/BLHakiSFX/conquerorshakisfx.wav");
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            HakiAudioManager.HakiManager = new GameObject("HakiManager");
            int triggerLayer = LayerMask.NameToLayer("Trigger");
            HakiAudioManager.HakiManager.layer = triggerLayer;
            HakiAudioManager.HakiManager.AddComponent<AudioSource>();
            audioSource = HakiAudioManager.HakiManager.GetComponent<AudioSource>();
            audioSource.playOnAwake = false;

            ConquerorsLogic.ConquerorsHakiComponents();

            HakiAudioManager.HakiManager.AddComponent<MeshRenderer>().material = Haki.Resources.Bundles.Assets.armHakiMat;
        }

        public override void OnUpdate()
        {
            if (Player.RigManager)
            {
                HakiAudioManager.HakiManager.transform.position = Player.PhysicsRig.m_head.position;
            }

            ConquerorsLogic.ConquerorsUpdate();
        }
    }
}