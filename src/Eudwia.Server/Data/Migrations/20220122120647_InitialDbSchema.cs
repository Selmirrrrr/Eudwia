using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Eudwia.Server.Data.Migrations
{
    public partial class InitialDbSchema : Migration
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
                name: "AspNetUsers",
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
                    Language = table.Column<int>(type: "integer", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
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
                        name: "FK_Payments_AspNetUsers_MemberId",
                        column: x => x.MemberId,
                        principalTable: "AspNetUsers",
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
                        name: "FK_SubscriptionsPaid_AspNetUsers_MemberId",
                        column: x => x.MemberId,
                        principalTable: "AspNetUsers",
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
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "City", "ConcurrencyStamp", "CountryId", "Email", "EmailConfirmed", "FirstName", "HouseNumber", "Language", "LastName", "LockoutEnabled", "LockoutEnd", "MemberSince", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "StreetLine1", "StreetLine2", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("0c865509-3202-49f5-98e7-0a9a4c5c0489"), 0, new DateOnly(1977, 8, 1), "Niort", "fcec1acd-f080-4381-bf62-ce9273b58c97", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Anthelmette.Deschamps18@gmail.com", false, "Théodose", "6180", 1, "Mercier", false, null, new DateOnly(2020, 6, 12), null, null, null, "+33 599615083", false, null, "VD", "9 Allée Saint-Denis", "Apt. 992", false, null, "94439" },
                    { new Guid("3021a50b-2e14-4860-a432-98a126642eb9"), 0, new DateOnly(1956, 3, 26), "Montreuil", "903eacca-c53e-4d08-a70c-e6e72cdaf5e6", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Anthelmette.Deschamps18@gmail.com", false, "Quintia", "99", 0, "Sanchez", false, null, new DateOnly(2016, 5, 2), null, null, null, "+33 599615083", false, null, "VD", "2080 Boulevard de la Pompe", "4 étage", false, null, "65064" },
                    { new Guid("321b519a-bead-4408-8e85-cfd5c7afe182"), 0, new DateOnly(1989, 2, 2), "Aix-en-Provence", "8fba772c-b8ee-45d9-b8c5-78ff7dc8c3cd", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Anthelmette.Deschamps18@gmail.com", false, "Johan", "44", 0, "Paris", false, null, new DateOnly(2012, 5, 14), null, null, null, "+33 599615083", false, null, "VD", "9 Place de Provence", "Apt. 995", false, null, "26550" },
                    { new Guid("399c47ef-caf0-4115-98db-c6c8f6dde507"), 0, new DateOnly(1984, 2, 4), "Nîmes", "17569b45-7f5f-4e29-829a-9a2a968f4d7f", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Anthelmette.Deschamps18@gmail.com", false, "Simone", "9403", 2, "Muller", false, null, new DateOnly(2013, 7, 17), null, null, null, "+33 599615083", false, null, "VD", "4 Avenue du Faubourg-Saint-Denis", "Apt. 233", false, null, "65164" },
                    { new Guid("58384a47-8236-4a5f-93d7-5913ced82d1e"), 0, new DateOnly(1950, 12, 2), "Aix-en-Provence", "b04ed588-69a9-4b53-99e0-086e8651cf4d", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Anthelmette.Deschamps18@gmail.com", false, "Mélisande", "4205", 0, "Meyer", false, null, new DateOnly(2016, 10, 12), null, null, null, "+33 599615083", false, null, "VD", "83 Place Pierre Charron", "8 étage", false, null, "29048" },
                    { new Guid("5e3bb94b-9db1-4c98-afcc-75746f0d0050"), 0, new DateOnly(1950, 12, 12), "Montpellier", "93d685d1-f79d-4691-a14e-d2f1c141ef31", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Anthelmette.Deschamps18@gmail.com", false, "Balthazar", "1078", 0, "Roux", false, null, new DateOnly(2012, 7, 9), null, null, null, "+33 599615083", false, null, "VD", "7516 Voie Delesseux", "1 étage", false, null, "56327" },
                    { new Guid("625f60c7-26bf-4b4d-810a-a53717a7983c"), 0, new DateOnly(1984, 12, 26), "La Seyne-sur-Mer", "69050682-b8f9-4b4c-bee5-b92ca4883725", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Anthelmette.Deschamps18@gmail.com", false, "Anicette", "0097", 1, "Breton", false, null, new DateOnly(2014, 4, 4), null, null, null, "+33 599615083", false, null, "VD", "889 Allée de la Bûcherie", "Apt. 422", false, null, "84653" },
                    { new Guid("666b7a2b-c7e6-4de9-a345-57b8062ad9e6"), 0, new DateOnly(1964, 10, 15), "Beauvais", "666a6a37-6f4a-4aee-84f0-4c5ab6f6093e", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Anthelmette.Deschamps18@gmail.com", false, "Longin", "0", 1, "Marchal", false, null, new DateOnly(2020, 8, 29), null, null, null, "+33 599615083", false, null, "VD", "32 Voie Oberkampf", "Apt. 158", false, null, "07880" },
                    { new Guid("6ac03431-5ace-40a8-8672-e40ed7a5cf21"), 0, new DateOnly(1986, 7, 26), "Antony", "dc214a63-6644-4781-b928-4e177c5b2714", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Anthelmette.Deschamps18@gmail.com", false, "Gilles", "335", 1, "Rolland", false, null, new DateOnly(2015, 5, 1), null, null, null, "+33 599615083", false, null, "VD", "7 Quai des Francs-Bourgeois", "0 étage", false, null, "68346" },
                    { new Guid("90579122-bf74-4a7a-9eba-5c166ddaa313"), 0, new DateOnly(1970, 1, 23), "Levallois-Perret", "adabf137-85fd-4bfe-a5b3-bd245b550d7b", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Anthelmette.Deschamps18@gmail.com", false, "Joséphine", "255", 2, "Breton", false, null, new DateOnly(2016, 5, 29), null, null, null, "+33 599615083", false, null, "VD", "100 Allée Joubert", "Apt. 849", false, null, "79228" },
                    { new Guid("9801b0c7-db84-4779-af42-de97aedf9b64"), 0, new DateOnly(1978, 8, 18), "Le Havre", "5395aba5-0b34-4f01-8374-355f17439ded", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Anthelmette.Deschamps18@gmail.com", false, "Stanislas", "548", 1, "Barbier", false, null, new DateOnly(2013, 3, 21), null, null, null, "+33 599615083", false, null, "VD", "5589 Impasse de la Huchette", "Apt. 959", false, null, "89304" },
                    { new Guid("a09aa449-febf-4318-b933-fe31feb73c9c"), 0, new DateOnly(1951, 3, 2), "Hyères", "b1b3f500-64b8-4e93-8e83-7ab33fe9f532", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Anthelmette.Deschamps18@gmail.com", false, "Raymond", "1380", 1, "Simon", false, null, new DateOnly(2014, 12, 4), null, null, null, "+33 599615083", false, null, "VD", "2917 Quai Joubert", "Apt. 636", false, null, "54945" },
                    { new Guid("b560e47d-09da-4044-bd0a-6172a633478b"), 0, new DateOnly(1976, 6, 20), "La Seyne-sur-Mer", "1fbfb8aa-f280-4b93-a249-07a553db1ecd", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Anthelmette.Deschamps18@gmail.com", false, "Clotilde", "31", 2, "Francois", false, null, new DateOnly(2021, 5, 1), null, null, null, "+33 599615083", false, null, "VD", "2 Impasse Saint-Denis", "7 étage", false, null, "90542" },
                    { new Guid("bf67e662-0d81-4f4a-83bd-727e20a66cb7"), 0, new DateOnly(1977, 8, 31), "Le Mans", "99571bd6-11fd-41ea-8200-15d2084165e8", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Anthelmette.Deschamps18@gmail.com", false, "Marc", "432", 2, "Sanchez", false, null, new DateOnly(2012, 10, 16), null, null, null, "+33 599615083", false, null, "VD", "3006 Place des Francs-Bourgeois", "Apt. 736", false, null, "98476" },
                    { new Guid("c12da2dc-533c-43bc-ad77-fc3a97ae0300"), 0, new DateOnly(1965, 11, 29), "Metz", "ce39ebae-f0fb-4567-905b-4389359b3226", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Anthelmette.Deschamps18@gmail.com", false, "Louis", "13", 2, "Renaud", false, null, new DateOnly(2014, 10, 30), null, null, null, "+33 599615083", false, null, "VD", "633 Boulevard Saint-Bernard", "8 étage", false, null, "91772" },
                    { new Guid("cb817682-2116-4baa-9960-edd372cd2bf2"), 0, new DateOnly(1988, 1, 13), "Paris", "d20d0f53-4c31-4b80-9fa2-b7102fbd11d1", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Anthelmette.Deschamps18@gmail.com", false, "Armin", "3", 2, "Olivier", false, null, new DateOnly(2020, 4, 21), null, null, null, "+33 599615083", false, null, "VD", "896 Avenue de Solférino", "2 étage", false, null, "30568" },
                    { new Guid("d416c1a3-8b50-4550-8807-55b14fa7e4af"), 0, new DateOnly(1962, 7, 24), "Limoges", "2f52594c-f3d9-4595-9606-390f516c54dc", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Anthelmette.Deschamps18@gmail.com", false, "Corinne", "89", 1, "Marie", false, null, new DateOnly(2020, 9, 5), null, null, null, "+33 599615083", false, null, "VD", "669 Impasse Saint-Dominique", "Apt. 306", false, null, "07186" },
                    { new Guid("d4a59397-3d7d-407f-9a9d-9d5cefe93216"), 0, new DateOnly(1971, 11, 10), "Montpellier", "f3595ae9-70cb-44c6-ab8b-9ccd63702ad3", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Anthelmette.Deschamps18@gmail.com", false, "Simone", "19", 2, "Breton", false, null, new DateOnly(2015, 12, 30), null, null, null, "+33 599615083", false, null, "VD", "4531 Place Saint-Honoré", "Apt. 883", false, null, "51663" },
                    { new Guid("e06131eb-f2e1-40d8-b36a-d1f26aceb63c"), 0, new DateOnly(1952, 4, 23), "Levallois-Perret", "b07f7b18-94b1-4bd6-ae1e-e49f1b037a49", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Anthelmette.Deschamps18@gmail.com", false, "Arcadie", "041", 0, "Dupont", false, null, new DateOnly(2012, 2, 18), null, null, null, "+33 599615083", false, null, "VD", "69 Boulevard du Faubourg Saint-Honoré", "Apt. 179", false, null, "27997" },
                    { new Guid("fa30eb2d-f8b6-4219-9061-f62f7eeb0f89"), 0, new DateOnly(1962, 7, 27), "Bordeaux", "96eecf3b-5dca-40f8-ae91-640d7a750295", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Anthelmette.Deschamps18@gmail.com", false, "Élisabeth", "4126", 0, "Andre", false, null, new DateOnly(2017, 11, 30), null, null, null, "+33 599615083", false, null, "VD", "79 Place des Lombards", "Apt. 433", false, null, "71647" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "IsDeleted", "MemberId", "Note", "PaymentDate", "PaymentType" },
                values: new object[,]
                {
                    { new Guid("0018c106-e51a-4b82-b4b4-7fd6e25a265f"), 840.341039780603000m, false, new Guid("c12da2dc-533c-43bc-ad77-fc3a97ae0300"), "Accusantium voluptatum et ratione debitis tempore asperiores. Rerum nihil voluptatum magni sit eaque. Culpa eos non labore totam voluptatum ut.", new DateTime(2015, 4, 8, 9, 34, 11, 798, DateTimeKind.Utc).AddTicks(9955), 0 },
                    { new Guid("02795c74-f886-4bdc-ba39-1c7c9d76e769"), 92.1353314158394000m, false, new Guid("a09aa449-febf-4318-b933-fe31feb73c9c"), "Culpa laudantium animi est. Sunt temporibus corporis a nam ducimus. Odio vel officia sunt voluptatem et sint. Nihil eos est.", new DateTime(2014, 11, 25, 13, 41, 46, 924, DateTimeKind.Utc).AddTicks(1105), 99 },
                    { new Guid("02c368b0-bc8f-4bcc-a239-ff223b770fb0"), 465.375778776001000m, false, new Guid("3021a50b-2e14-4860-a432-98a126642eb9"), "Repellat voluptatibus a cupiditate ipsa doloremque.", new DateTime(2013, 7, 24, 22, 9, 27, 537, DateTimeKind.Utc).AddTicks(3941), 1 },
                    { new Guid("049f7961-51f4-4a3e-9d3c-645008c1f603"), 169.689787588708000m, false, new Guid("a09aa449-febf-4318-b933-fe31feb73c9c"), "Ut dolores inventore perspiciatis doloremque. Nulla ipsum cumque cumque sint reprehenderit. Dolorum dolor provident reiciendis qui voluptatem accusantium.", new DateTime(2021, 7, 18, 2, 2, 1, 313, DateTimeKind.Utc).AddTicks(7029), 99 },
                    { new Guid("07ff4bc5-47e0-4170-b9bf-6869b30e2128"), 954.48186238545000m, false, new Guid("b560e47d-09da-4044-bd0a-6172a633478b"), "Natus sit sint voluptatibus mollitia voluptas autem aut. Sit impedit dolorem voluptatem qui dolore vero iste pariatur.", new DateTime(2013, 4, 20, 8, 23, 12, 823, DateTimeKind.Utc).AddTicks(6638), 0 },
                    { new Guid("0846a5a0-923c-4f9d-b7b8-8e4da9132bf1"), 188.672796004382000m, false, new Guid("399c47ef-caf0-4115-98db-c6c8f6dde507"), "Quibusdam rerum nemo officia. Ut et doloribus placeat beatae qui voluptatibus ducimus unde deleniti. Sunt nihil itaque dignissimos.", new DateTime(2021, 10, 27, 2, 40, 49, 383, DateTimeKind.Utc).AddTicks(1276), 1 },
                    { new Guid("085d7ec1-a083-4758-b312-c935b0081126"), 73.7911091315661000m, false, new Guid("d4a59397-3d7d-407f-9a9d-9d5cefe93216"), "Mollitia et maxime repudiandae id voluptate dolore non. Optio magni eius qui dolor iure. Perferendis natus quis unde repellendus sit labore blanditiis. Autem hic earum ex dolorem pariatur assumenda suscipit nobis.", new DateTime(2013, 4, 14, 1, 47, 45, 759, DateTimeKind.Utc).AddTicks(5867), 0 },
                    { new Guid("09a73785-acf7-49ed-ab30-8ecb5532ed6e"), 932.163189132429000m, false, new Guid("cb817682-2116-4baa-9960-edd372cd2bf2"), "Aut velit totam perspiciatis alias fugiat sit. Vel asperiores est.", new DateTime(2021, 5, 6, 23, 3, 14, 515, DateTimeKind.Utc).AddTicks(44), 1 },
                    { new Guid("09a8f440-10d8-4279-9c66-e873a2904606"), 815.995573515826000m, false, new Guid("90579122-bf74-4a7a-9eba-5c166ddaa313"), "A dolores et sint fugiat rem exercitationem vel neque. Cum minus consectetur. Esse architecto quaerat vel quis nemo. Optio sit quis autem voluptas consequatur magni quia.", new DateTime(2015, 2, 8, 0, 44, 50, 559, DateTimeKind.Utc).AddTicks(5540), 1 },
                    { new Guid("0a0a5b5c-a84a-4b10-afb5-0cde28c31f73"), 961.001509876986000m, false, new Guid("9801b0c7-db84-4779-af42-de97aedf9b64"), "Ipsum et ut aut saepe blanditiis qui.", new DateTime(2014, 2, 12, 13, 2, 3, 106, DateTimeKind.Utc).AddTicks(5586), 99 },
                    { new Guid("0aa2075c-cec7-4c62-8044-2e48506b5fbc"), 322.843472416235000m, false, new Guid("6ac03431-5ace-40a8-8672-e40ed7a5cf21"), "Nobis sunt sapiente aut est corporis eum possimus. Harum et laborum aut et magnam enim nihil odit voluptates. Fuga minus delectus molestias nam velit et laborum deserunt vel. Quas aliquid sint et.", new DateTime(2015, 12, 12, 22, 54, 0, 692, DateTimeKind.Utc).AddTicks(3041), 0 },
                    { new Guid("0adc6dbf-6e08-4522-82b8-9cce581ee93d"), 617.382129137693000m, false, new Guid("fa30eb2d-f8b6-4219-9061-f62f7eeb0f89"), "Neque necessitatibus consequatur cum quo ipsum sunt. Doloremque dicta sequi iste enim. Eaque laudantium eum est.", new DateTime(2017, 6, 4, 11, 22, 4, 711, DateTimeKind.Utc).AddTicks(2008), 0 },
                    { new Guid("0be6056b-8731-4654-a3d0-1a79148fac24"), 324.785006087385000m, false, new Guid("fa30eb2d-f8b6-4219-9061-f62f7eeb0f89"), "Labore blanditiis hic numquam dignissimos voluptatem incidunt sit magnam. Animi quo consequuntur aliquid quos et quo quia et in.", new DateTime(2016, 4, 12, 7, 40, 0, 398, DateTimeKind.Utc).AddTicks(8511), 0 },
                    { new Guid("0cba1a3c-3f67-4326-b3b6-196e1b55f76d"), 606.976847663543000m, false, new Guid("58384a47-8236-4a5f-93d7-5913ced82d1e"), "Voluptas ducimus assumenda.", new DateTime(2020, 6, 11, 4, 46, 20, 171, DateTimeKind.Utc).AddTicks(5508), 0 },
                    { new Guid("0d785621-17f2-41eb-be74-7da209efed1f"), 989.967442771808000m, false, new Guid("5e3bb94b-9db1-4c98-afcc-75746f0d0050"), "Aliquam id earum laudantium sed mollitia nesciunt. Cum est sit. Similique nesciunt enim molestias fugit error.", new DateTime(2014, 10, 11, 1, 44, 7, 218, DateTimeKind.Utc).AddTicks(9495), 0 },
                    { new Guid("0d8aa2ee-bcf8-4b68-b8ef-c24cb9eaab88"), 649.381237073816000m, false, new Guid("cb817682-2116-4baa-9960-edd372cd2bf2"), "Cumque ut sed rem quo magnam voluptas ipsa. Autem perferendis totam ut eligendi deserunt esse recusandae soluta nemo.", new DateTime(2016, 11, 26, 6, 1, 15, 130, DateTimeKind.Utc).AddTicks(3292), 1 },
                    { new Guid("10c35901-fe90-4221-899c-abb8e1ce6c6e"), 281.528238959831000m, false, new Guid("9801b0c7-db84-4779-af42-de97aedf9b64"), "Fuga velit odit blanditiis est. Et laborum dolores dolor architecto possimus. Cupiditate molestias vitae qui ut aut ut.", new DateTime(2021, 5, 7, 16, 43, 3, 146, DateTimeKind.Utc).AddTicks(7384), 1 },
                    { new Guid("12e2ca98-bd69-4f0b-8d6b-40fd818c338d"), 356.159532893795000m, false, new Guid("fa30eb2d-f8b6-4219-9061-f62f7eeb0f89"), "Ut sed consequatur. Eaque et et error excepturi voluptatem et.", new DateTime(2015, 4, 1, 14, 23, 9, 373, DateTimeKind.Utc).AddTicks(1197), 99 },
                    { new Guid("132bb9a4-3ac4-4a93-91e5-cee5cd26e2a4"), 624.596195381898000m, false, new Guid("625f60c7-26bf-4b4d-810a-a53717a7983c"), "Qui laborum et in velit. Nisi id sed numquam harum inventore enim amet at explicabo.", new DateTime(2014, 2, 22, 10, 1, 44, 576, DateTimeKind.Utc).AddTicks(8504), 0 },
                    { new Guid("13a2e0e4-e934-4174-a669-cb65906e702a"), 187.436258526682000m, false, new Guid("cb817682-2116-4baa-9960-edd372cd2bf2"), "Occaecati sed pariatur dolor fuga ut. Omnis fugit rem corrupti voluptate. Rerum sint dolorem asperiores dignissimos nobis ea est dolores.", new DateTime(2015, 3, 12, 10, 42, 37, 987, DateTimeKind.Utc).AddTicks(9364), 0 },
                    { new Guid("151f03dd-dd45-4685-a152-d031d89300bf"), 242.827824381854000m, false, new Guid("c12da2dc-533c-43bc-ad77-fc3a97ae0300"), "Ducimus quod nisi omnis explicabo.", new DateTime(2017, 8, 11, 8, 13, 32, 551, DateTimeKind.Utc).AddTicks(2240), 1 },
                    { new Guid("16a4488e-0110-4343-bfd0-505833d593d6"), 688.170400107813000m, false, new Guid("bf67e662-0d81-4f4a-83bd-727e20a66cb7"), "Repellendus nesciunt dolor aperiam voluptatibus quae alias omnis. Tenetur ut ducimus.", new DateTime(2014, 7, 16, 13, 12, 22, 495, DateTimeKind.Utc).AddTicks(1595), 1 },
                    { new Guid("18b710b4-9ba9-474d-94de-2b12df440c34"), 348.448067342135000m, false, new Guid("3021a50b-2e14-4860-a432-98a126642eb9"), "Dicta doloremque cum voluptates odio beatae quisquam asperiores corporis qui. Et et quaerat expedita rerum saepe iure. Qui voluptates eius doloribus enim aut vel.", new DateTime(2020, 2, 11, 2, 55, 6, 105, DateTimeKind.Utc).AddTicks(518), 99 },
                    { new Guid("1ae06a73-1ba2-42df-8e6a-663d90ecd641"), 142.273601497263000m, false, new Guid("3021a50b-2e14-4860-a432-98a126642eb9"), "Optio fugit quia expedita. Alias ea sed. Non magnam aperiam perferendis quia totam fuga qui perspiciatis. Enim ut illum facere labore.", new DateTime(2019, 8, 9, 10, 16, 25, 849, DateTimeKind.Utc).AddTicks(8425), 0 },
                    { new Guid("1cb103fc-74e8-4ff4-92a2-1e7b073b3a1f"), 500.630139005974000m, false, new Guid("a09aa449-febf-4318-b933-fe31feb73c9c"), "Nostrum aut qui hic amet dolorum aut natus. Dolorem commodi ut ut et laudantium. Ut nihil autem reiciendis reprehenderit facilis molestiae quos qui.", new DateTime(2012, 7, 9, 23, 28, 38, 200, DateTimeKind.Utc).AddTicks(9015), 99 },
                    { new Guid("1fcdb87a-bae3-4fdf-bf59-843d1253b41f"), 818.663154903719000m, false, new Guid("d416c1a3-8b50-4550-8807-55b14fa7e4af"), "Tenetur a consequuntur veniam nemo velit. Expedita nostrum dolore autem rerum aut. Neque recusandae eveniet esse eos voluptas et perspiciatis.", new DateTime(2015, 1, 13, 17, 22, 20, 705, DateTimeKind.Utc).AddTicks(6497), 99 },
                    { new Guid("247ada56-e046-44ac-89b8-73d75056774d"), 201.488474669745000m, false, new Guid("e06131eb-f2e1-40d8-b36a-d1f26aceb63c"), "Delectus provident itaque voluptatem consequatur illum in.", new DateTime(2014, 6, 1, 17, 45, 3, 523, DateTimeKind.Utc).AddTicks(1737), 1 },
                    { new Guid("2494d284-1b15-4f21-abc6-4ccf9d148b3b"), 639.128879124826000m, false, new Guid("399c47ef-caf0-4115-98db-c6c8f6dde507"), "Ut est asperiores. Provident consequatur quia deleniti praesentium in dolores doloremque molestiae id. Quod excepturi soluta praesentium.", new DateTime(2019, 4, 14, 18, 16, 19, 468, DateTimeKind.Utc).AddTicks(143), 99 },
                    { new Guid("2547ce2a-8c5b-4595-ae11-e9ef4e2a2d00"), 496.761713839015000m, false, new Guid("d416c1a3-8b50-4550-8807-55b14fa7e4af"), "Incidunt voluptatem optio ad tempore et laudantium. Aliquam commodi eligendi ipsam et officiis enim fuga temporibus. Eligendi occaecati vitae eos. Nulla nam mollitia repellat numquam recusandae.", new DateTime(2020, 4, 16, 20, 48, 21, 720, DateTimeKind.Utc).AddTicks(1475), 99 },
                    { new Guid("27007ad0-30db-4141-b992-eb9b3774cb94"), 496.077818231185000m, false, new Guid("e06131eb-f2e1-40d8-b36a-d1f26aceb63c"), "Quisquam aut omnis sed iusto voluptates at beatae non. Quaerat quia quas aut doloremque est cumque ex et. Sint non sit sit odit nihil maiores esse eos omnis.", new DateTime(2020, 8, 16, 0, 37, 41, 441, DateTimeKind.Utc).AddTicks(7998), 1 },
                    { new Guid("29d54cb2-4025-4e37-aaf3-59476c679a7c"), 367.722283321885000m, false, new Guid("321b519a-bead-4408-8e85-cfd5c7afe182"), "Et qui tempore accusamus eveniet voluptates et recusandae tenetur. Molestiae dolore ullam est sed consectetur. Fugit ratione et voluptatem repellat vitae fugiat.", new DateTime(2012, 9, 5, 7, 31, 11, 122, DateTimeKind.Utc).AddTicks(3020), 0 },
                    { new Guid("2a4677a4-bec2-4296-b6dc-709d08d20d95"), 77.2025323861409000m, false, new Guid("d4a59397-3d7d-407f-9a9d-9d5cefe93216"), "Earum qui et nobis alias unde velit qui ad. Ad et quia mollitia cupiditate ea.", new DateTime(2015, 2, 1, 15, 31, 20, 105, DateTimeKind.Utc).AddTicks(258), 99 },
                    { new Guid("2aa7bcd6-c66c-41d9-84e8-8f7e8786080c"), 364.817167812812000m, false, new Guid("625f60c7-26bf-4b4d-810a-a53717a7983c"), "Inventore laborum aut rerum ratione rem.", new DateTime(2020, 2, 12, 4, 45, 40, 81, DateTimeKind.Utc).AddTicks(1933), 1 },
                    { new Guid("2b1a0ede-d04c-4a91-ae6d-8da1a38e30dd"), 877.001680012201000m, false, new Guid("58384a47-8236-4a5f-93d7-5913ced82d1e"), "In quis quo et ab quia ab minima non perspiciatis. Distinctio enim odio quia. Assumenda in debitis minus saepe consequuntur perferendis. Commodi porro sit ea impedit praesentium reprehenderit dolore a.", new DateTime(2020, 1, 31, 23, 27, 51, 576, DateTimeKind.Utc).AddTicks(9276), 1 },
                    { new Guid("2cd5519d-0342-4384-9c3d-dc5cd0e5d2e3"), 44.234366346374000m, false, new Guid("fa30eb2d-f8b6-4219-9061-f62f7eeb0f89"), "Autem id eos perspiciatis asperiores voluptatem eos eligendi reprehenderit. Suscipit voluptas velit similique et quas inventore deleniti eaque voluptas. Aut qui odit autem. Dolor est esse qui ab commodi asperiores.", new DateTime(2012, 10, 27, 8, 8, 13, 59, DateTimeKind.Utc).AddTicks(8817), 99 },
                    { new Guid("2e12472e-7b36-47d1-87f5-0137ffc86ad2"), 365.818677093304000m, false, new Guid("625f60c7-26bf-4b4d-810a-a53717a7983c"), "Dolorum ut autem soluta.", new DateTime(2018, 9, 14, 10, 15, 43, 3, DateTimeKind.Utc).AddTicks(4132), 99 },
                    { new Guid("2e5e9b7f-77aa-402b-b07c-6009a951b289"), 618.941763668753000m, false, new Guid("fa30eb2d-f8b6-4219-9061-f62f7eeb0f89"), "Vel qui tenetur alias.", new DateTime(2014, 9, 18, 22, 17, 8, 95, DateTimeKind.Utc).AddTicks(6990), 1 },
                    { new Guid("2e631e15-68df-4e79-acfc-3a7fe44b161f"), 781.634800226754000m, false, new Guid("a09aa449-febf-4318-b933-fe31feb73c9c"), "Rem vel autem. Ducimus et consequatur quos voluptate similique reiciendis quas vel. Dolorem ut omnis magni consequatur sint labore harum. Non sint iusto accusamus.", new DateTime(2013, 10, 9, 7, 42, 11, 59, DateTimeKind.Utc).AddTicks(4072), 0 },
                    { new Guid("2ecb82a7-7d8e-4134-a933-f2736cdde736"), 19.843503669002000m, false, new Guid("9801b0c7-db84-4779-af42-de97aedf9b64"), "Corrupti fugit totam qui architecto eveniet voluptatem ut quidem quisquam.", new DateTime(2015, 5, 10, 13, 11, 0, 113, DateTimeKind.Utc).AddTicks(3683), 1 },
                    { new Guid("309df02c-6d73-4534-80b8-e3308e888add"), 568.64365849911000m, false, new Guid("fa30eb2d-f8b6-4219-9061-f62f7eeb0f89"), "Eos repudiandae quis. Provident laboriosam aut velit sint ullam. Rerum corporis qui consectetur nam assumenda illo quia.", new DateTime(2017, 9, 25, 19, 53, 32, 390, DateTimeKind.Utc).AddTicks(9791), 0 },
                    { new Guid("329d2190-c441-4249-85ff-b9e054a3cb29"), 428.678780538752000m, false, new Guid("6ac03431-5ace-40a8-8672-e40ed7a5cf21"), "Sit vel porro eaque aspernatur.", new DateTime(2016, 4, 2, 8, 48, 17, 608, DateTimeKind.Utc).AddTicks(5296), 99 },
                    { new Guid("32e6381e-b454-4f70-854c-0da5ff25c5b3"), 880.252967838943000m, false, new Guid("90579122-bf74-4a7a-9eba-5c166ddaa313"), "Et in et non ex eum. Quaerat sit repudiandae et eligendi voluptatum dolorem incidunt velit.", new DateTime(2012, 10, 12, 22, 0, 55, 585, DateTimeKind.Utc).AddTicks(6592), 0 },
                    { new Guid("3374177f-1f92-4cad-84ad-03efbae9eec0"), 282.741152935094000m, false, new Guid("399c47ef-caf0-4115-98db-c6c8f6dde507"), "Maiores consequatur accusamus et nisi ex possimus nostrum vitae. Reprehenderit aut illum sit nobis iure aut dolor est facere. Non et ut.", new DateTime(2017, 8, 5, 19, 38, 25, 592, DateTimeKind.Utc).AddTicks(9125), 0 },
                    { new Guid("33c0be77-43e7-461c-8637-e98649f5fb36"), 18.631665681744000m, false, new Guid("a09aa449-febf-4318-b933-fe31feb73c9c"), "Ut dolor iste voluptatum magnam. Neque natus qui ratione eveniet pariatur aut enim. Ut et molestiae rerum rerum. Consequatur ut quibusdam qui est veritatis laudantium.", new DateTime(2013, 4, 4, 11, 59, 23, 355, DateTimeKind.Utc).AddTicks(1248), 1 },
                    { new Guid("34ce5f47-ef5c-4796-a2a8-6d4c910c3a27"), 855.5936625016000m, false, new Guid("6ac03431-5ace-40a8-8672-e40ed7a5cf21"), "Laudantium rerum amet quibusdam temporibus. Quas eligendi laborum quisquam. Quam hic nihil. Non occaecati quibusdam eveniet consequatur.", new DateTime(2013, 5, 30, 13, 46, 6, 921, DateTimeKind.Utc).AddTicks(1020), 99 },
                    { new Guid("35e1d485-2895-4dfc-bdfd-9db50c7740b1"), 771.878714933455000m, false, new Guid("0c865509-3202-49f5-98e7-0a9a4c5c0489"), "Dolore beatae necessitatibus est reiciendis qui.", new DateTime(2012, 10, 12, 3, 26, 12, 97, DateTimeKind.Utc).AddTicks(7146), 0 },
                    { new Guid("370ae24d-5a23-41c7-acf1-51418ada1a02"), 696.315901978666000m, false, new Guid("0c865509-3202-49f5-98e7-0a9a4c5c0489"), "Et qui quia perferendis recusandae aut est consectetur sed et.", new DateTime(2012, 2, 27, 21, 53, 44, 729, DateTimeKind.Utc).AddTicks(2260), 1 },
                    { new Guid("370e2556-0011-4aac-a653-15fd7bf18efe"), 849.125053482874000m, false, new Guid("6ac03431-5ace-40a8-8672-e40ed7a5cf21"), "Mollitia natus tempora beatae quam culpa.", new DateTime(2014, 8, 5, 14, 44, 8, 445, DateTimeKind.Utc).AddTicks(8871), 99 },
                    { new Guid("37abeaf1-ebd8-43d5-8984-bbe9f0cea3c3"), 440.602578469524000m, false, new Guid("d4a59397-3d7d-407f-9a9d-9d5cefe93216"), "Velit sunt consequatur. Voluptate sequi velit et illum recusandae nisi qui. Incidunt rem fugiat. Non saepe optio dolorem et suscipit.", new DateTime(2012, 10, 25, 13, 46, 14, 707, DateTimeKind.Utc).AddTicks(6951), 1 },
                    { new Guid("397aeb46-1cf2-4372-99ea-8c2d1d645f8b"), 202.80577758591000m, false, new Guid("0c865509-3202-49f5-98e7-0a9a4c5c0489"), "Nihil magnam est ratione non consectetur ipsa accusantium alias. Et quo est facilis reiciendis sunt repellendus. Corrupti nulla laboriosam et accusantium amet nulla. Qui quia voluptatum consequatur quia explicabo consectetur sunt.", new DateTime(2019, 7, 2, 10, 19, 20, 734, DateTimeKind.Utc).AddTicks(6112), 1 },
                    { new Guid("3b04435b-f7d4-43ae-9eba-1c3e04927869"), 616.509461964387000m, false, new Guid("666b7a2b-c7e6-4de9-a345-57b8062ad9e6"), "In qui aut et eveniet. Aut ut aut inventore ut vitae ducimus nemo accusamus. Quia eligendi est debitis eos.", new DateTime(2012, 7, 4, 2, 11, 50, 780, DateTimeKind.Utc).AddTicks(6794), 0 },
                    { new Guid("3b5594c5-c890-406e-93b7-ff0f08741d5f"), 828.198618208308000m, false, new Guid("666b7a2b-c7e6-4de9-a345-57b8062ad9e6"), "Veritatis est enim in nisi. Quidem doloribus quae magnam laboriosam. Nostrum deleniti eum.", new DateTime(2021, 2, 2, 4, 36, 7, 411, DateTimeKind.Utc).AddTicks(6365), 1 },
                    { new Guid("3d31108e-ab4f-4edd-9e91-3132d43d4114"), 855.600050564657000m, false, new Guid("e06131eb-f2e1-40d8-b36a-d1f26aceb63c"), "Porro recusandae voluptatem sed exercitationem voluptas.", new DateTime(2021, 10, 18, 17, 15, 49, 811, DateTimeKind.Utc).AddTicks(601), 99 },
                    { new Guid("3e0aaf01-6922-4200-87ee-df8342614c0e"), 953.690375434867000m, false, new Guid("d416c1a3-8b50-4550-8807-55b14fa7e4af"), "Veritatis laudantium repellendus corporis ab neque blanditiis. Deserunt ex eligendi aut. Accusamus quas fuga sunt illo. Rerum provident sed.", new DateTime(2015, 8, 5, 3, 51, 20, 168, DateTimeKind.Utc).AddTicks(552), 1 },
                    { new Guid("405b36cb-46ea-4080-9329-c0b0a3152a45"), 569.365450005171000m, false, new Guid("a09aa449-febf-4318-b933-fe31feb73c9c"), "Ut architecto asperiores similique consequatur accusantium. Voluptas minima id. Est deserunt ut officia dolorem aliquid sed. Odio non ex sed aliquam consequatur asperiores quia explicabo.", new DateTime(2013, 6, 24, 17, 23, 6, 100, DateTimeKind.Utc).AddTicks(2426), 1 },
                    { new Guid("4084bf22-e567-4b15-9ee4-fd0cf976e90d"), 617.185501483754000m, false, new Guid("5e3bb94b-9db1-4c98-afcc-75746f0d0050"), "Eum sequi molestias. Quo sint id eum. Quia commodi est dolor aliquam fugiat explicabo est vero voluptatem. Qui eum rerum possimus.", new DateTime(2015, 10, 13, 10, 55, 13, 12, DateTimeKind.Utc).AddTicks(1050), 0 },
                    { new Guid("408ebd7e-c2ff-48e7-857d-baa8434f7115"), 107.391348839059000m, false, new Guid("bf67e662-0d81-4f4a-83bd-727e20a66cb7"), "Magni quos sit sunt eveniet rerum sint laudantium architecto. Aut ut quisquam ea ipsam modi tempore vitae. Sit enim error qui omnis. Quis cupiditate labore repellendus unde deleniti aut accusantium veniam id.", new DateTime(2014, 11, 23, 18, 48, 30, 82, DateTimeKind.Utc).AddTicks(3940), 99 },
                    { new Guid("40d64c1b-c585-4516-827f-b23804ffe215"), 26.8207645711914000m, false, new Guid("d4a59397-3d7d-407f-9a9d-9d5cefe93216"), "A earum rerum perferendis voluptatem tempora magni consequatur sint. Voluptatem est sint quia. Quis tenetur porro rerum nulla perspiciatis commodi eum.", new DateTime(2018, 10, 9, 15, 0, 47, 575, DateTimeKind.Utc).AddTicks(1234), 0 },
                    { new Guid("4253b4c9-2d28-4059-b0ef-949b6f485dea"), 768.789272254572000m, false, new Guid("bf67e662-0d81-4f4a-83bd-727e20a66cb7"), "Tempora quo quas dolorem natus molestias molestiae nemo. Odio eum ad ex.", new DateTime(2019, 9, 30, 0, 33, 54, 754, DateTimeKind.Utc).AddTicks(1040), 1 },
                    { new Guid("49f081db-96f5-4ef9-bb5f-b166d6ee69a5"), 16.5582479983575000m, false, new Guid("321b519a-bead-4408-8e85-cfd5c7afe182"), "Corrupti pariatur quidem id quia non nostrum sint pariatur voluptatibus. Assumenda reiciendis eligendi vitae a facere quam dolore inventore fugiat. Illum perferendis error a consequatur corrupti. Sed placeat temporibus molestiae ea qui voluptas culpa magnam.", new DateTime(2012, 8, 20, 19, 3, 16, 308, DateTimeKind.Utc).AddTicks(4773), 99 },
                    { new Guid("4ac6ab16-180e-4a4a-9345-77b549fc04af"), 675.430964195666000m, false, new Guid("90579122-bf74-4a7a-9eba-5c166ddaa313"), "Quia quae totam nam aperiam. Impedit molestiae ipsam adipisci et.", new DateTime(2014, 6, 11, 18, 9, 30, 762, DateTimeKind.Utc).AddTicks(4577), 0 },
                    { new Guid("4b36cb58-3149-4c8c-97d7-c6915670c217"), 368.362405829477000m, false, new Guid("e06131eb-f2e1-40d8-b36a-d1f26aceb63c"), "Omnis qui quos. Illo sunt alias omnis.", new DateTime(2021, 12, 27, 5, 42, 2, 581, DateTimeKind.Utc).AddTicks(4607), 99 },
                    { new Guid("4d12fd77-a5e9-445b-87f1-376b57dc36da"), 180.301671392285000m, false, new Guid("d416c1a3-8b50-4550-8807-55b14fa7e4af"), "Mollitia accusamus omnis officiis dignissimos. Eligendi dolores minima enim.", new DateTime(2016, 9, 20, 16, 40, 54, 59, DateTimeKind.Utc).AddTicks(3652), 99 },
                    { new Guid("4d31e9c9-9b5d-4a1c-b5ce-00b4a7ebf4ed"), 512.961235760827000m, false, new Guid("5e3bb94b-9db1-4c98-afcc-75746f0d0050"), "Eos et cumque quia illum reiciendis eveniet.", new DateTime(2013, 3, 10, 16, 6, 17, 229, DateTimeKind.Utc).AddTicks(2593), 99 },
                    { new Guid("4f2457a6-3999-4d40-ad10-26abfac782d6"), 756.324364971714000m, false, new Guid("9801b0c7-db84-4779-af42-de97aedf9b64"), "Qui sapiente ipsum repudiandae qui delectus voluptas. Voluptatem iusto reprehenderit laboriosam quia voluptatem rem sit laudantium. Soluta aut eum est consectetur culpa autem quisquam. Aperiam cumque excepturi.", new DateTime(2021, 1, 27, 21, 7, 38, 160, DateTimeKind.Utc).AddTicks(2048), 1 },
                    { new Guid("50f54a38-b992-4d73-8d58-2aca6cb3eb90"), 445.777700958873000m, false, new Guid("b560e47d-09da-4044-bd0a-6172a633478b"), "Velit reiciendis dolores vel sit. Alias magnam qui. Porro explicabo atque quis quod sed sed possimus eligendi.", new DateTime(2016, 6, 29, 8, 13, 15, 736, DateTimeKind.Utc).AddTicks(8270), 0 },
                    { new Guid("51f67c33-9465-4747-a31c-c7025f2006d2"), 491.433092298524000m, false, new Guid("b560e47d-09da-4044-bd0a-6172a633478b"), "Saepe est animi dicta mollitia odit quia. Perferendis nisi doloribus nihil eos voluptas quis rerum vero aperiam. Quam et culpa unde maxime alias repudiandae aut dolores.", new DateTime(2014, 1, 15, 5, 59, 26, 114, DateTimeKind.Utc).AddTicks(487), 99 },
                    { new Guid("524cbc86-6ad1-40e0-beef-6a7c4770e6d9"), 589.646303408876000m, false, new Guid("d4a59397-3d7d-407f-9a9d-9d5cefe93216"), "Nihil neque consequuntur voluptas earum.", new DateTime(2021, 6, 13, 14, 41, 31, 538, DateTimeKind.Utc).AddTicks(4763), 1 },
                    { new Guid("5290ee7d-fe1d-432a-ba9d-46edb6d61526"), 336.784620462355000m, false, new Guid("c12da2dc-533c-43bc-ad77-fc3a97ae0300"), "Et id voluptatum. Possimus voluptas vero minus asperiores molestiae quod repellendus dolorem.", new DateTime(2016, 12, 26, 4, 21, 30, 378, DateTimeKind.Utc).AddTicks(5454), 1 },
                    { new Guid("52cfcdba-ab1f-48f6-b2a5-5e641cfa974f"), 974.755927363318000m, false, new Guid("3021a50b-2e14-4860-a432-98a126642eb9"), "Ut facilis rerum culpa. Quam esse ab architecto. Et harum corrupti est mollitia est assumenda veniam possimus. Praesentium minima odio minima illum aut sed.", new DateTime(2020, 10, 28, 16, 9, 15, 21, DateTimeKind.Utc).AddTicks(3851), 99 },
                    { new Guid("537b7bea-ace8-4a4c-aa25-742e932f2247"), 651.014382230417000m, false, new Guid("5e3bb94b-9db1-4c98-afcc-75746f0d0050"), "Ipsam officiis voluptates. Earum sunt nemo aut adipisci quo voluptatibus iusto id. Qui laudantium pariatur ratione.", new DateTime(2021, 3, 15, 18, 37, 6, 430, DateTimeKind.Utc).AddTicks(1406), 99 },
                    { new Guid("538deefd-7edf-4b09-868e-0553dc218235"), 767.412963847379000m, false, new Guid("d4a59397-3d7d-407f-9a9d-9d5cefe93216"), "Voluptatem praesentium enim perferendis. Cum quia autem soluta id ea dignissimos dicta cumque.", new DateTime(2021, 4, 28, 1, 56, 23, 739, DateTimeKind.Utc).AddTicks(5174), 99 },
                    { new Guid("53b7c50f-5c42-47ac-9ecf-6160caeca8b5"), 136.627052606531000m, false, new Guid("d416c1a3-8b50-4550-8807-55b14fa7e4af"), "Eum ea incidunt sit id placeat beatae. Nobis qui quos laborum rerum quisquam aut voluptatibus perspiciatis labore. Repudiandae excepturi rerum quae nam voluptatum.", new DateTime(2018, 6, 29, 9, 5, 10, 913, DateTimeKind.Utc).AddTicks(4520), 0 },
                    { new Guid("55a22667-6aec-42ac-9a93-e47dac4bc257"), 660.019206576253000m, false, new Guid("6ac03431-5ace-40a8-8672-e40ed7a5cf21"), "Culpa qui molestiae quia aut sint placeat sint enim autem. Nulla beatae voluptatem aliquid.", new DateTime(2015, 11, 6, 20, 36, 59, 50, DateTimeKind.Utc).AddTicks(2435), 0 },
                    { new Guid("55aafbb1-ef79-4b3b-bdfd-905e4e98c132"), 526.800381188419000m, false, new Guid("666b7a2b-c7e6-4de9-a345-57b8062ad9e6"), "Voluptas delectus dolores explicabo ducimus reprehenderit dicta. Quaerat cumque iure sapiente aperiam temporibus aut omnis.", new DateTime(2017, 11, 29, 4, 26, 43, 55, DateTimeKind.Utc).AddTicks(9715), 99 },
                    { new Guid("579330e0-ab1f-4edf-b288-ddce26a0c473"), 933.276431373856000m, false, new Guid("58384a47-8236-4a5f-93d7-5913ced82d1e"), "Quasi qui assumenda quis sequi voluptas voluptatum optio ipsam nemo. Fugiat enim est minus eum perferendis. Adipisci ea beatae accusantium aut quo est. Iure voluptates reiciendis rerum dolorem soluta maxime consequatur ut.", new DateTime(2016, 4, 27, 13, 30, 1, 393, DateTimeKind.Utc).AddTicks(3198), 0 },
                    { new Guid("5821175f-ce5b-482c-a6cc-e1407e9c4170"), 207.579039283175000m, false, new Guid("0c865509-3202-49f5-98e7-0a9a4c5c0489"), "Vel est nulla esse omnis voluptatem. Et ut qui assumenda laborum.", new DateTime(2020, 4, 10, 11, 15, 45, 514, DateTimeKind.Utc).AddTicks(4271), 0 },
                    { new Guid("59fa3868-2f09-4b26-a37e-763033dae4fb"), 799.994846456507000m, false, new Guid("d4a59397-3d7d-407f-9a9d-9d5cefe93216"), "Nihil neque velit voluptatem sit dolor earum beatae iure accusantium. Nesciunt velit voluptate nihil. Sed sit optio eum ipsum id autem. Qui facilis sed sint et.", new DateTime(2012, 11, 8, 14, 3, 10, 325, DateTimeKind.Utc).AddTicks(4348), 99 },
                    { new Guid("5a5e0c52-f566-43e9-ac91-2e3efe4dd70f"), 361.954864212873000m, false, new Guid("399c47ef-caf0-4115-98db-c6c8f6dde507"), "Error maxime corrupti harum.", new DateTime(2018, 6, 22, 9, 46, 42, 609, DateTimeKind.Utc).AddTicks(9215), 0 },
                    { new Guid("5b1aefce-206a-4477-b671-c1720be3a883"), 205.494835964068000m, false, new Guid("3021a50b-2e14-4860-a432-98a126642eb9"), "Natus officia nihil aut in et. Quas eos non rem doloribus harum accusantium eum.", new DateTime(2018, 3, 20, 12, 25, 28, 640, DateTimeKind.Utc).AddTicks(4896), 1 },
                    { new Guid("5b7f599d-52aa-49d8-a1db-b54d43b06b79"), 681.21775055565000m, false, new Guid("58384a47-8236-4a5f-93d7-5913ced82d1e"), "Dolore sit nostrum autem. Perferendis delectus et repudiandae illum sapiente et nihil quia eligendi. Nisi quia ab consequuntur sapiente debitis. Aut fugiat dolorem quia omnis incidunt aut corrupti autem numquam.", new DateTime(2013, 8, 17, 5, 9, 43, 544, DateTimeKind.Utc).AddTicks(9481), 0 },
                    { new Guid("5c43807a-fffe-4649-90fd-86bf98cb13f0"), 239.995614033527000m, false, new Guid("d4a59397-3d7d-407f-9a9d-9d5cefe93216"), "Aut non illum explicabo. Enim qui exercitationem fugiat omnis. Eos ipsam ut voluptatem in soluta ea. Nobis cum sed consequatur.", new DateTime(2013, 9, 18, 15, 36, 55, 238, DateTimeKind.Utc).AddTicks(6676), 99 },
                    { new Guid("5c46989e-b906-4a42-8177-0966d91047f3"), 47.8422468582007000m, false, new Guid("3021a50b-2e14-4860-a432-98a126642eb9"), "Incidunt quasi soluta possimus odio. Voluptatibus sequi laboriosam dolores consequatur quae et sunt. Fugiat consectetur occaecati facilis ratione similique repellat quia voluptatem. Velit nihil quidem.", new DateTime(2012, 2, 3, 1, 30, 47, 596, DateTimeKind.Utc).AddTicks(3038), 0 },
                    { new Guid("5c9d1e63-31d5-4531-8e8c-3a9c1487e121"), 730.830418108682000m, false, new Guid("bf67e662-0d81-4f4a-83bd-727e20a66cb7"), "Voluptatem excepturi et dolorem facilis maxime atque. Facilis consequatur ut officia. Quisquam modi adipisci. Qui consequatur ut sapiente aliquid excepturi illo nemo et consequuntur.", new DateTime(2018, 11, 8, 4, 47, 23, 654, DateTimeKind.Utc).AddTicks(5784), 1 },
                    { new Guid("5da78954-212a-4041-bdc9-794de86d6e74"), 457.942955051678000m, false, new Guid("bf67e662-0d81-4f4a-83bd-727e20a66cb7"), "Exercitationem fuga quis ea suscipit sapiente expedita reiciendis et. Alias voluptate velit molestias laboriosam rerum eius.", new DateTime(2020, 4, 26, 2, 54, 7, 804, DateTimeKind.Utc).AddTicks(1147), 1 },
                    { new Guid("64500c1b-ada7-48b9-aeb0-148545306845"), 523.831320936978000m, false, new Guid("399c47ef-caf0-4115-98db-c6c8f6dde507"), "Distinctio sequi exercitationem ipsa eligendi quis optio voluptatem odit. Officia animi illum aliquam.", new DateTime(2020, 2, 14, 15, 18, 16, 381, DateTimeKind.Utc).AddTicks(444), 99 },
                    { new Guid("65431fb6-33c0-4fdc-923f-7596e5ab6fc6"), 326.08200022141000m, false, new Guid("bf67e662-0d81-4f4a-83bd-727e20a66cb7"), "Dignissimos ut incidunt laboriosam. Hic blanditiis consequuntur.", new DateTime(2016, 6, 11, 13, 48, 10, 657, DateTimeKind.Utc).AddTicks(6685), 1 },
                    { new Guid("6548f000-d5b5-45c3-86ea-0d41ee0110ec"), 614.037550991968000m, false, new Guid("a09aa449-febf-4318-b933-fe31feb73c9c"), "Aut facilis aliquam esse eaque. Illum ipsa esse vero accusamus.", new DateTime(2013, 3, 14, 12, 7, 41, 814, DateTimeKind.Utc).AddTicks(4718), 1 },
                    { new Guid("698b4b06-e778-46a9-b839-ea3bc6c8c12f"), 584.965218906161000m, false, new Guid("399c47ef-caf0-4115-98db-c6c8f6dde507"), "Magni alias natus deserunt deleniti. Rem necessitatibus et dolorem repellat dignissimos quo est.", new DateTime(2015, 1, 15, 10, 49, 13, 579, DateTimeKind.Utc).AddTicks(4888), 0 },
                    { new Guid("69e7c61b-412e-4027-a1b9-f04c78299690"), 605.276149694458000m, false, new Guid("e06131eb-f2e1-40d8-b36a-d1f26aceb63c"), "Ratione voluptatem eos cupiditate vel. Consequatur veniam maiores amet eum magni quia.", new DateTime(2014, 3, 22, 21, 46, 41, 478, DateTimeKind.Utc).AddTicks(7024), 1 },
                    { new Guid("6c1579c3-3729-46de-be66-031f7c34803f"), 949.898178888218000m, false, new Guid("625f60c7-26bf-4b4d-810a-a53717a7983c"), "Vero officiis nisi. Et cum ipsum est saepe. Neque id quis possimus maiores laboriosam corrupti. Ullam repellat voluptatibus perferendis.", new DateTime(2012, 4, 15, 12, 28, 37, 639, DateTimeKind.Utc).AddTicks(4656), 0 },
                    { new Guid("6cddca7c-526a-4d1d-aacb-84326ea56d9f"), 515.263385691617000m, false, new Guid("6ac03431-5ace-40a8-8672-e40ed7a5cf21"), "Nisi totam et quia et quae qui. Non est autem nihil debitis voluptas.", new DateTime(2015, 1, 26, 7, 22, 8, 66, DateTimeKind.Utc).AddTicks(9455), 99 },
                    { new Guid("6d226bda-0137-4eea-854e-fe71ead7ea18"), 206.491975410462000m, false, new Guid("321b519a-bead-4408-8e85-cfd5c7afe182"), "At eum non iusto et ut quis rerum.", new DateTime(2013, 12, 5, 0, 41, 35, 51, DateTimeKind.Utc).AddTicks(5507), 99 },
                    { new Guid("6d57b147-6d15-4e08-96be-8e8c9761a17b"), 691.98841017882000m, false, new Guid("5e3bb94b-9db1-4c98-afcc-75746f0d0050"), "Impedit reiciendis eveniet vero id quidem laudantium ea possimus aut. Omnis et pariatur consectetur magnam vel qui atque.", new DateTime(2015, 7, 21, 9, 59, 52, 937, DateTimeKind.Utc).AddTicks(3686), 1 },
                    { new Guid("6dd6aa11-a3e7-498a-a6e1-ef10a6b24237"), 960.538153114825000m, false, new Guid("321b519a-bead-4408-8e85-cfd5c7afe182"), "Fuga nam quas inventore quia adipisci veritatis.", new DateTime(2017, 2, 4, 13, 48, 1, 462, DateTimeKind.Utc).AddTicks(560), 0 },
                    { new Guid("6dda8334-d88c-4229-9c87-ecb2c1350863"), 882.845607901197000m, false, new Guid("5e3bb94b-9db1-4c98-afcc-75746f0d0050"), "Aut laboriosam voluptatem adipisci dolor est officia qui numquam rem. Voluptatum modi saepe eius et. Voluptas facere doloremque ea et voluptatum quisquam non.", new DateTime(2019, 6, 6, 1, 18, 38, 502, DateTimeKind.Utc).AddTicks(7486), 0 },
                    { new Guid("6e721324-2580-4e98-af92-e2d232aac967"), 692.828268438686000m, false, new Guid("666b7a2b-c7e6-4de9-a345-57b8062ad9e6"), "Ad et corrupti eos reprehenderit in. Nulla aut sed aut sit saepe eius totam fuga fugiat. Fuga deleniti vel commodi.", new DateTime(2016, 6, 2, 0, 56, 53, 685, DateTimeKind.Utc).AddTicks(2838), 1 },
                    { new Guid("7097510f-9886-4acc-be8e-b390fd7e0a61"), 951.294094451711000m, false, new Guid("b560e47d-09da-4044-bd0a-6172a633478b"), "Voluptates omnis aspernatur occaecati consequuntur ut neque asperiores.", new DateTime(2013, 6, 27, 5, 44, 32, 883, DateTimeKind.Utc).AddTicks(8442), 99 },
                    { new Guid("717e3211-c97e-46db-a875-bcbcb570296c"), 200.236450909765000m, false, new Guid("0c865509-3202-49f5-98e7-0a9a4c5c0489"), "Aliquam explicabo suscipit qui.", new DateTime(2020, 4, 22, 4, 11, 14, 571, DateTimeKind.Utc).AddTicks(2524), 0 },
                    { new Guid("71a0d090-30d0-4454-b937-d5252ed9704f"), 344.814199809136000m, false, new Guid("b560e47d-09da-4044-bd0a-6172a633478b"), "Odit sed animi. Qui qui cupiditate temporibus dignissimos eum. At et adipisci omnis repellendus. Nihil excepturi qui enim cum consequatur quia et.", new DateTime(2015, 11, 5, 22, 15, 48, 112, DateTimeKind.Utc).AddTicks(1370), 1 },
                    { new Guid("71d0ff9f-ca69-4ccc-897b-ffff0b9c8979"), 320.08780680722000m, false, new Guid("b560e47d-09da-4044-bd0a-6172a633478b"), "Necessitatibus et beatae quisquam quaerat quae veniam ipsam. Id harum quia dolorem esse fugiat est. Rerum et pariatur omnis in qui incidunt.", new DateTime(2013, 3, 8, 10, 20, 36, 392, DateTimeKind.Utc).AddTicks(3386), 99 },
                    { new Guid("73eebda4-189f-44c9-8d6d-f72c7b46ec9a"), 365.158265550633000m, false, new Guid("fa30eb2d-f8b6-4219-9061-f62f7eeb0f89"), "Ut neque aut voluptatem magnam aspernatur autem aperiam.", new DateTime(2016, 12, 1, 10, 21, 45, 266, DateTimeKind.Utc).AddTicks(5008), 0 },
                    { new Guid("74e771c2-ef73-48b6-9c8d-c17d883d05ca"), 900.601461759742000m, false, new Guid("cb817682-2116-4baa-9960-edd372cd2bf2"), "Totam magnam sunt hic itaque. Nam totam omnis ab. Commodi ullam quia in.", new DateTime(2016, 5, 6, 3, 20, 17, 778, DateTimeKind.Utc).AddTicks(2611), 99 },
                    { new Guid("77b488c6-4632-4b6c-9d7f-f41a9c35d7e3"), 366.663116981059000m, false, new Guid("90579122-bf74-4a7a-9eba-5c166ddaa313"), "Nesciunt omnis repellendus nulla dicta quia. Quasi ea sequi voluptas. Doloribus magni eum adipisci dicta dolorem. Ut molestiae qui unde doloremque quo maiores tempore est.", new DateTime(2016, 6, 16, 17, 20, 31, 389, DateTimeKind.Utc).AddTicks(8965), 0 },
                    { new Guid("785bdf27-9f2a-45ca-b324-c8e89f8ba17d"), 969.323837176338000m, false, new Guid("b560e47d-09da-4044-bd0a-6172a633478b"), "Delectus omnis reprehenderit alias voluptatem quisquam et asperiores.", new DateTime(2017, 2, 14, 8, 18, 23, 805, DateTimeKind.Utc).AddTicks(1921), 1 },
                    { new Guid("796d6ae7-8cdf-458e-90ad-27840ea161ed"), 683.703389367982000m, false, new Guid("58384a47-8236-4a5f-93d7-5913ced82d1e"), "Consequatur quibusdam sunt. Delectus incidunt id numquam. Ipsum deserunt eos porro.", new DateTime(2018, 5, 1, 16, 43, 21, 452, DateTimeKind.Utc).AddTicks(3141), 99 },
                    { new Guid("7abbe6ed-7cd7-4e1c-b31d-2203278fe947"), 750.450264855202000m, false, new Guid("b560e47d-09da-4044-bd0a-6172a633478b"), "Nam qui quidem ab consectetur. Qui aliquam adipisci sequi nihil excepturi.", new DateTime(2017, 3, 29, 5, 2, 44, 500, DateTimeKind.Utc).AddTicks(7623), 99 },
                    { new Guid("7b002fe3-b731-4794-92c9-54fd791d0b82"), 809.384317182729000m, false, new Guid("625f60c7-26bf-4b4d-810a-a53717a7983c"), "Aut voluptas in rerum qui aliquam nesciunt. Veritatis placeat corrupti ullam odio ut.", new DateTime(2018, 6, 16, 23, 22, 19, 979, DateTimeKind.Utc).AddTicks(9764), 0 },
                    { new Guid("7bc37bb7-eb42-4845-9ce2-69ff6f89f660"), 994.922588726143000m, false, new Guid("90579122-bf74-4a7a-9eba-5c166ddaa313"), "Laudantium praesentium sed aut autem minima neque minus facere nostrum. Unde nam nihil deserunt iure ut molestias dicta est voluptate.", new DateTime(2014, 4, 10, 16, 8, 18, 151, DateTimeKind.Utc).AddTicks(9408), 0 },
                    { new Guid("7dd9eaab-31a9-490b-b040-07e06402f1b3"), 929.623180681667000m, false, new Guid("90579122-bf74-4a7a-9eba-5c166ddaa313"), "Assumenda ratione officiis.", new DateTime(2013, 10, 8, 23, 53, 52, 553, DateTimeKind.Utc).AddTicks(9204), 99 },
                    { new Guid("7de5afd7-24ae-47ca-a873-30bcfd7adc90"), 930.007057415612000m, false, new Guid("58384a47-8236-4a5f-93d7-5913ced82d1e"), "Iusto ea recusandae corrupti aut consequatur quibusdam officiis dolores. Blanditiis doloremque provident qui eum. Voluptas dolores libero voluptatem repudiandae velit praesentium amet dolor tempora. Enim cum vel.", new DateTime(2013, 3, 27, 2, 28, 11, 529, DateTimeKind.Utc).AddTicks(4473), 99 },
                    { new Guid("7f45f83f-502b-4252-8725-0f4ea8057ba1"), 817.879877012575000m, false, new Guid("6ac03431-5ace-40a8-8672-e40ed7a5cf21"), "Labore aut in labore. Quod aut quia hic quos id.", new DateTime(2013, 4, 1, 8, 30, 18, 65, DateTimeKind.Utc).AddTicks(8039), 0 },
                    { new Guid("7fadee7e-4877-4863-8048-73eeac97b4b2"), 135.74595170211000m, false, new Guid("3021a50b-2e14-4860-a432-98a126642eb9"), "Sunt quia recusandae cumque fugit praesentium nisi perferendis. Dolorem aut id nesciunt debitis dolorum fuga eligendi dolor eum. Distinctio eius aliquam at fugit ducimus totam voluptate sint aut. Recusandae deserunt inventore ut qui vero rem atque dicta a.", new DateTime(2021, 1, 9, 2, 21, 45, 53, DateTimeKind.Utc).AddTicks(3320), 0 },
                    { new Guid("8004b9c2-5802-4447-b16f-fa47bab968f8"), 597.709449085404000m, false, new Guid("9801b0c7-db84-4779-af42-de97aedf9b64"), "Quos quo consequatur sunt inventore dolores. Optio ut dolores fugiat assumenda autem ut iure quaerat.", new DateTime(2021, 12, 24, 15, 41, 13, 552, DateTimeKind.Utc).AddTicks(8756), 99 },
                    { new Guid("80b3d05e-aceb-4d34-9861-0f35bff6a7bc"), 14.2305648978355000m, false, new Guid("d416c1a3-8b50-4550-8807-55b14fa7e4af"), "Voluptas voluptates omnis suscipit alias quae quia et. Tempore nostrum vel at ullam.", new DateTime(2013, 9, 17, 7, 57, 54, 632, DateTimeKind.Utc).AddTicks(5183), 99 },
                    { new Guid("82847c2d-3e66-4bb8-8b79-25dd15ff7e8b"), 811.798274109361000m, false, new Guid("d416c1a3-8b50-4550-8807-55b14fa7e4af"), "Vitae et nostrum sit in vel assumenda veniam non alias. Ut aspernatur qui. Quia odit sint non ut nihil dignissimos soluta eum.", new DateTime(2019, 3, 16, 8, 20, 59, 804, DateTimeKind.Utc).AddTicks(9280), 1 },
                    { new Guid("82dede15-8895-45c6-9052-723b257f6566"), 761.013906189322000m, false, new Guid("a09aa449-febf-4318-b933-fe31feb73c9c"), "Excepturi ea facilis ea laborum repellendus eum. Rerum eum natus rerum quis praesentium sed id. Placeat voluptatibus ea enim dolorem molestias accusantium.", new DateTime(2021, 6, 22, 23, 57, 57, 367, DateTimeKind.Utc).AddTicks(8827), 1 },
                    { new Guid("8318a161-1b7f-403d-ae23-f26f4f583921"), 537.113694013836000m, false, new Guid("c12da2dc-533c-43bc-ad77-fc3a97ae0300"), "At doloribus deserunt dignissimos maxime.", new DateTime(2013, 4, 8, 18, 17, 51, 841, DateTimeKind.Utc).AddTicks(1708), 99 },
                    { new Guid("83a6d8bd-bf77-46e9-8802-2815c0bcb41b"), 233.057991821313000m, false, new Guid("a09aa449-febf-4318-b933-fe31feb73c9c"), "Est deserunt et necessitatibus neque ut veniam. Praesentium optio expedita molestias fuga incidunt rem. Quia eum est eum vitae rem vel reiciendis et porro. Earum magnam ratione.", new DateTime(2021, 9, 16, 15, 56, 30, 775, DateTimeKind.Utc).AddTicks(708), 1 },
                    { new Guid("83f9e9b0-b888-4669-8b9a-803a0c850b4a"), 708.426216612262000m, false, new Guid("0c865509-3202-49f5-98e7-0a9a4c5c0489"), "Voluptas fuga dolores distinctio maxime. Error aspernatur repellendus sed voluptas rerum voluptas et. Quo maxime qui et voluptas voluptate quod architecto.", new DateTime(2015, 7, 13, 16, 46, 29, 674, DateTimeKind.Utc).AddTicks(846), 1 },
                    { new Guid("867c429e-a7ae-4fcd-bc71-b848ffd25993"), 220.305230594164000m, false, new Guid("58384a47-8236-4a5f-93d7-5913ced82d1e"), "Quis assumenda unde. Laboriosam et aut aut. Sed veritatis molestiae est ducimus consequatur.", new DateTime(2015, 3, 22, 19, 52, 23, 62, DateTimeKind.Utc).AddTicks(8018), 1 },
                    { new Guid("86985c6c-752b-43d5-be97-4d3787a4f625"), 220.171309908038000m, false, new Guid("625f60c7-26bf-4b4d-810a-a53717a7983c"), "Harum aut ut debitis vel ut. Ipsum deserunt mollitia qui rerum id. Voluptatibus minus sapiente quae commodi eveniet.", new DateTime(2020, 9, 11, 8, 11, 30, 318, DateTimeKind.Utc).AddTicks(8512), 99 },
                    { new Guid("88c09656-022f-4208-82b4-8afb6a275262"), 972.301566684426000m, false, new Guid("5e3bb94b-9db1-4c98-afcc-75746f0d0050"), "Rerum qui rem ipsam numquam a dolorum amet quo facere. Excepturi magni accusantium.", new DateTime(2021, 9, 7, 14, 7, 14, 140, DateTimeKind.Utc).AddTicks(5627), 99 },
                    { new Guid("898e25b9-1b3a-4182-aff2-a17827a99344"), 205.407734809381000m, false, new Guid("cb817682-2116-4baa-9960-edd372cd2bf2"), "Repellendus beatae modi. Modi accusamus nesciunt tempore.", new DateTime(2018, 2, 12, 10, 44, 14, 631, DateTimeKind.Utc).AddTicks(2125), 0 },
                    { new Guid("8dea5e20-f584-418c-bd6c-2800dd389c74"), 956.327511565039000m, false, new Guid("c12da2dc-533c-43bc-ad77-fc3a97ae0300"), "Ut odit in odio. Id amet ullam ut modi ipsam. Magni nostrum vero maxime reprehenderit.", new DateTime(2015, 12, 9, 21, 48, 7, 689, DateTimeKind.Utc).AddTicks(6951), 99 },
                    { new Guid("8ff6e2d1-6807-4e48-8e50-bcf00496a0af"), 18.4025713381862000m, false, new Guid("666b7a2b-c7e6-4de9-a345-57b8062ad9e6"), "Earum exercitationem officiis ex aut dolor nulla et libero alias. Nobis alias facilis in.", new DateTime(2016, 6, 9, 4, 25, 36, 119, DateTimeKind.Utc).AddTicks(1059), 1 },
                    { new Guid("90486c45-d6b6-442e-9bf4-913307092271"), 204.172538894331000m, false, new Guid("bf67e662-0d81-4f4a-83bd-727e20a66cb7"), "Libero voluptatibus enim dolorem voluptatibus est odit similique sed. Iste quam sit ut fugiat. Ut vel molestiae.", new DateTime(2012, 5, 11, 20, 59, 24, 250, DateTimeKind.Utc).AddTicks(5169), 99 },
                    { new Guid("95778710-f6f7-4cd7-8f06-f12976121135"), 869.892640203686000m, false, new Guid("399c47ef-caf0-4115-98db-c6c8f6dde507"), "Neque eum optio ullam odit exercitationem et corporis debitis vel. Ipsum fugit sit quo tempora consequatur alias. Magni quas rem exercitationem perspiciatis sint est accusamus.", new DateTime(2016, 9, 18, 1, 24, 3, 767, DateTimeKind.Utc).AddTicks(4787), 0 },
                    { new Guid("95b75201-5bfb-43b9-8f3f-0e6f793fa7b1"), 550.790284416304000m, false, new Guid("0c865509-3202-49f5-98e7-0a9a4c5c0489"), "Pariatur natus quo repellat soluta voluptatum recusandae. Sint suscipit officiis at reiciendis doloribus facilis dolorum aut. Quia perspiciatis tempora praesentium animi.", new DateTime(2019, 10, 12, 3, 53, 42, 670, DateTimeKind.Utc).AddTicks(9205), 1 },
                    { new Guid("9620b9be-0b58-4466-a3c9-f4b559679e4a"), 495.076562721229000m, false, new Guid("666b7a2b-c7e6-4de9-a345-57b8062ad9e6"), "Iure sed dignissimos delectus. Earum provident voluptatem quia laboriosam repellendus dolorem.", new DateTime(2020, 8, 19, 20, 10, 48, 637, DateTimeKind.Utc).AddTicks(4817), 0 },
                    { new Guid("96a39575-6b4a-452c-b7c0-6cc44ae628be"), 782.403639004668000m, false, new Guid("399c47ef-caf0-4115-98db-c6c8f6dde507"), "Voluptatem ea omnis aut incidunt pariatur quia. Sapiente consequuntur ea. Sit expedita pariatur sunt est hic quidem tempora provident.", new DateTime(2017, 6, 10, 18, 27, 38, 949, DateTimeKind.Utc).AddTicks(5120), 0 },
                    { new Guid("98cb7dc9-9d43-447e-8aee-f2f6eb41603b"), 534.775355695108000m, false, new Guid("321b519a-bead-4408-8e85-cfd5c7afe182"), "Numquam porro id vel id vel saepe quo nostrum aut. Ipsa dolore non repudiandae aspernatur. Dignissimos magnam expedita voluptates sed mollitia repudiandae. Qui explicabo non laborum.", new DateTime(2017, 4, 30, 10, 36, 16, 260, DateTimeKind.Utc).AddTicks(7495), 99 },
                    { new Guid("9d72a1c3-ae66-4f6a-b76f-57cf6c941242"), 942.112050053084000m, false, new Guid("e06131eb-f2e1-40d8-b36a-d1f26aceb63c"), "A a molestiae officia itaque quo.", new DateTime(2017, 6, 15, 17, 42, 36, 833, DateTimeKind.Utc).AddTicks(6976), 99 },
                    { new Guid("a12e7d9c-3edc-4658-b247-d5028d702be4"), 20.3642280532019000m, false, new Guid("d416c1a3-8b50-4550-8807-55b14fa7e4af"), "Est beatae a fugit consectetur. Deserunt dicta expedita explicabo delectus.", new DateTime(2015, 6, 27, 2, 28, 47, 395, DateTimeKind.Utc).AddTicks(3033), 99 },
                    { new Guid("a1778c57-d2f0-40ef-ba2f-72eac586d08e"), 646.133349090427000m, false, new Guid("d416c1a3-8b50-4550-8807-55b14fa7e4af"), "Et dolorem dolorum. Ipsam aut doloribus qui. Ut quos adipisci.", new DateTime(2017, 1, 23, 11, 7, 1, 257, DateTimeKind.Utc).AddTicks(8904), 99 },
                    { new Guid("a3597d7f-7fd3-49ab-9aef-598b7d662074"), 976.916774283738000m, false, new Guid("90579122-bf74-4a7a-9eba-5c166ddaa313"), "Velit quia labore.", new DateTime(2021, 11, 2, 14, 50, 31, 427, DateTimeKind.Utc).AddTicks(1107), 1 },
                    { new Guid("a36d5ff6-7c7b-45a7-b495-f2c2c10b0277"), 995.899475510713000m, false, new Guid("c12da2dc-533c-43bc-ad77-fc3a97ae0300"), "Consequatur voluptatibus quae fugiat voluptatum saepe dolores at suscipit modi. Autem repudiandae fugiat qui omnis placeat in eius ex.", new DateTime(2015, 10, 6, 13, 14, 4, 12, DateTimeKind.Utc).AddTicks(8606), 99 },
                    { new Guid("a55e61a8-1e54-4030-9cc3-6027e8652e27"), 363.772461376852000m, false, new Guid("321b519a-bead-4408-8e85-cfd5c7afe182"), "Exercitationem quia quae ipsum esse occaecati rem. Ut unde qui aperiam deserunt voluptas. Eum nihil soluta rerum voluptatibus nihil quam inventore non. Illo est quam amet incidunt doloribus dolorem similique occaecati.", new DateTime(2019, 1, 17, 11, 23, 13, 904, DateTimeKind.Utc).AddTicks(8261), 99 },
                    { new Guid("a63bdb50-b1ee-49ff-9665-27ef17e723de"), 362.71542895269000m, false, new Guid("9801b0c7-db84-4779-af42-de97aedf9b64"), "Illum aliquid corporis.", new DateTime(2015, 9, 29, 16, 2, 54, 818, DateTimeKind.Utc).AddTicks(3328), 0 },
                    { new Guid("a65a2fc6-46a5-4142-af4b-ed1c3f342c12"), 717.176743088234000m, false, new Guid("cb817682-2116-4baa-9960-edd372cd2bf2"), "Et quod dignissimos et voluptatem. Quasi minus voluptatibus dolorum ad facere saepe odio corporis.", new DateTime(2012, 8, 11, 3, 28, 34, 350, DateTimeKind.Utc).AddTicks(780), 99 },
                    { new Guid("a9645889-11a6-46be-8cef-12f3aaf95dca"), 865.160359118614000m, false, new Guid("b560e47d-09da-4044-bd0a-6172a633478b"), "Illo non iste et. Eum dicta molestias architecto voluptas recusandae molestiae culpa. Nihil consequatur ab occaecati laborum.", new DateTime(2015, 7, 28, 22, 25, 31, 936, DateTimeKind.Utc).AddTicks(19), 1 },
                    { new Guid("ac934d7b-a8fe-4e93-87bd-27e37cc411f6"), 407.789357804753000m, false, new Guid("666b7a2b-c7e6-4de9-a345-57b8062ad9e6"), "Debitis velit nobis porro modi similique. Possimus similique aut cum dolorem et sit incidunt assumenda. Ducimus ut sint cumque id asperiores ipsum aperiam quidem qui.", new DateTime(2015, 7, 6, 12, 5, 11, 881, DateTimeKind.Utc).AddTicks(2514), 1 },
                    { new Guid("ace3fb15-3546-4813-aead-bfd83cf3daa3"), 119.024070110746000m, false, new Guid("6ac03431-5ace-40a8-8672-e40ed7a5cf21"), "Quos illo iusto. Molestias et quidem velit mollitia quae.", new DateTime(2018, 8, 9, 1, 27, 35, 782, DateTimeKind.Utc).AddTicks(1366), 0 },
                    { new Guid("af4c5937-2d09-4768-bd7e-22589912ad28"), 759.473397803295000m, false, new Guid("c12da2dc-533c-43bc-ad77-fc3a97ae0300"), "Qui placeat quis. Sed delectus voluptas maiores. Et omnis commodi maiores distinctio facilis commodi cupiditate quisquam debitis.", new DateTime(2021, 11, 12, 5, 50, 9, 551, DateTimeKind.Utc).AddTicks(78), 99 },
                    { new Guid("b17931de-9fa3-4f3a-b077-abd8b6b41dba"), 765.761228925751000m, false, new Guid("666b7a2b-c7e6-4de9-a345-57b8062ad9e6"), "Sunt quam neque aliquid sed quis. Et consequuntur cum quo et sed ut consequatur. Amet labore nesciunt fugiat dolore quod.", new DateTime(2013, 8, 7, 16, 46, 42, 335, DateTimeKind.Utc).AddTicks(2734), 99 },
                    { new Guid("b191dac9-ffc9-49cc-8cd0-b4fb80a54675"), 904.15110528679000m, false, new Guid("9801b0c7-db84-4779-af42-de97aedf9b64"), "Sunt sit corporis voluptates totam corrupti consequatur. Sapiente cumque voluptatem nemo suscipit quia quibusdam dolor aut. Consequatur saepe inventore quod et.", new DateTime(2014, 8, 25, 23, 41, 47, 215, DateTimeKind.Utc).AddTicks(4360), 99 },
                    { new Guid("b1f5d10e-aeb5-4870-ae7d-ef54b614c52d"), 163.354578999772000m, false, new Guid("cb817682-2116-4baa-9960-edd372cd2bf2"), "Doloribus tenetur voluptas molestiae. Voluptatum error accusamus similique blanditiis ipsa.", new DateTime(2016, 11, 6, 6, 30, 11, 762, DateTimeKind.Utc).AddTicks(348), 99 },
                    { new Guid("b25fe0b2-77a5-4219-a040-ad20189f6610"), 546.228343457017000m, false, new Guid("a09aa449-febf-4318-b933-fe31feb73c9c"), "Excepturi repudiandae atque tempore qui labore. Nobis fugiat a aspernatur deleniti molestias. Ex voluptatem quia.", new DateTime(2013, 12, 16, 17, 0, 25, 594, DateTimeKind.Utc).AddTicks(2437), 99 },
                    { new Guid("b4789ad8-5304-4bfc-abcc-5b22848f0022"), 532.126163849782000m, false, new Guid("cb817682-2116-4baa-9960-edd372cd2bf2"), "Dolor accusamus maiores sed architecto ducimus nam maxime rerum eum. Aut sunt rerum enim autem. Eos in rem enim aliquam tenetur necessitatibus eligendi exercitationem blanditiis.", new DateTime(2017, 2, 13, 23, 0, 11, 764, DateTimeKind.Utc).AddTicks(2578), 0 },
                    { new Guid("b4ab8730-102c-4f5c-bf52-8e9435303bbb"), 395.0030198915000m, false, new Guid("399c47ef-caf0-4115-98db-c6c8f6dde507"), "Accusamus vel dolorem possimus sint earum dicta dolores. Totam fuga perferendis dolor laboriosam libero minima expedita similique deserunt. Consequuntur culpa voluptate qui dolorum reiciendis aspernatur. In velit quo atque dolorem corrupti autem.", new DateTime(2012, 5, 1, 8, 7, 44, 955, DateTimeKind.Utc).AddTicks(417), 0 },
                    { new Guid("b6ca0d19-962c-4bcd-a1d7-620fce87c516"), 766.200981866026000m, false, new Guid("625f60c7-26bf-4b4d-810a-a53717a7983c"), "Cum nostrum dolore est esse ad doloremque.", new DateTime(2015, 6, 25, 15, 21, 17, 715, DateTimeKind.Utc).AddTicks(9427), 99 },
                    { new Guid("b787a8d2-474e-484a-9bf7-de548ea05ce8"), 590.674159961706000m, false, new Guid("58384a47-8236-4a5f-93d7-5913ced82d1e"), "Soluta fugiat voluptatem cumque distinctio rerum.", new DateTime(2012, 4, 30, 12, 3, 41, 64, DateTimeKind.Utc).AddTicks(8485), 0 },
                    { new Guid("ba0f4e9a-f4fb-4926-8f5e-8475176f870d"), 352.475797990542000m, false, new Guid("90579122-bf74-4a7a-9eba-5c166ddaa313"), "Blanditiis veritatis adipisci sed. Est quas ut tempora sapiente aut.", new DateTime(2016, 11, 12, 14, 55, 50, 877, DateTimeKind.Utc).AddTicks(9719), 0 },
                    { new Guid("bb1a0d66-2209-4976-a88f-69b456fcc39f"), 595.725943023459000m, false, new Guid("3021a50b-2e14-4860-a432-98a126642eb9"), "Minima doloremque suscipit. Sit illum eos iure itaque. Numquam nisi quibusdam velit. Suscipit vero laudantium ut.", new DateTime(2014, 11, 27, 9, 51, 18, 688, DateTimeKind.Utc).AddTicks(4653), 0 },
                    { new Guid("be4fdac9-4462-4740-b99c-00f1d26f48f2"), 575.390040147165000m, false, new Guid("9801b0c7-db84-4779-af42-de97aedf9b64"), "Nulla voluptates amet consequatur quia. Ea et consequatur ut. Minus quos voluptas doloremque ut aperiam. Porro quo sed sed nisi modi nobis quod suscipit aut.", new DateTime(2012, 8, 13, 10, 56, 3, 795, DateTimeKind.Utc).AddTicks(1708), 1 },
                    { new Guid("be65fcd3-ec95-4c4f-b852-8b758b057a5a"), 690.426629302708000m, false, new Guid("625f60c7-26bf-4b4d-810a-a53717a7983c"), "Itaque perferendis officia voluptatum exercitationem incidunt totam odit. Necessitatibus est eligendi. Voluptatibus similique assumenda veniam quo. Laboriosam qui excepturi sequi officiis.", new DateTime(2021, 6, 18, 22, 32, 50, 367, DateTimeKind.Utc).AddTicks(2638), 99 },
                    { new Guid("bec1015e-6393-49ef-8448-92e477d02904"), 171.863777443484000m, false, new Guid("3021a50b-2e14-4860-a432-98a126642eb9"), "Eum eius nobis dolores. Ad qui omnis. Eum at eum tempore natus assumenda corporis.", new DateTime(2013, 1, 7, 10, 23, 41, 875, DateTimeKind.Utc).AddTicks(9724), 99 },
                    { new Guid("bf4e1f6e-cfcf-40ef-a14c-0e8656eac4e3"), 494.023819473223000m, false, new Guid("e06131eb-f2e1-40d8-b36a-d1f26aceb63c"), "Molestias et amet soluta aperiam.", new DateTime(2021, 7, 28, 6, 54, 0, 196, DateTimeKind.Utc).AddTicks(5743), 0 },
                    { new Guid("c35f2d83-d613-4b1a-9592-c54915a5125b"), 116.875614378048000m, false, new Guid("6ac03431-5ace-40a8-8672-e40ed7a5cf21"), "Harum distinctio aut sed natus tempore.", new DateTime(2013, 5, 19, 18, 30, 25, 645, DateTimeKind.Utc).AddTicks(5046), 1 },
                    { new Guid("c5a9a245-4154-44f4-805a-fe71aa438820"), 143.993883813346000m, false, new Guid("bf67e662-0d81-4f4a-83bd-727e20a66cb7"), "Est provident voluptas consequatur commodi eligendi dolore non cum ullam. Et et sit voluptatem culpa assumenda error quo. Rerum fugit fuga sunt exercitationem ut. Aspernatur et aut quia sed cum.", new DateTime(2017, 6, 7, 10, 17, 54, 428, DateTimeKind.Utc).AddTicks(3523), 1 },
                    { new Guid("ca8c82f2-d607-4868-b582-f9a4d9f2a97a"), 78.7903313240703000m, false, new Guid("58384a47-8236-4a5f-93d7-5913ced82d1e"), "Dolores provident qui veritatis quasi magnam et sit est. Est autem repellendus. Quasi cupiditate et aut rem et laborum quae illum. Sed fugiat eos eius sit voluptatem eos quo.", new DateTime(2014, 10, 2, 23, 48, 32, 498, DateTimeKind.Utc).AddTicks(9015), 0 },
                    { new Guid("cc7e34a2-64ef-461f-945e-277652f26af0"), 716.006087739749000m, false, new Guid("9801b0c7-db84-4779-af42-de97aedf9b64"), "Dicta voluptatem magni. Nulla adipisci deleniti aliquam molestiae sit.", new DateTime(2013, 7, 12, 4, 22, 56, 433, DateTimeKind.Utc).AddTicks(6364), 0 },
                    { new Guid("cfd3de15-abb8-4148-bbf1-b0fd7929f17a"), 649.472070739907000m, false, new Guid("c12da2dc-533c-43bc-ad77-fc3a97ae0300"), "Rem ab consequatur eos qui et impedit accusamus consequatur ab. Praesentium ut dolores non molestiae voluptates itaque ab consectetur.", new DateTime(2014, 1, 19, 2, 52, 59, 989, DateTimeKind.Utc).AddTicks(5806), 1 },
                    { new Guid("d1e9e9d7-1f3d-4b87-a619-82c64b87d56c"), 765.972220140021000m, false, new Guid("c12da2dc-533c-43bc-ad77-fc3a97ae0300"), "Eos sed quam sint hic officia assumenda. Beatae et neque eum atque placeat quae culpa consequatur quis. Natus consequuntur aut quis ipsa nemo facere nihil non.", new DateTime(2020, 6, 18, 11, 57, 6, 977, DateTimeKind.Utc).AddTicks(6518), 0 },
                    { new Guid("d4ad2424-51ec-49c9-9416-959738ae43bd"), 705.663626316336000m, false, new Guid("9801b0c7-db84-4779-af42-de97aedf9b64"), "Iure molestiae vero nostrum voluptas. Adipisci labore animi eum dolor eum enim. Dolores consequatur inventore autem quam ut rerum. Officia consequatur et praesentium distinctio temporibus voluptatem quia.", new DateTime(2013, 3, 23, 21, 21, 7, 932, DateTimeKind.Utc).AddTicks(9174), 0 },
                    { new Guid("d569cae9-4629-4567-91b0-17b9c1dff3cc"), 616.226194507276000m, false, new Guid("0c865509-3202-49f5-98e7-0a9a4c5c0489"), "Voluptate voluptatibus velit est ducimus dolorem sed et.", new DateTime(2021, 1, 15, 3, 57, 46, 312, DateTimeKind.Utc).AddTicks(2640), 1 },
                    { new Guid("d7f53a6e-457c-49cc-ab17-f2a57db16d54"), 873.58943834142000m, false, new Guid("cb817682-2116-4baa-9960-edd372cd2bf2"), "Ad tenetur vel sunt deserunt eveniet voluptate corporis enim. Eos nesciunt et ut alias cumque magnam.", new DateTime(2021, 3, 14, 15, 8, 38, 104, DateTimeKind.Utc).AddTicks(2708), 0 },
                    { new Guid("d90ec419-f6ea-4135-a5cf-06ac27065902"), 905.30204525358000m, false, new Guid("e06131eb-f2e1-40d8-b36a-d1f26aceb63c"), "Ea non nihil aut qui quae magni doloremque ut officiis. Sed ducimus est et omnis qui id perferendis.", new DateTime(2013, 11, 2, 8, 19, 36, 1, DateTimeKind.Utc).AddTicks(8278), 1 },
                    { new Guid("de5720e7-7f3e-4cc6-b7e2-7c4bd980cd7a"), 88.1252401786396000m, false, new Guid("5e3bb94b-9db1-4c98-afcc-75746f0d0050"), "Cumque rem possimus quo. Officiis consequuntur enim aspernatur quia quia. Autem rerum ducimus et velit aut sapiente aliquam explicabo. Illo magnam aut similique debitis.", new DateTime(2014, 3, 26, 12, 14, 24, 140, DateTimeKind.Utc).AddTicks(7895), 99 },
                    { new Guid("e1e6dfb4-1d44-4437-93e8-a8d9f6e952be"), 925.404445480819000m, false, new Guid("b560e47d-09da-4044-bd0a-6172a633478b"), "Fugit explicabo molestias voluptas iure eos quibusdam corrupti et. Sed illo ut non recusandae delectus. Rerum error amet impedit rem ea voluptates.", new DateTime(2014, 6, 12, 18, 30, 1, 441, DateTimeKind.Utc).AddTicks(8955), 1 },
                    { new Guid("e414479e-03fd-41cf-ba8e-0f3ed5318aba"), 220.861808331524000m, false, new Guid("3021a50b-2e14-4860-a432-98a126642eb9"), "Natus ea et vero dicta explicabo. Molestiae non quibusdam est dicta sed voluptates consequatur voluptate. Fugiat ut quisquam placeat odit voluptatibus recusandae vel fuga numquam.", new DateTime(2019, 2, 13, 15, 29, 28, 227, DateTimeKind.Utc).AddTicks(1280), 99 },
                    { new Guid("e474a587-5fa8-4b9d-a42b-8ab145cc97e2"), 236.935248840225000m, false, new Guid("cb817682-2116-4baa-9960-edd372cd2bf2"), "Voluptatem tempore sit dolore.", new DateTime(2018, 5, 10, 10, 58, 24, 41, DateTimeKind.Utc).AddTicks(2626), 1 },
                    { new Guid("e551dc8d-09b9-416b-af80-f8c84207b9b1"), 950.126247143922000m, false, new Guid("321b519a-bead-4408-8e85-cfd5c7afe182"), "Non aut omnis dolores.", new DateTime(2016, 4, 21, 0, 57, 54, 431, DateTimeKind.Utc).AddTicks(9840), 0 },
                    { new Guid("e5760e3e-059b-406a-adc6-b15c1ffa41ce"), 466.833318265221000m, false, new Guid("fa30eb2d-f8b6-4219-9061-f62f7eeb0f89"), "Qui enim aut aut recusandae eveniet ex non maiores qui.", new DateTime(2014, 7, 11, 9, 43, 13, 628, DateTimeKind.Utc).AddTicks(7907), 0 },
                    { new Guid("e7322714-d590-4f14-82d2-413683273db7"), 235.547221105896000m, false, new Guid("5e3bb94b-9db1-4c98-afcc-75746f0d0050"), "Rem quia quia numquam quia quis. Ut culpa odio quidem sit ut est.", new DateTime(2019, 2, 21, 21, 4, 59, 40, DateTimeKind.Utc).AddTicks(765), 1 },
                    { new Guid("e73844c2-b657-48b4-b55d-921a83fcae94"), 659.375614728788000m, false, new Guid("321b519a-bead-4408-8e85-cfd5c7afe182"), "Aut eius qui soluta consequuntur id error sit.", new DateTime(2017, 10, 31, 18, 49, 41, 999, DateTimeKind.Utc).AddTicks(7515), 1 },
                    { new Guid("e75744f5-0ec1-49ce-8416-5f587b685e2e"), 742.105331071141000m, false, new Guid("d4a59397-3d7d-407f-9a9d-9d5cefe93216"), "Atque excepturi ea ducimus consequatur.", new DateTime(2020, 1, 17, 7, 9, 39, 441, DateTimeKind.Utc).AddTicks(3254), 0 },
                    { new Guid("e79cee1c-bd01-45af-8773-f6ce7cbc3998"), 126.544346136813000m, false, new Guid("0c865509-3202-49f5-98e7-0a9a4c5c0489"), "Voluptates soluta et est qui. Consequatur architecto dolorem consequatur ullam quis eligendi illo. Sed voluptas quas officia id dolorem numquam dolorem minima consequuntur.", new DateTime(2013, 8, 13, 17, 20, 32, 508, DateTimeKind.Utc).AddTicks(9795), 1 },
                    { new Guid("e997c51f-9dc6-4ef5-9653-a4a0e46dbede"), 297.143105192699000m, false, new Guid("6ac03431-5ace-40a8-8672-e40ed7a5cf21"), "Est cumque iste in repudiandae magni voluptatem consequatur sunt. Quam iste ullam reprehenderit eos delectus explicabo. Ad voluptatibus rerum voluptas excepturi iusto adipisci consequuntur quo. Voluptas ipsum eos non numquam molestias.", new DateTime(2018, 4, 18, 14, 47, 20, 844, DateTimeKind.Utc).AddTicks(7441), 99 },
                    { new Guid("ea55d1a1-290d-41fb-8ef5-3c8e874160fa"), 861.45763392459000m, false, new Guid("58384a47-8236-4a5f-93d7-5913ced82d1e"), "Dolorem vel autem corporis ad temporibus atque nihil alias reprehenderit. Est quod ratione vel eum.", new DateTime(2012, 4, 14, 17, 38, 7, 59, DateTimeKind.Utc).AddTicks(7415), 99 },
                    { new Guid("eb447fcf-f582-41fa-8c6f-a82d476727af"), 942.001141810796000m, false, new Guid("321b519a-bead-4408-8e85-cfd5c7afe182"), "Vero non autem vero. Labore qui et non praesentium perspiciatis fugiat repellat sit. Ut consequuntur numquam error et sit.", new DateTime(2017, 11, 19, 3, 25, 39, 740, DateTimeKind.Utc).AddTicks(2902), 1 },
                    { new Guid("eb64a9e8-1dbe-4c63-9936-55579eae3daf"), 258.468346855477000m, false, new Guid("e06131eb-f2e1-40d8-b36a-d1f26aceb63c"), "Occaecati dolor voluptatibus quas fugit nobis. In illum asperiores quod dignissimos.", new DateTime(2016, 6, 23, 17, 19, 41, 825, DateTimeKind.Utc).AddTicks(8915), 99 },
                    { new Guid("eb988b2b-aa83-4575-908b-826f2ee31034"), 201.037553753211000m, false, new Guid("90579122-bf74-4a7a-9eba-5c166ddaa313"), "Ducimus iste aut sunt aut. Sunt et culpa et. Quae aut ipsam dolorem impedit. Molestiae tenetur culpa culpa quia.", new DateTime(2016, 11, 8, 17, 32, 54, 156, DateTimeKind.Utc).AddTicks(1850), 0 },
                    { new Guid("ebbf5034-ce6d-4510-9b0b-53eb2f614b82"), 877.614481100198000m, false, new Guid("d416c1a3-8b50-4550-8807-55b14fa7e4af"), "Minima ut enim quas blanditiis.", new DateTime(2015, 2, 19, 15, 11, 45, 55, DateTimeKind.Utc).AddTicks(7733), 99 },
                    { new Guid("ece8f17c-b4dd-4f71-83b5-7133e76388d5"), 19.514136202711000m, false, new Guid("5e3bb94b-9db1-4c98-afcc-75746f0d0050"), "Aspernatur nulla qui facere mollitia qui ab tenetur distinctio nihil. Corporis eligendi qui rem dolor perspiciatis ipsum necessitatibus necessitatibus officiis.", new DateTime(2018, 7, 17, 6, 35, 43, 983, DateTimeKind.Utc).AddTicks(9764), 99 },
                    { new Guid("ed13984a-5919-4e85-a0c4-298ebf2a739e"), 867.19854065447000m, false, new Guid("0c865509-3202-49f5-98e7-0a9a4c5c0489"), "Voluptatum fugiat aliquam deleniti animi ea qui unde quisquam expedita.", new DateTime(2019, 1, 9, 7, 48, 30, 839, DateTimeKind.Utc).AddTicks(5940), 0 },
                    { new Guid("ed3b34bf-209b-48bc-b6da-b27558de9d9a"), 393.972502872727000m, false, new Guid("bf67e662-0d81-4f4a-83bd-727e20a66cb7"), "Accusantium iste temporibus fugit ipsum ut. Atque odio ullam voluptatem. Doloribus sint quisquam nostrum ipsum doloremque veniam consequuntur. Sunt corrupti eos quas labore et sed voluptatem est labore.", new DateTime(2021, 9, 5, 9, 20, 58, 854, DateTimeKind.Utc).AddTicks(269), 1 },
                    { new Guid("eebb87c0-57a7-42d0-a0df-629b46308f1a"), 717.590019359982000m, false, new Guid("c12da2dc-533c-43bc-ad77-fc3a97ae0300"), "Dolorem minima quos. Officiis quis perferendis et consequatur perferendis dolor. Suscipit numquam sit consequatur dolor. Veniam omnis ab et accusamus.", new DateTime(2019, 3, 11, 10, 54, 3, 484, DateTimeKind.Utc).AddTicks(5882), 99 },
                    { new Guid("f0684ed8-4bd2-4fa6-a912-f06fd8d46041"), 418.720562558284000m, false, new Guid("321b519a-bead-4408-8e85-cfd5c7afe182"), "Ea voluptas molestias accusamus.", new DateTime(2013, 7, 15, 5, 25, 3, 210, DateTimeKind.Utc).AddTicks(3553), 1 },
                    { new Guid("f1515cb4-79ab-43f5-a463-a664f3223e08"), 156.769337641463000m, false, new Guid("fa30eb2d-f8b6-4219-9061-f62f7eeb0f89"), "Deleniti iure consequatur unde omnis sunt vel consectetur fugit. Eos iste numquam pariatur nulla veniam architecto beatae.", new DateTime(2021, 7, 2, 9, 29, 20, 458, DateTimeKind.Utc).AddTicks(7373), 1 },
                    { new Guid("f17444a1-85ea-47db-985c-1b9b25d30326"), 598.88487888845000m, false, new Guid("625f60c7-26bf-4b4d-810a-a53717a7983c"), "Nostrum ad delectus fugiat odio velit qui amet. Doloremque enim dolor dolores molestias nemo unde unde.", new DateTime(2020, 1, 11, 11, 57, 7, 717, DateTimeKind.Utc).AddTicks(3076), 99 },
                    { new Guid("f238f214-a9b0-4949-ac12-b3493fb8e224"), 442.099019300145000m, false, new Guid("bf67e662-0d81-4f4a-83bd-727e20a66cb7"), "Qui autem excepturi autem numquam sunt. Sit qui omnis. Dolorum maiores vero qui quo alias id porro.", new DateTime(2022, 1, 6, 6, 49, 12, 458, DateTimeKind.Utc).AddTicks(2846), 1 },
                    { new Guid("f2506441-f6d1-457c-a971-bb00729c7f65"), 700.921855940028000m, false, new Guid("d4a59397-3d7d-407f-9a9d-9d5cefe93216"), "Voluptatum autem optio quisquam molestiae consequatur. Eum ducimus quia quasi. Odit et modi ullam ut deleniti nihil quo minus. Temporibus odit aliquid deserunt.", new DateTime(2016, 3, 25, 20, 11, 26, 285, DateTimeKind.Utc).AddTicks(7737), 99 },
                    { new Guid("f2cfb03f-3a48-4005-9be1-4c0751ed5e21"), 330.538644721181000m, false, new Guid("fa30eb2d-f8b6-4219-9061-f62f7eeb0f89"), "Debitis officiis sint dolorem fuga et neque optio id autem.", new DateTime(2020, 7, 23, 14, 34, 34, 413, DateTimeKind.Utc).AddTicks(8160), 0 },
                    { new Guid("f82e83d8-e6cb-40d9-a272-220cff64ab78"), 854.442853265369000m, false, new Guid("625f60c7-26bf-4b4d-810a-a53717a7983c"), "Eaque totam eos autem et fugit. Maiores non ut.", new DateTime(2016, 1, 26, 16, 41, 12, 239, DateTimeKind.Utc).AddTicks(356), 0 },
                    { new Guid("fac4d1f9-a70c-4ff2-a433-23144a38edba"), 208.875245030493000m, false, new Guid("90579122-bf74-4a7a-9eba-5c166ddaa313"), "Aliquid sequi eos et ducimus. Sit ipsam dicta autem quasi repellendus qui consequuntur. Laboriosam aut hic porro voluptate eum laboriosam hic nihil ratione. Repellendus sit quam consequatur.", new DateTime(2019, 1, 4, 18, 21, 41, 505, DateTimeKind.Utc).AddTicks(3601), 99 },
                    { new Guid("fb0529e3-4cb0-4292-b78c-3dfe5add3ad6"), 314.140725672964000m, false, new Guid("399c47ef-caf0-4115-98db-c6c8f6dde507"), "Rerum non qui recusandae occaecati qui et quae. Quidem consequatur architecto.", new DateTime(2013, 3, 1, 19, 32, 51, 82, DateTimeKind.Utc).AddTicks(2695), 99 },
                    { new Guid("fc82eda0-d694-45c4-8115-bb21586c3faa"), 394.218075783365000m, false, new Guid("666b7a2b-c7e6-4de9-a345-57b8062ad9e6"), "Consequatur odit consectetur ducimus.", new DateTime(2019, 7, 1, 13, 3, 37, 820, DateTimeKind.Utc).AddTicks(2844), 99 },
                    { new Guid("fd146d9e-ecfa-4f7b-b15f-935af9d29902"), 594.320652443982000m, false, new Guid("e06131eb-f2e1-40d8-b36a-d1f26aceb63c"), "Ducimus quas voluptates et maiores illo est est ut in. Quae officia magni occaecati dolor.", new DateTime(2015, 12, 15, 14, 1, 21, 977, DateTimeKind.Utc).AddTicks(3143), 99 },
                    { new Guid("fd4cfca3-4c48-4359-b04a-b3a79bb71095"), 525.593151960875000m, false, new Guid("666b7a2b-c7e6-4de9-a345-57b8062ad9e6"), "Similique quisquam architecto deserunt neque animi asperiores autem delectus sequi.", new DateTime(2015, 1, 5, 8, 34, 4, 797, DateTimeKind.Utc).AddTicks(7358), 1 }
                });

            migrationBuilder.InsertData(
                table: "SubscriptionsPaid",
                columns: new[] { "MemberId", "Year", "April", "August", "December", "February", "January", "July", "June", "March", "May", "November", "October", "September" },
                values: new object[,]
                {
                    { new Guid("0c865509-3202-49f5-98e7-0a9a4c5c0489"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("0c865509-3202-49f5-98e7-0a9a4c5c0489"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("0c865509-3202-49f5-98e7-0a9a4c5c0489"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("0c865509-3202-49f5-98e7-0a9a4c5c0489"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("3021a50b-2e14-4860-a432-98a126642eb9"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("3021a50b-2e14-4860-a432-98a126642eb9"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("3021a50b-2e14-4860-a432-98a126642eb9"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("3021a50b-2e14-4860-a432-98a126642eb9"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("321b519a-bead-4408-8e85-cfd5c7afe182"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("321b519a-bead-4408-8e85-cfd5c7afe182"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("321b519a-bead-4408-8e85-cfd5c7afe182"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("321b519a-bead-4408-8e85-cfd5c7afe182"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("321b519a-bead-4408-8e85-cfd5c7afe182"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("321b519a-bead-4408-8e85-cfd5c7afe182"), 2020, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("399c47ef-caf0-4115-98db-c6c8f6dde507"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("399c47ef-caf0-4115-98db-c6c8f6dde507"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("399c47ef-caf0-4115-98db-c6c8f6dde507"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("399c47ef-caf0-4115-98db-c6c8f6dde507"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("399c47ef-caf0-4115-98db-c6c8f6dde507"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("58384a47-8236-4a5f-93d7-5913ced82d1e"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("58384a47-8236-4a5f-93d7-5913ced82d1e"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("58384a47-8236-4a5f-93d7-5913ced82d1e"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("58384a47-8236-4a5f-93d7-5913ced82d1e"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("58384a47-8236-4a5f-93d7-5913ced82d1e"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("58384a47-8236-4a5f-93d7-5913ced82d1e"), 2020, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("58384a47-8236-4a5f-93d7-5913ced82d1e"), 2021, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("5e3bb94b-9db1-4c98-afcc-75746f0d0050"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("5e3bb94b-9db1-4c98-afcc-75746f0d0050"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("5e3bb94b-9db1-4c98-afcc-75746f0d0050"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("5e3bb94b-9db1-4c98-afcc-75746f0d0050"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("625f60c7-26bf-4b4d-810a-a53717a7983c"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("625f60c7-26bf-4b4d-810a-a53717a7983c"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("625f60c7-26bf-4b4d-810a-a53717a7983c"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("625f60c7-26bf-4b4d-810a-a53717a7983c"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("625f60c7-26bf-4b4d-810a-a53717a7983c"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("666b7a2b-c7e6-4de9-a345-57b8062ad9e6"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("666b7a2b-c7e6-4de9-a345-57b8062ad9e6"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("666b7a2b-c7e6-4de9-a345-57b8062ad9e6"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("666b7a2b-c7e6-4de9-a345-57b8062ad9e6"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("666b7a2b-c7e6-4de9-a345-57b8062ad9e6"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("6ac03431-5ace-40a8-8672-e40ed7a5cf21"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("6ac03431-5ace-40a8-8672-e40ed7a5cf21"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("6ac03431-5ace-40a8-8672-e40ed7a5cf21"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("6ac03431-5ace-40a8-8672-e40ed7a5cf21"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("6ac03431-5ace-40a8-8672-e40ed7a5cf21"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("90579122-bf74-4a7a-9eba-5c166ddaa313"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("90579122-bf74-4a7a-9eba-5c166ddaa313"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("90579122-bf74-4a7a-9eba-5c166ddaa313"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("9801b0c7-db84-4779-af42-de97aedf9b64"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("9801b0c7-db84-4779-af42-de97aedf9b64"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("9801b0c7-db84-4779-af42-de97aedf9b64"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("9801b0c7-db84-4779-af42-de97aedf9b64"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("9801b0c7-db84-4779-af42-de97aedf9b64"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("a09aa449-febf-4318-b933-fe31feb73c9c"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("b560e47d-09da-4044-bd0a-6172a633478b"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("b560e47d-09da-4044-bd0a-6172a633478b"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("b560e47d-09da-4044-bd0a-6172a633478b"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("b560e47d-09da-4044-bd0a-6172a633478b"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("bf67e662-0d81-4f4a-83bd-727e20a66cb7"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("bf67e662-0d81-4f4a-83bd-727e20a66cb7"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("bf67e662-0d81-4f4a-83bd-727e20a66cb7"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("bf67e662-0d81-4f4a-83bd-727e20a66cb7"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("c12da2dc-533c-43bc-ad77-fc3a97ae0300"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("c12da2dc-533c-43bc-ad77-fc3a97ae0300"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("c12da2dc-533c-43bc-ad77-fc3a97ae0300"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("c12da2dc-533c-43bc-ad77-fc3a97ae0300"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("cb817682-2116-4baa-9960-edd372cd2bf2"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("cb817682-2116-4baa-9960-edd372cd2bf2"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("cb817682-2116-4baa-9960-edd372cd2bf2"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("cb817682-2116-4baa-9960-edd372cd2bf2"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("cb817682-2116-4baa-9960-edd372cd2bf2"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("d416c1a3-8b50-4550-8807-55b14fa7e4af"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("d416c1a3-8b50-4550-8807-55b14fa7e4af"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("d4a59397-3d7d-407f-9a9d-9d5cefe93216"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("d4a59397-3d7d-407f-9a9d-9d5cefe93216"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("d4a59397-3d7d-407f-9a9d-9d5cefe93216"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("d4a59397-3d7d-407f-9a9d-9d5cefe93216"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("d4a59397-3d7d-407f-9a9d-9d5cefe93216"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("d4a59397-3d7d-407f-9a9d-9d5cefe93216"), 2020, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("e06131eb-f2e1-40d8-b36a-d1f26aceb63c"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("e06131eb-f2e1-40d8-b36a-d1f26aceb63c"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("fa30eb2d-f8b6-4219-9061-f62f7eeb0f89"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("fa30eb2d-f8b6-4219-9061-f62f7eeb0f89"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("fa30eb2d-f8b6-4219-9061-f62f7eeb0f89"), 2017, true, true, true, true, true, true, true, true, true, true, true, true }
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
                name: "IX_AspNetUsers_CountryId",
                table: "AspNetUsers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

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
                name: "Countries");
        }
    }
}
