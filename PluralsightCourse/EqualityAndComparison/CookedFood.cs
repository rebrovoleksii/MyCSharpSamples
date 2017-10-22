using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralSight.Foods
{
    public sealed class CookedFood : Food
    {
        public string CookingMethod { get; set; }

        public  CookedFood(string name, FoodGroup type, string cookingMethod) :
            base(name, type)
        {
            this.CookingMethod = cookingMethod;
        }

        public override bool Equals(object obj)
        {
            if (!base.Equals(obj))
                return false;
            CookedFood other = obj as CookedFood;
            return  this.CookingMethod == other.CookingMethod;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} ({2})", this.CookingMethod, this.Name, this.Type.ToString());
        }
    }
}
