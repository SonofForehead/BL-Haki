using UnityEngine;
using MelonLoader;
using BoneLib.BoneMenu;
using BoneLib.BoneMenu.Elements;

namespace BLHaki
{
    public class HakiBoneMenu : MelonMod // Need to create 2 enum elements for controller inputs
    {
        public static int radius = 10;
        private static bool isEnabled;
        public static bool IsEnabled { get => isEnabled; set => isEnabled = value; }

        public enum controls
        {
            joystick = 0,
            doubletap = 1,
            button = 2
        }

        public static void CreateBoneMenu()
        {
            MenuCategory menuCategory = MenuManager.CreateCategory("<color=#120022>BL <color=#0d0019> H<color=#0b0014>a<color=#020004>k<color=#000000>i", Color.black);
            SubPanelElement armamentPanel = menuCategory.CreateSubPanel("Armament Haki", Color.black);
            SubPanelElement conquerorsPanel = menuCategory.CreateSubPanel("Conquerors Haki", Color.yellow);
            conquerorsPanel.CreateBoolElement("Haki Toggle", Color.black, IsEnabled, ConquerorsLogic.OnEnable);
            armamentPanel.CreateFunctionElement("Activate Armament Haki", Color.black, ArmamentLogic.ActivateArmHaki);
            conquerorsPanel.CreateIntElement("<color=#100000>R<color=#200000>a<color=#300000>d<color=#400000>i<color=#500000>u<color=#600000>s", Color.blue, radius, 1, 1, 100, (value) => radius = value);
            conquerorsPanel.CreateFunctionElement("Activate Conquerors Haki", Color.black, ConquerorsLogic.ConquerorsHakiFunction);
        }
    }
}