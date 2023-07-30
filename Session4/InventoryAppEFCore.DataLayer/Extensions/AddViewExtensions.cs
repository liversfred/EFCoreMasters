using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryAppEFCore.DataLayer.Extensions
{
    public static class AddViewExtensions
    {
        public static void AddViewViaSql<TView>(                  
            this MigrationBuilder migrationBuilder, string viewName, string viewQuery)                                      
            where TView : class                                   
        {
            if (!migrationBuilder.IsSqlServer())                  
                throw new NotImplementedException("This command only works for SQL Server");                         

            var viewSql = $"CREATE OR ALTER VIEW {viewName} AS {viewQuery}";                              

            migrationBuilder.Sql(viewSql);                        
        }
    }
}
