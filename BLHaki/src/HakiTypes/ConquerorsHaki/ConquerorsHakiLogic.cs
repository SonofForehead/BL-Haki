using UnityEngine;
using MelonLoader;
using BoneLib;
using Il2CppSLZ.Bonelab;
using Il2CppSLZ.Bonelab.VoidLogic;
using Il2CppSLZ.Bonelab.Obsolete;
using Il2CppSLZ.Player;

namespace BLHaki
{
    public class ConquerorsLogic : MelonMod
    {
        public static Vector3 headPos;
        public static DamageVolume damageVolume;
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
            //Player.RigManager.GetComponentInChildren<Health>().healthMode = Health.HealthMode.Invincible;
            HakiAudioManager.HakiManager.GetComponent<DamageVolume>().enabled = true;
        }

        public static void DeactivateConquerorsHaki()
        {
            conqTimerRunning = false;
            conqTimer = 2f;
            //Player.RigManager.GetComponentInChildren<Health>().healthMode = Health.HealthMode.Mortal;
            HakiAudioManager.HakiManager.GetComponent<DamageVolume>().enabled = false;
        }

        public static void ConquerorsHakiLogic() // OnUpdate
        {
            if (Player.RigManager)
            {
                headPos = Player.PhysicsRig.m_head.position;
                HakiAudioManager.HakiManager.transform.position = headPos;

                HakiAudioManager.HakiManager.GetComponent<SphereCollider>().radius = HakiBoneMenu.radius;
                damageVolume._effectiveDistance = HakiBoneMenu.radius;
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

            if (Player.RigManager && Player.RightController._thumbstickDown)
            {
                ConquerorsLogic.ConquerorsHakiFunction();
            }
        }

        public static void ConquerorsComponents() // OnLevelLoad
        {
            conqSFX = HakiAudioManager.HakiManager.GetComponent<AudioSource>();

            // Add VoidLogicDamageVolume
            HakiAudioManager.HakiManager.AddComponent<DamageVolume>();
            HakiAudioManager.HakiManager.AddComponent<SphereCollider>();
            HakiAudioManager.HakiManager.GetComponent<SphereCollider>().isTrigger = true;
            damageVolume = HakiAudioManager.HakiManager.GetComponent<DamageVolume>();
            damageVolume.enabled = false;
            damageVolume._damageType = Il2CppSLZ.Marrow.Data.AttackType.Fire;
            damageVolume._damage = 100;
        }
    }
}