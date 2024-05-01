using UnityEngine;
using MelonLoader;
using BoneLib.BoneMenu;
using BoneLib.BoneMenu.Elements;

namespace BLHaki
{
    public class BoneMenu : MelonMod
    {
        public static bool IsEnabled;
        public static void CreateBoneMenu()
        {
            MenuCategory menuCategory = MenuManager.CreateCategory("BL Haki", Color.black);
            SubPanelElement armamentPanel = menuCategory.CreateSubPanel("Armament Haki", Color.black);
            SubPanelElement conquerorsPanel = menuCategory.CreateSubPanel("Conquerors Haki", Color.yellow);
            armamentPanel.CreateBoolElement("Haki Toggle", Color.black, IsEnabled, ArmamentMain.OnSetEnabled);
            armamentPanel.CreateFunctionElement("Activate Armament Haki", Color.black, ArmamentMain.ActivateHaki);
            conquerorsPanel.CreateFunctionElement("Activate Conquerors Haki", Color.black, ArmamentMain.ActivateHaki);
        }
    }
}