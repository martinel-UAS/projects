using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models.Field;
using WebApplication.Models.Player;
using WebApplication.Models.Result;

namespace WebApplication.Managers
{
    public class GolfManager
    {
        public static FieldViewModel GetAdjustedField(PlayerViewModel player, FieldViewModel field)
        {
            int extraStrikes = Convert.ToInt32(player.GameHP);

            if (extraStrikes > 0)
            {

                var orderedField = from o in field.Holes
                                   orderby o.Handicap ascending
                                   select o;

                while (extraStrikes > 0)
                {
                    foreach (HoleViewModel hole in orderedField)
                    {
                        hole.Par++;
                        extraStrikes--;
                        if (extraStrikes == 0) break;
                    }
                }

                orderedField = from o in field.Holes
                               orderby o.HoleId ascending
                               select o;

                field.Equals(orderedField);
            }
             
            return field;

        }

        public static int GetStablefordScore(HoleViewModel hole)         
        {
                var dif = hole.SelectedStrikes - hole.Par;
                switch (dif)
                {
                    case 2:
                        return 0;
                    case 1:
                        return 1;
                    case 0:
                        return 2;
                    case -1:
                        return 3;
                    case -2:
                        return 4;
                    case -3:
                        return 5;
                    case -4:
                        return 6;
                    default:
                        return 0;
                }    
        }

        public static double GetNewHandicap(int totalStrikes, FieldViewModel field, PlayerViewModel player)
             {

                 if (player.GameHP >= 21) return player.GameHP;

                 var FieldPar = 0;

                 foreach (var hole in field.Holes)
                 {
                     FieldPar = FieldPar + hole.Par;
                 }

                 var difNeto = totalStrikes - FieldPar;

                 if (difNeto < 5 && difNeto > 0) return player.GameHP;
                 
                 else if (difNeto < 0) 
                 {
                     if (player.GameHP <= 5) { player.GameHP = player.GameHP - (0.2 * Math.Abs(difNeto)); }
                     else if (player.GameHP >= 14) { player.GameHP = player.GameHP - (0.6 *  Math.Abs(difNeto)); }
                     else if (player.GameHP > 5) { player.GameHP = player.GameHP - (0.4 *  Math.Abs(difNeto)); }
                 }

                 else if (difNeto > 5) { player.GameHP = player.GameHP + 0.1; }

                 return player.GameHP;
             }

    }
}