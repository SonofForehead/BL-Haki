using System.IO;
using AudioImportLib;
using BoneLib;
using MelonLoader;
using RootMotion.FinalIK;
using SLZ.Combat;
using SLZ.Marrow.VoidLogic;
using UnityEngine.Rendering;
using UnityEngine;
using SLZ.Bonelab;

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
        public static AudioClip ConquerorSFX;
        public static Vector3 headPos;
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            // Add Gameobject + audio
            HakiAudioManager.HakiManager = new GameObject("HakiManager");
            int triggerLayer = LayerMask.NameToLayer("Trigger");
            HakiAudioManager.HakiManager.layer = triggerLayer;
            HakiAudioManager.HakiManager.AddComponent<AudioSource>();
            HakiAudioManager.HakiManager.GetComponent<AudioSource>().playOnAwake = false;
            
            // Add VoidLogicDamageVolume
            HakiAudioManager.HakiManager.AddComponent<DamageVolumeNode>();
            HakiAudioManager.HakiManager.AddComponent<SphereCollider>();
            HakiAudioManager.HakiManager.GetComponent<SphereCollider>().isTrigger = true;
            HakiAudioManager.HakiManager.GetComponent<SphereCollider>().radius = 25;
            HakiAudioManager.HakiManager.GetComponent<DamageVolumeNode>().enabled = false;
            HakiAudioManager.HakiManager.GetComponent<DamageVolumeNode>()._effectiveDistance = 10;
            HakiAudioManager.HakiManager.GetComponent<DamageVolumeNode>()._damageType = SLZ.Marrow.Data.AttackType.Fire;
            HakiAudioManager.HakiManager.GetComponent<DamageVolumeNode>()._tickFrequency = 0;
            HakiAudioManager.HakiManager.GetComponent<DamageVolumeNode>()._damageSourceTransform = HakiAudioManager.HakiManager.transform;
            HakiAudioManager.HakiManager.GetComponent<DamageVolumeNode>()._damage = 100;

            // Add GlobalVolume
            
        }

        public override void OnUpdate()
        {

            if (HakiAudioManager.HakiManager && HakiAudioManager.HakiManager.GetComponent<AudioSource>().isPlaying == false)
            {
                HakiAudioManager.HakiManager.GetComponent<DamageVolumeNode>().enabled = false;
            }
            else if(HakiAudioManager.HakiManager && HakiAudioManager.HakiManager.GetComponent<AudioSource>().isPlaying == true)
            {
                Player.rigManager.health.TAKEDAMAGE(-9999f);
                HakiAudioManager.HakiManager.GetComponent<DamageVolumeNode>().enabled = true;
            }

            if (Player.rigManager != null)
            {
                headPos = Player.physicsRig.m_head.position;
                HakiAudioManager.HakiManager.transform.position = headPos;
            }
        }

        public override void OnInitializeMelon()
        {
            BoneMenu.CreateBoneMenu();
            CreateAssetFolders();
            ArmamentSFX = API.LoadAudioClip($"{path_UserData}/BLHakiSFX/armamenthakisfx.wav");
            ConquerorSFX = API.LoadAudioClip($"{path_UserData}/BLHakiSFX/conquerorshakisfx.wav");
        }
        static void CreateAssetFolders()
        {
            Directory.CreateDirectory(HakiSFXPath);
        }
    }
}