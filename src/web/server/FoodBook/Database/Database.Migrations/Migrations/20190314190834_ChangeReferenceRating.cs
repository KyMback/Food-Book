using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodBook.Database.Migrations.Migrations
{
    public partial class ChangeReferenceRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Ratings_Id",
                table: "Recipes");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Ratings_EntityId",
                table: "Ratings");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_EntityId",
                table: "Ratings",
                column: "EntityId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Recipes_EntityId",
                table: "Ratings",
                column: "EntityId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Recipes_EntityId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_EntityId",
                table: "Ratings");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Ratings_EntityId",
                table: "Ratings",
                column: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Ratings_Id",
                table: "Recipes",
                column: "Id",
                principalTable: "Ratings",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
