using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralSight.Foods
{
    public class FoodStructEqualityComparer : EqualityComparer<FoodStruct>
    {
        private static FoodStructEqualityComparer _instance = new FoodStructEqualityComparer();

        private FoodStructEqualityComparer() {}

        public static FoodStructEqualityComparer Instance { get { return _instance; } }
        /// <summary>
        /// Compares FoodStruct ignoring case of Name field
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override bool Equals(FoodStruct x, FoodStruct y)
        {
            return x.Name.ToUpperInvariant() == y.Name.ToUpperInvariant() && x.Type == y.Type;
        }

        public override int GetHashCode(FoodStruct obj)
        {
            return obj.Name.ToUpperInvariant().GetHashCode() ^ obj.Type.GetHashCode(); 
        }
    }
}
