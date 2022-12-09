using System.Collections.Generic;
using HarmonyLib;
using Verse;

namespace SmeltDesignation;

[HarmonyPatch(typeof(ReverseDesignatorDatabase), "InitDesignators")]
public static class ReverseDesignatorDatabase_InitDesignators
{
    public static void Postfix(List<Designator> ___desList)
    {
        ___desList.Add(new Designator_SmeltItem());
    }
}