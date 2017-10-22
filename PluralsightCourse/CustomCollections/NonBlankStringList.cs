using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralSight.CustomCollections
{
    /// <summary>
    /// Collection<T> designed for inheritance
    /// </summary>
    public class NonBlankStringList : Collection<string>
    {
        public NonBlankStringList(IList<string> list)
            : base(list)
        {
        }

        protected override void InsertItem(int index, string item)
        {
            if (!string.IsNullOrWhiteSpace(item))
            {
                base.InsertItem(index, item);
            }
            else
            {
                throw new ArgumentException("Value of the element can't be null or whitespace");
            }
        }

        protected override void SetItem(int index, string item)
        {
            if (!string.IsNullOrWhiteSpace(item))
            {
                base.SetItem(index, item);
            }
            else
            {
                throw new ArgumentException("Value of the element can't be null or whitespace");
            }
        }
    }
}
