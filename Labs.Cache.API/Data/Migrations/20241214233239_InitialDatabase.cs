using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labs.Cache.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TenantId",
                table: "Users",
                column: "TenantId");

            // Esse script se encontra em sql/create_indexed_view.sql para análise.
            migrationBuilder.Sql("--Set the options to support indexed views.\r\nSET NUMERIC_ROUNDABORT OFF;\r\nSET ANSI_PADDING,\r\n    ANSI_WARNINGS,\r\n    CONCAT_NULL_YIELDS_NULL,\r\n    ARITHABORT,\r\n    QUOTED_IDENTIFIER,\r\n    ANSI_NULLS ON;\r\n\r\n--Create view with SCHEMABINDING.\r\nIF OBJECT_ID('dbo.UserSummary', 'view') IS NOT NULL\r\n    DROP VIEW dbo.UserSummary;\r\nGO\r\n\r\nCREATE VIEW dbo.UserSummary\r\n    WITH SCHEMABINDING\r\nAS\r\nSELECT u.Id AS UserId, \r\n\t   u.Name AS [Name], \r\n\t   u.Email AS Email, \r\n\t   t.Name AS TenantName,\r\n\t   r.Name AS RoleName\r\nFROM dbo.Users u INNER JOIN\r\n\t dbo.Tenants t on u.TenantId = t.Id INNER JOIN \r\n\t dbo.Roles r on u.RoleId = r.Id;\r\nGO\r\n\r\n--Create an index on the view. (materialization)\r\nCREATE UNIQUE CLUSTERED INDEX IDX_V1 ON dbo.UserSummary (\r\n    UserId\r\n);\r\nGO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.Sql(@"DROP VIEW dbo.UserSummary;");
        }
    }
}
