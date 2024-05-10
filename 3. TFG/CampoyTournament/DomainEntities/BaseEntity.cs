using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainEntities
{
    /// <summary>
    /// The base class for all entities
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Set/Get Entity id -> It's the name of the Id column
        /// </summary>
        public int Id { get; set; }
        /// This field is used for logical delete. Its has two values, true and false. True is when the entity is delete. For default the field is 0 on table database
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}