using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Eudwia.Server.Data.Migrations
{
    public partial class InitialDatabase : Migration
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
                    { new Guid("10765bc8-7a84-4fd7-af14-468a9a24d48c"), 0, new DateOnly(1987, 2, 27), "Béziers", "976f9a5c-fcd2-4e97-9319-52aed2b3c5c6", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Virginie.Lacroix@gmail.com", false, "Soline", "23", 2, "Laurent", false, null, new DateOnly(2017, 3, 25), null, null, null, "0104865587", false, "326d77c3-417b-4d62-8f1a-994e63072822", "VD", "600 Avenue de Richelieu", "8 étage", false, "Virginie.Lacroix@gmail.com", "05245" },
                    { new Guid("1339ea5e-333b-431b-b9f7-46dcec82a275"), 0, new DateOnly(1977, 10, 29), "Rennes", "e32cec8b-6e99-43e0-ad5e-8aae9c7b212b", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Flavie_Dasilva@yahoo.fr", false, "Hippolyte", "093", 1, "Bourgeois", false, null, new DateOnly(2016, 3, 9), null, null, null, "0368472614", false, "c045f524-3b72-48bb-b167-3a4c3aa65f44", "VD", "534 Passage des Panoramas", "Apt. 546", false, "Flavie_Dasilva@yahoo.fr", "48419" },
                    { new Guid("27b6e593-824c-4ace-b846-3af9909b1f65"), 0, new DateOnly(1955, 2, 3), "Saint-Denis", "eb23555a-f794-44f8-8ac2-5412c52df34f", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Arsene.Richard@hotmail.fr", false, "Armandine", "070", 1, "Leclercq", false, null, new DateOnly(2012, 6, 5), null, null, null, "+33 470283246", false, "1a66cea0-3ff3-4c2b-aaee-7d59831c1a57", "VD", "8286 Place La Boétie", "3 étage", false, "Arsene.Richard@hotmail.fr", "74044" },
                    { new Guid("293f8448-6306-44e1-b0d2-de6e56c05b6a"), 0, new DateOnly(1969, 6, 29), "Roubaix", "4fab9402-e9dd-40d5-a344-848bdeb671d4", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Edmond.Renault@gmail.com", false, "Ascension", "723", 2, "Mathieu", false, null, new DateOnly(2017, 6, 30), null, null, null, "+33 215631014", false, "083f7ef0-38a8-4db6-a32d-5398d425646e", "VD", "3507 Rue Pierre Charron", "Apt. 387", false, "Edmond.Renault@gmail.com", "19674" },
                    { new Guid("4a6c0db7-fa8b-4fa0-a332-47f50f255879"), 0, new DateOnly(1954, 6, 16), "Nancy", "34c279e8-ee19-4a6c-96de-59d1dce1c136", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Adelaide_Muller82@gmail.com", false, "Isabelle", "17", 1, "Gaillard", false, null, new DateOnly(2012, 11, 14), null, null, null, "0111776599", false, "9a0c2b86-64e0-4828-baa0-850cbaf4c839", "VD", "30 Boulevard du Faubourg Saint-Honoré", "Apt. 860", false, "Adelaide_Muller82@gmail.com", "38729" },
                    { new Guid("57e7666c-e85d-47c5-8137-c5ed7d565cec"), 0, new DateOnly(1959, 2, 13), "La Rochelle", "e435d146-4abe-4eec-b057-49c5c0f35757", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Guillemette_Clement27@hotmail.fr", false, "Vinciane", "390", 1, "Dumas", false, null, new DateOnly(2015, 12, 18), null, null, null, "0362342660", false, "1dcb154a-3f1c-4a08-89fb-9649135cdc4e", "VD", "932 Passage Royale", "4 étage", false, "Guillemette_Clement27@hotmail.fr", "13015" },
                    { new Guid("60033e04-f97b-4ed8-9104-3029eef5bdb8"), 0, new DateOnly(1979, 10, 19), "Versailles", "a390e5f3-c07d-48ab-8671-c2fd329ee79c", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Brunehilde.Schneider96@yahoo.fr", false, "Léon", "183", 2, "Maillard", false, null, new DateOnly(2021, 3, 6), null, null, null, "0675875213", false, "7567a8ca-91ab-48d4-9e27-85910b79cd20", "VD", "49 Voie Montorgueil", "0 étage", false, "Brunehilde.Schneider96@yahoo.fr", "67704" },
                    { new Guid("776ff3b6-36cd-4926-8d24-4a0ada93eaea"), 0, new DateOnly(1995, 3, 6), "Colmar", "6fb22445-c490-4de2-80fc-261eb98249e3", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Barthelemy.Blanc@hotmail.fr", false, "Adegrine", "3199", 1, "Masson", false, null, new DateOnly(2014, 4, 13), null, null, null, "+33 335634926", false, "49cac554-e60f-41b9-9535-093becb319a4", "VD", "8 Allée de la Ferronnerie", "Apt. 106", false, "Barthelemy.Blanc@hotmail.fr", "79984" },
                    { new Guid("7fe7e445-5866-48d8-9e0f-cb2460103c01"), 0, new DateOnly(1995, 10, 17), "Grenoble", "9214ca6c-ac0d-4f2c-add5-e46fa35e3968", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Flavien_Gauthier@yahoo.fr", false, "Agnan", "52", 0, "Meyer", false, null, new DateOnly(2015, 4, 28), null, null, null, "0334409482", false, "6cca7333-b8a9-4f4c-b9dd-2101e1af3391", "VD", "6 Avenue des Lombards", "3 étage", false, "Flavien_Gauthier@yahoo.fr", "85655" },
                    { new Guid("8cc8a727-2c22-4d67-aaad-7a99a42ccb07"), 0, new DateOnly(1967, 6, 30), "Bourges", "a7c1a0bd-583c-4d7c-89ab-179c5626aae9", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Eric_Duval46@gmail.com", false, "Alaine", "272", 0, "Noel", false, null, new DateOnly(2014, 4, 4), null, null, null, "+33 304574730", false, "c802bb57-22f4-40cc-bd8f-7a9c22234665", "VD", "2458 Avenue de la Huchette", "7 étage", false, "Eric_Duval46@gmail.com", "24153" },
                    { new Guid("8d4eb238-5f87-4849-af4c-de1ec6b76cae"), 0, new DateOnly(1998, 4, 15), "La Rochelle", "742c7117-e4c8-4a78-97b0-ff4bb7fb6622", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Taurin29@gmail.com", false, "Anicette", "3", 1, "Jacquet", false, null, new DateOnly(2013, 4, 15), null, null, null, "0709183312", false, "5ece6546-9611-40f6-8b4d-b31990673e24", "VD", "783 Impasse de Tilsitt", "9 étage", false, "Taurin29@gmail.com", "53052" },
                    { new Guid("9d6b320e-7809-44c6-bb0f-621d94518a3c"), 0, new DateOnly(1955, 5, 18), "Bourges", "ace8f6bb-7b10-4cb8-bebe-5b0cff775d15", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Thomas28@hotmail.fr", false, "Antonine", "09", 1, "Nguyen", false, null, new DateOnly(2017, 11, 28), null, null, null, "+33 508128109", false, "12708e9b-05ce-416a-94ef-855b4ddf46e8", "VD", "3747 Avenue La Boétie", "Apt. 080", false, "Thomas28@hotmail.fr", "05953" },
                    { new Guid("a4856544-8f7d-49d1-bc75-bfde8593a6fd"), 0, new DateOnly(1982, 5, 3), "Avignon", "c0027cce-8875-4dbf-8306-f0a5254accb5", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Caroline.Fleury76@gmail.com", false, "Perceval", "73", 0, "Lecomte", false, null, new DateOnly(2013, 3, 22), null, null, null, "0311081587", false, "189cb49c-5c2a-4409-bc16-7d1a0380ed01", "VD", "4 Allée Charlemagne", "6 étage", false, "Caroline.Fleury76@gmail.com", "57104" },
                    { new Guid("c0008290-6a8b-4dfb-8d2f-198bc8f28420"), 0, new DateOnly(1995, 12, 3), "Amiens", "93a4e2f5-8791-4066-bd88-19657482b0ab", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Gerbert59@hotmail.fr", false, "Fulbert", "4030", 1, "Philippe", false, null, new DateOnly(2019, 10, 27), null, null, null, "0459707010", false, "0dd714b9-7946-43dc-ba64-367699fc123e", "VD", "6 Boulevard de Vaugirard", "Apt. 560", false, "Gerbert59@hotmail.fr", "72008" },
                    { new Guid("c5ef00c0-f740-40ba-a2ec-f90600cd8587"), 0, new DateOnly(1991, 3, 31), "Antibes", "0eba5984-22a2-4ff6-8813-18719559bcf7", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Ansberte.Rey7@yahoo.fr", false, "Carine", "1955", 0, "Aubry", false, null, new DateOnly(2012, 2, 15), null, null, null, "+33 689321701", false, "00206cd6-408b-4448-a4c3-eaa2362dab18", "VD", "99 Boulevard Adolphe Mille", "6 étage", false, "Ansberte.Rey7@yahoo.fr", "13559" },
                    { new Guid("dbfa8ad9-8ce9-4e34-ab96-89495ccf0964"), 0, new DateOnly(1967, 1, 28), "Ivry-sur-Seine", "24a1d33a-0630-4de6-ac04-9bb89c4ca215", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Gerard_Roux48@gmail.com", false, "Axeline", "6", 2, "Olivier", false, null, new DateOnly(2015, 7, 16), null, null, null, "0327126007", false, "9625c874-d100-4851-ac73-730c9a0f544d", "VD", "44 Boulevard de la Huchette", "4 étage", false, "Gerard_Roux48@gmail.com", "87438" },
                    { new Guid("e04ee5ad-485f-459f-9913-56ff9495d6a1"), 0, new DateOnly(1976, 4, 4), "Dunkerque14", "78b51d07-a802-4cb2-868e-16c2ed6d9bb5", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Pierre.Morin24@yahoo.fr", false, "Eugène", "121", 0, "Lopez", false, null, new DateOnly(2013, 8, 13), null, null, null, "+33 797850905", false, "0dc6dd18-0e64-4f71-bfe7-4f39c7dcadad", "VD", "5265 Voie de Richelieu", "Apt. 469", false, "Pierre.Morin24@yahoo.fr", "50135" },
                    { new Guid("e07a62f4-6ddd-4be4-b983-4902d2aabca3"), 0, new DateOnly(1976, 1, 11), "Cergy", "c9f636f2-8862-4476-9f5b-8e39189e695c", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Basilisse_Lopez55@gmail.com", false, "Alliaume", "53", 2, "Petit", false, null, new DateOnly(2013, 9, 12), null, null, null, "0764407230", false, "147ec4ec-df66-471e-98e4-9a3f45d90528", "VD", "023 Allée de la Paix", "Apt. 647", false, "Basilisse_Lopez55@gmail.com", "38395" },
                    { new Guid("ee804991-d117-4443-a038-67a602b22b8f"), 0, new DateOnly(1958, 4, 29), "Lorient", "0172ca47-6bb6-4de3-935b-57804cc6787c", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Maxime0@yahoo.fr", false, "Marlène", "1413", 1, "Leroux", false, null, new DateOnly(2019, 4, 19), null, null, null, "0594810227", false, "83ec7c51-1749-4a5f-8870-783e65ac4ba3", "VD", "6899 Place des Francs-Bourgeois", "8 étage", false, "Maxime0@yahoo.fr", "44004" },
                    { new Guid("f996ca10-5c5f-4493-ab9c-939766ea46ec"), 0, new DateOnly(1977, 4, 24), "Grenoble", "ecfa633a-5275-435f-9ddc-5b5bec913eaf", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Adeltrude.Petit95@yahoo.fr", false, "Abraham", "2991", 2, "Charpentier", false, null, new DateOnly(2018, 2, 6), null, null, null, "+33 193642968", false, "4648cd55-d759-42f5-a24f-1caaaccfdc34", "VD", "3 Rue d'Alésia", "6 étage", false, "Adeltrude.Petit95@yahoo.fr", "87739" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "IsDeleted", "MemberId", "Note", "PaymentDate", "PaymentType" },
                values: new object[,]
                {
                    { new Guid("00d1b3d9-d3b1-4d88-87cb-43243641df4c"), 79.4280347785993000m, false, new Guid("776ff3b6-36cd-4926-8d24-4a0ada93eaea"), "Tempore vel et quis doloribus possimus ut accusantium quas. Repellendus et sit consectetur maxime sint et quas esse et. Eaque quis possimus sunt.", new DateTime(2012, 3, 11, 2, 17, 0, 252, DateTimeKind.Utc).AddTicks(6651), 99 },
                    { new Guid("0137d3f6-c001-4c92-86f2-6eff58b0ee54"), 585.34997933329000m, false, new Guid("4a6c0db7-fa8b-4fa0-a332-47f50f255879"), "Ullam nam rerum minus. Quia sit ad ut quos natus velit odit alias iste. Aliquam molestiae quia est harum modi nisi. Hic odio quam blanditiis repellat.", new DateTime(2018, 9, 20, 21, 58, 56, 851, DateTimeKind.Utc).AddTicks(9038), 1 },
                    { new Guid("02d344f1-ed35-484e-8587-ed45da2cd11a"), 359.604123736946000m, false, new Guid("60033e04-f97b-4ed8-9104-3029eef5bdb8"), "Est quae est ad dolorem odit.", new DateTime(2014, 7, 30, 10, 8, 33, 28, DateTimeKind.Utc).AddTicks(5842), 1 },
                    { new Guid("048046db-fa57-49a1-8421-6a0d6891acda"), 935.490347935925000m, false, new Guid("a4856544-8f7d-49d1-bc75-bfde8593a6fd"), "Molestias harum distinctio occaecati qui necessitatibus officiis sit minima.", new DateTime(2018, 7, 16, 15, 10, 59, 463, DateTimeKind.Utc).AddTicks(9595), 0 },
                    { new Guid("0551bdbb-41bb-4507-944f-94d943fcd801"), 87.11764965898000m, false, new Guid("27b6e593-824c-4ace-b846-3af9909b1f65"), "Aperiam ipsam quia quas. Ut non dolorem.", new DateTime(2017, 10, 20, 15, 32, 11, 688, DateTimeKind.Utc).AddTicks(7777), 0 },
                    { new Guid("05560a1e-95b3-4a5b-8016-466c58c1aa60"), 541.78189604282000m, false, new Guid("57e7666c-e85d-47c5-8137-c5ed7d565cec"), "Molestiae repellat iusto non illum et quis rerum quae temporibus. Dicta sapiente atque. Voluptates nam distinctio est. Eum voluptate eos reprehenderit rerum ut autem.", new DateTime(2017, 3, 5, 2, 26, 15, 288, DateTimeKind.Utc).AddTicks(7161), 0 },
                    { new Guid("059de3f3-8d80-4403-ad32-a7137efbdd97"), 979.10631302263000m, false, new Guid("f996ca10-5c5f-4493-ab9c-939766ea46ec"), "Vel ut qui enim repudiandae consequatur. Vero pariatur consectetur nulla. Sit optio culpa quasi quia.", new DateTime(2012, 2, 20, 22, 54, 25, 485, DateTimeKind.Utc).AddTicks(4216), 99 },
                    { new Guid("06e2ea31-f91f-474b-beb8-068832a2e913"), 169.434318907036000m, false, new Guid("e07a62f4-6ddd-4be4-b983-4902d2aabca3"), "Saepe velit expedita quia iure rerum nihil.", new DateTime(2017, 10, 25, 19, 4, 23, 709, DateTimeKind.Utc).AddTicks(8403), 99 },
                    { new Guid("073c0575-62c3-4273-b721-cf6ee211b06d"), 386.084575252356000m, false, new Guid("f996ca10-5c5f-4493-ab9c-939766ea46ec"), "Voluptatem inventore non alias accusantium fugit saepe. Eos eos officia. Facere incidunt et enim et sint.", new DateTime(2021, 12, 3, 8, 35, 43, 410, DateTimeKind.Utc).AddTicks(1502), 0 },
                    { new Guid("086345db-8dd5-449e-b729-d0b210d3cc65"), 185.855131678242000m, false, new Guid("9d6b320e-7809-44c6-bb0f-621d94518a3c"), "Eveniet veritatis laudantium quia voluptas ipsam suscipit et temporibus nihil. Corrupti blanditiis eum rerum. Sed ut consectetur dolorem. Debitis voluptas officia ipsum commodi deleniti.", new DateTime(2019, 2, 2, 17, 13, 41, 472, DateTimeKind.Utc).AddTicks(4576), 1 },
                    { new Guid("08fcfdff-1232-447a-b488-2961be878b5b"), 615.309776032223000m, false, new Guid("8cc8a727-2c22-4d67-aaad-7a99a42ccb07"), "Et facere culpa quia. Qui unde doloremque fuga sit cum. Repellat incidunt aspernatur et velit nemo dicta sed. Tempora fugiat ut et.", new DateTime(2013, 4, 14, 14, 54, 54, 697, DateTimeKind.Utc).AddTicks(2786), 99 },
                    { new Guid("094220f6-963f-41f9-bf0e-9c27ec0364c9"), 382.475079319834000m, false, new Guid("60033e04-f97b-4ed8-9104-3029eef5bdb8"), "Similique in ipsa doloribus aut ipsum. Eaque ea consequatur.", new DateTime(2020, 11, 27, 12, 50, 45, 413, DateTimeKind.Utc).AddTicks(9627), 99 },
                    { new Guid("0c160190-f01d-4772-a3ac-2f80fdc1f536"), 646.801106692568000m, false, new Guid("c0008290-6a8b-4dfb-8d2f-198bc8f28420"), "Illum quis ut dolorem. Molestiae consectetur nulla ex harum reprehenderit aspernatur. Sed non et illum suscipit sunt eveniet illum nobis nam. Ut quis et suscipit illum ea magni perspiciatis.", new DateTime(2013, 6, 23, 8, 23, 14, 229, DateTimeKind.Utc).AddTicks(1351), 99 },
                    { new Guid("0d6c26b1-0ac9-4de9-bd80-a42e92c02d22"), 682.625679445662000m, false, new Guid("1339ea5e-333b-431b-b9f7-46dcec82a275"), "Natus optio officia ad sunt voluptates autem. Accusamus vitae ipsa eveniet omnis iusto et. Autem pariatur similique.", new DateTime(2014, 11, 18, 8, 1, 27, 853, DateTimeKind.Utc).AddTicks(1766), 0 },
                    { new Guid("0e6aa4ba-dcc9-470f-89b8-253478f9cdfe"), 62.163241660484000m, false, new Guid("60033e04-f97b-4ed8-9104-3029eef5bdb8"), "Culpa qui explicabo et reprehenderit veniam itaque ut quia occaecati. Rerum cum voluptas libero ut.", new DateTime(2019, 11, 14, 0, 45, 4, 578, DateTimeKind.Utc).AddTicks(542), 99 },
                    { new Guid("0f4a7dd9-67f2-444c-b295-1e2b7b993b43"), 634.035278068041000m, false, new Guid("7fe7e445-5866-48d8-9e0f-cb2460103c01"), "Velit sit voluptatem quas quidem iure est quis. Amet ipsum voluptatibus repudiandae tenetur ipsum. Harum perferendis eos est possimus.", new DateTime(2014, 10, 23, 19, 22, 27, 786, DateTimeKind.Utc).AddTicks(2975), 0 },
                    { new Guid("0f622df8-4dea-40f1-a7a3-883e932a5c67"), 980.472406992389000m, false, new Guid("293f8448-6306-44e1-b0d2-de6e56c05b6a"), "Ea molestias magnam aut error iure praesentium. Occaecati corporis suscipit sed eum atque repudiandae reiciendis quam vel. Sit aut velit quasi veritatis. Adipisci saepe consequuntur illum.", new DateTime(2015, 12, 28, 4, 33, 8, 131, DateTimeKind.Utc).AddTicks(5557), 0 },
                    { new Guid("10389357-a184-47e8-8b96-92673c826208"), 191.405253828151000m, false, new Guid("a4856544-8f7d-49d1-bc75-bfde8593a6fd"), "Placeat soluta et iure dolorem officia deleniti tempora qui voluptas. Dolores accusantium qui autem et enim praesentium in. Quisquam sint sint et neque repellat dolor sequi eos.", new DateTime(2014, 8, 3, 8, 45, 54, 423, DateTimeKind.Utc).AddTicks(7377), 0 },
                    { new Guid("10e1f03f-4f3d-4655-b2b2-210f2145c5df"), 580.198010540797000m, false, new Guid("776ff3b6-36cd-4926-8d24-4a0ada93eaea"), "Dolores voluptas sint doloribus fugit est enim. Tenetur vero autem aut.", new DateTime(2020, 5, 13, 22, 37, 43, 507, DateTimeKind.Utc).AddTicks(3478), 1 },
                    { new Guid("1309aa41-2e34-4f96-909d-25612beb7589"), 442.620022927351000m, false, new Guid("4a6c0db7-fa8b-4fa0-a332-47f50f255879"), "Quia odit dolorem. Sunt quibusdam perferendis in ex placeat.", new DateTime(2012, 10, 22, 11, 43, 29, 822, DateTimeKind.Utc).AddTicks(3024), 0 },
                    { new Guid("1365128f-ff1c-42ba-be56-da066807f905"), 789.85853383628000m, false, new Guid("9d6b320e-7809-44c6-bb0f-621d94518a3c"), "Ut itaque eos ab odio ut. Ea aspernatur cumque molestias nesciunt qui ut vel.", new DateTime(2019, 11, 24, 17, 28, 26, 67, DateTimeKind.Utc).AddTicks(3427), 99 },
                    { new Guid("139f7d4d-96d3-4fb5-972f-ce6b5ddbd1ef"), 920.73071715564000m, false, new Guid("57e7666c-e85d-47c5-8137-c5ed7d565cec"), "Magnam vero quos eligendi vitae inventore. Ducimus laboriosam nisi. Et consequatur harum. Qui id quisquam voluptatem ipsum.", new DateTime(2017, 12, 7, 17, 28, 47, 407, DateTimeKind.Utc).AddTicks(9989), 1 },
                    { new Guid("14b35694-3ac9-429e-a37f-da8d425eb36d"), 630.335203690274000m, false, new Guid("f996ca10-5c5f-4493-ab9c-939766ea46ec"), "Est impedit expedita ipsam fuga quae. Modi aut at laboriosam fuga minima quaerat accusamus. Omnis deleniti earum odit et.", new DateTime(2017, 3, 1, 3, 34, 13, 690, DateTimeKind.Utc).AddTicks(9806), 1 },
                    { new Guid("15308350-6b5b-4995-b77d-c6e1541578b0"), 679.655273501772000m, false, new Guid("ee804991-d117-4443-a038-67a602b22b8f"), "Aut praesentium odit non qui voluptatem ipsum et voluptatem et. Aperiam exercitationem sequi dolor ad dolor debitis fugiat.", new DateTime(2016, 5, 29, 11, 26, 58, 334, DateTimeKind.Utc).AddTicks(3037), 0 },
                    { new Guid("15cbc541-dd63-4f9a-9631-e82a84d6d04b"), 729.82052184974000m, false, new Guid("60033e04-f97b-4ed8-9104-3029eef5bdb8"), "Non aut asperiores. Possimus consequatur sint nihil voluptas pariatur similique explicabo quo.", new DateTime(2012, 6, 19, 11, 43, 30, 718, DateTimeKind.Utc).AddTicks(4628), 0 },
                    { new Guid("160b9ee2-65df-45a1-b6a9-6d2c04fbe6b7"), 285.886904068884000m, false, new Guid("c5ef00c0-f740-40ba-a2ec-f90600cd8587"), "Nisi dicta et possimus perferendis consectetur rerum earum possimus a. Ex quia et ratione et et earum aut blanditiis blanditiis. Enim dolorum facilis aut iusto et ullam placeat.", new DateTime(2015, 6, 15, 18, 20, 41, 216, DateTimeKind.Utc).AddTicks(1342), 99 },
                    { new Guid("17289774-8daa-4f39-b2a9-80e23b052de2"), 440.917247779271000m, false, new Guid("ee804991-d117-4443-a038-67a602b22b8f"), "Autem sed doloribus sequi nemo ducimus laborum eaque molestiae. Accusantium eum at.", new DateTime(2019, 11, 15, 14, 27, 24, 868, DateTimeKind.Utc).AddTicks(1986), 99 },
                    { new Guid("1a8cc5b0-46e7-496e-a90f-dc8d005ef153"), 803.70854062005000m, false, new Guid("e04ee5ad-485f-459f-9913-56ff9495d6a1"), "Optio maxime veniam dolores. Possimus perferendis nemo similique aperiam minima. Distinctio est animi eum inventore culpa.", new DateTime(2017, 2, 24, 2, 52, 24, 301, DateTimeKind.Utc).AddTicks(9251), 0 },
                    { new Guid("1c52752c-2cb7-4296-b1e8-5e7cc04d7fc3"), 473.268814008108000m, false, new Guid("293f8448-6306-44e1-b0d2-de6e56c05b6a"), "Ad officiis voluptatum saepe. Eos rerum omnis. Omnis animi est cum enim molestias corrupti.", new DateTime(2012, 3, 11, 22, 19, 39, 533, DateTimeKind.Utc).AddTicks(3835), 99 },
                    { new Guid("1d9f2a5b-80c1-47bd-8746-a360a3b8e7ad"), 342.821103644443000m, false, new Guid("dbfa8ad9-8ce9-4e34-ab96-89495ccf0964"), "Dolore facere quos ut adipisci maxime et.", new DateTime(2017, 11, 6, 18, 52, 58, 219, DateTimeKind.Utc).AddTicks(2320), 99 },
                    { new Guid("224098b8-d0fa-4a9e-834e-952f5c1fcbb3"), 306.000967206237000m, false, new Guid("ee804991-d117-4443-a038-67a602b22b8f"), "Deserunt similique tempore et a sapiente totam delectus.", new DateTime(2015, 1, 23, 16, 28, 57, 143, DateTimeKind.Utc).AddTicks(4427), 0 },
                    { new Guid("23d5bcb8-2276-436d-87e5-226f380e580c"), 267.208763760175000m, false, new Guid("10765bc8-7a84-4fd7-af14-468a9a24d48c"), "Ea enim eos. Veritatis quidem ipsam repellendus ad veniam sint ut. Consequatur fugiat minima cum inventore. Itaque ullam minima et.", new DateTime(2018, 1, 14, 18, 53, 58, 169, DateTimeKind.Utc).AddTicks(9026), 99 },
                    { new Guid("245b4d49-8c8f-4a38-bf5e-8250b47c87f8"), 512.028675948004000m, false, new Guid("57e7666c-e85d-47c5-8137-c5ed7d565cec"), "Quibusdam qui pariatur reiciendis at. Nisi provident eum voluptatem eum dolorem pariatur. Commodi iusto laudantium vitae sapiente fuga beatae. Incidunt maxime ipsam et iusto.", new DateTime(2020, 6, 21, 19, 35, 40, 204, DateTimeKind.Utc).AddTicks(336), 99 },
                    { new Guid("263f63b0-1d98-434f-9776-6790edaa43b1"), 137.955716977159000m, false, new Guid("f996ca10-5c5f-4493-ab9c-939766ea46ec"), "Ratione omnis voluptatem atque et quam. Et maxime praesentium. Vel et libero sunt odit aut pariatur ut est at. Et quasi velit molestiae nesciunt voluptatem dolorem voluptas nostrum est.", new DateTime(2018, 9, 29, 9, 29, 0, 849, DateTimeKind.Utc).AddTicks(6586), 99 },
                    { new Guid("279c73c9-cee7-4c6f-b75c-a049b882c57d"), 450.396178186532000m, false, new Guid("10765bc8-7a84-4fd7-af14-468a9a24d48c"), "Corrupti similique est est. Mollitia neque et.", new DateTime(2016, 9, 11, 17, 31, 49, 815, DateTimeKind.Utc).AddTicks(9913), 0 },
                    { new Guid("27a1a118-b242-49e1-a43d-30bba6c6322c"), 382.32222923856000m, false, new Guid("60033e04-f97b-4ed8-9104-3029eef5bdb8"), "Delectus repudiandae optio incidunt cumque.", new DateTime(2019, 1, 14, 3, 4, 56, 421, DateTimeKind.Utc).AddTicks(2929), 99 },
                    { new Guid("28218643-b997-4cd6-9cbd-e29870703ad8"), 228.181642314498000m, false, new Guid("10765bc8-7a84-4fd7-af14-468a9a24d48c"), "Quo modi dolor nihil esse perspiciatis. Commodi voluptatem qui. Veritatis voluptate tempora sed voluptatem provident est ea qui. Vel et sunt.", new DateTime(2014, 7, 24, 21, 29, 49, 866, DateTimeKind.Utc).AddTicks(196), 1 },
                    { new Guid("285dda1b-dc60-46bc-8bc9-06c0487740ea"), 165.504040967193000m, false, new Guid("dbfa8ad9-8ce9-4e34-ab96-89495ccf0964"), "Deleniti temporibus architecto ea voluptatibus quis quidem et. In ipsam voluptatem vero. In at ducimus provident.", new DateTime(2014, 11, 25, 16, 14, 22, 744, DateTimeKind.Utc).AddTicks(3049), 99 },
                    { new Guid("28668f70-32ea-4e8a-9cd7-ba028fc40e20"), 503.316121708393000m, false, new Guid("293f8448-6306-44e1-b0d2-de6e56c05b6a"), "Fugiat ipsam sed amet porro id et. Nulla sit pariatur eum debitis. Non dolor voluptate dolorem velit doloremque fugiat debitis. Ut repellat exercitationem et atque ea alias.", new DateTime(2020, 7, 3, 2, 34, 50, 255, DateTimeKind.Utc).AddTicks(2253), 0 },
                    { new Guid("29935e52-3481-4618-bb79-66e05a6892c8"), 617.212029346692000m, false, new Guid("4a6c0db7-fa8b-4fa0-a332-47f50f255879"), "Nam doloribus magnam. Autem aut accusantium architecto culpa. Quas voluptatum exercitationem praesentium neque rerum. In quo voluptas temporibus facilis et ipsa.", new DateTime(2021, 4, 20, 7, 4, 23, 65, DateTimeKind.Utc).AddTicks(7996), 99 },
                    { new Guid("2a197bc7-9868-4195-a6df-9636f7a009de"), 307.095308061825000m, false, new Guid("57e7666c-e85d-47c5-8137-c5ed7d565cec"), "Velit ipsam ut aut sed qui. Repellat labore nesciunt consequatur iste enim natus natus et.", new DateTime(2012, 8, 24, 20, 22, 16, 354, DateTimeKind.Utc).AddTicks(9623), 1 },
                    { new Guid("2ae7f0af-620d-4dfc-9b55-9e84992dc572"), 589.875277174124000m, false, new Guid("a4856544-8f7d-49d1-bc75-bfde8593a6fd"), "Beatae aliquam inventore corrupti et qui eius inventore. Doloribus eaque a fuga. Deleniti maiores eum occaecati quos aperiam autem excepturi et voluptatem. Fugit neque doloribus.", new DateTime(2018, 6, 14, 1, 52, 6, 75, DateTimeKind.Utc).AddTicks(1175), 0 },
                    { new Guid("2d6315a6-64c9-4be4-8665-0ebe8817e898"), 939.101750475232000m, false, new Guid("27b6e593-824c-4ace-b846-3af9909b1f65"), "Quae impedit occaecati sit exercitationem. Suscipit ipsa doloribus fugiat. Ut quo illum non nesciunt eligendi a ut.", new DateTime(2019, 7, 28, 18, 19, 28, 380, DateTimeKind.Utc).AddTicks(4714), 99 },
                    { new Guid("2dc9285c-e73d-4675-9e3c-67e81bb39021"), 1.54331572683075000m, false, new Guid("27b6e593-824c-4ace-b846-3af9909b1f65"), "Voluptas consectetur id voluptate ipsa aut et eos aut. Consectetur dolorum et sit. Autem accusamus dolore. Molestiae quod aut aut vero nam dolorum aut.", new DateTime(2014, 11, 8, 5, 55, 7, 238, DateTimeKind.Utc).AddTicks(8258), 0 },
                    { new Guid("2ea7f28e-5c1b-417b-9258-e98fcffaf426"), 656.857240591874000m, false, new Guid("8cc8a727-2c22-4d67-aaad-7a99a42ccb07"), "Quos nihil rerum soluta. Error voluptas minima at ex velit quia. Sunt eum qui voluptate ducimus quasi soluta ut commodi.", new DateTime(2013, 1, 6, 9, 54, 50, 238, DateTimeKind.Utc).AddTicks(1496), 0 },
                    { new Guid("2f407fb7-45a9-4dac-9ad3-962187d7e70e"), 380.15656244125000m, false, new Guid("10765bc8-7a84-4fd7-af14-468a9a24d48c"), "Maiores quibusdam fugiat sed similique optio aut natus aut aut.", new DateTime(2012, 3, 13, 15, 30, 23, 916, DateTimeKind.Utc).AddTicks(8933), 99 },
                    { new Guid("311dab6e-baf3-44df-b1c5-24199d90ca73"), 941.020659594294000m, false, new Guid("dbfa8ad9-8ce9-4e34-ab96-89495ccf0964"), "Optio possimus qui assumenda numquam nihil quaerat. At ipsam et assumenda aut architecto laudantium eveniet omnis aut.", new DateTime(2017, 1, 31, 2, 37, 55, 67, DateTimeKind.Utc).AddTicks(8749), 99 },
                    { new Guid("34df3774-3ce8-492e-8f26-b21bab0f51f7"), 678.661064444987000m, false, new Guid("c5ef00c0-f740-40ba-a2ec-f90600cd8587"), "Nulla exercitationem eum iusto ex distinctio corporis. Sint sunt optio animi dolorem minus magni in. Consequuntur eum dolorem eveniet sed debitis harum laborum ipsa cupiditate.", new DateTime(2017, 10, 26, 17, 34, 38, 737, DateTimeKind.Utc).AddTicks(8651), 1 },
                    { new Guid("34fd84bc-1231-4544-a9ef-c7e7e6da6b8b"), 345.303926205118000m, false, new Guid("c5ef00c0-f740-40ba-a2ec-f90600cd8587"), "Aliquam corporis rerum eum voluptatem totam.", new DateTime(2013, 7, 25, 16, 25, 33, 369, DateTimeKind.Utc).AddTicks(4368), 1 },
                    { new Guid("3522b4a3-1bfc-4f5c-aa0a-008d8a0d5bfa"), 267.316838431282000m, false, new Guid("e07a62f4-6ddd-4be4-b983-4902d2aabca3"), "Et est deleniti quo ab assumenda earum error commodi vero.", new DateTime(2022, 1, 24, 10, 44, 39, 560, DateTimeKind.Utc).AddTicks(1645), 99 },
                    { new Guid("3d79c5cb-453e-4218-a97b-fed180c98654"), 211.6202473421000m, false, new Guid("e04ee5ad-485f-459f-9913-56ff9495d6a1"), "Ad rem optio facere sed distinctio nihil voluptatum aut.", new DateTime(2013, 10, 20, 9, 4, 23, 838, DateTimeKind.Utc).AddTicks(9941), 1 },
                    { new Guid("3f63cf9d-93ac-456d-b838-0d3377b34094"), 103.970952755131000m, false, new Guid("9d6b320e-7809-44c6-bb0f-621d94518a3c"), "Iure neque provident quia unde nihil. Nihil voluptatem qui. Aperiam qui voluptatum eum ad.", new DateTime(2019, 8, 1, 10, 17, 9, 633, DateTimeKind.Utc).AddTicks(5976), 99 },
                    { new Guid("3f891a29-d1b6-418f-bc51-5d9f584193cb"), 873.231745960979000m, false, new Guid("ee804991-d117-4443-a038-67a602b22b8f"), "Veritatis sit totam quo vero nemo ea temporibus quidem. Accusantium ratione et. Tenetur nulla enim harum hic molestiae natus.", new DateTime(2017, 10, 31, 8, 59, 20, 155, DateTimeKind.Utc).AddTicks(6831), 99 },
                    { new Guid("3fe10152-eb60-49ab-afc2-d3b3f2e8d881"), 588.353464281709000m, false, new Guid("f996ca10-5c5f-4493-ab9c-939766ea46ec"), "Molestiae porro aperiam tempora et est aliquid. Unde voluptas quasi eligendi. Ut nulla autem est doloremque sunt.", new DateTime(2020, 8, 10, 5, 28, 17, 678, DateTimeKind.Utc).AddTicks(4285), 99 },
                    { new Guid("3ffef33d-7991-471f-aab4-8fb36f635ec7"), 499.211134976911000m, false, new Guid("1339ea5e-333b-431b-b9f7-46dcec82a275"), "Amet in et placeat et. Eius exercitationem expedita incidunt voluptatem laboriosam error. Ratione et voluptates cupiditate facilis.", new DateTime(2016, 5, 9, 3, 15, 22, 784, DateTimeKind.Utc).AddTicks(6409), 99 },
                    { new Guid("402b76a7-c320-4a72-b83b-453df4b7ec97"), 458.353182198968000m, false, new Guid("dbfa8ad9-8ce9-4e34-ab96-89495ccf0964"), "Enim officiis reprehenderit sunt aliquid fuga. Reiciendis numquam rerum odit vel dolorem quia rerum dignissimos. Consequatur officiis est quia. Voluptas omnis architecto sed ab aliquid.", new DateTime(2019, 6, 10, 18, 7, 16, 517, DateTimeKind.Utc).AddTicks(57), 0 },
                    { new Guid("404d2be1-524c-44e9-bd4b-5cabf0e746c5"), 896.001381084165000m, false, new Guid("293f8448-6306-44e1-b0d2-de6e56c05b6a"), "Ipsam suscipit dolores. Dolore et dolores commodi provident ipsam quaerat consequatur voluptatem.", new DateTime(2020, 2, 9, 5, 31, 29, 189, DateTimeKind.Utc).AddTicks(7539), 0 },
                    { new Guid("406b3075-068f-49d9-919b-d20cc7b9f3cc"), 520.905815932898000m, false, new Guid("8cc8a727-2c22-4d67-aaad-7a99a42ccb07"), "Voluptate aliquid error amet. Voluptas et et eum. Ab molestiae natus tempora.", new DateTime(2016, 11, 25, 19, 35, 49, 532, DateTimeKind.Utc).AddTicks(9592), 0 },
                    { new Guid("4186e16d-6f4d-4d1f-86fe-a2310a58ab67"), 199.369133203238000m, false, new Guid("9d6b320e-7809-44c6-bb0f-621d94518a3c"), "Ex quos omnis magnam. Cum dolorum eos et aliquid est adipisci ratione.", new DateTime(2017, 9, 28, 17, 48, 29, 798, DateTimeKind.Utc).AddTicks(7714), 99 },
                    { new Guid("43cd7f7b-7f98-40c2-a7e0-1af3bd654b06"), 177.360878522045000m, false, new Guid("a4856544-8f7d-49d1-bc75-bfde8593a6fd"), "Et in et quia earum explicabo. Dolorum voluptas eligendi dolorum iusto voluptas et voluptatibus reprehenderit molestiae. Tempore maxime omnis qui qui molestias est voluptas.", new DateTime(2017, 7, 15, 5, 23, 39, 616, DateTimeKind.Utc).AddTicks(7173), 1 },
                    { new Guid("43cd8ad2-10f2-446d-a090-080f1f51e85d"), 930.825815457799000m, false, new Guid("10765bc8-7a84-4fd7-af14-468a9a24d48c"), "Officia enim a doloremque harum explicabo rerum dolores.", new DateTime(2019, 5, 31, 13, 2, 50, 549, DateTimeKind.Utc).AddTicks(5129), 99 },
                    { new Guid("466c206b-dcce-4e72-9ed2-e67cecdd6938"), 357.814992768085000m, false, new Guid("e07a62f4-6ddd-4be4-b983-4902d2aabca3"), "Est dolorum id sit facilis quia id distinctio ad. Vero quam eos aut.", new DateTime(2017, 8, 2, 16, 49, 4, 784, DateTimeKind.Utc).AddTicks(7404), 1 },
                    { new Guid("49bef3d0-d05d-4930-b5e5-0d37e2fde59a"), 499.618999722967000m, false, new Guid("10765bc8-7a84-4fd7-af14-468a9a24d48c"), "Omnis sit velit quasi. Adipisci laborum repudiandae aut. Voluptatem et aliquam.", new DateTime(2016, 8, 6, 7, 23, 16, 551, DateTimeKind.Utc).AddTicks(7589), 99 },
                    { new Guid("4d203dc9-1cea-43e5-8353-9f2c7dd1327f"), 275.280957977672000m, false, new Guid("f996ca10-5c5f-4493-ab9c-939766ea46ec"), "Et laudantium dolorem repudiandae distinctio. Minus consequatur qui quia minima non.", new DateTime(2018, 5, 2, 10, 36, 36, 358, DateTimeKind.Utc).AddTicks(4027), 0 },
                    { new Guid("523f8445-81ae-47fc-9e06-bffcd24be5c7"), 796.176476772214000m, false, new Guid("8cc8a727-2c22-4d67-aaad-7a99a42ccb07"), "Necessitatibus quasi voluptas dolorum qui. Officiis ab expedita odit magnam autem vitae ut.", new DateTime(2014, 7, 9, 16, 52, 21, 924, DateTimeKind.Utc).AddTicks(5045), 0 },
                    { new Guid("525bb62e-758b-4553-8a1a-094f001b91bd"), 959.892502956435000m, false, new Guid("4a6c0db7-fa8b-4fa0-a332-47f50f255879"), "Cumque provident blanditiis aspernatur ipsa.", new DateTime(2014, 8, 17, 7, 31, 8, 312, DateTimeKind.Utc).AddTicks(4571), 1 },
                    { new Guid("53efb09e-e7c0-4568-bb21-64461449fdb3"), 124.559743611083000m, false, new Guid("f996ca10-5c5f-4493-ab9c-939766ea46ec"), "Itaque natus repellat culpa ut eum. Quas praesentium rerum exercitationem. Perferendis in nisi accusantium maxime dolores officiis qui sunt. Quo aut ut aspernatur.", new DateTime(2013, 12, 27, 16, 25, 48, 515, DateTimeKind.Utc).AddTicks(9865), 99 },
                    { new Guid("544311b3-c340-4426-b0cd-41f00537c16d"), 222.358878074576000m, false, new Guid("e07a62f4-6ddd-4be4-b983-4902d2aabca3"), "Molestiae consequuntur consequuntur veniam qui iste doloremque ut. Inventore nobis minima qui harum dolorem velit porro ullam iusto. Sit sed consequatur porro eligendi rerum sed.", new DateTime(2012, 4, 2, 3, 59, 53, 887, DateTimeKind.Utc).AddTicks(9058), 99 },
                    { new Guid("5446779e-7fe4-4ace-b8dd-da0822ea59e0"), 586.061832276049000m, false, new Guid("e07a62f4-6ddd-4be4-b983-4902d2aabca3"), "Quasi accusantium numquam non magni aut cumque.", new DateTime(2018, 3, 16, 6, 8, 40, 703, DateTimeKind.Utc).AddTicks(2388), 99 },
                    { new Guid("55d12bc5-1392-467d-a118-8328048b13d2"), 456.017095499986000m, false, new Guid("60033e04-f97b-4ed8-9104-3029eef5bdb8"), "Fuga eum ea dolore laboriosam fuga tempore atque dolorum. Quibusdam dolore ipsam assumenda omnis cumque. Fuga aspernatur autem sed suscipit.", new DateTime(2016, 8, 17, 11, 15, 46, 221, DateTimeKind.Utc).AddTicks(6732), 1 },
                    { new Guid("574e1960-4786-44b6-940a-0e6f9c0166fa"), 488.337306496519000m, false, new Guid("60033e04-f97b-4ed8-9104-3029eef5bdb8"), "Sed nihil eum.", new DateTime(2018, 2, 23, 14, 51, 13, 656, DateTimeKind.Utc).AddTicks(585), 1 },
                    { new Guid("59ff5b08-3aef-463c-9909-c255a975cdb6"), 687.046397896352000m, false, new Guid("e04ee5ad-485f-459f-9913-56ff9495d6a1"), "Voluptas omnis quaerat voluptatem porro quia consectetur labore amet assumenda.", new DateTime(2017, 5, 11, 16, 10, 29, 331, DateTimeKind.Utc).AddTicks(5669), 99 },
                    { new Guid("5a54262d-032b-4f07-bb63-0b1273969be5"), 216.620529143254000m, false, new Guid("e07a62f4-6ddd-4be4-b983-4902d2aabca3"), "Quam officia libero voluptatem doloremque quibusdam quisquam et sed. Sit neque eveniet.", new DateTime(2020, 12, 22, 3, 57, 1, 190, DateTimeKind.Utc).AddTicks(7326), 1 },
                    { new Guid("5bfdd386-1082-4510-af98-1e7d0b40debc"), 671.285374717254000m, false, new Guid("8d4eb238-5f87-4849-af4c-de1ec6b76cae"), "Consequatur est voluptatem et perferendis voluptatibus omnis est iusto. Eveniet consequatur omnis voluptatem quo officiis voluptatum fugiat qui minima. Quia vel explicabo explicabo quia eius nisi illo iusto.", new DateTime(2017, 7, 3, 22, 21, 26, 330, DateTimeKind.Utc).AddTicks(7994), 0 },
                    { new Guid("5c0ff19a-83a7-4059-b971-7944819f6ab6"), 150.147978197572000m, false, new Guid("7fe7e445-5866-48d8-9e0f-cb2460103c01"), "Qui saepe et eius. Et voluptatibus itaque magnam mollitia aut debitis enim earum. Dignissimos voluptatibus enim. Reiciendis consectetur non dolor praesentium velit ad pariatur quod.", new DateTime(2013, 1, 10, 21, 22, 58, 903, DateTimeKind.Utc).AddTicks(291), 1 },
                    { new Guid("5c420874-9127-4f89-a0a3-16a4507a2e0a"), 147.080019246121000m, false, new Guid("8d4eb238-5f87-4849-af4c-de1ec6b76cae"), "Odio amet commodi voluptas minus nostrum aut ut iste et. Sit molestiae rerum. Sint non aut nobis. Et laudantium saepe est deserunt.", new DateTime(2017, 6, 8, 13, 7, 15, 254, DateTimeKind.Utc).AddTicks(9892), 99 },
                    { new Guid("5da8423f-4556-4d73-be48-664d86690acc"), 372.470537863681000m, false, new Guid("776ff3b6-36cd-4926-8d24-4a0ada93eaea"), "Reiciendis labore in eligendi harum labore. Iusto natus quibusdam id. Hic inventore aut mollitia enim.", new DateTime(2014, 8, 29, 4, 17, 36, 982, DateTimeKind.Utc).AddTicks(1307), 1 },
                    { new Guid("60f463bf-3367-4c77-95e7-5df51f26ecd2"), 321.324056547274000m, false, new Guid("57e7666c-e85d-47c5-8137-c5ed7d565cec"), "Ut vel rerum neque omnis accusantium non praesentium sed voluptatem. Ea sapiente aliquid.", new DateTime(2015, 3, 21, 12, 50, 36, 180, DateTimeKind.Utc).AddTicks(8540), 1 },
                    { new Guid("61993920-8546-432a-8d0a-571eb4e3f240"), 123.754055795397000m, false, new Guid("27b6e593-824c-4ace-b846-3af9909b1f65"), "Quia quia magnam sunt voluptatem rerum. Illum similique deleniti sed distinctio quo ut facilis. Soluta quasi error. Nesciunt tenetur consequatur aut.", new DateTime(2016, 4, 20, 22, 43, 53, 815, DateTimeKind.Utc).AddTicks(8276), 0 },
                    { new Guid("6221d86e-b487-416d-b443-7b24e06f23de"), 495.676736100321000m, false, new Guid("57e7666c-e85d-47c5-8137-c5ed7d565cec"), "Cumque ut voluptatem vel maiores repellat nobis quia deserunt dolorem. Maiores laborum sed sint. Molestias et enim fugit et voluptate. Inventore numquam ipsa praesentium dolor enim eius.", new DateTime(2017, 1, 27, 17, 25, 37, 554, DateTimeKind.Utc).AddTicks(3265), 1 },
                    { new Guid("6288d7e4-7d8f-4c05-b36a-8753da5a433d"), 374.565829978254000m, false, new Guid("e07a62f4-6ddd-4be4-b983-4902d2aabca3"), "Repellendus id odit autem nesciunt debitis. Unde non quia nesciunt. Qui non esse ad id sit voluptas animi ut. Ea modi est quo.", new DateTime(2013, 10, 16, 9, 39, 22, 850, DateTimeKind.Utc).AddTicks(3308), 0 },
                    { new Guid("62a7a952-79f8-4de6-a4d1-4cd60a17f8ed"), 795.974353513594000m, false, new Guid("8cc8a727-2c22-4d67-aaad-7a99a42ccb07"), "Et ex et voluptatum vitae voluptas nemo quisquam. Aspernatur facilis quia totam ipsum nemo dolor. Expedita aut asperiores et officiis sit hic quas sapiente.", new DateTime(2018, 4, 21, 1, 48, 39, 528, DateTimeKind.Utc).AddTicks(9413), 0 },
                    { new Guid("62d30f1e-8ca6-48c2-9dbf-1e2776adca6d"), 377.165596360714000m, false, new Guid("9d6b320e-7809-44c6-bb0f-621d94518a3c"), "Harum tenetur odio non dolorem. Dolor aperiam voluptatem est inventore harum neque error quis dolor.", new DateTime(2013, 7, 13, 0, 30, 17, 576, DateTimeKind.Utc).AddTicks(1770), 1 },
                    { new Guid("62f1c0f1-8ecf-47fc-b721-18562fc8f650"), 447.266561314448000m, false, new Guid("a4856544-8f7d-49d1-bc75-bfde8593a6fd"), "Ex ab cupiditate et voluptas iure omnis officiis. Distinctio quia dolor ad quae a eveniet voluptatem et. Non doloremque nesciunt ad iste aperiam voluptatem repellat at.", new DateTime(2012, 5, 6, 7, 42, 17, 39, DateTimeKind.Utc).AddTicks(7073), 0 },
                    { new Guid("64d11ebf-e5db-4f8b-97a2-a7f28576ffcc"), 32.7385871486074000m, false, new Guid("8d4eb238-5f87-4849-af4c-de1ec6b76cae"), "Aliquid sed sed voluptatem voluptate mollitia officiis.", new DateTime(2019, 10, 14, 7, 21, 7, 735, DateTimeKind.Utc).AddTicks(8879), 0 },
                    { new Guid("64dbacec-310e-402e-a919-a1928e149579"), 509.564165198994000m, false, new Guid("ee804991-d117-4443-a038-67a602b22b8f"), "Et et et. Cumque laudantium ut consequuntur corrupti. Eos quasi possimus omnis voluptatem assumenda rerum unde corrupti libero.", new DateTime(2021, 4, 26, 2, 52, 52, 333, DateTimeKind.Utc).AddTicks(9040), 0 },
                    { new Guid("6692f04a-3474-403b-8d69-69e5a941f9e2"), 509.428697301324000m, false, new Guid("a4856544-8f7d-49d1-bc75-bfde8593a6fd"), "Tempora nesciunt perspiciatis porro ipsam ut ea nobis quas. Cumque eaque iure iure est. Inventore similique consequatur dicta tempore voluptatem ab.", new DateTime(2013, 9, 1, 3, 43, 17, 324, DateTimeKind.Utc).AddTicks(4314), 99 },
                    { new Guid("677be39e-1a13-46a9-a464-74e069f2de0f"), 488.72920948791000m, false, new Guid("4a6c0db7-fa8b-4fa0-a332-47f50f255879"), "Ex ut at aperiam hic nemo doloribus fugit ipsa nemo.", new DateTime(2013, 3, 11, 3, 16, 32, 641, DateTimeKind.Utc).AddTicks(5591), 0 },
                    { new Guid("6aee8126-ceae-4d27-bb10-3814ff4a5261"), 85.1216882671847000m, false, new Guid("e04ee5ad-485f-459f-9913-56ff9495d6a1"), "Facilis non ab eum non cumque asperiores perspiciatis. Adipisci tenetur omnis et. Sapiente voluptatibus dolore quia corrupti nisi reiciendis. Laborum voluptate asperiores voluptatem aut rem.", new DateTime(2013, 6, 2, 20, 51, 4, 734, DateTimeKind.Utc).AddTicks(6052), 0 },
                    { new Guid("6bf05f8d-3ae2-4da7-a5b1-402f9449e353"), 283.294320800547000m, false, new Guid("a4856544-8f7d-49d1-bc75-bfde8593a6fd"), "Quod explicabo qui autem perferendis sunt mollitia. Modi ullam amet illum. Ea deserunt consectetur unde.", new DateTime(2014, 7, 11, 20, 28, 35, 603, DateTimeKind.Utc).AddTicks(961), 99 },
                    { new Guid("6c07d548-2061-4d43-b8bb-55fe876453be"), 775.891848882772000m, false, new Guid("8cc8a727-2c22-4d67-aaad-7a99a42ccb07"), "Non est enim ut doloremque numquam deserunt. Ducimus in ut reprehenderit sunt consequatur nemo minima modi id. Atque eveniet nihil magni repudiandae quis exercitationem qui necessitatibus.", new DateTime(2013, 10, 4, 4, 54, 11, 303, DateTimeKind.Utc).AddTicks(5455), 1 },
                    { new Guid("6e9cc0ab-16a5-4d8f-a472-f7d52865fb11"), 588.847724874308000m, false, new Guid("8d4eb238-5f87-4849-af4c-de1ec6b76cae"), "Ipsum repellat facilis voluptatibus facilis voluptatem laudantium dolore. Temporibus tenetur alias est et quo.", new DateTime(2014, 10, 15, 17, 4, 6, 217, DateTimeKind.Utc).AddTicks(4557), 1 },
                    { new Guid("70476a20-184e-47c4-ad77-4d7f47d899d3"), 912.217444779499000m, false, new Guid("8d4eb238-5f87-4849-af4c-de1ec6b76cae"), "Quod repellat quidem soluta iusto cum. Non est beatae quia exercitationem.", new DateTime(2014, 2, 27, 12, 33, 7, 501, DateTimeKind.Utc).AddTicks(935), 99 },
                    { new Guid("718dfcd2-3531-47ad-ab95-ecf0e18e46c8"), 21.941495636744000m, false, new Guid("f996ca10-5c5f-4493-ab9c-939766ea46ec"), "Ut ipsum quo non rerum quae. At sed quas eum vel laudantium. Sit error dolor saepe.", new DateTime(2014, 3, 24, 22, 48, 18, 438, DateTimeKind.Utc).AddTicks(4708), 1 },
                    { new Guid("73222ed6-bee6-4bf8-83f7-8d52161a5d57"), 947.391790241034000m, false, new Guid("9d6b320e-7809-44c6-bb0f-621d94518a3c"), "Est error et provident veniam dolore impedit. Qui error doloribus quae laborum rerum reiciendis et. Voluptatem reprehenderit et. Quia mollitia quo aperiam.", new DateTime(2018, 5, 1, 7, 29, 56, 805, DateTimeKind.Utc).AddTicks(4459), 0 },
                    { new Guid("734df95e-1ded-4d94-b4d2-08c6b8d75b2b"), 416.520946673582000m, false, new Guid("a4856544-8f7d-49d1-bc75-bfde8593a6fd"), "Quibusdam exercitationem est voluptatem. Libero aliquam eum tempora minus a perferendis. Eaque officiis enim minima illum ea.", new DateTime(2021, 6, 3, 22, 9, 8, 236, DateTimeKind.Utc).AddTicks(783), 1 },
                    { new Guid("743a1b60-fed6-40c8-b007-f1bcb3eeedac"), 902.961793717975000m, false, new Guid("8cc8a727-2c22-4d67-aaad-7a99a42ccb07"), "Occaecati nam consequatur eum error tempora laudantium quis voluptates. Nihil et earum qui aut explicabo harum molestiae atque. Voluptatem molestiae est iure et dignissimos. Aut tenetur ex perspiciatis cupiditate magnam.", new DateTime(2019, 8, 5, 3, 2, 35, 270, DateTimeKind.Utc).AddTicks(7618), 1 },
                    { new Guid("750c182d-a02a-4a3e-bf21-5e7ea85e8d51"), 726.82852096865000m, false, new Guid("8d4eb238-5f87-4849-af4c-de1ec6b76cae"), "Placeat qui iusto culpa et. Est illo molestias totam blanditiis sed cumque. Repellat eos repellendus possimus quo maiores perspiciatis voluptas. Et debitis accusamus non in ad sit in deleniti tempora.", new DateTime(2019, 4, 5, 18, 22, 46, 963, DateTimeKind.Utc).AddTicks(288), 99 },
                    { new Guid("77a92eb1-7b2b-4cc5-96d7-6dd994f87b41"), 836.764443055484000m, false, new Guid("293f8448-6306-44e1-b0d2-de6e56c05b6a"), "Maiores commodi neque. Velit aut pariatur est voluptatum consequatur voluptate dolore distinctio est. Repellendus placeat ut ut autem itaque et velit.", new DateTime(2017, 11, 25, 17, 56, 57, 51, DateTimeKind.Utc).AddTicks(1138), 1 },
                    { new Guid("77dae34a-8ce3-4bb2-a592-9daee0d26030"), 460.443809502714000m, false, new Guid("e07a62f4-6ddd-4be4-b983-4902d2aabca3"), "Ad omnis rerum velit nulla recusandae minus totam ut. Voluptatem tempora voluptas sint voluptatibus sed quae. Repudiandae adipisci est est.", new DateTime(2014, 4, 26, 13, 25, 12, 572, DateTimeKind.Utc).AddTicks(8803), 1 },
                    { new Guid("77daf84f-e81a-447d-a43c-bd530a4c21c5"), 841.8672826883000m, false, new Guid("c0008290-6a8b-4dfb-8d2f-198bc8f28420"), "Itaque consectetur aut repellendus. Voluptas velit voluptatem est odio. Laborum molestiae vel enim culpa provident delectus numquam tempore totam.", new DateTime(2017, 5, 25, 23, 51, 46, 709, DateTimeKind.Utc).AddTicks(9683), 1 },
                    { new Guid("7a2a1500-2a15-4ee6-952a-633d8df5b5c8"), 417.817319403871000m, false, new Guid("c0008290-6a8b-4dfb-8d2f-198bc8f28420"), "Dolorem sed dolorem veniam asperiores quod numquam vel quod. Optio voluptatem culpa temporibus ipsa quibusdam voluptatibus. Non est accusantium velit laborum labore sint.", new DateTime(2017, 6, 7, 16, 38, 28, 712, DateTimeKind.Utc).AddTicks(9463), 0 },
                    { new Guid("7ae10e34-d0b8-474b-9032-524b05ef2c7c"), 504.85587921352000m, false, new Guid("dbfa8ad9-8ce9-4e34-ab96-89495ccf0964"), "Doloremque et omnis voluptas aut. Nulla deleniti et vero est perspiciatis sunt in suscipit et.", new DateTime(2018, 5, 17, 0, 18, 40, 373, DateTimeKind.Utc).AddTicks(5197), 99 },
                    { new Guid("7b08dfe6-34ea-4ecb-95a4-2fed2eae5aae"), 260.468708555035000m, false, new Guid("e07a62f4-6ddd-4be4-b983-4902d2aabca3"), "Totam tempore rerum illo voluptas quia a voluptatem reprehenderit in. Ducimus nihil molestias reprehenderit adipisci ipsam ipsa vel.", new DateTime(2016, 2, 2, 6, 45, 46, 378, DateTimeKind.Utc).AddTicks(3438), 99 },
                    { new Guid("7e31a1d7-9cde-4d21-855b-7d5059b20d72"), 973.76542548038000m, false, new Guid("f996ca10-5c5f-4493-ab9c-939766ea46ec"), "Ut voluptatem deserunt suscipit perspiciatis enim. Rerum provident deleniti reiciendis.", new DateTime(2016, 6, 4, 19, 36, 15, 163, DateTimeKind.Utc).AddTicks(7794), 1 },
                    { new Guid("7e6e14a3-747d-412b-a31d-5aa103932b77"), 788.319217014625000m, false, new Guid("293f8448-6306-44e1-b0d2-de6e56c05b6a"), "Neque quaerat non minima soluta aut quidem. Tempora totam fugit officiis non minus ratione et sapiente. Veniam voluptatum assumenda. Nam nihil aut possimus iusto officiis asperiores non aut.", new DateTime(2019, 9, 23, 17, 33, 27, 446, DateTimeKind.Utc).AddTicks(8968), 0 },
                    { new Guid("7f0017a1-4c89-4f4e-99db-d0f3a103a8f7"), 919.461943509527000m, false, new Guid("a4856544-8f7d-49d1-bc75-bfde8593a6fd"), "Qui ratione aut eos sed deserunt. Unde cum minima ipsum debitis doloremque hic sed omnis quam.", new DateTime(2019, 12, 2, 22, 45, 38, 538, DateTimeKind.Utc).AddTicks(4763), 1 },
                    { new Guid("7f1af57b-3bb1-48d4-a5c5-348a1e417a29"), 149.351214289275000m, false, new Guid("7fe7e445-5866-48d8-9e0f-cb2460103c01"), "Eligendi sed voluptatum exercitationem omnis eos. Voluptatem facere et ad sint minima. Aperiam possimus sint et similique et eos sit modi eaque.", new DateTime(2018, 11, 20, 17, 51, 15, 143, DateTimeKind.Utc).AddTicks(7032), 99 },
                    { new Guid("8088ab0c-8cbd-49b5-b27e-496b481efc97"), 865.845150366233000m, false, new Guid("293f8448-6306-44e1-b0d2-de6e56c05b6a"), "Deleniti incidunt libero. Nostrum corporis alias. Totam sit aliquam neque eos quam veritatis.", new DateTime(2017, 2, 4, 16, 36, 32, 202, DateTimeKind.Utc).AddTicks(4512), 99 },
                    { new Guid("809c8d6b-0534-4364-9398-66a2f285f6b1"), 85.0154451400721000m, false, new Guid("57e7666c-e85d-47c5-8137-c5ed7d565cec"), "Nesciunt qui sed debitis minus. Nihil aut nulla quisquam assumenda commodi doloremque. Animi enim illo corrupti quia repellat aut odio.", new DateTime(2013, 11, 1, 1, 38, 24, 501, DateTimeKind.Utc).AddTicks(6952), 1 },
                    { new Guid("82682f6c-fd65-4b1d-8251-dc544c8d7a03"), 548.847155448763000m, false, new Guid("dbfa8ad9-8ce9-4e34-ab96-89495ccf0964"), "Architecto repellat sed repellat aspernatur deleniti nobis aut.", new DateTime(2021, 5, 3, 5, 21, 50, 176, DateTimeKind.Utc).AddTicks(5665), 1 },
                    { new Guid("83bbf7cd-a81c-44e7-ace2-f3332df12146"), 114.80607899749000m, false, new Guid("57e7666c-e85d-47c5-8137-c5ed7d565cec"), "In incidunt ut. Non qui consectetur ducimus recusandae expedita hic voluptatem in exercitationem.", new DateTime(2015, 1, 17, 16, 53, 51, 279, DateTimeKind.Utc).AddTicks(6075), 1 },
                    { new Guid("8b64b897-effa-4c82-93f7-71d2887245db"), 620.405336675022000m, false, new Guid("9d6b320e-7809-44c6-bb0f-621d94518a3c"), "Enim maiores et pariatur aliquid.", new DateTime(2014, 2, 14, 8, 51, 0, 628, DateTimeKind.Utc).AddTicks(2508), 99 },
                    { new Guid("8c8b5787-d913-46df-b541-0c69930dcec4"), 707.686113363176000m, false, new Guid("9d6b320e-7809-44c6-bb0f-621d94518a3c"), "Quia delectus voluptas placeat officia qui autem.", new DateTime(2020, 6, 15, 11, 3, 12, 718, DateTimeKind.Utc).AddTicks(682), 1 },
                    { new Guid("8e7fc9bb-6e45-4f34-a095-580282a01bcb"), 43.983205945924000m, false, new Guid("293f8448-6306-44e1-b0d2-de6e56c05b6a"), "Porro ducimus odio accusantium voluptas. Libero id unde beatae quia adipisci officiis qui assumenda. Ex reiciendis tempore numquam.", new DateTime(2015, 12, 4, 12, 39, 1, 548, DateTimeKind.Utc).AddTicks(8130), 1 },
                    { new Guid("90a16182-1c39-4865-8918-a8a0cd851b82"), 695.071211700515000m, false, new Guid("c0008290-6a8b-4dfb-8d2f-198bc8f28420"), "Officia placeat illo ut et. Quidem voluptatem nulla aut. Distinctio quia eos.", new DateTime(2019, 10, 4, 12, 41, 25, 982, DateTimeKind.Utc).AddTicks(7510), 0 },
                    { new Guid("94f4f3a5-ee56-474d-b987-260f558e7c7b"), 559.957385697339000m, false, new Guid("776ff3b6-36cd-4926-8d24-4a0ada93eaea"), "Aut laborum quis consectetur optio sequi minima distinctio pariatur sapiente. Corporis molestiae quae id voluptatum magni aut exercitationem quo voluptatum.", new DateTime(2016, 4, 13, 0, 9, 59, 59, DateTimeKind.Utc).AddTicks(4829), 0 },
                    { new Guid("97e736f4-82c8-426e-84d8-bc7b2a2ee4e7"), 897.791305383102000m, false, new Guid("10765bc8-7a84-4fd7-af14-468a9a24d48c"), "Provident aut voluptas omnis deserunt quos ea et facilis. Facilis aut vel voluptatem tenetur.", new DateTime(2019, 3, 31, 7, 24, 39, 38, DateTimeKind.Utc).AddTicks(9123), 99 },
                    { new Guid("996aedbf-ac0d-445c-b98f-518cf2bc4afb"), 10.5795043806047000m, false, new Guid("c5ef00c0-f740-40ba-a2ec-f90600cd8587"), "Velit vero consequatur eum aut nam vel vel.", new DateTime(2014, 1, 5, 21, 55, 26, 185, DateTimeKind.Utc).AddTicks(6224), 1 },
                    { new Guid("9974c377-264e-464c-afb1-f55e1cfa6d73"), 246.619506049223000m, false, new Guid("776ff3b6-36cd-4926-8d24-4a0ada93eaea"), "Voluptas cum sit aut suscipit.", new DateTime(2012, 2, 22, 4, 12, 25, 707, DateTimeKind.Utc).AddTicks(9293), 0 },
                    { new Guid("99e38be3-b658-4d91-a638-6e1c9cf94750"), 97.0741818455741000m, false, new Guid("c0008290-6a8b-4dfb-8d2f-198bc8f28420"), "Officia qui quasi sapiente eaque neque laborum. Distinctio qui tenetur dolores labore non sed dolorem deleniti.", new DateTime(2017, 8, 8, 1, 17, 45, 209, DateTimeKind.Utc).AddTicks(4030), 1 },
                    { new Guid("9e3b6fd6-eb07-4c30-b81a-a634e7f5ca22"), 667.578024659416000m, false, new Guid("e04ee5ad-485f-459f-9913-56ff9495d6a1"), "Quod quibusdam dolor autem officia voluptates eum. Quam amet cumque sequi iste asperiores iste aliquam repellat reiciendis.", new DateTime(2019, 7, 18, 2, 36, 14, 284, DateTimeKind.Utc).AddTicks(8286), 99 },
                    { new Guid("9ff61187-940f-41fb-838c-a43067f8b012"), 914.462464687458000m, false, new Guid("8d4eb238-5f87-4849-af4c-de1ec6b76cae"), "Odio et ipsum. Saepe reiciendis similique ut odio assumenda ut aut. Sequi mollitia ad enim sit quia pariatur dolores vel possimus. Et quis voluptatibus in quis iure.", new DateTime(2015, 6, 28, 17, 7, 58, 783, DateTimeKind.Utc).AddTicks(2633), 0 },
                    { new Guid("a0e2f715-9782-455b-a1d9-5a79ce0e6c05"), 356.749925307799000m, false, new Guid("ee804991-d117-4443-a038-67a602b22b8f"), "Tempora neque aut itaque itaque ipsam. Non dolor quidem.", new DateTime(2020, 2, 16, 13, 26, 54, 206, DateTimeKind.Utc).AddTicks(3618), 99 },
                    { new Guid("a12b1bd5-cb8f-43d3-a969-d97a748ac030"), 260.920945341095000m, false, new Guid("e07a62f4-6ddd-4be4-b983-4902d2aabca3"), "Pariatur magnam blanditiis.", new DateTime(2018, 7, 15, 21, 30, 7, 731, DateTimeKind.Utc).AddTicks(7982), 1 },
                    { new Guid("a3e2912b-5045-4b52-80e8-1698b7a5b397"), 556.158130265143000m, false, new Guid("4a6c0db7-fa8b-4fa0-a332-47f50f255879"), "Id animi cumque qui porro culpa expedita. Illum consectetur sapiente.", new DateTime(2015, 12, 10, 12, 23, 27, 821, DateTimeKind.Utc).AddTicks(5882), 1 },
                    { new Guid("a453cd5d-ae36-4493-a54c-804ff66a601b"), 100.89265682586000m, false, new Guid("60033e04-f97b-4ed8-9104-3029eef5bdb8"), "Architecto voluptatem fugiat est natus saepe. Quia eum est sapiente tempora officiis voluptas. Consequuntur aut alias. In occaecati nulla omnis incidunt doloribus illo.", new DateTime(2020, 7, 19, 23, 6, 49, 119, DateTimeKind.Utc).AddTicks(105), 99 },
                    { new Guid("a4565980-8c46-4ea8-a558-45b677d313c0"), 526.332709222708000m, false, new Guid("7fe7e445-5866-48d8-9e0f-cb2460103c01"), "Distinctio perspiciatis ut sunt. Rem inventore incidunt in nesciunt.", new DateTime(2017, 4, 15, 1, 54, 44, 150, DateTimeKind.Utc).AddTicks(7995), 1 },
                    { new Guid("a66b0a84-17f1-484d-a622-eb41ab7edfdf"), 994.274362343263000m, false, new Guid("776ff3b6-36cd-4926-8d24-4a0ada93eaea"), "Culpa molestias et consectetur sit consequatur et est non voluptatem.", new DateTime(2016, 10, 2, 9, 57, 6, 468, DateTimeKind.Utc).AddTicks(1858), 0 },
                    { new Guid("a6e35022-b827-4538-8e7d-8d3122e3acd5"), 745.135884574202000m, false, new Guid("7fe7e445-5866-48d8-9e0f-cb2460103c01"), "Sed ipsa molestiae rem velit reiciendis nobis voluptatem enim.", new DateTime(2013, 5, 8, 4, 43, 32, 250, DateTimeKind.Utc).AddTicks(1811), 0 },
                    { new Guid("a7b924c3-7301-40b2-8c25-79865fa3a701"), 803.998505040307000m, false, new Guid("c5ef00c0-f740-40ba-a2ec-f90600cd8587"), "Iste eum ad deleniti et deleniti recusandae. Sunt et impedit illo quaerat adipisci consequatur id.", new DateTime(2022, 1, 2, 13, 9, 2, 407, DateTimeKind.Utc).AddTicks(8112), 1 },
                    { new Guid("a871b676-310d-4708-a718-19e4c29593aa"), 368.407117462491000m, false, new Guid("dbfa8ad9-8ce9-4e34-ab96-89495ccf0964"), "Dolorem qui nemo alias dolores.", new DateTime(2020, 6, 14, 17, 8, 13, 329, DateTimeKind.Utc).AddTicks(1360), 99 },
                    { new Guid("a8fb455a-e267-4ab7-b0d1-aae31e20a2c9"), 498.127219606219000m, false, new Guid("ee804991-d117-4443-a038-67a602b22b8f"), "Laboriosam sit et sint. Ut eum necessitatibus sint. Quia quas nesciunt. Mollitia qui qui.", new DateTime(2013, 3, 15, 17, 9, 59, 713, DateTimeKind.Utc).AddTicks(2498), 99 },
                    { new Guid("a92c67bd-8d48-4d00-bd20-9e4f69aaa64f"), 127.876718324792000m, false, new Guid("c5ef00c0-f740-40ba-a2ec-f90600cd8587"), "Optio illum quia architecto a sint error animi aut. Corrupti iusto ipsum rerum fugit enim provident deleniti iure.", new DateTime(2017, 6, 10, 23, 41, 39, 292, DateTimeKind.Utc).AddTicks(2440), 0 },
                    { new Guid("aa098236-8f55-4302-8f0a-a983579e751f"), 348.536285889807000m, false, new Guid("4a6c0db7-fa8b-4fa0-a332-47f50f255879"), "Commodi nostrum ipsam quo esse vel dolorem temporibus. Quod ut odit ut vel sed enim in quo veniam. Velit ut aut sequi quia.", new DateTime(2013, 6, 30, 1, 12, 53, 81, DateTimeKind.Utc).AddTicks(3018), 99 },
                    { new Guid("aab4e0cc-abc9-4380-8c9a-6f5378db0b0b"), 802.638013709982000m, false, new Guid("1339ea5e-333b-431b-b9f7-46dcec82a275"), "Recusandae quasi alias. Ad dolor dolores perspiciatis earum ratione recusandae iusto.", new DateTime(2016, 12, 18, 0, 28, 48, 603, DateTimeKind.Utc).AddTicks(9508), 99 },
                    { new Guid("ab6c0301-db37-4af5-98d5-5149f402a28d"), 743.753006607638000m, false, new Guid("10765bc8-7a84-4fd7-af14-468a9a24d48c"), "Nemo voluptatibus earum vitae et. Dignissimos laboriosam debitis quam qui nemo et incidunt. Ea similique voluptas aut suscipit. Unde et ipsam deleniti perspiciatis et.", new DateTime(2017, 6, 6, 2, 52, 6, 34, DateTimeKind.Utc).AddTicks(6352), 0 },
                    { new Guid("abaab6b0-e2a5-4336-8646-473cf234ec50"), 200.476873280635000m, false, new Guid("dbfa8ad9-8ce9-4e34-ab96-89495ccf0964"), "Ut hic molestias. Ullam inventore enim ex. Temporibus consequatur eos accusantium consequatur culpa culpa.", new DateTime(2013, 10, 15, 22, 28, 11, 199, DateTimeKind.Utc).AddTicks(2208), 0 },
                    { new Guid("abf0cef7-a7e5-4454-8cc6-e7b352c81ea3"), 623.602783995651000m, false, new Guid("8d4eb238-5f87-4849-af4c-de1ec6b76cae"), "Incidunt necessitatibus provident id ut et consequuntur.", new DateTime(2020, 11, 8, 18, 49, 25, 872, DateTimeKind.Utc).AddTicks(5831), 1 },
                    { new Guid("afe194b2-22c3-46c2-b2fb-622fb6a1d089"), 760.371579671011000m, false, new Guid("27b6e593-824c-4ace-b846-3af9909b1f65"), "Sunt qui occaecati deserunt maiores. A et assumenda ut omnis voluptatum. Assumenda placeat hic inventore qui aperiam rerum maiores commodi beatae. Rem et voluptatem numquam voluptate aut voluptatem voluptatem sint.", new DateTime(2018, 3, 26, 9, 26, 23, 712, DateTimeKind.Utc).AddTicks(2909), 0 },
                    { new Guid("b1f6d257-3f0e-4d58-b219-6b9572a61bbc"), 216.780208202658000m, false, new Guid("57e7666c-e85d-47c5-8137-c5ed7d565cec"), "Officia omnis sit. Dolor fugit nihil vel dolor.", new DateTime(2019, 10, 11, 9, 44, 18, 383, DateTimeKind.Utc).AddTicks(5545), 0 },
                    { new Guid("b3367588-7abc-4a3d-86eb-ddf5de630921"), 749.22097813146000m, false, new Guid("293f8448-6306-44e1-b0d2-de6e56c05b6a"), "Beatae sed enim inventore est temporibus. Odio quia rem id ut cum iste distinctio qui.", new DateTime(2020, 8, 11, 8, 40, 40, 837, DateTimeKind.Utc).AddTicks(4569), 0 },
                    { new Guid("b439b26e-03a4-4220-88f9-936f34d079f5"), 418.748141437787000m, false, new Guid("7fe7e445-5866-48d8-9e0f-cb2460103c01"), "Exercitationem quos debitis et aliquam. Consectetur omnis eaque labore.", new DateTime(2016, 12, 26, 23, 36, 32, 448, DateTimeKind.Utc).AddTicks(4842), 1 },
                    { new Guid("b5e53788-d0ff-4152-b291-754bb25aaa03"), 440.031503902059000m, false, new Guid("60033e04-f97b-4ed8-9104-3029eef5bdb8"), "Aspernatur ullam qui ad id. Et est neque omnis perferendis temporibus sequi veniam similique nulla.", new DateTime(2015, 10, 21, 0, 47, 20, 820, DateTimeKind.Utc).AddTicks(6551), 0 },
                    { new Guid("b5f568a9-e7dc-409e-8021-265489aa902c"), 253.576867951586000m, false, new Guid("4a6c0db7-fa8b-4fa0-a332-47f50f255879"), "Nesciunt adipisci consequatur nostrum magni doloremque quod eaque quo. Laudantium molestiae dolorum incidunt labore sint dolores dolore. Tenetur consequuntur quo consequatur non sed in qui quod. Nesciunt aliquam enim itaque rerum nobis.", new DateTime(2015, 11, 7, 8, 19, 23, 870, DateTimeKind.Utc).AddTicks(1959), 1 },
                    { new Guid("b6561289-b16c-4051-86f0-13737d96fa1a"), 539.593058040231000m, false, new Guid("e04ee5ad-485f-459f-9913-56ff9495d6a1"), "Cumque qui quia qui cum.", new DateTime(2021, 5, 2, 17, 1, 47, 620, DateTimeKind.Utc).AddTicks(8825), 1 },
                    { new Guid("b7a986f7-2729-44c9-971d-38debc10d41a"), 440.137807975282000m, false, new Guid("1339ea5e-333b-431b-b9f7-46dcec82a275"), "Quas quos sint eius. Nostrum et delectus.", new DateTime(2018, 4, 20, 20, 19, 44, 814, DateTimeKind.Utc).AddTicks(2856), 1 },
                    { new Guid("b7b772e9-266f-4242-9237-8398bdb77b5e"), 397.276567179779000m, false, new Guid("8d4eb238-5f87-4849-af4c-de1ec6b76cae"), "Cumque quas est modi ab quia.", new DateTime(2020, 3, 28, 18, 17, 12, 421, DateTimeKind.Utc).AddTicks(4091), 99 },
                    { new Guid("ba4ce8c7-35bb-4d29-ba50-ccf08b93ffff"), 408.348863355912000m, false, new Guid("c5ef00c0-f740-40ba-a2ec-f90600cd8587"), "Eum qui in enim distinctio expedita est pariatur. Vitae aut perferendis iure. Eius ut deleniti aspernatur error facilis fugiat inventore.", new DateTime(2014, 9, 8, 21, 23, 27, 967, DateTimeKind.Utc).AddTicks(8757), 1 },
                    { new Guid("baca5fef-1765-4322-ada7-0ac81e5d6dc6"), 394.119297231842000m, false, new Guid("27b6e593-824c-4ace-b846-3af9909b1f65"), "Perspiciatis rem nihil magni itaque aut harum. Nihil vitae atque iusto delectus ut odio assumenda numquam.", new DateTime(2017, 9, 10, 14, 14, 20, 522, DateTimeKind.Utc).AddTicks(4228), 1 },
                    { new Guid("bb682fc8-3bbc-4119-b07b-21eb609bf907"), 725.191778882948000m, false, new Guid("dbfa8ad9-8ce9-4e34-ab96-89495ccf0964"), "Rem a rem. Velit asperiores rem. Vitae quaerat qui. Vero ea magni beatae aliquid voluptas ut ratione.", new DateTime(2020, 10, 26, 16, 38, 12, 31, DateTimeKind.Utc).AddTicks(3334), 1 },
                    { new Guid("bf4f6e21-89cd-4198-bae0-b4646642f8b0"), 831.113089330778000m, false, new Guid("c0008290-6a8b-4dfb-8d2f-198bc8f28420"), "Ratione eius et quaerat doloremque placeat. Libero eveniet incidunt similique et magnam.", new DateTime(2016, 3, 3, 13, 48, 44, 781, DateTimeKind.Utc).AddTicks(9730), 1 },
                    { new Guid("bf9759b8-e35f-4559-bed1-80c250a9b5c9"), 284.320246568293000m, false, new Guid("27b6e593-824c-4ace-b846-3af9909b1f65"), "Doloremque magni cumque tempore dolore fugiat in ea alias. Aut ab quam qui repellendus numquam. Nihil ut autem doloribus eaque. Excepturi unde reiciendis quo omnis.", new DateTime(2016, 1, 15, 1, 53, 49, 914, DateTimeKind.Utc).AddTicks(7035), 1 },
                    { new Guid("bfcc031f-4397-48a3-b8a5-d54bddddfef6"), 763.095770926455000m, false, new Guid("1339ea5e-333b-431b-b9f7-46dcec82a275"), "Optio sunt impedit ipsam quam ab aperiam. Autem libero omnis delectus. Aut at est. Qui unde occaecati sunt.", new DateTime(2018, 12, 11, 23, 16, 34, 402, DateTimeKind.Utc).AddTicks(2664), 1 },
                    { new Guid("bfda5512-238b-4d0e-a1ae-2986bc1a13a9"), 130.319873180022000m, false, new Guid("57e7666c-e85d-47c5-8137-c5ed7d565cec"), "Ducimus rem quas ad laudantium delectus veritatis. Reprehenderit saepe omnis. Ullam dolorem quis eum nobis consequuntur voluptatem. Accusantium voluptatum omnis dicta eum sed atque sed.", new DateTime(2021, 8, 15, 6, 7, 59, 971, DateTimeKind.Utc).AddTicks(1086), 0 },
                    { new Guid("c0f597db-505b-4dba-9acd-c9498c3ca396"), 506.347019355115000m, false, new Guid("7fe7e445-5866-48d8-9e0f-cb2460103c01"), "Et quasi repellendus ipsum neque et ut ipsa aut itaque.", new DateTime(2022, 1, 19, 13, 28, 6, 503, DateTimeKind.Utc).AddTicks(2260), 0 },
                    { new Guid("c22e7a40-9883-4dea-83ae-949cf60004bb"), 833.002626580602000m, false, new Guid("8cc8a727-2c22-4d67-aaad-7a99a42ccb07"), "Quo aliquid architecto qui non. Eligendi et reiciendis vero recusandae eos laudantium et rem beatae.", new DateTime(2016, 5, 30, 8, 45, 14, 162, DateTimeKind.Utc).AddTicks(4477), 99 },
                    { new Guid("c24a778a-b0bc-410b-8332-2619f843531e"), 498.021374603386000m, false, new Guid("776ff3b6-36cd-4926-8d24-4a0ada93eaea"), "Quam quo autem velit. Et labore qui dolore ad sed rerum et. Repellat magnam fugit enim neque expedita molestiae sint et.", new DateTime(2017, 11, 26, 13, 58, 2, 743, DateTimeKind.Utc).AddTicks(4909), 0 },
                    { new Guid("c3ba05dc-c4a6-4997-b5e5-ce700c23fa88"), 838.709625229854000m, false, new Guid("ee804991-d117-4443-a038-67a602b22b8f"), "Quia sed eos nisi aut non nostrum nemo numquam. Culpa culpa quia voluptatibus est quis.", new DateTime(2020, 6, 16, 2, 46, 28, 457, DateTimeKind.Utc).AddTicks(1413), 99 },
                    { new Guid("c6d4a1e0-2f1b-4bdd-957a-ab67bcdc8899"), 195.673559858965000m, false, new Guid("c0008290-6a8b-4dfb-8d2f-198bc8f28420"), "Autem impedit dolores eum saepe non aut dolore.", new DateTime(2017, 6, 30, 11, 58, 47, 629, DateTimeKind.Utc).AddTicks(469), 99 },
                    { new Guid("c70ff6bf-eafe-4066-885d-392f7ef1d213"), 605.227115830884000m, false, new Guid("7fe7e445-5866-48d8-9e0f-cb2460103c01"), "A ut rem placeat cum at ut et qui dolore. Non iure consequuntur expedita culpa deleniti dolore ut ex sapiente. Voluptas quisquam et ea doloremque recusandae autem excepturi dignissimos. Ut eum ut deserunt possimus vero.", new DateTime(2013, 5, 26, 2, 37, 3, 290, DateTimeKind.Utc).AddTicks(7431), 1 },
                    { new Guid("c7ede49d-b8c4-4837-b882-7a853feb6f28"), 296.510697663223000m, false, new Guid("10765bc8-7a84-4fd7-af14-468a9a24d48c"), "Velit molestias dolore ullam laudantium et blanditiis veritatis consequuntur dolor. Sapiente repellendus eaque dolorem cum. Commodi eveniet non magni dolores.", new DateTime(2016, 8, 30, 12, 16, 23, 842, DateTimeKind.Utc).AddTicks(5580), 0 },
                    { new Guid("cb59e018-db64-47b3-8a84-f7405c7bb98e"), 443.507033624709000m, false, new Guid("1339ea5e-333b-431b-b9f7-46dcec82a275"), "Tempora perspiciatis iusto. Et nisi ad ducimus laboriosam quia. Sed quibusdam reiciendis est officiis dolor labore molestias pariatur. Explicabo sed animi repellendus aspernatur.", new DateTime(2021, 1, 9, 5, 4, 17, 483, DateTimeKind.Utc).AddTicks(1576), 0 },
                    { new Guid("cbf56d29-839e-4f1d-b3fa-880d721e4b97"), 175.913969243621000m, false, new Guid("293f8448-6306-44e1-b0d2-de6e56c05b6a"), "Eaque delectus dicta sed architecto in dolore accusantium.", new DateTime(2012, 9, 23, 1, 13, 33, 557, DateTimeKind.Utc).AddTicks(2862), 0 },
                    { new Guid("d0b26862-ec02-41da-b2f2-fef99b1ff735"), 479.789152759404000m, false, new Guid("c5ef00c0-f740-40ba-a2ec-f90600cd8587"), "Numquam autem hic dolor vel omnis. Nisi asperiores dolorem officia sequi accusamus doloribus minima soluta. Ut sit ut.", new DateTime(2017, 9, 13, 23, 2, 47, 355, DateTimeKind.Utc).AddTicks(8380), 1 },
                    { new Guid("d2bd3198-f22f-4e0c-a8dc-7a705971149c"), 991.24854052289000m, false, new Guid("c0008290-6a8b-4dfb-8d2f-198bc8f28420"), "Sapiente dolores quo cumque eum quibusdam et in. Asperiores natus numquam corporis repellat dolores quae vel. Atque molestiae esse.", new DateTime(2019, 1, 18, 13, 11, 11, 787, DateTimeKind.Utc).AddTicks(4218), 99 },
                    { new Guid("d3fd89d8-eaa9-4117-9d9d-a2f2b0f8c501"), 545.457109396666000m, false, new Guid("4a6c0db7-fa8b-4fa0-a332-47f50f255879"), "Nemo eum vel reprehenderit aut dolorem deserunt sit. Dignissimos aut ullam accusantium.", new DateTime(2012, 3, 7, 15, 42, 44, 930, DateTimeKind.Utc).AddTicks(9590), 99 },
                    { new Guid("d41d783a-ac89-4c34-99bb-03b035520b5f"), 790.387577459292000m, false, new Guid("c0008290-6a8b-4dfb-8d2f-198bc8f28420"), "Qui rerum quam sequi sunt temporibus sed. Ipsum similique ex. Sed distinctio eaque quis ad.", new DateTime(2014, 10, 13, 15, 11, 48, 279, DateTimeKind.Utc).AddTicks(3273), 0 },
                    { new Guid("d7f895ec-10bd-4739-b9fa-657247bd58d4"), 628.830659971998000m, false, new Guid("7fe7e445-5866-48d8-9e0f-cb2460103c01"), "Sed vel maxime. Molestiae sint voluptatem modi error.", new DateTime(2020, 5, 11, 9, 6, 27, 409, DateTimeKind.Utc).AddTicks(8570), 99 },
                    { new Guid("daf2b63c-4f7d-4326-bce8-8292158f0c3d"), 819.503921690979000m, false, new Guid("e04ee5ad-485f-459f-9913-56ff9495d6a1"), "Sed et ex temporibus voluptatum. At est non accusamus exercitationem fuga repellendus quasi eius commodi.", new DateTime(2021, 2, 22, 17, 16, 50, 980, DateTimeKind.Utc).AddTicks(4342), 99 },
                    { new Guid("db6625d8-4214-4073-a169-8fba74c2b8cb"), 126.752194441164000m, false, new Guid("4a6c0db7-fa8b-4fa0-a332-47f50f255879"), "Est nesciunt reiciendis optio. Necessitatibus sapiente eaque velit a nisi. Molestiae voluptatem nihil ipsam ex labore eveniet.", new DateTime(2019, 7, 17, 20, 28, 13, 379, DateTimeKind.Utc).AddTicks(150), 0 },
                    { new Guid("dba70491-52a8-46e1-95c2-a0b1a379ba54"), 995.716635242618000m, false, new Guid("8d4eb238-5f87-4849-af4c-de1ec6b76cae"), "Voluptatem fugiat tempore dolor et quam. Dolores esse cumque qui labore consequatur. Fugiat reiciendis sapiente minus nulla ut magnam quis placeat facilis. Eaque quibusdam illo dolorum aut mollitia autem sunt molestias corporis.", new DateTime(2013, 10, 1, 4, 54, 54, 495, DateTimeKind.Utc).AddTicks(6437), 99 },
                    { new Guid("dbbdcbf9-661b-4871-b022-d27bb5da4706"), 669.212026488606000m, false, new Guid("7fe7e445-5866-48d8-9e0f-cb2460103c01"), "Deserunt voluptatem exercitationem praesentium ut ullam maxime necessitatibus. Ullam est sunt. Natus hic voluptatem delectus quis voluptates ipsum dolor aspernatur. Expedita reiciendis a iusto incidunt quis accusantium id qui.", new DateTime(2015, 3, 14, 10, 7, 32, 703, DateTimeKind.Utc).AddTicks(765), 99 },
                    { new Guid("e040e2da-2e34-4c2f-9e51-29a61db64881"), 64.0117472084018000m, false, new Guid("776ff3b6-36cd-4926-8d24-4a0ada93eaea"), "Fugit quae aut et non in aut. Suscipit repellat nihil repellendus magni aperiam et non consequatur. Blanditiis ipsam est corporis tenetur.", new DateTime(2013, 11, 11, 0, 44, 49, 282, DateTimeKind.Utc).AddTicks(4063), 0 },
                    { new Guid("e0449c76-9320-40dd-b023-4381d1a64db5"), 801.409648695914000m, false, new Guid("1339ea5e-333b-431b-b9f7-46dcec82a275"), "Delectus repellat tenetur sint reprehenderit autem mollitia dolorem quisquam quia. In unde voluptas non quidem rerum voluptatum.", new DateTime(2015, 1, 2, 6, 30, 51, 629, DateTimeKind.Utc).AddTicks(4272), 1 },
                    { new Guid("e27ac6fe-0e6d-4dcf-96b0-2fe88cc08210"), 983.324977135314000m, false, new Guid("ee804991-d117-4443-a038-67a602b22b8f"), "Eos quibusdam et aspernatur qui dolorem eum illum nisi esse. Nemo non cum quo facilis.", new DateTime(2018, 3, 4, 19, 4, 48, 595, DateTimeKind.Utc).AddTicks(2835), 99 },
                    { new Guid("e297efa6-bb45-42c0-9118-c29936250d4f"), 480.210716734083000m, false, new Guid("ee804991-d117-4443-a038-67a602b22b8f"), "Explicabo iste id est cum porro est ut vitae.", new DateTime(2020, 8, 8, 7, 1, 38, 548, DateTimeKind.Utc).AddTicks(6741), 1 },
                    { new Guid("e35518e1-fdca-4b3d-96a0-b647a77b5b63"), 692.305275269556000m, false, new Guid("e04ee5ad-485f-459f-9913-56ff9495d6a1"), "Sed perferendis aperiam dignissimos deleniti.", new DateTime(2020, 4, 26, 17, 8, 13, 339, DateTimeKind.Utc).AddTicks(75), 99 },
                    { new Guid("ebfc6545-c076-4751-b675-50c670977fba"), 954.210415740528000m, false, new Guid("c5ef00c0-f740-40ba-a2ec-f90600cd8587"), "Eveniet qui accusamus est aut ipsa. Voluptas id in est soluta ipsum vitae quis soluta. Quisquam aliquid suscipit itaque fuga ullam non.", new DateTime(2019, 7, 17, 17, 9, 42, 402, DateTimeKind.Utc).AddTicks(69), 1 },
                    { new Guid("ed2bd19d-47e6-4586-8486-79e01f37fbc3"), 8.24237379510673000m, false, new Guid("e04ee5ad-485f-459f-9913-56ff9495d6a1"), "Consequatur temporibus eaque.", new DateTime(2014, 12, 15, 23, 26, 21, 596, DateTimeKind.Utc).AddTicks(6349), 99 },
                    { new Guid("ee491f20-2c07-4462-a060-2d102447312a"), 312.132600634633000m, false, new Guid("9d6b320e-7809-44c6-bb0f-621d94518a3c"), "Optio iste commodi quidem soluta illum est qui ea ipsa. Commodi ipsam ipsam. Aliquid debitis qui.", new DateTime(2014, 2, 28, 14, 35, 1, 769, DateTimeKind.Utc).AddTicks(8737), 0 },
                    { new Guid("ef328598-96b2-4bf7-9d49-9f5352d0bb80"), 564.753374330894000m, false, new Guid("10765bc8-7a84-4fd7-af14-468a9a24d48c"), "Est corrupti esse et dolore provident autem.", new DateTime(2019, 9, 10, 18, 54, 42, 408, DateTimeKind.Utc).AddTicks(5843), 99 },
                    { new Guid("ef65ca18-e269-4b43-8add-123d6c2c9f53"), 498.139805920058000m, false, new Guid("60033e04-f97b-4ed8-9104-3029eef5bdb8"), "Ea numquam ratione similique repudiandae eligendi. Maxime ut alias minima rerum expedita nemo. Labore quis vel laborum ut earum et labore quis nostrum.", new DateTime(2020, 2, 29, 18, 43, 34, 107, DateTimeKind.Utc).AddTicks(7850), 0 },
                    { new Guid("efebca08-4f54-4bbf-becb-aeec8bc8268c"), 231.403186130106000m, false, new Guid("776ff3b6-36cd-4926-8d24-4a0ada93eaea"), "Consequatur debitis iusto enim. Blanditiis quis et nihil quas ducimus eveniet. Ut consequatur tempora facilis ut optio libero laboriosam. Enim molestiae voluptatem delectus perspiciatis qui tenetur recusandae minima.", new DateTime(2017, 4, 14, 21, 38, 42, 303, DateTimeKind.Utc).AddTicks(1607), 0 },
                    { new Guid("f1f09319-ebb9-41ac-9600-a404db58a521"), 984.051594926259000m, false, new Guid("8cc8a727-2c22-4d67-aaad-7a99a42ccb07"), "Eaque repellat molestiae sunt aperiam ipsam inventore quod omnis. Sit voluptas quod.", new DateTime(2014, 5, 15, 9, 47, 43, 210, DateTimeKind.Utc).AddTicks(101), 0 },
                    { new Guid("f3a2d4ee-444a-4ec1-869b-0c5a548fa940"), 248.287083815608000m, false, new Guid("1339ea5e-333b-431b-b9f7-46dcec82a275"), "Nisi sed eum. Ut voluptatibus at a aliquid earum quaerat voluptas ut officiis.", new DateTime(2017, 5, 24, 7, 51, 7, 982, DateTimeKind.Utc).AddTicks(1189), 99 },
                    { new Guid("f42c3274-9008-4fe4-bd9e-222ca6549329"), 410.131849125943000m, false, new Guid("8cc8a727-2c22-4d67-aaad-7a99a42ccb07"), "Est est sed distinctio reprehenderit molestiae officia soluta.", new DateTime(2020, 3, 16, 21, 9, 39, 108, DateTimeKind.Utc).AddTicks(6745), 99 },
                    { new Guid("f4367671-e303-4172-8338-c8d795dee3e2"), 579.06348272658000m, false, new Guid("27b6e593-824c-4ace-b846-3af9909b1f65"), "Totam ut illo eum dolorem ducimus quo.", new DateTime(2014, 9, 22, 19, 53, 17, 977, DateTimeKind.Utc).AddTicks(1971), 1 },
                    { new Guid("f60e8814-f1f1-4d5c-9478-5b9501de46f8"), 325.362962148315000m, false, new Guid("27b6e593-824c-4ace-b846-3af9909b1f65"), "Dolor rerum quia necessitatibus adipisci veritatis. Possimus earum ullam architecto doloribus ex.", new DateTime(2020, 3, 11, 11, 38, 52, 426, DateTimeKind.Utc).AddTicks(5554), 0 },
                    { new Guid("f6a9f7c1-dbfe-4b51-8d07-2c17456a3334"), 463.965690115993000m, false, new Guid("f996ca10-5c5f-4493-ab9c-939766ea46ec"), "Sit ipsam est perferendis adipisci corporis autem iusto. Dolore officia eius unde at illum eum velit voluptatem.", new DateTime(2013, 5, 3, 18, 41, 46, 210, DateTimeKind.Utc).AddTicks(1030), 1 },
                    { new Guid("f7feed8b-2cf8-40ff-854f-058c663885f7"), 895.72653104416000m, false, new Guid("c5ef00c0-f740-40ba-a2ec-f90600cd8587"), "Eum facere iusto.", new DateTime(2018, 5, 4, 20, 49, 13, 86, DateTimeKind.Utc).AddTicks(8257), 99 },
                    { new Guid("f88ea68d-0bc0-408e-a6fa-f5c4ca53045d"), 184.890904710959000m, false, new Guid("776ff3b6-36cd-4926-8d24-4a0ada93eaea"), "Accusamus amet fuga.", new DateTime(2012, 7, 29, 12, 15, 53, 797, DateTimeKind.Utc).AddTicks(9451), 99 },
                    { new Guid("f99ac2b0-074b-4a96-91e4-c0d701da5a7c"), 341.656337395578000m, false, new Guid("1339ea5e-333b-431b-b9f7-46dcec82a275"), "Necessitatibus dolorum ut. Iste et provident. Dicta qui molestiae pariatur aut veritatis vero dolorem eum quia.", new DateTime(2013, 1, 25, 2, 12, 2, 608, DateTimeKind.Utc).AddTicks(3389), 1 },
                    { new Guid("f9c84117-e0ea-46f4-89db-123d0d10c0d0"), 658.426981804244000m, false, new Guid("e04ee5ad-485f-459f-9913-56ff9495d6a1"), "Optio et corrupti hic maxime consequatur velit nihil in. Animi incidunt ut temporibus.", new DateTime(2019, 3, 16, 12, 33, 55, 304, DateTimeKind.Utc).AddTicks(5750), 99 },
                    { new Guid("f9fcd7e6-52af-4a9f-ad1b-94b04de78c30"), 432.168496371178000m, false, new Guid("a4856544-8f7d-49d1-bc75-bfde8593a6fd"), "Maxime mollitia assumenda at consequuntur aut ipsam. Aliquam magni molestias in. Voluptatum est repudiandae esse voluptatem ut nisi consectetur consequatur.", new DateTime(2012, 10, 9, 23, 30, 54, 886, DateTimeKind.Utc).AddTicks(7388), 1 },
                    { new Guid("fa276c49-7762-4bef-9624-1502a23a2edb"), 953.418266862839000m, false, new Guid("1339ea5e-333b-431b-b9f7-46dcec82a275"), "Quisquam officiis nemo dolor hic. Mollitia tempora vel. Libero minus architecto distinctio sed est dolores saepe quia.", new DateTime(2021, 5, 23, 0, 8, 32, 710, DateTimeKind.Utc).AddTicks(8319), 1 },
                    { new Guid("fabb5631-00cf-43c7-98a5-a73cbf5fc6d8"), 981.373469641304000m, false, new Guid("dbfa8ad9-8ce9-4e34-ab96-89495ccf0964"), "Veritatis aut voluptas minima. Exercitationem ex enim magnam quo molestias provident impedit. Incidunt illo sequi vitae voluptas qui corporis soluta eum. Est labore qui.", new DateTime(2016, 5, 26, 20, 26, 15, 798, DateTimeKind.Utc).AddTicks(6427), 99 },
                    { new Guid("fcfa1dff-d84b-418c-8ca3-4531c65df8f7"), 582.502250789969000m, false, new Guid("27b6e593-824c-4ace-b846-3af9909b1f65"), "Voluptas eos alias consectetur nulla laudantium ut quia. Qui occaecati rerum et consectetur reprehenderit est sint.", new DateTime(2014, 10, 29, 18, 46, 32, 819, DateTimeKind.Utc).AddTicks(5615), 0 },
                    { new Guid("fe1a44ad-9e46-462e-b34e-2401592f97f4"), 646.91926693052000m, false, new Guid("9d6b320e-7809-44c6-bb0f-621d94518a3c"), "Nesciunt et magnam cupiditate esse. Ab et ut qui. Ducimus nobis dolorum. Suscipit placeat aperiam ipsam nobis.", new DateTime(2019, 4, 13, 13, 46, 33, 976, DateTimeKind.Utc).AddTicks(452), 99 },
                    { new Guid("fe323db2-4da6-4260-8fde-40b794cfb845"), 368.806008893189000m, false, new Guid("c0008290-6a8b-4dfb-8d2f-198bc8f28420"), "Et autem quis delectus ut a quis sequi ullam. Consequatur vitae quas. Ab ea deleniti suscipit. Fugiat deleniti exercitationem omnis hic fuga ut.", new DateTime(2014, 5, 27, 13, 43, 54, 179, DateTimeKind.Utc).AddTicks(1145), 99 }
                });

            migrationBuilder.InsertData(
                table: "SubscriptionsPaid",
                columns: new[] { "MemberId", "Year", "April", "August", "December", "February", "January", "July", "June", "March", "May", "November", "October", "September" },
                values: new object[,]
                {
                    { new Guid("1339ea5e-333b-431b-b9f7-46dcec82a275"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("1339ea5e-333b-431b-b9f7-46dcec82a275"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("1339ea5e-333b-431b-b9f7-46dcec82a275"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("1339ea5e-333b-431b-b9f7-46dcec82a275"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("27b6e593-824c-4ace-b846-3af9909b1f65"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("293f8448-6306-44e1-b0d2-de6e56c05b6a"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("4a6c0db7-fa8b-4fa0-a332-47f50f255879"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("4a6c0db7-fa8b-4fa0-a332-47f50f255879"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("57e7666c-e85d-47c5-8137-c5ed7d565cec"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("57e7666c-e85d-47c5-8137-c5ed7d565cec"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("57e7666c-e85d-47c5-8137-c5ed7d565cec"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("57e7666c-e85d-47c5-8137-c5ed7d565cec"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("60033e04-f97b-4ed8-9104-3029eef5bdb8"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("60033e04-f97b-4ed8-9104-3029eef5bdb8"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("60033e04-f97b-4ed8-9104-3029eef5bdb8"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("60033e04-f97b-4ed8-9104-3029eef5bdb8"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("60033e04-f97b-4ed8-9104-3029eef5bdb8"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("60033e04-f97b-4ed8-9104-3029eef5bdb8"), 2020, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("60033e04-f97b-4ed8-9104-3029eef5bdb8"), 2021, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("776ff3b6-36cd-4926-8d24-4a0ada93eaea"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("776ff3b6-36cd-4926-8d24-4a0ada93eaea"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("776ff3b6-36cd-4926-8d24-4a0ada93eaea"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("776ff3b6-36cd-4926-8d24-4a0ada93eaea"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("776ff3b6-36cd-4926-8d24-4a0ada93eaea"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("776ff3b6-36cd-4926-8d24-4a0ada93eaea"), 2020, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("7fe7e445-5866-48d8-9e0f-cb2460103c01"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("7fe7e445-5866-48d8-9e0f-cb2460103c01"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("7fe7e445-5866-48d8-9e0f-cb2460103c01"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("7fe7e445-5866-48d8-9e0f-cb2460103c01"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("8cc8a727-2c22-4d67-aaad-7a99a42ccb07"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("8d4eb238-5f87-4849-af4c-de1ec6b76cae"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("a4856544-8f7d-49d1-bc75-bfde8593a6fd"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("c0008290-6a8b-4dfb-8d2f-198bc8f28420"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("c0008290-6a8b-4dfb-8d2f-198bc8f28420"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("c0008290-6a8b-4dfb-8d2f-198bc8f28420"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("c0008290-6a8b-4dfb-8d2f-198bc8f28420"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("c0008290-6a8b-4dfb-8d2f-198bc8f28420"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("c5ef00c0-f740-40ba-a2ec-f90600cd8587"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("c5ef00c0-f740-40ba-a2ec-f90600cd8587"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("c5ef00c0-f740-40ba-a2ec-f90600cd8587"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("c5ef00c0-f740-40ba-a2ec-f90600cd8587"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("dbfa8ad9-8ce9-4e34-ab96-89495ccf0964"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("dbfa8ad9-8ce9-4e34-ab96-89495ccf0964"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("dbfa8ad9-8ce9-4e34-ab96-89495ccf0964"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("dbfa8ad9-8ce9-4e34-ab96-89495ccf0964"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("dbfa8ad9-8ce9-4e34-ab96-89495ccf0964"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("dbfa8ad9-8ce9-4e34-ab96-89495ccf0964"), 2020, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("dbfa8ad9-8ce9-4e34-ab96-89495ccf0964"), 2021, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("e04ee5ad-485f-459f-9913-56ff9495d6a1"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("e04ee5ad-485f-459f-9913-56ff9495d6a1"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("e04ee5ad-485f-459f-9913-56ff9495d6a1"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("e04ee5ad-485f-459f-9913-56ff9495d6a1"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("e04ee5ad-485f-459f-9913-56ff9495d6a1"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("e07a62f4-6ddd-4be4-b983-4902d2aabca3"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("e07a62f4-6ddd-4be4-b983-4902d2aabca3"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("ee804991-d117-4443-a038-67a602b22b8f"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("ee804991-d117-4443-a038-67a602b22b8f"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("ee804991-d117-4443-a038-67a602b22b8f"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("ee804991-d117-4443-a038-67a602b22b8f"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("ee804991-d117-4443-a038-67a602b22b8f"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("ee804991-d117-4443-a038-67a602b22b8f"), 2020, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("ee804991-d117-4443-a038-67a602b22b8f"), 2021, true, true, true, true, true, true, true, true, true, true, true, true }
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
