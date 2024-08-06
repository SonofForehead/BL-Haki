using UnityEngine;
using MelonLoader;
using BoneLib.BoneMenu;
using BoneLib.BoneMenu.UI;

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
            Page menuCategory = Page.Root.CreatePage("BL Haki", Color.black);
            Page armamentPanel = menuCategory.CreatePage("Armament Haki", Color.black);
            Page conquerorsPanel = menuCategory.CreatePage("Conquerors Haki", Color.yellow);
            conquerorsPanel.CreateBool("Haki Toggle", Color.black, IsEnabled, ConquerorsLogic.OnEnable);
            armamentPanel.CreateFunction("Activate Armament Haki", Color.black, ArmamentLogic.ActivateArmHaki);
            conquerorsPanel.CreateInt("Radius", Color.blue, radius, 1, 1, 100, (value) => radius = value);
            conquerorsPanel.CreateFunction("Activate Conquerors Haki", Color.black, ConquerorsLogic.ConquerorsHakiFunction);
        }
    }
}