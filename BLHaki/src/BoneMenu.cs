using UnityEngine;
using MelonLoader;
using BoneLib.BoneMenu;
using BoneLib.BoneMenu.UI;

namespace BLHaki
{
    public class HakiBoneMenu : MelonMod
    {
        public static int radius;
        public static bool armBool;
        public static void CreateBoneMenu()
        {
            Page mainCategory = Page.Root.CreatePage("BL Haki", Color.black);
            Page conqPage = mainCategory.CreatePage("Conquerors Haki", Color.yellow);
            Page armPage = mainCategory.CreatePage("Armament Haki", Color.red);
            armPage.CreateBool("Armament Haki", Color.black, true, ToggleArm);
            armPage.CreateFunction("Activate Armament Haki", Color.red, ArmamentLogic.ActivateArmHaki);
            conqPage.CreateFunction("Activate Conquerors Haki", Color.white, ConquerorsLogic.ActivateConquerorsHaki);
            conqPage.CreateInt("Radius", Color.red, 20, 5, 0, 1000, (value) => radius = value);
        }

        public static void ToggleArm(bool armToggle)
        {
            if (armToggle)
            {
                armBool = true;
            }
            else
            {
                armBool = false;
            }
        }

    }
}