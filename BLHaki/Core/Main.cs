using System.IO;
using AudioImportLib;
using BoneLib;
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
        public static AudioClip ArmamentSFX;
        public static Collider[] brainsInsideZone;
        public static Vector3 position = Player.rigManager.physicsRig._lastHeadPos;

        public override void OnUpdate() // I'm slowly adding things from conquerors haki logic to see whats breaking it
        {
            MelonLogger.Msg("its workin nice");
            position = Player.rigManager.physicsRig._lastHeadPos;
            //brainsInsideZone = Physics.OverlapSphere(position, 100f);
        }
        public override void OnInitializeMelon()
        {
            BoneMenu.CreateBoneMenu();
            CreateAssetFolders();
            ArmamentSFX = API.LoadAudioClip($"{path_UserData}/BLHakiSFX/HakiArmamentSFX.wav");
        }
        static void CreateAssetFolders()
        {
            Directory.CreateDirectory(HakiSFXPath);
        }
    }
}