using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralSight.Foods
{
    public class Food
    {
        public FoodGroup Type { get; set; }

        public string Name { get; set; }

        public Food(string name, FoodGroup type)
        {
            this.Name = name;
            this.Type = type;
        }

        public static bool operator ==(Food lhs, Food rhs)
        {
            //inside it calls virtual object.Equals
            return object.Equals(lhs, rhs);
        }

        public static bool operator !=(Food lhs, Food rhs)
        {
            return !object.Equals(lhs, rhs);
        }

        // when implemented static object.Equals will work
        // because inside it call virtual object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            Food other = obj as Food;
            return this.Name == other.Name && this.Type == other.Type;

        }
        public override string ToString()
        {
            return String.Format("{0} ({1})", this.Name, this.Type.ToString());
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.Type.GetHashCode();
        }
    }
}
