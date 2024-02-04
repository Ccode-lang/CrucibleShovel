using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace CrucibleShovel.Patches
{
    [HarmonyPatch(typeof(GrabbableObject), "Start")]
    internal class ShovelPatch
    {
        public static void Prefix(GrabbableObject __instance)
        {
            if ((__instance.GetType() == typeof(Shovel)) && (__instance.gameObject.GetComponentInChildren<ScanNodeProperties>() == null))
            {
                MeshFilter mesh = __instance.gameObject.GetComponentInChildren<MeshFilter>();
                mesh.mesh = CrucibleShovel.Plugin.newModel;
                Renderer renderer = __instance.gameObject.GetComponentInChildren<MeshRenderer>();
                renderer.material = CrucibleShovel.Plugin.newMaterial;
            } 
        }
    }
}
 