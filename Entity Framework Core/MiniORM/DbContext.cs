using Azure.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace MiniORM
{
    public abstract class DbContext
    {
        private readonly DatabaseConnection connection;

        private readonly IDictionary<Type, PropertyInfo> dbSetProperties;

        protected DbContext(string connectionString)
        {
            this.connection = new DatabaseConnection(connectionString);
            this.dbSetProperties = this.DiscoverDbSets();
            using (new ConnectionManager(this.connection))
            {
                this.InitializeDbSets();
            }
            this.MapAllRelations();
        }

        internal static ICollection<Type> AllowedSqlTypes = new HashSet<Type>()
        {
            typeof(string),
            typeof(char),
            typeof(bool),
            typeof(byte),
            typeof(short),
            typeof(int),
            typeof(long),
            typeof(float),
            typeof(double),
            typeof(decimal),
            typeof(DateTime),
            typeof(TimeSpan),
            typeof(DateOnly),
            typeof(TimeOnly)
        };

        private IDictionary<Type, PropertyInfo> DiscoverDbSets()
        {
            return this.GetType()
                .GetProperties()
                .Where(pi => pi.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                .ToDictionary(p => p.PropertyType.GetGenericArguments().First(), p => p);
        }

        private void InitializeDbSets()
        {
            foreach (KeyValuePair<Type, PropertyInfo> dbSetPropertyPair in this.dbSetProperties)
            {
                Type entityType = dbSetPropertyPair.Key;
                PropertyInfo dbSetProperty = dbSetPropertyPair.Value;

                MethodInfo? populateDbSetGenericMethod = this.GetType()
                    .GetMethod(nameof(PopulateDbSet), BindingFlags.Instance | BindingFlags.NonPublic)?
                    .MakeGenericMethod(entityType);
                if (populateDbSetGenericMethod == null)
                {
                    throw new InvalidOperationException(ExceptionMessages.PopulateDbSetNotFoundMessage);
                }

                populateDbSetGenericMethod.Invoke(this, new object[] { dbSetProperty });
            }
        }

        private void PopulateDbSet<TEntity>(PropertyInfo dbSetPropertyInfo)
            where TEntity : class, new()
        {
            IEnumerable<TEntity> tableEntities = this.LoadTableEntities<TEntity>();
            DbSet<TEntity> dbSetInstance = new DbSet<TEntity>(tableEntities);

            ReflectionHelper.ReplaceBackingField(this, dbSetPropertyInfo.Name, dbSetInstance);
        }

        private IEnumerable<TEntity> LoadTableEntities<TEntity>()
            where TEntity : class, new()
        {
            Type entityType = typeof(TEntity);
            string tableName = this.GetTableName(entityType);
            string[] columnNames = this.GetEntityColumnNames(entityType)
                .ToArray();

            IEnumerable<TEntity> tableEntities = this.connection
                .FetchResultSet<TEntity>(tableName, columnNames);

            return tableEntities;
        }

        private IEnumerable<string> GetEntityColumnNames(Type entityType)
        {
            string tableName = this.GetTableName(entityType);
            IEnumerable<string> columnNames = this.connection
                .FetchColumnNames(tableName);

            IEnumerable<string> entityColumnNames = entityType
                .GetProperties()
                .Where(pi => columnNames.Contains(pi.Name, StringComparer.InvariantCultureIgnoreCase) &&
                       pi.HasAttribute<NotMappedAttribute>() == false &&
                       AllowedSqlTypes.Contains(pi.PropertyType))
                .Select(pi => pi.Name)
                .ToArray();

            return entityColumnNames;
        }

        private string GetTableName(Type entityType)
        {
            string? tableName = entityType
                .GetCustomAttribute<TableAttribute>()?
                .Name;
            if (tableName == null)
            {
                tableName = this.dbSetProperties[entityType].Name;
            }

            return tableName;
        }

        private void MapAllRelations()
        {
            foreach (KeyValuePair<Type, PropertyInfo> dbSetPropertyPair in this.dbSetProperties)
            {
                Type entityType = dbSetPropertyPair.Key;
                object? dbSetInstance = dbSetPropertyPair.Value.GetValue(this);
                if (dbSetInstance == null)
                {
                    throw new InvalidOperationException(ExceptionMessages.NullDbSetMessage);
                }

                MethodInfo? mapRelationsGenericMethod = this.GetType()
                    .GetMethod(nameof(MapRelations), BindingFlags.Instance | BindingFlags.NonPublic)?
                    .MakeGenericMethod(entityType);
                if (mapRelationsGenericMethod == null)
                {
                    throw new InvalidOperationException(ExceptionMessages.MapRelationsNotFoundMessage);
                }

                mapRelationsGenericMethod.Invoke(this, new object[] { dbSetInstance });
            }
        }

        private void MapRelations<TEntity>(DbSet<TEntity> dbSetInstance)
            where TEntity : class, new()
        {
            Type entityType = typeof(TEntity);
            this.MapNavigationProperties(dbSetInstance);
            PropertyInfo[] navigationCollectionsProperties = entityType
                .GetProperties()
                .Where(pi => pi.PropertyType.IsGenericType &&
                             pi.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>) &&
                             this.dbSetProperties.ContainsKey(pi.PropertyType.GetGenericArguments().First()))
                .ToArray();

            foreach (PropertyInfo navigationCollectionPropInfo in navigationCollectionsProperties)
            {
                Type collectionEntityType = navigationCollectionPropInfo.PropertyType
                    .GetGenericArguments()
                    .First();

                MethodInfo? mapCollectionGenericMethod = this.GetType()
                    .GetMethod(nameof(MapNavigationCollection), BindingFlags.Instance | BindingFlags.NonPublic)?
                    .MakeGenericMethod(entityType, collectionEntityType);
                if (mapCollectionGenericMethod == null)
                {
                    throw new InvalidOperationException(ExceptionMessages.MapNavigationCollectionNotFound);
                }

                mapCollectionGenericMethod.Invoke(this, new object[] { dbSetInstance, navigationCollectionPropInfo });
            }
        }

        private void MapNavigationProperties<TEntity>(DbSet<TEntity> dbSetInstance)
            where TEntity : class, new()
        {
            Type entityType = typeof(TEntity);
            PropertyInfo[] foreignKeyProperties = entityType
                .GetProperties()
                .Where(pi => pi.HasAttribute<ForeignKeyAttribute>())
                .ToArray();
            foreach (PropertyInfo foreignKeyProperty in foreignKeyProperties)
            {
                string navigationPropertyName = foreignKeyProperty
                    .GetCustomAttribute<ForeignKeyAttribute>()!
                    .Name;
                PropertyInfo navigationProperty = entityType
                    .GetProperties()
                    .First(pi => pi.Name == navigationPropertyName);

                object? navigationDbSetInstance = this.dbSetProperties[navigationProperty.PropertyType]
                    .GetValue(this);
                if (navigationDbSetInstance == null)
                {
                    throw new InvalidOperationException(ExceptionMessages.NullDbSetMessage);
                }

                PropertyInfo navigationPrimaryKey = navigationProperty
                    .PropertyType
                    .GetProperties()
                    .First(pi => pi.HasAttribute<KeyAttribute>());
                foreach (TEntity entity in dbSetInstance)
                {
                    object? foreignKeyValue = foreignKeyProperty.GetValue(entity);
                    if (foreignKeyValue == null)
                    {
                        continue;
                    }

                    object navigationEntity = ((IEnumerable<object>)navigationDbSetInstance)
                        .First(ne => navigationPrimaryKey.GetValue(ne)!.Equals(foreignKeyValue));
                    navigationProperty.SetValue(entity, navigationEntity);
                }
            }
        }

        //TODO: Invastigate mapping of many-to-many relations.
        private void MapNavigationCollection<TEntity, TCollectionEntity>(DbSet<TEntity> dbSetInstance,
            PropertyInfo navigationCollectionPropInfo)
            where TEntity : class, new()
            where TCollectionEntity : class, new()
        {
            Type entityType = typeof(TEntity);
            Type collectionEntityType = typeof(TCollectionEntity);

            PropertyInfo[] collectionEntityPrimaryKeys = collectionEntityType
                .GetProperties()
                .Where(pi => pi.HasAttribute<KeyAttribute>())
                .ToArray();

            PropertyInfo collectionPrimaryKey = collectionEntityPrimaryKeys.First();
            PropertyInfo entityPrimaryKey = entityType
                .GetProperties()
                .First(pi => pi.HasAttribute<KeyAttribute>());
            bool isManyToMany = collectionEntityPrimaryKeys.Length > 1;
            if (isManyToMany)
            {
                collectionPrimaryKey = collectionEntityType
                    .GetProperties()
                    .First(pi => collectionEntityType
                    .GetProperty(pi.GetCustomAttribute<ForeignKeyAttribute>().Name).PropertyType == entityType);
            }

            DbSet<TCollectionEntity>? navigationCollectionDbSet =
                (DbSet<TCollectionEntity>?)this.dbSetProperties[collectionEntityType]
                .GetValue(this);
            if (navigationCollectionDbSet == null)
            {
                throw new InvalidOperationException(ExceptionMessages.NullDbSetMessage);
            }

            foreach (TEntity entity in dbSetInstance)
            {
                object entityPrimaryKeyValue = entityPrimaryKey.GetValue(entity);
                ICollection<TCollectionEntity> navigationEntities = navigationCollectionDbSet
                    .Where(ne => collectionPrimaryKey.GetValue(ne).Equals(entityPrimaryKeyValue))
                    .ToArray();
                ReflectionHelper.ReplaceBackingField(dbSetInstance, navigationCollectionPropInfo.Name,
                    navigationEntities);
            }
        }

        private static bool IsObjectValid(object obj)
        {
            ValidationContext validationContext = new ValidationContext(obj);
            ICollection<ValidationResult> validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults);
        }
    }
}
