using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;
using HarmonyLib;

namespace Crests
{

    public class Recipe_InstallCrestBase : RecipeWorker
    {
        public override IEnumerable<BodyPartRecord> GetPartsToApplyOn(Pawn pawn, RecipeDef recipe)
        {
            if (rjw.Genital_Helper.has_genitals(pawn) || rjw.xxx.is_slime(pawn))
            {
                bool blocked = rjw.Genital_Helper.genitals_blocked(pawn);

                if (!blocked)
                {
                foreach (BodyPartRecord bodyPart in pawn.health.hediffSet.GetNotMissingParts())
                    {
                    if (recipe.appliedOnFixedBodyParts.Contains(bodyPart.def))
                        yield return bodyPart;
                    }
                }

            }
        }

        public override void ApplyOnPawn(Pawn pawn, BodyPartRecord part, Pawn billDoer, List<Thing> ingredients, Bill bill)
        {
            pawn.health.AddHediff(recipe.addsHediff, part);
        }
    }

}