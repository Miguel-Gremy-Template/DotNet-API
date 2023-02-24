﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Shared.Infrastructure.Migrations
{
	/// <inheritdoc />
	public partial class initialmigration : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterDatabase()
				.Annotation("MySql:CharSet", "utf8mb4");

			migrationBuilder.CreateTable(
				name: "__Identity_Role",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
					Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
						.Annotation("MySql:CharSet", "utf8mb4"),
					NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
						.Annotation("MySql:CharSet", "utf8mb4"),
					ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: false)
						.Annotation("MySql:CharSet", "utf8mb4")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK___Identity_Role", x => x.Id);
				})
				.Annotation("MySql:CharSet", "utf8mb4");

			migrationBuilder.CreateTable(
				name: "__Identity_User",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
					UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
						.Annotation("MySql:CharSet", "utf8mb4"),
					NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
						.Annotation("MySql:CharSet", "utf8mb4"),
					Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
						.Annotation("MySql:CharSet", "utf8mb4"),
					NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
						.Annotation("MySql:CharSet", "utf8mb4"),
					EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
					PasswordHash = table.Column<string>(type: "longtext", nullable: false)
						.Annotation("MySql:CharSet", "utf8mb4"),
					SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
						.Annotation("MySql:CharSet", "utf8mb4"),
					ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
						.Annotation("MySql:CharSet", "utf8mb4"),
					PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
						.Annotation("MySql:CharSet", "utf8mb4"),
					PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
					TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
					LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
					LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
					AccessFailedCount = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK___Identity_User", x => x.Id);
				})
				.Annotation("MySql:CharSet", "utf8mb4");

			migrationBuilder.CreateTable(
				name: "__Identity_RoleClaim",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
					RoleId = table.Column<int>(type: "int", nullable: false),
					ClaimType = table.Column<string>(type: "longtext", nullable: false)
						.Annotation("MySql:CharSet", "utf8mb4"),
					ClaimValue = table.Column<string>(type: "longtext", nullable: false)
						.Annotation("MySql:CharSet", "utf8mb4")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK___Identity_RoleClaim", x => x.Id);
					table.ForeignKey(
						name: "FK___Identity_RoleClaim___Identity_Role_RoleId",
						column: x => x.RoleId,
						principalTable: "__Identity_Role",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				})
				.Annotation("MySql:CharSet", "utf8mb4");

			migrationBuilder.CreateTable(
				name: "__Identity_UserClaim",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
					UserId = table.Column<int>(type: "int", nullable: false),
					ClaimType = table.Column<string>(type: "longtext", nullable: false)
						.Annotation("MySql:CharSet", "utf8mb4"),
					ClaimValue = table.Column<string>(type: "longtext", nullable: false)
						.Annotation("MySql:CharSet", "utf8mb4")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK___Identity_UserClaim", x => x.Id);
					table.ForeignKey(
						name: "FK___Identity_UserClaim___Identity_User_UserId",
						column: x => x.UserId,
						principalTable: "__Identity_User",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				})
				.Annotation("MySql:CharSet", "utf8mb4");

			migrationBuilder.CreateTable(
				name: "__Identity_UserLogin",
				columns: table => new
				{
					LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
						.Annotation("MySql:CharSet", "utf8mb4"),
					ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false)
						.Annotation("MySql:CharSet", "utf8mb4"),
					ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
						.Annotation("MySql:CharSet", "utf8mb4"),
					UserId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK___Identity_UserLogin", x => new { x.LoginProvider, x.ProviderKey });
					table.ForeignKey(
						name: "FK___Identity_UserLogin___Identity_User_UserId",
						column: x => x.UserId,
						principalTable: "__Identity_User",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				})
				.Annotation("MySql:CharSet", "utf8mb4");

			migrationBuilder.CreateTable(
				name: "__Identity_UserRole",
				columns: table => new
				{
					UserId = table.Column<int>(type: "int", nullable: false),
					RoleId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK___Identity_UserRole", x => new { x.UserId, x.RoleId });
					table.ForeignKey(
						name: "FK___Identity_UserRole___Identity_Role_RoleId",
						column: x => x.RoleId,
						principalTable: "__Identity_Role",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK___Identity_UserRole___Identity_User_UserId",
						column: x => x.UserId,
						principalTable: "__Identity_User",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				})
				.Annotation("MySql:CharSet", "utf8mb4");

			migrationBuilder.CreateTable(
				name: "__Identity_UserToken",
				columns: table => new
				{
					UserId = table.Column<int>(type: "int", nullable: false),
					LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
						.Annotation("MySql:CharSet", "utf8mb4"),
					Name = table.Column<string>(type: "varchar(255)", nullable: false)
						.Annotation("MySql:CharSet", "utf8mb4"),
					Value = table.Column<string>(type: "longtext", nullable: false)
						.Annotation("MySql:CharSet", "utf8mb4")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK___Identity_UserToken", x => new { x.UserId, x.LoginProvider, x.Name });
					table.ForeignKey(
						name: "FK___Identity_UserToken___Identity_User_UserId",
						column: x => x.UserId,
						principalTable: "__Identity_User",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				})
				.Annotation("MySql:CharSet", "utf8mb4");

			migrationBuilder.CreateIndex(
				name: "RoleNameIndex",
				table: "__Identity_Role",
				column: "NormalizedName",
				unique: true);

			migrationBuilder.CreateIndex(
				name: "IX___Identity_RoleClaim_RoleId",
				table: "__Identity_RoleClaim",
				column: "RoleId");

			migrationBuilder.CreateIndex(
				name: "EmailIndex",
				table: "__Identity_User",
				column: "NormalizedEmail");

			migrationBuilder.CreateIndex(
				name: "UserNameIndex",
				table: "__Identity_User",
				column: "NormalizedUserName",
				unique: true);

			migrationBuilder.CreateIndex(
				name: "IX___Identity_UserClaim_UserId",
				table: "__Identity_UserClaim",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX___Identity_UserLogin_UserId",
				table: "__Identity_UserLogin",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX___Identity_UserRole_RoleId",
				table: "__Identity_UserRole",
				column: "RoleId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "__Identity_RoleClaim");

			migrationBuilder.DropTable(
				name: "__Identity_UserClaim");

			migrationBuilder.DropTable(
				name: "__Identity_UserLogin");

			migrationBuilder.DropTable(
				name: "__Identity_UserRole");

			migrationBuilder.DropTable(
				name: "__Identity_UserToken");

			migrationBuilder.DropTable(
				name: "__Identity_Role");

			migrationBuilder.DropTable(
				name: "__Identity_User");
		}
	}
}
