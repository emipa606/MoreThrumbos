using RimWorld;
using Verse;

namespace Thrumbo;

[DefOf]
public static class PawnKindDefOf
{
    public static PawnKindDef BlondThrumboPawn;

    public static PawnKindDef GingerThrumboPawn;

    public static PawnKindDef BionicThrumboPawn;

    public static PawnKindDef BionicDamagedThrumboPawn;

    public static PawnKindDef BlackThrumboPawn;

    public static PawnKindDef SilverThrumboPawn;

    static PawnKindDefOf()
    {
        DefOfHelper.EnsureInitializedInCtor(typeof(PawnKindDefOf));
    }
}