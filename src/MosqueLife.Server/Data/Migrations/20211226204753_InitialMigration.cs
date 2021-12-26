using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MosqueLife.Server.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Firstname = table.Column<string>(type: "text", nullable: false),
                    Lastname = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Alpha2Code = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    Alpha3Code = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK_States_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Firstname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Lastname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    MemberSince = table.Column<DateOnly>(type: "date", nullable: false),
                    StreetLine1 = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    StreetLine2 = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    HouseNumber = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    ZipCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    StateId = table.Column<Guid>(type: "uuid", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Language = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    MemberId = table.Column<Guid>(type: "uuid", nullable: false),
                    PaymentType = table.Column<int>(type: "integer", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionPaid",
                columns: table => new
                {
                    Year = table.Column<int>(type: "integer", nullable: false),
                    MemberId = table.Column<Guid>(type: "uuid", nullable: false),
                    January = table.Column<bool>(type: "boolean", nullable: false),
                    February = table.Column<bool>(type: "boolean", nullable: false),
                    March = table.Column<bool>(type: "boolean", nullable: false),
                    April = table.Column<bool>(type: "boolean", nullable: false),
                    May = table.Column<bool>(type: "boolean", nullable: false),
                    June = table.Column<bool>(type: "boolean", nullable: false),
                    July = table.Column<bool>(type: "boolean", nullable: false),
                    August = table.Column<bool>(type: "boolean", nullable: false),
                    September = table.Column<bool>(type: "boolean", nullable: false),
                    October = table.Column<bool>(type: "boolean", nullable: false),
                    November = table.Column<bool>(type: "boolean", nullable: false),
                    December = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionPaid", x => new { x.MemberId, x.Year });
                    table.ForeignKey(
                        name: "FK_SubscriptionPaid_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Alpha2Code", "Alpha3Code", "Name" },
                values: new object[,]
                {
                    { new Guid("009dfcfd-7e30-4bf8-a10b-bd7b0a476651"), "EH", "ESH", "Western Sahara" },
                    { new Guid("011b06b2-3aa8-4047-9e52-47c0ef010e4d"), "AI", "AIA", "Anguilla" },
                    { new Guid("014f2bc5-6ec6-483d-abcf-3ad3c10e0c71"), "US", "USA", "United States of America (the)" },
                    { new Guid("01eb164b-3f0f-4e77-aa7e-a42749f63c75"), "SD", "SDN", "Sudan (the)" },
                    { new Guid("02e931e6-055a-4e65-aa24-e836881d3f60"), "ES", "ESP", "Spain" },
                    { new Guid("0311f6ff-5ace-4c2d-a769-73dddfbc08ed"), "TK", "TKL", "Tokelau" },
                    { new Guid("0663734e-c1d4-4a58-9c64-bb8463c82fbf"), "UA", "UKR", "Ukraine" },
                    { new Guid("0841c778-23cb-4ea4-bb5b-950f3d4d2c10"), "BH", "BHR", "Bahrain" },
                    { new Guid("0889760b-4a1d-4163-8184-9062d56e4d8c"), "NE", "NER", "Niger (the)" },
                    { new Guid("08b97c4b-ba5c-496c-a77f-5394f483ab9e"), "MZ", "MOZ", "Mozambique" },
                    { new Guid("08c2fc07-b083-4ce7-8a28-e180ebf2326b"), "AT", "AUT", "Austria" },
                    { new Guid("0af6985e-b3a8-4225-afbe-42e7e5e9e26b"), "AD", "AND", "Andorra" },
                    { new Guid("10a74150-281e-41a3-a719-009854ccb354"), "TC", "TCA", "Turks and Caicos Islands (the)" },
                    { new Guid("1192eb08-3026-480c-b21b-f62f6ec59f50"), "JO", "JOR", "Jordan" },
                    { new Guid("12df6980-409d-4129-b6f3-d71d1ce8087a"), "FI", "FIN", "Finland" },
                    { new Guid("147b82eb-c081-41dd-b87b-635d5c5054f3"), "MR", "MRT", "Mauritania" },
                    { new Guid("150d6279-6736-4a3b-aed7-86e1b23ca6b1"), "SH", "SHN", "Saint Helena, Ascension and Tristan da Cunha" },
                    { new Guid("15f4c5e9-24bc-494c-92d5-cb3e976fe1f5"), "IS", "ISL", "Iceland" },
                    { new Guid("1a1ed865-82ce-4090-8b0b-33a28108f2dc"), "LK", "LKA", "Sri Lanka" },
                    { new Guid("1a270b09-036d-4872-992e-88c357433e50"), "KW", "KWT", "Kuwait" },
                    { new Guid("1b253905-4292-4941-9efb-f8e28762ebe1"), "BJ", "BEN", "Benin" },
                    { new Guid("1ce59e25-dd93-46b3-8425-3392cb35151f"), "NA", "NAM", "Namibia" },
                    { new Guid("1d8a0fe1-7f8f-4fa9-a336-8902b8b27a9e"), "CK", "COK", "Cook Islands (the)" },
                    { new Guid("1da6a677-dcf9-40fe-afd6-c39b35e9d529"), "TN", "TUN", "Tunisia" },
                    { new Guid("1dedcb63-8bcc-4bd9-a725-93cbc0a4644e"), "BI", "BDI", "Burundi" },
                    { new Guid("1ef58b86-ffb9-4e6d-8641-8bdb6bc2e51a"), "BB", "BRB", "Barbados" },
                    { new Guid("20e1b116-df2d-4121-be5d-0c9814248ad2"), "MH", "MHL", "Marshall Islands (the)" },
                    { new Guid("20ea933e-023a-4e5b-997e-b9bad3e54cd2"), "BA", "BIH", "Bosnia and Herzegovina" },
                    { new Guid("23c66a5d-a9f5-4a50-bde4-b7611405a1b0"), "RW", "RWA", "Rwanda" },
                    { new Guid("27265d25-3b49-4ee7-9fe7-3ba41f094e16"), "EE", "EST", "Estonia" },
                    { new Guid("2780f1a7-9056-4a52-9522-71b40442d886"), "VC", "VCT", "Saint Vincent and the Grenadines" },
                    { new Guid("284dca74-da6d-4228-9df8-5b2f5a344057"), "BV", "BVT", "Bouvet Island" },
                    { new Guid("2979bb6d-2002-4abd-8785-e34dce26cfaf"), "JE", "JEY", "Jersey" },
                    { new Guid("2b9dae73-d40c-4f48-94e1-c00f3b963c1d"), "PA", "PAN", "Panama" },
                    { new Guid("2bb4ea20-5db8-4d0e-a398-f6eed7db833c"), "CN", "CHN", "China" },
                    { new Guid("2bd96788-8ae4-494e-8637-ba347f2bbbca"), "ET", "ETH", "Ethiopia" },
                    { new Guid("2d0b5d27-c0cc-4e37-bcc8-365467f8022c"), "SZ", "SWZ", "Eswatini" },
                    { new Guid("2d235488-6cff-4a90-a2bd-2d259933fe1b"), "GI", "GIB", "Gibraltar" },
                    { new Guid("2da08c51-ec1c-4896-b349-5b0d8ca66039"), "CV", "CPV", "Cabo Verde" },
                    { new Guid("2e8acc4a-bea1-4864-b197-a63233e8c397"), "MP", "MNP", "Northern Mariana Islands (the)" },
                    { new Guid("2f7371e6-33bc-4939-9735-034aa10f6ac9"), "AR", "ARG", "Argentina" },
                    { new Guid("2f861285-ae1c-48d8-8edb-e1952d86ca80"), "MF", "MAF", "Saint Martin (French part)" },
                    { new Guid("2fc41f33-eb67-4470-81e3-116ac2769304"), "SA", "SAU", "Saudi Arabia" },
                    { new Guid("30ebf3fe-ebf9-49a5-96cf-9b709a72bc4d"), "BN", "BRN", "Brunei Darussalam" },
                    { new Guid("316b9969-ce67-4aa3-8476-7adc52407150"), "KE", "KEN", "Kenya" },
                    { new Guid("317160b1-4cb7-45b8-8e54-e98c2373466e"), "CI", "CIV", "Côte d'Ivoire" },
                    { new Guid("32617962-b412-4366-b0ea-c55f0dfc9af6"), "SY", "SYR", "Syrian Arab Republic" },
                    { new Guid("331aafed-3986-4275-b747-e2a79b1fe134"), "NO", "NOR", "Norway" },
                    { new Guid("333fdc8c-9bc7-4769-91c7-4f02726637c4"), "TV", "TUV", "Tuvalu" },
                    { new Guid("35a040fc-1049-4938-ae12-8089ff3cfe85"), "HM", "HMD", "Heard Island and McDonald Islands" },
                    { new Guid("35fcf832-8028-437a-9ac1-e080cddf275d"), "SO", "SOM", "Somalia" },
                    { new Guid("36e874da-595b-4f43-b6ed-9baf25abe8d9"), "VG", "VGB", "Virgin Islands (British)" },
                    { new Guid("36f57ced-cd3d-4763-bc60-932d6946b13c"), "SM", "SMR", "San Marino" },
                    { new Guid("3713bbb1-1b45-43d0-851e-cce44e894f05"), "FJ", "FJI", "Fiji" },
                    { new Guid("37a4d8f9-6ce1-4611-a540-4b54f936c973"), "AM", "ARM", "Armenia" },
                    { new Guid("3a02147b-7946-4b6b-9456-462ca47f11e6"), "VI", "VIR", "Virgin Islands (U.S.)" },
                    { new Guid("3a991f3a-939a-49bf-876d-cf19db30ff14"), "TD", "TCD", "Chad" },
                    { new Guid("3b63854e-07d3-4883-b997-d8a7496b0d45"), "MC", "MCO", "Monaco" },
                    { new Guid("3e7dc4b7-a517-454c-8657-0e4a2df9e67c"), "TZ", "TZA", "Tanzania, United Republic of" },
                    { new Guid("3ecaafbc-af46-4a7c-a9dc-6bb7096f8929"), "AF", "AFG", "Afghanistan" },
                    { new Guid("3f95334f-14c0-437b-b7d4-eb5b7023faf2"), "CA", "CAN", "Canada" },
                    { new Guid("43164f4e-e476-4a39-a5ee-e53bf23c6fea"), "SN", "SEN", "Senegal" },
                    { new Guid("44ae2342-0fb8-4510-9963-cced7b8def4a"), "WS", "WSM", "Samoa" },
                    { new Guid("488cc064-6271-425c-8562-c769da4c68e5"), "BL", "BLM", "Saint Barthélemy" },
                    { new Guid("494e855f-e3da-48f1-b40c-e45fc8e728dc"), "SG", "SGP", "Singapore" },
                    { new Guid("49b07547-6593-4a59-a296-9ae4322adca3"), "PF", "PYF", "French Polynesia" },
                    { new Guid("4b88870d-f147-4d55-ba6b-cf470738f945"), "TW", "TWN", "Taiwan (Province of China)" },
                    { new Guid("4ddde8d8-f7c8-48da-96a9-7e2a10cf9ef8"), "TT", "TTO", "Trinidad and Tobago" },
                    { new Guid("4e028214-1302-46c5-bce5-6ac6d7d8f550"), "KN", "KNA", "Saint Kitts and Nevis" },
                    { new Guid("4e24c555-a619-48f1-afcd-7f8e536eacc1"), "LU", "LUX", "Luxembourg" },
                    { new Guid("4f5a6bb2-55f4-4cbc-9149-61d49b14ac9d"), "CR", "CRI", "Costa Rica" },
                    { new Guid("4f8d0d0e-c5b0-4990-ac31-d80d8099e84b"), "VE", "VEN", "Venezuela (Bolivarian Republic of)" },
                    { new Guid("4fab2d4b-44f1-4d5c-9072-5aed6b58f5d1"), "VN", "VNM", "Viet Nam" },
                    { new Guid("4fb924e5-d1fb-40c7-9b48-a40441ecf3b2"), "WF", "WLF", "Wallis and Futuna" },
                    { new Guid("50444744-61c8-4a96-8747-fe03e962eb9d"), "SC", "SYC", "Seychelles" },
                    { new Guid("50aa4ab0-3c14-4550-a87f-bdfca7d90638"), "ZW", "ZWE", "Zimbabwe" },
                    { new Guid("52a225d1-fac4-408a-9b82-e3c411f6d0d5"), "KZ", "KAZ", "Kazakhstan" },
                    { new Guid("543b391b-a9fc-4e71-96a8-7cf94c4f4d5b"), "GT", "GTM", "Guatemala" },
                    { new Guid("549fba38-4427-4c65-9071-800e0afd84dc"), "PL", "POL", "Poland" },
                    { new Guid("54d14be5-6a0b-4817-928d-3b63c2fcffa6"), "DJ", "DJI", "Djibouti" },
                    { new Guid("55024a10-cfe0-472e-8f2f-748a1f960bf5"), "BR", "BRA", "Brazil" },
                    { new Guid("555f9d6e-6dd3-477d-8f6a-1131c153e061"), "BF", "BFA", "Burkina Faso" },
                    { new Guid("569f984c-be17-4c77-83ea-a0d5a43d1d5e"), "LV", "LVA", "Latvia" },
                    { new Guid("59532a0f-0c95-40c5-a1f5-fffb589540f5"), "BE", "BEL", "Belgium" },
                    { new Guid("59ed5d69-0838-4454-8186-629fc1621b93"), "NZ", "NZL", "New Zealand" },
                    { new Guid("5a5d00ef-026f-481a-a7c4-b05870e84c88"), "KY", "CYM", "Cayman Islands (the)" },
                    { new Guid("5aeb9baf-0198-4f2b-8183-a1ca51f66d96"), "MD", "MDA", "Moldova (the Republic of)" },
                    { new Guid("5e6def8e-12af-415e-9cb9-276f97914bf0"), "IQ", "IRQ", "Iraq" },
                    { new Guid("60920235-7b02-43b0-a0a9-d7a509c6cd33"), "MM", "MMR", "Myanmar" },
                    { new Guid("60ab754a-4df0-4254-a9bc-3714a25f9764"), "DO", "DOM", "Dominican Republic (the)" },
                    { new Guid("60ef64ed-5cb7-4b8e-98ad-ea9fb27486a4"), "RS", "SRB", "Serbia" },
                    { new Guid("6453c40a-f697-4223-9797-821ad45c4647"), "MW", "MWI", "Malawi" },
                    { new Guid("6470d150-c33c-49e2-b0e9-4dbb9574aedb"), "FK", "FLK", "Falkland Islands (the) [Malvinas]" },
                    { new Guid("653a5814-e9ba-4afa-97c6-3856023e2a86"), "BO", "BOL", "Bolivia (Plurinational State of)" },
                    { new Guid("6618a417-5c7d-4e24-a77d-ccfe89ec38bf"), "ML", "MLI", "Mali" },
                    { new Guid("66ee8fd1-1ee5-4354-af86-30edc54fda19"), "NP", "NPL", "Nepal" },
                    { new Guid("6a223637-18e4-4822-9c62-ba483a333d15"), "KI", "KIR", "Kiribati" },
                    { new Guid("6aa14e79-4d9a-4841-b412-367c778548b4"), "MT", "MLT", "Malta" },
                    { new Guid("6c8ab378-ddfe-4071-9f02-2cab31174dfd"), "MU", "MUS", "Mauritius" },
                    { new Guid("6e4c0de6-a8ac-481b-8e24-023d9e024c00"), "MG", "MDG", "Madagascar" },
                    { new Guid("6f096c2e-10d6-465f-8bb6-f3ca476faa63"), "ZA", "ZAF", "South Africa" },
                    { new Guid("6f4a774f-863f-4e09-b8d8-3b22cdca5deb"), "CL", "CHL", "Chile" },
                    { new Guid("6faffedf-4a24-4a05-a7e3-36f10d3a6c1c"), "GF", "GUF", "French Guiana" },
                    { new Guid("6fcffd3e-ac9a-4abd-a44b-b13a5558d743"), "AG", "ATG", "Antigua and Barbuda" },
                    { new Guid("719281fe-c79f-43a2-b31b-23c928faa8e6"), "HK", "HKG", "Hong Kong" },
                    { new Guid("7462207c-12ae-42dc-bc3e-8e0bab3cf727"), "ST", "STP", "Sao Tome and Principe" },
                    { new Guid("74eea3e2-7f1b-4c0c-b63c-7bc1c4fa8670"), "GR", "GRC", "Greece" },
                    { new Guid("7514bcc3-7881-4fb1-bc8f-c346d44fb58f"), "UG", "UGA", "Uganda" },
                    { new Guid("753d5556-64e7-46cd-bc97-2fa50d0970c2"), "AW", "ABW", "Aruba" },
                    { new Guid("76e26eff-cf3f-4d6e-aae6-cf3f6a9f5ca7"), "RE", "REU", "Réunion" },
                    { new Guid("7a56db1d-0e7e-4932-9747-3f19a79f6534"), "MV", "MDV", "Maldives" },
                    { new Guid("7a5a29fb-3171-4778-bb68-ede54e169111"), "VA", "VAT", "Holy See (the)" },
                    { new Guid("7b56a3a2-d433-4432-a3af-5c3c1872103c"), "BD", "BGD", "Bangladesh" },
                    { new Guid("7b8484e1-0a41-466c-9903-1328e8669d1b"), "GY", "GUY", "Guyana" },
                    { new Guid("7bdbabda-d487-4ec9-89b1-015a3c5e9391"), "BW", "BWA", "Botswana" },
                    { new Guid("7bf2c229-1165-4587-bcf8-cfd0b4952879"), "IR", "IRN", "Iran (Islamic Republic of)" },
                    { new Guid("7d810385-a431-4f6e-b1ed-abec8ecef91a"), "YT", "MYT", "Mayotte" },
                    { new Guid("7ee68a9a-ad8d-4392-8146-7f393f85b7ed"), "KG", "KGZ", "Kyrgyzstan" },
                    { new Guid("7f0ecd37-0e96-4271-b975-ffc72ef86cc4"), "IN", "IND", "India" },
                    { new Guid("80a1cb0a-d12c-4418-9422-49b497c64a45"), "PY", "PRY", "Paraguay" },
                    { new Guid("80f6fadb-c0e0-41eb-bfdf-c253c3c2945b"), "DE", "DEU", "Germany" },
                    { new Guid("81b25266-fa29-4280-a30e-59f6d42f3f15"), "MY", "MYS", "Malaysia" },
                    { new Guid("8596e8dc-49e8-4bae-b459-a73c9caa3767"), "LA", "LAO", "Lao People's Democratic Republic (the)" },
                    { new Guid("85cc67ab-22ec-4ef5-84b8-22490145eda5"), "KM", "COM", "Comoros (the)" },
                    { new Guid("86b175ea-352f-4437-87dd-7a64ab0a9a57"), "UY", "URY", "Uruguay" },
                    { new Guid("883ac320-106d-4749-b225-87714d705763"), "HT", "HTI", "Haiti" },
                    { new Guid("8d4c6695-ceae-4f48-b6a9-39be1ee88cf4"), "CF", "CAF", "Central African Republic (the)" },
                    { new Guid("8d82e03f-3a66-46e1-abf4-1c03e9554236"), "PE", "PER", "Peru" },
                    { new Guid("8da1077a-231d-49d8-ae2d-8c0184eafea0"), "LT", "LTU", "Lithuania" },
                    { new Guid("8eaa9550-1236-401a-ae24-810c8851ea5e"), "NI", "NIC", "Nicaragua" },
                    { new Guid("908765e7-efe7-4c56-81ac-bb2c86bcc093"), "IM", "IMN", "Isle of Man" },
                    { new Guid("90b599dc-4581-406b-8b8e-589b72e6bb9f"), "TF", "ATF", "French Southern Territories (the)" },
                    { new Guid("91a80287-a0f5-4de1-a10f-bf3a058f2b1c"), "LS", "LSO", "Lesotho" },
                    { new Guid("92a7681e-ccc7-4930-9e47-edb3d9f4e9cd"), "LC", "LCA", "Saint Lucia" },
                    { new Guid("94035b74-9598-4912-b9d4-48f7fbc6120a"), "IO", "IOT", "British Indian Ocean Territory (the)" },
                    { new Guid("94918806-4e2c-41eb-b3db-19d0c43c4280"), "EG", "EGY", "Egypt" },
                    { new Guid("9514391e-4097-4a2e-9bab-9c18d083c26d"), "NF", "NFK", "Norfolk Island" },
                    { new Guid("9596570c-3ed0-4a92-9ff5-8db594c072b0"), "MA", "MAR", "Morocco" },
                    { new Guid("9657dc08-d803-449f-8499-ab2a93267f0c"), "SS", "SSD", "South Sudan" },
                    { new Guid("96c04e08-db94-4e58-aa3c-7a4b59c31da9"), "KH", "KHM", "Cambodia" },
                    { new Guid("9744a74d-3c85-4c15-a23b-514580aaf41f"), "BM", "BMU", "Bermuda" },
                    { new Guid("9832f4a3-ed3e-4aaf-a20c-457f4a26bd62"), "NR", "NRU", "Nauru" },
                    { new Guid("983d6ec3-d9f5-4e19-a58b-efdd4d3609a7"), "FM", "FSM", "Micronesia (Federated States of)" },
                    { new Guid("98d9e46d-66c1-4f44-94f6-fb2e90b8b300"), "SJ", "SJM", "Svalbard and Jan Mayen" },
                    { new Guid("994d9d8e-ded2-4355-bb0f-f3a66a3a4779"), "GM", "GMB", "Gambia (the)" },
                    { new Guid("99abee71-db3e-4909-b4b6-c47e1b2ec49b"), "ZM", "ZMB", "Zambia" },
                    { new Guid("9a1a90f6-40fb-4a25-ab5a-2b044e587605"), "SK", "SVK", "Slovakia" },
                    { new Guid("9a8ad1d0-4c5b-489f-9ef3-0774bc698943"), "GQ", "GNQ", "Equatorial Guinea" },
                    { new Guid("9b94c3a2-2a0a-4ad0-b390-f414ac45e059"), "GN", "GIN", "Guinea" },
                    { new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "CH", "CHE", "Switzerland" },
                    { new Guid("9d5d0da6-c7a0-4cb1-bdaa-35fae9616974"), "BG", "BGR", "Bulgaria" },
                    { new Guid("9d6cb9ec-760b-417e-9b72-8addbec15624"), "PS", "PSE", "Palestine, State of" },
                    { new Guid("9d937d08-5fab-4689-8622-3b260d1d9a0f"), "CM", "CMR", "Cameroon" },
                    { new Guid("9f04b793-305a-453e-bc51-1749104536d9"), "AZ", "AZE", "Azerbaijan" },
                    { new Guid("9f10a9d9-3823-466c-beb6-dd7543100b80"), "CW", "CUW", "Curaçao" },
                    { new Guid("9fbb50fe-ff23-4abc-b524-2ed8d8b64a9b"), "LI", "LIE", "Liechtenstein" },
                    { new Guid("a18ae9ac-ed68-4b3e-85a5-037a0dac5cf6"), "ER", "ERI", "Eritrea" },
                    { new Guid("a33a5b08-d624-49b3-b451-8d371deef429"), "AL", "ALB", "Albania" },
                    { new Guid("a39279d9-e93f-4a22-abb7-6cc05e5e8874"), "IE", "IRL", "Ireland" },
                    { new Guid("a49834f0-4e9e-4402-bac5-e22d04dc3767"), "MN", "MNG", "Mongolia" },
                    { new Guid("a5f125cb-e6a2-409b-af94-54c9284204f9"), "JM", "JAM", "Jamaica" },
                    { new Guid("a70721d4-6426-4eee-a60f-95fca983cf28"), "BY", "BLR", "Belarus" },
                    { new Guid("a731ed1b-eed0-4b67-b1fd-f9e7625d0f7e"), "RU", "RUS", "Russian Federation (the)" },
                    { new Guid("a7ce5d31-a001-42ea-a5c9-9611d677df65"), "TH", "THA", "Thailand" },
                    { new Guid("a7efd015-4c3e-493c-bc62-10a7bf762825"), "NG", "NGA", "Nigeria" },
                    { new Guid("a8e34c5a-90bc-4df4-a6b7-de7f4d211125"), "GS", "SGS", "South Georgia and the South Sandwich Islands" },
                    { new Guid("aa6c7744-f7ce-442b-aab3-cee4faa9f50b"), "TJ", "TJK", "Tajikistan" },
                    { new Guid("aba79b10-e3d8-41b4-95ed-cb173b0d73e7"), "MQ", "MTQ", "Martinique" },
                    { new Guid("ac38b0f1-134e-41a9-b361-a5012e8e3d3c"), "AS", "ASM", "American Samoa" },
                    { new Guid("aca267be-8365-4b73-a806-3cb547d5a211"), "KR", "KOR", "Korea (the Republic of)" },
                    { new Guid("ad8f3577-f710-48be-a8ce-283082cdfd5c"), "TO", "TON", "Tonga" },
                    { new Guid("afbd6ead-3e62-4507-991e-2053f28f9278"), "PW", "PLW", "Palau" },
                    { new Guid("b15897b7-cb1c-4da2-b2f8-d3d7af5b3ad0"), "LY", "LBY", "Libya" },
                    { new Guid("b16a98b9-9b6f-4db0-94b1-5cfc0718f2bd"), "PK", "PAK", "Pakistan" },
                    { new Guid("b3188d20-7572-4879-9f12-44ea7c06745c"), "GB", "GBR", "United Kingdom of Great Britain and Northern Ireland (the)" },
                    { new Guid("b34073c8-5ee0-4990-a7cc-6aacb209b0d3"), "CC", "CCK", "Cocos (Keeling) Islands (the)" },
                    { new Guid("b3639d78-54dc-4fe0-989c-a8d08ab8093d"), "CX", "CXR", "Christmas Island" },
                    { new Guid("b7428613-0879-4421-b15b-a438d5c50054"), "SR", "SUR", "Suriname" },
                    { new Guid("b89d7b1a-27c3-4859-aa7e-23293f4b9ca0"), "GL", "GRL", "Greenland" },
                    { new Guid("b937694b-9236-44d6-bec4-ee8883314aa3"), "PM", "SPM", "Saint Pierre and Miquelon" },
                    { new Guid("b9939a38-eab5-4d8f-906a-e2b2c5f7da55"), "QA", "QAT", "Qatar" },
                    { new Guid("b9b8535e-1e6b-4e39-a6ac-1b7e57bfd33c"), "ID", "IDN", "Indonesia" },
                    { new Guid("bb38feee-4d81-4f56-a11b-673ca15a95a0"), "AX", "ALA", "Åland Islands" },
                    { new Guid("bba74714-4497-4806-bad9-e74075217ca2"), "CD", "COD", "Congo (the Democratic Republic of the)" },
                    { new Guid("bcd6b8f0-38b7-4310-a532-920eb5543097"), "SI", "SVN", "Slovenia" },
                    { new Guid("bdb15a05-6afc-413d-867c-47a87c2e0074"), "IL", "ISR", "Israel" },
                    { new Guid("bff539e0-82c8-4a20-8c0b-567561a2646b"), "GD", "GRD", "Grenada" },
                    { new Guid("c1badf50-9f25-4e84-a3e0-69e9fa545984"), "AE", "ARE", "United Arab Emirates (the)" },
                    { new Guid("c1eb37b8-e284-4c73-a6af-3b52dab81c39"), "NL", "NLD", "Netherlands (the)" },
                    { new Guid("c43bf101-d151-406f-8669-cc6e2ad0dba2"), "GH", "GHA", "Ghana" },
                    { new Guid("c4a41ca2-1f47-4ec3-b250-0942e31603cc"), "GA", "GAB", "Gabon" },
                    { new Guid("c5d646f9-009b-4d1b-b5fc-eb30a03e4b81"), "GU", "GUM", "Guam" },
                    { new Guid("c683f637-ddff-4238-9a1f-5ad10eeb36d9"), "YE", "YEM", "Yemen" },
                    { new Guid("c70a2df5-fd2a-4a99-9b98-7254ada8460c"), "CG", "COG", "Congo (the)" },
                    { new Guid("cad06768-0005-464d-885e-d287cdb34e5d"), "TL", "TLS", "Timor-Leste" },
                    { new Guid("cb9ec68e-1006-4525-8612-44329c816757"), "DM", "DMA", "Dominica" },
                    { new Guid("cc5ec694-7ce2-4883-8dab-05a6f148243b"), "LR", "LBR", "Liberia" },
                    { new Guid("cdea498d-1b3f-4975-af1b-2e0ec2f3cafd"), "KP", "PRK", "Korea (the Democratic People's Republic of)" },
                    { new Guid("cf48f7ca-042f-4a25-81c2-4b48332a7f5a"), "AO", "AGO", "Angola" },
                    { new Guid("d0958301-d073-4252-a183-0a2b34afcc94"), "IT", "ITA", "Italy" },
                    { new Guid("d10ff280-01b1-4ad0-b1fa-992b9dad9b53"), "GE", "GEO", "Georgia" },
                    { new Guid("d1dbe9ef-e4e0-44fd-a8f6-2a9b0b130a27"), "GW", "GNB", "Guinea-Bissau" },
                    { new Guid("d434e065-5c31-4881-bef3-b53d8adb20ce"), "BT", "BTN", "Bhutan" },
                    { new Guid("d4993250-cdb6-40da-9474-48a97971307e"), "JP", "JPN", "Japan" },
                    { new Guid("d4a71bbc-eeb2-4693-bc96-25372ccb7929"), "AU", "AUS", "Australia" },
                    { new Guid("d58e62c1-78af-4307-9aea-be667612c4c4"), "PG", "PNG", "Papua New Guinea" },
                    { new Guid("d69602bd-76f3-4785-a498-3874cbaa970f"), "DK", "DNK", "Denmark" },
                    { new Guid("d761bb47-8477-4f67-a992-2535c789f30f"), "FR", "FRA", "France" },
                    { new Guid("d8831f86-bd62-49c3-8805-b5c881acefa8"), "HU", "HUN", "Hungary" },
                    { new Guid("dc04de6a-e250-44f5-9299-f9f23eccd3ce"), "NC", "NCL", "New Caledonia" },
                    { new Guid("dea3d7d2-2c87-433f-8c82-3f3fc094325e"), "TR", "TUR", "Turkey" },
                    { new Guid("e00e2f21-a661-4e32-abf8-9c593cc62a4c"), "UZ", "UZB", "Uzbekistan" },
                    { new Guid("e0a1bbb7-6460-42fb-9492-9344f548c773"), "SE", "SWE", "Sweden" },
                    { new Guid("e1afe3c2-28ca-4078-bfe4-97064bb50719"), "SL", "SLE", "Sierra Leone" },
                    { new Guid("e2b629b1-bbc6-4d34-8b3c-35f7524cdd54"), "EC", "ECU", "Ecuador" },
                    { new Guid("e3dd51f1-acbf-4fe9-bd53-4aa8b59d425d"), "PN", "PCN", "Pitcairn" },
                    { new Guid("e55c2bf2-266d-4af5-953a-d5cdb52e9073"), "FO", "FRO", "Faroe Islands (the)" },
                    { new Guid("e69d03f7-a99d-4c6c-b392-ce217b1dc868"), "UM", "UMI", "United States Minor Outlying Islands (the)" },
                    { new Guid("e8235f90-9d31-4c9d-b7cc-8e7397057380"), "LB", "LBN", "Lebanon" },
                    { new Guid("e8929799-dff3-443c-a417-e1871ca29c90"), "MX", "MEX", "Mexico" },
                    { new Guid("ec485b6a-4a69-40d6-a34e-559c0b25f96c"), "CO", "COL", "Colombia" },
                    { new Guid("ed1149bc-0dfb-4746-b800-655809739578"), "MK", "MKD", "Republic of North Macedonia" },
                    { new Guid("ed14ef85-515a-4f7c-a001-76aec44ebe59"), "PR", "PRI", "Puerto Rico" },
                    { new Guid("ed97b7e9-06b1-40ed-bae4-c14e301d5042"), "CU", "CUB", "Cuba" },
                    { new Guid("edad8646-82cc-4137-9519-18034b1f6dea"), "PH", "PHL", "Philippines (the)" },
                    { new Guid("ee3e97c3-e3b9-49e8-9abb-3092669fd314"), "NU", "NIU", "Niue" },
                    { new Guid("ef7bc59d-1c60-4cce-b78e-77447839e181"), "DZ", "DZA", "Algeria" },
                    { new Guid("ef8601c1-4735-4350-a359-5b1ebe597e0d"), "SV", "SLV", "El Salvador" },
                    { new Guid("f1357ee3-156c-41fe-9715-2c6929590fc2"), "MO", "MAC", "Macao" },
                    { new Guid("f13ed7e7-1d76-467b-8e68-a5612cbaa169"), "TM", "TKM", "Turkmenistan" },
                    { new Guid("f1526d84-2265-407a-97ba-15e4fb61ef3f"), "GP", "GLP", "Guadeloupe" },
                    { new Guid("f1a94128-3d8d-473c-baa2-1e9c0b971cdb"), "RO", "ROU", "Romania" },
                    { new Guid("f1b3c5c2-ad82-440d-aff2-71647f75e400"), "BQ", "BES", "Bonaire, Sint Eustatius and Saba" },
                    { new Guid("f293b8ea-529e-4c90-8044-7f37717e8980"), "CZ", "CZE", "Czechia" },
                    { new Guid("f3ccee21-77d5-4bc6-a05a-2383710f5477"), "GG", "GGY", "Guernsey" },
                    { new Guid("f48fcde0-a6bb-4668-b8bf-92d028ca9ab3"), "HR", "HRV", "Croatia" },
                    { new Guid("f6422962-2b04-4470-a3c7-7bb55a7a2d45"), "PT", "PRT", "Portugal" },
                    { new Guid("f66585ce-7b53-4b9b-8122-150f8a1bdb75"), "ME", "MNE", "Montenegro" },
                    { new Guid("f6ee2169-65a5-4c0c-8ebc-eef7adf29481"), "MS", "MSR", "Montserrat" },
                    { new Guid("f71dd500-b6ae-44f8-805c-ab00d359753b"), "SB", "SLB", "Solomon Islands" },
                    { new Guid("f89b51b9-a6e5-41de-aa3c-77614e91f52e"), "AQ", "ATA", "Antarctica" },
                    { new Guid("f9fddddc-eead-4de8-b4bf-cf210c77f61c"), "SX", "SXM", "Sint Maarten (Dutch part)" },
                    { new Guid("fb561aec-6c55-4d51-9537-05facbd91dda"), "CY", "CYP", "Cyprus" },
                    { new Guid("fc1d5164-4161-4248-a795-eee401895cac"), "TG", "TGO", "Togo" },
                    { new Guid("fc6da1c1-3236-455d-8f4c-9dbc9f5214c7"), "OM", "OMN", "Oman" },
                    { new Guid("fd5dba2a-999b-4720-a0a6-d87f39cdd9b3"), "BZ", "BLZ", "Belize" },
                    { new Guid("fddff3c1-3bb3-4ee6-b9cc-628c3d53defb"), "HN", "HND", "Honduras" },
                    { new Guid("fea13ee2-a1fe-473d-97db-117027425402"), "VU", "VUT", "Vanuatu" },
                    { new Guid("ffd997c4-6cec-4993-8edd-0376784d8973"), "BS", "BHS", "Bahamas (the)" }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Code", "CountryId", "Name" },
                values: new object[,]
                {
                    { new Guid("09bbfd7a-2dd3-4ab8-86c1-1cf76a93bf5a"), "AR", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Appenzell Ausserrhoden" },
                    { new Guid("0aaf91b7-b1f9-4b82-9efd-8f9d7069ac7b"), "GL", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Glarus" },
                    { new Guid("0b0404af-da77-4a5d-84c1-149fed6795e9"), "NW", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Nidwalden" },
                    { new Guid("4fc833b0-7bb6-45a7-8b57-40d77cde7927"), "SG", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "St. Gallen" },
                    { new Guid("561f6eee-921e-4638-8e35-51a8bc2b4b9b"), "BE", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Bern" },
                    { new Guid("58545b2b-bf38-47f2-a4e7-b78c68225d1f"), "BL", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Basel-Landschaft" },
                    { new Guid("6a5165e9-d667-4984-82e3-5bcc12009da5"), "SH", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Schaffhausen" },
                    { new Guid("6bd940fa-f1bf-437c-bb6b-993a2da33701"), "TI", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Ticino" },
                    { new Guid("849c8f78-501a-40ce-b374-73e0a7249790"), "OW", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Obwalden" },
                    { new Guid("9a71b829-fb15-42d4-b733-028d0ff5a387"), "JU", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Jura" },
                    { new Guid("9baa5577-eca8-49b7-8ccb-0e9ade6fdc92"), "LU", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Luzern" },
                    { new Guid("9d7b864a-ee6f-46c6-ab2d-ad6a8e803cb7"), "GR", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Graubünden; Grisons; Grigioni" },
                    { new Guid("a2be2120-bea1-462e-8ddc-0d218cb0628b"), "TG", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Thurgau" },
                    { new Guid("a82b7de4-969a-4c30-837d-fd90883d4901"), "NE", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Neuchâtel" },
                    { new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "VD", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Vaud" },
                    { new Guid("c653c92b-3d0a-4faa-b605-1fd2c9ec180d"), "ZG", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Zug" },
                    { new Guid("c89f3cb9-a5ae-4b68-a0fc-807d7f4331a6"), "VS", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Valais; Wallis" },
                    { new Guid("ca8e3cdf-1425-41d1-9493-aaab5ecad07f"), "SZ", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Schwyz" },
                    { new Guid("cce40cc0-8e6d-41e2-9bbe-1127690bb70d"), "ZH", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Zürich" },
                    { new Guid("dab9e513-99c2-4d4f-91ad-6da85be3a317"), "BS", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Basel-Stadt" },
                    { new Guid("db02d941-c810-427c-9fe0-e3e93ab34094"), "SO", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Solothurn" },
                    { new Guid("e515b746-6c8b-4bd5-a6b0-2c5f35d258e9"), "AI", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Appenzell Innerrhoden" },
                    { new Guid("eb9afd42-0165-4074-99bf-e9e114e49a64"), "GE", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Genève" },
                    { new Guid("ef15a7dd-6f56-47b6-8b1b-88e9424b5d41"), "FR", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Fribourg; Freiburg" },
                    { new Guid("f5a28e04-194b-442b-a590-f6a94d356ce9"), "AG", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Aargau" },
                    { new Guid("f7eeae1c-9aa9-4e91-b372-ed433a1cbcc7"), "UR", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Uri" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "BirthDate", "City", "Email", "Firstname", "HouseNumber", "Language", "Lastname", "MemberSince", "PhoneNumber", "StateId", "StreetLine1", "StreetLine2", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("037bc4e3-5593-46f7-b91d-f4d234ebb8e7"), new DateOnly(1976, 5, 31), "Saint-Étienne", null, "Félicie", "9", 2, "Lefebvre", new DateOnly(2020, 11, 23), null, new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "72 Allée Marcadet", "Apt. 503", "16255" },
                    { new Guid("1d968608-0bac-4b7d-a2bb-3b6e6a5df2e5"), new DateOnly(1985, 2, 21), "Bourges", null, "Alaïs", "930", 1, "Bourgeois", new DateOnly(2018, 6, 2), null, new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "886 Passage de l'Odéon", "7 étage", "86640" },
                    { new Guid("21852f57-283d-41d7-81c5-abab51ea1f96"), new DateOnly(1953, 3, 31), "Bourges", null, "Mauricette'", "32", 2, "Colin", new DateOnly(2016, 11, 21), null, new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "51 Quai de la Huchette", "8 étage", "14328" },
                    { new Guid("2241f7c2-56e2-47ca-990a-74eeea967bb9"), new DateOnly(1978, 4, 12), "Amiens", null, "Alice", "80", 2, "Gonzalez", new DateOnly(2019, 1, 24), null, new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "9455 Boulevard des Grands Augustins", "7 étage", "74818" },
                    { new Guid("38d15922-121a-4bf4-86c0-f855d82d0043"), new DateOnly(1995, 5, 24), "Montpellier", null, "Emmanuel", "939", 1, "Baron", new DateOnly(2016, 5, 12), null, new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "71 Allée Marcadet", "Apt. 002", "57337" },
                    { new Guid("49208646-b259-4f1e-b974-0f4f6e3e7581"), new DateOnly(1991, 6, 2), "Mulhouse", null, "Henriette", "6589", 0, "Marchand", new DateOnly(2016, 3, 27), null, new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "60 Impasse Montorgueil", "7 étage", "05277" },
                    { new Guid("51ddc486-ea21-4eed-966b-725ba507f84f"), new DateOnly(1973, 6, 27), "Villeurbanne", null, "Bathilde", "1194", 1, "Lopez", new DateOnly(2019, 7, 17), null, new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "0816 Avenue d'Argenteuil", "Apt. 996", "72436" },
                    { new Guid("5c875dc4-be9f-4393-9701-b38032878f4f"), new DateOnly(1990, 8, 31), "Pau", null, "Guenièvre", "7", 0, "Arnaud", new DateOnly(2018, 2, 17), null, new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "1264 Allée Saint-Honoré", "8 étage", "16104" },
                    { new Guid("6c8a9f30-dd14-40bc-8f72-94fab82010dd"), new DateOnly(1967, 8, 6), "Vénissieux", null, "Timoléon", "5412", 0, "Gaillard", new DateOnly(2015, 5, 10), null, new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "7854 Impasse Delesseux", "3 étage", "51345" },
                    { new Guid("6ebc0c06-ed18-43b4-b9c0-45fe65110580"), new DateOnly(1965, 10, 4), "Tours", null, "Aphélie", "05", 0, "Renard", new DateOnly(2013, 7, 21), null, new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "46 Voie de Seine", "3 étage", "58063" },
                    { new Guid("78aecccb-50ba-4d70-b847-0c7c2071ab9a"), new DateOnly(1995, 8, 29), "Bourges", null, "Léon", "3", 0, "Gautier", new DateOnly(2015, 10, 4), null, new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "0 Boulevard de la Huchette", "1 étage", "93692" },
                    { new Guid("88954795-7e42-4935-9a08-030d7ed88878"), new DateOnly(1992, 5, 14), "Saint-Maur-des-Fossés", null, "Ascelin", "2", 0, "Gautier", new DateOnly(2019, 4, 20), null, new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "6 Passage de la Pompe", "5 étage", "02000" },
                    { new Guid("915d5d3f-620d-4966-a312-4d5af3b07c1c"), new DateOnly(1992, 1, 13), "Champigny-sur-Marne", null, "Damien", "036", 1, "Bernard", new DateOnly(2013, 7, 10), null, new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "443 Quai Adolphe Mille", "Apt. 707", "14776" },
                    { new Guid("ace2d1a9-0654-43ed-bc3e-001a36da5c81"), new DateOnly(1969, 2, 16), "Antony", null, "Hilaire", "8", 0, "Le roux", new DateOnly(2013, 6, 7), null, new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "6 Quai d'Abbeville", "2 étage", "33591" },
                    { new Guid("afb471ee-620f-47da-a14c-f767894c607e"), new DateOnly(1959, 9, 28), "Nantes", null, "Moïsette", "601", 0, "Gerard", new DateOnly(2016, 12, 13), null, new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "99 Impasse d'Abbeville", "Apt. 953", "95350" },
                    { new Guid("c9262fd0-d92d-4bcc-85db-9c179d66c822"), new DateOnly(1997, 6, 22), "Reims", null, "Isabeau", "580", 1, "Richard", new DateOnly(2012, 10, 9), null, new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "2 Impasse de la Victoire", "Apt. 051", "20147" },
                    { new Guid("ce15a0d0-f2f4-400a-93bc-eb32becb2e15"), new DateOnly(1955, 7, 25), "Le Mans", null, "Edmond", "189", 0, "Thomas", new DateOnly(2021, 4, 9), null, new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "589 Boulevard de Presbourg", "5 étage", "61006" },
                    { new Guid("d4866fa1-0094-4eb8-bddc-e4d7c8777d60"), new DateOnly(1954, 11, 29), "Tourcoing", null, "Cassandre", "4189", 0, "Duval", new DateOnly(2015, 6, 17), null, new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "95 Allée de Richelieu", "5 étage", "54359" },
                    { new Guid("dc744156-73d3-4ebe-9574-334a24a9a7ee"), new DateOnly(1965, 9, 2), "Mulhouse", null, "Marc", "3", 2, "Laurent", new DateOnly(2019, 11, 24), null, new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "89 Allée du Chat-qui-Pêche", "Apt. 394", "90286" },
                    { new Guid("e236781c-6290-4c4f-b634-e339fd8ebc2a"), new DateOnly(1997, 1, 1), "Pau", null, "Ariane", "193", 0, "Dubois", new DateOnly(2015, 1, 3), null, new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "91 Quai Bonaparte", "3 étage", "39483" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "MemberId", "Note", "PaymentDate", "PaymentType" },
                values: new object[,]
                {
                    { new Guid("0029658f-700f-4663-9a96-857a2f3fa4b3"), 0m, new Guid("915d5d3f-620d-4966-a312-4d5af3b07c1c"), "Repudiandae ut culpa. Enim beatae dolorem et omnis tenetur. Illum veniam molestiae quis iste nostrum sunt consequatur. Consectetur rerum nesciunt porro vitae id alias et odio officiis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("00e726ab-6271-436e-be07-5e372a110e44"), 0m, new Guid("88954795-7e42-4935-9a08-030d7ed88878"), "Rem voluptas et quis nesciunt consectetur. Ut dolorem reiciendis ipsa molestiae. Eius praesentium nostrum aut omnis quo omnis voluptatem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("016df0dd-5184-47a5-87bf-f06d1549809e"), 0m, new Guid("dc744156-73d3-4ebe-9574-334a24a9a7ee"), "Dicta minima possimus quas eum blanditiis. Quia earum quos ex repellat tempore quaerat. Fugit molestiae iure alias quisquam sunt unde dolores. Aut ut pariatur aut aut ipsam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("024a82df-b954-46f5-bb3d-d2ce3b0f2e66"), 0m, new Guid("e236781c-6290-4c4f-b634-e339fd8ebc2a"), "Cum aperiam odio exercitationem et vel illum praesentium. Consequuntur perferendis voluptas aut consequuntur perferendis minus. Quos rerum odio nemo. Aut iusto quod accusantium voluptas.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("0270b64d-3bea-4829-9911-231ff39f1314"), 0m, new Guid("2241f7c2-56e2-47ca-990a-74eeea967bb9"), "Optio nisi expedita nostrum consequatur dignissimos non dolorem. Quod fugiat aut et quos tempora aut accusamus. Provident delectus quia blanditiis nesciunt.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("02d059d7-307b-444a-bd12-34f2c372634d"), 0m, new Guid("21852f57-283d-41d7-81c5-abab51ea1f96"), "Consequatur quos eaque earum eaque.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("041ea4d0-2704-4bd8-afcb-1a5886be8773"), 0m, new Guid("c9262fd0-d92d-4bcc-85db-9c179d66c822"), "Et laboriosam commodi ut dignissimos possimus. Fugiat delectus est dolor repellat eaque velit hic possimus. Aut numquam consequatur voluptatem fugiat corporis. Dolores recusandae modi voluptate iure aut deleniti.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("04801a97-c75f-4d9a-aee6-561844f06d8e"), 0m, new Guid("51ddc486-ea21-4eed-966b-725ba507f84f"), "Facilis error ut dolorum debitis culpa qui fugit. Ea nulla nihil atque repudiandae sit fugiat cum eum enim. Dolorum fuga ut voluptatem voluptatum. Rerum soluta est laudantium aut recusandae quis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("0733c273-fb1b-4af7-aa8c-0ca1ae414466"), 0m, new Guid("21852f57-283d-41d7-81c5-abab51ea1f96"), "Impedit non rerum asperiores. Debitis nulla rem vel assumenda nulla eveniet in libero qui.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("0b356484-cbc2-4d15-8c89-07220eb132b0"), 0m, new Guid("2241f7c2-56e2-47ca-990a-74eeea967bb9"), "Placeat esse consequatur libero in aperiam. Voluptas qui animi quos mollitia. Omnis tempora eius ad sunt quae. Incidunt nam molestias sunt eos non consequuntur animi molestias est.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("0be4bc1e-9fac-4124-aa31-e5f70ecce9cc"), 0m, new Guid("e236781c-6290-4c4f-b634-e339fd8ebc2a"), "Qui quibusdam dolorem iste consequatur placeat. Maiores a nisi atque voluptas laboriosam tempore odit corporis quis. Dicta est fugiat ea est doloremque incidunt in expedita repudiandae. Eligendi ratione corporis aut nemo ut earum accusamus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("0c90ae5f-1b8a-4ed4-a8a1-b4e677cb1b34"), 0m, new Guid("2241f7c2-56e2-47ca-990a-74eeea967bb9"), "Qui dolores dicta a cumque.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("0cf8cbea-21bd-4e49-874d-ef8f768768d1"), 0m, new Guid("78aecccb-50ba-4d70-b847-0c7c2071ab9a"), "Unde doloribus et fuga omnis incidunt pariatur impedit. Itaque consequatur maxime quod consequatur et molestiae quae a. Necessitatibus aliquid doloribus. Placeat nulla quas ut numquam doloremque alias sed.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("0dd6e18e-00a6-4f85-896e-cb6434a2a092"), 0m, new Guid("5c875dc4-be9f-4393-9701-b38032878f4f"), "Quod a voluptas aut vel quia nobis. Et occaecati voluptas cum labore quis quidem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("0f900f4a-0058-41e4-b67a-765d9b1b18e6"), 0m, new Guid("d4866fa1-0094-4eb8-bddc-e4d7c8777d60"), "Vero iure non. Libero voluptatem omnis esse non aut quidem. Et dolores ut adipisci enim. Omnis tenetur voluptates voluptatum quisquam quidem dolorem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("0fbd284e-8643-49d2-8884-4da07f886f9d"), 0m, new Guid("dc744156-73d3-4ebe-9574-334a24a9a7ee"), "Officia dignissimos nostrum pariatur. Omnis sint autem in cupiditate impedit alias officia. Qui commodi nisi deleniti non sequi et. Laborum facilis maxime quis aut eveniet veritatis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("11263cb0-3a36-4e73-9957-96cfa5f960fd"), 0m, new Guid("ace2d1a9-0654-43ed-bc3e-001a36da5c81"), "Explicabo voluptas voluptate minus facilis accusantium tenetur nulla deleniti nulla. Veniam nulla quis. Soluta a fugiat ullam. Quisquam quidem aut autem beatae.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("129fb89c-4b02-4bb6-9bfe-5e7562fdfe88"), 0m, new Guid("49208646-b259-4f1e-b974-0f4f6e3e7581"), "Magnam autem ut sit culpa.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("13402e8e-e002-43ba-8c6e-c4af07bfba54"), 0m, new Guid("88954795-7e42-4935-9a08-030d7ed88878"), "Ut fugit odio minus ut ex alias exercitationem voluptas. Earum rerum qui quos totam rem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("13cccb58-83bc-4e41-8be8-4f980f80a58f"), 0m, new Guid("5c875dc4-be9f-4393-9701-b38032878f4f"), "Adipisci quaerat ut quae qui ut vero.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("15468c7e-969c-49a3-959d-9b4996e347d7"), 0m, new Guid("915d5d3f-620d-4966-a312-4d5af3b07c1c"), "Esse suscipit veritatis sit soluta cumque exercitationem ducimus perspiciatis consequatur. Maxime quo adipisci sit saepe et aut. Perferendis repellat occaecati animi aut nostrum maxime quasi autem. Expedita officiis ipsa.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("161a947e-d5c8-48b3-bfee-272012e28578"), 0m, new Guid("ace2d1a9-0654-43ed-bc3e-001a36da5c81"), "Sint sed quis amet cumque deserunt officia molestiae. Eligendi molestiae eum odio et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("16bcca6e-4400-400b-8604-537dafc6fd05"), 0m, new Guid("51ddc486-ea21-4eed-966b-725ba507f84f"), "Incidunt nihil laudantium cumque ut quos voluptatem. Incidunt est quia. Delectus quia praesentium omnis repudiandae facilis cupiditate dolor cupiditate.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("16e6fe61-17ff-4eaa-9e19-32f7600f33e7"), 0m, new Guid("dc744156-73d3-4ebe-9574-334a24a9a7ee"), "Eaque nisi veritatis voluptatem amet qui. Voluptas non mollitia.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("1845492f-2482-476b-8b24-09b812157e95"), 0m, new Guid("51ddc486-ea21-4eed-966b-725ba507f84f"), "Molestiae fugiat dolor esse hic sapiente iusto aut placeat qui. Quibusdam vitae minus dignissimos consequatur maxime nemo sint tempore quidem. Itaque eius adipisci. Velit id maxime dicta.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("18f59a19-5177-4527-9a05-d5f8dbf732d7"), 0m, new Guid("6c8a9f30-dd14-40bc-8f72-94fab82010dd"), "Culpa molestias vero minus. Eius reprehenderit debitis perferendis. Omnis voluptatem ipsum et doloribus dolorem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("1a0bf250-5687-4969-872d-ea8d2d9b6109"), 0m, new Guid("afb471ee-620f-47da-a14c-f767894c607e"), "Sit minus esse dolorum. Quam dolorem incidunt quod reprehenderit. Error et illo ab illo et. Voluptatibus quis iure perferendis ut ab porro nihil a.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("1ac8a980-10f5-47ef-a05a-2c2e0f04d223"), 0m, new Guid("e236781c-6290-4c4f-b634-e339fd8ebc2a"), "Nihil vero quisquam sit eius velit. Suscipit cumque itaque est.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("1c9317bc-dc46-499f-8269-72658135f975"), 0m, new Guid("ace2d1a9-0654-43ed-bc3e-001a36da5c81"), "Consequatur aut repudiandae voluptates eaque ut dolor blanditiis autem illo. Ratione in laborum dignissimos fugiat aut sed.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("1d2495ac-72c6-4410-90d6-46013bb4f888"), 0m, new Guid("6ebc0c06-ed18-43b4-b9c0-45fe65110580"), "Tenetur nostrum sit quam. Magni veritatis accusamus blanditiis iure expedita qui.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("1d3db2e1-5d78-465c-a0c1-f0c8e2becc5d"), 0m, new Guid("49208646-b259-4f1e-b974-0f4f6e3e7581"), "Iure voluptatem est asperiores distinctio aut doloribus iure natus. Qui eius cumque omnis dolores assumenda expedita aperiam. Eaque nobis minus aspernatur rerum exercitationem quia. Maxime aut non quaerat dolorum quia quis odit quam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("205c440f-f9f8-4824-a951-0f534715e099"), 0m, new Guid("afb471ee-620f-47da-a14c-f767894c607e"), "Ut nihil et quia est minus alias quis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("216a51f0-7b39-4236-9a4a-6959ade3ac53"), 0m, new Guid("38d15922-121a-4bf4-86c0-f855d82d0043"), "Et unde deleniti fuga. Nihil voluptate labore et consequuntur aut nemo impedit maiores harum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("2198b5ad-6328-408b-8b86-034687f7fcf0"), 0m, new Guid("6ebc0c06-ed18-43b4-b9c0-45fe65110580"), "Sed ratione voluptatem ut ut. Reiciendis tempora ea excepturi dolorem fugiat fugit voluptatibus doloribus sunt. Quae nihil illum nulla explicabo perspiciatis laudantium iusto et suscipit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("21d2d0a1-d455-439c-85d4-38ba372f8499"), 0m, new Guid("49208646-b259-4f1e-b974-0f4f6e3e7581"), "At maiores quia eligendi aut corrupti alias officiis illum. Ad est quidem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("227c6332-9a5f-44f2-9ceb-a2046844eb28"), 0m, new Guid("21852f57-283d-41d7-81c5-abab51ea1f96"), "Voluptas adipisci ipsa quod aliquam aut. Aspernatur in excepturi possimus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("23e45dbb-fb50-4d67-90df-6ed6edb3e2f7"), 0m, new Guid("88954795-7e42-4935-9a08-030d7ed88878"), "Quia temporibus ex impedit quia voluptates. Aut et est natus cum minus dolores maiores est. Consequuntur perferendis ducimus voluptas quo ab voluptatibus velit ab.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("2569629e-0bea-4ca7-b7c6-a44fe02b3e94"), 0m, new Guid("49208646-b259-4f1e-b974-0f4f6e3e7581"), "Fugiat explicabo aut et quis est a rerum optio. Eum expedita corporis vero facilis. Voluptatem ad ipsum nostrum optio.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("2de04be0-24e0-43bf-9465-96bd83cc18cd"), 0m, new Guid("d4866fa1-0094-4eb8-bddc-e4d7c8777d60"), "Rerum qui quisquam rerum aut sit iste et sint at. Iste explicabo sed nobis in recusandae recusandae et. Consequatur veritatis voluptatem ut voluptas eius veniam commodi possimus voluptatum. Quia error facere est.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("2e6e20f8-9d38-4ac0-9750-8f5849755957"), 0m, new Guid("88954795-7e42-4935-9a08-030d7ed88878"), "Fugit dicta pariatur sed sit ullam distinctio aut quo non. Aut numquam illo et velit architecto distinctio et. Aliquid iusto molestiae sit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("2f9ebd1d-f991-43de-98e5-b705c73bd4e4"), 0m, new Guid("1d968608-0bac-4b7d-a2bb-3b6e6a5df2e5"), "Nihil nisi odio aut iusto commodi temporibus suscipit voluptatem. Aut et quidem magni nostrum similique aut est. Alias doloribus quo minima nemo dolor quos est enim.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("2ff9702f-1dcc-4574-927e-e6a30e14e780"), 0m, new Guid("d4866fa1-0094-4eb8-bddc-e4d7c8777d60"), "Laudantium nihil eos. Similique molestiae accusamus veritatis fugiat recusandae mollitia soluta sit quis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("307cf275-88ca-40ba-8964-cf62572d2927"), 0m, new Guid("49208646-b259-4f1e-b974-0f4f6e3e7581"), "Nobis vitae ut eos.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("320a171e-9007-4e88-87fe-afcc560e4a9f"), 0m, new Guid("6c8a9f30-dd14-40bc-8f72-94fab82010dd"), "Ab consequatur officiis nisi mollitia. Et aliquid voluptatem deleniti quidem accusamus accusamus quidem ipsum. Numquam autem numquam minus fuga.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("34573067-1b22-433a-8bc8-7c194c731c9a"), 0m, new Guid("38d15922-121a-4bf4-86c0-f855d82d0043"), "Totam vitae tenetur autem voluptatem autem eligendi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("34ad7b0e-009f-49c6-b369-5bec957b1cb9"), 0m, new Guid("037bc4e3-5593-46f7-b91d-f4d234ebb8e7"), "Ea sequi sunt perspiciatis qui est quia ratione eos.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("361a2a01-17eb-44c2-9c23-dd3670b1deec"), 0m, new Guid("915d5d3f-620d-4966-a312-4d5af3b07c1c"), "Sunt et voluptatem. Facere omnis iusto dolores atque mollitia ipsum quis. Aut tenetur aut ex.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("397be83c-49fa-4b28-a588-882768ab4758"), 0m, new Guid("51ddc486-ea21-4eed-966b-725ba507f84f"), "Nam sit officiis voluptatum possimus ducimus occaecati consequuntur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("3a11c6c3-ee56-49c7-8bb6-2e39ba27a364"), 0m, new Guid("c9262fd0-d92d-4bcc-85db-9c179d66c822"), "Consequuntur repellat distinctio dolorem quia non.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("3c2b408c-101a-40bc-b96b-5c5442a2ac02"), 0m, new Guid("6c8a9f30-dd14-40bc-8f72-94fab82010dd"), "Doloremque autem ut maiores est eveniet molestiae sed similique.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("3cc9b985-d7eb-426b-b15b-e96348512bec"), 0m, new Guid("5c875dc4-be9f-4393-9701-b38032878f4f"), "Ea nobis aut distinctio dignissimos. Provident a aspernatur excepturi odio cumque beatae nemo non aut. Deleniti laborum sit nam rerum at sapiente voluptas fugit nemo. Iste voluptatem ratione delectus numquam itaque est.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("3dd53af0-d778-417c-ba47-d610dcb3c164"), 0m, new Guid("e236781c-6290-4c4f-b634-e339fd8ebc2a"), "Est aut est magni veritatis sed iure. Dolores dolores iste quia in.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("3df9bb11-c84b-47c0-95fe-a207ecde5a80"), 0m, new Guid("afb471ee-620f-47da-a14c-f767894c607e"), "Ea id vero et cumque magnam magni. Ut vero adipisci cupiditate.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("3eb80460-a517-4684-be97-a01bce842acd"), 0m, new Guid("88954795-7e42-4935-9a08-030d7ed88878"), "Aspernatur et similique qui quo omnis voluptas itaque. Nulla qui iste aliquam aut quae consectetur et rem iure. Sed sit eveniet cum quae asperiores vitae magni accusantium sed.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("3fdd05a3-c49c-4de9-9d76-2974358cb479"), 0m, new Guid("51ddc486-ea21-4eed-966b-725ba507f84f"), "Perspiciatis officia sunt nulla. Asperiores repudiandae iste atque repellat voluptates voluptatem qui nulla. Voluptatem dolorem quia quae. Molestias tempora voluptas earum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("3fee09cd-8a57-4e07-917f-7fe2d288da59"), 0m, new Guid("ce15a0d0-f2f4-400a-93bc-eb32becb2e15"), "Voluptatum unde molestias. Inventore voluptas possimus ea natus amet facere nulla consequatur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("4038423d-e59c-417c-9835-d0676fec6f11"), 0m, new Guid("ce15a0d0-f2f4-400a-93bc-eb32becb2e15"), "Voluptatibus nam incidunt officiis cupiditate. Excepturi qui quidem qui vel error iusto est.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("41bec596-8f3b-4d13-a091-2a4d4bcfa81a"), 0m, new Guid("2241f7c2-56e2-47ca-990a-74eeea967bb9"), "Consequatur sunt eius suscipit officia ipsum amet ipsum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("44c5fc97-50c7-47cc-b53e-f49e3cd42a85"), 0m, new Guid("5c875dc4-be9f-4393-9701-b38032878f4f"), "Autem beatae est fugiat provident quia. Magnam perspiciatis quibusdam autem inventore velit quo pariatur qui.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("45987423-03c6-4270-a685-f74f0e931163"), 0m, new Guid("2241f7c2-56e2-47ca-990a-74eeea967bb9"), "Quia cumque tempore natus ipsam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("45fc253b-adad-4f73-a02d-453025c059f6"), 0m, new Guid("6ebc0c06-ed18-43b4-b9c0-45fe65110580"), "Fugit voluptas necessitatibus eos sapiente libero. Totam aut vel ex rerum ad dolore quod.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("49df0189-1772-46c6-895e-310fdfbfe1ce"), 0m, new Guid("5c875dc4-be9f-4393-9701-b38032878f4f"), "Culpa at id ratione veniam autem quidem rerum. Esse et ut quo. Odit ut doloremque enim dolor eos inventore quidem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("4a7976d0-ef0a-42b6-aaed-0328a0cc7efe"), 0m, new Guid("c9262fd0-d92d-4bcc-85db-9c179d66c822"), "Blanditiis in eius quibusdam neque.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("4b314699-69e9-4be2-92ed-1a08b63962dd"), 0m, new Guid("38d15922-121a-4bf4-86c0-f855d82d0043"), "Ipsa magni rerum necessitatibus ut maxime unde mollitia. Earum corporis expedita omnis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("4d3b55cd-c8b6-4d35-9abf-9ab4bfbe1b9a"), 0m, new Guid("afb471ee-620f-47da-a14c-f767894c607e"), "Et soluta eos tempora ex tempore omnis nemo. Magnam autem cupiditate voluptatem harum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("4f34422a-890f-4e7d-969d-85163c7c5ac8"), 0m, new Guid("ace2d1a9-0654-43ed-bc3e-001a36da5c81"), "Id minima praesentium quasi consequatur voluptatem. Porro eum omnis sunt est ut deleniti sit voluptates quo.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("5008bb75-7ead-4a10-ad51-e4f8af2672c7"), 0m, new Guid("38d15922-121a-4bf4-86c0-f855d82d0043"), "Excepturi et qui mollitia voluptatibus fugiat. Modi neque sit in nihil est hic minima nobis. Et rerum quo non ut ducimus aperiam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("502aded8-e53d-46f8-9527-d376a1e39134"), 0m, new Guid("dc744156-73d3-4ebe-9574-334a24a9a7ee"), "Facere natus aut distinctio architecto sequi laboriosam. Dignissimos et recusandae.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("515cb9ec-c6df-4d6f-b277-a054d060dd3b"), 0m, new Guid("915d5d3f-620d-4966-a312-4d5af3b07c1c"), "Amet ea nobis et assumenda sapiente eos qui. Ut qui eveniet et commodi quis cumque rem voluptas vel. Doloribus soluta ut perferendis maiores voluptatibus autem velit facilis. Non in ipsa voluptatum sint aut eos adipisci.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("5392b1bf-7cfa-4495-8585-2c2458aa6ee3"), 0m, new Guid("d4866fa1-0094-4eb8-bddc-e4d7c8777d60"), "Aut dolores dicta voluptates sed ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("549bd457-6f28-48f8-9bff-272b0e672365"), 0m, new Guid("ce15a0d0-f2f4-400a-93bc-eb32becb2e15"), "Eaque id enim quia quia cumque esse. Omnis qui est aut. Maxime aliquid nesciunt possimus a unde dolores et omnis sint. Similique asperiores aliquid doloribus reiciendis corrupti dolor autem natus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("556ab96b-e62e-450e-8b5a-3c9cdfb8c26e"), 0m, new Guid("1d968608-0bac-4b7d-a2bb-3b6e6a5df2e5"), "Consequatur inventore eos nemo modi voluptatibus. Nisi consequatur pariatur numquam quaerat consectetur. Aut tenetur sapiente.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("5894564a-37e5-423d-8d39-338c3ebc072f"), 0m, new Guid("78aecccb-50ba-4d70-b847-0c7c2071ab9a"), "Aut iusto a sed laborum qui est et nihil aliquid.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("5942a122-a873-49cc-84bb-cfa11a34bc58"), 0m, new Guid("21852f57-283d-41d7-81c5-abab51ea1f96"), "Omnis cumque assumenda nemo quod ut odit voluptatem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("5d157c01-441d-4a67-828c-fb2eca877eb7"), 0m, new Guid("6c8a9f30-dd14-40bc-8f72-94fab82010dd"), "Veritatis sint impedit aliquid et magnam vitae. Ut amet autem occaecati praesentium voluptate dolores minus suscipit iusto.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("5d3e4641-695b-45f3-8f00-5154f1c710e3"), 0m, new Guid("88954795-7e42-4935-9a08-030d7ed88878"), "Dicta velit quia vero suscipit et. Ipsum id inventore. Aliquam expedita a ullam qui est asperiores atque odit aut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("5d588f6a-2180-4880-b0e5-0917ac4d8a1d"), 0m, new Guid("915d5d3f-620d-4966-a312-4d5af3b07c1c"), "Beatae amet voluptas incidunt sunt maxime quos facere eum. Doloribus veniam fugiat accusamus et mollitia consequatur similique quo. Et explicabo veniam molestiae facilis illum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("628ed0b7-95c6-449c-8d37-5f96afb35948"), 0m, new Guid("6ebc0c06-ed18-43b4-b9c0-45fe65110580"), "Laudantium est laudantium temporibus qui. Voluptatem rem sit voluptatem est eligendi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("6791bbb4-cc5f-469c-9d34-31d650ff6482"), 0m, new Guid("afb471ee-620f-47da-a14c-f767894c607e"), "Aut ullam minima aut perspiciatis eligendi facilis. Aut sit aut repudiandae.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("6a2cd6dc-4f78-4494-8c73-f5d72867f44f"), 0m, new Guid("afb471ee-620f-47da-a14c-f767894c607e"), "Quos rerum explicabo incidunt ut vero quis debitis ea. Repudiandae qui qui aspernatur nihil itaque. Consequuntur voluptatem rerum perferendis totam qui assumenda vero. Amet in maiores eum amet dolor voluptatem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("6a3aab5f-4d7b-4e98-8026-a139a4ea77da"), 0m, new Guid("d4866fa1-0094-4eb8-bddc-e4d7c8777d60"), "Sint ea neque aperiam aut enim ipsa distinctio voluptatum omnis. Iste itaque impedit quod odio expedita consequatur occaecati veritatis veniam. Quisquam accusantium tenetur animi ullam consequatur et officia asperiores. Enim magnam ab repellat et rerum qui ducimus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("6cea91c5-7454-4ad4-b83b-be6259e732f2"), 0m, new Guid("e236781c-6290-4c4f-b634-e339fd8ebc2a"), "Animi et amet ullam iste aut eveniet pariatur sint. Omnis doloremque aspernatur veritatis aut non consequuntur animi maiores autem. Est accusamus consequuntur et. Nam adipisci dignissimos quia eos qui fugiat doloribus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("6d2e7776-6927-462e-95e0-3c2adf5cd0dd"), 0m, new Guid("2241f7c2-56e2-47ca-990a-74eeea967bb9"), "Inventore repellendus sunt et. Libero labore sunt molestiae dignissimos qui fugiat et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("6e20e008-d601-4a4d-a9de-bae9598d4a35"), 0m, new Guid("dc744156-73d3-4ebe-9574-334a24a9a7ee"), "Commodi dolores aut ipsum velit quis iusto esse et. Fugiat magni maxime veritatis. Harum quas sequi dolore odit fugiat aut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("6ea0657d-bc04-4fc8-9289-1e4a67686763"), 0m, new Guid("ace2d1a9-0654-43ed-bc3e-001a36da5c81"), "Quaerat eius nisi itaque odit laborum iusto eius sit atque. Dolor optio praesentium.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("70a69711-7fe2-4d5f-a254-9cc25ab806de"), 0m, new Guid("e236781c-6290-4c4f-b634-e339fd8ebc2a"), "Quia nobis culpa beatae quod. Aut consequatur qui maiores ut in mollitia voluptatem fuga. Est sit minima ut laboriosam voluptatem magni nostrum. Alias officiis nam ullam sunt voluptate deserunt est et repudiandae.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("714b19ef-9e6d-4e19-acad-17570e26f747"), 0m, new Guid("78aecccb-50ba-4d70-b847-0c7c2071ab9a"), "Nobis perspiciatis voluptatem delectus veritatis. Unde libero deserunt sit et. Placeat molestias molestias corrupti aut enim quam dolor. Voluptatem nulla voluptas iste voluptate voluptas.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("72f193d7-3877-4ba7-8594-d7734419459e"), 0m, new Guid("1d968608-0bac-4b7d-a2bb-3b6e6a5df2e5"), "Eius dolorum aut voluptatibus odio veritatis. Iste quo adipisci aliquid et eum. Hic voluptas aspernatur illum facere et enim qui voluptas totam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("76c120f4-7a9a-41d7-9b12-96a45bd568a1"), 0m, new Guid("dc744156-73d3-4ebe-9574-334a24a9a7ee"), "Illo necessitatibus sint. Eum minus consequatur tempore culpa incidunt qui.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("7989ad13-0147-483a-a25d-e5c97689cf1e"), 0m, new Guid("6ebc0c06-ed18-43b4-b9c0-45fe65110580"), "Qui excepturi ducimus. Quo corporis et vitae omnis illo perferendis non mollitia.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("79b6d93e-cebc-43e3-9867-ec2279fdfade"), 0m, new Guid("915d5d3f-620d-4966-a312-4d5af3b07c1c"), "Sed molestiae vel veniam eum qui. Nihil dolores vitae aperiam labore dignissimos voluptas maiores.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("7af59bf1-73bd-474c-a726-8d41aeece1b2"), 0m, new Guid("915d5d3f-620d-4966-a312-4d5af3b07c1c"), "Laboriosam cumque similique. Qui quidem et itaque vitae et sed ab beatae aut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("7b6d7e87-e0a4-4d28-8d9e-c6243ce1eee6"), 0m, new Guid("dc744156-73d3-4ebe-9574-334a24a9a7ee"), "Velit esse dicta. Inventore vero voluptatem expedita veritatis. Reprehenderit qui iusto dolorem molestiae quia delectus sit nostrum deserunt.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("7b74ac41-9cb7-49cb-a871-3f3b739858b5"), 0m, new Guid("51ddc486-ea21-4eed-966b-725ba507f84f"), "Pariatur enim deleniti numquam commodi quam sapiente et dolorum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("7bb1f827-77c2-45c3-a716-a166e2b769fd"), 0m, new Guid("1d968608-0bac-4b7d-a2bb-3b6e6a5df2e5"), "Est sit quis velit ab nesciunt. Provident dolore assumenda repellendus at quo. Soluta dolorem quo aspernatur possimus voluptas et ut beatae.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("7c30014d-3491-405e-801e-3e287f86d7e3"), 0m, new Guid("ce15a0d0-f2f4-400a-93bc-eb32becb2e15"), "Hic sequi ad. Minima beatae vel dolor repellat quo labore nobis autem. Voluptatum reprehenderit laborum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("7e0d8fc7-2e05-42f6-9f5a-f2287ba93347"), 0m, new Guid("51ddc486-ea21-4eed-966b-725ba507f84f"), "Perferendis et voluptas labore. Aut vel explicabo hic et qui sint. Consequuntur tenetur praesentium qui accusantium. Blanditiis vitae beatae dolor dolores id.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("7e5381bf-c417-4353-b0cc-e85a18f51a77"), 0m, new Guid("2241f7c2-56e2-47ca-990a-74eeea967bb9"), "Voluptates eveniet commodi incidunt sint.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("7e689b05-17be-443e-9af1-7361db526c2a"), 0m, new Guid("78aecccb-50ba-4d70-b847-0c7c2071ab9a"), "Voluptatem nesciunt qui ratione eum suscipit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("7fef7548-0d4c-4c06-b569-a53864caa511"), 0m, new Guid("c9262fd0-d92d-4bcc-85db-9c179d66c822"), "Magni perspiciatis qui. Animi eum nesciunt harum ut. Exercitationem vel perferendis fugit illum et est sit quam nihil. Alias provident ut saepe molestiae sunt temporibus fuga mollitia.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("8147aca1-1657-445d-be32-6fa628306cc2"), 0m, new Guid("ace2d1a9-0654-43ed-bc3e-001a36da5c81"), "Quos molestias a ut qui. Omnis sit sunt voluptatem sunt. Ea iure eaque ea quis alias dolorum eum et voluptatum. Numquam autem molestias molestias non.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("8168d863-3e50-4f92-9a28-c7fd76690ad0"), 0m, new Guid("6ebc0c06-ed18-43b4-b9c0-45fe65110580"), "Et fugit nihil. Minus ipsum est magnam voluptatem distinctio ut minima. Optio non nisi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("8288902a-e2d8-4352-9c11-c04014f608b4"), 0m, new Guid("1d968608-0bac-4b7d-a2bb-3b6e6a5df2e5"), "Laudantium perferendis nobis ipsam eius qui illum. Aut sunt impedit qui quia quisquam corrupti dignissimos.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("83efb6a7-8d13-4b53-9406-8f337aa4063f"), 0m, new Guid("915d5d3f-620d-4966-a312-4d5af3b07c1c"), "Nihil voluptatem est est autem minima. Quam dolorum veritatis voluptas rem ut. Veritatis fugiat laborum voluptatem occaecati error et soluta. Quod architecto eos officia cupiditate voluptates aliquid necessitatibus dolorem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("8442be76-7ce5-478d-b486-21845655191f"), 0m, new Guid("ace2d1a9-0654-43ed-bc3e-001a36da5c81"), "Ut est harum ea et est dicta dolorem. Et est et distinctio ipsum nesciunt omnis enim et et. Unde sit ut repellendus tempora sed distinctio vitae qui.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("85b50243-2918-43ce-905b-9d775fb617ca"), 0m, new Guid("c9262fd0-d92d-4bcc-85db-9c179d66c822"), "Et dolore tempore quos voluptas aut distinctio earum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("87883a6c-c4e1-4dc0-82ec-5bfacab10216"), 0m, new Guid("38d15922-121a-4bf4-86c0-f855d82d0043"), "Et dolore exercitationem dolores mollitia ut voluptates. Maxime enim sapiente est sit mollitia enim reprehenderit. Facilis quaerat officiis eius at tempore voluptatem placeat.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("897c66e3-1519-4d19-94db-ffbfa9041db0"), 0m, new Guid("5c875dc4-be9f-4393-9701-b38032878f4f"), "Dolor atque eaque dolor eum amet corrupti at. Odit explicabo enim eligendi dolor nam odit. Quo assumenda reiciendis harum alias nemo expedita dolor nulla unde.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("8d0073f8-68e3-47b1-9f5d-d67e7bf91813"), 0m, new Guid("ace2d1a9-0654-43ed-bc3e-001a36da5c81"), "Est molestias dolorem vitae ipsam ut nulla necessitatibus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("8d526b99-9921-4250-9189-80fd6c6eb11c"), 0m, new Guid("6c8a9f30-dd14-40bc-8f72-94fab82010dd"), "A ratione modi earum distinctio.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("8e2c0f2f-e7fc-473a-9d83-cbd9b1da9fe9"), 0m, new Guid("78aecccb-50ba-4d70-b847-0c7c2071ab9a"), "Expedita eveniet aut incidunt recusandae sed praesentium inventore atque culpa. Veritatis libero rerum minima officiis rerum et libero fuga. Hic dolor dolores aspernatur ullam amet maiores sunt molestiae tempora.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("8e6f17b9-4e70-4440-a09b-554ca37351cf"), 0m, new Guid("e236781c-6290-4c4f-b634-e339fd8ebc2a"), "Est earum saepe delectus vel. Dolores eos id inventore et molestias et quod. Illum est ipsum itaque magnam rerum accusamus culpa nostrum. Vero eum eos et tempore magni magni qui.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("91e16af3-31ab-421e-bc44-bfebc1a3914d"), 0m, new Guid("c9262fd0-d92d-4bcc-85db-9c179d66c822"), "Dignissimos voluptatum at exercitationem facere id unde.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("928848b5-e920-4bf4-86b4-d8e8b26b0d30"), 0m, new Guid("037bc4e3-5593-46f7-b91d-f4d234ebb8e7"), "Nam voluptatum quia aperiam eum error incidunt rerum enim tempore.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("987365c6-76e4-4c6e-96b9-0a02b4bcd42d"), 0m, new Guid("afb471ee-620f-47da-a14c-f767894c607e"), "Repellendus quasi nihil eos.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("9be75586-25b8-499a-9938-abb4d8d27f74"), 0m, new Guid("49208646-b259-4f1e-b974-0f4f6e3e7581"), "Tenetur totam voluptate id incidunt architecto consequatur unde.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("9c73c53c-2e6f-43e2-ad9f-b5cbc525daf4"), 0m, new Guid("51ddc486-ea21-4eed-966b-725ba507f84f"), "Ut omnis rerum rem dolor voluptatum ea ut. Et debitis iure natus in nulla consectetur perferendis. Facilis fugit qui itaque occaecati beatae est qui et. Qui sit nulla est.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("9edf63ef-7675-4874-b3b4-b5aff63da575"), 0m, new Guid("2241f7c2-56e2-47ca-990a-74eeea967bb9"), "Cupiditate non ut eos ea qui fugiat. Molestias id facere repudiandae ut voluptas. Doloribus velit dolores numquam aperiam quia modi. Ipsum voluptas quo nisi deleniti earum ea expedita ipsa provident.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("a27f3585-6d47-4d15-9889-45e923b85bb6"), 0m, new Guid("21852f57-283d-41d7-81c5-abab51ea1f96"), "Reprehenderit temporibus libero officiis ipsum eos nesciunt velit hic. Est tenetur qui enim et doloremque voluptatem asperiores.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("a2fda14e-9a6a-45ec-ac42-36df5fa508f1"), 0m, new Guid("6c8a9f30-dd14-40bc-8f72-94fab82010dd"), "Sed explicabo voluptatem dolorem autem quia repellendus adipisci.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("a301dab9-9764-46cf-8ff0-3244588a9a2e"), 0m, new Guid("dc744156-73d3-4ebe-9574-334a24a9a7ee"), "Repudiandae blanditiis voluptatum occaecati mollitia suscipit ut necessitatibus voluptate. Vel esse autem dolore quae. Aspernatur repudiandae temporibus sit velit quibusdam inventore.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("a590baa1-f835-4c0f-b31d-f158bbb00743"), 0m, new Guid("ce15a0d0-f2f4-400a-93bc-eb32becb2e15"), "Dolorem omnis rerum nobis praesentium. Dolorem et nesciunt cumque cupiditate voluptas rerum vel aut. Dolor vero et eos voluptatem nesciunt.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("a593faf2-9d02-43ff-939c-26d66220b936"), 0m, new Guid("e236781c-6290-4c4f-b634-e339fd8ebc2a"), "Doloremque sequi omnis enim unde. Qui magnam laboriosam et in vel id.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("a5e5b95a-fdab-430e-a6f5-8ee9ba4f8944"), 0m, new Guid("6c8a9f30-dd14-40bc-8f72-94fab82010dd"), "Quasi omnis eos soluta similique qui aut est.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("a6e9c200-7a32-497d-81e5-6f46e28b6c49"), 0m, new Guid("d4866fa1-0094-4eb8-bddc-e4d7c8777d60"), "Cumque ut unde et voluptatem est voluptatum. Ipsum voluptate quod blanditiis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("a931f121-b2ce-4d89-9a11-e3e4838e4c5a"), 0m, new Guid("037bc4e3-5593-46f7-b91d-f4d234ebb8e7"), "Earum omnis maiores nisi esse consequatur. Animi ut asperiores qui facilis voluptatem quae. Ut aut qui velit culpa eum eos aliquid necessitatibus. Id tempore quibusdam necessitatibus voluptatum itaque vitae.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("aadfdd22-fe06-4daf-a4a3-27d2f31a6118"), 0m, new Guid("6ebc0c06-ed18-43b4-b9c0-45fe65110580"), "Sed ipsa ratione et aut soluta tempore. Aut nostrum facere expedita et ad rem eum voluptatem. Est adipisci quis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("aafc2fcc-15f8-46a9-9256-a48da2119ae7"), 0m, new Guid("afb471ee-620f-47da-a14c-f767894c607e"), "Asperiores odit vitae est ab enim numquam illum autem. Molestiae nemo sunt ut. Laboriosam veritatis quia. Aut ut ut odit aperiam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("ac9dada4-2725-40fc-84d0-e150fbbdfed8"), 0m, new Guid("c9262fd0-d92d-4bcc-85db-9c179d66c822"), "Omnis repellat nihil reiciendis maxime enim. Ipsum architecto quasi voluptate reprehenderit ratione ab nesciunt.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("ae5af5e7-e350-4a5f-98bd-58b32b33805d"), 0m, new Guid("e236781c-6290-4c4f-b634-e339fd8ebc2a"), "Praesentium amet nihil quia ut consequuntur molestiae. Odio pariatur rem nesciunt et quia facilis ut omnis. Qui ut sint quas dolorem dolorum possimus minima est neque.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("af8cacd0-f59a-4bf1-a7c9-5fb43acd0f3e"), 0m, new Guid("78aecccb-50ba-4d70-b847-0c7c2071ab9a"), "Et rerum nihil et fugit totam hic nihil odit molestiae. Officiis et voluptatem aut vero perferendis laudantium. Non alias iste similique in pariatur ex. Maxime aperiam voluptatibus modi delectus quaerat repellendus ducimus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("b06a67e0-4af2-49e4-b71b-b3b2622e1c3c"), 0m, new Guid("49208646-b259-4f1e-b974-0f4f6e3e7581"), "Unde ut molestias neque repudiandae in libero sit. Provident labore harum vitae inventore.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("b0889b60-e5b1-4af5-ba36-3879bc650bf0"), 0m, new Guid("915d5d3f-620d-4966-a312-4d5af3b07c1c"), "Repudiandae dicta earum necessitatibus. Sed voluptate officia earum aut esse modi et reiciendis consectetur. Commodi at cumque iste.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("b158f946-eec4-4b37-8448-4ab14d533b26"), 0m, new Guid("d4866fa1-0094-4eb8-bddc-e4d7c8777d60"), "Voluptatem sit illo optio rerum dolor. Aut est necessitatibus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("b1d20b0d-da2b-4398-8551-ea705222178f"), 0m, new Guid("6c8a9f30-dd14-40bc-8f72-94fab82010dd"), "Et repellendus laudantium et tenetur et quae quasi nihil. Et magni id molestiae quia eos voluptas. Consequatur quas sint possimus. Ad magnam reprehenderit tempore.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("b373d516-b833-49cf-9271-2f20d90d413b"), 0m, new Guid("78aecccb-50ba-4d70-b847-0c7c2071ab9a"), "Quasi dolores voluptatem omnis architecto fuga atque sit culpa. Voluptatem nobis neque aut eum vero quaerat quidem excepturi. Quae eos quisquam sed quia hic aspernatur reiciendis non.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("b3d038bc-4651-4afd-bd87-af5fdfd3dccc"), 0m, new Guid("5c875dc4-be9f-4393-9701-b38032878f4f"), "Ipsam doloribus quo nihil.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("b5133e9b-ad0e-4a60-b40c-f7e335641fbd"), 0m, new Guid("88954795-7e42-4935-9a08-030d7ed88878"), "Inventore architecto eligendi natus fuga sit debitis quas. Corporis quisquam possimus est quibusdam ad distinctio. Voluptas molestiae sed magnam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("b67b8bec-2939-4232-8d9b-cccecbd799b6"), 0m, new Guid("ce15a0d0-f2f4-400a-93bc-eb32becb2e15"), "Facilis voluptas ut totam voluptas tempora quis quia sed culpa.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("b7d79f62-0501-4c49-8972-5a3726330ba6"), 0m, new Guid("88954795-7e42-4935-9a08-030d7ed88878"), "Doloribus velit nostrum ut occaecati minus omnis voluptas sit. Esse optio assumenda numquam. Blanditiis et nam excepturi omnis quia.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("b9c0bc13-aab1-4bd2-8a54-2f86cf2ccaed"), 0m, new Guid("38d15922-121a-4bf4-86c0-f855d82d0043"), "Quo et doloremque sapiente qui magnam. Reiciendis ut possimus quo fugit explicabo porro praesentium asperiores soluta. Quo voluptatem nesciunt veritatis. Occaecati dolor eos perferendis cupiditate sit corrupti.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("ba2e75a7-c49e-4f26-8d90-99bdbd5f4eb2"), 0m, new Guid("5c875dc4-be9f-4393-9701-b38032878f4f"), "Autem cumque voluptas et non consectetur qui mollitia aut et. Sunt repudiandae autem a. Consequuntur esse atque ut ab quaerat aperiam quis ut. Aut eveniet dolor est expedita quos et id.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("bab1472a-348e-4d66-a159-d0fa22ed302f"), 0m, new Guid("ace2d1a9-0654-43ed-bc3e-001a36da5c81"), "Sed ipsum exercitationem magni minima. Aut quod molestiae a ad nesciunt mollitia omnis velit. Dignissimos accusamus omnis eaque libero id.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("bab3f9d1-2292-4ea7-8fab-7913881138cd"), 0m, new Guid("6c8a9f30-dd14-40bc-8f72-94fab82010dd"), "Nobis voluptatem excepturi fugit et iste magni iure voluptas molestias. Ea quo aperiam consequatur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("bac84845-53ff-4341-810f-64b19cd2db91"), 0m, new Guid("5c875dc4-be9f-4393-9701-b38032878f4f"), "Tempora rem maiores sunt. Alias cum qui voluptate ut dolore quam in. Architecto error vero voluptates hic perspiciatis dolore laboriosam qui. Labore officiis eos aspernatur quis quia eaque.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("bb797138-72da-4aa8-b09f-c89f6cfb3975"), 0m, new Guid("78aecccb-50ba-4d70-b847-0c7c2071ab9a"), "Et autem saepe ut dolores voluptas inventore rerum et. Quaerat ullam dolorem sit ut maxime. Suscipit quibusdam aut necessitatibus minima et. Eos consequatur nulla eligendi atque est eveniet natus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("bb8cefae-7dd5-407f-81c6-1b21568be285"), 0m, new Guid("dc744156-73d3-4ebe-9574-334a24a9a7ee"), "Non dicta cupiditate ex voluptates. Commodi assumenda excepturi consequatur nulla omnis. Voluptatem id doloribus. Quod quidem quis velit facere voluptatem consequatur culpa.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("bc40481c-8c42-4589-bdb2-80b305b32442"), 0m, new Guid("037bc4e3-5593-46f7-b91d-f4d234ebb8e7"), "Est id rerum ut autem est ut tempore sed.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("bd4e1908-96eb-4a82-b2e5-1e6ba00aada7"), 0m, new Guid("037bc4e3-5593-46f7-b91d-f4d234ebb8e7"), "Et labore culpa in officiis tempore consequatur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("bee21f60-6201-4b45-a3a4-14f751492536"), 0m, new Guid("2241f7c2-56e2-47ca-990a-74eeea967bb9"), "Mollitia quo non. Nesciunt est quo quae.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("c0ff4c13-cbfc-4e3a-be4f-481cf1e7f60d"), 0m, new Guid("38d15922-121a-4bf4-86c0-f855d82d0043"), "Soluta sed excepturi eum sunt doloribus distinctio veritatis porro. Dolorem nostrum quibusdam consequatur beatae. Incidunt vitae qui quisquam optio dignissimos velit vitae nihil a.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("c204d3e4-2c17-4e5f-92ff-4d780058b896"), 0m, new Guid("ce15a0d0-f2f4-400a-93bc-eb32becb2e15"), "Praesentium repudiandae ut dicta totam voluptatem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("c26e99e9-9ea5-42e6-9353-c9e2da2d31b2"), 0m, new Guid("1d968608-0bac-4b7d-a2bb-3b6e6a5df2e5"), "Nisi aut nobis voluptas iure alias. Veniam perferendis quia.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("c34d8ac6-6260-4dc1-aacb-0e54058c8053"), 0m, new Guid("afb471ee-620f-47da-a14c-f767894c607e"), "Mollitia corrupti temporibus non culpa ab molestias iste. Reprehenderit mollitia tempore ducimus occaecati et soluta aut. Aut vero quia accusantium optio dicta officia et aut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("c40652e3-294f-4644-8d49-4226367b073c"), 0m, new Guid("ce15a0d0-f2f4-400a-93bc-eb32becb2e15"), "Molestias mollitia perspiciatis dolor omnis ex illo. Est quisquam dolore id voluptate ut voluptas facilis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("c4b3e99a-ca91-4e6c-8f07-fe30a0071bbb"), 0m, new Guid("dc744156-73d3-4ebe-9574-334a24a9a7ee"), "Quia neque rem et assumenda qui. Numquam molestiae quas aliquam aut. Corporis porro molestiae magni hic unde. Consequatur laborum excepturi explicabo inventore pariatur nobis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("c98bd4c1-c69e-4f6a-99c6-76d97b36c5dd"), 0m, new Guid("e236781c-6290-4c4f-b634-e339fd8ebc2a"), "Labore non voluptatem ad dolores. Soluta debitis doloribus consequatur temporibus rerum ut. Odit hic non velit aliquid quidem quod perspiciatis. Facere aspernatur possimus maiores.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("ca516563-2257-4b19-83fc-b5c96f5139c4"), 0m, new Guid("21852f57-283d-41d7-81c5-abab51ea1f96"), "Et voluptate porro aut saepe iusto ut perspiciatis cupiditate.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("cbb49435-1e0b-438c-8e76-027783c4bad8"), 0m, new Guid("037bc4e3-5593-46f7-b91d-f4d234ebb8e7"), "Sit possimus iste vitae perspiciatis aliquid non.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("ccc7ccc4-b7ce-44bd-b428-bea9d95e9712"), 0m, new Guid("78aecccb-50ba-4d70-b847-0c7c2071ab9a"), "Dicta rem ut sint reiciendis quae earum qui. Nesciunt praesentium laboriosam impedit non neque. Quaerat illum itaque officia iure ea est similique consequatur. Nesciunt quo sunt est quia est non autem voluptatibus laborum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("cfe19095-550b-411a-b98e-52e1e155457c"), 0m, new Guid("6ebc0c06-ed18-43b4-b9c0-45fe65110580"), "Molestiae rem non impedit nulla modi in possimus. Et unde quo ullam velit eos sed excepturi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("d157ae82-0751-4e63-b31b-98ad946d6040"), 0m, new Guid("d4866fa1-0094-4eb8-bddc-e4d7c8777d60"), "Eum iste quia natus molestiae adipisci porro reiciendis eum. Accusantium ab est. Explicabo autem culpa est ratione et doloribus laborum consectetur. Ut sed quis hic culpa quis deserunt iste.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("d15aa81a-9afe-4184-8f56-d6392c44693f"), 0m, new Guid("88954795-7e42-4935-9a08-030d7ed88878"), "Dolores sunt officia quas. Et debitis aut explicabo eaque. Laborum reprehenderit nesciunt eos eaque hic magni tempora qui error. Earum magnam harum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("d1ce60eb-cbe8-43e6-9115-de13bd57896e"), 0m, new Guid("2241f7c2-56e2-47ca-990a-74eeea967bb9"), "Autem ipsum dolor ex.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("d1ee70ec-e801-4324-be6d-cc350fd62c0b"), 0m, new Guid("88954795-7e42-4935-9a08-030d7ed88878"), "Quia delectus possimus quos qui quia doloremque asperiores autem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("d3b25d1e-0e99-405f-80ad-bcbc45a042e7"), 0m, new Guid("21852f57-283d-41d7-81c5-abab51ea1f96"), "Voluptate ex molestias mollitia eos vel quas dolorum est odit. Non architecto qui sed est sunt blanditiis ea sapiente.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("db6dec3b-6cef-490f-aff7-1ce91197dcca"), 0m, new Guid("ace2d1a9-0654-43ed-bc3e-001a36da5c81"), "Facilis error est iste iusto ullam molestias. Pariatur eum facere rerum occaecati non nostrum quod.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("ddac716a-bb9f-4740-9b53-1e89cdb401c1"), 0m, new Guid("037bc4e3-5593-46f7-b91d-f4d234ebb8e7"), "Cumque ullam nulla. Mollitia quasi inventore quia et non reiciendis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("ddc2d888-fbae-47cf-80c3-ac349c78df0f"), 0m, new Guid("78aecccb-50ba-4d70-b847-0c7c2071ab9a"), "Dolores aspernatur nisi totam blanditiis ratione nesciunt ut et sunt. Eos dolorum sed vitae explicabo inventore.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("de24e5ad-c84e-4660-92f3-37e79833a024"), 0m, new Guid("6ebc0c06-ed18-43b4-b9c0-45fe65110580"), "Ad ipsam quaerat unde qui cupiditate commodi eos velit tempora. In ducimus ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("df9e6933-5783-46cf-a250-67cbffb80b36"), 0m, new Guid("c9262fd0-d92d-4bcc-85db-9c179d66c822"), "Velit aut unde repudiandae reiciendis ut molestiae perspiciatis numquam. Ipsa dolorem facere ut quis. Autem possimus in autem nobis ut voluptas labore blanditiis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("e0aa1e68-ea3b-41b6-b532-820fe2702f21"), 0m, new Guid("38d15922-121a-4bf4-86c0-f855d82d0043"), "Culpa est sint amet ipsa. Libero sunt quos consequatur dicta maxime iusto est praesentium dolores. Molestiae non id reiciendis ducimus aliquam aut non.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("e0c6fd23-06db-4d99-91c3-4bfda6923daa"), 0m, new Guid("38d15922-121a-4bf4-86c0-f855d82d0043"), "Exercitationem non debitis sed sed sed iusto est laudantium aut. Laboriosam at consequatur. Quia magnam minima. Nesciunt adipisci assumenda consequuntur error qui.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("e0e0e4e7-1e79-4777-8c12-27d578a01e04"), 0m, new Guid("38d15922-121a-4bf4-86c0-f855d82d0043"), "Dolorem voluptate fuga et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("e1c208c1-d860-4243-95e9-9fbcbfd0dabb"), 0m, new Guid("21852f57-283d-41d7-81c5-abab51ea1f96"), "Et aut ut laboriosam est.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("e1cb9eca-52c6-4600-b236-b5cceed24218"), 0m, new Guid("6ebc0c06-ed18-43b4-b9c0-45fe65110580"), "Dolor similique non quis. Dolorem a non odit quia voluptatum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("e2ccf0cc-b352-4a8e-a160-9abb392d9b6a"), 0m, new Guid("ce15a0d0-f2f4-400a-93bc-eb32becb2e15"), "Maiores et earum magnam nihil exercitationem. In odio est aperiam dolores beatae veritatis eos nostrum quam. Deserunt qui aut quo.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("e370354f-6577-4144-9c75-2ec4fda645bb"), 0m, new Guid("1d968608-0bac-4b7d-a2bb-3b6e6a5df2e5"), "Ex sunt vel assumenda ipsam a molestiae velit dolores quia. Minima magnam omnis corrupti eaque quibusdam provident aut id dicta.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("e3daa992-913f-4ebe-998a-1554645bc162"), 0m, new Guid("037bc4e3-5593-46f7-b91d-f4d234ebb8e7"), "Quia cupiditate rerum ut et et suscipit. Voluptas quo impedit at velit voluptatum sed sit est.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("e63a2988-1988-4948-b073-c68188094c95"), 0m, new Guid("ce15a0d0-f2f4-400a-93bc-eb32becb2e15"), "Porro maiores dolor error.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("e6a433bf-8834-4173-97b1-405c1d684da0"), 0m, new Guid("6c8a9f30-dd14-40bc-8f72-94fab82010dd"), "Est id alias fugiat numquam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("e7fac6f2-9c8e-4e13-b6ec-7815719f5bb9"), 0m, new Guid("d4866fa1-0094-4eb8-bddc-e4d7c8777d60"), "Est inventore fuga quia aut ex illo. Enim illum officiis velit quisquam qui quae perspiciatis consequatur odio.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("eb17a365-7189-44d7-8520-38e0e6f4f1a0"), 0m, new Guid("21852f57-283d-41d7-81c5-abab51ea1f96"), "Provident qui qui aut autem quia quia natus. Et velit voluptatem cumque quia eligendi hic nisi facilis. Quo rem voluptas blanditiis quis laudantium nemo.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("eba73a25-b70a-496a-bb1d-b47b3847dcc7"), 0m, new Guid("915d5d3f-620d-4966-a312-4d5af3b07c1c"), "Quos totam aut velit. Voluptas harum est odio reiciendis. Eaque animi impedit ea voluptates ut quasi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("ebeb6b22-e912-4e22-9d4a-57349744e766"), 0m, new Guid("1d968608-0bac-4b7d-a2bb-3b6e6a5df2e5"), "Alias quibusdam dolor inventore.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("ed32b6be-80fb-451a-ae86-2aa52f285359"), 0m, new Guid("d4866fa1-0094-4eb8-bddc-e4d7c8777d60"), "Sed impedit maxime dolores est dolorem a esse. Dicta ipsa sit quod fugiat omnis consequatur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("eef3fbc0-598b-484d-80e7-3e8f786078b7"), 0m, new Guid("c9262fd0-d92d-4bcc-85db-9c179d66c822"), "Asperiores omnis praesentium ea eius. Ut consequatur vel ad adipisci quis quod unde aliquam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("ef0dab7c-a03c-46cb-bbec-c4cba9222652"), 0m, new Guid("037bc4e3-5593-46f7-b91d-f4d234ebb8e7"), "Dolor officia veniam consequatur expedita eius magnam in.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("f018d702-b826-4ed0-9660-5609b41ce693"), 0m, new Guid("1d968608-0bac-4b7d-a2bb-3b6e6a5df2e5"), "Earum perferendis ipsa laboriosam quo suscipit sint in laboriosam. Sint ad voluptas et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("f0ff480a-d4a6-4881-94dd-dbd92a548a85"), 0m, new Guid("5c875dc4-be9f-4393-9701-b38032878f4f"), "Expedita voluptatem quo cum excepturi molestiae vel.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("f30951e2-4e92-4e1c-b32a-ee3d45748cfa"), 0m, new Guid("037bc4e3-5593-46f7-b91d-f4d234ebb8e7"), "Dolorum id ut sunt totam voluptas sed. Hic voluptas consequuntur id ad.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("f3f051b0-6079-400f-a8be-acf5ae319d5f"), 0m, new Guid("c9262fd0-d92d-4bcc-85db-9c179d66c822"), "Repellat quae et molestiae maxime. Aut asperiores tempore accusamus consequatur ut quis distinctio rerum. Et ut at corrupti consequatur et qui rem est. Quo fugit sequi quaerat alias.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("f701cae0-16a6-4f42-a2da-0d5c61ad2a73"), 0m, new Guid("49208646-b259-4f1e-b974-0f4f6e3e7581"), "Ab minus numquam expedita velit asperiores maxime vero odio.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("f7946761-4a1d-4f0b-a870-8bc6647a3d0c"), 0m, new Guid("1d968608-0bac-4b7d-a2bb-3b6e6a5df2e5"), "Doloremque dolorem cupiditate. Qui quidem ipsum hic. Mollitia quia blanditiis minima ut accusamus architecto. Expedita corrupti hic recusandae quis perferendis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("f89e038d-6397-4d01-aff0-662ab06c8a5e"), 0m, new Guid("51ddc486-ea21-4eed-966b-725ba507f84f"), "Officiis sunt consequatur excepturi. Voluptatem nihil dignissimos illo laudantium dolore non ratione autem laudantium. Minus error est necessitatibus accusamus rerum eos.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("f8e5d957-85d7-4086-9b83-b7a1284fb4e2"), 0m, new Guid("21852f57-283d-41d7-81c5-abab51ea1f96"), "Sunt repudiandae dolor.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("fbb7accf-ba85-40d3-bd50-a04a110eb0b8"), 0m, new Guid("49208646-b259-4f1e-b974-0f4f6e3e7581"), "Similique modi aut ipsa laborum veniam eaque fugit vero. Quod eum fugit et quibusdam et repellendus modi qui inventore. Vel iste quia ratione.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("fc39023f-452f-47f1-a251-170edb6d4cdc"), 0m, new Guid("51ddc486-ea21-4eed-966b-725ba507f84f"), "Et inventore tenetur. Quos cumque ut neque harum quia ut cumque et quis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("fc505cc1-c172-499d-b65a-13bbfe59bee7"), 0m, new Guid("49208646-b259-4f1e-b974-0f4f6e3e7581"), "Occaecati consequatur blanditiis. Aperiam quos minima.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("ffb14153-fdd9-45ce-af3b-2af9a8ba14e0"), 0m, new Guid("afb471ee-620f-47da-a14c-f767894c607e"), "Ut error in dolores nobis sit dolor et sapiente illo. Est impedit asperiores vero cumque corrupti aperiam ad placeat eos. Hic recusandae est optio aut ut exercitationem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 }
                });

            migrationBuilder.InsertData(
                table: "SubscriptionPaid",
                columns: new[] { "MemberId", "Year", "April", "August", "December", "February", "January", "July", "June", "March", "May", "November", "October", "September" },
                values: new object[,]
                {
                    { new Guid("1d968608-0bac-4b7d-a2bb-3b6e6a5df2e5"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("21852f57-283d-41d7-81c5-abab51ea1f96"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("21852f57-283d-41d7-81c5-abab51ea1f96"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("21852f57-283d-41d7-81c5-abab51ea1f96"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("21852f57-283d-41d7-81c5-abab51ea1f96"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("21852f57-283d-41d7-81c5-abab51ea1f96"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("21852f57-283d-41d7-81c5-abab51ea1f96"), 2020, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("21852f57-283d-41d7-81c5-abab51ea1f96"), 2021, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("38d15922-121a-4bf4-86c0-f855d82d0043"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("38d15922-121a-4bf4-86c0-f855d82d0043"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("38d15922-121a-4bf4-86c0-f855d82d0043"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("38d15922-121a-4bf4-86c0-f855d82d0043"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("38d15922-121a-4bf4-86c0-f855d82d0043"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("38d15922-121a-4bf4-86c0-f855d82d0043"), 2020, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("38d15922-121a-4bf4-86c0-f855d82d0043"), 2021, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("51ddc486-ea21-4eed-966b-725ba507f84f"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("51ddc486-ea21-4eed-966b-725ba507f84f"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("51ddc486-ea21-4eed-966b-725ba507f84f"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("51ddc486-ea21-4eed-966b-725ba507f84f"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("51ddc486-ea21-4eed-966b-725ba507f84f"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("51ddc486-ea21-4eed-966b-725ba507f84f"), 2020, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("5c875dc4-be9f-4393-9701-b38032878f4f"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("5c875dc4-be9f-4393-9701-b38032878f4f"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("6c8a9f30-dd14-40bc-8f72-94fab82010dd"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("6c8a9f30-dd14-40bc-8f72-94fab82010dd"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("6ebc0c06-ed18-43b4-b9c0-45fe65110580"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("6ebc0c06-ed18-43b4-b9c0-45fe65110580"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("6ebc0c06-ed18-43b4-b9c0-45fe65110580"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("88954795-7e42-4935-9a08-030d7ed88878"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("88954795-7e42-4935-9a08-030d7ed88878"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("88954795-7e42-4935-9a08-030d7ed88878"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("88954795-7e42-4935-9a08-030d7ed88878"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("88954795-7e42-4935-9a08-030d7ed88878"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("88954795-7e42-4935-9a08-030d7ed88878"), 2020, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("915d5d3f-620d-4966-a312-4d5af3b07c1c"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("915d5d3f-620d-4966-a312-4d5af3b07c1c"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("ace2d1a9-0654-43ed-bc3e-001a36da5c81"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("ace2d1a9-0654-43ed-bc3e-001a36da5c81"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("ace2d1a9-0654-43ed-bc3e-001a36da5c81"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("ace2d1a9-0654-43ed-bc3e-001a36da5c81"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("ace2d1a9-0654-43ed-bc3e-001a36da5c81"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("ace2d1a9-0654-43ed-bc3e-001a36da5c81"), 2020, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("afb471ee-620f-47da-a14c-f767894c607e"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("afb471ee-620f-47da-a14c-f767894c607e"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("c9262fd0-d92d-4bcc-85db-9c179d66c822"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("d4866fa1-0094-4eb8-bddc-e4d7c8777d60"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("d4866fa1-0094-4eb8-bddc-e4d7c8777d60"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("dc744156-73d3-4ebe-9574-334a24a9a7ee"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("dc744156-73d3-4ebe-9574-334a24a9a7ee"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("dc744156-73d3-4ebe-9574-334a24a9a7ee"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("e236781c-6290-4c4f-b634-e339fd8ebc2a"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("e236781c-6290-4c4f-b634-e339fd8ebc2a"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("e236781c-6290-4c4f-b634-e339fd8ebc2a"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("e236781c-6290-4c4f-b634-e339fd8ebc2a"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("e236781c-6290-4c4f-b634-e339fd8ebc2a"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("e236781c-6290-4c4f-b634-e339fd8ebc2a"), 2020, true, true, true, true, true, true, true, true, true, true, true, true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Members_StateId",
                table: "Members",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_MemberId",
                table: "Payments",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId",
                table: "States",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "SubscriptionPaid");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
