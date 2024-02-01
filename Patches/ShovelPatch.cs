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
            if (__instance.GetType() == typeof(Shovel))
            {
                MonoBehaviour bh = __instance as MonoBehaviour;
                bh.gameObject.GetComponent<MeshFilter>().sharedMesh = CrucibleShovel.Plugin.newModel;
            }
        }
    }
}
