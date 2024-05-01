using UnityEngine;
using MelonLoader;
using BoneLib;
using PuppetMasta;

namespace BLHaki
{
    public class ConquerorsLogic : MelonMod
    {
         public static Collider[] brainsInsideZone;
         public static Vector3 position = Player.rigManager.physicsRig._lastHeadPos;
         public override void OnUpdate()
         {
            position = Player.rigManager.physicsRig._lastHeadPos;
            brainsInsideZone = Physics.OverlapSphere(position, 100f);

            MelonLogger.Msg(":3 " + Player.rigManager.physicsRig.m_chest.position);
           MelonLogger.Msg(":3 ");

           foreach (Collider aiBrain in brainsInsideZone)
           { 
               LoggerInstance.Msg("Somethings inside");
              if (aiBrain.GetComponent<BehaviourPowerLegs>() != null)
              {
              LoggerInstance.Msg("Ragdolled");
              aiBrain.GetComponent<BehaviourPowerLegs>().SwitchLocoState(BehaviourBaseNav.LocoState.InAir, 0f, true);
              }
          }
         }
    }
}