using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralSight.Foods
{
    // Comparer implements IComparer and IComparer<T>
    public class FoodNameComparer : Comparer<Food>
    {
        private static FoodNameComparer _instance = new FoodNameComparer();

        private FoodNameComparer() { }

        public static FoodNameComparer Instance { get { return _instance; } }

        public override int Compare(Food lhs, Food rhs)
        {
            if (rhs == null && lhs == null)
                return 0;
            if (lhs == null)
                return -1;
            if (rhs == null)
                return 1;
            return string.Compare(lhs.Name, rhs.Name, StringComparison.InvariantCulture);
        }
    }
}
