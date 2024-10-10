using System;
using MelonLoader;
using System.Text.RegularExpressions;
using Il2CppSLZ.Marrow.Data;
using Il2CppSLZ.Marrow.Pool;
using Il2CppSLZ.Marrow.SceneStreaming;
using Il2CppSLZ.Marrow.Warehouse;
using UnityEngine;
using System.Linq;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using UnityEngine.Rendering;
using Unity.IL2CPP.CompilerServices;
using BoneLib;

namespace Haki.Resources.Bundles
{
    internal static class Assets
    {
        private static readonly Assembly assembly = Assembly.GetExecutingAssembly();
        private static AssetBundle conqAssetBundle;
        private static AssetBundle armAssetBundle;
        //public static VolumeProfile conquerorsVolume { get; private set; }
        public static Material armHakiMat { get; private set; }
        public static Shader animeShader { get; private set; }
        public static GameObject conquerorsHakiPrefab { get; private set; }

        public static string bundlePath = "Haki.Resources.Bundles.hakiassets";

        public static void LoadConquerorsAssets()
        {
            //conqAssetBundle = HelperMethods.LoadEmbeddedAssetBundle(assembly, "Haki.Resources.Bundles.hakiassets");
            //conquerorsHakiPrefab = conqAssetBundle.LoadPersistentAsset<GameObject>("Assets/ConquerorsHakiLocalVolume.prefab");
            //conqAssetBundle.LoadAllAssets();
        }

        public static void LoadArmamentAssets()
        {
            //armAssetBundle = HelperMethods.LoadEmbeddedAssetBundle(assembly, "Haki.Resources.Bundles.hakiassets");
            //armHakiMat = armAssetBundle.LoadPersistentAsset<Material>("Assets/ArmamentHaki.mat");
            //animeShader = armAssetBundle.LoadPersistentAsset<Shader>("Assets/SLZAnime.shader");
        }

        public static void OnLoad()
        {
            //armHakiMat = new Material(animeShader);
            //conquerorsHakiPrefab = new GameObject("ConquerorsHakiLocalVolume");
        }

    }
} 