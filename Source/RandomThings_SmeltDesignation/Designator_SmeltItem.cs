using System.Linq;
using RimWorld;
using UnityEngine;
using Verse;

namespace SmeltDesignation;

public class Designator_SmeltItem : Designator
{
    public Designator_SmeltItem()
    {
        defaultLabel = "SmeltDesignation.DesignatorSmeltItem".Translate();
        defaultDesc = "SmeltDesignation.DesignatorSmeltItemDesc".Translate();
        icon = ContentFinder<Texture2D>.Get("SmeltDesignator");
        soundDragSustain = SoundDefOf.Designate_DragStandard;
        soundDragChanged = SoundDefOf.Designate_DragStandard_Changed;
        useMouseIcon = true;
        soundSucceeded = SoundDefOf.Designate_Claim;
    }

    public override int DraggableDimensions => 2;

    public override AcceptanceReport CanDesignateCell(IntVec3 loc)
    {
        if (!loc.InBounds(Map) || loc.Fogged(Map))
        {
            return false;
        }

        if (!(from t in loc.GetThingList(Map) where CanDesignateThing(t).Accepted select t).Any())
        {
            return "SmeltDesignation.MessageMustDesignateSmeltable".Translate();
        }

        return true;
    }

    public override void DesignateSingleCell(IntVec3 c)
    {
        var items = c.GetThingList(Map);
        foreach (var thing in items)
        {
            if (CanDesignateThing(thing).Accepted)
            {
                DesignateThing(thing);
            }
        }
    }

    public override AcceptanceReport CanDesignateThing(Thing t)
    {
        if (Map.designationManager.DesignationOn(t, SmeltDefOf.SmeltDesignation) != null)
        {
            return false;
        }

        return t.def.IsWithinCategory(ThingCategoryDefOf.Weapons) ||
               t.def.IsWithinCategory(ThingCategoryDefOf.Apparel);
    }

    public override void DesignateThing(Thing t)
    {
        Map.designationManager.AddDesignation(new Designation(t, SmeltDefOf.SmeltDesignation));
    }
}