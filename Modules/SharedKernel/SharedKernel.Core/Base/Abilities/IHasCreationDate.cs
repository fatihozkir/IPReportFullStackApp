namespace SharedKernel.Core.Base.Abilities
{
    /// <summary>
    /// Implements the CreatedDate property
    /// </summary>
    public interface IHasCreationDate
    {
        /// <summary>
        /// Specifies when the issued entity created.
        /// </summary>
        public DateTime CreatedDate { get; set; }

    }
}
