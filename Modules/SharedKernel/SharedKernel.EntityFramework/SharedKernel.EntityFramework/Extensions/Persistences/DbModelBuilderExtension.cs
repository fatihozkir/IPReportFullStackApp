using Microsoft.EntityFrameworkCore;

namespace SharedKernel.EntityFramework.Extensions.Persistences
{
    public static class DbModelBuilderExtension
    {
        private static readonly HashSet<Type> _allowedKeyTypes = [typeof(byte), typeof(short), typeof(int), typeof(long), typeof(Guid)];
        private static readonly string _allowedKeyTypesText = string.Join(", ", _allowedKeyTypes.Select(t => t.Name));
        extension(ModelBuilder modelBuilder)
        {
            public ModelBuilder ValidatePrimaryKeyTypes()
            {
                var entityTypes = modelBuilder.Model.GetEntityTypes();

                foreach (var entityType in entityTypes)
                {
                    var primaryKey = entityType.FindPrimaryKey();
                    if (primaryKey == null)
                    {
                        continue;
                    }

                    foreach (var keyProperty in primaryKey.Properties)
                    {
                        var propertyType = keyProperty.ClrType;
                        var underlyingType = Nullable.GetUnderlyingType(propertyType);
                        var keyType = underlyingType ?? propertyType;

                        if (!_allowedKeyTypes.Contains(keyType))
                        {
                            throw new NotSupportedException($"Type '{keyType.Name}' is not supported as the Primary Key for the database tables. Entity: {entityType.ClrType.Name}, Property: {keyProperty.Name} KeyType: {keyType.Name}, AllowedTypes: [{_allowedKeyTypesText}]");

                        }
                    }
                }
                return modelBuilder;
            }
        }
    }
}
