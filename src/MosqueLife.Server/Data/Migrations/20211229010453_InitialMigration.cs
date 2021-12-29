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
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
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
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    MemberSince = table.Column<DateOnly>(type: "date", nullable: false),
                    StreetLine1 = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    StreetLine2 = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    HouseNumber = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    ZipCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Language = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
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
                table: "Members",
                columns: new[] { "Id", "BirthDate", "City", "CountryId", "Email", "FirstName", "HouseNumber", "Language", "LastName", "MemberSince", "PhoneNumber", "State", "StreetLine1", "StreetLine2", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("0e2262c1-52b1-4b2e-b848-66e83f39c903"), new DateOnly(1954, 9, 2), "Villeurbanne", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Aveline", "147", 0, "Roger", new DateOnly(2020, 8, 28), null, "VD", "2 Avenue de Nesle", "Apt. 696", "28609" },
                    { new Guid("195bdda0-e27a-487b-9e91-8039b35a4763"), new DateOnly(1984, 8, 29), "Rouen", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Alphée", "6", 0, "Gautier", new DateOnly(2020, 1, 25), null, "VD", "761 Place Laffitte", "3 étage", "81871" },
                    { new Guid("2831f824-d65d-43fd-98cc-1da45ab165a0"), new DateOnly(1955, 5, 16), "Drancy", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Inès", "175", 2, "Louis", new DateOnly(2020, 1, 27), null, "VD", "33 Avenue de Provence", "Apt. 474", "90648" },
                    { new Guid("2d126231-0496-4816-b4e6-495fdbec8ea4"), new DateOnly(1983, 11, 1), "Vitry-sur-Seine", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Delphine", "413", 2, "Nicolas", new DateOnly(2018, 5, 17), null, "VD", "1 Impasse de Solférino", "5 étage", "14757" },
                    { new Guid("3750fa65-bca0-44e5-961e-785b47d374e6"), new DateOnly(1975, 3, 22), "Le Mans", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Quiéta", "8495", 2, "Renard", new DateOnly(2018, 3, 14), null, "VD", "4 Avenue Saint-Honoré", "Apt. 196", "26826" },
                    { new Guid("38cdfadf-0aa8-47ab-a14d-e43b3c5ae46a"), new DateOnly(1963, 4, 16), "Cholet", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Emmelie", "3", 0, "Aubry", new DateOnly(2015, 3, 16), null, "VD", "6958 Avenue des Grands Augustins", "8 étage", "21564" },
                    { new Guid("4193dee9-73e6-4a03-9946-cc67ce81d6c8"), new DateOnly(1965, 11, 19), "Nanterre", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Aubertine", "3", 0, "Roux", new DateOnly(2016, 2, 7), null, "VD", "7 Voie Charlemagne", "8 étage", "61413" },
                    { new Guid("49bab813-1111-48e4-b332-efa3199a33e8"), new DateOnly(1996, 9, 23), "Orléans", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Florie", "7", 2, "Morin", new DateOnly(2016, 8, 30), null, "VD", "3 Rue Bonaparte", "3 étage", "85746" },
                    { new Guid("4ddab414-92cc-42ed-8ce6-6549ffec5211"), new DateOnly(1991, 6, 23), "Vénissieux", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Philippe", "078", 0, "Adam", new DateOnly(2015, 4, 3), null, "VD", "4450 Impasse Joubert", "7 étage", "18682" },
                    { new Guid("637b06f7-20dc-4632-bd4b-99d24cc69fd7"), new DateOnly(1995, 10, 28), "Le Havre", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Almire", "4", 1, "Roger", new DateOnly(2017, 6, 11), null, "VD", "55 Boulevard de la Paix", "Apt. 690", "33131" },
                    { new Guid("75cbb265-86b1-4614-8c1f-1f0a4b798d3f"), new DateOnly(1965, 2, 24), "Saint-Denis", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Adalard", "8", 0, "Gerard", new DateOnly(2014, 12, 31), null, "VD", "9067 Voie Lepic", "1 étage", "58948" },
                    { new Guid("76a6088d-48f5-4c3d-b3cd-9fdc5f9c4efa"), new DateOnly(1950, 1, 20), "Nice", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Débora", "1", 2, "Meunier", new DateOnly(2013, 2, 6), null, "VD", "6 Boulevard du Bac", "Apt. 234", "52017" },
                    { new Guid("9dfee284-40a3-46dd-8059-0eaca1a54c16"), new DateOnly(1995, 1, 26), "Rouen", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Landry", "0517", 2, "Bonnet", new DateOnly(2016, 5, 18), null, "VD", "48 Voie Marcadet", "Apt. 900", "62737" },
                    { new Guid("a47a66f4-6efa-4e5f-b51f-cd6929899467"), new DateOnly(1966, 5, 15), "Saint-Pierre", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Bérard", "1303", 0, "Robert", new DateOnly(2012, 1, 9), null, "VD", "8 Allée des Panoramas", "Apt. 309", "85960" },
                    { new Guid("b17a9e28-d98b-449e-a4db-bea08b3c06d4"), new DateOnly(1959, 9, 18), "Versailles", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Dorian", "57", 0, "Marie", new DateOnly(2017, 8, 19), null, "VD", "45 Avenue de la Paix", "Apt. 181", "93733" },
                    { new Guid("c37786eb-bc89-495b-9cb3-cd27d3b93f52"), new DateOnly(1994, 12, 1), "Brest", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Françoise", "6682", 0, "Marchand", new DateOnly(2015, 9, 19), null, "VD", "5489 Impasse Joubert", "0 étage", "98052" },
                    { new Guid("d9aad189-d2f5-4f02-bb90-7e8f20627c90"), new DateOnly(1966, 8, 14), "Dijon", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Timothée", "6", 1, "Menard", new DateOnly(2017, 12, 27), null, "VD", "90 Rue d'Orsel", "Apt. 146", "54012" },
                    { new Guid("ec6c91f9-c1dc-45e9-99b7-bcc097ea4786"), new DateOnly(1981, 7, 23), "Dunkerque14", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Gondebaud", "18", 0, "Rolland", new DateOnly(2017, 3, 31), null, "VD", "5673 Allée des Panoramas", "6 étage", "35902" },
                    { new Guid("f77825b6-9aa6-44f4-8252-d65df74ed794"), new DateOnly(1982, 11, 3), "Rouen", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Armine", "3815", 2, "Moulin", new DateOnly(2013, 8, 26), null, "VD", "373 Quai Zadkine", "9 étage", "09556" },
                    { new Guid("fc7f30a1-0c44-4d64-9c98-660602302e07"), new DateOnly(1979, 9, 1), "Courbevoie", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Hildebert", "3501", 0, "Poirier", new DateOnly(2020, 9, 12), null, "VD", "04 Quai du Dahomey", "7 étage", "70688" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "MemberId", "Note", "PaymentDate", "PaymentType" },
                values: new object[,]
                {
                    { new Guid("036cb2d7-edc8-428f-8225-2d66ec577c96"), 0m, new Guid("0e2262c1-52b1-4b2e-b848-66e83f39c903"), "Porro explicabo omnis. Expedita repudiandae sunt et dolor saepe velit dolorem. Hic dolor aliquam tempore rerum non. Doloremque est itaque.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("05da0f34-4b1e-430a-aa45-60568fa48415"), 0m, new Guid("2d126231-0496-4816-b4e6-495fdbec8ea4"), "Pariatur consequatur et corrupti ut illo.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("06182d6a-1108-46c1-a92d-acf42092b880"), 0m, new Guid("0e2262c1-52b1-4b2e-b848-66e83f39c903"), "Deleniti quia suscipit eius atque beatae a. Officiis perspiciatis dolores perferendis rem et accusamus. Officiis non excepturi rerum omnis eveniet voluptatem animi. Possimus mollitia aut tempora dignissimos consectetur blanditiis aut perferendis et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("067f3ee9-33bb-4214-a8a4-039b2839744d"), 0m, new Guid("d9aad189-d2f5-4f02-bb90-7e8f20627c90"), "Odit qui libero. Temporibus natus ipsum beatae rem qui. Odit quia beatae consequatur velit excepturi. Est veritatis rerum dolorem et neque.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("082b28f3-4f63-4159-9f9e-64e607f0ec7f"), 0m, new Guid("4ddab414-92cc-42ed-8ce6-6549ffec5211"), "Voluptas sed et incidunt suscipit dicta ut. Optio consequuntur a qui. Tempore sed qui eos nulla corporis. Maxime odio assumenda autem voluptatum in aut eos placeat.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("092d4af4-802c-4bf9-90eb-920fc9507b4e"), 0m, new Guid("49bab813-1111-48e4-b332-efa3199a33e8"), "Molestiae modi velit inventore ut. Rerum quia explicabo voluptates illo id iste. Est possimus cumque quia ut blanditiis adipisci recusandae.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("09889275-8279-4f7d-86b4-f11c26dfe24a"), 0m, new Guid("195bdda0-e27a-487b-9e91-8039b35a4763"), "Et minus sunt non et consequuntur. Voluptatem autem consequatur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("09b10be0-3858-413e-ab01-f15acf38a872"), 0m, new Guid("75cbb265-86b1-4614-8c1f-1f0a4b798d3f"), "Blanditiis qui consequatur qui hic nostrum maiores rerum velit. Voluptate dicta nihil recusandae.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("0ad78537-aa9d-4e9c-be66-04da26ecb6ab"), 0m, new Guid("d9aad189-d2f5-4f02-bb90-7e8f20627c90"), "Reprehenderit optio ut harum eos vitae sapiente est. Debitis autem nisi magni dolores vitae eveniet inventore nobis est.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("0c09230a-17af-4dd2-aa6f-d15e8c1c5bc4"), 0m, new Guid("c37786eb-bc89-495b-9cb3-cd27d3b93f52"), "Occaecati omnis enim consequatur assumenda. Ut facilis est recusandae reprehenderit velit. Quia et itaque dolor voluptatem commodi dolorem consectetur doloribus. Maxime ullam commodi nostrum adipisci adipisci consequatur neque ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("0c1071cf-5e36-4be3-a77c-0ae65dabea0a"), 0m, new Guid("a47a66f4-6efa-4e5f-b51f-cd6929899467"), "Saepe rerum aut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("0c26a8f3-05bb-4c50-9b47-82135c58dc87"), 0m, new Guid("75cbb265-86b1-4614-8c1f-1f0a4b798d3f"), "Est officiis consequuntur ad excepturi cupiditate voluptas voluptas dolores. Nesciunt cumque in dolores quia earum voluptatum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("0c712c40-0bbf-48d9-81a3-d837355dcdc3"), 0m, new Guid("a47a66f4-6efa-4e5f-b51f-cd6929899467"), "Voluptas expedita corporis aut distinctio. Magni ut enim nihil cumque molestiae nihil occaecati quia.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("0ce01d8f-d1a4-48fa-aa8b-fd2b2848a0ad"), 0m, new Guid("fc7f30a1-0c44-4d64-9c98-660602302e07"), "Sed autem modi minus voluptate tenetur explicabo doloribus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("0db7f636-e3bd-4228-ab67-c16707e84d1c"), 0m, new Guid("4ddab414-92cc-42ed-8ce6-6549ffec5211"), "Iste iure accusantium vel dolor voluptates fugiat inventore tempora.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("0f06aa67-2f8e-4250-89d0-af1c46075742"), 0m, new Guid("9dfee284-40a3-46dd-8059-0eaca1a54c16"), "Nobis doloribus nemo quia quidem eaque sed.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("0f1fbf7c-fc23-437c-9653-837d396958b0"), 0m, new Guid("2831f824-d65d-43fd-98cc-1da45ab165a0"), "Qui voluptatem sunt quo. Perspiciatis dolore repellat accusantium hic explicabo. Molestiae rerum animi consectetur vero doloribus aliquam quia.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("0f2ab3c7-0205-4bc4-9d22-acfb1445101a"), 0m, new Guid("ec6c91f9-c1dc-45e9-99b7-bcc097ea4786"), "At et pariatur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("0fe124af-69ce-409a-9832-f2ae64d7ae8c"), 0m, new Guid("b17a9e28-d98b-449e-a4db-bea08b3c06d4"), "Nulla eos placeat voluptate accusantium est aliquam. Voluptates ad non pariatur blanditiis iusto. Consequatur aut deleniti.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("110770e0-680b-476a-af61-2e5cbaaffd82"), 0m, new Guid("637b06f7-20dc-4632-bd4b-99d24cc69fd7"), "Odio minus consequatur. Sit ut sed inventore et aut ad.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("121c1eec-74b7-4baf-a538-23fa68ff6cc8"), 0m, new Guid("f77825b6-9aa6-44f4-8252-d65df74ed794"), "Error debitis temporibus in reprehenderit possimus necessitatibus sunt. Mollitia et odio quia rerum corrupti accusantium ut itaque quidem. Est perferendis adipisci reprehenderit cum exercitationem assumenda aut alias quam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("13acef30-44fb-4d49-a756-465f94f660f9"), 0m, new Guid("fc7f30a1-0c44-4d64-9c98-660602302e07"), "Aperiam dolorum unde corrupti et molestiae incidunt dolor repellat qui. Culpa eum nostrum. Aspernatur qui veritatis voluptatem tempore officiis dolores.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("147115a5-07d8-4922-8b36-d72dfacb305c"), 0m, new Guid("2831f824-d65d-43fd-98cc-1da45ab165a0"), "Voluptatibus recusandae sunt dolor quas voluptatem. Sequi voluptates omnis. Omnis consectetur exercitationem unde.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("192636ad-5c37-4930-b13b-7a9ff7ed54fb"), 0m, new Guid("9dfee284-40a3-46dd-8059-0eaca1a54c16"), "Et aut molestias id omnis earum et earum eos. Tempore ut sit sed nam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("197f74d9-c057-47b9-b0e2-11ac3cd1045f"), 0m, new Guid("2831f824-d65d-43fd-98cc-1da45ab165a0"), "Aut natus quia atque fuga sunt. Fugit qui omnis atque. Modi velit culpa voluptate quibusdam sit similique.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("1a14cdd3-6630-4d46-b57d-21e3071e271e"), 0m, new Guid("3750fa65-bca0-44e5-961e-785b47d374e6"), "Rerum consequatur aut consectetur consequatur veritatis et a qui. Tenetur placeat quos enim soluta.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("1fc4770e-cb75-43ba-9dfc-7a4fc491fd80"), 0m, new Guid("fc7f30a1-0c44-4d64-9c98-660602302e07"), "Non veritatis dolores quae. Unde consequatur eum facilis molestiae esse ratione soluta possimus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("20d9427f-7278-4be6-bf85-5bf635ac321a"), 0m, new Guid("3750fa65-bca0-44e5-961e-785b47d374e6"), "Possimus aut quia pariatur ea eum ad illum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("225c4b60-daa3-4501-9b5d-f23c43e54aa1"), 0m, new Guid("76a6088d-48f5-4c3d-b3cd-9fdc5f9c4efa"), "Ut assumenda quae et ducimus. Ex cupiditate dicta eum quo quidem excepturi tempore assumenda.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("22893ba4-c2c5-4e53-af6f-b0ade1decc3b"), 0m, new Guid("637b06f7-20dc-4632-bd4b-99d24cc69fd7"), "Omnis eos qui et sunt architecto autem praesentium facere explicabo. Rerum cum porro voluptatem officiis occaecati. Sed unde possimus vero dolorem. Et corporis expedita.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("22fb8bbf-d922-4696-baf5-27f35d886d60"), 0m, new Guid("2831f824-d65d-43fd-98cc-1da45ab165a0"), "Incidunt id ratione ut sit earum vero quae facere. Nesciunt reiciendis nemo. Vero facere enim sit aut itaque nihil blanditiis aut cum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("269db761-b418-494c-b7e9-d40c1541890c"), 0m, new Guid("3750fa65-bca0-44e5-961e-785b47d374e6"), "Ducimus sunt voluptate voluptas suscipit numquam ipsam dolor.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("2976cee8-b0a4-4f09-9e30-3092b0683a48"), 0m, new Guid("38cdfadf-0aa8-47ab-a14d-e43b3c5ae46a"), "Dolor accusantium ea deserunt sint. Sit error ipsum quidem blanditiis qui nisi at placeat. Dolor occaecati ratione.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("2a3b002d-a4c6-423a-9bd0-bf74eb5ab6a3"), 0m, new Guid("4ddab414-92cc-42ed-8ce6-6549ffec5211"), "Architecto perferendis qui assumenda officiis autem aut aut hic. Eum dolores et harum consequatur. Natus omnis consequatur ut rerum sit doloremque sed eveniet. Illum quae sit saepe magni ut delectus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("2b8fec7f-dec6-458d-bf4b-41f4cba39e01"), 0m, new Guid("4193dee9-73e6-4a03-9946-cc67ce81d6c8"), "Consequuntur et placeat odio sint. Et voluptatem similique.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("2e01bafc-ae1e-4a32-8386-efb951d83073"), 0m, new Guid("637b06f7-20dc-4632-bd4b-99d24cc69fd7"), "Facere dolorem amet optio. Laborum debitis minima modi aliquam qui. Beatae a et voluptatem est voluptatem minima est deserunt voluptas.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("317f5a6c-f3e6-4399-a408-0b2b940ab194"), 0m, new Guid("9dfee284-40a3-46dd-8059-0eaca1a54c16"), "Sint nemo voluptas culpa sapiente quae.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("328725d5-5c45-42eb-a3e1-dc0925b7939f"), 0m, new Guid("9dfee284-40a3-46dd-8059-0eaca1a54c16"), "Eum voluptas quia suscipit aut. Aut voluptas earum sequi cum vel tempore fuga quis rerum. Itaque ut consequuntur non et molestiae. Et qui sed et mollitia.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("32ea03b2-329c-4c58-98fa-87671efb9421"), 0m, new Guid("38cdfadf-0aa8-47ab-a14d-e43b3c5ae46a"), "Omnis incidunt unde consequuntur hic illum et repellat. Non delectus ea voluptatem debitis dicta voluptatibus animi aperiam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("347c5520-28a8-4802-ab5b-79c8cca51ebc"), 0m, new Guid("9dfee284-40a3-46dd-8059-0eaca1a54c16"), "Deserunt quod debitis. Fugit suscipit non.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("3809acb6-2ca9-4d52-a147-3dcdfb44e0bb"), 0m, new Guid("76a6088d-48f5-4c3d-b3cd-9fdc5f9c4efa"), "Repellendus maxime qui nobis cum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("38c8c338-8ee5-4aac-94f8-aa872f8de833"), 0m, new Guid("4ddab414-92cc-42ed-8ce6-6549ffec5211"), "Est dolor nesciunt voluptate sunt delectus atque expedita. Atque ratione iste nisi. Veritatis ducimus quae et cumque ullam perferendis numquam. Deserunt sit consequatur maxime et enim architecto voluptate vero.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("39fbe3ce-6de0-479b-97cc-15626c268260"), 0m, new Guid("0e2262c1-52b1-4b2e-b848-66e83f39c903"), "Doloremque veniam numquam est atque beatae et aut. Dolores voluptatibus minus aspernatur. Incidunt repudiandae occaecati dignissimos. Placeat est consequuntur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("3b1ba62e-c222-4744-8084-45dab7fed200"), 0m, new Guid("637b06f7-20dc-4632-bd4b-99d24cc69fd7"), "Quae odit nostrum sapiente. In iste omnis voluptatem excepturi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("3ffed040-8a94-4beb-9cd0-33e6ab03c322"), 0m, new Guid("f77825b6-9aa6-44f4-8252-d65df74ed794"), "Labore similique maxime assumenda dolorem sint. Et praesentium natus. Tempora in mollitia asperiores ad incidunt facilis quo.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("40af6bc1-3a19-458a-ae27-37d828a9ff9d"), 0m, new Guid("195bdda0-e27a-487b-9e91-8039b35a4763"), "Blanditiis aspernatur officiis. Veniam beatae iste. Beatae vero aut vitae maiores.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("40fb941e-f4f9-4a22-a309-cbb5203c55df"), 0m, new Guid("d9aad189-d2f5-4f02-bb90-7e8f20627c90"), "A quidem aut itaque esse quam non enim. Quia labore exercitationem odio et sit vel harum. Minus illum autem sequi at. Totam officia vero est omnis vitae expedita quasi non.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("42076ac9-7561-4129-8f99-e81cbf38b8e1"), 0m, new Guid("49bab813-1111-48e4-b332-efa3199a33e8"), "Repellat est quo et ad quasi ipsam. Veritatis ut et tempora iusto.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("45674803-b528-4e18-ae58-25ca8ec1ac3f"), 0m, new Guid("ec6c91f9-c1dc-45e9-99b7-bcc097ea4786"), "Laborum labore voluptas perferendis enim officiis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("46076d98-e1bb-4766-bd4c-661a7bdf7136"), 0m, new Guid("2831f824-d65d-43fd-98cc-1da45ab165a0"), "Aut voluptas architecto explicabo excepturi voluptas consequuntur occaecati quam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("463124c4-e596-4c84-9ea3-788cc965431c"), 0m, new Guid("0e2262c1-52b1-4b2e-b848-66e83f39c903"), "Soluta autem mollitia reiciendis dolorem minus enim vero. Minus dolore repudiandae aut modi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("465528b7-132c-4cac-b265-95662dbb5c0a"), 0m, new Guid("3750fa65-bca0-44e5-961e-785b47d374e6"), "Excepturi sed autem id repellat suscipit dolores quod sed impedit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("47d2bc55-5d9e-459c-b0a7-41936536ee2e"), 0m, new Guid("4ddab414-92cc-42ed-8ce6-6549ffec5211"), "Vero voluptas quis voluptate saepe distinctio dolorem odit libero. Soluta non sit est quia et sed delectus in. Qui rerum autem error dolorem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("48d8f1a0-4843-48f7-a384-4b34145cd761"), 0m, new Guid("2831f824-d65d-43fd-98cc-1da45ab165a0"), "Optio quia nisi quisquam. Veniam porro beatae nihil officiis aut ullam dolorum. Aut est qui voluptatem sint totam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("4ac1887d-f415-4cf3-b7f9-447654d826cb"), 0m, new Guid("fc7f30a1-0c44-4d64-9c98-660602302e07"), "Minima nobis sint quis voluptatem nulla et. Expedita reprehenderit amet suscipit voluptatibus nihil quo ut reiciendis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("4ca345f7-314a-4e20-a0a0-db20a77795c2"), 0m, new Guid("195bdda0-e27a-487b-9e91-8039b35a4763"), "Atque repellat magnam assumenda et et laudantium et ipsum itaque.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("50831e13-1d16-44e4-9151-dd11c9e89193"), 0m, new Guid("3750fa65-bca0-44e5-961e-785b47d374e6"), "Qui ad officia quam necessitatibus. Sequi illo qui amet sed vero occaecati a reiciendis. Non eum maiores voluptas sapiente qui sunt ratione voluptatem. Consequatur aliquid cum soluta recusandae nisi molestiae non qui.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("50a06425-5866-4ded-ae21-6cf5ff5827fe"), 0m, new Guid("2d126231-0496-4816-b4e6-495fdbec8ea4"), "Excepturi non maxime animi enim consequuntur occaecati temporibus. Culpa impedit vel delectus enim blanditiis fugiat dolorem velit. Eos odio ut et voluptas error modi voluptatibus. Minima sunt maxime.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("524bbd85-a592-4452-9df2-ba01936348d3"), 0m, new Guid("637b06f7-20dc-4632-bd4b-99d24cc69fd7"), "Beatae sed expedita reprehenderit quia et et pariatur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("5420c742-87d5-47bc-b03a-64f620011f8a"), 0m, new Guid("ec6c91f9-c1dc-45e9-99b7-bcc097ea4786"), "Nemo debitis ea ut officia voluptatibus. Veritatis sint qui dignissimos est nam aut vitae suscipit. Qui aut ratione eius quaerat. Asperiores sint est voluptates aliquid.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("552aca02-dff9-4ed3-a3c6-d53b3c5d4f49"), 0m, new Guid("9dfee284-40a3-46dd-8059-0eaca1a54c16"), "Velit aut eveniet in.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("55c03c98-3f6d-4e77-9510-a3fe35e9ae69"), 0m, new Guid("76a6088d-48f5-4c3d-b3cd-9fdc5f9c4efa"), "Facilis rerum fugiat quia.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("56d1230f-92da-450e-b696-39a72bbe9d33"), 0m, new Guid("2831f824-d65d-43fd-98cc-1da45ab165a0"), "Magni nulla sapiente.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("580a33d4-222b-4620-9a1a-cf85ce1dd1c1"), 0m, new Guid("f77825b6-9aa6-44f4-8252-d65df74ed794"), "Qui id quia.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("58780edd-3c8e-4502-86c7-81fece71a48d"), 0m, new Guid("d9aad189-d2f5-4f02-bb90-7e8f20627c90"), "Dolore eligendi sed quas ea in libero id. Eius dolore dolor quasi possimus distinctio aliquam aut autem. Saepe ea odit qui et nemo temporibus consequatur. Esse ut sit facilis et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("588068bd-2c33-41c7-9f64-50dd2a53ff5d"), 0m, new Guid("4193dee9-73e6-4a03-9946-cc67ce81d6c8"), "Nobis error dolore culpa at.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("593aa36b-feed-4d6e-bead-d40b68d9e24f"), 0m, new Guid("76a6088d-48f5-4c3d-b3cd-9fdc5f9c4efa"), "Illo voluptatem quia similique labore dolorem nam culpa. Officia quae dolor sunt eveniet a dolores a sed occaecati. Autem nostrum non facere perferendis rerum id voluptas corrupti. Autem nam ex autem sed voluptas quas vel illum non.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("5b09984d-638f-4579-9ab6-615a7281e6f1"), 0m, new Guid("ec6c91f9-c1dc-45e9-99b7-bcc097ea4786"), "Earum rem quis officia totam et aliquid voluptas quod dolorem. Aut vero rerum aut consequatur sed voluptate.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("5b4007be-b840-4d4f-9f33-8706318cf945"), 0m, new Guid("ec6c91f9-c1dc-45e9-99b7-bcc097ea4786"), "Sequi dolorem perspiciatis consequatur non voluptates. Quos est sint quisquam odit quo. Ratione soluta qui omnis nobis ratione nostrum ut dolor. Velit dignissimos veritatis eos qui unde recusandae placeat amet.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("5cd97c80-4752-4965-9226-f61090652593"), 0m, new Guid("49bab813-1111-48e4-b332-efa3199a33e8"), "Iure voluptas omnis velit perspiciatis incidunt. Sapiente fugiat eos assumenda qui dolorem omnis. Earum et incidunt velit distinctio eligendi quasi commodi ea. Error reprehenderit et sit illo quas asperiores sapiente voluptas.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("600b8599-ef75-4a96-a46a-0265428d632e"), 0m, new Guid("b17a9e28-d98b-449e-a4db-bea08b3c06d4"), "Pariatur sed aut mollitia et ratione et molestiae tempora qui. Eum tenetur ducimus ex delectus incidunt ad qui. Ut voluptates odio accusamus qui magni reiciendis ratione alias. Tenetur aliquam pariatur et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("6078e1a9-5f4f-445e-be8b-0f9de8336bee"), 0m, new Guid("2d126231-0496-4816-b4e6-495fdbec8ea4"), "Voluptatum deleniti et nemo molestiae corporis suscipit. Non quibusdam consequuntur. Magni iste sint in cum aperiam nulla atque. Quaerat eum et rerum optio et perspiciatis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("60987053-1fc7-4479-bcee-8fce58b52cf9"), 0m, new Guid("76a6088d-48f5-4c3d-b3cd-9fdc5f9c4efa"), "Hic est ipsa ea quasi quas possimus. Eos expedita quia. Et quis vitae dolore suscipit minus reiciendis odit est.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("63fc9f7d-bcee-40ef-b870-9b3ee737f05e"), 0m, new Guid("637b06f7-20dc-4632-bd4b-99d24cc69fd7"), "Sunt nihil quisquam ipsa et nam dignissimos voluptatem quisquam sequi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("6431a9fd-832a-4cd3-acca-2a2e29f84021"), 0m, new Guid("9dfee284-40a3-46dd-8059-0eaca1a54c16"), "Cum aut id. Est est impedit. Voluptatibus aut fugit quos reprehenderit nesciunt quis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("652744a2-a5c5-49b0-965a-d89455cd8288"), 0m, new Guid("2d126231-0496-4816-b4e6-495fdbec8ea4"), "Cupiditate laudantium quasi quo quibusdam veniam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("655dc81a-fba0-4b29-9b17-a1092b359f6d"), 0m, new Guid("75cbb265-86b1-4614-8c1f-1f0a4b798d3f"), "Ut minima qui.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("68f4e14e-90cf-4ad8-acde-2270579013ab"), 0m, new Guid("9dfee284-40a3-46dd-8059-0eaca1a54c16"), "Quis omnis ut. Libero illo animi dolorem sed recusandae et. Impedit ducimus et ab voluptas fuga quasi velit quia id.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("68f645bc-ab43-478b-93a5-4ba5f0e776a9"), 0m, new Guid("b17a9e28-d98b-449e-a4db-bea08b3c06d4"), "Nesciunt pariatur modi. In maxime minus sint inventore veritatis. Iste quas mollitia vitae est sed.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("6975b353-1d4c-4951-9122-9d5a62cb72a9"), 0m, new Guid("3750fa65-bca0-44e5-961e-785b47d374e6"), "Enim ea nihil consequatur ad nemo dolorem ipsam omnis minus. Consectetur molestias omnis architecto pariatur a et. Autem facere at rerum a tenetur. Quasi sed voluptas atque quis est.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("6a064a8a-1b9b-407f-b8ca-9cd397faaf45"), 0m, new Guid("a47a66f4-6efa-4e5f-b51f-cd6929899467"), "Qui quibusdam labore ea soluta consequuntur aut inventore ea omnis. Sit aliquam necessitatibus nobis aut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("6a7a85d2-a614-4bc0-b4d8-34b032882373"), 0m, new Guid("4193dee9-73e6-4a03-9946-cc67ce81d6c8"), "Et et in sequi incidunt cumque. Incidunt quia provident provident dolor provident expedita. Aut nam totam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("6be2455e-a305-416a-a3d6-205bc82d9452"), 0m, new Guid("2d126231-0496-4816-b4e6-495fdbec8ea4"), "Dolores libero non nostrum perferendis expedita quam vel. Recusandae eligendi corrupti consequatur incidunt numquam quasi. Ullam optio aliquid illum quas beatae. Sunt ipsam eos.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("6c4533c2-caf7-44ca-abd0-42c656861b19"), 0m, new Guid("76a6088d-48f5-4c3d-b3cd-9fdc5f9c4efa"), "Eaque ut aut excepturi et optio soluta eveniet. Laboriosam quidem repellendus dolorum non aut occaecati et sint. Ut tempore eveniet nihil est voluptatem dolorum quidem aut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("6d4322cf-a5ad-4da5-a73c-0ac00b37eacb"), 0m, new Guid("ec6c91f9-c1dc-45e9-99b7-bcc097ea4786"), "Consequuntur at quibusdam aut qui sunt dicta. Sunt consequatur exercitationem ea fugit ullam cumque adipisci.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("6fe066bc-f404-4f19-88ae-b48f7eb152db"), 0m, new Guid("76a6088d-48f5-4c3d-b3cd-9fdc5f9c4efa"), "Quo omnis velit dolores maxime labore pariatur similique. Commodi qui quibusdam explicabo. Dolorem iste doloribus iste ex.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("707dc83b-2897-48e2-a9cb-fa3f6b1dba17"), 0m, new Guid("2831f824-d65d-43fd-98cc-1da45ab165a0"), "Consequatur doloribus saepe id vel atque similique aspernatur saepe iure.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("708ea8c1-ad96-4a02-937d-17598b8e39c1"), 0m, new Guid("4193dee9-73e6-4a03-9946-cc67ce81d6c8"), "Vero doloremque labore ipsum aspernatur culpa omnis accusantium unde. Impedit qui est ut ipsam qui pariatur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("72bf1486-151c-46ae-888f-3fad782c4ef4"), 0m, new Guid("4ddab414-92cc-42ed-8ce6-6549ffec5211"), "Quae nam pariatur perferendis. Occaecati exercitationem ipsum est maiores. Quo in non. Adipisci ut eum ut modi corrupti minus voluptatem non ducimus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("731db397-f5a6-46fc-ae50-bb18fbf5a4b7"), 0m, new Guid("0e2262c1-52b1-4b2e-b848-66e83f39c903"), "Assumenda eum ut culpa velit ducimus fugiat autem ex nihil.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("7430416d-da57-4f06-bcc6-11378e30fc3f"), 0m, new Guid("b17a9e28-d98b-449e-a4db-bea08b3c06d4"), "Omnis ratione qui quas et consequuntur quasi rerum maiores. Rerum nostrum aut omnis tempora officiis culpa nemo. Facere sed iure. Ab ducimus minus quod recusandae nostrum similique.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("75736792-9e3c-41c3-a033-7f41cab050a0"), 0m, new Guid("38cdfadf-0aa8-47ab-a14d-e43b3c5ae46a"), "Ut cumque corrupti ut ipsum quis repellat nam. Harum assumenda et quaerat dolor eum. Qui laboriosam architecto.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("76575e4e-6d4b-4720-bc48-9b6be6bb9a3f"), 0m, new Guid("195bdda0-e27a-487b-9e91-8039b35a4763"), "Deserunt quis eius quisquam. Veritatis cumque praesentium officiis rerum consequatur tempora aliquid nam dolorum. Qui sint vel dolores expedita consectetur ut quibusdam omnis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("773e998b-0676-4123-8b28-f44a88774f08"), 0m, new Guid("c37786eb-bc89-495b-9cb3-cd27d3b93f52"), "Numquam assumenda est rerum nemo est totam consequatur voluptatem. Sunt ut explicabo pariatur suscipit atque sit. Beatae voluptatem molestiae.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("7742ca8d-f65e-41b0-aaf8-063e26f4950e"), 0m, new Guid("195bdda0-e27a-487b-9e91-8039b35a4763"), "Repudiandae quisquam reprehenderit ea veniam unde minus ut impedit. Molestias fugit quam fugit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("78e97322-3644-44f3-a39c-66fe6a9addd4"), 0m, new Guid("b17a9e28-d98b-449e-a4db-bea08b3c06d4"), "Praesentium molestiae voluptatem deleniti sunt eius perferendis dignissimos. Dolores omnis sed repudiandae molestiae. Vitae numquam labore. Voluptatem a quis repellendus eum nostrum mollitia.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("7b0f6ef9-019e-4706-8112-9ae3cd4a84f4"), 0m, new Guid("4ddab414-92cc-42ed-8ce6-6549ffec5211"), "Quia sapiente quam est sunt omnis quaerat.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("7c02d039-dcab-4fd3-b667-a19cede49b7a"), 0m, new Guid("ec6c91f9-c1dc-45e9-99b7-bcc097ea4786"), "Consequatur consequatur labore. Mollitia est autem dicta cumque et molestiae. Id soluta velit culpa. Quia cupiditate animi consequatur nostrum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("811408d7-358d-43ba-bbd0-7843768306c1"), 0m, new Guid("0e2262c1-52b1-4b2e-b848-66e83f39c903"), "Quasi asperiores qui quidem dolorum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("8469d09a-7c01-4c5b-ab14-45e6cd49dd0f"), 0m, new Guid("fc7f30a1-0c44-4d64-9c98-660602302e07"), "Deleniti rem ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("847f3df2-7c4c-4d4a-a1dc-a7634b44ca5e"), 0m, new Guid("4193dee9-73e6-4a03-9946-cc67ce81d6c8"), "Quas numquam et illo aut nesciunt et et velit. Quia maiores doloremque. Consequatur qui porro vel. Quia cum eum et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("84ca7869-ad2e-4105-bb68-cce667091115"), 0m, new Guid("a47a66f4-6efa-4e5f-b51f-cd6929899467"), "Aut magnam laudantium repellat excepturi illum necessitatibus voluptatem saepe magni. Maxime voluptates nisi repellat veritatis optio fuga. Dignissimos nulla est commodi vel tempora debitis. Fugit aut sit possimus est.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("84f98991-f172-4213-8909-4a13a0ce7ad7"), 0m, new Guid("a47a66f4-6efa-4e5f-b51f-cd6929899467"), "Consequatur officia in. Ut voluptatibus ad rerum dolore officiis necessitatibus ipsam dolor.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("8518fe39-e405-4448-8c6b-5dd41bf4a00a"), 0m, new Guid("a47a66f4-6efa-4e5f-b51f-cd6929899467"), "Aut atque enim libero qui. Et quis impedit assumenda aliquam. Vitae eaque dicta iure sunt blanditiis sint minima doloribus. Eos explicabo commodi quia molestiae minus quasi repudiandae et inventore.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("86f8480a-4259-4dde-8413-be0215350432"), 0m, new Guid("4193dee9-73e6-4a03-9946-cc67ce81d6c8"), "Quia alias laudantium earum quo et eum ad sed. Ut labore aut vel eius tenetur minima ut ipsum fugit. Quasi occaecati sit consequatur officiis enim ut nihil. Optio blanditiis omnis eum inventore deleniti quo quae sit nihil.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("8720c41f-d3db-4816-9356-a84f8dbe5833"), 0m, new Guid("b17a9e28-d98b-449e-a4db-bea08b3c06d4"), "Voluptatem quibusdam commodi totam occaecati doloremque omnis sequi. Dignissimos ut et accusantium id. Excepturi est ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("872ae834-6aa2-4c90-b289-cdbe7d8a377a"), 0m, new Guid("38cdfadf-0aa8-47ab-a14d-e43b3c5ae46a"), "Explicabo consequuntur veritatis officia aut in. Ut dolor illum sit. Est distinctio corporis omnis ipsam atque architecto.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("877a4a4e-ff6c-4d0c-91f9-4765dae5dd42"), 0m, new Guid("49bab813-1111-48e4-b332-efa3199a33e8"), "Dolor vero deserunt in quia culpa. Eos praesentium nisi. Quam quo minus. Et qui non consequatur impedit rem tempore qui.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("89da32f0-b297-417a-9b8d-917694e75b8f"), 0m, new Guid("a47a66f4-6efa-4e5f-b51f-cd6929899467"), "Eum minus occaecati ducimus laboriosam ea fugit sunt qui. Tempora tempore dicta non voluptatem amet suscipit voluptatem. Ut distinctio laudantium sint quis magni est ut corporis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("8ae637cd-d44b-47b4-af14-e22eb234586c"), 0m, new Guid("3750fa65-bca0-44e5-961e-785b47d374e6"), "Molestias voluptatum excepturi voluptatum cumque sapiente. Debitis delectus nemo amet.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("8c4d2e49-b81e-41a6-b8ff-09883076f663"), 0m, new Guid("c37786eb-bc89-495b-9cb3-cd27d3b93f52"), "Omnis id quo. Quae consectetur voluptates asperiores. Maxime eum aut perspiciatis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("8c6441e3-c662-43bf-a256-a0bedb58ca3e"), 0m, new Guid("38cdfadf-0aa8-47ab-a14d-e43b3c5ae46a"), "Qui eligendi autem quia. Ut vero maiores ullam quae aspernatur dolores delectus. Aut dolorum perferendis. Voluptatem minima illo et placeat deleniti earum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("8eaaab28-368d-4205-88ee-6ffa7f398692"), 0m, new Guid("d9aad189-d2f5-4f02-bb90-7e8f20627c90"), "Non qui quasi sint. Vero dolor quo quis aut eos soluta amet autem. Modi fugiat nam dignissimos fugit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("8ed1b342-ff09-43f9-8f2c-95638ba26d83"), 0m, new Guid("9dfee284-40a3-46dd-8059-0eaca1a54c16"), "Quos aliquid debitis perspiciatis dicta neque soluta voluptas dolor illo.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("8f1464ee-06e5-44b1-9d54-4685e16a3ae3"), 0m, new Guid("0e2262c1-52b1-4b2e-b848-66e83f39c903"), "Temporibus aut voluptatibus. Similique consequatur quas aspernatur molestias sint totam nihil.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("911e9575-f854-4d7f-a225-99a2f5e4ac8f"), 0m, new Guid("75cbb265-86b1-4614-8c1f-1f0a4b798d3f"), "Voluptatum id quas. Voluptatem id iste dignissimos.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("9227ab0e-2a62-4648-ad1f-5a585d6b2c26"), 0m, new Guid("3750fa65-bca0-44e5-961e-785b47d374e6"), "Quo saepe voluptatibus pariatur consectetur nihil autem qui veniam. Deserunt eos enim ut velit. Qui similique impedit cum non natus architecto.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("935a46f3-0d4a-4ef6-ae8b-7e560d817b41"), 0m, new Guid("9dfee284-40a3-46dd-8059-0eaca1a54c16"), "Eos quam sapiente eum necessitatibus doloribus. Ratione minus unde est iusto tempora.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("950176ed-a854-493f-b0d4-6dcd305b7ec2"), 0m, new Guid("ec6c91f9-c1dc-45e9-99b7-bcc097ea4786"), "Est enim rerum consectetur accusantium officia asperiores illo quis. Consequuntur dolorem libero nobis dignissimos temporibus quidem aut. Qui velit illo ipsa fuga qui iure enim.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("9550cf69-6ad2-42f0-9b5c-be8db708ef5f"), 0m, new Guid("b17a9e28-d98b-449e-a4db-bea08b3c06d4"), "Hic consectetur rem harum et eum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("9629c640-b52f-4f49-aad1-53c720def982"), 0m, new Guid("a47a66f4-6efa-4e5f-b51f-cd6929899467"), "Autem mollitia vel non maxime maiores. Esse consequuntur ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("96b09b5d-6237-4396-aec3-f19c4b10a332"), 0m, new Guid("c37786eb-bc89-495b-9cb3-cd27d3b93f52"), "Molestiae incidunt et quas ea ea. Error dignissimos ea ut voluptas beatae reprehenderit sint. Praesentium qui odit nihil maxime at ex perspiciatis voluptatem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("96dc460c-d0c1-4a25-9756-9f53d6efa6ba"), 0m, new Guid("4193dee9-73e6-4a03-9946-cc67ce81d6c8"), "Impedit quia quia numquam ea ut autem blanditiis quod. Commodi voluptates repellat quae ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("973a17e1-2878-4ac1-a0da-cfe036844df6"), 0m, new Guid("f77825b6-9aa6-44f4-8252-d65df74ed794"), "Explicabo dolorem nihil iure magni consequatur dolor dolorum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("97d45bc2-8ecc-4606-a646-f2784890366f"), 0m, new Guid("ec6c91f9-c1dc-45e9-99b7-bcc097ea4786"), "Est consectetur ex.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("9a58f1ea-781b-40f1-bdeb-889dc46efdb7"), 0m, new Guid("f77825b6-9aa6-44f4-8252-d65df74ed794"), "Sapiente veritatis doloribus distinctio provident placeat adipisci eveniet est.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("9adc7ccc-3e1d-4f20-8f36-87769d2e83da"), 0m, new Guid("2831f824-d65d-43fd-98cc-1da45ab165a0"), "Excepturi voluptatem temporibus inventore.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("9cd8cdd2-484c-4199-b998-8a39089943a0"), 0m, new Guid("38cdfadf-0aa8-47ab-a14d-e43b3c5ae46a"), "Aut neque et cumque suscipit quibusdam alias sed voluptatum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("9cee05af-1899-43c9-a019-4d8ee3327d61"), 0m, new Guid("d9aad189-d2f5-4f02-bb90-7e8f20627c90"), "Saepe odit repellendus facilis. Aperiam omnis et aut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("9d6668b3-ee5d-4698-aea4-968c35a645f5"), 0m, new Guid("d9aad189-d2f5-4f02-bb90-7e8f20627c90"), "Fuga explicabo et voluptatem ipsam facere et sunt. Qui sit maiores eos fugit vero sed ratione. Iure quis quos omnis voluptatem rerum deserunt accusamus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("a18e32b1-c3e6-461a-a79e-743857dc092f"), 0m, new Guid("3750fa65-bca0-44e5-961e-785b47d374e6"), "Cupiditate ad suscipit ea repellendus rem nam quasi in. Quidem quia architecto officia. Quis totam dolorem quis quisquam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("a1a8ccc0-3550-4a98-aaea-9496ed5f62a1"), 0m, new Guid("4ddab414-92cc-42ed-8ce6-6549ffec5211"), "Sit reprehenderit iure. Dolor sequi vel.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("a3f8422b-4608-4588-b070-d963c1e42e99"), 0m, new Guid("a47a66f4-6efa-4e5f-b51f-cd6929899467"), "Nemo esse ullam fugit eos distinctio non cumque. Sed at sunt amet voluptatem. Sequi ratione eius iusto aut sint.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("a46d1d90-e6f2-4fe7-a7b7-12b66882c030"), 0m, new Guid("4193dee9-73e6-4a03-9946-cc67ce81d6c8"), "Iure ut expedita. Sunt illo qui dolorem asperiores in. Ullam quia repellendus sed.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("a4768ab2-4f80-4e3b-b466-e2ca562ec49b"), 0m, new Guid("0e2262c1-52b1-4b2e-b848-66e83f39c903"), "Optio ut eos iste quo reprehenderit adipisci voluptas eum dolor. Accusamus necessitatibus sit id harum provident officiis minima necessitatibus fuga.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("a876311e-65f8-4682-9764-4ab45dc4d561"), 0m, new Guid("d9aad189-d2f5-4f02-bb90-7e8f20627c90"), "Distinctio temporibus quia cumque voluptate. Aspernatur eum eos est dolor accusantium quae. Quibusdam velit quam. Reprehenderit sed et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("a9676b5f-2c0d-4cf3-a0d2-aac24cc3fc64"), 0m, new Guid("38cdfadf-0aa8-47ab-a14d-e43b3c5ae46a"), "Non eum suscipit perferendis nemo sint. Vel earum eius voluptas et expedita dolorem facilis soluta in. Perferendis aut quasi. Consequatur quod quo.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("aa77d99e-6b7c-4b07-ad69-b5f6e962b6b5"), 0m, new Guid("f77825b6-9aa6-44f4-8252-d65df74ed794"), "Quas nemo dolorum eaque praesentium voluptatibus molestias blanditiis et debitis. Voluptate sint nesciunt. Nemo aut sint autem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("ab087461-33bf-4104-8b3c-a1b93e60189a"), 0m, new Guid("2d126231-0496-4816-b4e6-495fdbec8ea4"), "Et cum deleniti sunt a ipsa. Incidunt ullam ea omnis magnam reprehenderit omnis eum nostrum est.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("ab64e452-97c7-4fbd-8876-c1ee5a013ed6"), 0m, new Guid("49bab813-1111-48e4-b332-efa3199a33e8"), "Dolores praesentium aut ut labore. Aut optio dignissimos. Itaque magni quidem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("ac4d3106-1122-487a-ae9a-c9a9f02e768f"), 0m, new Guid("195bdda0-e27a-487b-9e91-8039b35a4763"), "Excepturi eos molestiae. Amet quibusdam qui vel et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("afd0d31e-a554-4841-a2a7-cd7a23cb58f2"), 0m, new Guid("76a6088d-48f5-4c3d-b3cd-9fdc5f9c4efa"), "Dolorem sint tempore reiciendis quia voluptas incidunt. Voluptatibus debitis qui et dolorem quibusdam quod. Adipisci voluptatem praesentium.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("b240cb7d-fa2c-4775-907e-a242d36f0d05"), 0m, new Guid("38cdfadf-0aa8-47ab-a14d-e43b3c5ae46a"), "Quod qui sed perferendis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("b89a571f-9aaa-47d4-ae99-f0bf86f93332"), 0m, new Guid("4193dee9-73e6-4a03-9946-cc67ce81d6c8"), "In cum dicta. Rerum et ea provident ducimus. Laudantium cumque dolor debitis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("b9421be4-3592-4c0a-a463-9e86a3c76afd"), 0m, new Guid("49bab813-1111-48e4-b332-efa3199a33e8"), "Quaerat perferendis sit qui enim autem earum fugiat.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("ba1ce1a0-02f3-44d2-b2cf-d4ef41183498"), 0m, new Guid("3750fa65-bca0-44e5-961e-785b47d374e6"), "Quis consectetur et dolorem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("bb95d1ae-1e10-4058-bb15-93f00f1669eb"), 0m, new Guid("76a6088d-48f5-4c3d-b3cd-9fdc5f9c4efa"), "Quae reiciendis quia.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("bbe83856-1fd0-4847-9eea-72029fe5fd35"), 0m, new Guid("2d126231-0496-4816-b4e6-495fdbec8ea4"), "Vel sit et. Est quidem sequi tempore iusto id esse est nobis dolorem. Rerum voluptatem et alias eos natus dignissimos ut adipisci quia.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("bcbef492-53f1-44dc-8268-33b7a9f3d1e7"), 0m, new Guid("f77825b6-9aa6-44f4-8252-d65df74ed794"), "Quas non eveniet reiciendis perspiciatis sit consectetur voluptatibus. Quia corrupti molestiae itaque placeat. At expedita omnis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("bf998bc3-6519-4fdb-85e0-c6af410278af"), 0m, new Guid("b17a9e28-d98b-449e-a4db-bea08b3c06d4"), "Adipisci sit ut autem a ducimus porro nostrum. Vel quia numquam fugiat asperiores dolores harum cupiditate alias.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("c19f7240-e934-41bb-88cf-81582bf72dce"), 0m, new Guid("637b06f7-20dc-4632-bd4b-99d24cc69fd7"), "Ab cumque maxime.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("c33ea1a1-9fd2-4445-9200-381f5ea52722"), 0m, new Guid("b17a9e28-d98b-449e-a4db-bea08b3c06d4"), "Ea alias aut incidunt molestiae inventore sunt veniam nemo.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("c4467c17-58d9-42f1-b4e2-48bd27729db8"), 0m, new Guid("4193dee9-73e6-4a03-9946-cc67ce81d6c8"), "In quia dolorem dolor sed cumque est totam aliquam. Nisi blanditiis ut dolores molestiae magni magnam inventore. Architecto temporibus voluptas et eum aliquam eum. Et adipisci molestiae aut explicabo animi inventore.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("c4eb454d-6094-47dc-8555-3a23bf74b31e"), 0m, new Guid("75cbb265-86b1-4614-8c1f-1f0a4b798d3f"), "Delectus ut dolore. Voluptatum recusandae molestiae ad vitae.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("c63e5268-6d52-4ea8-bc92-bbd35d4af38a"), 0m, new Guid("195bdda0-e27a-487b-9e91-8039b35a4763"), "Quas consequuntur aliquid totam omnis animi numquam qui repellendus ex. Numquam sequi temporibus tempore consequatur ad vel delectus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("c7afc1e0-1f5a-41f5-ba28-f44d435a6a3a"), 0m, new Guid("75cbb265-86b1-4614-8c1f-1f0a4b798d3f"), "Et in inventore sit non laboriosam autem vel accusantium repellat. Sint tempora blanditiis et ut sit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("c7e95e87-af0b-4097-af78-0c719caaa7ee"), 0m, new Guid("f77825b6-9aa6-44f4-8252-d65df74ed794"), "Sit tempore qui. Voluptates deserunt eaque voluptas alias corrupti. Et temporibus tempora omnis est nisi esse nisi iure. A neque dolorum ut corrupti.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("c8eab8a5-381e-4c38-8ef2-2e0108052bbb"), 0m, new Guid("c37786eb-bc89-495b-9cb3-cd27d3b93f52"), "Eum enim officia mollitia labore et eveniet quaerat non nulla.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("cbf8eda8-825e-440d-9bc1-d627364c17bf"), 0m, new Guid("b17a9e28-d98b-449e-a4db-bea08b3c06d4"), "Nihil porro aut explicabo ut dolorem. Et tempore sit voluptatem consequatur. Delectus autem laborum asperiores quas fugit sed. Repellat earum consequatur ducimus iusto est deserunt.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("cdf46814-b768-4811-a0c3-e2cfa862026d"), 0m, new Guid("a47a66f4-6efa-4e5f-b51f-cd6929899467"), "Ab ipsum et minus. Nobis voluptatum quia architecto libero. Et distinctio aut ut facere cum et eveniet cumque sed.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("cf524737-97c0-4c8f-9b77-2113c2cc3ea5"), 0m, new Guid("195bdda0-e27a-487b-9e91-8039b35a4763"), "Et maiores minima.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("cf76cb36-8e09-444e-b8d4-44e0ac916263"), 0m, new Guid("fc7f30a1-0c44-4d64-9c98-660602302e07"), "Voluptatem fuga deserunt sunt voluptatem. Porro et labore ipsa doloribus deleniti molestias perspiciatis iste laudantium. Facere recusandae ut explicabo doloremque non sequi voluptatem porro.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("d035d3ed-cdee-416c-9cd3-5199e566042e"), 0m, new Guid("75cbb265-86b1-4614-8c1f-1f0a4b798d3f"), "Et aut consequatur sed nobis facilis et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("d0bd8a09-8ad7-4d00-a81f-25119dff928f"), 0m, new Guid("49bab813-1111-48e4-b332-efa3199a33e8"), "Eveniet sapiente quis. Ea neque adipisci suscipit voluptatibus nostrum. Sint nobis asperiores et nostrum voluptatibus aut autem accusantium.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("d102e02f-8960-4cbf-be45-cfa05708a65d"), 0m, new Guid("c37786eb-bc89-495b-9cb3-cd27d3b93f52"), "Qui eum repudiandae incidunt voluptates. Voluptatibus unde alias sit veniam quo non a dicta est. Sit laboriosam expedita voluptas id.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("d19e426c-8483-4d3b-bc7f-dcbb682513b5"), 0m, new Guid("f77825b6-9aa6-44f4-8252-d65df74ed794"), "Facilis doloremque corporis nostrum. Laboriosam sequi in distinctio et perspiciatis et quasi molestias molestiae. Sed aliquid et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("d203f263-88e2-4c15-bc85-4bbba53aef18"), 0m, new Guid("fc7f30a1-0c44-4d64-9c98-660602302e07"), "Quia totam adipisci temporibus voluptas quis. Mollitia est iste accusantium cum sint omnis accusantium aut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("d20dad12-4cdc-46de-9119-1d781c891603"), 0m, new Guid("fc7f30a1-0c44-4d64-9c98-660602302e07"), "Exercitationem dolorem aut consequatur tempore. Et eius molestiae rerum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("d229d467-cd3a-4c89-8a5c-7a83e6364d3a"), 0m, new Guid("c37786eb-bc89-495b-9cb3-cd27d3b93f52"), "Voluptate quas voluptatem sint. Cum sed dolores unde officiis. Enim amet modi eos quod.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("d31efcc7-e3d2-4b1a-8a49-db35ec77be5f"), 0m, new Guid("75cbb265-86b1-4614-8c1f-1f0a4b798d3f"), "Facilis provident accusamus. Ut id nam sit labore qui architecto.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("d3e287a3-05b1-4334-80f6-e0fd5a51cb1e"), 0m, new Guid("fc7f30a1-0c44-4d64-9c98-660602302e07"), "Fugiat sed eum libero rerum ab doloribus recusandae. Aut temporibus officiis. Expedita quasi autem nisi quasi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("da7e47a0-49a3-4d9b-8549-59ace70c84cb"), 0m, new Guid("2d126231-0496-4816-b4e6-495fdbec8ea4"), "Est voluptatem ut. Ratione expedita nemo voluptatem. In et eum sunt quia.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("dabddac8-4d22-4271-b97f-342866c81c11"), 0m, new Guid("195bdda0-e27a-487b-9e91-8039b35a4763"), "Sed nam blanditiis est rerum omnis nisi illum magnam dolorem. Veritatis exercitationem ut officiis sunt exercitationem sit rem laboriosam earum. Nemo recusandae amet voluptates et at impedit. Ipsa earum est quidem maxime at consequatur quas dignissimos ipsa.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("db543652-4200-480b-8437-dbe317bc07d5"), 0m, new Guid("c37786eb-bc89-495b-9cb3-cd27d3b93f52"), "Consectetur ab maxime provident est voluptatem dolor dolores. Sequi voluptatem quia reiciendis voluptatem itaque enim quasi praesentium quasi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("db5dae2d-2430-4d66-aba2-032dd73e027d"), 0m, new Guid("f77825b6-9aa6-44f4-8252-d65df74ed794"), "Architecto voluptas omnis molestiae impedit maiores non quae molestiae assumenda.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("dc993415-9fa3-4b08-8697-be40735f6457"), 0m, new Guid("ec6c91f9-c1dc-45e9-99b7-bcc097ea4786"), "Velit eum et blanditiis reiciendis dolores est iusto recusandae quia. Tempora voluptas natus odio consectetur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("dd1aedb6-1a59-44fc-b5a1-080294398936"), 0m, new Guid("38cdfadf-0aa8-47ab-a14d-e43b3c5ae46a"), "Pariatur nulla et dignissimos repudiandae unde laboriosam et reiciendis nam. Rem blanditiis quaerat nobis cum occaecati et qui.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("df5e867a-96d4-40ee-bf83-66dd7c449303"), 0m, new Guid("d9aad189-d2f5-4f02-bb90-7e8f20627c90"), "In fuga doloribus nihil maxime eos.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("e0a31618-2137-490c-ad55-6d3e790611aa"), 0m, new Guid("0e2262c1-52b1-4b2e-b848-66e83f39c903"), "Aperiam qui magni aut ex voluptatibus corrupti. Ipsam earum repellendus non quis illo officiis tenetur. Sequi non aliquid minima labore impedit quia ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("e31cd4f4-4581-43ec-88be-7b87f6d0333d"), 0m, new Guid("49bab813-1111-48e4-b332-efa3199a33e8"), "Ipsam est velit. Consequatur ut blanditiis nihil. Non dolore praesentium repellendus dicta dicta occaecati.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("e53149fb-d653-44ed-ab87-64be1ae7d1c2"), 0m, new Guid("49bab813-1111-48e4-b332-efa3199a33e8"), "Iusto mollitia nobis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("e5977aa0-3ee6-4a1f-9c4f-404befef0c86"), 0m, new Guid("0e2262c1-52b1-4b2e-b848-66e83f39c903"), "Laborum omnis et velit iusto quia aut illum omnis ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("e6fc543a-bc46-4ccb-8930-82b8d868dc0d"), 0m, new Guid("c37786eb-bc89-495b-9cb3-cd27d3b93f52"), "Amet nemo dolor. Ducimus dolor ab repellat quae molestias. Est corporis eligendi eligendi sint voluptas voluptas aliquid omnis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("eb42565f-2c6d-4004-9e90-7d2395316670"), 0m, new Guid("637b06f7-20dc-4632-bd4b-99d24cc69fd7"), "Eos eos modi est possimus debitis possimus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("ee3568ec-2fb2-47db-9867-8584bba75d21"), 0m, new Guid("2d126231-0496-4816-b4e6-495fdbec8ea4"), "Eligendi sit sit amet voluptatem delectus nam et eum blanditiis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("ef0b155b-742f-45ff-982b-d125a6d9a11e"), 0m, new Guid("637b06f7-20dc-4632-bd4b-99d24cc69fd7"), "Dolorum error excepturi omnis. Ipsa veniam rem similique. Voluptas ratione molestiae vel reprehenderit quos. Perferendis quia qui ut et possimus alias.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("f0ee26cc-31a2-491e-9355-b315cc4af3d8"), 0m, new Guid("75cbb265-86b1-4614-8c1f-1f0a4b798d3f"), "Quo omnis doloremque. Asperiores enim non. Facilis sed earum officiis quas impedit iste sed fugiat. Eaque consequuntur voluptatem porro sint voluptatibus dolor qui beatae ea.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("f2226125-5d4f-447f-8703-05b7ca3f3961"), 0m, new Guid("2d126231-0496-4816-b4e6-495fdbec8ea4"), "Totam iure molestias.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("f33a742d-28bc-4636-959f-0ac83e4dc7d4"), 0m, new Guid("49bab813-1111-48e4-b332-efa3199a33e8"), "Est unde distinctio tempora molestiae vitae distinctio eius atque iure. Blanditiis blanditiis et minus quis. Ipsa sed eos consequatur ea blanditiis maxime doloremque commodi inventore.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("f3c4b157-fe09-4f24-b701-27652fbd423e"), 0m, new Guid("4ddab414-92cc-42ed-8ce6-6549ffec5211"), "Esse modi error inventore molestias aut voluptate ipsum cum nihil. Quibusdam est est non voluptatum consequatur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("f3ebdba3-6d7b-47d2-9ac8-9aad3afbde96"), 0m, new Guid("fc7f30a1-0c44-4d64-9c98-660602302e07"), "Provident dolor odit numquam voluptatem maxime odit quos accusantium et. Libero cupiditate quod nisi qui. Non nisi dicta rem sint dolores rerum dolorum consequuntur. Ipsum in voluptas et quia earum sit possimus ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("f649bd73-8054-4cf6-aaba-ad63662b7389"), 0m, new Guid("75cbb265-86b1-4614-8c1f-1f0a4b798d3f"), "Numquam qui ab dicta qui qui modi laboriosam porro provident. Sint doloribus iusto eaque aut. Magnam magnam suscipit est non saepe voluptatibus et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("f905a129-4db6-4227-aa06-54fe4717854f"), 0m, new Guid("637b06f7-20dc-4632-bd4b-99d24cc69fd7"), "Veniam error eaque ut suscipit aut dolor. Aliquam at dolorem saepe. Occaecati laboriosam autem. Sed dolores ad suscipit debitis velit corrupti.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("f9d255fa-477c-4a52-8d86-b4d178b506fe"), 0m, new Guid("c37786eb-bc89-495b-9cb3-cd27d3b93f52"), "Vel ut est dolore saepe ex numquam magni dolor ipsa. Voluptates facilis odio consectetur soluta qui minus sit non aut. Doloribus perspiciatis similique omnis tenetur at dolor sunt.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("fac3200a-cdb0-42e2-ac9b-b1bb0f5d8cec"), 0m, new Guid("38cdfadf-0aa8-47ab-a14d-e43b3c5ae46a"), "Esse omnis labore corporis laboriosam numquam officia et repellendus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("fb6f3cc7-0569-48c6-bcc4-d0f27fee8b6d"), 0m, new Guid("2831f824-d65d-43fd-98cc-1da45ab165a0"), "Veniam perferendis ut ut sint totam voluptate cum deleniti.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("fba6eebc-736f-48b2-9ac8-c32c0b3be853"), 0m, new Guid("76a6088d-48f5-4c3d-b3cd-9fdc5f9c4efa"), "Eos non aliquam excepturi. Id esse aut maxime modi vero ex voluptas est. Pariatur nobis soluta incidunt sit veritatis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("fd421da5-fa6f-4781-a3f0-d1f3b2694db6"), 0m, new Guid("195bdda0-e27a-487b-9e91-8039b35a4763"), "Autem explicabo velit. Numquam quae voluptatem facilis architecto accusamus. Atque facere debitis ducimus culpa culpa eum placeat. Facere in inventore.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("ff7c1605-85a1-4e31-9374-04c74a53c4bc"), 0m, new Guid("d9aad189-d2f5-4f02-bb90-7e8f20627c90"), "Et distinctio sunt debitis et sunt corrupti beatae reprehenderit omnis. Explicabo debitis cum dolor vero. Ab et fugiat iure aut id commodi similique perferendis velit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("ff7d9dd9-976c-4b28-8533-6230ef49412e"), 0m, new Guid("4ddab414-92cc-42ed-8ce6-6549ffec5211"), "Quae error dignissimos sed maxime ut ipsam. Et quae minus aut rerum delectus doloremque facilis mollitia hic.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "SubscriptionPaid",
                columns: new[] { "MemberId", "Year", "April", "August", "December", "February", "January", "July", "June", "March", "May", "November", "October", "September" },
                values: new object[,]
                {
                    { new Guid("0e2262c1-52b1-4b2e-b848-66e83f39c903"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("0e2262c1-52b1-4b2e-b848-66e83f39c903"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("195bdda0-e27a-487b-9e91-8039b35a4763"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("2831f824-d65d-43fd-98cc-1da45ab165a0"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("3750fa65-bca0-44e5-961e-785b47d374e6"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("3750fa65-bca0-44e5-961e-785b47d374e6"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("3750fa65-bca0-44e5-961e-785b47d374e6"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("3750fa65-bca0-44e5-961e-785b47d374e6"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("3750fa65-bca0-44e5-961e-785b47d374e6"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("3750fa65-bca0-44e5-961e-785b47d374e6"), 2020, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("3750fa65-bca0-44e5-961e-785b47d374e6"), 2021, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("38cdfadf-0aa8-47ab-a14d-e43b3c5ae46a"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("38cdfadf-0aa8-47ab-a14d-e43b3c5ae46a"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("38cdfadf-0aa8-47ab-a14d-e43b3c5ae46a"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("38cdfadf-0aa8-47ab-a14d-e43b3c5ae46a"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("38cdfadf-0aa8-47ab-a14d-e43b3c5ae46a"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("38cdfadf-0aa8-47ab-a14d-e43b3c5ae46a"), 2020, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("4193dee9-73e6-4a03-9946-cc67ce81d6c8"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("4193dee9-73e6-4a03-9946-cc67ce81d6c8"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("4193dee9-73e6-4a03-9946-cc67ce81d6c8"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("4193dee9-73e6-4a03-9946-cc67ce81d6c8"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("4193dee9-73e6-4a03-9946-cc67ce81d6c8"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("49bab813-1111-48e4-b332-efa3199a33e8"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("49bab813-1111-48e4-b332-efa3199a33e8"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("4ddab414-92cc-42ed-8ce6-6549ffec5211"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("4ddab414-92cc-42ed-8ce6-6549ffec5211"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("4ddab414-92cc-42ed-8ce6-6549ffec5211"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("4ddab414-92cc-42ed-8ce6-6549ffec5211"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("637b06f7-20dc-4632-bd4b-99d24cc69fd7"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("637b06f7-20dc-4632-bd4b-99d24cc69fd7"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("637b06f7-20dc-4632-bd4b-99d24cc69fd7"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("637b06f7-20dc-4632-bd4b-99d24cc69fd7"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("637b06f7-20dc-4632-bd4b-99d24cc69fd7"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("75cbb265-86b1-4614-8c1f-1f0a4b798d3f"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("75cbb265-86b1-4614-8c1f-1f0a4b798d3f"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("75cbb265-86b1-4614-8c1f-1f0a4b798d3f"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("75cbb265-86b1-4614-8c1f-1f0a4b798d3f"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("75cbb265-86b1-4614-8c1f-1f0a4b798d3f"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("75cbb265-86b1-4614-8c1f-1f0a4b798d3f"), 2020, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("75cbb265-86b1-4614-8c1f-1f0a4b798d3f"), 2021, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("76a6088d-48f5-4c3d-b3cd-9fdc5f9c4efa"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("76a6088d-48f5-4c3d-b3cd-9fdc5f9c4efa"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("76a6088d-48f5-4c3d-b3cd-9fdc5f9c4efa"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("76a6088d-48f5-4c3d-b3cd-9fdc5f9c4efa"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("a47a66f4-6efa-4e5f-b51f-cd6929899467"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("a47a66f4-6efa-4e5f-b51f-cd6929899467"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("a47a66f4-6efa-4e5f-b51f-cd6929899467"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("a47a66f4-6efa-4e5f-b51f-cd6929899467"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("a47a66f4-6efa-4e5f-b51f-cd6929899467"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("a47a66f4-6efa-4e5f-b51f-cd6929899467"), 2020, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("b17a9e28-d98b-449e-a4db-bea08b3c06d4"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("b17a9e28-d98b-449e-a4db-bea08b3c06d4"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("c37786eb-bc89-495b-9cb3-cd27d3b93f52"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("c37786eb-bc89-495b-9cb3-cd27d3b93f52"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("c37786eb-bc89-495b-9cb3-cd27d3b93f52"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("c37786eb-bc89-495b-9cb3-cd27d3b93f52"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("c37786eb-bc89-495b-9cb3-cd27d3b93f52"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("c37786eb-bc89-495b-9cb3-cd27d3b93f52"), 2020, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("d9aad189-d2f5-4f02-bb90-7e8f20627c90"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("ec6c91f9-c1dc-45e9-99b7-bcc097ea4786"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("ec6c91f9-c1dc-45e9-99b7-bcc097ea4786"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("ec6c91f9-c1dc-45e9-99b7-bcc097ea4786"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("f77825b6-9aa6-44f4-8252-d65df74ed794"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("f77825b6-9aa6-44f4-8252-d65df74ed794"), 2016, true, true, true, true, true, true, true, true, true, true, true, true }
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
                name: "IX_Members_CountryId",
                table: "Members",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_MemberId",
                table: "Payments",
                column: "MemberId");
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
                name: "Countries");
        }
    }
}
