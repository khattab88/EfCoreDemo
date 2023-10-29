﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreDemo.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddViewAndStroredProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER VIEW dbo.GetOnlyBookDetails
                AS
                SELECT  m.ISBN,m.Title,m.Price FROM dbo.Books m
            ");

            migrationBuilder.Sql(@"CREATE PROCEDURE dbo.getAllBookDetails   
                    @bookId int
                AS   

                    SET NOCOUNT ON;  
                    SELECT  *  FROM dbo.Books b
	                WHERE b.Id=@bookId
                GO  
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW dbo.GetOnlyBookDetails");

            migrationBuilder.Sql("DROP PROCEDURE dbo.getAllBookDetails");
        }
    }
}
