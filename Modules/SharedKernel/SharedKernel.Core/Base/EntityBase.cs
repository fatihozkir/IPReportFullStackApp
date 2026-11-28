using System.ComponentModel.DataAnnotations;

namespace SharedKernel.Core.Base
{
    /// <summary>
    /// Entity Base class for a Database Entity. It does provide the primary key of the table by the given type
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public abstract class EntityBase<TKey> where TKey : notnull
    {
        /// <summary>
        /// Specifies the Primary key of the table by the given type
        /// </summary>
        [Key]
        public virtual TKey Id { get; set; } = default!;
    }
}
