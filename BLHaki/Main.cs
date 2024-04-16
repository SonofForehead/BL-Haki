using System;
using MelonLoader;
using UnityEngine;
using BoneLib;

namespace BLHakiMain
{
    public static class BuildInfo
    {
        public const string Name = "BLHaki";
        public const string Author = "Son of Forehead";
        public const string Version = "0.0.0";
    }

    public class HakiMain : MelonMod
    {
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            MelonLogger.Msg("OnLevelWasLoaded: " + sceneName);
        }
    }
}