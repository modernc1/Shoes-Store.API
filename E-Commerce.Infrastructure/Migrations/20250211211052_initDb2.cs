using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Commerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initDb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductItem_Colors_ColorId",
                table: "ProductItem");

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("026996b2-5c47-4759-87ee-922b45707e80"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("123f6c55-0d4c-4b3f-88ea-e14775a57215"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("12451821-dba6-4d9b-91d1-b9b090b33123"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("124aaa3d-7476-4947-a19f-35de593a0ba0"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("64537793-85fa-4e97-b50e-368cdc614a89"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("6a066513-e8e7-4d7a-a9b0-4f962ffd99c9"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("8e5c25f3-e878-40e3-914e-6176c1b13a48"));

            migrationBuilder.AddColumn<string>(
                name: "HexCode",
                table: "Colors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "HexCode", "Name" },
                values: new object[,]
                {
                    { new Guid("175208bf-d3fe-4029-a381-474ab0daa225"), "#4169E1", "Royal Blue" },
                    { new Guid("275208bf-d3fe-4029-a381-474ab0daa225"), "#87CEEB", "Sky Blue" },
                    { new Guid("315208bf-d3fe-4029-a381-474ab0daa225"), "#800000", "Dark Red (Maroon)" },
                    { new Guid("325208bf-d3fe-4029-a381-474ab0daa225"), "#8B0000", "Burgundy" },
                    { new Guid("335208bf-d3fe-4029-a381-474ab0daa225"), "#654321", "Brown" },
                    { new Guid("345208bf-d3fe-4029-a381-474ab0daa225"), "#D2B48C", "Tan" },
                    { new Guid("355208bf-d3fe-4029-a381-474ab0daa225"), "#F5F5DC", "Beige" },
                    { new Guid("365208bf-d3fe-4029-a381-474ab0daa225"), "#808000", "Olive Green" },
                    { new Guid("371208bf-d3fe-4029-a381-474ab0daa225"), "#4B5320", "Military Green" },
                    { new Guid("372208bf-d3fe-4029-a381-474ab0daa225"), "#228B22", "Forest Green" },
                    { new Guid("373208bf-d3fe-4029-a381-474ab0daa225"), "#FFD700", "Yellow" },
                    { new Guid("374208bf-d3fe-4029-a381-474ab0daa225"), "#FF4500", "Orange" },
                    { new Guid("375108bf-d3fe-4029-a381-474ab0daa225"), "#FFD700", "Gold" },
                    { new Guid("375208bf-d3fe-4029-a381-474ab0daa225"), "#FF0000", "Red" },
                    { new Guid("375808bf-d3fe-4029-a381-474ab0daa225"), "#C0C0C0", "Silver" },
                    { new Guid("376208bf-d3fe-4029-a381-474ab0daa225"), "#800080", "Purple" },
                    { new Guid("377208bf-d3fe-4029-a381-474ab0daa225"), "#9400D3", "Violet" },
                    { new Guid("378208bf-d3fe-4029-a381-474ab0daa225"), "#FFC0CB", "Pink" },
                    { new Guid("379208bf-d3fe-4029-a381-474ab0daa225"), "#B76E79", "Rose Gold" },
                    { new Guid("475208bf-d3fe-4029-a381-474ab0daa225"), "#000000", "Black" },
                    { new Guid("575208bf-d3fe-4029-a381-474ab0daa225"), "#FFFFFF", "White" },
                    { new Guid("675208bf-d3fe-4029-a381-474ab0daa225"), "#808080", "Gray" },
                    { new Guid("775208bf-d3fe-4029-a381-474ab0daa225"), "#D3D3D3", "Light Gray" },
                    { new Guid("875208bf-d3fe-4029-a381-474ab0daa225"), "#333333", "Charcoal" },
                    { new Guid("975208bf-d3fe-4029-a381-474ab0daa225"), "#001F3F", "Navy Blue" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItem_Colors_ColorId",
                table: "ProductItem",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductItem_Colors_ColorId",
                table: "ProductItem");

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("175208bf-d3fe-4029-a381-474ab0daa225"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("275208bf-d3fe-4029-a381-474ab0daa225"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("315208bf-d3fe-4029-a381-474ab0daa225"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("325208bf-d3fe-4029-a381-474ab0daa225"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("335208bf-d3fe-4029-a381-474ab0daa225"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("345208bf-d3fe-4029-a381-474ab0daa225"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("355208bf-d3fe-4029-a381-474ab0daa225"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("365208bf-d3fe-4029-a381-474ab0daa225"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("371208bf-d3fe-4029-a381-474ab0daa225"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("372208bf-d3fe-4029-a381-474ab0daa225"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("373208bf-d3fe-4029-a381-474ab0daa225"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("374208bf-d3fe-4029-a381-474ab0daa225"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("375108bf-d3fe-4029-a381-474ab0daa225"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("375208bf-d3fe-4029-a381-474ab0daa225"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("375808bf-d3fe-4029-a381-474ab0daa225"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("376208bf-d3fe-4029-a381-474ab0daa225"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("377208bf-d3fe-4029-a381-474ab0daa225"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("378208bf-d3fe-4029-a381-474ab0daa225"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("379208bf-d3fe-4029-a381-474ab0daa225"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("475208bf-d3fe-4029-a381-474ab0daa225"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("575208bf-d3fe-4029-a381-474ab0daa225"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("675208bf-d3fe-4029-a381-474ab0daa225"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("775208bf-d3fe-4029-a381-474ab0daa225"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("875208bf-d3fe-4029-a381-474ab0daa225"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("975208bf-d3fe-4029-a381-474ab0daa225"));

            migrationBuilder.DropColumn(
                name: "HexCode",
                table: "Colors");

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("026996b2-5c47-4759-87ee-922b45707e80"), "Red" },
                    { new Guid("123f6c55-0d4c-4b3f-88ea-e14775a57215"), "Grey" },
                    { new Guid("12451821-dba6-4d9b-91d1-b9b090b33123"), "Blue" },
                    { new Guid("124aaa3d-7476-4947-a19f-35de593a0ba0"), "Black" },
                    { new Guid("64537793-85fa-4e97-b50e-368cdc614a89"), "White" },
                    { new Guid("6a066513-e8e7-4d7a-a9b0-4f962ffd99c9"), "LightChoclate" },
                    { new Guid("8e5c25f3-e878-40e3-914e-6176c1b13a48"), "Pink" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItem_Colors_ColorId",
                table: "ProductItem",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
