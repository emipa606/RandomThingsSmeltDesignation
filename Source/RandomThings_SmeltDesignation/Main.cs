using System.Reflection;
using HarmonyLib;
using Verse;

namespace SmeltDesignation;

[StaticConstructorOnStartup]
public static class Main
{
    static Main()
    {
        new Harmony("Mlie.SmeltDesignation").PatchAll(Assembly.GetExecutingAssembly());
    }
}