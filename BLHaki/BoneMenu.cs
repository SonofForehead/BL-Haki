using UnityEngine;
using MelonLoader;
using BoneLib.BoneMenu;
using BoneLib.BoneMenu.Elements;

namespace BLHaki // :3
{
    public class BoneMenu : MelonMod
    {
        public static bool IsEnabled { get; private set; }
        public static void CreateBoneMenu()
        {
            MenuCategory menuCategory = MenuManager.CreateCategory("BL Haki", Color.black);
            SubPanelElement armamentPanel = menuCategory.CreateSubPanel("Armament Haki", Color.grey);
            armamentPanel.CreateBoolElement("Haki Toggle", Color.red, IsEnabled);
            armamentPanel.CreateFunctionElement("Activate Armament Haki", Color.black, ArmamentMain.ActivateHaki);
            armamentPanel.CreateFunctionElement("Activate  Haki", Color.black, ArmamentMain.ActivateHaki);
        }
        public override void OnUpdate()
        {
            if (BoneMenu.IsEnabled) // && Player.controllerRig.leftController._aButtonDown && Player.controllerRig.rightController._aButtonDown
            {
                LoggerInstance.Msg("Enabled");
            }
            else
            {
                LoggerInstance.Msg("Disabled");
            }
        }
    }
}