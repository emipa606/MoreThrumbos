using RimWorld;
using UnityEngine;
using Verse;
using Random = System.Random;

namespace Thrumbo;

public class IncidentWorker_SpecialWorker : IncidentWorker
{
    protected override bool CanFireNowSub(IncidentParms parms)
    {
        var map = (Map)parms.target;
        return !map.gameConditionManager.ConditionIsActive(GameConditionDefOf.ToxicFallout) &&
               map.mapTemperature.SeasonAndOutdoorTemperatureAcceptableFor(ThingDefOf.Thrumbo) &&
               tryFindEntryCell(map, out _);
    }

    protected override bool TryExecuteWorker(IncidentParms parms)
    {
        var map = (Map)parms.target;
        if (!tryFindEntryCell(map, out var cell))
        {
            return false;
        }

        var random = new Random();
        var pawnKindDef = ThrumboList.Thrumbos[random.Next(0, 6)];
        var num = StorytellerUtility.DefaultThreatPointsNow(map);
        var value = GenMath.RoundRandom(num / pawnKindDef.combatPower);
        var max = Rand.RangeInclusive(2, 16);
        value = Mathf.Clamp(value, 1, max);
        var num2 = Rand.RangeInclusive(90000, 150000);
        if (!RCellFinder.TryFindRandomCellOutsideColonyNearTheCenterOfTheMap(cell, map, 10f, out var result))
        {
            result = IntVec3.Invalid;
        }

        Pawn pawn = null;
        for (var i = 0; i < value; i++)
        {
            var loc = CellFinder.RandomClosewalkCellNear(cell, map, 10);
            pawn = PawnGenerator.GeneratePawn(pawnKindDef);
            GenSpawn.Spawn(pawn, loc, map, Rot4.Random);
            pawn.mindState.exitMapAfterTick = Find.TickManager.TicksGame + num2;
            if (result.IsValid)
            {
                pawn.mindState.forcedGotoPosition = CellFinder.RandomClosewalkCellNear(result, map, 10);
            }
        }

        Find.LetterStack.ReceiveLetter("LetterLabelThrumboPasses".Translate(pawnKindDef.label).CapitalizeFirst(),
            "LetterThrumboPasses".Translate(pawnKindDef.label), LetterDefOf.PositiveEvent, pawn);
        return true;
    }

    private static bool tryFindEntryCell(Map map, out IntVec3 cell)
    {
        return RCellFinder.TryFindRandomPawnEntryCell(out cell, map, CellFinder.EdgeRoadChance_Animal + 0.2f);
    }
}