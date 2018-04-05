using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Http
{
    public class ParamCollection
    {
        public ParamCollection(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }
        /// <summary>
        /// Gets or sets the name field.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value field.
        /// </summary>
        public string Value { get; set; }

    }


    /// <summary>
    /// Comparer class used to perform the sorting of the query parameters
    /// </summary>
    public class ParameterComparer : IComparer<ParamCollection>
    {
        public int Compare(ParamCollection x, ParamCollection y)
        {
            if (x.Name == y.Name)
            {
                return string.Compare(x.Value, y.Value);
            }
            else
            {
                return string.Compare(x.Name, y.Name);
            }
        }
    }

}
