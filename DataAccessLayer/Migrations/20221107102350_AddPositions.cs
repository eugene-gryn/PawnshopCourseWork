using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class AddPositions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SecondName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ThirdName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Serial = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: true),
                    Number = table.Column<string>(type: "VARCHAR(9)", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.CheckConstraint("CHK_DateIsGrater18", "(DATEDIFF(year, Birthday, GETDATE()) > 17)");
                });

            migrationBuilder.CreateTable(
                name: "OperationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkerPositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerPositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pawnshops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TimeOpen = table.Column<TimeSpan>(type: "time", nullable: false),
                    TimeClose = table.Column<TimeSpan>(type: "time", nullable: false),
                    MoneyAvailable = table.Column<float>(type: "real", nullable: false),
                    CityId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pawnshops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pawnshops_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pawnshops_Cities_CityId1",
                        column: x => x.CityId1,
                        principalTable: "Cities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SecondName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ThirdName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Salt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PawnshopId = table.Column<int>(type: "int", nullable: false),
                    PawnshopId1 = table.Column<int>(type: "int", nullable: true),
                    WorkerPositionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workers_Pawnshops_PawnshopId",
                        column: x => x.PawnshopId,
                        principalTable: "Pawnshops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Workers_Pawnshops_PawnshopId1",
                        column: x => x.PawnshopId1,
                        principalTable: "Pawnshops",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Workers_WorkerPositions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "WorkerPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Workers_WorkerPositions_WorkerPositionId",
                        column: x => x.WorkerPositionId,
                        principalTable: "WorkerPositions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Makes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    IssuancePercent = table.Column<float>(type: "real", nullable: false),
                    Income = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Close = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false),
                    IsSold = table.Column<bool>(type: "bit", nullable: false),
                    PawnshopId = table.Column<int>(type: "int", nullable: false),
                    WorkerId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    CustomerId1 = table.Column<int>(type: "int", nullable: true),
                    PawnshopId1 = table.Column<int>(type: "int", nullable: true),
                    WorkerId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Makes_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Makes_Customers_CustomerId1",
                        column: x => x.CustomerId1,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Makes_Pawnshops_PawnshopId",
                        column: x => x.PawnshopId,
                        principalTable: "Pawnshops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Makes_Pawnshops_PawnshopId1",
                        column: x => x.PawnshopId1,
                        principalTable: "Pawnshops",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Makes_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Makes_Workers_WorkerId1",
                        column: x => x.WorkerId1,
                        principalTable: "Workers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Sum = table.Column<int>(type: "int", nullable: true),
                    OperationTypeId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    WorkerId = table.Column<int>(type: "int", nullable: false),
                    PawnshopId = table.Column<int>(type: "int", nullable: false),
                    CustomerId1 = table.Column<int>(type: "int", nullable: true),
                    OperationTypeId1 = table.Column<int>(type: "int", nullable: true),
                    PawnshopId1 = table.Column<int>(type: "int", nullable: true),
                    WorkerId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Operations_Customers_CustomerId1",
                        column: x => x.CustomerId1,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Operations_OperationTypes_OperationTypeId",
                        column: x => x.OperationTypeId,
                        principalTable: "OperationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Operations_OperationTypes_OperationTypeId1",
                        column: x => x.OperationTypeId1,
                        principalTable: "OperationTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Operations_Pawnshops_PawnshopId",
                        column: x => x.PawnshopId,
                        principalTable: "Pawnshops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Operations_Pawnshops_PawnshopId1",
                        column: x => x.PawnshopId1,
                        principalTable: "Pawnshops",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Operations_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Operations_Workers_WorkerId1",
                        column: x => x.WorkerId1,
                        principalTable: "Workers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Makes_CustomerId",
                table: "Makes",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Makes_CustomerId1",
                table: "Makes",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Makes_PawnshopId",
                table: "Makes",
                column: "PawnshopId");

            migrationBuilder.CreateIndex(
                name: "IX_Makes_PawnshopId1",
                table: "Makes",
                column: "PawnshopId1");

            migrationBuilder.CreateIndex(
                name: "IX_Makes_WorkerId",
                table: "Makes",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Makes_WorkerId1",
                table: "Makes",
                column: "WorkerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_CustomerId",
                table: "Operations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_CustomerId1",
                table: "Operations",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_OperationTypeId",
                table: "Operations",
                column: "OperationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_OperationTypeId1",
                table: "Operations",
                column: "OperationTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_PawnshopId",
                table: "Operations",
                column: "PawnshopId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_PawnshopId1",
                table: "Operations",
                column: "PawnshopId1");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_WorkerId",
                table: "Operations",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_WorkerId1",
                table: "Operations",
                column: "WorkerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Pawnshops_CityId",
                table: "Pawnshops",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pawnshops_CityId1",
                table: "Pawnshops",
                column: "CityId1");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_PawnshopId",
                table: "Workers",
                column: "PawnshopId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_PawnshopId1",
                table: "Workers",
                column: "PawnshopId1");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_PositionId",
                table: "Workers",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_WorkerPositionId",
                table: "Workers",
                column: "WorkerPositionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Makes");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "OperationTypes");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "Pawnshops");

            migrationBuilder.DropTable(
                name: "WorkerPositions");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
