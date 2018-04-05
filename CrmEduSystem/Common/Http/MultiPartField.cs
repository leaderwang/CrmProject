using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Http
{
    /// <summary>
    /// Represents a muit-part field.
    /// </summary>
    public class MultiPartField
    {
        #region MultiPartField
        /// <summary>
        /// Initializes a new instance of <see cref="MultiPartField"/>.
        /// </summary>
        public MultiPartField()
        {
        }
        #endregion

        #region MultiPartField
        /// <summary>
        /// Initializes a new instance of <see cref="MultiPartField"/> with the specified <paramref name="name"/> and <paramref name="value"/>.
        /// </summary>
        /// <param name="name">The name of the field.</param>
        /// <param name="FilePath">The FilePath of the field.</param>
        public MultiPartField(string name, string FilePath)
        {
            this.Name = name;
            this.FilePath = FilePath;
        }
        #endregion

        /// <summary>
        /// Gets or sets the name of the multi-part field.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value of the multi-part field.
        /// </summary>
        internal string Value { get; set; }

        /// <summary>
        /// Gets or sets the file path of the multi-part field it it is a file field.
        /// </summary>
        public string FilePath { get; set; }
    }
}
