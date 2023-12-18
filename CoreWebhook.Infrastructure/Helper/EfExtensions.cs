using Microsoft.EntityFrameworkCore;

namespace CoreWebhook.Infrastructure.Helper
{
    public static class EfExtensions
    {
        /// <summary>
        /// Set table's name to Uppercase
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void ToUpperCaseTables(this ModelBuilder modelBuilder)
        {
            foreach(var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.SetTableName(entityType.GetTableName().ToUpper());
            }
        }
        /// <summary>
        /// Set column's name to uppercase
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void ToUpperCaseColumns(this ModelBuilder modelBuilder)
        {
            foreach(var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach(var property in entityType.GetProperties())
                {
                    property.SetColumnName(property.GetColumnBaseName().ToUpper());
                }
            }
        }

        /// <summary>
		/// Set foreignkey's name to Uppercase
		/// </summary>
		/// <param name="modelBuilder"></param>
		public static void ToUpperCaseForeignKeys(this ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    foreach (var fk in entityType.FindForeignKeys(property))
                    {
                        fk.SetConstraintName(fk.GetConstraintName().ToUpper());
                    }
                }
            }
        }

        /// <summary>
        /// Set index's name to Uppercase
        /// </summary>
        /// <param name="modelBuilder"></param>
        [Obsolete]
        public static void ToUpperCaseIndexes(this ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var index in entityType.GetIndexes())
                {
                    index.SetName(index.Name.ToUpper());
                }
            }
        }
    }
}
