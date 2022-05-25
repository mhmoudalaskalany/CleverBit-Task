using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendCore.Data.Migrations
{
    public partial class RemoveConstraintsFromRegion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Region_Region_ParentRegionId",
                table: "Region");

            migrationBuilder.DropIndex(
                name: "IX_Region_ParentRegionId",
                table: "Region");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("abcc43c2-f7b8-4d70-8c1e-81bc61cb4518"),
                column: "Password",
                value: "AJ9vnY+1sNnoI2md55S5bIuUrzMjLbVq706QBB/pPDiMkhRZogNPE4eAq8vUoJ+LaQ==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("abcc43c2-f7b8-4d70-8c1e-81bc61cb4518"),
                column: "Password",
                value: "AJeFL6UHRJRgiiBtPsb87oMpHg724kzXevJ73wqKjwkJGDMU87V5KT+vOx0k9juSxA==");

            migrationBuilder.CreateIndex(
                name: "IX_Region_ParentRegionId",
                table: "Region",
                column: "ParentRegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Region_Region_ParentRegionId",
                table: "Region",
                column: "ParentRegionId",
                principalTable: "Region",
                principalColumn: "Id");
        }
    }
}
