using MelonLoader;
using BoneLib;
using UnityEngine.Rendering;
using UnityEngine;
using Il2CppSLZ.Marrow.VoidLogic;
using Il2CppSLZ.Player;
using Il2CppSLZ.Marrow;
using Jevil.PostProcessing;

namespace BLHaki
{
    public class ConquerorsLogic : MelonMod
    {
        public static DamageVolume damageVolume;
        public static SphereCollider sphereCollider;

        public static float timer = 2f;
        public static bool timerRunning = false;
        public static void ActivateConquerorsHaki()
        {
            MelonLogger.Msg("Activated");
            damageVolume.enabled = true;

            if (HakiMain.audioSource.isPlaying == false)
            {
                HakiAudioManager.Play(HakiMain.conquerorSFX);
                timerRunning = true;
            }
        }

        public static void ConquerorsUpdate()
        {
            if (timerRunning == true)
            {
                Player.RigManager.health.SetFullHealth();
                timer -= Time.deltaTime;
                MelonLogger.Msg("Timer Going Down", timer);
            }

            if(timer <= 0f)
            {
                timerRunning = false;
                timer = 2f;

                MelonLogger.Msg("Deactivated");
                damageVolume.enabled = false;
                Player.RigManager.GetComponentInChildren<Il2CppSLZ.Marrow.Health>().healthMode = Il2CppSLZ.Marrow.Health.HealthMode.Mortal;
            }
        }

        public static void ConquerorsHakiComponents()
        {
            MelonLogger.Msg("Components Added");
            HakiAudioManager.HakiManager.AddComponent<DamageVolume>();
            HakiAudioManager.HakiManager.AddComponent<SphereCollider>();
            damageVolume = HakiAudioManager.HakiManager.GetComponent<DamageVolume>();
            sphereCollider = HakiAudioManager.HakiManager.GetComponent<SphereCollider>();

            sphereCollider.radius = 15;
            damageVolume._effectiveDistance = 15;

            damageVolume._mapLow = 1;
            damageVolume._mapHigh = 9999;
            damageVolume._damage = 100;
            damageVolume._damageType = Il2CppSLZ.Marrow.Data.AttackType.Fire;
            damageVolume.enabled = false;

            sphereCollider.isTrigger = true;
        }

    }
}