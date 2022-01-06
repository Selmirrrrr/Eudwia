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
                    { new Guid("0a54a9bf-901f-49a5-a249-17c711bb6621"), new DateOnly(1985, 8, 17), "Rennes", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Annabelle", "556", 2, "Nicolas", new DateOnly(2019, 2, 27), null, "VD", "567 Passage Royale", "8 étage", "70433" },
                    { new Guid("1986cf92-661b-4935-8549-b47c80bc9455"), new DateOnly(1996, 1, 21), "Le Tampon", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Eulalie", "698", 2, "Deschamps", new DateOnly(2021, 10, 8), null, "VD", "11 Allée Saint-Honoré", "Apt. 096", "60411" },
                    { new Guid("2a94a07d-ba5d-4c1d-a884-18757698c355"), new DateOnly(1959, 3, 4), "Aulnay-sous-Bois", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Auxane", "8", 0, "Berger", new DateOnly(2015, 3, 25), null, "VD", "2176 Avenue Marcadet", "Apt. 970", "43833" },
                    { new Guid("4333d245-b59c-47df-b304-0504151cd170"), new DateOnly(1950, 4, 15), "Roubaix", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Axelle", "1535", 0, "Morel", new DateOnly(2016, 1, 14), null, "VD", "2 Boulevard de Vaugirard", "Apt. 987", "57327" },
                    { new Guid("4341e472-ce11-4bb5-9627-a8b78fac99f7"), new DateOnly(1985, 12, 16), "Nantes", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Hardouin", "742", 1, "Rousseau", new DateOnly(2021, 9, 16), null, "VD", "341 Rue d'Abbeville", "6 étage", "59090" },
                    { new Guid("66176f28-d002-454d-b567-38f41464878f"), new DateOnly(1971, 12, 3), "Limoges", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Armelle", "04", 2, "Roussel", new DateOnly(2017, 1, 10), null, "VD", "885 Avenue Saint-Jacques", "Apt. 617", "87379" },
                    { new Guid("6a817924-9c58-4dfd-8737-0c3c2a5d009d"), new DateOnly(1955, 10, 27), "Bourges", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Aube", "9586", 2, "Carre", new DateOnly(2016, 3, 21), null, "VD", "916 Boulevard des Saussaies", "Apt. 381", "93983" },
                    { new Guid("6bb109f5-75b5-4c06-ab9f-3be75d2ee8cb"), new DateOnly(1960, 5, 12), "Paris", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Azeline", "2960", 0, "Jean", new DateOnly(2019, 6, 23), null, "VD", "4 Voie Saint-Honoré", "Apt. 360", "91920" },
                    { new Guid("743e47d8-d927-4999-ac3f-87ca70e37025"), new DateOnly(1970, 6, 8), "Amiens", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Chrysole", "61", 0, "Vasseur", new DateOnly(2020, 3, 7), null, "VD", "715 Impasse de Tilsitt", "6 étage", "79143" },
                    { new Guid("7ec9e58a-4558-4a74-b5bc-964d3ee34f12"), new DateOnly(1976, 3, 8), "Aix-en-Provence", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Victor", "861", 0, "Renaud", new DateOnly(2021, 4, 7), null, "VD", "219 Allée d'Argenteuil", "2 étage", "88499" },
                    { new Guid("9bb3b604-164b-40d4-9d8c-80446606f855"), new DateOnly(1992, 12, 25), "Noisy-le-Grand", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Scholastique", "7425", 0, "Remy", new DateOnly(2019, 5, 29), null, "VD", "0197 Boulevard de Paris", "Apt. 889", "74699" },
                    { new Guid("a577cef9-574f-4b4b-a550-d73ee538cf8e"), new DateOnly(1987, 12, 2), "Saint-Denis", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Maxime", "9354", 0, "Garnier", new DateOnly(2012, 1, 25), null, "VD", "3702 Place de Rivoli", "Apt. 023", "41245" },
                    { new Guid("bfdab30f-4fba-4ff9-b315-49387b7a6372"), new DateOnly(1968, 4, 6), "Levallois-Perret", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Aldric", "50", 0, "Vidal", new DateOnly(2016, 12, 8), null, "VD", "8 Voie Saint-Dominique", "5 étage", "66669" },
                    { new Guid("c390632f-04e2-4bda-9d3e-f8bf13c27f00"), new DateOnly(1960, 10, 20), "Villeurbanne", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Hilaire", "34", 1, "Schneider", new DateOnly(2012, 2, 2), null, "VD", "8 Allée Pierre Charron", "Apt. 921", "82907" },
                    { new Guid("c40325b2-00dc-424c-bdb2-826cb64bc22a"), new DateOnly(1999, 9, 9), "Troyes", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Aurélie", "8", 2, "Faure", new DateOnly(2020, 2, 19), null, "VD", "05 Rue du Faubourg Saint-Honoré", "3 étage", "81995" },
                    { new Guid("e4863da0-3e5c-4431-9dfa-551c4ef94c56"), new DateOnly(1987, 12, 26), "Clermont-Ferrand", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Apolline", "3", 0, "Dupuis", new DateOnly(2012, 10, 31), null, "VD", "04 Quai des Francs-Bourgeois", "1 étage", "80530" },
                    { new Guid("f434642d-c01d-4cdd-85c5-4fdf5df07c0e"), new DateOnly(1965, 11, 22), "Amiens", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Damien", "6017", 2, "Marchand", new DateOnly(2019, 6, 1), null, "VD", "04 Impasse Zadkine", "Apt. 853", "09381" },
                    { new Guid("fb467bd5-82b5-4ead-91c0-9eb4170a49d4"), new DateOnly(1993, 10, 27), "Mulhouse", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Adolphie", "6085", 0, "Le roux", new DateOnly(2015, 9, 26), null, "VD", "060 Impasse Marcadet", "Apt. 824", "74038" },
                    { new Guid("fc9ea8ee-18c0-463e-b208-5b82657999c5"), new DateOnly(1991, 3, 27), "Toulon", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Edmée", "9", 2, "Marchand", new DateOnly(2013, 3, 18), null, "VD", "6 Impasse Du Sommerard", "4 étage", "00699" },
                    { new Guid("ffbc275f-ea62-4f58-a600-cd8a0ea8c3ed"), new DateOnly(1979, 10, 22), "Chambéry", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Aleth", "3", 0, "Martin", new DateOnly(2018, 4, 23), null, "VD", "544 Impasse de Rivoli", "Apt. 080", "54638" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "MemberId", "Note", "PaymentDate", "PaymentType" },
                values: new object[,]
                {
                    { new Guid("012b84cd-ff6e-4466-9083-b4af510d99c7"), 0m, new Guid("6a817924-9c58-4dfd-8737-0c3c2a5d009d"), "Labore sit illo optio eum et itaque. Odit amet aliquid sed dolorem modi laboriosam. Cum praesentium fugiat facilis odit rerum autem accusantium sed necessitatibus. Illum eos et et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("02ec7915-ad36-40e0-ab6a-8223a5a5d42f"), 0m, new Guid("4341e472-ce11-4bb5-9627-a8b78fac99f7"), "Et cum et laboriosam eligendi id distinctio. Mollitia enim eaque provident nostrum quam autem. Sed voluptate qui.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("03a4db10-9a07-4088-bc08-a2c94ce4d781"), 0m, new Guid("66176f28-d002-454d-b567-38f41464878f"), "Ut aut ex.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("05577c0b-631e-4107-96fe-97a8156e4d57"), 0m, new Guid("6bb109f5-75b5-4c06-ab9f-3be75d2ee8cb"), "Et est velit quo natus perspiciatis nam debitis aut et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("05c51e34-f370-4202-b195-e55a2f244d6c"), 0m, new Guid("9bb3b604-164b-40d4-9d8c-80446606f855"), "Et illo quaerat officia. Nostrum error molestiae consectetur quia iusto quis et consequatur. Rerum ut sint nihil qui. At et sunt illo accusantium ut neque optio fugiat iure.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("081895d8-0a48-4d1d-adfb-43b1e7b13eb4"), 0m, new Guid("ffbc275f-ea62-4f58-a600-cd8a0ea8c3ed"), "Earum consequuntur quo quod vel. In nihil odio hic.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("08ddcca3-908a-4b97-9d34-b8ddce2fe673"), 0m, new Guid("1986cf92-661b-4935-8549-b47c80bc9455"), "Perferendis beatae corrupti beatae. Qui sint ex.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("0a51f1e0-6d08-4fb1-94ff-a7a6d078d909"), 0m, new Guid("66176f28-d002-454d-b567-38f41464878f"), "Enim et laborum. Delectus ratione ex voluptates provident. Et vel quo necessitatibus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("0d2863bb-4f1f-43e4-93d0-2ab9e4e38f39"), 0m, new Guid("4333d245-b59c-47df-b304-0504151cd170"), "Libero tempore sint.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("0d49ea98-916e-43e6-bc62-f7159c0fb9b6"), 0m, new Guid("6bb109f5-75b5-4c06-ab9f-3be75d2ee8cb"), "Qui est reiciendis et soluta harum quasi aut maxime sit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("10180639-92c7-4cb4-acdf-85be740b58b4"), 0m, new Guid("f434642d-c01d-4cdd-85c5-4fdf5df07c0e"), "Provident rerum repellat qui dicta ea nam sequi. Rerum molestiae eius blanditiis natus placeat incidunt dolorum excepturi adipisci. Minima maxime fuga dolorem corporis nesciunt voluptas animi eveniet blanditiis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("122732c2-9964-48b3-adc2-d722523419ee"), 0m, new Guid("7ec9e58a-4558-4a74-b5bc-964d3ee34f12"), "Soluta eum commodi dolores aut ut occaecati enim distinctio. Laborum qui eveniet in. Molestiae in modi dolorem perferendis. Maxime deserunt omnis deserunt nulla sit ut consectetur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("1242f2c4-1819-43e0-9295-e505a57c7738"), 0m, new Guid("f434642d-c01d-4cdd-85c5-4fdf5df07c0e"), "Doloremque excepturi aspernatur qui dolor. Est corporis distinctio omnis corporis. Laudantium dolores deleniti quisquam autem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("131ebe59-a3ed-45f6-986e-a5d3a59b2b12"), 0m, new Guid("e4863da0-3e5c-4431-9dfa-551c4ef94c56"), "Saepe nemo et voluptate. Aut sunt repellat et atque occaecati molestias nihil repellat error. Laborum alias in ut et nobis. Molestiae eos quis qui illum ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("179d467a-614e-4587-adb7-4c9eaee9cd07"), 0m, new Guid("a577cef9-574f-4b4b-a550-d73ee538cf8e"), "Et autem maxime vero sunt optio dicta quo. Voluptas minus perferendis aut et et dolorum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("18886826-7691-4268-ab4f-e15e1cd2e63b"), 0m, new Guid("4341e472-ce11-4bb5-9627-a8b78fac99f7"), "Ab ipsam velit omnis est dolorem ut dolorum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("1950b895-4310-41b0-a14d-66f7d08a02d6"), 0m, new Guid("fb467bd5-82b5-4ead-91c0-9eb4170a49d4"), "Laborum sit ab. Aspernatur sed cumque velit saepe ratione debitis. Possimus labore aspernatur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("19ad734f-2872-45bf-8d3c-6fc98c59ca09"), 0m, new Guid("743e47d8-d927-4999-ac3f-87ca70e37025"), "Temporibus est aspernatur doloremque quaerat repudiandae rerum accusantium quisquam sunt.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("1a0d383f-7d34-41dd-bc04-4e2ea4da9e4d"), 0m, new Guid("0a54a9bf-901f-49a5-a249-17c711bb6621"), "Sequi sequi illum blanditiis nihil. Qui eius voluptatum eveniet animi adipisci id dolores magnam. Dolor non error amet alias quisquam corporis magnam nostrum itaque. Corporis et autem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("1c8f8489-ca61-4af9-86b0-609801660c35"), 0m, new Guid("bfdab30f-4fba-4ff9-b315-49387b7a6372"), "Ducimus nesciunt praesentium. Voluptate et et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("1dcd0ed1-4bb3-450b-8618-c8a5363901e7"), 0m, new Guid("4333d245-b59c-47df-b304-0504151cd170"), "Autem autem aliquam esse accusantium numquam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("1f29cee6-119e-4abd-b5ec-68f8da0aacbb"), 0m, new Guid("fb467bd5-82b5-4ead-91c0-9eb4170a49d4"), "Sint nesciunt expedita ullam incidunt voluptatem inventore sed in consequatur. Dicta quis velit repudiandae quisquam ullam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("1f3872c3-368c-4395-8edc-53429aad329b"), 0m, new Guid("ffbc275f-ea62-4f58-a600-cd8a0ea8c3ed"), "Est alias dolorum quaerat accusamus aspernatur porro ea provident.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("2015f68e-5385-4aad-989e-585526658423"), 0m, new Guid("2a94a07d-ba5d-4c1d-a884-18757698c355"), "Aut sed numquam ut. A voluptas adipisci earum ut tempore quisquam nihil. Voluptatem voluptatem nesciunt et a qui.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("20d81f5c-e564-455c-a5a0-4f0ee1590691"), 0m, new Guid("e4863da0-3e5c-4431-9dfa-551c4ef94c56"), "Ratione et ea.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("21e55ab8-2479-4785-9770-cedfa5ae8243"), 0m, new Guid("6a817924-9c58-4dfd-8737-0c3c2a5d009d"), "Occaecati assumenda ex autem est ea facere dicta et. Aut consectetur mollitia animi nihil eaque amet sed omnis enim. Quia consequatur illo sint consequatur quis. Sed minus et deserunt eligendi sunt aliquid omnis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("2391503d-1cd3-40ee-9fc4-52cad80e6867"), 0m, new Guid("4333d245-b59c-47df-b304-0504151cd170"), "Accusamus eaque error eaque. Iste quia vitae. Delectus fuga sed illum. Id consequatur rerum dolores molestiae.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("25eb0173-6c88-423b-bd4e-36b3c3dcf151"), 0m, new Guid("c40325b2-00dc-424c-bdb2-826cb64bc22a"), "Tenetur dolor eaque officia assumenda sit minus. Provident odit tempora dolore voluptas. Non pariatur modi dolorem quasi et ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("26913b7a-f416-48c2-b8a8-08e6d6349545"), 0m, new Guid("bfdab30f-4fba-4ff9-b315-49387b7a6372"), "Nemo molestias omnis. Sit quia consequuntur corrupti sit natus provident et maiores et. Distinctio minima itaque. Et ut molestias omnis sint quo dolor.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("27ba3efe-fe30-4233-a2f0-1df673e6f145"), 0m, new Guid("6a817924-9c58-4dfd-8737-0c3c2a5d009d"), "Dolor sed dolores. Voluptatibus ea tempore harum reiciendis amet amet fugit magni perferendis. Praesentium incidunt asperiores consequatur ducimus accusantium aut sit nisi sequi. Atque laudantium distinctio.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("27d5bcb9-084f-4155-adbf-c0da3682d29b"), 0m, new Guid("66176f28-d002-454d-b567-38f41464878f"), "Nostrum at dolores cumque itaque aspernatur ut nisi quia. Non expedita vitae rem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("28d63fd8-16e2-42fe-aa2c-1f636fb123ba"), 0m, new Guid("2a94a07d-ba5d-4c1d-a884-18757698c355"), "Numquam facere minus ea eum. Est nihil rerum. Et voluptatem repellendus est debitis et sed. Consequatur dignissimos vitae quod repellendus placeat ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("29d8f4ac-4c82-4640-8e55-9079f09cec92"), 0m, new Guid("743e47d8-d927-4999-ac3f-87ca70e37025"), "Rem minus optio et molestiae earum porro voluptatem voluptatibus. Molestias saepe beatae harum repudiandae id.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("2d0f451d-7b75-4096-bd4d-89dbd5d7bc34"), 0m, new Guid("0a54a9bf-901f-49a5-a249-17c711bb6621"), "Laborum sunt qui.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("2d4408c2-6c19-43e9-8079-5bab5f37f7ea"), 0m, new Guid("4333d245-b59c-47df-b304-0504151cd170"), "Porro magnam quis sunt omnis non numquam deleniti quis consectetur. Ab distinctio est est velit nesciunt est quis et et. Placeat aut est quis non voluptas. Et et quia.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("2dd7bc3b-ee0b-4b0f-b80a-5bd2f95f5f54"), 0m, new Guid("4333d245-b59c-47df-b304-0504151cd170"), "Perferendis sunt quia et itaque ipsum officiis itaque voluptatem atque.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("30bfb023-f777-4b68-8d18-0391e40527f6"), 0m, new Guid("bfdab30f-4fba-4ff9-b315-49387b7a6372"), "Perspiciatis iure sed quaerat aspernatur nobis beatae est expedita.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("321f5f15-d37c-41fc-abe5-989568a1c9bd"), 0m, new Guid("6a817924-9c58-4dfd-8737-0c3c2a5d009d"), "Et sapiente nostrum. Rerum inventore incidunt suscipit tenetur eos id. Ducimus sint omnis. Esse reiciendis quia quaerat et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("3423ba1a-6c14-46b8-8802-7e3c5a71f456"), 0m, new Guid("fc9ea8ee-18c0-463e-b208-5b82657999c5"), "Nam et praesentium est. Incidunt mollitia eos quis optio illo.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("349afd77-ee4b-460d-8836-1cbfe53cd291"), 0m, new Guid("2a94a07d-ba5d-4c1d-a884-18757698c355"), "Quisquam eius quia voluptas. Voluptatibus pariatur in illum aut itaque odio. Vel voluptates amet mollitia. Exercitationem delectus odit quae architecto dolorum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("38726810-f8c2-4bf9-a520-ddf11e9f087f"), 0m, new Guid("ffbc275f-ea62-4f58-a600-cd8a0ea8c3ed"), "Qui rerum molestiae magnam aperiam similique sunt commodi quia.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("393f98e2-e6a3-4fdf-aa5d-1c5d7316e47f"), 0m, new Guid("9bb3b604-164b-40d4-9d8c-80446606f855"), "Laborum eaque assumenda. Et deleniti nesciunt unde.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("3aaf9df3-f988-405c-acae-87b377517e78"), 0m, new Guid("2a94a07d-ba5d-4c1d-a884-18757698c355"), "Ad vel impedit quo qui. Consequatur non corrupti. Doloremque neque sapiente voluptatibus fugit accusamus quas iure.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("3b15b870-7c2f-481e-a403-b2758d36dd38"), 0m, new Guid("ffbc275f-ea62-4f58-a600-cd8a0ea8c3ed"), "Aut consectetur blanditiis aut ut nemo ad rem. Cum quibusdam quibusdam libero qui voluptatem nostrum illum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("3b1d356c-5ade-46db-9a89-93c44cc4cc99"), 0m, new Guid("a577cef9-574f-4b4b-a550-d73ee538cf8e"), "Est id voluptatibus et repellat deleniti et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("3bdddded-c8df-411c-bc03-ccc31895ff2d"), 0m, new Guid("c390632f-04e2-4bda-9d3e-f8bf13c27f00"), "Et consequatur libero quaerat rerum neque. Nemo excepturi rerum adipisci occaecati voluptatem nobis animi laborum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("3d74f862-63b2-472e-850e-fc7bbc2129a7"), 0m, new Guid("fc9ea8ee-18c0-463e-b208-5b82657999c5"), "Consequatur et illo perspiciatis repellat quo pariatur est quam eos. Commodi dolor eius cumque voluptas.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("402cce7f-b309-4054-9002-a296b25bde36"), 0m, new Guid("7ec9e58a-4558-4a74-b5bc-964d3ee34f12"), "Provident tempore et voluptates in qui.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("41540d41-869d-4f30-a32b-882ad65f88e3"), 0m, new Guid("9bb3b604-164b-40d4-9d8c-80446606f855"), "Consectetur rem ut illo. Ipsam dolorem quas ut. Eaque quibusdam voluptatem sint non rerum autem qui ipsam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("420979bb-22e7-48f2-a4ec-2792b0d2ad8a"), 0m, new Guid("a577cef9-574f-4b4b-a550-d73ee538cf8e"), "Inventore a enim sit ea.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("427dd293-a894-4e97-b7bd-07cfeefb2e51"), 0m, new Guid("4341e472-ce11-4bb5-9627-a8b78fac99f7"), "Pariatur et veritatis. Occaecati sint accusamus voluptate qui aut expedita rerum. Maxime porro dolorum quo et minus ipsam aperiam. Rem qui molestiae.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("429a22e2-3a35-4331-bf81-22b3e4effba7"), 0m, new Guid("4341e472-ce11-4bb5-9627-a8b78fac99f7"), "Laudantium cupiditate et molestiae. Dolorem a veritatis earum esse minima ut eveniet beatae optio. In accusantium repellat adipisci aut praesentium optio. Quasi aut deserunt itaque excepturi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("45db87eb-6346-4b24-a4f0-3285831144f8"), 0m, new Guid("c40325b2-00dc-424c-bdb2-826cb64bc22a"), "Perferendis rem consequatur animi facere. Voluptate dolorem beatae exercitationem reiciendis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("47f8ddc6-ade3-4eef-9564-86062526392f"), 0m, new Guid("743e47d8-d927-4999-ac3f-87ca70e37025"), "Voluptatem quia possimus dolores dolorem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("49bb412d-8869-48f3-882e-d7b1e6c6caa0"), 0m, new Guid("c390632f-04e2-4bda-9d3e-f8bf13c27f00"), "Voluptatem adipisci tempore sed. Est autem corrupti quis quidem maxime. Incidunt optio repudiandae voluptas aperiam et excepturi est autem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("4adc2d5a-b12c-4957-8f0f-8c6f98902ad3"), 0m, new Guid("c40325b2-00dc-424c-bdb2-826cb64bc22a"), "Molestias accusantium qui nihil consequatur ea qui. Sit odio velit itaque quis. Perferendis expedita id quod quia quaerat in voluptas at.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("4b790174-509f-4a7c-9902-ea51a9c73fe5"), 0m, new Guid("f434642d-c01d-4cdd-85c5-4fdf5df07c0e"), "Aut hic maiores quo voluptatem. Explicabo dolores facilis vitae alias rerum dicta alias. Perferendis qui quasi dolores neque voluptatibus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("4bb09c21-212f-41bd-888e-c2d99e67e7ec"), 0m, new Guid("a577cef9-574f-4b4b-a550-d73ee538cf8e"), "Non repellat saepe et molestias consequuntur ullam nisi sunt non.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("4c60c38c-4e14-4780-94f5-3700e0340a61"), 0m, new Guid("c40325b2-00dc-424c-bdb2-826cb64bc22a"), "Nulla officiis in non ut exercitationem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("4d29d89d-ab47-4c0b-b636-2a23b8f20b14"), 0m, new Guid("1986cf92-661b-4935-8549-b47c80bc9455"), "Nobis maxime omnis quis voluptatem dolore.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("4e939f1e-875f-4461-b653-8209ed3c63b7"), 0m, new Guid("9bb3b604-164b-40d4-9d8c-80446606f855"), "Explicabo consequatur architecto aut. Non at fugiat labore qui cupiditate voluptas quia.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("505f2662-98b8-4a66-95b7-74802ca8765f"), 0m, new Guid("fb467bd5-82b5-4ead-91c0-9eb4170a49d4"), "Impedit vero recusandae libero a consequuntur sed.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("51c0a5ca-2daf-434e-8a53-09e04b2dbde8"), 0m, new Guid("2a94a07d-ba5d-4c1d-a884-18757698c355"), "Ducimus laborum totam inventore sit vel nam et est. Quo nemo praesentium ratione asperiores nulla dolor. Magnam doloribus architecto rerum eligendi. Aut natus ut magnam eos veniam quos consequatur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("51ea5c4f-ac1a-474a-a5e9-5c774b9174d4"), 0m, new Guid("f434642d-c01d-4cdd-85c5-4fdf5df07c0e"), "Praesentium voluptatem dolorum natus doloribus ad consequuntur. Odio a explicabo.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("51f54d42-8660-45a7-8c01-324c6a2ee116"), 0m, new Guid("fb467bd5-82b5-4ead-91c0-9eb4170a49d4"), "Rerum esse accusantium omnis quisquam blanditiis ut debitis ut quaerat. Sed sit aut praesentium deleniti sit maxime aut exercitationem unde. Perferendis sapiente ipsum culpa quaerat impedit sunt.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("525814b0-c79e-423e-bb2b-8a245f60af02"), 0m, new Guid("e4863da0-3e5c-4431-9dfa-551c4ef94c56"), "Possimus dolorem facere quae. Suscipit laboriosam sit libero natus aut. Voluptatem nisi ducimus facilis magnam aperiam quis eum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("55210db2-3342-48e4-a5c5-a7f68f2de159"), 0m, new Guid("a577cef9-574f-4b4b-a550-d73ee538cf8e"), "Quia error error eum praesentium ipsa tenetur ex repudiandae. Excepturi quae rerum aperiam id rerum non cupiditate.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("56a454d5-f82b-430e-b809-e7484b52432a"), 0m, new Guid("743e47d8-d927-4999-ac3f-87ca70e37025"), "Quas tempora dignissimos molestias vero. Ratione magnam et aut iure.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("5b2f7de7-88d6-4aa2-ac3e-90d9ed18af6d"), 0m, new Guid("7ec9e58a-4558-4a74-b5bc-964d3ee34f12"), "Ratione neque maxime enim sit aperiam ea. Et magnam aliquid. Rem nihil qui. Possimus sed earum iure.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("5b5a4e06-82ab-4456-968c-0c240278a5c6"), 0m, new Guid("1986cf92-661b-4935-8549-b47c80bc9455"), "Dolorem distinctio incidunt tempore quos dolorum. Illo praesentium enim hic. Occaecati quidem reprehenderit natus repellendus recusandae consequuntur enim.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("5bbd64bc-9d4c-4a37-b878-2f2df55f87f8"), 0m, new Guid("e4863da0-3e5c-4431-9dfa-551c4ef94c56"), "Consequatur fuga sed ut quia perferendis dolorem. Esse omnis aut. At ut omnis repudiandae.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("5c4943f6-01ec-46d3-a124-7ca93bbb6d76"), 0m, new Guid("6bb109f5-75b5-4c06-ab9f-3be75d2ee8cb"), "Qui dolorem porro veniam. Ab ad sit delectus alias. Autem deleniti ut non ab quo totam corporis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("5cca30b6-a30e-4fac-888f-47b260f7e967"), 0m, new Guid("bfdab30f-4fba-4ff9-b315-49387b7a6372"), "Sit iure ullam ipsa necessitatibus sed sed quibusdam vel tempora.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("5dcdeba4-0a8e-4fd0-818a-3b72bfbaeb4d"), 0m, new Guid("2a94a07d-ba5d-4c1d-a884-18757698c355"), "Necessitatibus qui velit. Labore est voluptatem nobis sed veniam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("5e2ddb90-ac9e-4d94-aba3-dd9bab4abbff"), 0m, new Guid("6a817924-9c58-4dfd-8737-0c3c2a5d009d"), "Et repellat dolorum dolore quo in velit eveniet incidunt ab. Ex qui voluptate nihil asperiores quia doloribus vel ut. Minus possimus quis sint vitae animi molestias totam totam cupiditate.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("61a48a69-48c2-4a50-af6e-f7b571104ced"), 0m, new Guid("743e47d8-d927-4999-ac3f-87ca70e37025"), "Ipsa ut molestiae. Quaerat commodi eaque ut sint quaerat. Est corporis reiciendis amet deleniti voluptatem vitae enim eveniet voluptate.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("621729ba-251c-4407-bda3-59d273ae7505"), 0m, new Guid("743e47d8-d927-4999-ac3f-87ca70e37025"), "Nulla reprehenderit praesentium beatae dignissimos. Qui rem non tempora quam. Impedit commodi eaque veritatis modi. Aliquid ut aliquid ut perferendis deleniti recusandae in enim deserunt.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("63a72525-e41b-4c81-9f0c-c50b340233a5"), 0m, new Guid("6bb109f5-75b5-4c06-ab9f-3be75d2ee8cb"), "Vero modi esse voluptates accusantium repellendus nam repellendus sunt culpa.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("647570bb-c508-4764-8f84-8570ec5329d9"), 0m, new Guid("6a817924-9c58-4dfd-8737-0c3c2a5d009d"), "Modi et nemo voluptatem et asperiores non.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("651bf9af-01da-4ef4-8ff7-f243cb631304"), 0m, new Guid("9bb3b604-164b-40d4-9d8c-80446606f855"), "Aut saepe et. Sint rem dolor eum et rerum ipsa omnis rerum. Quo aut eius maxime.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("657efeac-2b15-4509-b1cc-fc4ec4354c55"), 0m, new Guid("0a54a9bf-901f-49a5-a249-17c711bb6621"), "Ad quis beatae ea optio qui distinctio ab molestiae inventore. Quam ut aliquid. Consequuntur quia consectetur amet ipsam inventore est velit quia.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("65aa1619-0746-4184-a5cb-d8ffe9362c1f"), 0m, new Guid("c390632f-04e2-4bda-9d3e-f8bf13c27f00"), "Vel et perspiciatis consectetur porro quia reprehenderit ea pariatur. Reprehenderit alias eaque explicabo ipsa et id magni nulla. Dolore repudiandae quam itaque cumque exercitationem est veniam nobis nobis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("66426514-400c-446e-b2cb-899373866a99"), 0m, new Guid("6bb109f5-75b5-4c06-ab9f-3be75d2ee8cb"), "Cumque omnis dolor laborum veritatis. Eos aut magni adipisci.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("66500b3f-8ba0-4517-ac87-69191f146ec3"), 0m, new Guid("7ec9e58a-4558-4a74-b5bc-964d3ee34f12"), "Non neque quia aut quos expedita numquam aut. Vero et laborum est beatae maiores et sunt recusandae. Occaecati inventore libero voluptatem quasi commodi placeat.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("66a5912c-fa5b-4a1e-8587-432b30597be2"), 0m, new Guid("1986cf92-661b-4935-8549-b47c80bc9455"), "Eum ut velit esse non omnis distinctio ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("66af7bd9-a886-4f48-8471-80887d67ee03"), 0m, new Guid("0a54a9bf-901f-49a5-a249-17c711bb6621"), "In deserunt eligendi fuga assumenda magni temporibus eligendi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("689df250-409a-41c7-b651-47ef1e5ecba1"), 0m, new Guid("4333d245-b59c-47df-b304-0504151cd170"), "Rerum consequatur ut totam et sit illo.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("69b2b978-c643-4573-9671-32195ac99114"), 0m, new Guid("bfdab30f-4fba-4ff9-b315-49387b7a6372"), "Aliquam dolorem suscipit aut. Iste cumque sapiente debitis aut. Et qui iusto illum qui doloribus. Id voluptatem aut rem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("6b09ea5d-b997-48ec-b964-415e15d1ed19"), 0m, new Guid("a577cef9-574f-4b4b-a550-d73ee538cf8e"), "Sint nisi laborum quia recusandae corporis qui numquam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("6bfb5312-b364-48e6-88fd-4197f17ae650"), 0m, new Guid("7ec9e58a-4558-4a74-b5bc-964d3ee34f12"), "Tempore ipsum dicta et repudiandae illum saepe labore. Et voluptas ad voluptatem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("6e7a55d0-352b-4d9a-89a8-f4de2ff2a32d"), 0m, new Guid("4333d245-b59c-47df-b304-0504151cd170"), "Modi libero labore quo non adipisci et quia officia. Vitae est nihil id cumque quis porro incidunt architecto. Eveniet dignissimos molestiae laudantium illum ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("6f2e3fc0-863d-4d56-92eb-a3d78e35994b"), 0m, new Guid("4341e472-ce11-4bb5-9627-a8b78fac99f7"), "Explicabo minima quis doloribus necessitatibus aut voluptatem dolores voluptatum nostrum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("6f4e0f0c-af4f-4902-9314-d3d4b366a4ba"), 0m, new Guid("f434642d-c01d-4cdd-85c5-4fdf5df07c0e"), "Officiis atque blanditiis necessitatibus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("721638f5-7bc5-4d28-b871-eb95cf187d69"), 0m, new Guid("a577cef9-574f-4b4b-a550-d73ee538cf8e"), "Laborum ipsa voluptatibus illo.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("758fe342-be14-49ed-ac12-3ebcba1e4921"), 0m, new Guid("1986cf92-661b-4935-8549-b47c80bc9455"), "In qui ipsum blanditiis eaque nemo rerum nihil optio. Nam quisquam aspernatur rem officiis rem excepturi et labore est.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("75e56f41-8754-49d3-8ed3-cedd5ee451df"), 0m, new Guid("fb467bd5-82b5-4ead-91c0-9eb4170a49d4"), "Accusantium odit quia minus ipsam rerum iste qui qui.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("77248df8-e443-41d2-87ff-9495f05bb660"), 0m, new Guid("c40325b2-00dc-424c-bdb2-826cb64bc22a"), "Repellat ipsum pariatur cupiditate accusantium. Sed odio voluptatem non perferendis quia earum unde. Qui iste qui aut ullam iure aut consectetur omnis. Cumque eum sit veritatis voluptatem ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("785a30eb-f014-46ad-ac8c-567913911306"), 0m, new Guid("4341e472-ce11-4bb5-9627-a8b78fac99f7"), "Molestias perspiciatis earum neque nam beatae veniam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("791d0ab4-5eae-4d6a-b703-1a41ca9e3b74"), 0m, new Guid("fc9ea8ee-18c0-463e-b208-5b82657999c5"), "Dolor ex vel sint quis aspernatur temporibus aliquam ratione. Porro atque nobis qui iste eveniet qui excepturi cupiditate atque. Porro nostrum omnis. Illo harum et minima non.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("7b326d83-a5fa-4622-b023-61423bbdf52b"), 0m, new Guid("fb467bd5-82b5-4ead-91c0-9eb4170a49d4"), "Et ut aliquid voluptate enim quis tenetur vitae. Corrupti quaerat iure ut aut velit reprehenderit. Veniam quia dolor sapiente eaque.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("7c91be28-5b38-4b2c-9165-30e99e840067"), 0m, new Guid("fb467bd5-82b5-4ead-91c0-9eb4170a49d4"), "Iusto eum quia ut qui ut repellendus dolorem quis consectetur. In dolores ratione architecto dicta et et qui facilis. Nobis libero consequatur ut est ex.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("7cc03f88-895f-4506-81af-37e3c809a03f"), 0m, new Guid("6bb109f5-75b5-4c06-ab9f-3be75d2ee8cb"), "Harum quaerat autem dicta minima nulla illum quia. Laboriosam deserunt repellat totam quis eveniet quis iure. Architecto tenetur quo aut praesentium. Deleniti quae aut molestias molestiae.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("7d1ab0a9-ff62-4535-9e86-8ab2b1d308a6"), 0m, new Guid("4333d245-b59c-47df-b304-0504151cd170"), "In et accusamus et id iure error.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("7ef829cf-8d04-49f7-9bbe-136727aa10cd"), 0m, new Guid("0a54a9bf-901f-49a5-a249-17c711bb6621"), "Qui mollitia sed et labore molestiae ipsum sed laudantium corporis. Doloribus et quam velit sint omnis laboriosam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("7fdd27b3-9be0-464e-9bde-119189b02b6a"), 0m, new Guid("743e47d8-d927-4999-ac3f-87ca70e37025"), "Voluptas aut rerum nesciunt rerum. Est nesciunt placeat eos expedita est expedita. Minima omnis qui repudiandae. Eum rerum eos quae eum est minima.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("80ca67c2-1ca2-4f20-a9cb-566d9c01383b"), 0m, new Guid("ffbc275f-ea62-4f58-a600-cd8a0ea8c3ed"), "Modi omnis rem consequuntur delectus quas voluptatem odit harum distinctio. Sint ducimus nemo exercitationem beatae laborum laudantium molestias velit et. Voluptas repellat impedit similique.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("80f05416-3755-4fc6-908d-5be9fcb32562"), 0m, new Guid("fc9ea8ee-18c0-463e-b208-5b82657999c5"), "Quidem officiis consequatur totam reiciendis nostrum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("81265497-0c4c-4b19-a947-37d8b09648b3"), 0m, new Guid("f434642d-c01d-4cdd-85c5-4fdf5df07c0e"), "Perferendis qui quae nihil.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("853c1f60-9755-4bab-9c3e-077742785c8a"), 0m, new Guid("66176f28-d002-454d-b567-38f41464878f"), "Est aut distinctio enim ratione animi autem labore necessitatibus. Laudantium quis ea quisquam libero rerum qui quos. Velit et qui deleniti ducimus nobis et et at.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("860bf286-9338-4117-a45b-5fd77f7020b6"), 0m, new Guid("2a94a07d-ba5d-4c1d-a884-18757698c355"), "Unde consequuntur in molestias minima neque quam est. Expedita porro voluptas voluptas excepturi distinctio possimus modi deserunt eum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("8630326a-863a-4f3d-9dec-ef885cdc4e95"), 0m, new Guid("e4863da0-3e5c-4431-9dfa-551c4ef94c56"), "Enim iure id deleniti et minus fugiat dolorem necessitatibus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("88239eeb-6056-48f1-b247-ad4a9f2314fe"), 0m, new Guid("c390632f-04e2-4bda-9d3e-f8bf13c27f00"), "Architecto nihil debitis et voluptatem voluptas et. Qui quia corporis. Voluptatem est qui quia ut nihil unde sunt tempore molestias.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("884d67f0-8262-4b86-8e17-1ef5c692b24c"), 0m, new Guid("1986cf92-661b-4935-8549-b47c80bc9455"), "Aut cumque nesciunt nulla voluptatem eaque. Dolores consequatur repellendus. Qui et exercitationem hic illum expedita. Molestias eaque eum numquam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("8894a94e-0fff-4bb5-a4c7-9e96cfc88ef7"), 0m, new Guid("a577cef9-574f-4b4b-a550-d73ee538cf8e"), "Quibusdam magnam ea rerum. Optio aliquid culpa dicta blanditiis veniam nesciunt et at consectetur. Expedita maiores aut similique quas eveniet. Nobis deleniti enim hic in nesciunt alias modi ut provident.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("88bdfe58-a133-4f65-9ae5-ce0cd40db5ba"), 0m, new Guid("6bb109f5-75b5-4c06-ab9f-3be75d2ee8cb"), "Consequatur debitis unde consequatur error incidunt.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("88dd7aaf-1cba-4e95-aaf9-b826a6e22c25"), 0m, new Guid("743e47d8-d927-4999-ac3f-87ca70e37025"), "Quae error optio est dicta omnis. Ratione pariatur harum ut optio aliquid accusantium iste voluptas dolorem. Suscipit pariatur facilis hic voluptatibus. Possimus expedita dolorem iusto voluptatem harum velit ab.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("89f8801f-4e6f-432c-8488-534293c985bd"), 0m, new Guid("f434642d-c01d-4cdd-85c5-4fdf5df07c0e"), "Id et optio laudantium rerum et ipsum. Sequi expedita qui nobis deleniti sit. Ut temporibus accusamus repellat facere. Qui sequi autem autem maxime voluptas dolorum amet.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("8b8df073-6114-4b36-8cfc-f7a59b291348"), 0m, new Guid("1986cf92-661b-4935-8549-b47c80bc9455"), "Qui eaque quasi aut consectetur doloribus fuga esse. Autem sapiente delectus. Dolorum voluptates nulla aliquid officiis eaque. Sed accusamus ea dignissimos.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("8bdfe5d1-6e84-4f86-8283-a65d2c302cfe"), 0m, new Guid("9bb3b604-164b-40d4-9d8c-80446606f855"), "Aut cum repellendus eaque nulla qui rerum laborum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("8ca5e5f0-024e-4789-a2ac-076d7e85412d"), 0m, new Guid("9bb3b604-164b-40d4-9d8c-80446606f855"), "Ipsam enim ipsum vero neque unde dolor esse et omnis. Sint quas corporis quam unde explicabo.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("8d45bfe9-27b4-4d29-a0b6-dd138546001f"), 0m, new Guid("6bb109f5-75b5-4c06-ab9f-3be75d2ee8cb"), "Voluptatem animi amet totam laboriosam. Explicabo sint doloremque veniam laudantium voluptatem rerum exercitationem aspernatur. Blanditiis ut reprehenderit cum totam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("8d532a0c-1df8-4189-ae28-809531303ad0"), 0m, new Guid("c390632f-04e2-4bda-9d3e-f8bf13c27f00"), "Laboriosam soluta et qui minima velit voluptatum quibusdam. Maiores in omnis sed neque et. Ratione a et autem qui ducimus eveniet explicabo et. Porro quibusdam adipisci hic facere consequatur voluptatem et ullam deserunt.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("8fb1597a-c161-4596-aa12-b6e595e9a564"), 0m, new Guid("c390632f-04e2-4bda-9d3e-f8bf13c27f00"), "Sit vero repellat at numquam. Non molestias id eos delectus. Saepe ipsum id quis impedit laborum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("90742856-2fbb-45fd-aee4-e1b80842ddd3"), 0m, new Guid("ffbc275f-ea62-4f58-a600-cd8a0ea8c3ed"), "Soluta dolor occaecati est mollitia rerum non ipsam. Tempore officiis incidunt blanditiis et est magnam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("90cee2c6-0650-4659-8503-115d0b59b662"), 0m, new Guid("0a54a9bf-901f-49a5-a249-17c711bb6621"), "Numquam quidem quo aspernatur eaque repellendus. Voluptas dolorem sed doloribus dolores tenetur. Sapiente delectus amet.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("90e56e93-283f-4dfe-81c9-4bec05da70b0"), 0m, new Guid("0a54a9bf-901f-49a5-a249-17c711bb6621"), "Quod atque placeat dicta commodi veritatis sed in sed. Rerum unde sit nobis autem. Qui autem minima quo vel. Aut quia dolor.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("911ebd28-73c4-4a12-9491-56810c53988a"), 0m, new Guid("66176f28-d002-454d-b567-38f41464878f"), "Suscipit quos earum ut ullam dolorem sint consectetur sit error. Rerum qui eum accusamus est voluptas in at provident maxime. Temporibus aut dolores ducimus et ducimus nisi nulla dolor error. Aliquid quia accusantium aut sint officia.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("915e7776-e41c-493a-b869-d9d0857c7e5c"), 0m, new Guid("bfdab30f-4fba-4ff9-b315-49387b7a6372"), "Maxime blanditiis sapiente doloribus aut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("925c2759-cd33-46ba-8485-8378e06913b8"), 0m, new Guid("c390632f-04e2-4bda-9d3e-f8bf13c27f00"), "Vel voluptas ullam rerum ratione sed et. Qui sunt perspiciatis quis rerum voluptatem omnis quia. Qui consequuntur veritatis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("93fde85b-f47f-4b91-9bae-d7d09888e883"), 0m, new Guid("7ec9e58a-4558-4a74-b5bc-964d3ee34f12"), "Perferendis ut vel optio et. Consequatur sit quia deserunt.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("94ac29c2-3abd-4d53-a477-9151bb9d50bb"), 0m, new Guid("2a94a07d-ba5d-4c1d-a884-18757698c355"), "Alias dolores quae voluptatem quo et quibusdam sit explicabo. Alias sed quis soluta laborum. Et vel nam magni voluptatum deleniti.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("94bab127-3fdf-4a15-bf23-b98cda5ee14f"), 0m, new Guid("0a54a9bf-901f-49a5-a249-17c711bb6621"), "Ut totam sint explicabo. Enim voluptatum asperiores velit qui autem. Officia quaerat quisquam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("95f12c45-2dc3-47eb-b161-8ab5e2c9e8a2"), 0m, new Guid("f434642d-c01d-4cdd-85c5-4fdf5df07c0e"), "Nulla autem molestiae praesentium doloremque aut dolorum dolor omnis. Ab minus nostrum vero vel eveniet eius. Dolor quia quam. Hic asperiores quod.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("96e9be94-3a63-483e-8aa0-12ea57180e74"), 0m, new Guid("7ec9e58a-4558-4a74-b5bc-964d3ee34f12"), "Natus et eveniet asperiores blanditiis placeat at et sit ut. Voluptas veritatis ut non.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("9ba8ce7d-81bc-4e76-ac6e-35ca3cb76345"), 0m, new Guid("bfdab30f-4fba-4ff9-b315-49387b7a6372"), "Sit aliquid animi qui sint. Non fugit illum voluptas facere dolorem atque fuga sequi dolor. Sit numquam aliquam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("9ebab6e3-b173-4aae-9b30-78bb6f590c49"), 0m, new Guid("a577cef9-574f-4b4b-a550-d73ee538cf8e"), "Sed qui atque voluptatem sit maxime accusamus repellendus. Et maxime qui voluptates neque vero sed suscipit omnis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("a2481f84-aaa5-4ef9-91b3-ed00352df28e"), 0m, new Guid("c390632f-04e2-4bda-9d3e-f8bf13c27f00"), "Sed velit perferendis dolor voluptas nisi voluptatum. Optio iste delectus eos sit expedita quis ipsa eius amet. Et esse nemo vel ut dolores sed et alias aliquid. Consequuntur quam maxime ex qui rerum alias voluptates.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("a2b6fef4-0ed0-4c5c-b1c8-aac9c87d3abb"), 0m, new Guid("e4863da0-3e5c-4431-9dfa-551c4ef94c56"), "Et eaque illo laboriosam non quis. Rerum rerum perferendis sed fugiat sint. Possimus tempore explicabo autem tenetur velit non praesentium provident.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("a2f2a624-9b4b-4895-b38f-e67a918ceada"), 0m, new Guid("c40325b2-00dc-424c-bdb2-826cb64bc22a"), "Sint voluptatem explicabo sint.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("a453894f-6f62-4146-ad88-fb5ea454ec18"), 0m, new Guid("f434642d-c01d-4cdd-85c5-4fdf5df07c0e"), "Expedita temporibus facilis minus nemo quaerat. Numquam exercitationem sit. Ipsa dolores fugit tempora hic et. Fuga officia accusamus velit molestiae aperiam non.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("a9b30a5b-9875-40cd-8454-be01e3582fc2"), 0m, new Guid("9bb3b604-164b-40d4-9d8c-80446606f855"), "Et autem voluptas aut sit eos veniam nihil.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("aaa2c1c6-ff3f-45e2-81f5-53dbf21b8cb5"), 0m, new Guid("4333d245-b59c-47df-b304-0504151cd170"), "Eum porro delectus eum ducimus ipsum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("aabbcb62-83b2-44d9-a778-cffce53469e5"), 0m, new Guid("66176f28-d002-454d-b567-38f41464878f"), "Quam a odio nesciunt magnam aliquam et dolorum aut. Tempora pariatur aut rem sint aspernatur magnam et itaque. Aut commodi ducimus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("ab0436d9-d921-47e4-8c46-04c5621f296d"), 0m, new Guid("fc9ea8ee-18c0-463e-b208-5b82657999c5"), "Ipsum ut et veritatis. Omnis quasi aliquid eaque architecto hic odit. Pariatur aperiam atque vitae et sed rerum repellendus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("ab76b171-026a-4631-9e2a-e6e572511c1b"), 0m, new Guid("e4863da0-3e5c-4431-9dfa-551c4ef94c56"), "Adipisci laudantium placeat sed sed expedita. Dignissimos debitis labore.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("ad4a8d15-e802-4911-9908-beca973832b8"), 0m, new Guid("c390632f-04e2-4bda-9d3e-f8bf13c27f00"), "Ut et quo veniam veritatis itaque at.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("aed45d1b-33d7-4b9d-b8cf-e09b1755405f"), 0m, new Guid("66176f28-d002-454d-b567-38f41464878f"), "Accusamus nostrum et iste. Distinctio voluptatem neque non aliquam reprehenderit officia iure eos. Enim et vitae suscipit molestiae doloribus. Ratione cumque qui ab delectus ut quas perspiciatis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("b245042f-e5c9-4ded-8b87-fd2218e801f6"), 0m, new Guid("1986cf92-661b-4935-8549-b47c80bc9455"), "Autem et et id deleniti ab repellat reprehenderit quia.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("b2e07535-ed9a-43a0-82db-19157f36400f"), 0m, new Guid("bfdab30f-4fba-4ff9-b315-49387b7a6372"), "Odio alias ab suscipit debitis harum. Tenetur ad officia. Deserunt et quisquam vitae ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("b3100c4c-6a4b-4b7c-a929-ac6a5a0e2f69"), 0m, new Guid("ffbc275f-ea62-4f58-a600-cd8a0ea8c3ed"), "Qui similique quasi minima. Dicta ea quod natus ipsam qui.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("b3770c67-d0b7-41db-9330-da41b8170feb"), 0m, new Guid("e4863da0-3e5c-4431-9dfa-551c4ef94c56"), "Repudiandae laborum repellendus eos. Aliquam labore aut corporis et. Debitis quo non consequatur vero et autem dolor aliquam perspiciatis. Fugit et sed amet sint hic.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("b3c41541-b727-485b-9996-19689399cb7d"), 0m, new Guid("0a54a9bf-901f-49a5-a249-17c711bb6621"), "Vitae rerum temporibus aliquid maxime illum culpa eum ut. Deserunt dignissimos atque sit. Assumenda aliquid quam natus quasi accusamus inventore dolores.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("b435c701-f245-490c-be69-ccb9c84cd05b"), 0m, new Guid("2a94a07d-ba5d-4c1d-a884-18757698c355"), "Officia velit eum voluptas sed. Cum repellendus non possimus eveniet ea et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("b8ef0e86-774a-42c3-82b5-d7c0a2192529"), 0m, new Guid("c390632f-04e2-4bda-9d3e-f8bf13c27f00"), "Fugit nihil aut dolor sint nulla nesciunt nihil in ipsam. Rerum fugit magnam qui aut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("b9cc2aa6-09ec-4288-b202-3f82a7e96462"), 0m, new Guid("6bb109f5-75b5-4c06-ab9f-3be75d2ee8cb"), "Minima quas dolor quasi ullam accusantium. Voluptate ea est molestiae iusto aut. Sunt placeat fugiat.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("ba248b21-e93f-4034-8ec4-58efadd16f45"), 0m, new Guid("6bb109f5-75b5-4c06-ab9f-3be75d2ee8cb"), "Animi id voluptas velit quo consectetur repellendus. Quod mollitia asperiores ipsum velit ipsum. Vitae placeat delectus autem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("ba36402c-8655-4a70-9339-537b9b4c92eb"), 0m, new Guid("ffbc275f-ea62-4f58-a600-cd8a0ea8c3ed"), "Exercitationem a excepturi deserunt beatae sit nihil. Rem nihil est id eius cumque nesciunt sed.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("ba3e9e84-8c75-4380-8d70-50a2b141a5bd"), 0m, new Guid("6a817924-9c58-4dfd-8737-0c3c2a5d009d"), "Sit laudantium dicta quae delectus tempora qui. Distinctio reiciendis repellendus fugiat suscipit rem reprehenderit aut ex tempore. Velit magnam saepe omnis. Exercitationem magni nobis dolor.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("bc8c67e4-6434-4948-911d-73970c916d35"), 0m, new Guid("1986cf92-661b-4935-8549-b47c80bc9455"), "Eaque consequatur quia natus. Magnam porro in est omnis qui. Quasi eius laborum reprehenderit praesentium pariatur autem. Dolorum dolore dolor.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("beefdb90-04a2-45ba-b022-24bc6abbac9b"), 0m, new Guid("bfdab30f-4fba-4ff9-b315-49387b7a6372"), "Dicta consequatur et deleniti amet nihil quas facilis eum nihil. Debitis sunt dolorem ducimus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("bf64dc73-2a38-4bed-bd52-87aaf06787bd"), 0m, new Guid("ffbc275f-ea62-4f58-a600-cd8a0ea8c3ed"), "Ea et voluptas ut sit repellat. Aut officia dolorem amet. Veniam id temporibus est. Sunt similique hic dolor rerum in eaque necessitatibus maxime.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("c60b7c62-5c34-4355-95ff-33a146cc5b9b"), 0m, new Guid("fc9ea8ee-18c0-463e-b208-5b82657999c5"), "Consequuntur praesentium architecto et error hic est iste dolor.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("c6b0b2b4-a984-4dc6-a6cb-e775c17d9b8a"), 0m, new Guid("9bb3b604-164b-40d4-9d8c-80446606f855"), "Modi nemo explicabo quas ut perspiciatis sint sunt. Eos aut neque fuga nesciunt quisquam vero fuga atque ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("c890fef3-2a79-4e62-86e6-6573efb34099"), 0m, new Guid("743e47d8-d927-4999-ac3f-87ca70e37025"), "Eligendi et ut dignissimos sint blanditiis voluptatem dolorem repellendus. Et odit similique velit sunt cupiditate eius corporis repudiandae quae. Consequuntur quis libero earum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("c89d2b37-282d-41fc-87cd-4d1c676a0b51"), 0m, new Guid("66176f28-d002-454d-b567-38f41464878f"), "Dolores minima eius ea eveniet et blanditiis soluta. Molestiae id vitae sunt rerum animi qui facere nisi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("c9dade01-da5e-4c23-ad39-f1763bffbd3e"), 0m, new Guid("bfdab30f-4fba-4ff9-b315-49387b7a6372"), "Cumque ipsum neque quaerat ullam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("ceb51e48-2aed-4270-8ad0-1995d9cae01a"), 0m, new Guid("fb467bd5-82b5-4ead-91c0-9eb4170a49d4"), "Repellat deserunt aut et. Deleniti dolorem in qui saepe voluptas error blanditiis ullam. Sed amet voluptatibus laboriosam eum incidunt rerum aut debitis harum. Omnis quas et nesciunt distinctio fuga nisi nihil sit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("cf0003cd-f8b0-43ac-918e-39aa6475eaec"), 0m, new Guid("66176f28-d002-454d-b567-38f41464878f"), "Pariatur harum hic sed recusandae repellat iure atque voluptas.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("d1a434b8-7300-4733-8342-812fa35aa2aa"), 0m, new Guid("fc9ea8ee-18c0-463e-b208-5b82657999c5"), "Recusandae eum autem aperiam repudiandae similique enim autem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("d22863a0-4bea-41f8-90dd-7b046b4ccf3b"), 0m, new Guid("fb467bd5-82b5-4ead-91c0-9eb4170a49d4"), "Ratione facilis fugit ut temporibus animi laudantium at. Quia atque nobis sed et excepturi voluptate voluptas. Rem aut hic dolores quos beatae rem. Optio officiis harum laboriosam nostrum dolore quas beatae omnis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("d2a7d210-17f5-4c68-b34d-75d04fd3b906"), 0m, new Guid("4333d245-b59c-47df-b304-0504151cd170"), "Maxime consequuntur corrupti. Et modi velit odit dolorem. Veniam quos quos suscipit explicabo quisquam nihil.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("d2ccc7ac-6678-4b2b-8470-9d41552726b3"), 0m, new Guid("f434642d-c01d-4cdd-85c5-4fdf5df07c0e"), "Quo ut est inventore adipisci alias iure. Laudantium atque nihil nihil enim. Sint atque ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("d4623e1e-818b-4047-9e50-e8b248865cd0"), 0m, new Guid("e4863da0-3e5c-4431-9dfa-551c4ef94c56"), "Molestiae quis quod maxime. Velit id ut ut eligendi voluptas ratione repellendus ut est. Qui sed dolorem blanditiis est incidunt.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("d4e4f620-1c38-41cd-bde8-fd1ef80fba05"), 0m, new Guid("6a817924-9c58-4dfd-8737-0c3c2a5d009d"), "Non eos praesentium sed et quis voluptate excepturi vel ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("d57a8f1f-93e9-4937-94bb-d25b78bd0694"), 0m, new Guid("743e47d8-d927-4999-ac3f-87ca70e37025"), "Debitis vel ad vel dolor perspiciatis delectus voluptas. Consequatur deserunt quisquam perferendis autem et non adipisci et. Eos sed et cupiditate.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("d5a20477-3310-4495-816f-9771ff1be7b2"), 0m, new Guid("6a817924-9c58-4dfd-8737-0c3c2a5d009d"), "Eveniet harum voluptate eveniet consequatur itaque magni et saepe. Id nobis excepturi in accusantium praesentium repellendus minima aliquid tempora.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("d674b903-a789-4528-b344-a79f5f0c31e9"), 0m, new Guid("ffbc275f-ea62-4f58-a600-cd8a0ea8c3ed"), "Dignissimos quibusdam magni ratione dolores laudantium amet. Deleniti rerum omnis sapiente ipsa et officiis rerum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("d6840a07-4a5c-4d71-835b-8f79d222fbac"), 0m, new Guid("c40325b2-00dc-424c-bdb2-826cb64bc22a"), "Est quia voluptate blanditiis voluptate qui. Optio excepturi molestiae explicabo facere et. Non dolores aut ut. Voluptas dicta earum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("da81d3f4-4285-429c-b1c0-b27ef37444d2"), 0m, new Guid("6a817924-9c58-4dfd-8737-0c3c2a5d009d"), "Omnis sequi ut pariatur possimus quia vel. Omnis est qui id tempora totam. Est eos asperiores.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("daff5b85-9e9a-4d7e-8292-2afb9bf4d35d"), 0m, new Guid("0a54a9bf-901f-49a5-a249-17c711bb6621"), "Qui asperiores incidunt. Vel sed velit perferendis nulla eligendi ratione consequatur. Voluptates voluptatem soluta voluptas accusantium animi iste quia perspiciatis. Adipisci commodi repudiandae autem voluptatum consectetur consequuntur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("dbe6be36-f002-433c-bca8-09c8cb9a0e9d"), 0m, new Guid("4341e472-ce11-4bb5-9627-a8b78fac99f7"), "Ex delectus libero quas consequatur eos dolorem. Omnis perspiciatis dolores mollitia. Corrupti vel reprehenderit in iusto dolor amet.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("ddf24138-aef6-4ee3-9340-c42f1c05e1ab"), 0m, new Guid("a577cef9-574f-4b4b-a550-d73ee538cf8e"), "Dignissimos excepturi deserunt.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("df095dab-96ae-4d90-97aa-a3da93de68a1"), 0m, new Guid("7ec9e58a-4558-4a74-b5bc-964d3ee34f12"), "Cum quasi voluptatem laborum quas. Et dolor dolores rem eum non facilis. Ad in maiores fugit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("e0e7a244-0e7e-4bae-be04-923fbe99a312"), 0m, new Guid("7ec9e58a-4558-4a74-b5bc-964d3ee34f12"), "Amet consectetur aspernatur vel reiciendis accusantium voluptates omnis eligendi. Sit quia minus assumenda expedita sit deserunt. Odit ut est veritatis exercitationem corporis voluptatibus nihil.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("e1845f3e-19bf-4a68-879f-661347c2949e"), 0m, new Guid("4341e472-ce11-4bb5-9627-a8b78fac99f7"), "Provident optio et numquam velit tempore incidunt saepe. Dolor est aut repudiandae maiores et optio ea. Dolorem quas qui nesciunt magni et iure esse.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("e3f15a34-aa9e-4914-9390-cc2709801a99"), 0m, new Guid("9bb3b604-164b-40d4-9d8c-80446606f855"), "Suscipit laudantium qui repellat eveniet rerum suscipit quaerat.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("e470ddd5-53be-4755-9b37-2d96db2b1b5a"), 0m, new Guid("66176f28-d002-454d-b567-38f41464878f"), "Autem quisquam ratione modi rem. Amet mollitia minus vel consectetur aspernatur incidunt et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("e4fa7e1c-c8b1-46bf-a7ce-a6e2b1ef4244"), 0m, new Guid("fc9ea8ee-18c0-463e-b208-5b82657999c5"), "Ipsam eum modi aliquid.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("e56b3c58-3f77-420e-849f-7d5803181a49"), 0m, new Guid("4341e472-ce11-4bb5-9627-a8b78fac99f7"), "Ea ab est omnis ad. Iusto assumenda id aut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("e8716ff2-07c5-48f4-b2b5-af6b666815ee"), 0m, new Guid("fc9ea8ee-18c0-463e-b208-5b82657999c5"), "Modi consequatur voluptatem sit. Quae accusantium odio ut ut qui blanditiis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("ed300646-0384-4b78-b4b5-6316f6ac4b98"), 0m, new Guid("e4863da0-3e5c-4431-9dfa-551c4ef94c56"), "Rerum tempore placeat dolorum qui quo.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("ef9bc6d7-b0ca-4349-9e5a-67a2d5b4e896"), 0m, new Guid("2a94a07d-ba5d-4c1d-a884-18757698c355"), "Architecto magni cumque possimus. Et molestiae ipsum laboriosam aut sapiente. Tempora natus sapiente voluptatibus itaque necessitatibus doloribus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("f1d51545-aab2-4018-8940-880ccdb41c5b"), 0m, new Guid("c40325b2-00dc-424c-bdb2-826cb64bc22a"), "Cumque praesentium vitae magnam saepe sint aut maxime perferendis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("f3d117a7-475b-425f-a6e8-88b35f99d564"), 0m, new Guid("7ec9e58a-4558-4a74-b5bc-964d3ee34f12"), "Ducimus ea molestiae eum distinctio aut. Itaque nulla consectetur qui rem. Suscipit numquam eius praesentium saepe voluptates quod dolore.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("f50d5771-79fd-4fa8-b338-973e1fdd8f63"), 0m, new Guid("fc9ea8ee-18c0-463e-b208-5b82657999c5"), "Est sed autem possimus ullam molestiae atque. Modi atque quia ipsam doloribus nihil dolores vel sed adipisci. Aut molestiae qui quas libero.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("f5c84be1-429a-4f51-828e-4ac2202b9d42"), 0m, new Guid("c40325b2-00dc-424c-bdb2-826cb64bc22a"), "Autem dicta aspernatur itaque aliquam quis tempora qui. Aliquid quo ipsa.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("f8520101-516d-4d2e-8966-968e0faabd57"), 0m, new Guid("4341e472-ce11-4bb5-9627-a8b78fac99f7"), "Quaerat harum non necessitatibus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("f928f057-e5b4-4b0a-8dfa-cf53d5ea7ca2"), 0m, new Guid("1986cf92-661b-4935-8549-b47c80bc9455"), "Dolor sunt natus explicabo pariatur esse asperiores et dolores non. Minima deleniti quasi dolore vel consequatur consequatur enim.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("f9c41c52-13b4-4290-8616-a0fb33738471"), 0m, new Guid("c40325b2-00dc-424c-bdb2-826cb64bc22a"), "Voluptates ducimus tempora odit commodi laboriosam distinctio incidunt.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("fd0ce3a6-a0a6-4ce2-a9cd-daa08bbbbd21"), 0m, new Guid("fb467bd5-82b5-4ead-91c0-9eb4170a49d4"), "Id laboriosam et dignissimos. Adipisci voluptatem rem laudantium sunt in nihil et assumenda qui.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "SubscriptionsPaid",
                columns: new[] { "MemberId", "Year", "April", "August", "December", "February", "January", "July", "June", "March", "May", "November", "October", "September" },
                values: new object[,]
                {
                    { new Guid("0a54a9bf-901f-49a5-a249-17c711bb6621"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("0a54a9bf-901f-49a5-a249-17c711bb6621"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("0a54a9bf-901f-49a5-a249-17c711bb6621"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("0a54a9bf-901f-49a5-a249-17c711bb6621"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("0a54a9bf-901f-49a5-a249-17c711bb6621"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("0a54a9bf-901f-49a5-a249-17c711bb6621"), 2020, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("0a54a9bf-901f-49a5-a249-17c711bb6621"), 2021, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("1986cf92-661b-4935-8549-b47c80bc9455"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("1986cf92-661b-4935-8549-b47c80bc9455"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("2a94a07d-ba5d-4c1d-a884-18757698c355"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("4333d245-b59c-47df-b304-0504151cd170"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("4333d245-b59c-47df-b304-0504151cd170"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("4333d245-b59c-47df-b304-0504151cd170"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("4333d245-b59c-47df-b304-0504151cd170"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("4333d245-b59c-47df-b304-0504151cd170"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("4341e472-ce11-4bb5-9627-a8b78fac99f7"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("4341e472-ce11-4bb5-9627-a8b78fac99f7"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("4341e472-ce11-4bb5-9627-a8b78fac99f7"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("4341e472-ce11-4bb5-9627-a8b78fac99f7"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("66176f28-d002-454d-b567-38f41464878f"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("66176f28-d002-454d-b567-38f41464878f"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("66176f28-d002-454d-b567-38f41464878f"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("66176f28-d002-454d-b567-38f41464878f"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("66176f28-d002-454d-b567-38f41464878f"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("6a817924-9c58-4dfd-8737-0c3c2a5d009d"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("6a817924-9c58-4dfd-8737-0c3c2a5d009d"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("6a817924-9c58-4dfd-8737-0c3c2a5d009d"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("6a817924-9c58-4dfd-8737-0c3c2a5d009d"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("6bb109f5-75b5-4c06-ab9f-3be75d2ee8cb"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("6bb109f5-75b5-4c06-ab9f-3be75d2ee8cb"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("743e47d8-d927-4999-ac3f-87ca70e37025"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("a577cef9-574f-4b4b-a550-d73ee538cf8e"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("a577cef9-574f-4b4b-a550-d73ee538cf8e"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("a577cef9-574f-4b4b-a550-d73ee538cf8e"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("a577cef9-574f-4b4b-a550-d73ee538cf8e"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("a577cef9-574f-4b4b-a550-d73ee538cf8e"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("a577cef9-574f-4b4b-a550-d73ee538cf8e"), 2020, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("bfdab30f-4fba-4ff9-b315-49387b7a6372"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("bfdab30f-4fba-4ff9-b315-49387b7a6372"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("bfdab30f-4fba-4ff9-b315-49387b7a6372"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("bfdab30f-4fba-4ff9-b315-49387b7a6372"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("c390632f-04e2-4bda-9d3e-f8bf13c27f00"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("c390632f-04e2-4bda-9d3e-f8bf13c27f00"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("c390632f-04e2-4bda-9d3e-f8bf13c27f00"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("c390632f-04e2-4bda-9d3e-f8bf13c27f00"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("e4863da0-3e5c-4431-9dfa-551c4ef94c56"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("e4863da0-3e5c-4431-9dfa-551c4ef94c56"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("e4863da0-3e5c-4431-9dfa-551c4ef94c56"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("e4863da0-3e5c-4431-9dfa-551c4ef94c56"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("fb467bd5-82b5-4ead-91c0-9eb4170a49d4"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("fc9ea8ee-18c0-463e-b208-5b82657999c5"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("fc9ea8ee-18c0-463e-b208-5b82657999c5"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("fc9ea8ee-18c0-463e-b208-5b82657999c5"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("fc9ea8ee-18c0-463e-b208-5b82657999c5"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("fc9ea8ee-18c0-463e-b208-5b82657999c5"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("fc9ea8ee-18c0-463e-b208-5b82657999c5"), 2020, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("fc9ea8ee-18c0-463e-b208-5b82657999c5"), 2021, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("ffbc275f-ea62-4f58-a600-cd8a0ea8c3ed"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("ffbc275f-ea62-4f58-a600-cd8a0ea8c3ed"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("ffbc275f-ea62-4f58-a600-cd8a0ea8c3ed"), 2017, true, true, true, true, true, true, true, true, true, true, true, true }
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
