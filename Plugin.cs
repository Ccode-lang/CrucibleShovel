using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace CrucibleShovel
{
    [BepInPlugin(MyGuid, PluginName, VersionString)]
    public class Plugin : BaseUnityPlugin
    {
        private const string MyGuid = "Ccode.Crucible";
        private const string PluginName = "CrucibleShovel";
        private const string VersionString = "1.5.1";

        private static readonly Harmony Harmony = new Harmony(MyGuid);

        public static ManualLogSource Log;
         
        public static Mesh newModel;

        public static Material newMaterial;
        public void Awake()
        {
            string location = ((BaseUnityPlugin)this).Info.Location;
            string text = "CrucibleShovel.dll";
            string text2 = location.TrimEnd(text.ToCharArray());
            string text3 = text2 + "crucible";
            AssetBundle val = AssetBundle.LoadFromFile(text3);
            newModel = val.LoadAssetWithSubAssets<Mesh>("untitled.obj")[0];
            newMaterial = val.LoadAsset<Material>("Untitled.001");
            Harmony.PatchAll();
            Logger.LogInfo(PluginName + " " + VersionString + " " + "loaded.");
            Log = Logger;
        }
    }
}
