using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectMediiBun.Migrations
{
    /// <inheritdoc />
    public partial class asdgfhjkop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Member_Trainer_TrainerID",
                table: "Member");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Teren_TerenID",
                table: "Reservation");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Trainer_TrainerID",
                table: "Member",
                column: "TrainerID",
                principalTable: "Trainer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Teren_TerenID",
                table: "Reservation",
                column: "TerenID",
                principalTable: "Teren",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Member_Trainer_TrainerID",
                table: "Member");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Teren_TerenID",
                table: "Reservation");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Trainer_TrainerID",
                table: "Member",
                column: "TrainerID",
                principalTable: "Trainer",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Teren_TerenID",
                table: "Reservation",
                column: "TerenID",
                principalTable: "Teren",
                principalColumn: "ID");
        }
    }
}
