using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookInfo.Web.Migrations.ApplicationDb
{
    public partial class IdentityTwoDbFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Reader_BookReaderReaderId",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reader",
                table: "Reader");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Reader");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Reader");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Reader");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Reader");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Reader");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Reader");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Reader");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Reader");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Reader");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Reader");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Reader");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Reader");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Reader");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Reader");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Reader");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Reader");

            migrationBuilder.RenameTable(
                name: "Reader",
                newName: "Readers");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Readers",
                newName: "IdentityReaderId");

            migrationBuilder.AlterColumn<int>(
                name: "BookReaderReaderId",
                table: "Review",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Readers",
                table: "Readers",
                column: "ReaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Readers_BookReaderReaderId",
                table: "Review",
                column: "BookReaderReaderId",
                principalTable: "Readers",
                principalColumn: "ReaderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Readers_BookReaderReaderId",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Readers",
                table: "Readers");

            migrationBuilder.RenameTable(
                name: "Readers",
                newName: "Reader");

            migrationBuilder.RenameColumn(
                name: "IdentityReaderId",
                table: "Reader",
                newName: "UserName");

            migrationBuilder.AlterColumn<int>(
                name: "BookReaderReaderId",
                table: "Review",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Reader",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Reader",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Reader",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Reader",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Reader",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Reader",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Reader",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Reader",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Reader",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Reader",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Reader",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Reader",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Reader",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Reader",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Reader",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Reader",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reader",
                table: "Reader",
                column: "ReaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Reader_BookReaderReaderId",
                table: "Review",
                column: "BookReaderReaderId",
                principalTable: "Reader",
                principalColumn: "ReaderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
