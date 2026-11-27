using System.ComponentModel.DataAnnotations;

namespace SharedKernel.Core.Base
{
    public abstract class EntityBase<TKey>
    {
        [Key]
        public virtual TKey Id { get; set; } = default!;
    }
}
