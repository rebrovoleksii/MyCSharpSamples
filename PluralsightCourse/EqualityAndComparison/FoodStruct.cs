using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralSight.Foods
{
    public enum FoodGroup { Fruit, Vegetable, Meat, Dairy }

    public struct FoodStruct :IEquatable<FoodStruct>
    {
        public FoodGroup Type { get; private set; }

        public string Name { get; private set; }

 
        public FoodStruct(string name, FoodGroup type) : this ()
        {
            this.Name = name;
            this.Type = type;
        }

        public static bool operator ==(FoodStruct lhs, FoodStruct rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(FoodStruct lhs, FoodStruct rhs)
        {
            return !lhs.Equals(rhs);
        }

        // use this method to avoid boxing
        // this is the container of equality logic and it could be reused
        public bool Equals(FoodStruct other)
        {
            return this.Name == other.Name && this.Type == other.Type;
        }

        // when implemented static object.Equals will work
        // because inside it call virtual object.Equals
        // overriding this method helps avoid reflection
        public override bool Equals(object obj)
        {
            
            if (obj is FoodStruct)
                return this.Equals((FoodStruct)obj);
            else
                return false;  
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.Type.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0} ({1})", this.Name, this.Type.ToString());
        }
    }
}
