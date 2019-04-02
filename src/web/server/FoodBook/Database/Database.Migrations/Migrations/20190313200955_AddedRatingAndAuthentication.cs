using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodBook.Database.Migrations.Migrations
{
    public partial class AddedRatingAndAuthentication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SecurityStamp",
                table: "UserAccounts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "UserAccounts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "UserAccounts",
                nullable: false);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Recipes",
                nullable: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Recipes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_UserAccounts_Login",
                table: "UserAccounts",
                column: "Login");

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EntityId = table.Column<Guid>(nullable: false),
                    RatingNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("RatingId", x => x.Id);
                    table.UniqueConstraint("AK_Ratings_EntityId", x => x.EntityId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CreatedById",
                table: "Recipes",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_UserAccounts_CreatedById",
                table: "Recipes",
                column: "CreatedById",
                principalTable: "UserAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Ratings_Id",
                table: "Recipes",
                column: "Id",
                principalTable: "Ratings",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_UserAccounts_CreatedById",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Ratings_Id",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_UserAccounts_Login",
                table: "UserAccounts");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_CreatedById",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Recipes");

            migrationBuilder.AlterColumn<string>(
                name: "SecurityStamp",
                table: "UserAccounts",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "UserAccounts",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
