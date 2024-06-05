using UnityEngine;
using MelonLoader;
using BoneLib;
using SLZ.Marrow.VoidLogic;

namespace BLHaki
{
    public class ConquerorsLogic : MelonMod
    {
        public static Vector3 headPos;
        public static DamageVolumeNode damageVolume;
        public static AudioSource conqSFX;
        public static float conqTimer = 2f;
        public static bool conqTimerRunning = false;
        public static bool armamentEnabled;

        public static void OnEnable(bool enable)
        {
            if (enable)
            {
                armamentEnabled = true;
            }
            else
            {
                armamentEnabled = false;
            }
        }

        public static void ConquerorsHakiFunction()
        {
            if (conqSFX.isPlaying == false)
            {
                HakiAudioManager.Play(HakiMain.conquerorSFX);
                conqTimerRunning = true;
            }
        }

        public static void ActivateConquerorsHaki()
        {
            Player.rigManager.health.TAKEDAMAGE(-9999f);
            HakiAudioManager.HakiManager.GetComponent<DamageVolumeNode>().enabled = true;
        }

        public static void DeactivateConquerorsHaki()
        {
            conqTimerRunning = false;
            conqTimer = 2f;
            HakiAudioManager.HakiManager.GetComponent<DamageVolumeNode>().enabled = false;
        }

        public static void ConquerorsHakiLogic() // OnUpdate
        {
            if (Player.rigManager != null)
            {
                headPos = Player.physicsRig.m_head.position;
                HakiAudioManager.HakiManager.transform.position = headPos;
            }

            if (conqTimerRunning)
            {
                conqTimer -= Time.deltaTime;
                ActivateConquerorsHaki();
            }
            
            if (conqTimer <= 0f)
            {
                DeactivateConquerorsHaki();
            }

            if (ArmamentLogic.armamentEnabled && Player.rigManager && Player.rightController._thumbstickDown)
            {
                ConquerorsLogic.ConquerorsHakiFunction();
            }

            if(Player.rigManager)
            {
                HakiAudioManager.HakiManager.GetComponent<SphereCollider>().radius = HakiBoneMenu.radius;
                damageVolume._effectiveDistance = HakiBoneMenu.radius;
            }
        }

        public static void ConquerorsComponents() // OnLevelLoad
        {
            conqSFX = HakiAudioManager.HakiManager.GetComponent<AudioSource>();

            // Add VoidLogicDamageVolume
            HakiAudioManager.HakiManager.AddComponent<DamageVolumeNode>();
            HakiAudioManager.HakiManager.AddComponent<SphereCollider>();
            HakiAudioManager.HakiManager.GetComponent<SphereCollider>().isTrigger = true;
            damageVolume = HakiAudioManager.HakiManager.GetComponent<DamageVolumeNode>();
            damageVolume.enabled = false;
            damageVolume._damageType = SLZ.Marrow.Data.AttackType.Fire;
            damageVolume._tickFrequency = 0;
            damageVolume._damageSourceTransform = HakiAudioManager.HakiManager.transform;
            damageVolume._damage = 100;
        }
    }
}