using UnityEngine;
using MelonLoader;
using BoneLib.BoneMenu;
using BoneLib.BoneMenu.Elements;

namespace BLHaki
{
    public class BoneMenu : MelonMod
    {
        private static bool isEnabled;
        public static bool IsEnabled { get => isEnabled; set => isEnabled = value; }

        public static void CreateBoneMenu()
        {
            MenuCategory menuCategory = MenuManager.CreateCategory("BL Haki", Color.black);
            SubPanelElement armamentPanel = menuCategory.CreateSubPanel("Armament Haki", Color.black);
            SubPanelElement conquerorsPanel = menuCategory.CreateSubPanel("Conquerors Haki", Color.yellow);
            armamentPanel.CreateBoolElement("Haki Toggle", Color.black, IsEnabled, ArmamentMain.OnEnable);
            armamentPanel.CreateFunctionElement("Activate Armament Haki", Color.black, ArmamentMain.ActivateArmHaki);
            conquerorsPanel.CreateFunctionElement("Activate Conquerors Haki", Color.black, ConquerorsLogic.ActivateConquerorsHaki);
        }
    }
}