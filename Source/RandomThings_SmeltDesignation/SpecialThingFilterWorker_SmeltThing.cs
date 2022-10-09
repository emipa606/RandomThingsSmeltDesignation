using Verse;

namespace SmeltDesignation;

public class SpecialThingFilterWorker_SmeltThing : SpecialThingFilterWorker
{
    public override bool Matches(Thing t)
    {
        return t.Map.designationManager.DesignationOn(t, SmeltDefOf.SmeltDesignation) == null;
    }

    public override bool AlwaysMatches(ThingDef def)
    {
        return false;
    }

    public override bool CanEverMatch(ThingDef def)
    {
        return false;
    }
}