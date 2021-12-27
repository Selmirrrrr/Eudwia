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
                    State = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
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
                columns: new[] { "Id", "BirthDate", "City", "CountryId", "Email", "Firstname", "HouseNumber", "Language", "Lastname", "MemberSince", "PhoneNumber", "State", "StreetLine1", "StreetLine2", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("0e49838e-092b-4dcc-9500-d16d267c05ad"), new DateOnly(1963, 9, 25), "La Rochelle", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Béatrice", "5", 2, "Garcia", new DateOnly(2019, 12, 7), null, "VD", "4178 Place des Francs-Bourgeois", "1 étage", "67909" },
                    { new Guid("208f0402-df0d-493d-9c25-f3e8b1173033"), new DateOnly(1992, 9, 18), "Tourcoing", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Fortunée", "898", 0, "Riviere", new DateOnly(2018, 9, 16), null, "VD", "025 Voie Du Sommerard", "6 étage", "00463" },
                    { new Guid("225c86ba-b89e-4316-89be-29cfee4a69d5"), new DateOnly(1984, 1, 28), "Avignon", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Éleuthère", "85", 1, "Dufour", new DateOnly(2016, 12, 10), null, "VD", "5980 Avenue Molière", "Apt. 443", "63965" },
                    { new Guid("229cfa30-1b50-45b9-b79d-7fe3c786f9af"), new DateOnly(1986, 8, 19), "Hyères", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Norbert", "312", 0, "Faure", new DateOnly(2017, 9, 13), null, "VD", "268 Impasse Monsieur-le-Prince", "Apt. 306", "41583" },
                    { new Guid("26cd5370-da2d-406a-a0e8-d6bf0a1a2590"), new DateOnly(1972, 2, 5), "Nice", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Vincent", "86", 1, "Nguyen", new DateOnly(2013, 8, 17), null, "VD", "1801 Avenue Lepic", "Apt. 212", "71170" },
                    { new Guid("43ced5f0-f418-4813-814b-ba21258fd954"), new DateOnly(1965, 9, 24), "Colmar", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Joëlle", "95", 0, "Guillaume", new DateOnly(2017, 3, 19), null, "VD", "595 Allée de la Ferronnerie", "Apt. 217", "29154" },
                    { new Guid("479b7e46-ddf8-4e15-94c0-bafe4a45ed4d"), new DateOnly(1968, 6, 23), "Levallois-Perret", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Cassien", "8669", 1, "Dumont", new DateOnly(2015, 7, 16), null, "VD", "7 Quai d'Alésia", "Apt. 205", "22032" },
                    { new Guid("47d4f027-0457-4462-a285-edfe5b7edfbc"), new DateOnly(1955, 7, 15), "Ajaccio", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Hildebert", "5", 1, "Blanchard", new DateOnly(2020, 11, 25), null, "VD", "6 Boulevard Du Sommerard", "6 étage", "88035" },
                    { new Guid("4900912d-f3c7-4bc5-a830-6ff58d514f3c"), new DateOnly(1970, 4, 23), "Montauban", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Céleste", "55", 0, "Thomas", new DateOnly(2013, 3, 6), null, "VD", "563 Allée de Tilsitt", "Apt. 107", "50139" },
                    { new Guid("676ee4b7-4109-42a0-b01b-e41eeb0328e6"), new DateOnly(1980, 3, 11), "Cayenne", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Ismérie", "060", 0, "Louis", new DateOnly(2013, 11, 19), null, "VD", "1535 Boulevard de Presbourg", "6 étage", "44931" },
                    { new Guid("75c2b1aa-900a-47c9-8c69-1af3cbcf5a56"), new DateOnly(1976, 4, 11), "Toulon", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Guyot", "7713", 2, "Joly", new DateOnly(2017, 3, 27), null, "VD", "248 Place Molière", "Apt. 511", "78256" },
                    { new Guid("95438a56-fa63-4a1b-9352-2b684b3358f7"), new DateOnly(1985, 8, 26), "Brest", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Brunehaut", "4198", 1, "Simon", new DateOnly(2014, 6, 18), null, "VD", "60 Place d'Abbeville", "Apt. 996", "24532" },
                    { new Guid("a451e473-9af9-4c97-949f-17cd687c5ce4"), new DateOnly(1977, 1, 12), "Cholet", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Job", "125", 2, "Roux", new DateOnly(2012, 11, 20), null, "VD", "70 Place de la Harpe", "0 étage", "29362" },
                    { new Guid("b4e96782-f1bc-40c2-b344-9e8ea6b71113"), new DateOnly(1974, 9, 4), "Ivry-sur-Seine", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Christian", "0", 1, "Fleury", new DateOnly(2018, 3, 20), null, "VD", "0 Rue de Presbourg", "Apt. 834", "17786" },
                    { new Guid("bda8105f-a864-4066-8b1b-c59dc9a75ed1"), new DateOnly(1992, 7, 23), "Strasbourg", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Clémentine", "6", 2, "Gauthier", new DateOnly(2012, 7, 30), null, "VD", "0913 Impasse Pastourelle", "4 étage", "04264" },
                    { new Guid("c5504494-1659-4f7f-88fa-9cfbf352bdef"), new DateOnly(1965, 4, 29), "Saint-Denis", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Alphonse", "6", 0, "Joly", new DateOnly(2014, 10, 26), null, "VD", "623 Allée de la Huchette", "4 étage", "76432" },
                    { new Guid("da60fe9b-cff2-47d2-98a7-08887f4fc53f"), new DateOnly(1987, 1, 14), "Aulnay-sous-Bois", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Mamert", "325", 2, "Gauthier", new DateOnly(2014, 1, 13), null, "VD", "59 Impasse de Solférino", "Apt. 243", "33473" },
                    { new Guid("e02387b9-706b-4efb-9749-1b58f6e0b7e1"), new DateOnly(1962, 3, 15), "Bourges", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Annibal", "330", 0, "Schneider", new DateOnly(2016, 7, 18), null, "VD", "046 Avenue de la Bûcherie", "Apt. 187", "18181" },
                    { new Guid("f0cdf413-7b73-4f2f-aa50-5e4b5ba45e40"), new DateOnly(1970, 8, 16), "Poitiers", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Gontran", "105", 2, "Cousin", new DateOnly(2015, 11, 22), null, "VD", "91 Rue de Presbourg", "Apt. 902", "96986" },
                    { new Guid("f9708a8e-e1ac-4953-8aa3-d60822eaa359"), new DateOnly(1969, 8, 17), "Villeneuve-d'Ascq", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), null, "Gislebert", "998", 0, "Arnaud", new DateOnly(2016, 12, 17), null, "VD", "6828 Voie des Panoramas", "Apt. 190", "21667" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "MemberId", "Note", "PaymentDate", "PaymentType" },
                values: new object[,]
                {
                    { new Guid("005e13ec-559a-4d0b-825b-3e778cfa78b3"), 0m, new Guid("75c2b1aa-900a-47c9-8c69-1af3cbcf5a56"), "Sint consequuntur totam et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("00aa866b-b185-49f2-af46-5a6c4b25d898"), 0m, new Guid("43ced5f0-f418-4813-814b-ba21258fd954"), "Necessitatibus odit voluptatem. In impedit unde.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("01f0aa22-c82d-4471-9d48-7dd1dc166a95"), 0m, new Guid("4900912d-f3c7-4bc5-a830-6ff58d514f3c"), "Sunt qui culpa voluptatem suscipit quae quo. Dignissimos iusto molestiae. Dolorem temporibus molestiae ab voluptatem eos corporis facilis. Repellat in tenetur consectetur nostrum ab quaerat quam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("04d67da1-e1a8-42ff-a286-68a1a11f3a26"), 0m, new Guid("e02387b9-706b-4efb-9749-1b58f6e0b7e1"), "Nihil explicabo ipsum dolorum tempora ipsa nisi occaecati.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("062e5048-8e1c-474f-981f-1b0241cccbf3"), 0m, new Guid("47d4f027-0457-4462-a285-edfe5b7edfbc"), "Iste iure rerum quod facere est. Modi corporis ea eos consequatur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("06818896-1abd-4643-8678-51ba660dc9e8"), 0m, new Guid("26cd5370-da2d-406a-a0e8-d6bf0a1a2590"), "Nisi dolorum qui et illum eum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("07e6c69b-0a92-41d9-8f75-7707d2ac89a0"), 0m, new Guid("b4e96782-f1bc-40c2-b344-9e8ea6b71113"), "Temporibus rerum ut ullam qui. Quaerat vero earum excepturi. Omnis delectus animi nobis odit. Officiis eaque harum corrupti deserunt sunt qui dolores.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("07f68561-44a8-4055-b078-afd2cf0d6dfd"), 0m, new Guid("676ee4b7-4109-42a0-b01b-e41eeb0328e6"), "Et voluptatem autem eos perferendis libero possimus exercitationem ipsa. Quia natus illum. Et dolorem voluptatem sed ex esse. Beatae aperiam quis consectetur ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("0b8190c2-2b49-4ecc-8782-2f9c4c42acb5"), 0m, new Guid("c5504494-1659-4f7f-88fa-9cfbf352bdef"), "Ut in consectetur qui. Consequatur consequatur ullam est non aut. Adipisci molestias animi ut perspiciatis iste nobis qui necessitatibus. Laborum consectetur debitis itaque dolores incidunt.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("0c0e51aa-686c-4f5c-ae04-faa5e08f6c05"), 0m, new Guid("b4e96782-f1bc-40c2-b344-9e8ea6b71113"), "Dolores excepturi accusamus mollitia dolores.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("10678f04-838f-44ae-832c-0c605d4ee9ca"), 0m, new Guid("229cfa30-1b50-45b9-b79d-7fe3c786f9af"), "Laborum doloribus mollitia dicta quos iure officiis. Doloremque sequi eligendi accusamus occaecati.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("116f5dd1-4edc-44c2-a748-9e0d773fa700"), 0m, new Guid("229cfa30-1b50-45b9-b79d-7fe3c786f9af"), "Non unde qui rerum in. Ea dolor nobis sunt dolor id ut itaque laudantium. Perspiciatis modi impedit et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("12d199bf-552d-41c1-b00b-0824889685b4"), 0m, new Guid("f0cdf413-7b73-4f2f-aa50-5e4b5ba45e40"), "Explicabo beatae at nobis consequatur nisi. Tempore mollitia occaecati. Aut ratione quisquam quo dicta repudiandae iusto nam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("12f3c7ff-e53b-4b43-9f62-46d0222e3acb"), 0m, new Guid("b4e96782-f1bc-40c2-b344-9e8ea6b71113"), "Quis sunt voluptate tempore qui quia cupiditate adipisci dolorem. Impedit culpa architecto voluptas voluptates veritatis inventore. Molestiae sed dolores iure et. Voluptates nisi sed facilis quasi esse non eos temporibus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("143a2abb-b404-445b-8781-e631c1a0985c"), 0m, new Guid("26cd5370-da2d-406a-a0e8-d6bf0a1a2590"), "Fugit et suscipit provident quia. Est error dicta voluptas voluptates laborum voluptatem magnam voluptatem. Necessitatibus qui aliquid facere. A tempora modi et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("16424d0e-17bb-4562-b45c-5df5e04271d7"), 0m, new Guid("75c2b1aa-900a-47c9-8c69-1af3cbcf5a56"), "Voluptatem quam cumque minus vel harum ut aut. Et cum deleniti.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("1675aaea-ee24-4c19-b290-d7fe3de145ea"), 0m, new Guid("f0cdf413-7b73-4f2f-aa50-5e4b5ba45e40"), "Non provident dolorem rerum consequatur libero nihil nulla. Ut ad dignissimos ut et accusantium odit rerum. Illo iusto delectus voluptatem error molestiae quo est. Magni minima est libero vero corrupti rerum harum architecto.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("16baa2ca-743d-4111-80e3-0980b5dc77a5"), 0m, new Guid("676ee4b7-4109-42a0-b01b-e41eeb0328e6"), "Rerum ut aut ea distinctio molestiae alias labore a. Molestias dicta dolores quisquam optio molestias consequatur perspiciatis. Possimus sed rerum sint aspernatur inventore natus modi quos. Ut repudiandae facere.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("1890f951-4da7-4fe8-9553-c796f1647d49"), 0m, new Guid("0e49838e-092b-4dcc-9500-d16d267c05ad"), "Facere laudantium hic dicta quasi. Velit officia harum delectus vitae. Voluptatum laudantium repellat voluptatibus cumque.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("18da6538-26a3-4999-a0b2-170f3b16d579"), 0m, new Guid("47d4f027-0457-4462-a285-edfe5b7edfbc"), "Eius velit qui accusantium non perspiciatis. Porro omnis natus sit aut id adipisci placeat. Voluptatem autem perspiciatis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("18f89c0f-1e85-4f73-a413-b0d980541538"), 0m, new Guid("479b7e46-ddf8-4e15-94c0-bafe4a45ed4d"), "Atque alias qui. Reiciendis quia accusantium possimus adipisci ut asperiores facere possimus quos. Totam et aut laudantium. Quasi eius et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("19cf8674-4c02-4ba5-8ac4-09ecf5e3d6dd"), 0m, new Guid("479b7e46-ddf8-4e15-94c0-bafe4a45ed4d"), "Occaecati veritatis ut vel quibusdam et nisi est. Doloremque ipsam velit nihil similique modi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("1a1fafbf-bcba-4960-b340-a8438de67ae8"), 0m, new Guid("75c2b1aa-900a-47c9-8c69-1af3cbcf5a56"), "Minima saepe dolorem nam. Qui exercitationem sit fugit. Quidem possimus eligendi nobis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("1a6722b1-43d8-411c-9712-c5c74b7bd30a"), 0m, new Guid("225c86ba-b89e-4316-89be-29cfee4a69d5"), "Saepe eveniet autem voluptatem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("1b283ea9-c22b-48d5-a51e-3c28a3b73c97"), 0m, new Guid("f0cdf413-7b73-4f2f-aa50-5e4b5ba45e40"), "Quidem voluptatem occaecati repellat ut. Quibusdam cumque autem ipsum excepturi eos quidem est nihil. Ut incidunt in vel. Ipsam debitis sed.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("1b901ce6-52f9-4a6a-8a87-29243f2d8df9"), 0m, new Guid("4900912d-f3c7-4bc5-a830-6ff58d514f3c"), "Harum et est ratione a nemo.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("1d1da19c-d41e-4313-9f04-ed48ba9d85cb"), 0m, new Guid("bda8105f-a864-4066-8b1b-c59dc9a75ed1"), "Nemo recusandae tempore hic quo est. Ea commodi est facilis soluta ullam eligendi ipsam. Totam eius voluptatem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("1e511e76-fa42-4e65-9dfc-6f4322fba2a9"), 0m, new Guid("47d4f027-0457-4462-a285-edfe5b7edfbc"), "Odio at dolorum. Aperiam voluptatum accusamus quas. Atque est et ex rerum dolore in officiis magnam et. Exercitationem ipsum nam neque ea quibusdam veritatis debitis eum nemo.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("1e5555d5-f3fd-47f2-bca2-3b983a40f2bd"), 0m, new Guid("f9708a8e-e1ac-4953-8aa3-d60822eaa359"), "Asperiores ad aut. Nulla at a deserunt qui minima. Soluta quia ea voluptate maiores. In autem similique.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("2075a9a0-e827-44c0-9ac5-bb05b0990018"), 0m, new Guid("26cd5370-da2d-406a-a0e8-d6bf0a1a2590"), "Velit vero sint ipsam at dicta. Qui maiores dolores. Debitis voluptas quo nemo repellat. Molestiae accusantium a aut voluptatem iusto ipsum voluptate minus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("219ad877-3100-4ce0-b230-d9fc209b0981"), 0m, new Guid("0e49838e-092b-4dcc-9500-d16d267c05ad"), "Error rerum debitis vero eveniet a inventore nulla distinctio doloribus. Vero omnis et occaecati harum illum distinctio. Laboriosam quisquam velit. Qui aliquid reprehenderit ut optio excepturi dolor.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("2359f756-c6fa-4269-9877-743a71e8dc63"), 0m, new Guid("da60fe9b-cff2-47d2-98a7-08887f4fc53f"), "Sint sed voluptatem nobis veritatis. Eveniet sint similique voluptates consequuntur qui facilis sit eos.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("2359fdff-233e-485e-bb29-85733b8f6079"), 0m, new Guid("95438a56-fa63-4a1b-9352-2b684b3358f7"), "Aliquam et enim hic sed laboriosam sint officiis. Repellendus et quibusdam ducimus voluptatum aspernatur ut omnis eum asperiores.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("25a2d150-4ace-4e14-b523-e85ee3ed80be"), 0m, new Guid("4900912d-f3c7-4bc5-a830-6ff58d514f3c"), "Sint aut recusandae ut illo fuga doloribus. Cumque vitae id sapiente est. Porro placeat quos et placeat sapiente similique.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("25d52669-e39a-46f4-853a-97c643b96fb7"), 0m, new Guid("e02387b9-706b-4efb-9749-1b58f6e0b7e1"), "Vitae possimus assumenda occaecati ut rerum officiis. In nihil ut nulla dolorem quas sunt.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("26b0e48d-ab10-4ad3-9ba0-b002b0a1ae40"), 0m, new Guid("f9708a8e-e1ac-4953-8aa3-d60822eaa359"), "Temporibus omnis quaerat voluptatem consectetur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("2861ee53-b0eb-4856-b5e6-e7beba42860d"), 0m, new Guid("a451e473-9af9-4c97-949f-17cd687c5ce4"), "Sit minus maiores esse qui vitae ut aut. Ut inventore tenetur inventore est. Vitae assumenda architecto distinctio est voluptatem sit. Eos deleniti ad facere quam illo qui labore repellendus numquam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("28dc41b7-1846-409c-8515-a7178935e891"), 0m, new Guid("75c2b1aa-900a-47c9-8c69-1af3cbcf5a56"), "Corrupti repudiandae reiciendis excepturi earum eligendi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("2935bbf1-6cf0-450c-ba83-366035ea581a"), 0m, new Guid("bda8105f-a864-4066-8b1b-c59dc9a75ed1"), "Fugit laboriosam magni placeat eaque occaecati vel. Sint velit asperiores eligendi asperiores nulla voluptas eius.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("2a73eedc-d67c-488d-84b0-ef4d464446e1"), 0m, new Guid("4900912d-f3c7-4bc5-a830-6ff58d514f3c"), "Earum in aperiam adipisci blanditiis a. Fugit consectetur hic ad eveniet repellat enim saepe quis magnam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("2a829620-635c-464b-8179-bf6935e3f48e"), 0m, new Guid("229cfa30-1b50-45b9-b79d-7fe3c786f9af"), "Fugiat consequatur id sunt ea alias et autem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("2d04f725-c24c-4c98-8d39-ffb7bec0c86c"), 0m, new Guid("676ee4b7-4109-42a0-b01b-e41eeb0328e6"), "Voluptas mollitia ipsa qui voluptatem aliquid voluptatum deleniti hic. Voluptatum omnis quae facere magni.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("2e36fc2e-c27d-4d16-a46d-3d9b6d4937db"), 0m, new Guid("f0cdf413-7b73-4f2f-aa50-5e4b5ba45e40"), "Omnis laborum voluptas. Temporibus optio molestiae.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("2fa2815a-36de-40b8-a17e-fb1d30b75063"), 0m, new Guid("75c2b1aa-900a-47c9-8c69-1af3cbcf5a56"), "Culpa consequatur laboriosam reprehenderit repudiandae. Deserunt asperiores minus dolores. Qui aut ipsa necessitatibus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("302288c7-fc12-4c69-ba0d-0cb9671aab64"), 0m, new Guid("bda8105f-a864-4066-8b1b-c59dc9a75ed1"), "Ipsam quisquam aspernatur sed molestiae magni ipsam. Nesciunt quisquam omnis officiis cumque illo. Non qui quia.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("314d2fca-57e8-495a-8c0b-a0f4bb84a04f"), 0m, new Guid("75c2b1aa-900a-47c9-8c69-1af3cbcf5a56"), "Exercitationem totam et et quo deleniti est earum rerum. Similique exercitationem id doloribus esse et. Repudiandae quis cum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("319e5014-c0ff-42f7-92bc-7c0a5f7a6f5d"), 0m, new Guid("f0cdf413-7b73-4f2f-aa50-5e4b5ba45e40"), "Quo voluptas earum rerum vitae atque corrupti. Labore sit modi quod et est necessitatibus a.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("31ad679c-a6a6-425b-988c-2790cb828e44"), 0m, new Guid("a451e473-9af9-4c97-949f-17cd687c5ce4"), "Cum neque provident sit quia.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("31daf8e0-fb0f-49a2-a8cd-b06ef19ecb47"), 0m, new Guid("26cd5370-da2d-406a-a0e8-d6bf0a1a2590"), "Dolorum tempore qui quod.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("3239f91d-1ed0-4427-9955-41595363079c"), 0m, new Guid("da60fe9b-cff2-47d2-98a7-08887f4fc53f"), "Porro iure pariatur veniam magni error. Esse assumenda deserunt neque libero. Omnis provident minima. Perspiciatis libero impedit quisquam eum et est delectus est.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("32da3197-66b6-45db-a376-ba9b5f88c0ff"), 0m, new Guid("225c86ba-b89e-4316-89be-29cfee4a69d5"), "Inventore rerum tempore sint.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("32e33634-23a5-4457-8583-ee0a5af62ff4"), 0m, new Guid("229cfa30-1b50-45b9-b79d-7fe3c786f9af"), "Corporis sint iusto aspernatur blanditiis nisi earum. Est id rem adipisci rerum qui.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("3308dc13-8d06-4fa4-b221-8aaf8db2477e"), 0m, new Guid("229cfa30-1b50-45b9-b79d-7fe3c786f9af"), "Consequatur officiis dignissimos voluptatem quam. Hic in laboriosam quisquam repudiandae praesentium magnam ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("338b1119-1a04-46dc-9159-8da44c02c493"), 0m, new Guid("f9708a8e-e1ac-4953-8aa3-d60822eaa359"), "Magni sed repellendus eum id dolorem. Aliquam nisi quae esse.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("33a03753-c6f5-490a-a13d-c6c9430750c4"), 0m, new Guid("26cd5370-da2d-406a-a0e8-d6bf0a1a2590"), "Non qui consequatur ut sunt. Provident aut voluptatem velit in velit pariatur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("36935bdf-b91a-4bcb-9cc6-78cb2649d51e"), 0m, new Guid("208f0402-df0d-493d-9c25-f3e8b1173033"), "Quam sed sint dolorem rerum earum consequatur autem. Cumque consectetur necessitatibus. Suscipit et ut perferendis. Nihil nam voluptatem itaque est.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("36bbf1ef-da5b-4c95-a32e-ddaf471999bc"), 0m, new Guid("c5504494-1659-4f7f-88fa-9cfbf352bdef"), "Illo omnis illum consequatur culpa veritatis nihil nostrum quas.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("384a006e-4e5b-4df4-8a20-446fc614ac7c"), 0m, new Guid("4900912d-f3c7-4bc5-a830-6ff58d514f3c"), "Debitis ut porro voluptates possimus officia cumque molestiae ut voluptatibus. Cumque voluptatem eos suscipit sed. Quia laboriosam facilis optio quia harum quo natus nam. Consequatur dolore aut corrupti.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("39fce9d2-f239-42e0-87e2-7cccc6ce919a"), 0m, new Guid("95438a56-fa63-4a1b-9352-2b684b3358f7"), "Fugiat ducimus eum numquam. Itaque est quae eos atque. Molestiae repellat voluptatem voluptatem quibusdam velit ipsam dolorem. Eos sed asperiores nostrum omnis facere dolorem ad aperiam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("3b064c22-5804-41f8-81cf-d413035dc8cd"), 0m, new Guid("bda8105f-a864-4066-8b1b-c59dc9a75ed1"), "Impedit quod reprehenderit quia omnis ut quas perspiciatis vel. Ut ut accusantium.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("3c42741c-599d-4979-a8eb-bb77bd298199"), 0m, new Guid("f9708a8e-e1ac-4953-8aa3-d60822eaa359"), "Non omnis tempore tempore sit veritatis illo libero necessitatibus sunt.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("3cdab3bc-4608-4574-b67c-6d69011b55e6"), 0m, new Guid("225c86ba-b89e-4316-89be-29cfee4a69d5"), "Voluptas assumenda tempore id. Vel quod vel modi. Sed explicabo veniam quia id qui aspernatur. Aut et veritatis unde.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("3e54a9f7-3706-4cbb-8294-96330e38e9c1"), 0m, new Guid("c5504494-1659-4f7f-88fa-9cfbf352bdef"), "Quas itaque quam facilis nesciunt ad ut molestiae reiciendis ut. Provident ut atque id voluptatem culpa est exercitationem minima modi. Quaerat possimus ipsam. Aut deleniti tenetur accusantium et quos.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("3f8f60e9-1f06-42fb-b860-b3cab414cc54"), 0m, new Guid("208f0402-df0d-493d-9c25-f3e8b1173033"), "Fugiat eveniet sed illum ipsa recusandae. Et corrupti qui cum. Sit consequatur fugiat corporis modi sit doloribus voluptas. Vel velit qui ut quaerat et reiciendis odio architecto vero.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("407aa462-974d-4d0c-95db-c23815b606e0"), 0m, new Guid("43ced5f0-f418-4813-814b-ba21258fd954"), "Cum placeat possimus. Qui laborum ipsa esse. Illum blanditiis in veniam ea quo molestiae nostrum et commodi. Doloribus molestiae ratione libero.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("414a119c-b163-42d9-be4f-8b4d028f014a"), 0m, new Guid("e02387b9-706b-4efb-9749-1b58f6e0b7e1"), "Est beatae dolores libero enim facilis. Aut quas sequi eaque tempora consequatur temporibus dolor quibusdam dolor. Similique voluptatum beatae laboriosam at numquam veniam ducimus et dolor. Quidem et voluptatem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("445dc222-0f36-48f0-be34-b5cd1e29f1bf"), 0m, new Guid("676ee4b7-4109-42a0-b01b-e41eeb0328e6"), "Et deleniti ut quo. Nihil eos vel et et ex.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("45185381-754f-4025-9c06-dcfac0003c43"), 0m, new Guid("da60fe9b-cff2-47d2-98a7-08887f4fc53f"), "Est voluptates delectus rem laborum modi voluptatibus ducimus doloremque sunt. Commodi odit optio dolores autem nostrum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("472f6e55-19ec-4293-aaab-55949c964785"), 0m, new Guid("225c86ba-b89e-4316-89be-29cfee4a69d5"), "Ut aut perferendis unde est. Quos pariatur iure unde laudantium dolor sequi odit. Consectetur eveniet excepturi sed dicta quae ut ad ipsum pariatur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("4766737e-85d4-4913-8a96-f72e3dff77a5"), 0m, new Guid("47d4f027-0457-4462-a285-edfe5b7edfbc"), "Eveniet accusamus tenetur sunt sint adipisci praesentium tempore mollitia.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("485582f4-496b-487f-873a-88e4c785dc59"), 0m, new Guid("26cd5370-da2d-406a-a0e8-d6bf0a1a2590"), "Ex dolorem et impedit. Temporibus maxime ut ut. Dolorem consequatur itaque esse laboriosam odio cum praesentium saepe ratione.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("48a95cdf-ba24-4799-b660-76750fe5ff08"), 0m, new Guid("da60fe9b-cff2-47d2-98a7-08887f4fc53f"), "Aliquam in quo sapiente magni iste optio repellat aliquid. Minima exercitationem asperiores est dolore. Incidunt inventore quas eius et ducimus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("49d9f5e6-84e8-4868-b561-eea8e7106298"), 0m, new Guid("f0cdf413-7b73-4f2f-aa50-5e4b5ba45e40"), "Consequatur rem perspiciatis unde iusto.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("49dcb9b3-ce74-435b-ac90-803e07d6f6fe"), 0m, new Guid("47d4f027-0457-4462-a285-edfe5b7edfbc"), "Occaecati consequatur ut ab est qui similique et. Quae pariatur est dolor expedita.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("4c21363c-426d-49ee-8548-3455d2595a76"), 0m, new Guid("95438a56-fa63-4a1b-9352-2b684b3358f7"), "Maxime est rerum nihil et molestias quisquam ea soluta molestiae. Veniam quam quaerat. Ut atque vel. Eius ut quas nam quod accusantium deleniti debitis et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("4dbe5572-73f4-45fc-8be4-a5c7bb5e9666"), 0m, new Guid("229cfa30-1b50-45b9-b79d-7fe3c786f9af"), "Enim quo aut rerum enim aperiam facere. Rem impedit sunt aliquam officiis deserunt sequi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("4e8c7175-b061-444f-9de9-dd0dbd8994ce"), 0m, new Guid("225c86ba-b89e-4316-89be-29cfee4a69d5"), "Quis veritatis placeat at iste voluptas odio. Aut harum dolorem ab in est dignissimos id repellendus omnis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("54501f84-ea57-498e-8bb3-24f8e60d82ed"), 0m, new Guid("43ced5f0-f418-4813-814b-ba21258fd954"), "Et recusandae nisi et corrupti. Quaerat ea iure perspiciatis quo enim non autem tempora. Ratione iure et et sit ea eaque quasi corporis autem. Consectetur et voluptas et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("545f19d7-8668-4e40-b7e5-e546b8d89032"), 0m, new Guid("95438a56-fa63-4a1b-9352-2b684b3358f7"), "Dicta nostrum autem. Maiores dignissimos modi. Quia nulla repudiandae vitae facere nihil voluptates ad dolorem. Eum eligendi ut reprehenderit quasi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("594cf5dc-2dff-4477-b07d-ff265510d2c8"), 0m, new Guid("43ced5f0-f418-4813-814b-ba21258fd954"), "Fugit ab aliquam eius non impedit repellat tempora ea et. Laborum eius est minima dolorem est aspernatur. Neque nihil non est sed. Minima iure est cupiditate dolores officia sunt minus beatae.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("5c8552ea-9cc3-4570-b9f5-3695e15483b0"), 0m, new Guid("47d4f027-0457-4462-a285-edfe5b7edfbc"), "Quae odio dolores quibusdam. Maxime eaque porro vel veniam inventore. Ut quo dolorem. Nesciunt qui numquam quibusdam nihil cumque occaecati ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("5cca73ff-f911-426e-b20f-4ec54d7e99bf"), 0m, new Guid("208f0402-df0d-493d-9c25-f3e8b1173033"), "Magni error commodi est mollitia. Autem voluptatem animi sed praesentium eveniet. Consequuntur corrupti id mollitia.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("5dcdb527-1160-45f6-a6e4-9ea3e7b0dc0d"), 0m, new Guid("225c86ba-b89e-4316-89be-29cfee4a69d5"), "Tempore et ut facere ut et nihil in tempore. Eveniet asperiores aut quos error velit repellendus voluptate animi sapiente.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("5f38c9d9-c6d1-4444-9d21-903397324dab"), 0m, new Guid("229cfa30-1b50-45b9-b79d-7fe3c786f9af"), "Omnis sunt dolorem recusandae animi quasi placeat non. Sint sint ut repellat. In ducimus molestiae reiciendis. Rerum saepe autem eius.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("5ff08130-6814-498d-9ef0-23954b7ab404"), 0m, new Guid("47d4f027-0457-4462-a285-edfe5b7edfbc"), "Consectetur molestiae ducimus culpa asperiores voluptatem at est ut. Non aut sed odit quaerat aliquid enim iure.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("5ffae119-6da3-4c3a-b445-6d8f532980eb"), 0m, new Guid("4900912d-f3c7-4bc5-a830-6ff58d514f3c"), "Harum perferendis quisquam saepe odio itaque veritatis. Nihil recusandae et fugit nulla quis ut amet ducimus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("620400ca-0879-44cf-958c-15a5f8c41ab5"), 0m, new Guid("a451e473-9af9-4c97-949f-17cd687c5ce4"), "Laborum ducimus quam ea aut porro quia culpa. Delectus maxime dolor iusto sit id enim doloribus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("63a6a909-cf81-4f09-be00-970ffebff94d"), 0m, new Guid("b4e96782-f1bc-40c2-b344-9e8ea6b71113"), "Perspiciatis deserunt qui sequi occaecati et temporibus quasi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("6407be54-f0ad-4e6e-91cc-8be1deb972bb"), 0m, new Guid("b4e96782-f1bc-40c2-b344-9e8ea6b71113"), "Sapiente nulla nemo illum vel distinctio. Accusantium voluptates aperiam hic dolores quia ipsam sed delectus corporis. Aut voluptatem consequatur asperiores qui id deserunt. Ducimus est enim.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("66378eb5-0025-43c1-a7e7-5a05d6fa1ef0"), 0m, new Guid("bda8105f-a864-4066-8b1b-c59dc9a75ed1"), "Temporibus quam eos dolorum et impedit praesentium quae unde velit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("686f90f7-0aad-43a2-87a2-d3f720fa4b91"), 0m, new Guid("479b7e46-ddf8-4e15-94c0-bafe4a45ed4d"), "Suscipit repellat illo eligendi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("6ba6b2ad-f5a3-4309-8364-932930e525db"), 0m, new Guid("4900912d-f3c7-4bc5-a830-6ff58d514f3c"), "Veritatis expedita quis odio aspernatur eos neque voluptate doloribus id.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("6baded41-e405-4a33-8f49-450d335039ec"), 0m, new Guid("676ee4b7-4109-42a0-b01b-e41eeb0328e6"), "Consectetur alias enim temporibus consequatur quis molestias et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("6d783197-2f5a-48f7-a62b-9fa97c0ce3c6"), 0m, new Guid("479b7e46-ddf8-4e15-94c0-bafe4a45ed4d"), "Consequuntur voluptatum et qui alias labore aut et deleniti. Aut nesciunt neque quis molestias unde fuga quis qui sit. Soluta qui debitis maiores dolor et vel fuga et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("6d94a31f-592d-411f-a3fb-50039240c050"), 0m, new Guid("a451e473-9af9-4c97-949f-17cd687c5ce4"), "Sed veniam et atque facilis placeat. Quia a sit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("701fd0ce-316c-4f18-9e96-f8fb609b4fb4"), 0m, new Guid("47d4f027-0457-4462-a285-edfe5b7edfbc"), "Distinctio sint qui dolorem et veritatis ut sapiente. Consequatur voluptas et non tempore praesentium voluptatem expedita.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("705d9ac6-e173-41cb-a57f-645439734091"), 0m, new Guid("c5504494-1659-4f7f-88fa-9cfbf352bdef"), "Occaecati ab velit numquam omnis autem tempora. Voluptas nulla laudantium. Nihil et molestiae quam quia. Harum sint laboriosam odit ut exercitationem a.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("717f025b-b983-4bcb-baa4-9f084c1707b8"), 0m, new Guid("0e49838e-092b-4dcc-9500-d16d267c05ad"), "Ad voluptatum repellat mollitia. Numquam eius corporis iure ratione non hic aliquam. Cumque quo adipisci impedit consequatur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("7236bd96-1489-46f0-9360-c7d186148a34"), 0m, new Guid("225c86ba-b89e-4316-89be-29cfee4a69d5"), "Cupiditate eligendi labore qui. Facilis temporibus sit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("77aeb09b-95d9-4a51-830a-30a139aa5e3e"), 0m, new Guid("f9708a8e-e1ac-4953-8aa3-d60822eaa359"), "Velit autem aut ipsum id ea maxime laudantium eligendi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("7abf1191-ad12-4e50-9386-cab601433ae2"), 0m, new Guid("a451e473-9af9-4c97-949f-17cd687c5ce4"), "Qui possimus aut consequatur cupiditate voluptatem illum. Et assumenda quisquam debitis omnis laboriosam eum. Assumenda accusantium asperiores iure est quas perferendis totam voluptas.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("7b34f793-bcfa-4185-a4c7-9ef47309e768"), 0m, new Guid("26cd5370-da2d-406a-a0e8-d6bf0a1a2590"), "Impedit ea porro expedita dignissimos et iusto explicabo minima culpa. Autem vel vero laboriosam enim sint tempore.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("7e185645-8df0-49b8-b1cf-daabca39f024"), 0m, new Guid("208f0402-df0d-493d-9c25-f3e8b1173033"), "Libero omnis distinctio consequatur ea delectus voluptas. Velit delectus minus impedit vel.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("7e4bf23b-09bc-4f58-bcc8-cd71483013bb"), 0m, new Guid("225c86ba-b89e-4316-89be-29cfee4a69d5"), "Sunt error ipsum impedit. Ut eveniet molestiae eos neque rerum dignissimos expedita deserunt. Molestiae aut maxime minus quae voluptas optio expedita. Sed labore nisi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("7fb6b38d-f903-4436-b1d4-6ffee05f6bc6"), 0m, new Guid("225c86ba-b89e-4316-89be-29cfee4a69d5"), "Consequatur ad minus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("80faea1f-4844-47d8-95b2-536f0dff89e3"), 0m, new Guid("f0cdf413-7b73-4f2f-aa50-5e4b5ba45e40"), "Omnis et cumque et expedita aut nihil. Laborum et sed rem quasi ut. Eum dolorem qui.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("82e31025-0283-4484-9957-b0a086ef1784"), 0m, new Guid("229cfa30-1b50-45b9-b79d-7fe3c786f9af"), "Cumque ut impedit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("830460a3-cca5-4e9c-b21e-14479ff90586"), 0m, new Guid("43ced5f0-f418-4813-814b-ba21258fd954"), "Provident impedit eligendi. Quaerat quo qui magni accusamus sed pariatur iusto. Corrupti dolores magnam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("84850539-5668-46ca-8c75-b182c1d10bc8"), 0m, new Guid("a451e473-9af9-4c97-949f-17cd687c5ce4"), "Nostrum sed fugiat laboriosam rem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("8cd34de1-6f60-4ce6-bcc9-63ab690cb7b4"), 0m, new Guid("da60fe9b-cff2-47d2-98a7-08887f4fc53f"), "Blanditiis labore repellendus magni tempore voluptatem placeat sit doloribus. Et perferendis corporis voluptatem quidem quasi impedit tenetur a accusantium. Laboriosam tempore repellendus voluptatem voluptas esse et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("8e929077-4c59-4acf-aa93-c268800b8e85"), 0m, new Guid("0e49838e-092b-4dcc-9500-d16d267c05ad"), "Quisquam alias sit molestias aut. Expedita autem error a repudiandae culpa sint in fuga.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("92bbc9fc-9f89-4c6f-bc22-d38f5152a188"), 0m, new Guid("0e49838e-092b-4dcc-9500-d16d267c05ad"), "In ex repellat illo sunt voluptas consequatur dignissimos illum. Aut temporibus neque veritatis dolores quis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("92e6577e-11ec-4e23-9dff-9b0220e4e6d7"), 0m, new Guid("676ee4b7-4109-42a0-b01b-e41eeb0328e6"), "Consequuntur dolorem architecto et tempora quibusdam dolorem nemo repudiandae ipsum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("9389a9a8-78b0-4e19-8a05-828a116aaad6"), 0m, new Guid("0e49838e-092b-4dcc-9500-d16d267c05ad"), "Officia harum cupiditate. Mollitia sit dolor perspiciatis maiores ea recusandae. Qui vero eum quis voluptatibus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("96374831-8106-4b2a-a38d-46bc1279459a"), 0m, new Guid("26cd5370-da2d-406a-a0e8-d6bf0a1a2590"), "Harum assumenda sequi at vero voluptatem excepturi quo dolore.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("995d7745-770c-44cc-9252-822c2f7eb848"), 0m, new Guid("208f0402-df0d-493d-9c25-f3e8b1173033"), "Ipsa voluptatibus quidem ut voluptas unde vero est laudantium. Nihil quis veritatis. Quos ipsum voluptatem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("9bf9143f-af21-4198-b474-3138fe4f4f2d"), 0m, new Guid("208f0402-df0d-493d-9c25-f3e8b1173033"), "A molestias corrupti et. Non eos voluptatem. Omnis qui aspernatur sed nisi consequuntur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("9c863516-b01e-49fb-9bfd-b7b49b47a5ae"), 0m, new Guid("479b7e46-ddf8-4e15-94c0-bafe4a45ed4d"), "Provident quis perspiciatis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("9cbf5547-13dc-4ed6-b251-cdc8bc319206"), 0m, new Guid("75c2b1aa-900a-47c9-8c69-1af3cbcf5a56"), "Non praesentium eligendi quia in et deserunt. Necessitatibus commodi recusandae molestiae et provident eaque porro voluptatem. Expedita est cupiditate. Quia eos quisquam ex.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("9f06b7cf-3744-4229-b24e-0fff3ce3ce49"), 0m, new Guid("75c2b1aa-900a-47c9-8c69-1af3cbcf5a56"), "Tempore veritatis aperiam rerum aliquid dolores laboriosam voluptas. Excepturi adipisci non fuga qui libero earum eum occaecati exercitationem. Repellendus sint quia numquam voluptatibus. Nobis impedit pariatur mollitia a dicta illo id voluptatem voluptas.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("a0595217-f538-41fa-9fe3-a6b19dfe47da"), 0m, new Guid("95438a56-fa63-4a1b-9352-2b684b3358f7"), "Ducimus optio quia id et fuga et et quas.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("a1471921-1d33-4835-bb66-c6b82d5f60fa"), 0m, new Guid("f9708a8e-e1ac-4953-8aa3-d60822eaa359"), "Provident nisi repellat sunt. Fugit non id earum enim enim ipsum tempore.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("a269295b-dcdc-42aa-bdf6-206189143747"), 0m, new Guid("b4e96782-f1bc-40c2-b344-9e8ea6b71113"), "Consequatur dolorem aliquam aperiam praesentium architecto. Ad esse pariatur ea sit adipisci dignissimos aut laborum consequatur. Aliquid nam occaecati veritatis voluptatibus et est adipisci magnam neque. Voluptates aspernatur quas.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("a37e433a-7884-407d-bde0-e4a5b4210b95"), 0m, new Guid("f9708a8e-e1ac-4953-8aa3-d60822eaa359"), "Voluptate et dolor natus qui deleniti quibusdam est magni. Molestiae delectus modi quasi et autem optio quo voluptatem consectetur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("a4275a57-1ff9-4c9e-a7da-a699316aa0e8"), 0m, new Guid("e02387b9-706b-4efb-9749-1b58f6e0b7e1"), "Quod reprehenderit corporis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("a4482c77-8d51-43bd-9771-cffcb579778a"), 0m, new Guid("75c2b1aa-900a-47c9-8c69-1af3cbcf5a56"), "In sint consequatur soluta consequatur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("a5165971-55cb-4f2c-9685-1a34fd3487f5"), 0m, new Guid("229cfa30-1b50-45b9-b79d-7fe3c786f9af"), "Accusantium iste aliquid. Corporis quos ex et in et vel non debitis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("a54a1e68-56d6-45eb-b11d-1bdf98cf4029"), 0m, new Guid("f9708a8e-e1ac-4953-8aa3-d60822eaa359"), "Doloremque distinctio quia eum enim aut. Omnis et ea est alias.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("a598e990-4d76-4e5d-b9d5-53b1902e3af7"), 0m, new Guid("4900912d-f3c7-4bc5-a830-6ff58d514f3c"), "Eos ipsa voluptatem unde natus beatae omnis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("a72b5c85-2d76-4c00-aea3-32ce9a0aeaf2"), 0m, new Guid("208f0402-df0d-493d-9c25-f3e8b1173033"), "Sit natus explicabo vitae libero exercitationem doloremque ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("a7d47680-d4a3-4444-990c-2c9f54421f3b"), 0m, new Guid("a451e473-9af9-4c97-949f-17cd687c5ce4"), "Culpa aut soluta est inventore deserunt aut ut. Sit sit qui aspernatur aut iusto.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("a8b3bdb2-cfe2-447d-8928-f4a1eea1ad09"), 0m, new Guid("e02387b9-706b-4efb-9749-1b58f6e0b7e1"), "Neque est officiis natus cumque corporis nulla distinctio magnam non. Non ipsam non nihil delectus nostrum corporis impedit cum est. Natus distinctio dolor rerum sed ullam quia labore et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("a98d75f6-3643-4979-85a3-74f70e3c3443"), 0m, new Guid("43ced5f0-f418-4813-814b-ba21258fd954"), "Itaque sunt ea quia enim voluptatem assumenda mollitia doloribus. Voluptas consequatur vel.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("ad121a43-0fbe-4b0c-88a2-1e99c3eaff8b"), 0m, new Guid("da60fe9b-cff2-47d2-98a7-08887f4fc53f"), "Vel eum est et ut. Ut deserunt velit sequi nemo necessitatibus aut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("ae256285-1a66-4baa-809b-fd707a811743"), 0m, new Guid("a451e473-9af9-4c97-949f-17cd687c5ce4"), "Culpa omnis quo magnam omnis mollitia. Officiis fuga nihil repellat ut ratione ea ipsa. Sit ducimus impedit beatae.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("b026b2f3-d3e2-49f6-a4a5-a00b6915e29c"), 0m, new Guid("bda8105f-a864-4066-8b1b-c59dc9a75ed1"), "Minima nihil ipsum qui tenetur illum reiciendis quidem. Expedita ullam amet doloremque adipisci nesciunt. Laudantium animi magni dolorem fuga non error. Ab et quisquam voluptas.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("b2ceafd8-8c6d-4799-8706-ded91417b3f7"), 0m, new Guid("f0cdf413-7b73-4f2f-aa50-5e4b5ba45e40"), "Minus et totam sunt aliquid possimus soluta. Deleniti laboriosam cum aliquid ratione libero. Dignissimos aspernatur libero unde minima dolores. Quo magni inventore sequi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("b459e7b4-aaaf-49fd-9d46-bb8ea0598f6a"), 0m, new Guid("208f0402-df0d-493d-9c25-f3e8b1173033"), "Sit qui magni doloremque aut consectetur. Porro nulla consequatur iure ea iste culpa facilis nisi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("b700072c-d099-49d5-8e9e-ad413c3a0d64"), 0m, new Guid("0e49838e-092b-4dcc-9500-d16d267c05ad"), "Inventore reiciendis dolorem nesciunt ab inventore. Dolorem laborum nobis atque sit est asperiores.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("b7fdbbd4-d144-4ef3-92d4-980f28171e5d"), 0m, new Guid("479b7e46-ddf8-4e15-94c0-bafe4a45ed4d"), "Omnis vitae rerum sit. Veritatis neque tempore perferendis qui sit voluptas.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("ba9fd68b-f934-42f4-9738-cde21e9f6695"), 0m, new Guid("4900912d-f3c7-4bc5-a830-6ff58d514f3c"), "Quas architecto omnis et et eum quod. Aut repudiandae veritatis deserunt quis molestias et. Et occaecati laudantium.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("bb8fdecf-0842-4ab3-97cd-3a2bb4e6fdd2"), 0m, new Guid("229cfa30-1b50-45b9-b79d-7fe3c786f9af"), "Eaque et accusantium est deleniti qui nisi quasi. Excepturi et dolorem. Dolor ipsam qui. Unde doloribus quod.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("bc16e037-79db-43e5-938d-7e4168cbcfb8"), 0m, new Guid("47d4f027-0457-4462-a285-edfe5b7edfbc"), "Sit eligendi officia voluptatem sint ratione a aliquam necessitatibus qui. Est tenetur cumque et quasi culpa sit. Sed aut facere ad. Quia quis nisi ea eos.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("bcc0b69c-eef2-44bf-b602-7d5cd4df09a0"), 0m, new Guid("c5504494-1659-4f7f-88fa-9cfbf352bdef"), "Quae aut doloribus totam iste incidunt tenetur illo rerum. At similique incidunt architecto debitis ipsam vel ratione. Maiores itaque maxime ducimus praesentium nihil enim vel. Rerum sit porro et minima.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("bdb0e708-f7ab-44c1-be3d-1ee12dc601d8"), 0m, new Guid("b4e96782-f1bc-40c2-b344-9e8ea6b71113"), "Nihil doloremque deserunt. Vero recusandae qui possimus quasi repellat et nobis qui distinctio. Ut in unde.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("be5f5be8-5b62-47a9-84d4-ddefd3a27520"), 0m, new Guid("0e49838e-092b-4dcc-9500-d16d267c05ad"), "A labore molestias rerum veritatis tempora eius.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("bfb023d4-243f-4026-b452-3b2d04336a30"), 0m, new Guid("479b7e46-ddf8-4e15-94c0-bafe4a45ed4d"), "Pariatur sapiente architecto aut nulla possimus id officia sapiente. Alias quisquam vero repellendus sunt tempora. Enim nihil enim.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("c03f971f-93ef-40fa-8a9b-e8bdc5deaa3c"), 0m, new Guid("26cd5370-da2d-406a-a0e8-d6bf0a1a2590"), "Sunt dolorem veritatis quaerat incidunt ex. Cum harum assumenda. Est nemo dolores expedita.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("c141ae3c-0e3e-4f25-9b78-9b93db4d6684"), 0m, new Guid("676ee4b7-4109-42a0-b01b-e41eeb0328e6"), "Sapiente voluptatem ut. Omnis ut et quis adipisci nihil ut unde qui. Aut vel expedita qui id facere nemo. Voluptas ullam quod.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("c1c190ba-a33d-48a2-a112-e79fd56fb501"), 0m, new Guid("a451e473-9af9-4c97-949f-17cd687c5ce4"), "Quod sit ducimus impedit consequatur. Velit minus qui ab reprehenderit iure cupiditate quibusdam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("c200baa7-1b06-4a6e-bf0e-d13070e9ed22"), 0m, new Guid("c5504494-1659-4f7f-88fa-9cfbf352bdef"), "Numquam dolorem quaerat ducimus eius sed voluptas suscipit qui. Libero repudiandae saepe ipsam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("c40a4cb3-4f45-4ee2-9c00-aa202da1fbd8"), 0m, new Guid("43ced5f0-f418-4813-814b-ba21258fd954"), "Ab commodi voluptatem vel aut corrupti dolorem. Dignissimos et repellat.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("c48376cf-3365-4a9d-9589-10f16df4f333"), 0m, new Guid("f9708a8e-e1ac-4953-8aa3-d60822eaa359"), "Deserunt aut cum amet.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("c5944d65-0ea8-433f-9f0b-8fbdd6d9e438"), 0m, new Guid("a451e473-9af9-4c97-949f-17cd687c5ce4"), "Ratione saepe ea quo omnis assumenda a vel distinctio quo.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("c7e589ec-4e0e-4944-804c-008d23e111a2"), 0m, new Guid("43ced5f0-f418-4813-814b-ba21258fd954"), "Non neque rerum. Distinctio voluptas placeat ut explicabo magni eaque iste quam. Veritatis sed modi rerum laboriosam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("c8d72a3e-5697-4287-8dd1-95ac20ff29b4"), 0m, new Guid("c5504494-1659-4f7f-88fa-9cfbf352bdef"), "Similique rerum sed laborum qui cum aut quis nemo est. Enim dolores dolorem ratione. Voluptas quia quod minima. Eum magni enim minima qui dolorum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("c9de347c-5665-4c72-a7d1-d6b840e8e8c6"), 0m, new Guid("e02387b9-706b-4efb-9749-1b58f6e0b7e1"), "Voluptatum dolores quod quasi soluta. Qui dolores quos nihil quia voluptas rerum itaque maxime soluta. Omnis id magnam. Veniam quas impedit beatae deserunt recusandae aliquam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("ca39acd7-60a3-4998-ad98-2621a63488f3"), 0m, new Guid("bda8105f-a864-4066-8b1b-c59dc9a75ed1"), "Placeat voluptatum repellat. Sint et veritatis. Pariatur cumque eligendi in alias dicta esse.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("cbdf5f96-9e0c-4d58-98c4-368ca79f9d9e"), 0m, new Guid("95438a56-fa63-4a1b-9352-2b684b3358f7"), "Autem numquam aspernatur nihil et voluptas.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("cc9f9f29-ab8f-49e7-be99-b8ca1d2a4c74"), 0m, new Guid("c5504494-1659-4f7f-88fa-9cfbf352bdef"), "Est repellat ratione temporibus ea corrupti nobis suscipit nobis libero. Qui nulla sapiente minus molestias optio. Eum laboriosam ut et reiciendis atque maiores non autem dolore.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("ccfbd429-c582-4763-8339-45357938b156"), 0m, new Guid("f0cdf413-7b73-4f2f-aa50-5e4b5ba45e40"), "Voluptas sint distinctio pariatur labore atque.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("cf10bcbe-b5cb-4266-a5f6-2aaeed588716"), 0m, new Guid("e02387b9-706b-4efb-9749-1b58f6e0b7e1"), "Sit voluptatem et necessitatibus. Qui alias molestias explicabo laboriosam fugiat ratione dolorem distinctio eveniet.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("cf36a453-2cf7-44a7-8564-a54a3d6cf5e3"), 0m, new Guid("e02387b9-706b-4efb-9749-1b58f6e0b7e1"), "Molestiae non quia eum. Excepturi tenetur voluptatem fuga at et est omnis doloremque dolores. Deleniti quibusdam doloribus necessitatibus doloribus praesentium delectus. Voluptatum quia dolore.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("cfb1fbfd-be45-443c-9c69-2ffcf74a2668"), 0m, new Guid("da60fe9b-cff2-47d2-98a7-08887f4fc53f"), "Nam beatae sit neque. Dolorum dicta eum dolor est inventore nobis dolores omnis dolores. Est aut vel nesciunt debitis facilis praesentium repudiandae.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("cff42795-350f-49bf-a130-14e75421fa18"), 0m, new Guid("0e49838e-092b-4dcc-9500-d16d267c05ad"), "Libero qui non.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("d28b3487-8555-40ad-8898-2c023d6dafa6"), 0m, new Guid("da60fe9b-cff2-47d2-98a7-08887f4fc53f"), "Id et sit fugiat illo eum voluptate sed. Rerum qui aut quia ut ipsa.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("d482031d-a4ed-45a6-a972-ce87d5043a1c"), 0m, new Guid("f0cdf413-7b73-4f2f-aa50-5e4b5ba45e40"), "Commodi voluptatem repellat voluptas necessitatibus odit consequatur aut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("d618df06-d389-47e9-bdd1-29b6e2676d4b"), 0m, new Guid("bda8105f-a864-4066-8b1b-c59dc9a75ed1"), "Iure sed et quia ipsa in adipisci aut et. Et odit reiciendis perferendis totam eum. Repudiandae molestias et voluptatem quo modi repellat. Repudiandae veniam voluptatem dignissimos sit nulla fugiat dolore qui.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("d7733fa8-8fb2-48b8-8699-585687297a1e"), 0m, new Guid("4900912d-f3c7-4bc5-a830-6ff58d514f3c"), "Placeat perspiciatis beatae. Corrupti esse voluptatem animi numquam possimus rerum. Veniam ut ea adipisci laboriosam. Reprehenderit numquam fuga aut quo ut ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("da86bed4-04cd-4a68-8bdc-7d5c8c9a74ab"), 0m, new Guid("e02387b9-706b-4efb-9749-1b58f6e0b7e1"), "Ut reprehenderit aut aliquid. Ut et earum voluptate ut expedita et sit voluptatem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("dcae03c9-9f7c-4668-817f-27c7b7cdafd6"), 0m, new Guid("c5504494-1659-4f7f-88fa-9cfbf352bdef"), "Earum a deserunt velit enim exercitationem. Nam facere est magnam id ut voluptatem. Aperiam ullam saepe voluptas doloribus aut. Magni magni voluptatem quos ipsa omnis ducimus qui ea.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("de60aeb5-f793-4d14-94df-953e99fd4f8a"), 0m, new Guid("95438a56-fa63-4a1b-9352-2b684b3358f7"), "Illum facilis mollitia dolorem ipsam assumenda fuga excepturi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("df333a28-0d9d-4291-9364-b9d8a546729a"), 0m, new Guid("c5504494-1659-4f7f-88fa-9cfbf352bdef"), "Id ut enim consectetur. Eum libero expedita animi eos ratione.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("dfb15f0d-aa86-4068-acf8-25a059932a7d"), 0m, new Guid("208f0402-df0d-493d-9c25-f3e8b1173033"), "Esse ad illum sed. Esse harum laboriosam magnam libero odio blanditiis rerum. Accusamus rerum autem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("e0232439-f997-46e7-acef-15900f1bdb3a"), 0m, new Guid("b4e96782-f1bc-40c2-b344-9e8ea6b71113"), "Commodi repudiandae occaecati excepturi. Quos consequatur debitis fugit sunt saepe in in minima.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("e3cf46d3-207c-49bb-b40e-580798bf9693"), 0m, new Guid("da60fe9b-cff2-47d2-98a7-08887f4fc53f"), "Dignissimos sit optio quia porro illo.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("e420cee3-1d7b-44a7-84fc-1f712bc9feaf"), 0m, new Guid("bda8105f-a864-4066-8b1b-c59dc9a75ed1"), "Voluptatibus eaque aspernatur. Dolorem consequatur pariatur quo harum provident sapiente in nam beatae. Doloremque qui sunt et ipsa. Omnis saepe et omnis repellat alias rerum neque excepturi ea.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("e521a0e9-2f29-4c1f-b7cb-7a910bd235fd"), 0m, new Guid("676ee4b7-4109-42a0-b01b-e41eeb0328e6"), "Quis corporis officiis molestias qui. Magnam quaerat minus. Adipisci ducimus id aut rerum velit. Placeat sed eum officiis ut dolor pariatur qui.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("e55f87ac-9b8f-464d-bcda-fd5ae2856612"), 0m, new Guid("0e49838e-092b-4dcc-9500-d16d267c05ad"), "Enim aut perferendis nam et hic. Accusamus porro consectetur ea.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("e63e1478-c996-4f86-973a-aad39b1ceb5b"), 0m, new Guid("479b7e46-ddf8-4e15-94c0-bafe4a45ed4d"), "Voluptatem et laboriosam necessitatibus quis voluptatum nisi. Provident autem itaque explicabo.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("e735e5bf-cb4a-469b-bb17-972c2d298df5"), 0m, new Guid("26cd5370-da2d-406a-a0e8-d6bf0a1a2590"), "Culpa nisi velit. Enim quaerat dolores eius id commodi fugit saepe aspernatur quia. Et excepturi animi. Voluptatem voluptate quidem expedita veniam incidunt eligendi porro est.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("e7c6594f-ebca-412f-b911-e00af1b47c1d"), 0m, new Guid("479b7e46-ddf8-4e15-94c0-bafe4a45ed4d"), "Eum qui et aut et eum nulla iure exercitationem harum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("e7fe8f85-9526-401d-bb50-50ebf6267e99"), 0m, new Guid("bda8105f-a864-4066-8b1b-c59dc9a75ed1"), "Accusantium quisquam maxime aliquid.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("ebb6e3b1-91a7-4fa4-b6e2-4e35a69c3c80"), 0m, new Guid("e02387b9-706b-4efb-9749-1b58f6e0b7e1"), "Modi impedit officia itaque. Consequatur qui illum repellat ratione mollitia numquam culpa exercitationem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("ed3d692b-b470-40ea-8c34-b7753b600360"), 0m, new Guid("95438a56-fa63-4a1b-9352-2b684b3358f7"), "Vel autem eos. Et et odit dolores voluptates enim rerum itaque rerum dolores. Voluptatem pariatur fugit molestiae.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("edc54ff3-e7a7-4713-8c80-d31afab9263f"), 0m, new Guid("47d4f027-0457-4462-a285-edfe5b7edfbc"), "Explicabo eligendi molestiae tenetur et provident. Pariatur velit dolores animi tempora odio. Dicta nihil laborum accusantium non.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("ee04cde1-4267-4109-ad64-b404129bf9dc"), 0m, new Guid("f9708a8e-e1ac-4953-8aa3-d60822eaa359"), "Pariatur nulla voluptas recusandae repudiandae. Libero praesentium non aut. Sequi aut molestiae perferendis ullam placeat minima magni officiis et. Quis qui qui consequuntur sit quis voluptatem dolorum ea.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("ee3e69b7-1f6b-4993-ab91-499ef272dc1d"), 0m, new Guid("b4e96782-f1bc-40c2-b344-9e8ea6b71113"), "Quasi est dolorem nihil porro tempore. Rerum quia libero expedita odio fugiat fuga sapiente. Et natus placeat repudiandae aut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("eefefc3f-0339-40c1-b177-73145f7b7320"), 0m, new Guid("da60fe9b-cff2-47d2-98a7-08887f4fc53f"), "Voluptatem vero deserunt omnis sunt quidem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("ef405cb8-8c5d-4039-a2ed-b57a7e22ebd3"), 0m, new Guid("676ee4b7-4109-42a0-b01b-e41eeb0328e6"), "Reiciendis totam ut deserunt odit voluptas fugiat nam voluptatem. Et et ut aliquam ipsam sit magnam maxime enim. Assumenda debitis totam blanditiis eaque ut neque explicabo. Non in eveniet dolor enim neque qui dolor maiores odit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("f11629b9-4057-48d5-87bb-77ffd70f6c77"), 0m, new Guid("225c86ba-b89e-4316-89be-29cfee4a69d5"), "Officiis doloribus assumenda ex assumenda iusto quis commodi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("f28b125f-d323-4a6e-b5d5-5747888922cb"), 0m, new Guid("b4e96782-f1bc-40c2-b344-9e8ea6b71113"), "Est reiciendis omnis explicabo qui. Quia eos dicta tempora dolor aliquid ut sint. Sunt harum laudantium architecto. Atque laborum est quam neque.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("f2e5aa6f-e496-4e76-b55a-b858efc39c7e"), 0m, new Guid("208f0402-df0d-493d-9c25-f3e8b1173033"), "Labore nam amet. Et praesentium fugiat rerum vero qui voluptates.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("f3ba0518-12bc-475d-bb49-ab8d4b5fc844"), 0m, new Guid("43ced5f0-f418-4813-814b-ba21258fd954"), "Ad ipsum corporis. Ut eaque laboriosam fugiat itaque occaecati doloribus voluptatem consequuntur veritatis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("f45be41a-de50-4d24-9aec-6b7ad716f09b"), 0m, new Guid("95438a56-fa63-4a1b-9352-2b684b3358f7"), "Nobis accusantium natus et rerum qui laudantium et exercitationem. Aliquam placeat id cum dolores debitis autem quisquam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("f61ffeb7-15f2-4265-9598-33982d774a3b"), 0m, new Guid("479b7e46-ddf8-4e15-94c0-bafe4a45ed4d"), "Modi similique sequi. Pariatur nihil quo repellat eius sapiente facere quaerat consequatur voluptate. Eaque dolor eligendi ea exercitationem voluptatibus omnis quia pariatur. Inventore quod cum quidem molestiae qui placeat ad rem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("f691c075-645f-4dab-8b8d-42c61e00e0e6"), 0m, new Guid("43ced5f0-f418-4813-814b-ba21258fd954"), "Natus blanditiis deleniti deserunt aspernatur delectus consequuntur alias ipsum modi. Est ducimus eum quas quia quae.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("f84c6b1f-a877-4562-9601-407f471d4328"), 0m, new Guid("676ee4b7-4109-42a0-b01b-e41eeb0328e6"), "Ducimus a unde soluta itaque quo provident cum soluta explicabo.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("fd3a484c-f47a-49a5-8cf7-9cdd4b8273a6"), 0m, new Guid("75c2b1aa-900a-47c9-8c69-1af3cbcf5a56"), "Sed numquam iusto tempore minima eos aut. Ea animi quas magnam deserunt natus molestiae. Aut delectus velit accusamus voluptas eum amet.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("fdd7a2e2-a90b-4f75-82ad-3b62fe6f3dc0"), 0m, new Guid("95438a56-fa63-4a1b-9352-2b684b3358f7"), "Odit dolorem et velit eos aut vitae. Repudiandae nihil quae debitis. Magni et tempore ut aut vitae tempore officiis sint. Autem eos at suscipit cum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "SubscriptionPaid",
                columns: new[] { "MemberId", "Year", "April", "August", "December", "February", "January", "July", "June", "March", "May", "November", "October", "September" },
                values: new object[,]
                {
                    { new Guid("208f0402-df0d-493d-9c25-f3e8b1173033"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("208f0402-df0d-493d-9c25-f3e8b1173033"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("208f0402-df0d-493d-9c25-f3e8b1173033"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("225c86ba-b89e-4316-89be-29cfee4a69d5"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("225c86ba-b89e-4316-89be-29cfee4a69d5"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("225c86ba-b89e-4316-89be-29cfee4a69d5"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("225c86ba-b89e-4316-89be-29cfee4a69d5"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("229cfa30-1b50-45b9-b79d-7fe3c786f9af"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("26cd5370-da2d-406a-a0e8-d6bf0a1a2590"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("26cd5370-da2d-406a-a0e8-d6bf0a1a2590"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("26cd5370-da2d-406a-a0e8-d6bf0a1a2590"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("26cd5370-da2d-406a-a0e8-d6bf0a1a2590"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("26cd5370-da2d-406a-a0e8-d6bf0a1a2590"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("479b7e46-ddf8-4e15-94c0-bafe4a45ed4d"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("479b7e46-ddf8-4e15-94c0-bafe4a45ed4d"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("47d4f027-0457-4462-a285-edfe5b7edfbc"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("47d4f027-0457-4462-a285-edfe5b7edfbc"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("47d4f027-0457-4462-a285-edfe5b7edfbc"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("47d4f027-0457-4462-a285-edfe5b7edfbc"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("4900912d-f3c7-4bc5-a830-6ff58d514f3c"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("4900912d-f3c7-4bc5-a830-6ff58d514f3c"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("4900912d-f3c7-4bc5-a830-6ff58d514f3c"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("676ee4b7-4109-42a0-b01b-e41eeb0328e6"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("676ee4b7-4109-42a0-b01b-e41eeb0328e6"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("676ee4b7-4109-42a0-b01b-e41eeb0328e6"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("676ee4b7-4109-42a0-b01b-e41eeb0328e6"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("75c2b1aa-900a-47c9-8c69-1af3cbcf5a56"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("75c2b1aa-900a-47c9-8c69-1af3cbcf5a56"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("75c2b1aa-900a-47c9-8c69-1af3cbcf5a56"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("95438a56-fa63-4a1b-9352-2b684b3358f7"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("95438a56-fa63-4a1b-9352-2b684b3358f7"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("95438a56-fa63-4a1b-9352-2b684b3358f7"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("95438a56-fa63-4a1b-9352-2b684b3358f7"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("a451e473-9af9-4c97-949f-17cd687c5ce4"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("a451e473-9af9-4c97-949f-17cd687c5ce4"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("a451e473-9af9-4c97-949f-17cd687c5ce4"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("a451e473-9af9-4c97-949f-17cd687c5ce4"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("a451e473-9af9-4c97-949f-17cd687c5ce4"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("a451e473-9af9-4c97-949f-17cd687c5ce4"), 2020, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("b4e96782-f1bc-40c2-b344-9e8ea6b71113"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("b4e96782-f1bc-40c2-b344-9e8ea6b71113"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("b4e96782-f1bc-40c2-b344-9e8ea6b71113"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("b4e96782-f1bc-40c2-b344-9e8ea6b71113"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("b4e96782-f1bc-40c2-b344-9e8ea6b71113"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("b4e96782-f1bc-40c2-b344-9e8ea6b71113"), 2020, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("b4e96782-f1bc-40c2-b344-9e8ea6b71113"), 2021, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("bda8105f-a864-4066-8b1b-c59dc9a75ed1"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("bda8105f-a864-4066-8b1b-c59dc9a75ed1"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("bda8105f-a864-4066-8b1b-c59dc9a75ed1"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("bda8105f-a864-4066-8b1b-c59dc9a75ed1"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("bda8105f-a864-4066-8b1b-c59dc9a75ed1"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("bda8105f-a864-4066-8b1b-c59dc9a75ed1"), 2020, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("bda8105f-a864-4066-8b1b-c59dc9a75ed1"), 2021, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("c5504494-1659-4f7f-88fa-9cfbf352bdef"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("c5504494-1659-4f7f-88fa-9cfbf352bdef"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("c5504494-1659-4f7f-88fa-9cfbf352bdef"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("da60fe9b-cff2-47d2-98a7-08887f4fc53f"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("da60fe9b-cff2-47d2-98a7-08887f4fc53f"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("da60fe9b-cff2-47d2-98a7-08887f4fc53f"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("e02387b9-706b-4efb-9749-1b58f6e0b7e1"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("e02387b9-706b-4efb-9749-1b58f6e0b7e1"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("e02387b9-706b-4efb-9749-1b58f6e0b7e1"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("e02387b9-706b-4efb-9749-1b58f6e0b7e1"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("e02387b9-706b-4efb-9749-1b58f6e0b7e1"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("e02387b9-706b-4efb-9749-1b58f6e0b7e1"), 2020, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("f0cdf413-7b73-4f2f-aa50-5e4b5ba45e40"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("f9708a8e-e1ac-4953-8aa3-d60822eaa359"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("f9708a8e-e1ac-4953-8aa3-d60822eaa359"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("f9708a8e-e1ac-4953-8aa3-d60822eaa359"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("f9708a8e-e1ac-4953-8aa3-d60822eaa359"), 2018, true, true, true, true, true, true, true, true, true, true, true, true }
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
