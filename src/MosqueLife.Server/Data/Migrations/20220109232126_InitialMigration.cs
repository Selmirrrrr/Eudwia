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
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
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
                name: "SubscriptionsPaid",
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
                    table.PrimaryKey("PK_SubscriptionsPaid", x => new { x.MemberId, x.Year });
                    table.ForeignKey(
                        name: "FK_SubscriptionsPaid_Members_MemberId",
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
                    { new Guid("09f419d2-09d8-4182-ac95-695055e5e634"), new DateOnly(1992, 5, 6), "Roubaix", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Adelie_Bertrand@gmail.com", "Amaliane", "349", 2, "Lemaire", new DateOnly(2013, 2, 12), "0526436068", "VD", "2 Quai du Dahomey", "Apt. 036", "35412" },
                    { new Guid("12d76e6f-a966-4235-8f43-991d88418b1f"), new DateOnly(1980, 9, 30), "Toulouse", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Adelie_Bertrand@gmail.com", "Eusébie", "6", 1, "Cousin", new DateOnly(2012, 12, 12), "0526436068", "VD", "5 Impasse Montorgueil", "Apt. 007", "84883" },
                    { new Guid("15358ab3-4b57-4e5e-877a-7e4762f018d4"), new DateOnly(1977, 5, 22), "Bourges", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Adelie_Bertrand@gmail.com", "Réjeanne", "4", 2, "Rousseau", new DateOnly(2018, 5, 28), "0526436068", "VD", "4242 Place de Paris", "4 étage", "16186" },
                    { new Guid("1f75aa88-935c-4eb2-9891-d39332949ed6"), new DateOnly(1969, 6, 3), "Aubervilliers", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Adelie_Bertrand@gmail.com", "Yvonne", "02", 0, "Lucas", new DateOnly(2015, 3, 24), "0526436068", "VD", "8653 Rue Joubert", "Apt. 705", "75568" },
                    { new Guid("39ef24e4-1de6-423d-b64d-c7057cd571cc"), new DateOnly(1985, 5, 8), "Boulogne-Billancourt", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Adelie_Bertrand@gmail.com", "Berthe", "7721", 1, "Garnier", new DateOnly(2020, 10, 25), "0526436068", "VD", "097 Boulevard d'Argenteuil", "9 étage", "45589" },
                    { new Guid("3ee5aab2-ccc1-45d2-89c0-341336f72a9a"), new DateOnly(1974, 8, 6), "Saint-Denis", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Adelie_Bertrand@gmail.com", "Léon", "8", 1, "Bonnet", new DateOnly(2015, 4, 16), "0526436068", "VD", "9952 Quai Monsieur-le-Prince", "9 étage", "61572" },
                    { new Guid("4385ff43-6e8d-444f-a265-cf8d478744f6"), new DateOnly(1973, 10, 6), "Avignon", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Adelie_Bertrand@gmail.com", "Alcide", "4792", 0, "Robert", new DateOnly(2014, 10, 18), "0526436068", "VD", "203 Passage de Provence", "Apt. 759", "54594" },
                    { new Guid("48fd525f-4966-41e8-968d-3f7149e389ae"), new DateOnly(1957, 9, 25), "Tours", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Adelie_Bertrand@gmail.com", "Élisabeth", "77", 2, "Le roux", new DateOnly(2021, 4, 15), "0526436068", "VD", "2246 Avenue de la Harpe", "Apt. 828", "22630" },
                    { new Guid("5ec1fd6b-5237-4f3d-94c1-fc36c7744b1d"), new DateOnly(1999, 9, 16), "Paris", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Adelie_Bertrand@gmail.com", "Madeleine", "07", 1, "Adam", new DateOnly(2020, 6, 7), "0526436068", "VD", "25 Impasse Saint-Bernard", "Apt. 604", "68194" },
                    { new Guid("793a0118-98ec-4b18-83ca-6d5f77fda5a0"), new DateOnly(1971, 4, 23), "Saint-Denis", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Adelie_Bertrand@gmail.com", "Aymardine", "5659", 0, "Guillaume", new DateOnly(2013, 11, 4), "0526436068", "VD", "142 Voie de Tilsitt", "0 étage", "93656" },
                    { new Guid("7e3ec143-3e22-48ca-8dd5-4fb8965cbebe"), new DateOnly(1964, 5, 3), "Nanterre", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Adelie_Bertrand@gmail.com", "Camille", "73", 0, "Schneider", new DateOnly(2012, 8, 27), "0526436068", "VD", "7664 Voie de la Chaussée-d'Antin", "Apt. 085", "13449" },
                    { new Guid("83f91037-a88d-4711-9911-ff86488bc237"), new DateOnly(1992, 6, 15), "Saint-Denis", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Adelie_Bertrand@gmail.com", "Anselme", "2454", 2, "Legrand", new DateOnly(2018, 1, 12), "0526436068", "VD", "9764 Passage Laffitte", "Apt. 089", "97606" },
                    { new Guid("8c59bd75-b7f6-43d5-87c5-c44061095f9c"), new DateOnly(1975, 7, 30), "Nice", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Adelie_Bertrand@gmail.com", "François", "543", 0, "Simon", new DateOnly(2014, 8, 6), "0526436068", "VD", "566 Boulevard Joubert", "2 étage", "92790" },
                    { new Guid("abe7de98-bd86-4c20-9918-d0e3d8867123"), new DateOnly(1970, 12, 25), "Villeneuve-d'Ascq", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Adelie_Bertrand@gmail.com", "Éléonore", "14", 0, "Paul", new DateOnly(2018, 6, 10), "0526436068", "VD", "60 Place du Dahomey", "8 étage", "01226" },
                    { new Guid("b2724ea1-4cce-450f-8bab-67988a9f865e"), new DateOnly(1979, 11, 4), "Clichy", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Adelie_Bertrand@gmail.com", "Fiacre", "8", 1, "Guyot", new DateOnly(2013, 12, 26), "0526436068", "VD", "3 Avenue de Paris", "5 étage", "61960" },
                    { new Guid("c93cf7ba-5301-4a59-8238-b7a2e73b924f"), new DateOnly(1996, 9, 20), "Beauvais", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Adelie_Bertrand@gmail.com", "Argine", "31", 0, "Muller", new DateOnly(2019, 1, 18), "0526436068", "VD", "2731 Quai des Lombards", "Apt. 671", "74965" },
                    { new Guid("cbf11d4f-3fe4-4ec9-ba79-fc5ff2ee2f4b"), new DateOnly(1998, 10, 14), "Colombes", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Adelie_Bertrand@gmail.com", "Ludovic", "9223", 0, "Berger", new DateOnly(2013, 6, 18), "0526436068", "VD", "9 Rue de Seine", "4 étage", "80261" },
                    { new Guid("ed8f84dd-7f9d-4317-80fa-419913dc23fb"), new DateOnly(1956, 4, 4), "Sarcelles", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Adelie_Bertrand@gmail.com", "Sigismond", "075", 1, "Barre", new DateOnly(2012, 3, 4), "0526436068", "VD", "7969 Allée de Tilsitt", "Apt. 264", "06091" },
                    { new Guid("f6cde8a2-e554-41d3-ae69-9589170b99c9"), new DateOnly(1977, 1, 24), "Versailles", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Adelie_Bertrand@gmail.com", "Loïc", "040", 2, "Carpentier", new DateOnly(2014, 7, 15), "0526436068", "VD", "8012 Place de Caumartin", "Apt. 758", "27663" },
                    { new Guid("fdaf0699-a28e-403c-8775-54a475a1cf0a"), new DateOnly(1985, 4, 9), "Aix-en-Provence", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Adelie_Bertrand@gmail.com", "Sauveur", "691", 1, "Durand", new DateOnly(2015, 6, 10), "0526436068", "VD", "168 Boulevard Saint-Dominique", "3 étage", "65475" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "IsDeleted", "MemberId", "Note", "PaymentDate", "PaymentType" },
                values: new object[,]
                {
                    { new Guid("0010c42c-6643-44bb-a8ad-7beb9670c90e"), 195.159071737537000m, false, new Guid("abe7de98-bd86-4c20-9918-d0e3d8867123"), "Aliquam non est. Sint ut alias magnam nesciunt corporis.", new DateTime(2013, 12, 6, 5, 16, 25, 906, DateTimeKind.Utc).AddTicks(789), 99 },
                    { new Guid("014a468d-5771-4f1f-9b63-05f59776766d"), 722.912756240841000m, false, new Guid("4385ff43-6e8d-444f-a265-cf8d478744f6"), "Et est labore nulla autem autem tempore. Molestiae corrupti magni sapiente esse. Dolorem commodi ipsum deleniti architecto aut cum enim. Officiis reiciendis error debitis enim accusamus voluptatem dolores quae.", new DateTime(2019, 8, 28, 4, 53, 44, 541, DateTimeKind.Utc).AddTicks(5637), 0 },
                    { new Guid("01611c6f-d1fb-4874-90d1-1abb9c99a579"), 692.386913524535000m, false, new Guid("793a0118-98ec-4b18-83ca-6d5f77fda5a0"), "In est laudantium exercitationem quo illo. Rem dolores velit eos non sequi distinctio necessitatibus ea eius. Distinctio et ut quia voluptas quo in non rerum. Nobis quod mollitia molestias aliquam ut molestiae.", new DateTime(2018, 2, 10, 6, 55, 33, 855, DateTimeKind.Utc).AddTicks(136), 1 },
                    { new Guid("01846f64-6d6b-4665-a335-e6ec71e4185a"), 464.277525171198000m, false, new Guid("09f419d2-09d8-4182-ac95-695055e5e634"), "Tempore iste id aspernatur facere voluptas tempora. Quia et incidunt.", new DateTime(2015, 10, 7, 16, 56, 1, 987, DateTimeKind.Utc).AddTicks(4372), 0 },
                    { new Guid("0286bad7-c948-4feb-a11d-dfb84cd3aef0"), 203.989306413048000m, false, new Guid("3ee5aab2-ccc1-45d2-89c0-341336f72a9a"), "Labore libero est quo reiciendis ut omnis. Est iusto animi ipsam aliquam fugit enim modi consequatur est. Sint sint eligendi repellat omnis et ratione dolore quis voluptatem.", new DateTime(2015, 4, 12, 11, 9, 10, 398, DateTimeKind.Utc).AddTicks(9908), 1 },
                    { new Guid("03207876-5262-4734-9e9d-d8efbb17b4b7"), 973.483859437349000m, false, new Guid("793a0118-98ec-4b18-83ca-6d5f77fda5a0"), "Doloribus debitis eum voluptas est et ut fugit accusantium. Beatae voluptatem est qui adipisci optio non quia.", new DateTime(2014, 3, 26, 18, 8, 28, 201, DateTimeKind.Utc).AddTicks(8969), 1 },
                    { new Guid("05e7493a-e7da-401f-84b5-ca5e454cb71f"), 957.441302492632000m, false, new Guid("fdaf0699-a28e-403c-8775-54a475a1cf0a"), "Cumque totam dolores voluptates accusantium voluptatum qui repudiandae. Sit quas et perferendis numquam voluptatem et quis adipisci sunt. Amet dolorem cumque voluptas delectus quia molestias omnis consequatur quis. Dolorem nemo et magnam animi tempora dolorum.", new DateTime(2015, 4, 20, 7, 40, 35, 981, DateTimeKind.Utc).AddTicks(7025), 99 },
                    { new Guid("05f86833-16f9-4606-8372-68261022a08f"), 528.141589196356000m, false, new Guid("1f75aa88-935c-4eb2-9891-d39332949ed6"), "Vel in aut dolor minima ut magni nemo ipsa. Ducimus voluptas molestiae ut minus cum. Qui autem voluptatem.", new DateTime(2016, 1, 16, 22, 21, 50, 441, DateTimeKind.Utc).AddTicks(5221), 99 },
                    { new Guid("065421a0-63f9-434f-80bb-f8b0ec63322d"), 90.2286971445073000m, false, new Guid("48fd525f-4966-41e8-968d-3f7149e389ae"), "Natus vel temporibus amet earum deleniti necessitatibus sunt sint eos.", new DateTime(2017, 5, 3, 16, 12, 45, 837, DateTimeKind.Utc).AddTicks(528), 99 },
                    { new Guid("075e1940-1984-4e96-b10f-883c3db67c03"), 672.173485226849000m, false, new Guid("7e3ec143-3e22-48ca-8dd5-4fb8965cbebe"), "Repellat atque ut voluptas est at sint. Non voluptatibus esse placeat. Sit fuga et rerum ipsa esse est quaerat.", new DateTime(2014, 2, 10, 18, 19, 15, 663, DateTimeKind.Utc).AddTicks(8651), 0 },
                    { new Guid("0890ebc8-257f-4f51-a155-86aab41068c9"), 626.777899132457000m, false, new Guid("15358ab3-4b57-4e5e-877a-7e4762f018d4"), "Saepe illum sequi ut et molestiae cum et. Est sint dolores nostrum consequatur ipsa. Illum repellat et dolor pariatur culpa.", new DateTime(2017, 9, 16, 15, 0, 48, 688, DateTimeKind.Utc).AddTicks(6925), 0 },
                    { new Guid("09c35a46-0477-4148-851d-b8359cfcbb4b"), 403.200468767293000m, false, new Guid("f6cde8a2-e554-41d3-ae69-9589170b99c9"), "Officiis earum commodi quaerat ratione nihil. Dolor qui et et fugit voluptatibus placeat qui enim fuga.", new DateTime(2015, 11, 28, 12, 28, 7, 921, DateTimeKind.Utc).AddTicks(2976), 0 },
                    { new Guid("0af8ad3c-f21f-4bdd-b45e-50b34b7c49e5"), 265.123479975336000m, false, new Guid("8c59bd75-b7f6-43d5-87c5-c44061095f9c"), "Iusto aliquid atque temporibus neque rem. Reiciendis et omnis enim nostrum doloremque omnis fuga placeat. Omnis cupiditate itaque est reiciendis provident. Asperiores ut et sint et aut aperiam libero perspiciatis.", new DateTime(2021, 2, 10, 8, 53, 37, 732, DateTimeKind.Utc).AddTicks(638), 0 },
                    { new Guid("0c14d375-cf00-4c3d-989f-fb83bfc98f33"), 456.623800817528000m, false, new Guid("f6cde8a2-e554-41d3-ae69-9589170b99c9"), "Natus eveniet dolorem harum cumque rem vel iure. Sit harum itaque iste est. Labore voluptatem voluptate occaecati architecto necessitatibus earum. Quo quos beatae sit deleniti voluptatem.", new DateTime(2015, 4, 27, 13, 23, 4, 187, DateTimeKind.Utc).AddTicks(8852), 1 },
                    { new Guid("0c96230c-eefa-42fd-a8c9-365c282f6df4"), 2.53621368921408000m, false, new Guid("793a0118-98ec-4b18-83ca-6d5f77fda5a0"), "Consectetur placeat fugiat et aut minima ad autem.", new DateTime(2015, 12, 13, 15, 11, 11, 288, DateTimeKind.Utc).AddTicks(4413), 1 },
                    { new Guid("0d233e58-2ca8-4830-9997-d7dae2a90a10"), 289.180298265437000m, false, new Guid("1f75aa88-935c-4eb2-9891-d39332949ed6"), "Occaecati qui ratione.", new DateTime(2018, 2, 22, 19, 6, 55, 421, DateTimeKind.Utc).AddTicks(8922), 0 },
                    { new Guid("0e371d68-e70e-4dce-85fe-25dbb228d27f"), 388.81583358695000m, false, new Guid("f6cde8a2-e554-41d3-ae69-9589170b99c9"), "Similique perferendis impedit vero facere aut.", new DateTime(2020, 1, 3, 22, 32, 3, 421, DateTimeKind.Utc).AddTicks(8914), 0 },
                    { new Guid("0e47874e-18e2-4764-ae1e-c688c6d4ef05"), 167.113965734773000m, false, new Guid("abe7de98-bd86-4c20-9918-d0e3d8867123"), "Earum velit impedit iusto perferendis quisquam esse.", new DateTime(2018, 3, 7, 15, 46, 32, 291, DateTimeKind.Utc).AddTicks(8673), 0 },
                    { new Guid("0e61a0ff-5921-4ce5-894e-0502cb22b3ab"), 338.244991402592000m, false, new Guid("1f75aa88-935c-4eb2-9891-d39332949ed6"), "Culpa fugit maiores. Fuga beatae molestiae culpa aut officia accusantium quia. Id eveniet expedita laboriosam et.", new DateTime(2013, 5, 13, 19, 32, 14, 765, DateTimeKind.Utc).AddTicks(1908), 1 },
                    { new Guid("0e72a308-063c-40b8-9404-8c7dfac3ce62"), 748.916408231903000m, false, new Guid("4385ff43-6e8d-444f-a265-cf8d478744f6"), "Repellendus animi ducimus consequuntur. Et ut in quidem optio. Quo quidem eos sunt.", new DateTime(2013, 3, 29, 3, 29, 42, 563, DateTimeKind.Utc).AddTicks(7498), 0 },
                    { new Guid("0eebba63-c2fe-4c5a-9af1-4985a7caa8c0"), 159.496339505332000m, false, new Guid("8c59bd75-b7f6-43d5-87c5-c44061095f9c"), "Veniam odio placeat suscipit autem fugiat reiciendis est laudantium consequatur. Eum quis voluptas ut sed exercitationem eligendi totam in. Quia sed saepe hic esse ut. Voluptates et temporibus reiciendis architecto quia aspernatur.", new DateTime(2013, 2, 26, 20, 7, 18, 943, DateTimeKind.Utc).AddTicks(6407), 99 },
                    { new Guid("0ef179e4-c68f-42fe-b644-91e9da826683"), 38.0661890518579000m, false, new Guid("c93cf7ba-5301-4a59-8238-b7a2e73b924f"), "Earum incidunt et. Distinctio eius voluptatem repellendus quidem totam. Quibusdam cum saepe ut voluptatem ullam nemo eos consequuntur enim.", new DateTime(2021, 8, 16, 0, 6, 37, 930, DateTimeKind.Utc).AddTicks(3697), 0 },
                    { new Guid("11963338-08e6-4c97-9d74-1c8c69fa4781"), 732.03364700091000m, false, new Guid("4385ff43-6e8d-444f-a265-cf8d478744f6"), "Qui reprehenderit doloremque id sed sit odio quidem at.", new DateTime(2012, 6, 23, 9, 32, 34, 819, DateTimeKind.Utc).AddTicks(5263), 99 },
                    { new Guid("12747bbc-c925-4718-b291-93a25209fb4d"), 586.371520615042000m, false, new Guid("cbf11d4f-3fe4-4ec9-ba79-fc5ff2ee2f4b"), "Ratione deserunt ut qui. Animi qui est enim officia numquam.", new DateTime(2016, 12, 21, 3, 11, 26, 287, DateTimeKind.Utc).AddTicks(6996), 0 },
                    { new Guid("12bdbee1-960c-4b66-afa1-f83091fa0f85"), 307.183384842941000m, false, new Guid("5ec1fd6b-5237-4f3d-94c1-fc36c7744b1d"), "Voluptate et sit neque. Aspernatur accusantium dolor et consequatur. Deserunt est qui quasi quas dolorem. Laudantium culpa libero in ad.", new DateTime(2012, 12, 11, 4, 48, 9, 136, DateTimeKind.Utc).AddTicks(9452), 99 },
                    { new Guid("138936a2-d8d4-46e2-933c-2d4b1a31ba7e"), 431.97579690472000m, false, new Guid("f6cde8a2-e554-41d3-ae69-9589170b99c9"), "Aut adipisci voluptatibus unde vero molestiae.", new DateTime(2019, 1, 14, 21, 29, 53, 888, DateTimeKind.Utc).AddTicks(9108), 99 },
                    { new Guid("14b6c762-cf90-4e69-b79c-f72c7b9c507c"), 484.717790227219000m, false, new Guid("7e3ec143-3e22-48ca-8dd5-4fb8965cbebe"), "Velit voluptatem error eum quaerat quas. Commodi pariatur facere tempora.", new DateTime(2017, 4, 23, 20, 44, 58, 614, DateTimeKind.Utc).AddTicks(4429), 0 },
                    { new Guid("1638e778-6ad7-4e46-973e-8aa7085fb461"), 73.2493468775304000m, false, new Guid("abe7de98-bd86-4c20-9918-d0e3d8867123"), "Vel consequatur et. Sed qui sunt deleniti cupiditate veniam necessitatibus velit. Ut fugit iusto incidunt tenetur natus dolore. Officiis harum ab ipsum deleniti nihil.", new DateTime(2017, 9, 17, 23, 16, 4, 906, DateTimeKind.Utc).AddTicks(7298), 0 },
                    { new Guid("169455e7-ff4e-4128-9c53-ae1a3371774e"), 29.6677507252673000m, false, new Guid("39ef24e4-1de6-423d-b64d-c7057cd571cc"), "Exercitationem quod qui quia numquam et labore deleniti sit. Numquam similique est et culpa. Fuga nam et corrupti.", new DateTime(2014, 4, 1, 16, 44, 10, 713, DateTimeKind.Utc).AddTicks(2845), 1 },
                    { new Guid("1901cb89-1504-4ec6-9d22-e459e93ea572"), 61.1278807960801000m, false, new Guid("83f91037-a88d-4711-9911-ff86488bc237"), "Accusamus architecto ad. Recusandae totam et. Ea et libero ut autem voluptates est.", new DateTime(2016, 7, 17, 22, 58, 10, 713, DateTimeKind.Utc).AddTicks(3996), 1 },
                    { new Guid("1a279943-daba-4000-b170-c46a5f7c2a77"), 392.640783637317000m, false, new Guid("8c59bd75-b7f6-43d5-87c5-c44061095f9c"), "Nesciunt omnis voluptas nesciunt ea eos nihil perspiciatis.", new DateTime(2014, 9, 4, 21, 58, 51, 249, DateTimeKind.Utc).AddTicks(1357), 1 },
                    { new Guid("1ac9cbbc-e59f-49fd-8af2-e7520584cabf"), 470.508075371841000m, false, new Guid("ed8f84dd-7f9d-4317-80fa-419913dc23fb"), "Sed magni est pariatur. Ea sequi nesciunt alias consequuntur dolores et expedita dolores tenetur.", new DateTime(2021, 3, 15, 14, 29, 6, 594, DateTimeKind.Utc).AddTicks(8689), 0 },
                    { new Guid("1c124055-a88e-4f75-b623-b013eac76331"), 292.443930158305000m, false, new Guid("39ef24e4-1de6-423d-b64d-c7057cd571cc"), "Repudiandae rerum amet voluptas tempore. Odio expedita est aut qui eius. Atque consequatur cumque voluptas quod eum recusandae. Magni voluptas voluptas id nesciunt incidunt nisi.", new DateTime(2014, 11, 8, 17, 33, 59, 246, DateTimeKind.Utc).AddTicks(2286), 99 },
                    { new Guid("1c3e4e72-4a3c-435c-bcdb-e44b07216e42"), 983.944071825388000m, false, new Guid("83f91037-a88d-4711-9911-ff86488bc237"), "In doloribus quia dicta quo et. Laboriosam iusto eos consequuntur quia omnis ut modi.", new DateTime(2020, 6, 6, 17, 6, 39, 366, DateTimeKind.Utc).AddTicks(7940), 99 },
                    { new Guid("1c4f5a89-21d6-4502-b70a-edd848d11e19"), 55.6685698229085000m, false, new Guid("83f91037-a88d-4711-9911-ff86488bc237"), "Dolorem repellendus eius fuga et iure eaque ut sunt omnis.", new DateTime(2021, 12, 27, 12, 28, 39, 140, DateTimeKind.Utc).AddTicks(6236), 1 },
                    { new Guid("1fa58569-71fb-4e9a-8a78-7563251c13f6"), 275.674660330491000m, false, new Guid("fdaf0699-a28e-403c-8775-54a475a1cf0a"), "Laborum et ut consequatur.", new DateTime(2016, 5, 29, 2, 45, 51, 591, DateTimeKind.Utc).AddTicks(6992), 0 },
                    { new Guid("202722ac-13a7-46a5-b142-ba846854d107"), 293.893354919699000m, false, new Guid("8c59bd75-b7f6-43d5-87c5-c44061095f9c"), "Alias aliquid similique ab laboriosam nemo tempore fugit voluptatem. Incidunt autem sed. Aliquam consectetur minima et. Odio a sunt modi.", new DateTime(2016, 12, 12, 18, 39, 46, 728, DateTimeKind.Utc).AddTicks(1844), 1 },
                    { new Guid("2205a804-d029-4ba9-9a5d-c4276e2433d0"), 39.7040727361657000m, false, new Guid("83f91037-a88d-4711-9911-ff86488bc237"), "Ducimus aut sequi vel ipsa aperiam sequi saepe rem deleniti. Iste qui provident ut voluptas veritatis consequatur. Sed vitae repudiandae doloremque quo veritatis commodi. In est modi.", new DateTime(2016, 1, 24, 1, 51, 21, 712, DateTimeKind.Utc).AddTicks(3301), 0 },
                    { new Guid("24c05442-7a5b-4e35-8128-c72a0363e2fb"), 418.256226767532000m, false, new Guid("5ec1fd6b-5237-4f3d-94c1-fc36c7744b1d"), "Asperiores iste omnis autem repellat non quibusdam eveniet. Nihil ea et praesentium dolor autem dicta cum. Et aut aut et. Quidem pariatur nam nulla distinctio autem maxime sapiente ut.", new DateTime(2014, 9, 11, 2, 36, 14, 303, DateTimeKind.Utc).AddTicks(4086), 1 },
                    { new Guid("251fa04d-bfd4-40b5-a938-0af181e8602d"), 618.955372431468000m, false, new Guid("3ee5aab2-ccc1-45d2-89c0-341336f72a9a"), "Aut est voluptas ipsa esse consequatur doloribus assumenda vel aut. Sed unde expedita blanditiis corporis eius. Delectus consequatur ex neque earum cupiditate ut sit quos.", new DateTime(2021, 12, 5, 4, 52, 21, 962, DateTimeKind.Utc).AddTicks(1514), 1 },
                    { new Guid("2a6842b7-a5ec-46a0-829a-fcd76172286d"), 744.22594289524000m, false, new Guid("c93cf7ba-5301-4a59-8238-b7a2e73b924f"), "Quo qui porro eius et nam error. Esse harum labore illo blanditiis qui dolores quisquam omnis.", new DateTime(2013, 9, 30, 7, 33, 12, 943, DateTimeKind.Utc).AddTicks(6993), 99 },
                    { new Guid("2ab39056-c8bb-4d63-9f02-7754dbbafe36"), 859.679259290034000m, false, new Guid("09f419d2-09d8-4182-ac95-695055e5e634"), "Et consequatur blanditiis beatae earum earum temporibus adipisci. Dolorum tenetur voluptas reiciendis quam.", new DateTime(2015, 7, 8, 4, 33, 44, 992, DateTimeKind.Utc).AddTicks(7028), 99 },
                    { new Guid("2b637225-d642-4aa5-ab2c-1074123c2b88"), 42.8300846375527000m, false, new Guid("ed8f84dd-7f9d-4317-80fa-419913dc23fb"), "Quos culpa voluptatem atque qui aspernatur provident rerum.", new DateTime(2017, 7, 19, 18, 19, 37, 796, DateTimeKind.Utc).AddTicks(2642), 99 },
                    { new Guid("3051cac0-0965-4ccf-a7c9-789f5bf5b24f"), 977.072821612152000m, false, new Guid("12d76e6f-a966-4235-8f43-991d88418b1f"), "Atque consequatur occaecati aut pariatur et qui tempore dicta. Modi omnis at repellendus expedita assumenda. Aut recusandae iusto neque sed et atque ut. Qui autem esse est voluptatem in omnis.", new DateTime(2019, 2, 11, 1, 56, 17, 233, DateTimeKind.Utc).AddTicks(1120), 1 },
                    { new Guid("318d82b9-62b2-4071-bad7-1198787986b1"), 478.59641986868000m, false, new Guid("fdaf0699-a28e-403c-8775-54a475a1cf0a"), "Nobis nam itaque recusandae qui animi suscipit molestias natus ex. Quia soluta rerum molestias. Autem facilis sit consequatur sint dolores impedit quam et dolores. Commodi voluptas dolor dolor recusandae ab provident.", new DateTime(2017, 2, 22, 2, 36, 9, 843, DateTimeKind.Utc).AddTicks(3079), 99 },
                    { new Guid("32e0d1de-8711-4be4-87b9-cb915e41194c"), 578.627364454417000m, false, new Guid("39ef24e4-1de6-423d-b64d-c7057cd571cc"), "Enim beatae natus recusandae est.", new DateTime(2021, 4, 23, 1, 58, 10, 574, DateTimeKind.Utc).AddTicks(8920), 0 },
                    { new Guid("33251f77-bcc9-46c4-b71e-a6f299fea6c6"), 863.865326794046000m, false, new Guid("793a0118-98ec-4b18-83ca-6d5f77fda5a0"), "Doloribus itaque error.", new DateTime(2014, 5, 31, 1, 24, 4, 696, DateTimeKind.Utc).AddTicks(9175), 0 },
                    { new Guid("339b8107-0e45-48c6-9005-2013e16f2edc"), 649.66363633491000m, false, new Guid("15358ab3-4b57-4e5e-877a-7e4762f018d4"), "Dolorem animi incidunt voluptatum provident culpa. Ut rerum quia. Repellendus dolores nisi iusto numquam et error dolor voluptas veritatis.", new DateTime(2017, 5, 16, 21, 20, 16, 876, DateTimeKind.Utc).AddTicks(2823), 0 },
                    { new Guid("359044fd-3289-4bd7-9c51-a5d6b68b4af8"), 304.344977254961000m, false, new Guid("5ec1fd6b-5237-4f3d-94c1-fc36c7744b1d"), "Molestiae ex labore expedita dolorum rerum exercitationem et.", new DateTime(2013, 3, 17, 3, 30, 33, 909, DateTimeKind.Utc).AddTicks(3737), 1 },
                    { new Guid("36657482-d18f-4061-ad45-98f2db5c1291"), 834.97948389981000m, false, new Guid("cbf11d4f-3fe4-4ec9-ba79-fc5ff2ee2f4b"), "Velit itaque pariatur excepturi eos ipsam nostrum. Adipisci eum id aliquid similique ad quia quia neque a.", new DateTime(2018, 10, 17, 11, 43, 36, 206, DateTimeKind.Utc).AddTicks(2957), 99 },
                    { new Guid("3853fa9d-63ed-44f6-9316-702068e0aa76"), 203.410511041871000m, false, new Guid("12d76e6f-a966-4235-8f43-991d88418b1f"), "Eligendi dolore et in aliquam fugit cum necessitatibus. Non est aut delectus sed. Voluptatem corporis tenetur praesentium qui at excepturi aut in. Est dolorem nobis esse ea.", new DateTime(2018, 4, 29, 23, 16, 27, 919, DateTimeKind.Utc).AddTicks(5082), 99 },
                    { new Guid("3bad7d47-d825-434b-babe-d4eead184edc"), 392.770817220411000m, false, new Guid("12d76e6f-a966-4235-8f43-991d88418b1f"), "Aliquam est dolor labore reprehenderit.", new DateTime(2012, 8, 26, 9, 34, 23, 352, DateTimeKind.Utc).AddTicks(8290), 0 },
                    { new Guid("3bcb0da2-c3f5-4e62-a813-c7fcfea26258"), 627.577133400655000m, false, new Guid("5ec1fd6b-5237-4f3d-94c1-fc36c7744b1d"), "Rem placeat magnam debitis soluta eos deserunt. Voluptatibus illum minus odit quod sed minus qui quas omnis. Reprehenderit eveniet vel deserunt perspiciatis non inventore eum rerum ea.", new DateTime(2013, 11, 24, 18, 20, 37, 269, DateTimeKind.Utc).AddTicks(6336), 0 },
                    { new Guid("3c171bca-9fcf-47cd-8458-c17d5867d71a"), 807.276782262486000m, false, new Guid("09f419d2-09d8-4182-ac95-695055e5e634"), "Eos et cupiditate dolores dignissimos. In porro qui ipsam aspernatur culpa hic voluptatem assumenda eum. Aut neque voluptatem suscipit.", new DateTime(2014, 7, 5, 6, 34, 44, 244, DateTimeKind.Utc).AddTicks(2961), 0 },
                    { new Guid("40931248-d543-415a-abce-aee226333402"), 881.599918649108000m, false, new Guid("1f75aa88-935c-4eb2-9891-d39332949ed6"), "Voluptates illo accusantium. Molestiae suscipit asperiores aut mollitia dignissimos ab possimus odio. Quidem quia provident at cupiditate quisquam. Esse animi ipsum vitae maxime et sit sed aut.", new DateTime(2020, 6, 2, 14, 40, 26, 430, DateTimeKind.Utc).AddTicks(4803), 0 },
                    { new Guid("42731554-f9e5-4d8a-a6ee-8a28123b4103"), 17.302794984778000m, false, new Guid("fdaf0699-a28e-403c-8775-54a475a1cf0a"), "Autem consectetur iure ratione non doloremque. Incidunt cumque et.", new DateTime(2021, 2, 28, 15, 9, 13, 952, DateTimeKind.Utc).AddTicks(6334), 0 },
                    { new Guid("43eb916f-f448-4826-864f-1dad495ce04a"), 363.945469317851000m, false, new Guid("39ef24e4-1de6-423d-b64d-c7057cd571cc"), "At doloribus adipisci placeat ut voluptatibus omnis.", new DateTime(2014, 8, 29, 10, 39, 14, 678, DateTimeKind.Utc).AddTicks(3179), 99 },
                    { new Guid("470de421-62b1-4e3d-b398-d1ac7aa4bdd5"), 910.140036793451000m, false, new Guid("7e3ec143-3e22-48ca-8dd5-4fb8965cbebe"), "Cupiditate labore incidunt. Reiciendis nesciunt qui qui nihil voluptas. Error perspiciatis praesentium adipisci exercitationem optio ipsam expedita cum. Quidem odit et est aut.", new DateTime(2015, 3, 12, 20, 13, 16, 301, DateTimeKind.Utc).AddTicks(366), 1 },
                    { new Guid("47cfd85c-6236-46dc-b93c-bfa6692ca192"), 505.793588324296000m, false, new Guid("09f419d2-09d8-4182-ac95-695055e5e634"), "Alias non harum cupiditate ut. Iure reiciendis necessitatibus quia dignissimos et necessitatibus.", new DateTime(2021, 7, 20, 23, 43, 25, 635, DateTimeKind.Utc).AddTicks(8712), 99 },
                    { new Guid("47e7a786-995c-43c9-8289-548f11cb83f5"), 742.289227413526000m, false, new Guid("b2724ea1-4cce-450f-8bab-67988a9f865e"), "Quibusdam magni architecto odio harum qui quisquam voluptas a blanditiis. Quam dolores eveniet qui laboriosam ex voluptatem voluptas explicabo. Provident velit perspiciatis rerum facilis rerum quaerat temporibus distinctio occaecati. Porro fuga assumenda id.", new DateTime(2019, 12, 14, 2, 4, 32, 243, DateTimeKind.Utc).AddTicks(1234), 99 },
                    { new Guid("49b2619a-cb19-4986-b3e6-59dcdb9ee2ea"), 378.854434175702000m, false, new Guid("39ef24e4-1de6-423d-b64d-c7057cd571cc"), "Saepe voluptatem molestias omnis sed repudiandae reiciendis. Libero qui commodi dignissimos reiciendis neque aliquid quibusdam in. Saepe est rerum expedita voluptatum quas. Est qui deleniti placeat molestiae reprehenderit.", new DateTime(2018, 4, 19, 18, 42, 0, 148, DateTimeKind.Utc).AddTicks(2071), 0 },
                    { new Guid("4b60246d-db43-4595-99e4-14ef321ab3b9"), 382.509100050139000m, false, new Guid("7e3ec143-3e22-48ca-8dd5-4fb8965cbebe"), "Nihil sit ratione. Ut dignissimos consequatur quos dolorum rem qui.", new DateTime(2013, 5, 19, 23, 10, 58, 724, DateTimeKind.Utc).AddTicks(7231), 0 },
                    { new Guid("4b97f928-0dda-4bf8-ac26-46ac312edc20"), 524.564125150884000m, false, new Guid("12d76e6f-a966-4235-8f43-991d88418b1f"), "Omnis quam aliquam. Minus deleniti rerum quaerat fugiat veritatis eos. Quo error ut ut quia non ut. Unde minima eius nulla quis unde.", new DateTime(2020, 3, 5, 16, 25, 16, 308, DateTimeKind.Utc).AddTicks(4941), 0 },
                    { new Guid("4c7b3a13-026a-4fa1-8573-d2645382d4a4"), 764.31470810144000m, false, new Guid("c93cf7ba-5301-4a59-8238-b7a2e73b924f"), "At laborum excepturi. Molestias dolores rem a ab recusandae omnis nisi odio. Est possimus illum beatae autem voluptatem animi. Consequatur in consequuntur veniam.", new DateTime(2017, 11, 20, 16, 56, 39, 624, DateTimeKind.Utc).AddTicks(2040), 99 },
                    { new Guid("4d5c59fa-9631-4fda-b0e0-f5eceaba43af"), 980.752646205105000m, false, new Guid("4385ff43-6e8d-444f-a265-cf8d478744f6"), "Sunt totam odio quaerat. Omnis quibusdam illo autem iure sint eveniet. Temporibus delectus magnam qui ducimus.", new DateTime(2014, 10, 18, 3, 46, 43, 84, DateTimeKind.Utc).AddTicks(6542), 1 },
                    { new Guid("4f43e387-69d2-4835-8429-43fb82055f59"), 569.438713214252000m, false, new Guid("15358ab3-4b57-4e5e-877a-7e4762f018d4"), "At dolores aspernatur reiciendis enim autem sed molestias vel laboriosam. Fugit illum quaerat debitis veniam. Dolores vitae enim odit nemo itaque dolore vel voluptatibus sit. Mollitia expedita assumenda.", new DateTime(2017, 3, 19, 8, 6, 49, 226, DateTimeKind.Utc).AddTicks(3041), 0 },
                    { new Guid("51461674-ac67-41ef-82db-0a14671388c9"), 101.045441592939000m, false, new Guid("09f419d2-09d8-4182-ac95-695055e5e634"), "Doloremque voluptates sed iste. Consequatur sint qui suscipit iste sunt aliquid distinctio. Autem voluptas omnis doloribus quia et accusantium et.", new DateTime(2020, 4, 3, 21, 45, 50, 267, DateTimeKind.Utc).AddTicks(3222), 1 },
                    { new Guid("51928f8c-ebf5-48c7-a1cc-a410fba46736"), 436.131888966955000m, false, new Guid("83f91037-a88d-4711-9911-ff86488bc237"), "Ut debitis nemo. Cupiditate vitae maxime. In optio praesentium doloribus laudantium ea.", new DateTime(2018, 3, 16, 0, 36, 27, 818, DateTimeKind.Utc).AddTicks(380), 99 },
                    { new Guid("51dd17ed-ea5d-4c07-9ad7-b0c220c7daef"), 963.608437024897000m, false, new Guid("c93cf7ba-5301-4a59-8238-b7a2e73b924f"), "Deserunt facere libero ex totam et error molestiae aliquid. Eveniet tenetur quibusdam voluptatem error nihil velit. Aut autem provident fugit quo distinctio facilis.", new DateTime(2012, 6, 10, 17, 14, 34, 655, DateTimeKind.Utc).AddTicks(4455), 1 },
                    { new Guid("532cd956-17b1-485a-9904-8c82301c1e1d"), 171.647429696366000m, false, new Guid("83f91037-a88d-4711-9911-ff86488bc237"), "Et suscipit saepe iure.", new DateTime(2020, 9, 15, 7, 55, 18, 266, DateTimeKind.Utc).AddTicks(6502), 99 },
                    { new Guid("53b8f180-b915-490f-b9f3-0fc6a040eb2b"), 380.468125985094000m, false, new Guid("39ef24e4-1de6-423d-b64d-c7057cd571cc"), "Necessitatibus id earum assumenda iure.", new DateTime(2018, 9, 3, 3, 55, 5, 852, DateTimeKind.Utc).AddTicks(7220), 1 },
                    { new Guid("56c78a49-44d1-4935-96fc-1be7075b4f9e"), 392.481217791673000m, false, new Guid("1f75aa88-935c-4eb2-9891-d39332949ed6"), "Voluptatem ipsa sit nam qui debitis. Odio aliquam numquam error ea nulla quis culpa.", new DateTime(2019, 7, 14, 6, 50, 18, 464, DateTimeKind.Utc).AddTicks(5948), 1 },
                    { new Guid("59b3d8db-6982-4eb8-ae8b-0d8a505d2aef"), 911.199865463867000m, false, new Guid("abe7de98-bd86-4c20-9918-d0e3d8867123"), "Impedit perspiciatis vel ipsum. Ut aliquam iusto.", new DateTime(2012, 5, 19, 13, 13, 40, 989, DateTimeKind.Utc).AddTicks(9476), 99 },
                    { new Guid("5d4a9d83-4c4d-4c92-8046-c3f767787674"), 452.628093350438000m, false, new Guid("3ee5aab2-ccc1-45d2-89c0-341336f72a9a"), "Quia sed repudiandae pariatur quia et dolores sunt voluptatibus nihil. Est cum veritatis cum. Doloremque voluptas aliquam esse ut vero.", new DateTime(2019, 5, 12, 2, 51, 25, 677, DateTimeKind.Utc).AddTicks(925), 0 },
                    { new Guid("5dea34ba-a344-4f62-a409-89eb57f699ed"), 532.217648991226000m, false, new Guid("48fd525f-4966-41e8-968d-3f7149e389ae"), "Tempore ea ipsa assumenda aliquam aut animi est voluptate consequatur.", new DateTime(2012, 8, 30, 22, 0, 29, 583, DateTimeKind.Utc).AddTicks(3061), 0 },
                    { new Guid("5e878e13-5fb5-4973-b5fb-ab1d6da6c8ae"), 910.433284700239000m, false, new Guid("b2724ea1-4cce-450f-8bab-67988a9f865e"), "Provident quidem blanditiis voluptas quia id cum ut et. Labore cupiditate quaerat. Minima sit non beatae temporibus.", new DateTime(2018, 9, 20, 13, 53, 1, 47, DateTimeKind.Utc).AddTicks(1332), 1 },
                    { new Guid("61a18276-c477-4784-b701-d14c73d86504"), 320.418170372947000m, false, new Guid("b2724ea1-4cce-450f-8bab-67988a9f865e"), "Perspiciatis nisi voluptatem molestiae optio est laudantium sed a.", new DateTime(2012, 12, 29, 17, 8, 14, 668, DateTimeKind.Utc).AddTicks(9687), 0 },
                    { new Guid("63f9a087-993b-47f7-bda9-2e6f41a560c3"), 333.019670271946000m, false, new Guid("ed8f84dd-7f9d-4317-80fa-419913dc23fb"), "Repellendus voluptates eius.", new DateTime(2015, 12, 27, 7, 44, 8, 700, DateTimeKind.Utc).AddTicks(855), 0 },
                    { new Guid("643bd985-a7aa-4b85-a35d-090cd46a08c0"), 712.830277382744000m, false, new Guid("5ec1fd6b-5237-4f3d-94c1-fc36c7744b1d"), "Est praesentium culpa iste et quidem in itaque. Voluptatum omnis eaque nulla omnis vel.", new DateTime(2019, 9, 7, 10, 56, 26, 447, DateTimeKind.Utc).AddTicks(6099), 1 },
                    { new Guid("661df8fe-fff1-49a5-975c-aafc7d1a3e9d"), 663.193391681295000m, false, new Guid("b2724ea1-4cce-450f-8bab-67988a9f865e"), "Qui natus ut maxime reprehenderit ex modi quia laboriosam. Alias in hic et iusto aliquam eaque officia enim. Nihil ipsum eligendi. Dicta nesciunt voluptas autem maiores odit.", new DateTime(2021, 7, 20, 14, 40, 32, 750, DateTimeKind.Utc).AddTicks(1929), 0 },
                    { new Guid("6708debc-3484-4ccf-b21e-f9c06266821e"), 302.140923211181000m, false, new Guid("cbf11d4f-3fe4-4ec9-ba79-fc5ff2ee2f4b"), "Incidunt et dolor delectus accusamus. Id laboriosam ea recusandae dolorem magnam. Voluptas possimus laborum. Repellat culpa eveniet ut enim sed.", new DateTime(2012, 2, 29, 16, 43, 6, 353, DateTimeKind.Utc).AddTicks(1264), 1 },
                    { new Guid("68e72703-7d91-4a2c-bd04-bb317f31a846"), 625.645145144422000m, false, new Guid("39ef24e4-1de6-423d-b64d-c7057cd571cc"), "Laborum ab consequatur adipisci dignissimos at.", new DateTime(2019, 4, 1, 4, 19, 26, 215, DateTimeKind.Utc).AddTicks(4732), 1 },
                    { new Guid("6c897f63-ffb2-4872-b57c-9da8f2d5ebe7"), 31.6758183461558000m, false, new Guid("cbf11d4f-3fe4-4ec9-ba79-fc5ff2ee2f4b"), "Qui similique eos quod nihil eos esse. Dolorem minima voluptatem eaque facere. Eveniet minus iusto perspiciatis et sed ipsa.", new DateTime(2013, 6, 24, 8, 43, 1, 490, DateTimeKind.Utc).AddTicks(9413), 99 },
                    { new Guid("6e217da1-df4a-4489-a7cc-03d60b49492c"), 160.258932743355000m, false, new Guid("8c59bd75-b7f6-43d5-87c5-c44061095f9c"), "Quos consequatur et maiores necessitatibus consectetur et sapiente distinctio non. Voluptas et rerum atque nihil repudiandae animi. Earum minus neque ut perferendis doloremque corporis ducimus. Est officia ipsa.", new DateTime(2013, 6, 19, 7, 38, 2, 374, DateTimeKind.Utc).AddTicks(6202), 1 },
                    { new Guid("715ee34d-0b0b-4a67-849f-eac77a5317ff"), 341.62061870738000m, false, new Guid("cbf11d4f-3fe4-4ec9-ba79-fc5ff2ee2f4b"), "Laudantium rerum qui rem debitis id facere. Reiciendis ea veritatis et quos enim cum et.", new DateTime(2013, 8, 7, 18, 9, 57, 590, DateTimeKind.Utc).AddTicks(8824), 0 },
                    { new Guid("71cc0d69-a010-44f5-89ab-fb18a641c28c"), 544.565545637386000m, false, new Guid("12d76e6f-a966-4235-8f43-991d88418b1f"), "Fugit eos exercitationem voluptatem. Fuga animi blanditiis corporis ea voluptate alias quia pariatur.", new DateTime(2012, 8, 27, 1, 57, 23, 946, DateTimeKind.Utc).AddTicks(8301), 0 },
                    { new Guid("74835d25-3078-4b0e-8bb6-8451cce5c17d"), 41.570279168368000m, false, new Guid("15358ab3-4b57-4e5e-877a-7e4762f018d4"), "Consequuntur natus provident est nisi dolor aperiam nulla est blanditiis.", new DateTime(2013, 12, 11, 14, 27, 26, 920, DateTimeKind.Utc).AddTicks(2512), 0 },
                    { new Guid("752c1939-f26a-4345-bf00-c7f30500e3ca"), 374.919538067373000m, false, new Guid("8c59bd75-b7f6-43d5-87c5-c44061095f9c"), "Velit dolorem in magnam totam nobis.", new DateTime(2014, 7, 29, 8, 37, 44, 454, DateTimeKind.Utc).AddTicks(1541), 0 },
                    { new Guid("75ae3b21-0825-4c49-93e7-ae88c5def32e"), 785.622435358437000m, false, new Guid("4385ff43-6e8d-444f-a265-cf8d478744f6"), "Aperiam aperiam numquam nostrum. Omnis eum facere exercitationem voluptatem in rem labore voluptas. Rerum asperiores veniam libero ratione rerum quo earum voluptas.", new DateTime(2018, 3, 22, 10, 39, 0, 630, DateTimeKind.Utc).AddTicks(2162), 99 },
                    { new Guid("760f59cf-a786-4e35-b703-f0042135cfb7"), 744.930883254588000m, false, new Guid("f6cde8a2-e554-41d3-ae69-9589170b99c9"), "Consequatur neque sit iste esse facere in. Delectus voluptatem sit molestiae quia vitae molestiae et maiores. Eum quod ad est amet.", new DateTime(2013, 6, 13, 5, 32, 0, 8, DateTimeKind.Utc).AddTicks(282), 99 },
                    { new Guid("77d71fb0-0715-4662-b47c-9a66c19f2c33"), 495.871943306762000m, false, new Guid("5ec1fd6b-5237-4f3d-94c1-fc36c7744b1d"), "Excepturi et eligendi in sapiente odio asperiores animi. Tempore beatae magnam perspiciatis aut. Nemo non atque voluptatem quaerat laudantium accusantium magnam.", new DateTime(2021, 3, 23, 2, 46, 39, 90, DateTimeKind.Utc).AddTicks(6093), 0 },
                    { new Guid("7afaf2e6-7710-433e-b3ba-bb3a208cd71c"), 116.368959040927000m, false, new Guid("7e3ec143-3e22-48ca-8dd5-4fb8965cbebe"), "Explicabo asperiores excepturi delectus ut. Sapiente et repellat et non et consequatur.", new DateTime(2021, 1, 27, 13, 18, 39, 209, DateTimeKind.Utc).AddTicks(4495), 99 },
                    { new Guid("7f393d96-4273-482d-80ad-fbb0d0bd9994"), 594.412452501825000m, false, new Guid("c93cf7ba-5301-4a59-8238-b7a2e73b924f"), "Ratione cupiditate sequi qui.", new DateTime(2017, 9, 25, 11, 42, 51, 129, DateTimeKind.Utc).AddTicks(4818), 99 },
                    { new Guid("7f6b8251-39db-4c8f-9d9b-e4935871b197"), 569.982939387026000m, false, new Guid("12d76e6f-a966-4235-8f43-991d88418b1f"), "Qui deleniti velit quam qui aut fugit maiores quae quia. Voluptatibus dolorem est. Quidem quo atque quod. Qui et praesentium laborum aut sed.", new DateTime(2021, 12, 16, 3, 53, 1, 691, DateTimeKind.Utc).AddTicks(4414), 99 },
                    { new Guid("7f8eda52-6fed-43b8-be96-bc68db7be00f"), 740.189580158799000m, false, new Guid("7e3ec143-3e22-48ca-8dd5-4fb8965cbebe"), "Quis dolorem sed non aut corporis voluptatem.", new DateTime(2013, 8, 23, 6, 32, 18, 305, DateTimeKind.Utc).AddTicks(2672), 1 },
                    { new Guid("82339eb8-107b-4931-8b4e-3bb47754dd49"), 56.0159674186042000m, false, new Guid("c93cf7ba-5301-4a59-8238-b7a2e73b924f"), "Magni qui id voluptas. Molestias aut fuga et et consequatur et optio necessitatibus ad.", new DateTime(2012, 8, 19, 12, 56, 44, 700, DateTimeKind.Utc).AddTicks(2172), 0 },
                    { new Guid("82803c5c-e9f2-49c9-bc9f-e5d574b2f729"), 799.005192865994000m, false, new Guid("f6cde8a2-e554-41d3-ae69-9589170b99c9"), "Rem quaerat harum est. Sit ab in earum qui est. Perspiciatis facere non consequuntur voluptatem porro eos corrupti.", new DateTime(2021, 8, 25, 3, 39, 53, 697, DateTimeKind.Utc).AddTicks(5166), 1 },
                    { new Guid("83a06d9b-729e-4012-a54e-d767bbadd080"), 48.5575010043712000m, false, new Guid("ed8f84dd-7f9d-4317-80fa-419913dc23fb"), "Magni velit qui explicabo doloremque eligendi fugiat.", new DateTime(2021, 11, 8, 2, 43, 50, 754, DateTimeKind.Utc).AddTicks(1855), 1 },
                    { new Guid("882842a6-4656-4311-9a98-d9d55efdf6cc"), 379.44999507144000m, false, new Guid("7e3ec143-3e22-48ca-8dd5-4fb8965cbebe"), "Architecto corrupti aut fugiat non nam est ex ab vel. Odio eveniet necessitatibus at. Eos ut assumenda quibusdam.", new DateTime(2020, 3, 7, 19, 8, 25, 477, DateTimeKind.Utc).AddTicks(5777), 0 },
                    { new Guid("884b81dc-2027-4fdc-94a3-1e4c7efd02ec"), 544.751296505939000m, false, new Guid("793a0118-98ec-4b18-83ca-6d5f77fda5a0"), "Ea vel quis et quia at impedit sunt nostrum non. Error odio labore quidem voluptatum repellat ut quasi necessitatibus. Tempora voluptas numquam consequatur unde voluptas. Aut unde cupiditate esse commodi repellendus iure ullam similique.", new DateTime(2016, 10, 28, 1, 51, 13, 571, DateTimeKind.Utc).AddTicks(3804), 0 },
                    { new Guid("8902a6be-f343-4f3c-ad36-0ad9c1033aee"), 820.393377647853000m, false, new Guid("48fd525f-4966-41e8-968d-3f7149e389ae"), "Adipisci quas consequatur nam id autem. Id quasi sunt quas eligendi harum. Dolorum similique voluptatum voluptatum in quos ipsum mollitia eius.", new DateTime(2021, 11, 14, 14, 49, 30, 31, DateTimeKind.Utc).AddTicks(9305), 0 },
                    { new Guid("8a1775e1-b39c-4ed3-b320-4fc8994fee59"), 415.236918359222000m, false, new Guid("f6cde8a2-e554-41d3-ae69-9589170b99c9"), "Voluptates saepe quae nam hic et a. Vitae occaecati error dolores.", new DateTime(2012, 6, 19, 15, 21, 34, 0, DateTimeKind.Utc).AddTicks(4740), 99 },
                    { new Guid("8b4527b2-754e-4c0c-8ee1-0f552dc6951f"), 711.144720000516000m, false, new Guid("ed8f84dd-7f9d-4317-80fa-419913dc23fb"), "Accusantium maiores dolorum voluptatibus eaque vel id atque. Ex est unde quaerat numquam. Culpa quia sed ut perspiciatis assumenda necessitatibus.", new DateTime(2013, 10, 19, 23, 47, 19, 148, DateTimeKind.Utc).AddTicks(7193), 99 },
                    { new Guid("8c248459-8cd6-4110-9d85-f3b0fcfd7a75"), 109.365053031084000m, false, new Guid("39ef24e4-1de6-423d-b64d-c7057cd571cc"), "Voluptas et assumenda recusandae omnis necessitatibus et sunt. Distinctio fugiat laudantium. Occaecati iusto atque et minus non voluptate.", new DateTime(2012, 7, 21, 12, 41, 36, 296, DateTimeKind.Utc).AddTicks(7572), 99 },
                    { new Guid("8d57e277-03fe-44fe-a856-15526821b9eb"), 930.538557104964000m, false, new Guid("3ee5aab2-ccc1-45d2-89c0-341336f72a9a"), "Dolorum ipsam nam quos ducimus voluptatum nemo. Repudiandae eos quasi. Harum facere sunt dolor quidem.", new DateTime(2019, 7, 2, 3, 9, 24, 813, DateTimeKind.Utc).AddTicks(7814), 1 },
                    { new Guid("8ed9d1c4-432b-45ce-a7c5-b20478509ca6"), 810.994073639345000m, false, new Guid("3ee5aab2-ccc1-45d2-89c0-341336f72a9a"), "Quis minima dolores. Voluptatem non cupiditate. Harum sit natus suscipit rerum. Et officiis laboriosam.", new DateTime(2012, 12, 7, 9, 20, 27, 710, DateTimeKind.Utc).AddTicks(3820), 99 },
                    { new Guid("91782f48-8ffb-418b-a807-43de1c1a9d34"), 934.730614327646000m, false, new Guid("5ec1fd6b-5237-4f3d-94c1-fc36c7744b1d"), "Quod aut voluptas est. Ut iusto facere. Tempora magni voluptas dolor qui sint at aperiam. Architecto eos sed.", new DateTime(2018, 4, 12, 0, 50, 45, 724, DateTimeKind.Utc).AddTicks(4415), 0 },
                    { new Guid("9372e73a-14c7-4d3b-8f29-623c797402ed"), 95.7347933972326000m, false, new Guid("15358ab3-4b57-4e5e-877a-7e4762f018d4"), "Velit nihil atque amet et voluptas itaque facilis sed voluptatem. Doloribus molestiae quaerat voluptate eos rerum saepe.", new DateTime(2020, 9, 26, 8, 27, 44, 633, DateTimeKind.Utc).AddTicks(917), 99 },
                    { new Guid("937bd1b3-a19a-4538-89a9-e0dc577bc60a"), 224.404788471023000m, false, new Guid("793a0118-98ec-4b18-83ca-6d5f77fda5a0"), "Fugit architecto rem velit incidunt beatae. Autem sit laborum animi debitis provident. Aspernatur excepturi explicabo porro doloribus repudiandae. Quia quibusdam sint unde recusandae distinctio suscipit dolor ipsam.", new DateTime(2018, 5, 14, 1, 58, 17, 647, DateTimeKind.Utc).AddTicks(2316), 99 },
                    { new Guid("9651da68-20ca-4817-9046-653e62bb577c"), 923.240708721893000m, false, new Guid("fdaf0699-a28e-403c-8775-54a475a1cf0a"), "Voluptate odio temporibus totam et ut ab. Ab perferendis accusamus est ipsa velit dolorem.", new DateTime(2021, 11, 30, 17, 12, 56, 50, DateTimeKind.Utc).AddTicks(2810), 99 },
                    { new Guid("96f3057a-eaef-44cf-ab41-dcb1762d8a00"), 803.334828922538000m, false, new Guid("15358ab3-4b57-4e5e-877a-7e4762f018d4"), "Nulla excepturi voluptates facilis modi ipsam. Quod officia consequatur nobis voluptatibus numquam vel.", new DateTime(2012, 2, 29, 0, 15, 35, 151, DateTimeKind.Utc).AddTicks(8891), 0 },
                    { new Guid("9704caa0-67d2-4d39-bc78-c374d452c9b4"), 391.049784735402000m, false, new Guid("f6cde8a2-e554-41d3-ae69-9589170b99c9"), "Consequuntur amet cupiditate in non quibusdam. Dolorem quidem cumque. In occaecati et fugiat repellendus aut.", new DateTime(2013, 7, 4, 14, 44, 6, 956, DateTimeKind.Utc).AddTicks(6401), 0 },
                    { new Guid("971e4800-ee2d-4412-96bc-79859a43e5ae"), 234.805834658014000m, false, new Guid("1f75aa88-935c-4eb2-9891-d39332949ed6"), "Natus amet maxime aperiam ab. Asperiores tempora sit accusamus ad laborum soluta cupiditate. Quae praesentium expedita at.", new DateTime(2019, 6, 22, 2, 5, 44, 879, DateTimeKind.Utc).AddTicks(6279), 0 },
                    { new Guid("97c700dd-1c66-4efb-b97d-ca54e1bf162b"), 886.582528563196000m, false, new Guid("cbf11d4f-3fe4-4ec9-ba79-fc5ff2ee2f4b"), "Consequatur corrupti quisquam est nihil.", new DateTime(2021, 9, 16, 21, 9, 45, 898, DateTimeKind.Utc).AddTicks(1608), 1 },
                    { new Guid("98e40511-f236-4381-b3cd-f633a22f14bc"), 942.895343609696000m, false, new Guid("1f75aa88-935c-4eb2-9891-d39332949ed6"), "Eius deleniti fugiat et soluta quia nihil sequi. Similique modi minima qui et dolorem maiores vel. Et non itaque itaque nisi corrupti facilis animi. Quia voluptas harum.", new DateTime(2018, 4, 10, 11, 54, 19, 118, DateTimeKind.Utc).AddTicks(9491), 1 },
                    { new Guid("997bca01-27fa-4f1e-9330-aec07ef9343c"), 937.657830519209000m, false, new Guid("7e3ec143-3e22-48ca-8dd5-4fb8965cbebe"), "Nulla sint maiores dignissimos esse et modi optio impedit. Ipsum sed quidem voluptatum.", new DateTime(2020, 12, 1, 17, 37, 2, 900, DateTimeKind.Utc).AddTicks(7026), 1 },
                    { new Guid("9a84af47-1f42-41da-9153-f1fb1520d9d5"), 626.457143885609000m, false, new Guid("5ec1fd6b-5237-4f3d-94c1-fc36c7744b1d"), "Consequuntur totam consequatur esse numquam impedit iure odit quasi ut. Adipisci ut illo consequatur doloremque ad ut iusto. Hic non perferendis est magni. Recusandae error illum alias aspernatur voluptatibus provident laboriosam.", new DateTime(2015, 11, 27, 19, 54, 14, 885, DateTimeKind.Utc).AddTicks(8517), 99 },
                    { new Guid("9b1e0220-90c2-4fe0-a49f-a602e2549c66"), 140.345968931287000m, false, new Guid("48fd525f-4966-41e8-968d-3f7149e389ae"), "Eos rerum enim est commodi qui voluptatem nulla dolor praesentium. Repellendus et occaecati et ab ducimus eius sequi unde dolore. Quo ut dolorem repudiandae delectus et laborum. Quidem commodi asperiores.", new DateTime(2018, 7, 19, 3, 41, 37, 42, DateTimeKind.Utc).AddTicks(8608), 99 },
                    { new Guid("9d82a471-e617-44a6-89c0-ffcf7fba828f"), 883.393450631244000m, false, new Guid("3ee5aab2-ccc1-45d2-89c0-341336f72a9a"), "Unde vel pariatur neque optio quod iusto et. Sint officia fuga.", new DateTime(2021, 6, 22, 11, 21, 56, 500, DateTimeKind.Utc).AddTicks(9570), 0 },
                    { new Guid("a0b03845-1280-4709-800e-c82a338278c4"), 820.887306290636000m, false, new Guid("abe7de98-bd86-4c20-9918-d0e3d8867123"), "Officia vel blanditiis quasi ex. Voluptatem occaecati consequuntur est voluptas id sit omnis ut. Accusantium ut quis dolor fugit a commodi quaerat accusantium. Voluptates ea omnis.", new DateTime(2017, 9, 8, 10, 44, 33, 254, DateTimeKind.Utc).AddTicks(9114), 1 },
                    { new Guid("a12872f8-26ba-4db2-9a00-0318600d1dde"), 577.501625559136000m, false, new Guid("abe7de98-bd86-4c20-9918-d0e3d8867123"), "Velit minus magni reiciendis voluptatibus sed. Et dolore in officia ipsum eius. Quis facilis dolore ut blanditiis ratione maxime quis consequatur reprehenderit.", new DateTime(2019, 2, 24, 10, 22, 18, 736, DateTimeKind.Utc).AddTicks(7017), 1 },
                    { new Guid("a415f689-782e-4ca1-99c8-e6857f698a00"), 870.478304596259000m, false, new Guid("cbf11d4f-3fe4-4ec9-ba79-fc5ff2ee2f4b"), "Rerum quos libero quisquam. Sint laborum delectus est et ad quaerat qui. Laudantium iure tenetur similique sit et est ipsa quo.", new DateTime(2015, 5, 31, 19, 13, 56, 781, DateTimeKind.Utc).AddTicks(2416), 1 },
                    { new Guid("a6189e23-bd69-4d27-925b-d4c5487a4986"), 695.856293366844000m, false, new Guid("8c59bd75-b7f6-43d5-87c5-c44061095f9c"), "Earum voluptatem accusantium. Hic dignissimos exercitationem fugiat temporibus rerum odit ut ratione.", new DateTime(2014, 6, 25, 1, 16, 15, 752, DateTimeKind.Utc).AddTicks(206), 1 },
                    { new Guid("a6329bd9-6225-47f3-ae8d-60493ac2ccd6"), 480.71459145939000m, false, new Guid("83f91037-a88d-4711-9911-ff86488bc237"), "Fugiat blanditiis eos quo velit aliquam debitis magnam. Fuga quo quasi modi.", new DateTime(2020, 6, 15, 1, 21, 35, 993, DateTimeKind.Utc).AddTicks(7499), 99 },
                    { new Guid("a6c730a2-434c-4175-bf1d-dcc3350d639c"), 662.414493177188000m, false, new Guid("f6cde8a2-e554-41d3-ae69-9589170b99c9"), "Veniam nihil qui. Tenetur eos in et sequi dolor non vel cum consectetur. Et asperiores quam ipsa. Quo molestias incidunt est.", new DateTime(2019, 5, 1, 0, 43, 7, 3, DateTimeKind.Utc).AddTicks(8289), 99 },
                    { new Guid("a79d6561-9667-4414-b228-6d03d64d75e0"), 940.520786059744000m, false, new Guid("ed8f84dd-7f9d-4317-80fa-419913dc23fb"), "Ipsa eos harum et libero iure nam fugiat ipsa. Soluta officiis rerum est dolores velit.", new DateTime(2017, 8, 8, 9, 48, 45, 268, DateTimeKind.Utc).AddTicks(9547), 0 },
                    { new Guid("aa67f672-c529-4d0d-87ed-3d7186575a40"), 759.645711773828000m, false, new Guid("48fd525f-4966-41e8-968d-3f7149e389ae"), "Esse maxime repellat consequatur quis ullam. Inventore illo vero sequi eaque non voluptas.", new DateTime(2012, 9, 21, 2, 25, 24, 262, DateTimeKind.Utc).AddTicks(2536), 0 },
                    { new Guid("ae94083b-c363-4fbf-9a28-436e0f28841a"), 288.374486161506000m, false, new Guid("793a0118-98ec-4b18-83ca-6d5f77fda5a0"), "Dolore maxime ut tempore et dolorum numquam aspernatur. Similique nostrum sit eveniet cumque asperiores cum blanditiis dolor. Esse magnam voluptatibus laudantium dolorem.", new DateTime(2016, 2, 19, 13, 31, 52, 41, DateTimeKind.Utc).AddTicks(6264), 0 },
                    { new Guid("aebbf9d4-5488-4191-aabb-9b502999068b"), 247.455633681758000m, false, new Guid("8c59bd75-b7f6-43d5-87c5-c44061095f9c"), "Amet ipsum ipsa magnam possimus.", new DateTime(2014, 12, 23, 14, 46, 1, 325, DateTimeKind.Utc).AddTicks(4359), 1 },
                    { new Guid("af806915-2c41-45d3-bff6-9bc4caf68a46"), 85.9500780988002000m, false, new Guid("5ec1fd6b-5237-4f3d-94c1-fc36c7744b1d"), "Nihil rerum et aliquam asperiores eaque sequi.", new DateTime(2020, 10, 22, 14, 24, 21, 672, DateTimeKind.Utc).AddTicks(2160), 99 },
                    { new Guid("b124ed35-1ff2-4dec-973c-a6eeff4bd778"), 518.302594378287000m, false, new Guid("4385ff43-6e8d-444f-a265-cf8d478744f6"), "Blanditiis magni dolore molestiae accusantium eligendi. Laborum voluptas vel.", new DateTime(2020, 6, 18, 5, 32, 8, 616, DateTimeKind.Utc).AddTicks(7412), 0 },
                    { new Guid("b1c0b243-ebd1-40da-a1e6-7e7c07a3222c"), 991.421937547208000m, false, new Guid("fdaf0699-a28e-403c-8775-54a475a1cf0a"), "Qui atque aperiam debitis incidunt sequi nihil voluptatem recusandae qui. Sint ut esse quia placeat.", new DateTime(2018, 4, 17, 5, 35, 14, 611, DateTimeKind.Utc).AddTicks(7577), 0 },
                    { new Guid("b1d826f8-df36-45b7-b77b-778a42fa07ee"), 270.370198342188000m, false, new Guid("3ee5aab2-ccc1-45d2-89c0-341336f72a9a"), "Debitis eos totam. Magnam ratione sit cupiditate.", new DateTime(2012, 7, 11, 21, 14, 33, 542, DateTimeKind.Utc).AddTicks(1898), 99 },
                    { new Guid("b335be96-b66a-4ad9-b7d7-34b483723907"), 509.86016030558000m, false, new Guid("12d76e6f-a966-4235-8f43-991d88418b1f"), "Adipisci saepe reiciendis est praesentium deleniti non id est. Ducimus nisi tempore occaecati iste eveniet. Ut voluptatem ut ea blanditiis voluptas nulla eos. Et nihil voluptas.", new DateTime(2014, 6, 24, 1, 25, 53, 517, DateTimeKind.Utc).AddTicks(6862), 1 },
                    { new Guid("b3372a04-8447-4da5-a154-681190ac21ed"), 862.588481832766000m, false, new Guid("abe7de98-bd86-4c20-9918-d0e3d8867123"), "Ipsam quisquam totam. Et vel numquam vel. Minus maiores ratione et enim. Molestias animi quisquam saepe iusto quo voluptates.", new DateTime(2014, 4, 2, 4, 45, 0, 402, DateTimeKind.Utc).AddTicks(7534), 0 },
                    { new Guid("b3e82d01-7453-4af1-af50-690d81f82eac"), 768.107933915128000m, false, new Guid("15358ab3-4b57-4e5e-877a-7e4762f018d4"), "Qui voluptatum odio voluptatem dolorem est velit ea corrupti et. Eveniet sed aperiam non dolores quod reprehenderit. Autem ut enim. Quaerat laborum ullam quia sint maiores et quo ea.", new DateTime(2016, 11, 19, 15, 43, 47, 71, DateTimeKind.Utc).AddTicks(8840), 0 },
                    { new Guid("b4096ca3-4b8e-4e83-aeae-cefc6af42303"), 487.287613036638000m, false, new Guid("12d76e6f-a966-4235-8f43-991d88418b1f"), "Ipsam ea sunt voluptas quod sed. Sed adipisci nihil. Quo est necessitatibus natus iure mollitia. Sed reprehenderit fuga.", new DateTime(2013, 9, 23, 12, 57, 41, 458, DateTimeKind.Utc).AddTicks(1853), 0 },
                    { new Guid("b7083359-9d21-4832-8d1d-df42872a3861"), 578.012810404577000m, false, new Guid("f6cde8a2-e554-41d3-ae69-9589170b99c9"), "Earum perspiciatis occaecati in qui et possimus et quo molestiae.", new DateTime(2015, 12, 25, 13, 0, 59, 848, DateTimeKind.Utc).AddTicks(7907), 99 },
                    { new Guid("b72bbf5f-c324-435f-aa09-86826e9f97bb"), 481.448804877418000m, false, new Guid("83f91037-a88d-4711-9911-ff86488bc237"), "Rerum expedita voluptatibus consequatur rerum ad modi id voluptas eveniet. Sit quia autem iusto est sunt. Odio aliquam dolor et dolor pariatur minus.", new DateTime(2012, 6, 7, 16, 29, 27, 646, DateTimeKind.Utc).AddTicks(2366), 99 },
                    { new Guid("b858d848-f463-4efd-b5e3-57e1cb292435"), 554.816505807515000m, false, new Guid("39ef24e4-1de6-423d-b64d-c7057cd571cc"), "Eos qui distinctio explicabo et provident labore repudiandae explicabo est.", new DateTime(2012, 4, 13, 2, 3, 11, 24, DateTimeKind.Utc).AddTicks(728), 0 },
                    { new Guid("b8687d84-9dce-46cb-962e-988e790e17be"), 630.563057148881000m, false, new Guid("cbf11d4f-3fe4-4ec9-ba79-fc5ff2ee2f4b"), "Nisi tempora nihil ullam. Velit qui voluptas dolor ratione delectus eveniet voluptatum consectetur.", new DateTime(2019, 9, 23, 16, 19, 59, 390, DateTimeKind.Utc).AddTicks(3807), 1 },
                    { new Guid("b901802d-e4d4-4b28-8785-7faa88097bba"), 811.106168680236000m, false, new Guid("fdaf0699-a28e-403c-8775-54a475a1cf0a"), "Repellat suscipit doloremque qui explicabo. Officia nihil fuga ex dolor laborum quia.", new DateTime(2015, 4, 16, 3, 19, 20, 146, DateTimeKind.Utc).AddTicks(9467), 0 },
                    { new Guid("bb273ebb-fb99-45f9-bd87-0d30401e96c6"), 928.37754015769000m, false, new Guid("4385ff43-6e8d-444f-a265-cf8d478744f6"), "Non quis soluta placeat repellendus repudiandae praesentium. Sapiente ullam et. Dolor fugiat aut est ab ipsam et sit ducimus. Debitis pariatur ullam voluptatem odio numquam.", new DateTime(2013, 10, 23, 8, 7, 13, 503, DateTimeKind.Utc).AddTicks(3161), 99 },
                    { new Guid("bcdc28f4-b2ce-4259-9476-2ce82a1b2561"), 373.41959922448000m, false, new Guid("fdaf0699-a28e-403c-8775-54a475a1cf0a"), "Necessitatibus vel voluptatibus esse est ut veniam placeat. Ea autem sit alias laudantium qui aut.", new DateTime(2017, 5, 29, 21, 16, 33, 518, DateTimeKind.Utc).AddTicks(8273), 1 },
                    { new Guid("be035a1a-6fc6-4297-8256-ae45ea4d66e8"), 290.731300891108000m, false, new Guid("b2724ea1-4cce-450f-8bab-67988a9f865e"), "Placeat recusandae accusantium animi qui. Rerum atque deserunt qui incidunt.", new DateTime(2016, 4, 11, 19, 0, 1, 548, DateTimeKind.Utc).AddTicks(3011), 0 },
                    { new Guid("be2018f9-c160-4d36-b56c-3c9a34ad1fd7"), 265.775943156696000m, false, new Guid("ed8f84dd-7f9d-4317-80fa-419913dc23fb"), "Quis itaque voluptatum.", new DateTime(2012, 3, 24, 1, 18, 43, 225, DateTimeKind.Utc).AddTicks(6802), 1 },
                    { new Guid("bede8267-1a7f-47c1-9c65-c4f0ab0e1f02"), 198.213873283313000m, false, new Guid("15358ab3-4b57-4e5e-877a-7e4762f018d4"), "Facilis autem modi deleniti. Omnis non adipisci sint rerum voluptatem. At odit esse totam.", new DateTime(2020, 5, 24, 10, 41, 40, 664, DateTimeKind.Utc).AddTicks(5656), 1 },
                    { new Guid("bef62ccf-f8dc-442b-9282-5e8d82e0f9c9"), 156.712543354958000m, false, new Guid("793a0118-98ec-4b18-83ca-6d5f77fda5a0"), "Et iste iusto at et optio voluptatum aut porro. Delectus et et nam ut sit. Quaerat asperiores deserunt quis fuga facere doloribus esse aliquam occaecati. Optio accusamus quod sit quibusdam sint dolorem ut.", new DateTime(2014, 1, 31, 21, 38, 23, 586, DateTimeKind.Utc).AddTicks(2681), 1 },
                    { new Guid("bf9c3555-a081-4a61-a5b3-02db4bed25da"), 314.879138509942000m, false, new Guid("8c59bd75-b7f6-43d5-87c5-c44061095f9c"), "Adipisci quidem et facilis harum ut alias. Suscipit ea rem magnam perspiciatis sit itaque consequatur. Est dolores et earum consequatur eligendi qui nostrum perferendis.", new DateTime(2016, 12, 27, 5, 57, 32, 445, DateTimeKind.Utc).AddTicks(6081), 99 },
                    { new Guid("c06e68b6-012d-43c1-b1c3-bd9d043037be"), 987.834902335258000m, false, new Guid("cbf11d4f-3fe4-4ec9-ba79-fc5ff2ee2f4b"), "Dolore pariatur exercitationem sit illo velit distinctio. Molestiae fuga voluptatem.", new DateTime(2019, 4, 27, 10, 36, 52, 700, DateTimeKind.Utc).AddTicks(516), 1 },
                    { new Guid("c08234b4-7168-4747-8806-e27cb894d478"), 357.238828504736000m, false, new Guid("83f91037-a88d-4711-9911-ff86488bc237"), "Repudiandae sunt cupiditate corporis dolorem et rerum. Alias laborum ratione.", new DateTime(2015, 10, 5, 13, 49, 23, 511, DateTimeKind.Utc).AddTicks(9640), 1 },
                    { new Guid("c08e81cf-3622-45ba-9ec1-9ee02835b3c6"), 713.13222156037000m, false, new Guid("3ee5aab2-ccc1-45d2-89c0-341336f72a9a"), "Nihil facere dolor veniam sunt suscipit quia. Quo dolor dolor repudiandae.", new DateTime(2016, 5, 3, 16, 5, 52, 683, DateTimeKind.Utc).AddTicks(7893), 99 },
                    { new Guid("c0b9b554-0baf-4152-b642-9ac732b8b6cd"), 817.205238058568000m, false, new Guid("09f419d2-09d8-4182-ac95-695055e5e634"), "Culpa cumque similique architecto omnis dolorum.", new DateTime(2016, 6, 21, 13, 24, 56, 710, DateTimeKind.Utc).AddTicks(847), 99 },
                    { new Guid("c4b10fb3-9749-4e1b-bf87-7e65f60de03a"), 463.520552436977000m, false, new Guid("09f419d2-09d8-4182-ac95-695055e5e634"), "Quidem libero et. Et officia eum unde sed vitae dolorum sed id.", new DateTime(2012, 8, 6, 5, 21, 53, 309, DateTimeKind.Utc).AddTicks(4855), 99 },
                    { new Guid("c6c6fc2f-48d5-490a-8238-0807f3837db4"), 615.385291010788000m, false, new Guid("48fd525f-4966-41e8-968d-3f7149e389ae"), "Libero est ducimus qui non voluptatibus.", new DateTime(2014, 4, 23, 20, 28, 24, 569, DateTimeKind.Utc).AddTicks(7171), 1 },
                    { new Guid("c8c74b38-6088-4613-abe2-62705db0811a"), 268.45423302516000m, false, new Guid("12d76e6f-a966-4235-8f43-991d88418b1f"), "Itaque voluptas odit. Qui qui eum sit quas molestias ea tenetur voluptates aut. Iusto quis enim inventore quibusdam amet.", new DateTime(2015, 1, 29, 5, 11, 56, 955, DateTimeKind.Utc).AddTicks(6019), 99 },
                    { new Guid("c94220a0-a166-430f-84ad-bae26eed2b3a"), 246.55319845181000m, false, new Guid("fdaf0699-a28e-403c-8775-54a475a1cf0a"), "Possimus aliquam voluptates asperiores. Est fuga architecto quam. Voluptate omnis cupiditate ab veniam nulla ex adipisci est cumque. Impedit ut assumenda libero sunt voluptatem cupiditate fuga culpa.", new DateTime(2014, 11, 2, 7, 35, 51, 299, DateTimeKind.Utc).AddTicks(1953), 1 },
                    { new Guid("c999a18f-bd80-4dee-a958-0aa13516d266"), 779.036083048038000m, false, new Guid("7e3ec143-3e22-48ca-8dd5-4fb8965cbebe"), "Reiciendis voluptatum dolores eos recusandae et voluptatem voluptates eum. Deleniti nam rem voluptas. Non et praesentium voluptatem et voluptate molestiae. Ipsa impedit non earum repellat et est.", new DateTime(2020, 11, 1, 6, 6, 58, 819, DateTimeKind.Utc).AddTicks(2737), 99 },
                    { new Guid("ca0867be-c331-4465-88e1-7f25ba15dc7e"), 353.585892006573000m, false, new Guid("1f75aa88-935c-4eb2-9891-d39332949ed6"), "Nemo temporibus quas consectetur eligendi molestias quidem cum id id. Non doloremque ut minima. Nihil maxime laboriosam officia.", new DateTime(2021, 5, 28, 17, 24, 20, 787, DateTimeKind.Utc).AddTicks(8388), 0 },
                    { new Guid("ca5ea13c-4081-4f3f-a63d-222905e4b9ce"), 440.8895603418000m, false, new Guid("c93cf7ba-5301-4a59-8238-b7a2e73b924f"), "Aut sed iure aspernatur quaerat. Ea et provident possimus aut eos quisquam deleniti quas omnis.", new DateTime(2017, 3, 12, 19, 33, 22, 270, DateTimeKind.Utc).AddTicks(1515), 0 },
                    { new Guid("ca818e5e-061e-4955-b616-fb056a0fd174"), 906.203672045656000m, false, new Guid("abe7de98-bd86-4c20-9918-d0e3d8867123"), "Distinctio saepe impedit consequuntur architecto officiis quia aspernatur dolor in. Autem incidunt quas quia velit quas consequatur dolorem. Deleniti quaerat doloribus. Neque placeat voluptas assumenda est.", new DateTime(2016, 2, 21, 20, 35, 32, 627, DateTimeKind.Utc).AddTicks(1299), 99 },
                    { new Guid("cc811a30-8a96-4d2f-a6cb-80c5c9037191"), 456.332591714538000m, false, new Guid("793a0118-98ec-4b18-83ca-6d5f77fda5a0"), "Nulla qui sunt odio est dignissimos quia tenetur est est. Voluptatem voluptatem omnis maxime quia explicabo.", new DateTime(2016, 2, 20, 13, 53, 12, 598, DateTimeKind.Utc).AddTicks(4618), 99 },
                    { new Guid("ccdaa3a7-18d0-40df-9460-712bad89d814"), 615.495634647578000m, false, new Guid("b2724ea1-4cce-450f-8bab-67988a9f865e"), "At quasi est eius. Deleniti recusandae repellendus consequatur quo optio. Consequatur culpa modi et neque sequi adipisci cupiditate autem rerum. Non omnis qui necessitatibus ut nihil ducimus.", new DateTime(2018, 5, 26, 5, 56, 45, 269, DateTimeKind.Utc).AddTicks(1186), 1 },
                    { new Guid("ceaa626b-42c4-4149-9542-0a1b43c43c27"), 317.991836538942000m, false, new Guid("c93cf7ba-5301-4a59-8238-b7a2e73b924f"), "Ut quia similique dolorum autem. Doloremque culpa quo accusantium voluptatem ab voluptatem.", new DateTime(2012, 11, 17, 13, 38, 49, 64, DateTimeKind.Utc).AddTicks(4000), 1 },
                    { new Guid("cf424e3f-8d59-4927-a072-8b3faa434877"), 777.53170966803000m, false, new Guid("fdaf0699-a28e-403c-8775-54a475a1cf0a"), "Adipisci possimus nobis ut a sint nesciunt totam eveniet ratione.", new DateTime(2020, 12, 2, 4, 38, 29, 337, DateTimeKind.Utc).AddTicks(6357), 99 },
                    { new Guid("cf5c65a3-e937-4462-8ed1-e649ac565c4a"), 804.922446947421000m, false, new Guid("c93cf7ba-5301-4a59-8238-b7a2e73b924f"), "Eveniet rerum voluptatum unde vitae rerum perferendis nam tempora. Ipsam quis quia est blanditiis rerum. Fuga a dolores a dolore saepe ut natus officiis. Dolores nisi qui provident ullam at.", new DateTime(2017, 6, 23, 20, 58, 3, 33, DateTimeKind.Utc).AddTicks(7205), 0 },
                    { new Guid("d264cb23-1f15-4055-a647-cf657c59c1c8"), 966.420519815876000m, false, new Guid("b2724ea1-4cce-450f-8bab-67988a9f865e"), "Voluptas consequuntur perferendis dolorem qui suscipit.", new DateTime(2019, 10, 31, 20, 3, 6, 848, DateTimeKind.Utc).AddTicks(4089), 0 },
                    { new Guid("d3baf705-bf91-40ea-a12e-cc9c7975ca75"), 325.89009491702000m, false, new Guid("48fd525f-4966-41e8-968d-3f7149e389ae"), "Exercitationem qui iste tempora aut. Aut tempora officiis qui ea ullam enim cum amet voluptatem. Est architecto adipisci quia ut recusandae tenetur unde rerum. Aspernatur magnam nobis quos.", new DateTime(2014, 3, 10, 12, 17, 50, 168, DateTimeKind.Utc).AddTicks(8142), 0 },
                    { new Guid("d51e386f-c910-41b7-bcf2-5ee63cd3c982"), 751.548079342036000m, false, new Guid("b2724ea1-4cce-450f-8bab-67988a9f865e"), "Sunt sit cupiditate. Molestiae perspiciatis fuga est dolore. Officia dolor molestiae quia rem dolorem nihil id voluptas. Libero quae ut quis molestias.", new DateTime(2015, 3, 9, 18, 16, 50, 763, DateTimeKind.Utc).AddTicks(4721), 0 },
                    { new Guid("d71abb84-0971-4a36-a36c-35be0d676774"), 260.949375631493000m, false, new Guid("48fd525f-4966-41e8-968d-3f7149e389ae"), "Quas debitis est velit. Quia dolores vel maxime eius doloremque eveniet non qui.", new DateTime(2014, 10, 13, 20, 11, 25, 584, DateTimeKind.Utc).AddTicks(8198), 1 },
                    { new Guid("dc178e18-06b8-4c60-a21f-8a810bfc9171"), 177.052338520737000m, false, new Guid("7e3ec143-3e22-48ca-8dd5-4fb8965cbebe"), "Dignissimos rerum est voluptatum neque.", new DateTime(2019, 4, 1, 11, 44, 45, 727, DateTimeKind.Utc).AddTicks(3041), 99 },
                    { new Guid("dc559554-3e50-40b7-9847-509187ae2019"), 264.471642440553000m, false, new Guid("b2724ea1-4cce-450f-8bab-67988a9f865e"), "Et facere aliquid repudiandae est eius similique ut.", new DateTime(2018, 3, 20, 8, 53, 31, 724, DateTimeKind.Utc).AddTicks(6421), 99 },
                    { new Guid("deee08dd-47ef-40dc-9b74-0e024f0a20cd"), 925.107866847705000m, false, new Guid("793a0118-98ec-4b18-83ca-6d5f77fda5a0"), "Expedita deserunt et quam eveniet sit voluptatum saepe vitae aperiam. Cum dolore et sint aut voluptas quod. A aut autem est ut aspernatur distinctio.", new DateTime(2016, 7, 20, 2, 13, 28, 470, DateTimeKind.Utc).AddTicks(7784), 1 },
                    { new Guid("dfe1cf6f-960f-4f35-93d6-3be69c6f60fd"), 229.904568068617000m, false, new Guid("1f75aa88-935c-4eb2-9891-d39332949ed6"), "Ratione et itaque sapiente qui. Necessitatibus laborum esse error libero. Vitae veritatis rerum aspernatur officia. Maiores illo nulla consequatur voluptate sed rerum totam.", new DateTime(2012, 12, 14, 2, 15, 15, 483, DateTimeKind.Utc).AddTicks(7386), 99 },
                    { new Guid("e40f60ca-4f9e-4114-a5d4-7f4f61fabda1"), 555.872584152244000m, false, new Guid("12d76e6f-a966-4235-8f43-991d88418b1f"), "Dignissimos nulla vitae voluptatem aliquam sed quas error. Ipsum nostrum deleniti et delectus hic delectus assumenda quos et. Similique nostrum qui qui suscipit.", new DateTime(2015, 4, 18, 12, 10, 52, 421, DateTimeKind.Utc).AddTicks(9461), 99 },
                    { new Guid("e58b5aec-c71f-40b6-8f3f-74a1af464fe4"), 616.01727770905000m, false, new Guid("09f419d2-09d8-4182-ac95-695055e5e634"), "Fugiat distinctio est unde adipisci non.", new DateTime(2015, 6, 11, 19, 59, 34, 862, DateTimeKind.Utc).AddTicks(3845), 1 },
                    { new Guid("e684d8e6-9e5b-4241-b174-d8cb06539af2"), 463.155352142312000m, false, new Guid("1f75aa88-935c-4eb2-9891-d39332949ed6"), "Ex et maxime et. Eum sapiente iste delectus qui vel quo.", new DateTime(2012, 3, 26, 0, 48, 19, 285, DateTimeKind.Utc).AddTicks(5961), 1 },
                    { new Guid("e702488a-be0e-4d98-96dd-3d498fc9df3d"), 435.464529865748000m, false, new Guid("39ef24e4-1de6-423d-b64d-c7057cd571cc"), "Est quisquam ex nihil quia sunt fugit praesentium. Beatae blanditiis ad laborum ex quasi sint. Quam aspernatur eos minus quo repellendus quam. Qui eos ratione dolores vitae eum.", new DateTime(2012, 2, 4, 21, 2, 58, 658, DateTimeKind.Utc).AddTicks(632), 1 },
                    { new Guid("e8850f6e-5ce7-4524-a5bd-eebee8083d41"), 366.693410064667000m, false, new Guid("4385ff43-6e8d-444f-a265-cf8d478744f6"), "Aut cum quia excepturi aut quo aut atque. Molestiae debitis officiis atque ut ut recusandae aspernatur voluptas. Recusandae harum eos. Omnis reiciendis temporibus debitis facere rerum optio perferendis voluptatibus vel.", new DateTime(2018, 10, 15, 18, 32, 25, 634, DateTimeKind.Utc).AddTicks(19), 99 },
                    { new Guid("e95f2f0b-65c6-4cb1-a782-46efc4284581"), 159.389687741479000m, false, new Guid("cbf11d4f-3fe4-4ec9-ba79-fc5ff2ee2f4b"), "Similique corrupti beatae est harum. Debitis eius eveniet optio nulla. Dolorem omnis quia asperiores. Est aperiam sed deserunt unde et.", new DateTime(2018, 4, 23, 12, 38, 31, 429, DateTimeKind.Utc).AddTicks(4523), 99 },
                    { new Guid("eb3975ce-9a98-4b45-b864-3e3bc241232a"), 216.872954230253000m, false, new Guid("15358ab3-4b57-4e5e-877a-7e4762f018d4"), "Illum dolore at et id molestiae dolorem sed. Dignissimos a qui quas error laboriosam explicabo eligendi aperiam laborum. Eum eveniet est. Recusandae quasi minus sint.", new DateTime(2017, 5, 13, 5, 59, 35, 11, DateTimeKind.Utc).AddTicks(8897), 1 },
                    { new Guid("eba50770-5172-48ef-ad9d-c803afae2d84"), 723.470273409266000m, false, new Guid("3ee5aab2-ccc1-45d2-89c0-341336f72a9a"), "Cupiditate delectus omnis excepturi aut excepturi magnam sit similique. Voluptatem minus voluptate voluptates iste et. Aut et est ut occaecati velit deleniti tenetur.", new DateTime(2017, 11, 2, 11, 43, 5, 433, DateTimeKind.Utc).AddTicks(3566), 0 },
                    { new Guid("ed8a4406-1cf5-430d-937b-c1af4b180b32"), 439.721315331927000m, false, new Guid("ed8f84dd-7f9d-4317-80fa-419913dc23fb"), "Pariatur reiciendis nihil ratione sed id maiores. Tempora harum vel non et quo est qui necessitatibus. Repellat voluptas quia culpa id et eligendi aut animi ut. Fugit necessitatibus eligendi nihil vel et.", new DateTime(2019, 10, 14, 22, 7, 43, 357, DateTimeKind.Utc).AddTicks(5298), 99 },
                    { new Guid("ee2cd6fb-2d0d-4265-9649-2559c0c86b4a"), 968.318381189419000m, false, new Guid("83f91037-a88d-4711-9911-ff86488bc237"), "Quod autem dolorem excepturi aut iste doloribus et sit sequi. Voluptate voluptatem error consequuntur libero ut quo autem.", new DateTime(2014, 1, 15, 4, 50, 44, 779, DateTimeKind.Utc).AddTicks(7442), 1 },
                    { new Guid("ee5fd65e-2c0f-4e73-88c7-7da406418806"), 458.200506981484000m, false, new Guid("ed8f84dd-7f9d-4317-80fa-419913dc23fb"), "Minima facilis aspernatur quo velit et porro aperiam nobis. Est temporibus consequatur.", new DateTime(2019, 7, 21, 15, 15, 7, 821, DateTimeKind.Utc).AddTicks(7097), 1 },
                    { new Guid("f0b95ee3-0b92-4cea-8c80-7a04e49a8b9d"), 180.52529097871000m, false, new Guid("c93cf7ba-5301-4a59-8238-b7a2e73b924f"), "Maxime molestiae provident labore ea nesciunt neque.", new DateTime(2012, 10, 29, 7, 56, 49, 330, DateTimeKind.Utc).AddTicks(1529), 99 },
                    { new Guid("f0f35294-4269-4e18-b3bb-9a1d7051d563"), 963.100326259378000m, false, new Guid("48fd525f-4966-41e8-968d-3f7149e389ae"), "Corrupti quia tempora natus. Commodi ut quod non voluptatibus ex cum quo. Quos expedita fuga ipsam enim et rerum qui qui. Praesentium ea est voluptatibus accusamus iure.", new DateTime(2018, 3, 29, 12, 2, 23, 783, DateTimeKind.Utc).AddTicks(8405), 0 },
                    { new Guid("f2e0e92b-4ea2-4f1a-a304-4ea89d6ee45b"), 775.824084162982000m, false, new Guid("abe7de98-bd86-4c20-9918-d0e3d8867123"), "Incidunt suscipit ea optio aut illum id sit officiis reiciendis. Est consectetur sint voluptas error.", new DateTime(2018, 3, 26, 2, 28, 59, 967, DateTimeKind.Utc).AddTicks(2862), 1 },
                    { new Guid("f3541b3d-03b8-4aba-af56-4b43688c740c"), 337.348284576868000m, false, new Guid("4385ff43-6e8d-444f-a265-cf8d478744f6"), "Vero voluptas ut.", new DateTime(2019, 9, 17, 4, 16, 48, 75, DateTimeKind.Utc).AddTicks(3879), 0 },
                    { new Guid("f4861269-eda4-4463-a567-050a808f7a5d"), 313.891924399633000m, false, new Guid("b2724ea1-4cce-450f-8bab-67988a9f865e"), "Quae vel consequatur quos. Molestias repellendus consectetur aspernatur labore optio.", new DateTime(2013, 1, 30, 16, 16, 57, 917, DateTimeKind.Utc).AddTicks(8588), 99 },
                    { new Guid("f5b4e279-e57e-4eef-ad8c-25cbcbcde582"), 930.38380562798000m, false, new Guid("15358ab3-4b57-4e5e-877a-7e4762f018d4"), "Accusamus possimus eos eius. Temporibus ea quia ratione voluptatem dolores quaerat repellat neque. Voluptatem et numquam consectetur quo dolorem cumque modi iste quae.", new DateTime(2013, 4, 30, 13, 48, 20, 63, DateTimeKind.Utc).AddTicks(4166), 99 },
                    { new Guid("f62c3422-9b72-4fd3-8ccb-7949124265a7"), 767.487229793799000m, false, new Guid("48fd525f-4966-41e8-968d-3f7149e389ae"), "Laborum voluptate culpa non hic maiores aperiam facere. Unde aspernatur magni eum provident. Corporis laborum vero accusantium molestias hic nihil et et.", new DateTime(2016, 1, 27, 1, 39, 32, 566, DateTimeKind.Utc).AddTicks(37), 1 },
                    { new Guid("f66cab7b-9bb5-4d2f-8f70-9863883abf8b"), 476.063996108306000m, false, new Guid("8c59bd75-b7f6-43d5-87c5-c44061095f9c"), "Eaque quibusdam minima et autem aut ab deleniti voluptate. Accusantium et illo cum repudiandae non velit non iste amet.", new DateTime(2021, 6, 6, 14, 58, 34, 975, DateTimeKind.Utc).AddTicks(6022), 1 },
                    { new Guid("f9dbde2b-7ff4-4b82-bda7-2e959d88d7fd"), 26.9142092444313000m, false, new Guid("4385ff43-6e8d-444f-a265-cf8d478744f6"), "Ut repellat ut corrupti quibusdam aut. Architecto voluptatem molestias facere aut quo quo. Excepturi debitis inventore et deserunt aut in accusamus. Minus esse minima.", new DateTime(2013, 3, 6, 12, 9, 40, 29, DateTimeKind.Utc).AddTicks(9960), 0 },
                    { new Guid("fa3cc8da-7cee-4bf8-add2-8685b7e66122"), 861.892647455486000m, false, new Guid("5ec1fd6b-5237-4f3d-94c1-fc36c7744b1d"), "Ut adipisci facere exercitationem earum recusandae odio voluptates id et. Et non consequuntur natus alias.", new DateTime(2017, 5, 17, 21, 9, 47, 879, DateTimeKind.Utc).AddTicks(4364), 1 },
                    { new Guid("facb382f-66ea-4619-9457-dd0ccc34e255"), 922.904180377964000m, false, new Guid("ed8f84dd-7f9d-4317-80fa-419913dc23fb"), "Quia quia dignissimos praesentium quo voluptate exercitationem. Ex voluptas quo excepturi. Corrupti velit quae aperiam molestiae velit. Ut sequi et molestiae et minus cupiditate.", new DateTime(2012, 6, 26, 22, 50, 54, 834, DateTimeKind.Utc).AddTicks(5208), 0 },
                    { new Guid("faf4f110-fbd5-402a-aca6-e4eb4c59a662"), 415.784951419951000m, false, new Guid("3ee5aab2-ccc1-45d2-89c0-341336f72a9a"), "Laborum sequi minima excepturi earum. Suscipit et earum rerum. Facere et dolorum.", new DateTime(2019, 9, 6, 17, 41, 35, 761, DateTimeKind.Utc).AddTicks(3278), 99 },
                    { new Guid("fc03f79d-b5dc-4ad2-a4d4-6006d7512eed"), 25.7475902268374000m, false, new Guid("09f419d2-09d8-4182-ac95-695055e5e634"), "Enim nihil in cum modi rerum. Et consequatur debitis quia ut similique ipsum. Molestiae nisi et. Dolores sit quas.", new DateTime(2013, 6, 7, 17, 44, 49, 444, DateTimeKind.Utc).AddTicks(3462), 1 },
                    { new Guid("fc358a55-e97c-44df-8362-d11d5630b51d"), 933.830202962398000m, false, new Guid("abe7de98-bd86-4c20-9918-d0e3d8867123"), "Aut dicta autem expedita recusandae quod. Porro animi atque fuga dolores qui alias accusamus. Officia facilis modi dolor laboriosam harum inventore.", new DateTime(2012, 10, 21, 23, 45, 3, 77, DateTimeKind.Utc).AddTicks(5766), 0 },
                    { new Guid("fcbb9bb3-09e1-4d3c-b48d-e8fc4ae38214"), 219.262346568166000m, false, new Guid("09f419d2-09d8-4182-ac95-695055e5e634"), "Error eius vel quis similique sed saepe rerum. Voluptatibus doloribus vel voluptatibus incidunt odio odit consequatur error ea.", new DateTime(2012, 1, 31, 2, 49, 30, 69, DateTimeKind.Utc).AddTicks(8380), 0 }
                });

            migrationBuilder.InsertData(
                table: "SubscriptionsPaid",
                columns: new[] { "MemberId", "Year", "April", "August", "December", "February", "January", "July", "June", "March", "May", "November", "October", "September" },
                values: new object[,]
                {
                    { new Guid("09f419d2-09d8-4182-ac95-695055e5e634"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("12d76e6f-a966-4235-8f43-991d88418b1f"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("12d76e6f-a966-4235-8f43-991d88418b1f"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("12d76e6f-a966-4235-8f43-991d88418b1f"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("12d76e6f-a966-4235-8f43-991d88418b1f"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("12d76e6f-a966-4235-8f43-991d88418b1f"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("12d76e6f-a966-4235-8f43-991d88418b1f"), 2020, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("15358ab3-4b57-4e5e-877a-7e4762f018d4"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("15358ab3-4b57-4e5e-877a-7e4762f018d4"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("15358ab3-4b57-4e5e-877a-7e4762f018d4"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("15358ab3-4b57-4e5e-877a-7e4762f018d4"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("1f75aa88-935c-4eb2-9891-d39332949ed6"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("1f75aa88-935c-4eb2-9891-d39332949ed6"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("1f75aa88-935c-4eb2-9891-d39332949ed6"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("39ef24e4-1de6-423d-b64d-c7057cd571cc"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("3ee5aab2-ccc1-45d2-89c0-341336f72a9a"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("3ee5aab2-ccc1-45d2-89c0-341336f72a9a"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("3ee5aab2-ccc1-45d2-89c0-341336f72a9a"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("3ee5aab2-ccc1-45d2-89c0-341336f72a9a"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("3ee5aab2-ccc1-45d2-89c0-341336f72a9a"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("3ee5aab2-ccc1-45d2-89c0-341336f72a9a"), 2020, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("3ee5aab2-ccc1-45d2-89c0-341336f72a9a"), 2021, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("4385ff43-6e8d-444f-a265-cf8d478744f6"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("4385ff43-6e8d-444f-a265-cf8d478744f6"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("4385ff43-6e8d-444f-a265-cf8d478744f6"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("4385ff43-6e8d-444f-a265-cf8d478744f6"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("4385ff43-6e8d-444f-a265-cf8d478744f6"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("4385ff43-6e8d-444f-a265-cf8d478744f6"), 2020, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("4385ff43-6e8d-444f-a265-cf8d478744f6"), 2021, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("48fd525f-4966-41e8-968d-3f7149e389ae"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("48fd525f-4966-41e8-968d-3f7149e389ae"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("7e3ec143-3e22-48ca-8dd5-4fb8965cbebe"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("83f91037-a88d-4711-9911-ff86488bc237"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("8c59bd75-b7f6-43d5-87c5-c44061095f9c"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("8c59bd75-b7f6-43d5-87c5-c44061095f9c"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("8c59bd75-b7f6-43d5-87c5-c44061095f9c"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("8c59bd75-b7f6-43d5-87c5-c44061095f9c"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("8c59bd75-b7f6-43d5-87c5-c44061095f9c"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("8c59bd75-b7f6-43d5-87c5-c44061095f9c"), 2020, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("abe7de98-bd86-4c20-9918-d0e3d8867123"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("abe7de98-bd86-4c20-9918-d0e3d8867123"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("abe7de98-bd86-4c20-9918-d0e3d8867123"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("abe7de98-bd86-4c20-9918-d0e3d8867123"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("b2724ea1-4cce-450f-8bab-67988a9f865e"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("b2724ea1-4cce-450f-8bab-67988a9f865e"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("b2724ea1-4cce-450f-8bab-67988a9f865e"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("c93cf7ba-5301-4a59-8238-b7a2e73b924f"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("c93cf7ba-5301-4a59-8238-b7a2e73b924f"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("c93cf7ba-5301-4a59-8238-b7a2e73b924f"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("c93cf7ba-5301-4a59-8238-b7a2e73b924f"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("c93cf7ba-5301-4a59-8238-b7a2e73b924f"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("c93cf7ba-5301-4a59-8238-b7a2e73b924f"), 2020, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("c93cf7ba-5301-4a59-8238-b7a2e73b924f"), 2021, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("cbf11d4f-3fe4-4ec9-ba79-fc5ff2ee2f4b"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("f6cde8a2-e554-41d3-ae69-9589170b99c9"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("f6cde8a2-e554-41d3-ae69-9589170b99c9"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("f6cde8a2-e554-41d3-ae69-9589170b99c9"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("f6cde8a2-e554-41d3-ae69-9589170b99c9"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("f6cde8a2-e554-41d3-ae69-9589170b99c9"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("f6cde8a2-e554-41d3-ae69-9589170b99c9"), 2020, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("fdaf0699-a28e-403c-8775-54a475a1cf0a"), 2015, true, true, true, true, true, true, true, true, true, true, true, true }
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
                name: "SubscriptionsPaid");

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
