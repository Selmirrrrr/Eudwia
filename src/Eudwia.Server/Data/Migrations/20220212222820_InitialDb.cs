using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Eudwia.Server.Data.Migrations
{
    public partial class InitialDb : Migration
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
                    { new Guid("031addae-12c7-45bc-ad72-837bcbcbe949"), 0, new DateOnly(1953, 6, 1), "Le Havre", "e50db121-191e-4576-887f-7353acb89559", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Gui70@hotmail.fr", false, "Alphonse", "4652", 0, "Meyer", false, null, new DateOnly(2015, 7, 20), null, null, null, "0281723829", false, null, "VD", "493 Place de Provence", "Apt. 701", false, null, "88172" },
                    { new Guid("03205baf-c226-4094-94a2-6bc60a94cc5d"), 0, new DateOnly(1999, 6, 18), "Saint-Quentin", "942cdcd6-5b3b-4a37-bdec-3cb438fbf52b", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Gui70@hotmail.fr", false, "Sylvestre", "407", 2, "Sanchez", false, null, new DateOnly(2017, 2, 8), null, null, null, "0281723829", false, null, "VD", "94 Allée Oberkampf", "Apt. 092", false, null, "05410" },
                    { new Guid("19c2dac9-f6df-445a-92a0-5028b785cdf8"), 0, new DateOnly(1974, 3, 8), "Le Havre", "b540a5d7-b12e-4c46-97c9-f359c189941c", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Gui70@hotmail.fr", false, "Adeline", "215", 1, "Vincent", false, null, new DateOnly(2020, 10, 10), null, null, null, "0281723829", false, null, "VD", "0 Boulevard de l'Abbaye", "Apt. 853", false, null, "10423" },
                    { new Guid("1e556685-dcaf-4ba7-a8da-707b17314922"), 0, new DateOnly(1989, 10, 1), "Bourges", "2fe9db30-a8d8-4656-bade-c8dcf111d4e5", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Gui70@hotmail.fr", false, "Annonciade", "69", 2, "Blanc", false, null, new DateOnly(2019, 1, 2), null, null, null, "0281723829", false, null, "VD", "25 Rue des Grands Augustins", "Apt. 057", false, null, "53419" },
                    { new Guid("266ff167-15bf-4dc2-b9b0-c5af915c143e"), 0, new DateOnly(1973, 3, 25), "Versailles", "49631677-5f6a-4ada-bb94-0313657cd87f", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Gui70@hotmail.fr", false, "Séverine", "35", 1, "Morel", false, null, new DateOnly(2015, 1, 9), null, null, null, "0281723829", false, null, "VD", "3727 Place de Presbourg", "0 étage", false, null, "85345" },
                    { new Guid("2763f4ef-266b-42e5-9d5c-712617d145f7"), 0, new DateOnly(1974, 7, 21), "Beauvais", "b2e6821c-d420-40e8-9c98-d43513a28a6d", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Gui70@hotmail.fr", false, "Guillaume", "01", 0, "Michel", false, null, new DateOnly(2015, 3, 24), null, null, null, "0281723829", false, null, "VD", "8 Impasse du Chat-qui-Pêche", "Apt. 879", false, null, "58664" },
                    { new Guid("2eff2c74-de12-4b27-85a2-1d8ad47c50d8"), 0, new DateOnly(1997, 4, 3), "Sarcelles", "eed34824-721a-4e0d-984b-bfa333571a77", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Gui70@hotmail.fr", false, "Olive", "4", 1, "Clement", false, null, new DateOnly(2021, 2, 5), null, null, null, "0281723829", false, null, "VD", "4 Boulevard de Seine", "Apt. 219", false, null, "62776" },
                    { new Guid("3f0b5db8-a2b4-4607-b7a1-3c277651d860"), 0, new DateOnly(1964, 10, 30), "Cholet", "4b3a3da4-7ea3-4b67-be40-76446c132c34", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Gui70@hotmail.fr", false, "Émeline", "22", 0, "Breton", false, null, new DateOnly(2012, 8, 31), null, null, null, "0281723829", false, null, "VD", "7 Voie du Bac", "Apt. 624", false, null, "75932" },
                    { new Guid("436f7a1d-cc9e-476f-8dd1-f38e9c870ab9"), 0, new DateOnly(1998, 9, 24), "Grenoble", "8beb3b2d-c3bc-4010-8688-4f59c1859266", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Gui70@hotmail.fr", false, "Alexis", "497", 1, "Meyer", false, null, new DateOnly(2018, 2, 26), null, null, null, "0281723829", false, null, "VD", "1 Place Pastourelle", "Apt. 807", false, null, "76269" },
                    { new Guid("43752539-10d2-435c-8e68-6e8fd0e53c12"), 0, new DateOnly(1958, 1, 7), "La Rochelle", "da507152-8a8e-4ca0-9d49-4271065a366e", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Gui70@hotmail.fr", false, "Anthelmette", "4320", 0, "Leclerc", false, null, new DateOnly(2016, 8, 11), null, null, null, "0281723829", false, null, "VD", "79 Voie Joubert", "Apt. 230", false, null, "66021" },
                    { new Guid("45827aeb-0b3d-4a6b-9f41-c53eba1c6cbc"), 0, new DateOnly(1965, 5, 10), "Brest", "c7c2acc4-b90d-4cbf-8574-eaf97fd07597", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Gui70@hotmail.fr", false, "Archange", "8", 2, "Mercier", false, null, new DateOnly(2012, 12, 20), null, null, null, "0281723829", false, null, "VD", "802 Passage d'Abbeville", "6 étage", false, null, "09582" },
                    { new Guid("583be124-ed68-4a81-b641-4dd7fba8bdd0"), 0, new DateOnly(1958, 11, 9), "Saint-Maur-des-Fossés", "a4d0bdea-39bb-4de1-80c6-465ff205464a", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Gui70@hotmail.fr", false, "Virginie", "521", 1, "Fournier", false, null, new DateOnly(2018, 4, 1), null, null, null, "0281723829", false, null, "VD", "6 Place du Bac", "Apt. 862", false, null, "13331" },
                    { new Guid("61fafe75-8063-4297-b42f-523c53db27db"), 0, new DateOnly(1952, 7, 4), "Limoges", "06d785ad-be59-4a84-936b-c28e85a6118d", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Gui70@hotmail.fr", false, "Emmanuelle", "1", 1, "Pierre", false, null, new DateOnly(2016, 4, 9), null, null, null, "0281723829", false, null, "VD", "5 Place Bonaparte", "Apt. 189", false, null, "21624" },
                    { new Guid("892dd3cc-afc5-44ee-9c98-e08577c51e3c"), 0, new DateOnly(1987, 3, 2), "Colmar", "846bdaa2-7bd1-4f5e-be57-f8a883d28d37", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Gui70@hotmail.fr", false, "Aymonde", "5", 2, "Olivier", false, null, new DateOnly(2014, 10, 10), null, null, null, "0281723829", false, null, "VD", "8781 Place du Havre", "9 étage", false, null, "16648" },
                    { new Guid("b80fa2ba-d920-4153-bff5-344f9cef9e6d"), 0, new DateOnly(1985, 2, 5), "Aix-en-Provence", "7a808b9f-d8d3-4b16-8dc8-08a296e38dd1", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Gui70@hotmail.fr", false, "Oury", "787", 1, "Poirier", false, null, new DateOnly(2014, 10, 12), null, null, null, "0281723829", false, null, "VD", "9 Impasse du Havre", "6 étage", false, null, "97388" },
                    { new Guid("bf559038-abfa-4ee2-ad60-0cd92ff54447"), 0, new DateOnly(1952, 6, 3), "Levallois-Perret", "f4c674ed-650f-4038-836e-091df6781c8b", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Gui70@hotmail.fr", false, "Romane", "19", 2, "Leclercq", false, null, new DateOnly(2016, 11, 20), null, null, null, "0281723829", false, null, "VD", "1 Impasse du Faubourg-Saint-Denis", "9 étage", false, null, "77829" },
                    { new Guid("c1a480a4-7835-4156-8b5c-a0b41663c36b"), 0, new DateOnly(1978, 12, 12), "Asnières-sur-Seine", "5a2b1642-08c5-4b78-a616-330ed52fc5eb", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Gui70@hotmail.fr", false, "Ascelin", "7195", 2, "Garnier", false, null, new DateOnly(2012, 7, 21), null, null, null, "0281723829", false, null, "VD", "06 Passage Marcadet", "Apt. 164", false, null, "39677" },
                    { new Guid("ce962a88-ee32-49bc-b2e2-8ccb5c53dcaf"), 0, new DateOnly(1989, 7, 12), "Levallois-Perret", "7fb4f546-6c30-4974-9c4e-b4ac805b8ba7", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Gui70@hotmail.fr", false, "Amante", "71", 2, "Huet", false, null, new DateOnly(2014, 3, 1), null, null, null, "0281723829", false, null, "VD", "55 Quai Charlemagne", "2 étage", false, null, "71825" },
                    { new Guid("edbda49f-0a72-4a07-9ce0-cccfda5c6e7e"), 0, new DateOnly(1958, 3, 1), "Béziers", "66c8739f-ea0f-4955-a709-6f5ecb010d8c", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Gui70@hotmail.fr", false, "Jade", "35", 2, "Lambert", false, null, new DateOnly(2013, 11, 6), null, null, null, "0281723829", false, null, "VD", "8912 Rue des Saussaies", "0 étage", false, null, "52574" },
                    { new Guid("fe265cbe-a3ca-449b-999a-95a48da566ab"), 0, new DateOnly(1961, 11, 23), "Saint-Nazaire", "73f207fb-cc27-483a-a0de-40e3fb97826b", new Guid("9bc1f1a9-7696-42e4-89aa-c93800704582"), "Gui70@hotmail.fr", false, "Childebert", "25", 0, "Vincent", false, null, new DateOnly(2014, 2, 24), null, null, null, "0281723829", false, null, "VD", "6453 Quai Saint-Jacques", "0 étage", false, null, "25359" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "IsDeleted", "MemberId", "Note", "PaymentDate", "PaymentType" },
                values: new object[,]
                {
                    { new Guid("00fb3532-a775-453b-8ce9-1d4846dbbd25"), 536.848757507751000m, false, new Guid("fe265cbe-a3ca-449b-999a-95a48da566ab"), "Voluptas qui et unde nam ex qui consectetur.", new DateTime(2019, 6, 4, 7, 50, 41, 114, DateTimeKind.Utc).AddTicks(2913), 0 },
                    { new Guid("036527e6-df65-4424-ac01-a80f1a22696a"), 823.70876062337000m, false, new Guid("bf559038-abfa-4ee2-ad60-0cd92ff54447"), "Nihil vitae nisi quo autem aliquam. Debitis aut ut ratione placeat dolores eos. Modi recusandae sapiente et. Sunt et et reprehenderit qui debitis dolorum nisi blanditiis ea.", new DateTime(2014, 3, 5, 4, 50, 1, 411, DateTimeKind.Utc).AddTicks(740), 99 },
                    { new Guid("085295cc-f8c7-4fb7-ab70-6759598dda41"), 844.59437252581000m, false, new Guid("61fafe75-8063-4297-b42f-523c53db27db"), "Sapiente ea eum autem repellat reiciendis. Voluptatibus vitae alias reprehenderit ut qui. Ipsum explicabo fuga consequatur laborum. Quia rerum sit qui dolor impedit cumque.", new DateTime(2014, 9, 24, 22, 59, 54, 696, DateTimeKind.Utc).AddTicks(8268), 0 },
                    { new Guid("086795e3-c5a3-443f-825a-3ac0cdb22fa3"), 406.227473568823000m, false, new Guid("fe265cbe-a3ca-449b-999a-95a48da566ab"), "Iusto impedit omnis iusto quam aut magni sint delectus dicta. Beatae ea adipisci ipsa voluptatem in qui accusamus commodi.", new DateTime(2019, 6, 21, 23, 4, 10, 382, DateTimeKind.Utc).AddTicks(7507), 1 },
                    { new Guid("08d27c84-a99b-4952-a171-10fbc56f1142"), 757.877539463462000m, false, new Guid("19c2dac9-f6df-445a-92a0-5028b785cdf8"), "Rerum in necessitatibus. Et et repellat adipisci minus molestiae inventore provident nisi. Modi pariatur qui quaerat assumenda quia dolores animi cumque optio.", new DateTime(2018, 4, 17, 14, 5, 11, 323, DateTimeKind.Utc).AddTicks(2615), 0 },
                    { new Guid("0945ba96-916c-418a-9a0b-b4d2a16270c0"), 765.762093838818000m, false, new Guid("c1a480a4-7835-4156-8b5c-a0b41663c36b"), "Commodi minima enim id. Beatae eum voluptates necessitatibus porro. Impedit aliquid tempora. Voluptatibus tenetur placeat labore amet qui inventore qui incidunt.", new DateTime(2021, 9, 5, 14, 49, 41, 463, DateTimeKind.Utc).AddTicks(6434), 0 },
                    { new Guid("0aa2cae6-1238-4307-9307-2aa777c3d0c6"), 871.037321481393000m, false, new Guid("ce962a88-ee32-49bc-b2e2-8ccb5c53dcaf"), "Culpa beatae sunt praesentium laboriosam nam et.", new DateTime(2019, 1, 13, 7, 27, 55, 327, DateTimeKind.Utc).AddTicks(4144), 0 },
                    { new Guid("0c453910-b8b8-4071-a163-90780e686c5c"), 139.266917314822000m, false, new Guid("2763f4ef-266b-42e5-9d5c-712617d145f7"), "Ex sint et ut laborum. Ea est et. Tempora aut incidunt et laudantium et voluptatem et.", new DateTime(2012, 8, 26, 6, 21, 2, 427, DateTimeKind.Utc).AddTicks(2119), 1 },
                    { new Guid("0cd7ea6d-1231-4a1e-8d9c-030da73b8033"), 430.561618611745000m, false, new Guid("2eff2c74-de12-4b27-85a2-1d8ad47c50d8"), "Non incidunt enim rerum natus et quisquam porro et et. Libero dolor accusamus deleniti et est et inventore est.", new DateTime(2021, 7, 29, 16, 43, 35, 938, DateTimeKind.Utc).AddTicks(2553), 1 },
                    { new Guid("0d97f4ee-b73f-4b32-9bc4-2145d37edfb7"), 94.6392505280344000m, false, new Guid("3f0b5db8-a2b4-4607-b7a1-3c277651d860"), "Adipisci non nulla explicabo. Mollitia hic quasi iste possimus minus. Enim et perspiciatis ipsa nulla vitae sequi aut nulla.", new DateTime(2015, 1, 4, 16, 32, 51, 556, DateTimeKind.Utc).AddTicks(9383), 1 },
                    { new Guid("0da9ef61-e803-43c4-9cf4-8d3dca465bbf"), 767.366745748812000m, false, new Guid("fe265cbe-a3ca-449b-999a-95a48da566ab"), "Adipisci modi et doloremque. Consequatur consectetur et.", new DateTime(2015, 7, 27, 3, 48, 23, 334, DateTimeKind.Utc).AddTicks(1433), 99 },
                    { new Guid("0dc03719-38f6-4586-91ff-4d25c387b982"), 453.280056882927000m, false, new Guid("1e556685-dcaf-4ba7-a8da-707b17314922"), "Enim quia et illum. Enim mollitia doloremque aut. Ad sunt quidem et et deleniti. Minus perspiciatis consectetur et numquam a rem.", new DateTime(2021, 8, 30, 1, 3, 53, 66, DateTimeKind.Utc).AddTicks(9245), 1 },
                    { new Guid("0e541fe0-637f-4d4a-8c44-96570d19785b"), 928.571516352895000m, false, new Guid("edbda49f-0a72-4a07-9ce0-cccfda5c6e7e"), "Eos rerum sit quaerat aut. Eius aspernatur quaerat excepturi occaecati exercitationem sed quod. Qui vel facere cum. Facere recusandae asperiores explicabo sapiente provident quod ad aut.", new DateTime(2014, 2, 13, 11, 33, 48, 75, DateTimeKind.Utc).AddTicks(6994), 1 },
                    { new Guid("10585105-bd20-428c-a121-ca203622b82b"), 968.589809534875000m, false, new Guid("19c2dac9-f6df-445a-92a0-5028b785cdf8"), "Dolores voluptates perferendis nemo animi sed in itaque qui.", new DateTime(2012, 7, 8, 4, 21, 28, 444, DateTimeKind.Utc).AddTicks(2881), 0 },
                    { new Guid("144224b6-cc15-48a0-a550-87669f579a7e"), 159.652291853174000m, false, new Guid("2eff2c74-de12-4b27-85a2-1d8ad47c50d8"), "Iste et nemo. Consectetur magni corporis cum. Inventore explicabo nisi quia magni necessitatibus est dolore culpa. Quaerat blanditiis non sint dolores dolorem et ut.", new DateTime(2019, 5, 12, 23, 21, 15, 56, DateTimeKind.Utc).AddTicks(4945), 99 },
                    { new Guid("173055e8-c495-4bb3-99a8-4626ecd7b86b"), 79.7449374463752000m, false, new Guid("583be124-ed68-4a81-b641-4dd7fba8bdd0"), "Voluptatem itaque dolor at est voluptatem qui id vitae deleniti. Quis molestiae eos dolor aut porro enim. Eligendi incidunt aliquid consequatur quasi aut ut natus quisquam voluptatem.", new DateTime(2015, 9, 2, 2, 45, 36, 800, DateTimeKind.Utc).AddTicks(1103), 0 },
                    { new Guid("17cb5181-df0e-4547-974e-a1ba939cdcd9"), 384.451353140947000m, false, new Guid("c1a480a4-7835-4156-8b5c-a0b41663c36b"), "Tempore possimus explicabo enim corporis sit quia alias.", new DateTime(2017, 9, 14, 9, 17, 54, 926, DateTimeKind.Utc).AddTicks(4399), 99 },
                    { new Guid("18043985-1902-403b-b18e-1e7579ac99ee"), 879.490027690227000m, false, new Guid("ce962a88-ee32-49bc-b2e2-8ccb5c53dcaf"), "Molestias in sunt ea fuga. Dolorem et veniam rerum quae.", new DateTime(2014, 6, 25, 17, 33, 5, 805, DateTimeKind.Utc).AddTicks(8860), 1 },
                    { new Guid("19db6b6c-caab-4954-9287-cb1d6f026505"), 104.806684041892000m, false, new Guid("3f0b5db8-a2b4-4607-b7a1-3c277651d860"), "Quae voluptatum corporis rerum id ea voluptatem ipsa. Architecto quia eius quae architecto consequatur voluptatem repudiandae omnis blanditiis. Quo veritatis voluptatem reprehenderit cumque molestiae. Doloremque esse voluptatum quo.", new DateTime(2012, 9, 11, 21, 22, 45, 736, DateTimeKind.Utc).AddTicks(6986), 0 },
                    { new Guid("1b385ac5-3eaf-4e60-942b-da837341c65a"), 41.7046705654609000m, false, new Guid("bf559038-abfa-4ee2-ad60-0cd92ff54447"), "Deleniti quisquam facere. Ipsum et provident vel inventore et quam impedit maxime sunt. Aut dolorem mollitia voluptatem et fugiat.", new DateTime(2017, 12, 7, 12, 9, 47, 807, DateTimeKind.Utc).AddTicks(2094), 1 },
                    { new Guid("1b43ab74-f337-44c5-984e-443372faeac6"), 270.215346660164000m, false, new Guid("2eff2c74-de12-4b27-85a2-1d8ad47c50d8"), "Nemo et qui asperiores natus. Laboriosam excepturi alias porro in laborum eligendi. Molestias sunt porro eos sed quaerat aliquid ut aut vero. Soluta harum voluptas illo vel voluptas accusamus sit.", new DateTime(2017, 9, 14, 3, 58, 24, 661, DateTimeKind.Utc).AddTicks(2749), 1 },
                    { new Guid("1babb9db-d418-41da-82d4-bffe92b6c860"), 509.647352534461000m, false, new Guid("03205baf-c226-4094-94a2-6bc60a94cc5d"), "Mollitia eius tempora. Eligendi consectetur qui labore quia modi voluptas quidem recusandae. Eveniet aut laboriosam aut minima dolores dicta.", new DateTime(2016, 7, 22, 8, 55, 54, 702, DateTimeKind.Utc).AddTicks(3496), 99 },
                    { new Guid("1bca688e-49bc-485a-8150-27588ec20a1a"), 332.968929485204000m, false, new Guid("edbda49f-0a72-4a07-9ce0-cccfda5c6e7e"), "Temporibus perspiciatis eum exercitationem corrupti.", new DateTime(2015, 5, 3, 6, 20, 21, 199, DateTimeKind.Utc).AddTicks(8580), 99 },
                    { new Guid("1cb53720-3578-47c4-9c50-93703ff4822c"), 248.59501135834000m, false, new Guid("2763f4ef-266b-42e5-9d5c-712617d145f7"), "Vel autem amet magni sapiente quis sint. Exercitationem nostrum repellat iusto fugit dignissimos. Quibusdam aliquid voluptas debitis.", new DateTime(2021, 3, 10, 16, 0, 3, 7, DateTimeKind.Utc).AddTicks(7044), 1 },
                    { new Guid("1e3ec6d6-2be4-4d5b-b4ff-bb2ca7248ecc"), 845.43945233654000m, false, new Guid("b80fa2ba-d920-4153-bff5-344f9cef9e6d"), "Odio quae laborum fugit laudantium vel ex ut nesciunt ut. Dolores perspiciatis ut consequatur numquam eveniet rerum adipisci. Deleniti ipsa itaque in non. Amet fugit autem sit in necessitatibus eaque voluptates aspernatur accusamus.", new DateTime(2018, 12, 15, 3, 39, 30, 995, DateTimeKind.Utc).AddTicks(3630), 99 },
                    { new Guid("205899cc-caac-4662-be42-a515e12f5ee2"), 659.822761820888000m, false, new Guid("45827aeb-0b3d-4a6b-9f41-c53eba1c6cbc"), "Quo officiis ut laudantium maxime laboriosam quia.", new DateTime(2020, 4, 24, 3, 30, 2, 434, DateTimeKind.Utc).AddTicks(8841), 0 },
                    { new Guid("21a78d4e-9bdd-4a4f-b644-4100384eb94a"), 689.817105809498000m, false, new Guid("3f0b5db8-a2b4-4607-b7a1-3c277651d860"), "Quasi asperiores expedita iste quia qui.", new DateTime(2015, 11, 6, 11, 59, 31, 129, DateTimeKind.Utc).AddTicks(7838), 99 },
                    { new Guid("221bd9cb-f333-4702-9389-81fd4dbc7778"), 678.439124312817000m, false, new Guid("031addae-12c7-45bc-ad72-837bcbcbe949"), "Rerum neque distinctio voluptatem sint inventore ducimus magni sunt.", new DateTime(2015, 10, 8, 2, 31, 25, 52, DateTimeKind.Utc).AddTicks(1509), 1 },
                    { new Guid("22ccfcb7-0e51-4392-becc-ab300ed0f892"), 621.954905922686000m, false, new Guid("ce962a88-ee32-49bc-b2e2-8ccb5c53dcaf"), "Atque nemo quos perferendis magnam qui ullam dolores nihil consequuntur. At dignissimos nihil alias dicta. Mollitia aut quos omnis magni accusantium ut sed asperiores consectetur.", new DateTime(2018, 1, 5, 16, 35, 54, 684, DateTimeKind.Utc).AddTicks(7589), 1 },
                    { new Guid("2419cd55-45bb-453d-bdaf-05a402e30020"), 766.710442639191000m, false, new Guid("61fafe75-8063-4297-b42f-523c53db27db"), "Dolorem quis accusantium provident voluptatum. Voluptas qui ut rerum eos eum eius eaque.", new DateTime(2014, 1, 28, 23, 48, 41, 937, DateTimeKind.Utc).AddTicks(7819), 0 },
                    { new Guid("25f10a60-7d2c-4620-8558-5f996a416eb6"), 502.702282469847000m, false, new Guid("61fafe75-8063-4297-b42f-523c53db27db"), "Aliquid recusandae quae.", new DateTime(2015, 2, 28, 1, 24, 25, 998, DateTimeKind.Utc).AddTicks(8708), 0 },
                    { new Guid("26628241-d8af-4ee9-8e27-0e933ada9ed3"), 46.938302706883000m, false, new Guid("1e556685-dcaf-4ba7-a8da-707b17314922"), "Neque assumenda impedit dolores quae ipsam eum quod. Et earum quaerat aut possimus voluptatum. Aperiam iure sint voluptatem ipsum aut temporibus vero et possimus. Iste eos provident numquam dolor repellendus beatae sed.", new DateTime(2015, 5, 1, 21, 25, 36, 516, DateTimeKind.Utc).AddTicks(1646), 0 },
                    { new Guid("2725bf1b-5bdf-4491-a06c-cec7d1815e0f"), 751.534145897543000m, false, new Guid("892dd3cc-afc5-44ee-9c98-e08577c51e3c"), "Quo aliquid blanditiis.", new DateTime(2013, 8, 23, 1, 1, 35, 217, DateTimeKind.Utc).AddTicks(4770), 99 },
                    { new Guid("296204c1-8327-40a4-b82a-b48811148c17"), 298.769335079744000m, false, new Guid("43752539-10d2-435c-8e68-6e8fd0e53c12"), "Sit id magnam et eum ipsum dolor est reiciendis. Libero magnam consequatur voluptas sequi dolore aspernatur quo.", new DateTime(2015, 10, 24, 19, 43, 46, 266, DateTimeKind.Utc).AddTicks(3956), 0 },
                    { new Guid("2a217d30-36e7-477b-87f4-9b4854ac328a"), 148.053733181276000m, false, new Guid("266ff167-15bf-4dc2-b9b0-c5af915c143e"), "Dicta dolorem illo molestiae.", new DateTime(2019, 10, 27, 4, 3, 29, 748, DateTimeKind.Utc).AddTicks(4213), 1 },
                    { new Guid("2bc20cc2-5162-4c4f-9f2f-cb98b61c2b4d"), 749.778751297109000m, false, new Guid("ce962a88-ee32-49bc-b2e2-8ccb5c53dcaf"), "Molestiae sit vero omnis sed rem laborum et. Accusamus esse reprehenderit provident adipisci dignissimos a quod.", new DateTime(2012, 3, 11, 7, 20, 20, 864, DateTimeKind.Utc).AddTicks(7908), 1 },
                    { new Guid("2cdd87e6-cf80-4044-ac12-3221d58dc17f"), 718.324801788553000m, false, new Guid("fe265cbe-a3ca-449b-999a-95a48da566ab"), "Repudiandae architecto aliquam assumenda quis enim ab labore nihil. Est magnam ipsa fugiat autem libero et voluptate aliquid recusandae. Repudiandae qui odit.", new DateTime(2018, 8, 19, 21, 21, 5, 651, DateTimeKind.Utc).AddTicks(529), 99 },
                    { new Guid("2d6c6a5c-b3fe-45b3-bc29-bc944001ca93"), 286.858018630764000m, false, new Guid("edbda49f-0a72-4a07-9ce0-cccfda5c6e7e"), "Veritatis sapiente deleniti omnis repellat nemo quae exercitationem amet. Aut consequatur nesciunt natus illo laborum. Commodi unde quas corporis dignissimos pariatur. Beatae architecto aut.", new DateTime(2018, 6, 29, 2, 20, 22, 975, DateTimeKind.Utc).AddTicks(7203), 99 },
                    { new Guid("2d77e399-4488-413a-afe0-cab5a1e4206b"), 51.021133459429000m, false, new Guid("2763f4ef-266b-42e5-9d5c-712617d145f7"), "Deleniti corrupti et deleniti illum temporibus sit.", new DateTime(2019, 11, 26, 12, 10, 53, 155, DateTimeKind.Utc).AddTicks(3021), 1 },
                    { new Guid("2f5664ca-f94d-48d4-a9bf-82befaa5b367"), 363.435603104817000m, false, new Guid("031addae-12c7-45bc-ad72-837bcbcbe949"), "Sint temporibus ut consectetur sit sed earum neque. Sed dolores quia. Non consequatur labore fugiat vero.", new DateTime(2012, 3, 10, 13, 25, 46, 94, DateTimeKind.Utc).AddTicks(3403), 0 },
                    { new Guid("2f661d68-f817-4e8d-90d4-8a9fd6bafb5f"), 263.065545346797000m, false, new Guid("b80fa2ba-d920-4153-bff5-344f9cef9e6d"), "Veniam qui iusto expedita distinctio modi distinctio. Aperiam excepturi voluptatibus consequatur laborum modi iure.", new DateTime(2016, 4, 8, 16, 55, 2, 586, DateTimeKind.Utc).AddTicks(6603), 0 },
                    { new Guid("347682b6-f0c3-44a3-964f-d0091e6600c8"), 342.213428312876000m, false, new Guid("266ff167-15bf-4dc2-b9b0-c5af915c143e"), "Nostrum voluptatem et qui. Dolorem et corrupti. Saepe dolor voluptatem voluptatem nihil. Ad dolores officiis cum sequi numquam eum harum qui consequatur.", new DateTime(2018, 7, 8, 12, 49, 50, 35, DateTimeKind.Utc).AddTicks(6768), 99 },
                    { new Guid("34ddb1e3-3765-4122-9aa1-0f594abdf7b4"), 673.270183465794000m, false, new Guid("edbda49f-0a72-4a07-9ce0-cccfda5c6e7e"), "Iure repudiandae qui aliquid alias dolorem ut. Totam dolore iure et sequi placeat doloremque.", new DateTime(2012, 12, 7, 17, 55, 6, 542, DateTimeKind.Utc).AddTicks(6082), 0 },
                    { new Guid("3638ecea-5da4-49a1-ba91-a603e45e39ff"), 726.261443178743000m, false, new Guid("45827aeb-0b3d-4a6b-9f41-c53eba1c6cbc"), "Magni dolorum voluptate et. Atque omnis eius illum. Sequi sed quia quo ad odio delectus. Saepe et voluptas sit porro minus.", new DateTime(2019, 5, 9, 13, 51, 22, 941, DateTimeKind.Utc).AddTicks(2625), 1 },
                    { new Guid("3644b573-27ad-4595-9388-46a722f3de76"), 179.928082158625000m, false, new Guid("031addae-12c7-45bc-ad72-837bcbcbe949"), "Expedita voluptas quidem omnis animi consectetur. Quae consectetur rerum minus et sed. Aut reprehenderit quia quia corporis magni soluta.", new DateTime(2019, 3, 12, 3, 17, 5, 784, DateTimeKind.Utc).AddTicks(4107), 0 },
                    { new Guid("36d69a7e-a86a-4920-91a1-d3293f336342"), 226.123697886292000m, false, new Guid("61fafe75-8063-4297-b42f-523c53db27db"), "Explicabo non porro maiores eum debitis et porro est aut. Voluptatem sunt repellat blanditiis quam debitis necessitatibus illo aliquam explicabo.", new DateTime(2015, 8, 7, 3, 26, 50, 753, DateTimeKind.Utc).AddTicks(8621), 1 },
                    { new Guid("372d7aba-efdc-42f2-afdd-91d07bf0635a"), 605.391087178311000m, false, new Guid("45827aeb-0b3d-4a6b-9f41-c53eba1c6cbc"), "Molestiae earum natus occaecati dicta voluptas dolorum nam rerum. Facilis porro quia officia. Consequatur aut ea fuga praesentium id laboriosam dolorem. Incidunt nisi quae aut eligendi ut architecto velit.", new DateTime(2014, 2, 23, 16, 19, 25, 284, DateTimeKind.Utc).AddTicks(2650), 99 },
                    { new Guid("386e68f1-112a-439b-9425-f031a818dc5c"), 971.290533168701000m, false, new Guid("892dd3cc-afc5-44ee-9c98-e08577c51e3c"), "Repellat laboriosam quia explicabo animi nihil at omnis. Quidem natus voluptate nobis consequuntur sed sed voluptatem doloribus facere.", new DateTime(2013, 8, 23, 20, 29, 59, 935, DateTimeKind.Utc).AddTicks(8984), 99 },
                    { new Guid("3b0f142d-a2cd-47a4-aebb-4773f78589b6"), 470.806700181817000m, false, new Guid("ce962a88-ee32-49bc-b2e2-8ccb5c53dcaf"), "Velit ab repellendus.", new DateTime(2015, 4, 29, 15, 4, 11, 343, DateTimeKind.Utc).AddTicks(3431), 1 },
                    { new Guid("3c724e21-daeb-4260-8e49-dbdbfd1587ff"), 895.210713331011000m, false, new Guid("03205baf-c226-4094-94a2-6bc60a94cc5d"), "Voluptatibus facilis et et.", new DateTime(2018, 5, 13, 13, 32, 50, 28, DateTimeKind.Utc).AddTicks(6815), 1 },
                    { new Guid("3c9434ee-17f5-4c81-a47f-ccb3df11babf"), 703.240409607449000m, false, new Guid("266ff167-15bf-4dc2-b9b0-c5af915c143e"), "Occaecati nobis sint accusamus et provident. Nemo minus ipsa incidunt molestias tenetur. Debitis aut voluptatum et suscipit aut ipsum animi. Tempora soluta ipsum tenetur ut deserunt eius sint tempore.", new DateTime(2013, 11, 11, 21, 48, 52, 641, DateTimeKind.Utc).AddTicks(3743), 0 },
                    { new Guid("3d1c46a1-b0ee-4bd8-a59e-3555eecaf10b"), 351.709158270631000m, false, new Guid("1e556685-dcaf-4ba7-a8da-707b17314922"), "Odio voluptatem quidem ut ea aut tempora. Autem animi consequatur quos ullam quis laboriosam accusantium. Non accusantium quas. Saepe magni dolorem ut officia inventore accusantium animi non accusantium.", new DateTime(2015, 10, 26, 11, 42, 24, 116, DateTimeKind.Utc).AddTicks(4234), 1 },
                    { new Guid("3db7f099-044c-4920-a129-379896d57e8e"), 628.609717417016000m, false, new Guid("45827aeb-0b3d-4a6b-9f41-c53eba1c6cbc"), "Exercitationem assumenda libero dolorem dignissimos voluptates laborum rerum dolorem. Eaque expedita omnis mollitia alias minus amet mollitia. Sit animi voluptatum eius aut aliquid perferendis dolores maiores mollitia. Tenetur odit qui quam nulla facere ut nihil maiores.", new DateTime(2013, 8, 11, 23, 20, 10, 55, DateTimeKind.Utc).AddTicks(9724), 99 },
                    { new Guid("3dd825ab-d838-49c5-9a34-276430b608b6"), 859.20584591155000m, false, new Guid("3f0b5db8-a2b4-4607-b7a1-3c277651d860"), "Cupiditate quae esse impedit et velit id suscipit. Odio voluptas quia. Atque cumque est rem eos rerum. Ducimus et explicabo in.", new DateTime(2020, 3, 31, 10, 47, 19, 7, DateTimeKind.Utc).AddTicks(5911), 0 },
                    { new Guid("3e058c02-5963-4512-a9a4-9e0811552bf1"), 855.571428112037000m, false, new Guid("031addae-12c7-45bc-ad72-837bcbcbe949"), "Voluptates soluta sunt enim consectetur quo dignissimos aut amet ullam. Qui impedit sunt dolorem unde. Odit quia fugit omnis officiis consequatur sint repellendus praesentium vel. Recusandae odio quibusdam molestiae quaerat corrupti architecto minus architecto.", new DateTime(2019, 4, 29, 22, 52, 37, 585, DateTimeKind.Utc).AddTicks(9623), 0 },
                    { new Guid("3e3fdfef-57a6-460b-aeb7-7baea28f8e3b"), 10.0410599381818000m, false, new Guid("1e556685-dcaf-4ba7-a8da-707b17314922"), "Molestiae architecto repellat hic voluptas alias culpa.", new DateTime(2019, 7, 5, 15, 51, 33, 529, DateTimeKind.Utc).AddTicks(9585), 0 },
                    { new Guid("3ea23de1-2e2e-428e-a0f3-b59522e6f1d7"), 274.369167950317000m, false, new Guid("436f7a1d-cc9e-476f-8dd1-f38e9c870ab9"), "Consequatur et quaerat nesciunt odit et aut nisi itaque ducimus. Dolores aut dignissimos aut quia consequatur. Molestiae esse sunt quisquam placeat ad iure aut id.", new DateTime(2013, 10, 17, 4, 37, 34, 973, DateTimeKind.Utc).AddTicks(849), 99 },
                    { new Guid("3edc4c28-3103-405c-8f2a-a9d794e285eb"), 270.874052017529000m, false, new Guid("2763f4ef-266b-42e5-9d5c-712617d145f7"), "Aliquid porro impedit incidunt perferendis laudantium similique sed. Alias et sed sed. Magni rerum incidunt tenetur nihil iure rerum cumque nisi.", new DateTime(2015, 3, 8, 14, 14, 11, 390, DateTimeKind.Utc).AddTicks(3609), 0 },
                    { new Guid("3ef042e7-07cd-4079-9a69-56879d279173"), 831.689363332389000m, false, new Guid("bf559038-abfa-4ee2-ad60-0cd92ff54447"), "Optio eum quibusdam illo quia qui possimus. Dolor reprehenderit et quia distinctio sed maiores. Reprehenderit deserunt laboriosam ut.", new DateTime(2016, 8, 3, 18, 44, 49, 620, DateTimeKind.Utc).AddTicks(1874), 0 },
                    { new Guid("3f832fc3-3f19-4c6c-b3cf-14a93a646ea3"), 894.081904043371000m, false, new Guid("031addae-12c7-45bc-ad72-837bcbcbe949"), "Voluptatibus id nihil fuga id nemo maiores. Incidunt distinctio voluptas sint omnis quibusdam dignissimos quae quia. Voluptatem maiores harum deserunt repudiandae animi quas. Alias amet consequatur ut sequi et.", new DateTime(2015, 10, 10, 22, 54, 25, 857, DateTimeKind.Utc).AddTicks(1208), 99 },
                    { new Guid("3fc6c67d-bde9-41ab-b192-af6ca7b0c258"), 725.804627033454000m, false, new Guid("583be124-ed68-4a81-b641-4dd7fba8bdd0"), "Quisquam quis velit laboriosam nihil. Dolorem ipsa saepe beatae dolor.", new DateTime(2021, 4, 25, 16, 36, 12, 570, DateTimeKind.Utc).AddTicks(2580), 0 },
                    { new Guid("405447df-40d7-40b1-abe8-84c484515ed5"), 777.903325288437000m, false, new Guid("583be124-ed68-4a81-b641-4dd7fba8bdd0"), "Maiores iusto nam vero non hic sit velit voluptate. Error hic sed. Cupiditate aliquid optio voluptate dolorem autem eveniet repellendus. Voluptatem quia iusto quia.", new DateTime(2012, 2, 22, 10, 20, 4, 381, DateTimeKind.Utc).AddTicks(1083), 0 },
                    { new Guid("422a4560-bd82-49df-91be-063a5516e96f"), 731.758001647492000m, false, new Guid("892dd3cc-afc5-44ee-9c98-e08577c51e3c"), "Quod vel natus. Qui incidunt rem officiis voluptas qui. Velit molestiae delectus aut doloribus natus. Deserunt provident dolores quia et.", new DateTime(2013, 2, 11, 22, 8, 45, 996, DateTimeKind.Utc).AddTicks(5520), 0 },
                    { new Guid("4589cd17-184d-4f68-b792-779c88324504"), 865.081561517631000m, false, new Guid("436f7a1d-cc9e-476f-8dd1-f38e9c870ab9"), "Totam perferendis non voluptatum. Quos ut autem totam culpa velit delectus necessitatibus. Illo consequatur itaque. Vero atque ut accusamus rem consequatur dolorem.", new DateTime(2019, 1, 7, 12, 8, 30, 830, DateTimeKind.Utc).AddTicks(9064), 1 },
                    { new Guid("46700ae0-936e-4a05-9c49-24bd56e0ebbc"), 904.211923978358000m, false, new Guid("3f0b5db8-a2b4-4607-b7a1-3c277651d860"), "Consequatur minima amet qui aliquid. Aliquid cum in occaecati dolore. Officiis consectetur qui perspiciatis omnis aut. Excepturi ad error voluptate quisquam quasi minima aut sapiente dolorem.", new DateTime(2013, 3, 29, 18, 19, 16, 815, DateTimeKind.Utc).AddTicks(326), 0 },
                    { new Guid("47dbee88-32c7-408d-83a4-62bd2b811bd7"), 742.519029227928000m, false, new Guid("61fafe75-8063-4297-b42f-523c53db27db"), "Error consectetur voluptatem reprehenderit quasi soluta ipsa debitis ipsam. Sed sed ducimus saepe. Deleniti autem quasi qui doloremque. Voluptatem dolore quo sunt delectus.", new DateTime(2015, 11, 14, 2, 53, 13, 148, DateTimeKind.Utc).AddTicks(6683), 0 },
                    { new Guid("49bc17d4-19fe-409c-a910-753cee51f721"), 980.040218001741000m, false, new Guid("436f7a1d-cc9e-476f-8dd1-f38e9c870ab9"), "A sapiente magni temporibus rerum mollitia provident est libero.", new DateTime(2018, 10, 27, 9, 20, 38, 351, DateTimeKind.Utc).AddTicks(2097), 1 },
                    { new Guid("4a22c37b-c4af-4a2f-a112-7b825e04ed18"), 135.028783599407000m, false, new Guid("43752539-10d2-435c-8e68-6e8fd0e53c12"), "Aut placeat saepe culpa.", new DateTime(2017, 4, 28, 9, 50, 26, 398, DateTimeKind.Utc).AddTicks(7021), 99 },
                    { new Guid("4ea45d65-ab56-40d8-92a8-d6298d637821"), 5.65108897002142000m, false, new Guid("ce962a88-ee32-49bc-b2e2-8ccb5c53dcaf"), "Ut ipsam eum incidunt et ut amet eos quidem adipisci. Est voluptatem possimus ut quae est corrupti.", new DateTime(2019, 9, 16, 7, 51, 3, 359, DateTimeKind.Utc).AddTicks(4196), 1 },
                    { new Guid("4f1f282d-8ce4-4213-b3f4-81dd5aebee35"), 338.602054628304000m, false, new Guid("b80fa2ba-d920-4153-bff5-344f9cef9e6d"), "Ut occaecati est aut sapiente maxime incidunt cum fugit.", new DateTime(2022, 2, 11, 17, 23, 51, 848, DateTimeKind.Utc).AddTicks(951), 0 },
                    { new Guid("52b74790-c6a9-4ec1-9a34-9dca3b3b2181"), 963.87744126887000m, false, new Guid("43752539-10d2-435c-8e68-6e8fd0e53c12"), "Eaque veniam reprehenderit consequatur officiis necessitatibus ut.", new DateTime(2016, 10, 26, 0, 48, 5, 110, DateTimeKind.Utc).AddTicks(5868), 1 },
                    { new Guid("531b57d7-7f63-4172-a262-519da4ba193e"), 412.838198246348000m, false, new Guid("266ff167-15bf-4dc2-b9b0-c5af915c143e"), "Ea et tempora. Officia rerum sit aut asperiores et magnam placeat. A ut autem ducimus eum est quis aut totam. Eum aut non.", new DateTime(2016, 7, 4, 22, 13, 15, 230, DateTimeKind.Utc).AddTicks(6198), 99 },
                    { new Guid("56c08862-a74e-4f04-9594-bc350016a64a"), 753.995426695672000m, false, new Guid("b80fa2ba-d920-4153-bff5-344f9cef9e6d"), "Nisi et doloribus ducimus reiciendis harum nihil sit. Et omnis at eius sit ipsa. Voluptatem quo fuga.", new DateTime(2012, 2, 18, 14, 42, 5, 225, DateTimeKind.Utc).AddTicks(5096), 99 },
                    { new Guid("56d6840a-9e77-48e3-b270-ed2e17114597"), 721.551153115099000m, false, new Guid("61fafe75-8063-4297-b42f-523c53db27db"), "Sit commodi et. Iste cupiditate expedita eaque facilis consequatur. Est cupiditate est harum ullam deleniti perspiciatis. Ipsa architecto repudiandae consequatur architecto quo placeat velit quo.", new DateTime(2012, 5, 10, 3, 4, 0, 528, DateTimeKind.Utc).AddTicks(3652), 99 },
                    { new Guid("58e2e456-f19c-4c3b-a057-644baab0635c"), 527.866271946198000m, false, new Guid("ce962a88-ee32-49bc-b2e2-8ccb5c53dcaf"), "Hic a perspiciatis reprehenderit provident occaecati sunt quo rerum dolor.", new DateTime(2012, 4, 6, 6, 53, 7, 12, DateTimeKind.Utc).AddTicks(7614), 0 },
                    { new Guid("59719026-653f-49e3-9e44-2418d524c2ef"), 710.610760696014000m, false, new Guid("2763f4ef-266b-42e5-9d5c-712617d145f7"), "Quasi sunt sit id consectetur. Illo ut distinctio optio. Soluta nemo dolor laboriosam facere adipisci mollitia.", new DateTime(2014, 10, 18, 1, 21, 11, 184, DateTimeKind.Utc).AddTicks(1900), 99 },
                    { new Guid("5b4b9985-7d2c-43af-895b-2fc622a4af85"), 748.523848471496000m, false, new Guid("fe265cbe-a3ca-449b-999a-95a48da566ab"), "Debitis harum in dolorum est. Maiores ut recusandae qui amet autem rerum praesentium. Reiciendis facilis sint delectus asperiores sequi.", new DateTime(2021, 8, 2, 11, 13, 25, 123, DateTimeKind.Utc).AddTicks(1789), 1 },
                    { new Guid("5c25413a-e937-4323-b1a0-0834b7d34239"), 850.43822899152000m, false, new Guid("03205baf-c226-4094-94a2-6bc60a94cc5d"), "Exercitationem optio voluptatem.", new DateTime(2013, 11, 23, 2, 46, 38, 84, DateTimeKind.Utc).AddTicks(3119), 0 },
                    { new Guid("634d0fc0-3b3d-498d-8aef-cdaecbe505ed"), 683.212432606268000m, false, new Guid("2eff2c74-de12-4b27-85a2-1d8ad47c50d8"), "Occaecati earum voluptatum minus est ex ipsam rem.", new DateTime(2020, 6, 21, 7, 33, 14, 27, DateTimeKind.Utc).AddTicks(6711), 1 },
                    { new Guid("641a6021-ff8e-4ef9-aabc-f244160f41ee"), 822.807207117255000m, false, new Guid("c1a480a4-7835-4156-8b5c-a0b41663c36b"), "Rerum vero at amet sequi ut impedit. Consequatur quisquam quo ut est itaque est sint. Incidunt nostrum ipsam. Recusandae qui velit porro et repellat.", new DateTime(2017, 5, 4, 0, 24, 34, 409, DateTimeKind.Utc).AddTicks(916), 1 },
                    { new Guid("64dfebe8-04e6-4f20-b9bc-76e3237ad789"), 699.25368474174000m, false, new Guid("2763f4ef-266b-42e5-9d5c-712617d145f7"), "Autem nemo architecto voluptatem quis non optio. Fugiat et modi at perferendis autem reprehenderit.", new DateTime(2014, 9, 3, 3, 40, 54, 543, DateTimeKind.Utc).AddTicks(501), 1 },
                    { new Guid("65c197ae-97c7-4b47-b8a0-e128f21d7037"), 913.759399000285000m, false, new Guid("fe265cbe-a3ca-449b-999a-95a48da566ab"), "Vero vel amet voluptatem accusantium voluptas.", new DateTime(2019, 1, 20, 8, 32, 26, 807, DateTimeKind.Utc).AddTicks(8712), 0 },
                    { new Guid("679cfe23-b0af-4a21-bb4a-52dcc796c89b"), 903.705736122679000m, false, new Guid("1e556685-dcaf-4ba7-a8da-707b17314922"), "Quo voluptas et deserunt nemo vitae.", new DateTime(2017, 4, 6, 19, 34, 1, 161, DateTimeKind.Utc).AddTicks(5269), 0 },
                    { new Guid("68e29065-5520-4a92-8c55-f05803885842"), 543.752352831736000m, false, new Guid("2eff2c74-de12-4b27-85a2-1d8ad47c50d8"), "Non sunt nostrum totam voluptatem consectetur et fugit dolores. Necessitatibus pariatur ducimus quaerat. Repudiandae qui dolorum facilis molestiae soluta possimus. Maiores velit corrupti iusto autem omnis dolorem culpa modi quia.", new DateTime(2018, 5, 27, 18, 32, 30, 754, DateTimeKind.Utc).AddTicks(9871), 99 },
                    { new Guid("6abd3776-6d76-4acd-a763-088427af1080"), 909.639491221062000m, false, new Guid("03205baf-c226-4094-94a2-6bc60a94cc5d"), "Praesentium in vitae officia voluptas incidunt quaerat.", new DateTime(2016, 1, 31, 20, 13, 43, 741, DateTimeKind.Utc).AddTicks(8794), 1 },
                    { new Guid("6b73e81a-e1d5-49c8-a753-7120e4533b15"), 72.5713854483304000m, false, new Guid("43752539-10d2-435c-8e68-6e8fd0e53c12"), "Consequatur possimus ut rem dolores est dolor officia.", new DateTime(2020, 7, 27, 12, 12, 31, 463, DateTimeKind.Utc).AddTicks(7082), 99 },
                    { new Guid("6d07d52b-66a3-4439-ba08-68df9725343d"), 671.008126110125000m, false, new Guid("892dd3cc-afc5-44ee-9c98-e08577c51e3c"), "Voluptatibus consequuntur officiis. Tempora dolorum ut est consequatur.", new DateTime(2021, 5, 12, 5, 22, 9, 928, DateTimeKind.Utc).AddTicks(3384), 1 },
                    { new Guid("7219614b-f6a2-4617-a1d3-034ef9d8ed90"), 597.727933112167000m, false, new Guid("43752539-10d2-435c-8e68-6e8fd0e53c12"), "Adipisci suscipit consequatur voluptas.", new DateTime(2019, 12, 20, 0, 31, 33, 646, DateTimeKind.Utc).AddTicks(2383), 99 },
                    { new Guid("75fc316b-0878-4eac-a54d-986582461ff5"), 482.092595221561000m, false, new Guid("03205baf-c226-4094-94a2-6bc60a94cc5d"), "Aliquid animi aut iure itaque aut ut nobis.", new DateTime(2012, 11, 30, 12, 34, 4, 240, DateTimeKind.Utc).AddTicks(8322), 99 },
                    { new Guid("7a6af24f-a36c-4b71-a333-5bfe192dd2d2"), 889.750652190338000m, false, new Guid("03205baf-c226-4094-94a2-6bc60a94cc5d"), "Praesentium ratione dolore cum culpa voluptas ducimus accusantium. Provident voluptas delectus sed. Earum reprehenderit tenetur. Blanditiis et eveniet praesentium nulla est autem aperiam numquam.", new DateTime(2017, 1, 11, 23, 20, 14, 301, DateTimeKind.Utc).AddTicks(8091), 1 },
                    { new Guid("7b30ed10-2f2d-4f82-b266-2b02a052657f"), 615.401782994681000m, false, new Guid("266ff167-15bf-4dc2-b9b0-c5af915c143e"), "Saepe blanditiis culpa laborum ut et vel aut. Veritatis molestiae possimus fugit et.", new DateTime(2022, 1, 27, 10, 23, 38, 419, DateTimeKind.Utc).AddTicks(8506), 1 },
                    { new Guid("7ca9b196-43a2-4a49-89d9-6c154642beb5"), 641.296033421591000m, false, new Guid("bf559038-abfa-4ee2-ad60-0cd92ff54447"), "Ea maiores eaque a amet nihil et inventore sed natus. Quibusdam ut eius.", new DateTime(2020, 1, 3, 3, 27, 19, 379, DateTimeKind.Utc).AddTicks(6092), 99 },
                    { new Guid("7ce181a3-4c95-43a5-9145-ababa99331f6"), 115.405051598000m, false, new Guid("436f7a1d-cc9e-476f-8dd1-f38e9c870ab9"), "Voluptas odit est et nulla. Rem ex est. Nemo magnam assumenda doloribus expedita et quidem.", new DateTime(2013, 10, 15, 21, 21, 7, 83, DateTimeKind.Utc).AddTicks(6320), 1 },
                    { new Guid("7ec22710-9f95-4b82-80d6-e4e2efd9e091"), 958.4315306321000m, false, new Guid("583be124-ed68-4a81-b641-4dd7fba8bdd0"), "Tempore soluta ea quisquam. Fuga molestiae at voluptas ea aperiam. Dolor et assumenda in sit et eius modi laboriosam consequatur. Unde sequi itaque labore.", new DateTime(2021, 10, 17, 15, 26, 12, 184, DateTimeKind.Utc).AddTicks(106), 99 },
                    { new Guid("7ec2598d-0214-4957-a016-83ed3a21e12e"), 524.321431727768000m, false, new Guid("b80fa2ba-d920-4153-bff5-344f9cef9e6d"), "Assumenda quo ipsa animi ipsa quis non nisi commodi deserunt. Maxime sit similique expedita vel et esse vitae.", new DateTime(2019, 12, 25, 8, 37, 17, 718, DateTimeKind.Utc).AddTicks(5544), 0 },
                    { new Guid("7ef06981-3237-46ec-a002-11db3dc2dd4a"), 267.575197756558000m, false, new Guid("892dd3cc-afc5-44ee-9c98-e08577c51e3c"), "Ut similique officiis earum aliquam qui. Nesciunt quia quos.", new DateTime(2015, 8, 17, 10, 19, 13, 744, DateTimeKind.Utc).AddTicks(6978), 99 },
                    { new Guid("7fcd6322-118d-47bd-a723-b250b95b2960"), 405.161833195793000m, false, new Guid("43752539-10d2-435c-8e68-6e8fd0e53c12"), "Omnis quis maxime assumenda iure excepturi quia expedita. Dignissimos numquam ipsa aliquid quos fugiat. Eveniet id dolorum.", new DateTime(2019, 8, 6, 10, 37, 51, 808, DateTimeKind.Utc).AddTicks(2602), 99 },
                    { new Guid("806e2d6d-f5f7-479e-8fa3-3d184a73e1e0"), 632.546471958776000m, false, new Guid("c1a480a4-7835-4156-8b5c-a0b41663c36b"), "Qui qui ut. Quia omnis ut doloribus soluta. Nostrum explicabo aut maxime.", new DateTime(2016, 7, 19, 16, 7, 19, 265, DateTimeKind.Utc).AddTicks(4206), 1 },
                    { new Guid("810e23be-3146-4eb7-ac07-1fc9d2a44867"), 244.008651279107000m, false, new Guid("892dd3cc-afc5-44ee-9c98-e08577c51e3c"), "Molestiae aut autem labore et totam.", new DateTime(2020, 9, 1, 9, 32, 51, 266, DateTimeKind.Utc).AddTicks(2189), 0 },
                    { new Guid("84546a69-3f80-4e2f-b30b-9aecf3c35979"), 740.392346275677000m, false, new Guid("3f0b5db8-a2b4-4607-b7a1-3c277651d860"), "Sequi amet vel eligendi reiciendis ut est dolorem. Soluta sit est.", new DateTime(2013, 11, 22, 19, 52, 26, 68, DateTimeKind.Utc).AddTicks(1539), 99 },
                    { new Guid("85819a1a-a639-4f2b-a274-be416ba84c7f"), 535.169266978994000m, false, new Guid("2eff2c74-de12-4b27-85a2-1d8ad47c50d8"), "Aliquid voluptas enim omnis perspiciatis sit voluptatem minima. Aspernatur maiores beatae.", new DateTime(2021, 1, 24, 13, 23, 9, 943, DateTimeKind.Utc).AddTicks(4095), 1 },
                    { new Guid("8a60b0a8-52bb-4173-aa80-632e4bdad8f9"), 963.732037064874000m, false, new Guid("fe265cbe-a3ca-449b-999a-95a48da566ab"), "Atque et repellat quidem omnis voluptas qui corrupti dolor. Perspiciatis atque iste et. Sed minus sint.", new DateTime(2013, 10, 20, 1, 8, 12, 973, DateTimeKind.Utc).AddTicks(5452), 99 },
                    { new Guid("8ad1b2fc-89bc-4467-bbf9-670722e4f6ee"), 345.833809423623000m, false, new Guid("266ff167-15bf-4dc2-b9b0-c5af915c143e"), "Sint pariatur ea id nemo dolorum impedit quidem ut. Sapiente debitis fuga voluptas perferendis eligendi qui id at qui. Et aut iusto distinctio id odit quod.", new DateTime(2017, 6, 19, 7, 40, 31, 963, DateTimeKind.Utc).AddTicks(2016), 0 },
                    { new Guid("8c9ff234-c784-49cd-8e40-3360bb8728f5"), 760.717288782892000m, false, new Guid("43752539-10d2-435c-8e68-6e8fd0e53c12"), "Commodi sapiente praesentium vel. Molestiae magni provident non.", new DateTime(2019, 1, 7, 23, 8, 11, 40, DateTimeKind.Utc).AddTicks(1245), 1 },
                    { new Guid("8cd7c563-66a2-4f60-b44d-d2ea1d06fbed"), 911.937147114103000m, false, new Guid("266ff167-15bf-4dc2-b9b0-c5af915c143e"), "Ab omnis laborum aut dignissimos dolor rem incidunt modi. Est temporibus dolorem voluptates voluptatem saepe distinctio quia adipisci.", new DateTime(2019, 4, 24, 5, 25, 10, 634, DateTimeKind.Utc).AddTicks(9971), 99 },
                    { new Guid("8d5f2e64-e685-4c20-9880-567a53354457"), 370.22773538485000m, false, new Guid("2eff2c74-de12-4b27-85a2-1d8ad47c50d8"), "Voluptas omnis enim facilis cupiditate dolorem cumque. Illo adipisci aut perferendis eum praesentium sint sunt ipsa corrupti.", new DateTime(2012, 10, 6, 3, 39, 18, 315, DateTimeKind.Utc).AddTicks(5589), 0 },
                    { new Guid("8faac492-5ceb-45ba-9fd2-7f5ca2e82233"), 942.773637503003000m, false, new Guid("19c2dac9-f6df-445a-92a0-5028b785cdf8"), "Aperiam et vel et perferendis voluptas ut velit magnam vel. Fugit beatae eveniet et nobis consectetur quia.", new DateTime(2020, 5, 5, 5, 40, 12, 783, DateTimeKind.Utc).AddTicks(7948), 0 },
                    { new Guid("9365dc51-ae27-4b6c-999d-468975ce4ff3"), 11.63562862787000m, false, new Guid("bf559038-abfa-4ee2-ad60-0cd92ff54447"), "Aspernatur sint et.", new DateTime(2018, 1, 15, 2, 40, 26, 117, DateTimeKind.Utc).AddTicks(7931), 1 },
                    { new Guid("95328afe-40f5-4161-a07d-e396f95e4c6c"), 359.320621678465000m, false, new Guid("583be124-ed68-4a81-b641-4dd7fba8bdd0"), "Consequuntur accusamus iste perspiciatis. Velit ex rerum quas officiis. Accusamus alias quas incidunt nihil natus. Vitae ut sint pariatur reiciendis atque voluptatem dolor iste rem.", new DateTime(2016, 3, 1, 8, 1, 26, 664, DateTimeKind.Utc).AddTicks(7101), 0 },
                    { new Guid("95ac2291-9745-4f37-b26d-228cd726ffd7"), 604.185982261935000m, false, new Guid("3f0b5db8-a2b4-4607-b7a1-3c277651d860"), "Quae quas enim.", new DateTime(2017, 3, 4, 1, 36, 9, 486, DateTimeKind.Utc).AddTicks(9730), 0 },
                    { new Guid("98958350-ef78-46ae-ac16-1ca409ad98c1"), 570.032441663327000m, false, new Guid("fe265cbe-a3ca-449b-999a-95a48da566ab"), "Officiis officiis quibusdam corporis praesentium est tempora pariatur autem. Omnis totam non.", new DateTime(2017, 3, 2, 17, 39, 44, 93, DateTimeKind.Utc).AddTicks(2250), 0 },
                    { new Guid("9cb7714e-ed18-42df-be34-d536637964fa"), 994.654148479688000m, false, new Guid("2763f4ef-266b-42e5-9d5c-712617d145f7"), "Voluptatem quibusdam ex et corporis ut et sint. Amet nemo sapiente quidem ut sed beatae. Placeat quod aut nam. Placeat corporis odit.", new DateTime(2019, 5, 7, 23, 31, 19, 297, DateTimeKind.Utc).AddTicks(495), 0 },
                    { new Guid("9f966979-533d-4716-b2b8-bb56ae89b536"), 6.28839481764609000m, false, new Guid("892dd3cc-afc5-44ee-9c98-e08577c51e3c"), "Aspernatur ad rem doloribus neque explicabo. Assumenda ut doloribus deleniti deleniti.", new DateTime(2015, 2, 27, 6, 43, 8, 336, DateTimeKind.Utc).AddTicks(6917), 0 },
                    { new Guid("a000b3d7-fdd2-458e-b791-bfc80281affc"), 305.47072669699000m, false, new Guid("fe265cbe-a3ca-449b-999a-95a48da566ab"), "Incidunt labore libero. Veritatis esse consequatur magni.", new DateTime(2014, 7, 28, 16, 2, 48, 655, DateTimeKind.Utc).AddTicks(962), 0 },
                    { new Guid("a211708a-c517-411e-b9ac-6e5bd34c3d56"), 700.345640323038000m, false, new Guid("583be124-ed68-4a81-b641-4dd7fba8bdd0"), "Nisi sunt nesciunt excepturi aut. Nulla eum dolorem dolor. Error quod minima doloribus recusandae voluptatibus nemo distinctio ipsum impedit. Asperiores eligendi iusto provident aut earum.", new DateTime(2020, 12, 21, 9, 20, 36, 358, DateTimeKind.Utc).AddTicks(5509), 0 },
                    { new Guid("a2242936-7be1-4e0e-990e-d6fb026f4cf2"), 613.22668248109000m, false, new Guid("edbda49f-0a72-4a07-9ce0-cccfda5c6e7e"), "Voluptate illum nesciunt ut vel consequatur ut rem. Qui nobis hic sunt.", new DateTime(2021, 8, 3, 18, 24, 52, 42, DateTimeKind.Utc).AddTicks(2637), 1 },
                    { new Guid("a354169a-8973-44ff-95c0-06a33daf5000"), 271.083344055154000m, false, new Guid("19c2dac9-f6df-445a-92a0-5028b785cdf8"), "Aspernatur earum veritatis rerum voluptatem minus.", new DateTime(2018, 1, 3, 4, 47, 41, 494, DateTimeKind.Utc).AddTicks(4822), 1 },
                    { new Guid("a5534411-f0a4-4951-a4f2-04d0e695c31a"), 40.3551664877411000m, false, new Guid("3f0b5db8-a2b4-4607-b7a1-3c277651d860"), "Incidunt et odio vitae consequatur quod.", new DateTime(2021, 2, 4, 1, 7, 27, 381, DateTimeKind.Utc).AddTicks(3138), 1 },
                    { new Guid("a809cd51-6952-4319-aee8-3f3e50e2953a"), 525.812938575637000m, false, new Guid("892dd3cc-afc5-44ee-9c98-e08577c51e3c"), "Error velit qui in. Ut veniam reprehenderit porro dolores et aut minus rerum.", new DateTime(2020, 10, 2, 23, 44, 34, 968, DateTimeKind.Utc).AddTicks(1550), 99 },
                    { new Guid("a8c10a5b-34dc-4ce6-95eb-105c6d251b22"), 127.279567129136000m, false, new Guid("45827aeb-0b3d-4a6b-9f41-c53eba1c6cbc"), "Non non quia perferendis sed mollitia vel iste. Sit consectetur soluta amet sint sint fuga doloremque magni quae. Nihil qui natus aut dolorum cum minus qui nulla sequi.", new DateTime(2017, 3, 18, 19, 33, 14, 510, DateTimeKind.Utc).AddTicks(1871), 1 },
                    { new Guid("a938c35b-4a88-4ae7-a112-8f2c30e804fb"), 599.369037997373000m, false, new Guid("c1a480a4-7835-4156-8b5c-a0b41663c36b"), "Pariatur iste voluptas facere molestiae in quam nihil molestiae fuga.", new DateTime(2016, 10, 18, 20, 42, 23, 479, DateTimeKind.Utc).AddTicks(7793), 1 },
                    { new Guid("a960e83f-d289-4c39-96f2-d7393f437a9d"), 3.97063380309348000m, false, new Guid("43752539-10d2-435c-8e68-6e8fd0e53c12"), "Facere quod rerum assumenda. Laudantium est dolore temporibus autem. Consequatur exercitationem sit veniam culpa in voluptatem sunt enim.", new DateTime(2020, 9, 9, 6, 52, 55, 486, DateTimeKind.Utc).AddTicks(1038), 0 },
                    { new Guid("ab30e772-73be-4a6c-b3ea-ca2959e8128d"), 546.71012169425000m, false, new Guid("bf559038-abfa-4ee2-ad60-0cd92ff54447"), "Deleniti et et dicta. Nulla ab incidunt qui est natus et rerum nulla itaque.", new DateTime(2018, 5, 7, 11, 9, 11, 919, DateTimeKind.Utc).AddTicks(8659), 99 },
                    { new Guid("ac87ed42-7ba4-4f26-8ef3-c1672d8f0340"), 830.168039183225000m, false, new Guid("b80fa2ba-d920-4153-bff5-344f9cef9e6d"), "Quia velit dolor.", new DateTime(2017, 7, 1, 2, 52, 38, 868, DateTimeKind.Utc).AddTicks(58), 1 },
                    { new Guid("aeb8517b-699d-4a11-a261-207487810eba"), 833.605387183729000m, false, new Guid("03205baf-c226-4094-94a2-6bc60a94cc5d"), "In occaecati non nisi vel minima. Repellat est magnam distinctio. Quis eaque error autem rerum. Soluta iste porro.", new DateTime(2018, 5, 27, 8, 36, 14, 61, DateTimeKind.Utc).AddTicks(4886), 99 },
                    { new Guid("afdacdcd-b9b8-4463-8f05-7953ebac71ef"), 374.688257410912000m, false, new Guid("61fafe75-8063-4297-b42f-523c53db27db"), "Dolorum quia ut et est perferendis impedit est nisi rem. Occaecati distinctio ullam.", new DateTime(2018, 9, 29, 9, 2, 17, 978, DateTimeKind.Utc).AddTicks(2434), 99 },
                    { new Guid("b3b5d91e-37fc-4b7f-8818-ce358e16f51f"), 94.5456026788496000m, false, new Guid("edbda49f-0a72-4a07-9ce0-cccfda5c6e7e"), "Et et aperiam quo aliquam quis. Nisi corrupti laboriosam inventore expedita rerum et.", new DateTime(2018, 4, 12, 2, 0, 5, 533, DateTimeKind.Utc).AddTicks(7114), 99 },
                    { new Guid("b493e9fe-250d-417f-8d17-cc31ced8b9a3"), 147.313577171258000m, false, new Guid("c1a480a4-7835-4156-8b5c-a0b41663c36b"), "Molestias doloremque cupiditate quaerat tempore. Earum praesentium sit eos.", new DateTime(2017, 6, 30, 19, 45, 44, 944, DateTimeKind.Utc).AddTicks(8358), 1 },
                    { new Guid("b582d0a4-f0f8-4a31-b2ef-d2b64a470d72"), 738.282430386826000m, false, new Guid("1e556685-dcaf-4ba7-a8da-707b17314922"), "Sapiente animi aliquid odio sint et dicta. Eius explicabo quisquam sapiente molestias consequuntur est nemo alias libero. Et vitae qui fugit sunt recusandae occaecati ad quo.", new DateTime(2019, 11, 9, 11, 55, 39, 18, DateTimeKind.Utc).AddTicks(7832), 1 },
                    { new Guid("b61fe030-14ee-4f11-900f-415d0e8e18ab"), 165.345899447208000m, false, new Guid("43752539-10d2-435c-8e68-6e8fd0e53c12"), "Omnis adipisci rem. Laboriosam dolor totam at maxime fugit eum quo. Est voluptatibus neque at dignissimos soluta voluptate dolorem.", new DateTime(2013, 11, 22, 5, 43, 9, 239, DateTimeKind.Utc).AddTicks(2508), 0 },
                    { new Guid("b6691f3e-ecd1-4711-8dbf-d6730aedc1d9"), 846.63052804417000m, false, new Guid("2eff2c74-de12-4b27-85a2-1d8ad47c50d8"), "Possimus eum qui. Voluptas aliquam itaque similique et fugiat nulla rem. Voluptas suscipit voluptas iusto sequi.", new DateTime(2019, 8, 30, 0, 49, 25, 843, DateTimeKind.Utc).AddTicks(4718), 1 },
                    { new Guid("b8345bf2-f355-4800-8757-e9a96e001e23"), 323.84829186902000m, false, new Guid("266ff167-15bf-4dc2-b9b0-c5af915c143e"), "Deleniti maxime vel aperiam aut corporis. Aspernatur autem inventore excepturi in nesciunt enim incidunt. Possimus ipsa laborum est doloribus perferendis.", new DateTime(2015, 3, 21, 4, 34, 12, 708, DateTimeKind.Utc).AddTicks(2159), 0 },
                    { new Guid("b8415288-a1a4-4aba-98d4-68e6541979c7"), 269.231099673126000m, false, new Guid("c1a480a4-7835-4156-8b5c-a0b41663c36b"), "Nam eos eos cum placeat libero eligendi autem.", new DateTime(2020, 11, 28, 19, 56, 58, 93, DateTimeKind.Utc).AddTicks(6970), 0 },
                    { new Guid("b8821661-9178-43fc-8dcf-332ee650be71"), 288.037415266701000m, false, new Guid("61fafe75-8063-4297-b42f-523c53db27db"), "Eius et dolorum occaecati et sapiente veritatis animi sit vitae. Necessitatibus esse enim qui. Et dolor aut officia ut eum. Tenetur cupiditate necessitatibus voluptas.", new DateTime(2013, 10, 4, 8, 23, 54, 387, DateTimeKind.Utc).AddTicks(9220), 99 },
                    { new Guid("b97d8250-0525-4395-85ef-874f13f235fb"), 671.925516684234000m, false, new Guid("2eff2c74-de12-4b27-85a2-1d8ad47c50d8"), "Dicta et fugit sit. Culpa non a ex quae.", new DateTime(2019, 10, 24, 4, 32, 9, 514, DateTimeKind.Utc).AddTicks(5135), 0 },
                    { new Guid("ba32c412-5587-48f4-b3e9-4689c684add4"), 695.742888103904000m, false, new Guid("436f7a1d-cc9e-476f-8dd1-f38e9c870ab9"), "Et similique odit eveniet. Neque nihil et molestias omnis officiis perspiciatis eligendi.", new DateTime(2016, 12, 11, 1, 16, 42, 612, DateTimeKind.Utc).AddTicks(7993), 99 },
                    { new Guid("bc063325-d225-4ca0-a878-eb3c5d5e9e98"), 76.7338601681496000m, false, new Guid("3f0b5db8-a2b4-4607-b7a1-3c277651d860"), "Magni numquam doloremque cum omnis. Fuga et earum nemo perspiciatis illo et. Neque magni occaecati odit consequuntur voluptas dolorum voluptas debitis. Vero tempora aut dolorem.", new DateTime(2017, 3, 24, 2, 39, 19, 553, DateTimeKind.Utc).AddTicks(7833), 0 },
                    { new Guid("bc164b2a-5c1d-4c68-b27f-db16659d3f40"), 173.232114765335000m, false, new Guid("1e556685-dcaf-4ba7-a8da-707b17314922"), "Iusto et odio eos cumque aliquid voluptatem eos praesentium. Quam perspiciatis voluptas occaecati.", new DateTime(2014, 4, 2, 7, 26, 36, 682, DateTimeKind.Utc).AddTicks(3089), 99 },
                    { new Guid("bc5b855b-6ad9-485c-8abe-33753e9fd03c"), 632.629974259385000m, false, new Guid("b80fa2ba-d920-4153-bff5-344f9cef9e6d"), "Praesentium aut aut sint eos sed.", new DateTime(2020, 11, 21, 3, 57, 51, 740, DateTimeKind.Utc).AddTicks(7178), 99 },
                    { new Guid("bcd3db16-7036-4eec-9efc-099b162ccdbd"), 299.341691958596000m, false, new Guid("583be124-ed68-4a81-b641-4dd7fba8bdd0"), "Architecto tempora qui sit ad quisquam sapiente vero.", new DateTime(2015, 5, 30, 12, 21, 49, 147, DateTimeKind.Utc).AddTicks(1088), 99 },
                    { new Guid("bd162d9a-dc10-4aad-889f-1aebfa7ca446"), 140.3391745402000m, false, new Guid("19c2dac9-f6df-445a-92a0-5028b785cdf8"), "Aut occaecati veritatis est voluptates ea dolorem dolorem dolores consequatur. Veritatis recusandae autem asperiores enim consequatur et sunt expedita. Numquam officiis sed error.", new DateTime(2016, 7, 22, 17, 15, 34, 775, DateTimeKind.Utc).AddTicks(7725), 99 },
                    { new Guid("be201483-1994-4cff-867b-493db6594f84"), 974.374575934497000m, false, new Guid("ce962a88-ee32-49bc-b2e2-8ccb5c53dcaf"), "Unde enim quisquam ut.", new DateTime(2012, 2, 17, 5, 47, 14, 799, DateTimeKind.Utc).AddTicks(6136), 99 },
                    { new Guid("be2f8b9c-10ec-4248-bf53-a5a389781685"), 432.222154774458000m, false, new Guid("bf559038-abfa-4ee2-ad60-0cd92ff54447"), "Cupiditate incidunt corrupti nobis earum.", new DateTime(2014, 3, 11, 21, 1, 26, 678, DateTimeKind.Utc).AddTicks(2681), 1 },
                    { new Guid("bf971c21-1d1b-459a-a73c-ee022b3389d0"), 203.076175294776000m, false, new Guid("031addae-12c7-45bc-ad72-837bcbcbe949"), "Nobis possimus facere laborum a quas voluptatibus exercitationem iste sequi. Quis molestias et dolorem voluptatum odio aut quia. Maiores inventore aut voluptas praesentium et veritatis ullam.", new DateTime(2017, 4, 12, 15, 17, 0, 914, DateTimeKind.Utc).AddTicks(8107), 99 },
                    { new Guid("c0622160-998e-4b03-bd81-8b1072879ff6"), 384.484022154842000m, false, new Guid("031addae-12c7-45bc-ad72-837bcbcbe949"), "Omnis voluptatem qui et id ipsa consequatur nesciunt. Neque cum dicta ex dolorum ipsa et laborum vel nesciunt. Nihil neque culpa ipsam. Dolores maxime aut sunt.", new DateTime(2018, 6, 20, 6, 44, 54, 664, DateTimeKind.Utc).AddTicks(7235), 0 },
                    { new Guid("c0656694-dd3a-4c0c-bd62-bf7049b4f24e"), 538.611729929392000m, false, new Guid("436f7a1d-cc9e-476f-8dd1-f38e9c870ab9"), "Voluptates autem sapiente ipsam recusandae quae alias quam nobis eveniet. Et officia magnam consequatur vitae. Itaque labore adipisci. Sit aperiam repellendus sint.", new DateTime(2021, 12, 1, 15, 5, 18, 86, DateTimeKind.Utc).AddTicks(4451), 0 },
                    { new Guid("c09df2ed-f5c2-43b5-a920-d8fa02436c56"), 263.903910474897000m, false, new Guid("ce962a88-ee32-49bc-b2e2-8ccb5c53dcaf"), "Voluptatem quia qui ut rem odit ab necessitatibus voluptas harum. Et sit ab nulla asperiores et.", new DateTime(2019, 3, 3, 1, 53, 54, 392, DateTimeKind.Utc).AddTicks(5666), 99 },
                    { new Guid("c177537d-04c0-4064-8ef1-1a5bea783639"), 883.121993035916000m, false, new Guid("edbda49f-0a72-4a07-9ce0-cccfda5c6e7e"), "Hic sit assumenda voluptates. Molestias veniam qui tempora perspiciatis nemo voluptatem. Pariatur quaerat quia. Et mollitia molestias aspernatur rerum corrupti fugiat perferendis et ut.", new DateTime(2017, 10, 30, 22, 19, 22, 155, DateTimeKind.Utc).AddTicks(7483), 0 },
                    { new Guid("c3551932-bc0d-4ec9-9fa1-2b906992f2d7"), 87.651263804924000m, false, new Guid("bf559038-abfa-4ee2-ad60-0cd92ff54447"), "Excepturi vitae officia deserunt officia aut ut omnis aut doloremque. Magni quidem aliquid aut adipisci. Ullam odio est quia. Dolorem quos hic aut.", new DateTime(2015, 9, 27, 0, 20, 18, 346, DateTimeKind.Utc).AddTicks(5321), 99 },
                    { new Guid("c36676f3-cc4e-4142-98e9-0bfe8f135ba6"), 360.755282185989000m, false, new Guid("2763f4ef-266b-42e5-9d5c-712617d145f7"), "Cum tempora vel consequatur nulla omnis exercitationem. Repellendus tempora earum optio et quisquam laudantium et maxime velit. Qui vel aut debitis et molestias repellendus accusantium totam. Sapiente culpa tenetur numquam sed.", new DateTime(2019, 12, 26, 10, 7, 5, 879, DateTimeKind.Utc).AddTicks(95), 0 },
                    { new Guid("c6f54b1c-5fa2-4551-9236-c47ff801e03f"), 274.048087575711000m, false, new Guid("436f7a1d-cc9e-476f-8dd1-f38e9c870ab9"), "Optio harum quos et autem. Fuga reprehenderit enim omnis veniam accusantium molestiae modi consequatur porro. Fugiat soluta necessitatibus quia sed ut. Qui aut dolor tempore voluptatum tempora veniam.", new DateTime(2017, 10, 22, 6, 56, 45, 687, DateTimeKind.Utc).AddTicks(7149), 1 },
                    { new Guid("c8b4fffb-1be5-49b4-8f17-5da66c17b7ee"), 259.163567460227000m, false, new Guid("436f7a1d-cc9e-476f-8dd1-f38e9c870ab9"), "Et qui aut consectetur magnam facilis suscipit aut. Omnis aut et tempore quas quo ad similique. Explicabo eius voluptas.", new DateTime(2021, 1, 11, 23, 33, 17, 275, DateTimeKind.Utc).AddTicks(9172), 1 },
                    { new Guid("c958c35c-d3d8-407a-a4c5-4a399d86abc3"), 599.459823575028000m, false, new Guid("19c2dac9-f6df-445a-92a0-5028b785cdf8"), "Nemo sunt laboriosam asperiores dolores dolores quisquam rerum. Et ipsam aut magni autem ullam odio.", new DateTime(2013, 9, 27, 22, 0, 7, 347, DateTimeKind.Utc).AddTicks(5499), 99 },
                    { new Guid("c97e7880-a469-49d0-8025-0c857f3971af"), 129.330329305637000m, false, new Guid("edbda49f-0a72-4a07-9ce0-cccfda5c6e7e"), "Occaecati corrupti maxime necessitatibus voluptas consequatur provident. Occaecati nihil reiciendis facere nulla.", new DateTime(2014, 2, 12, 21, 34, 1, 647, DateTimeKind.Utc).AddTicks(7984), 99 },
                    { new Guid("cb7fa344-64fb-49f1-8947-69032ad4e530"), 914.492241175148000m, false, new Guid("436f7a1d-cc9e-476f-8dd1-f38e9c870ab9"), "Omnis aut temporibus in ut minus nihil ut ea perspiciatis. Velit praesentium harum nulla. Nostrum consequatur fugit veniam commodi odio consequatur incidunt iure. Adipisci quos architecto adipisci vel expedita totam.", new DateTime(2013, 7, 28, 8, 59, 3, 276, DateTimeKind.Utc).AddTicks(5899), 99 },
                    { new Guid("cd2fa7f1-08f4-40a9-9a72-95c0b23cfcf6"), 538.324988183109000m, false, new Guid("2eff2c74-de12-4b27-85a2-1d8ad47c50d8"), "Est error asperiores dolore facere.", new DateTime(2012, 6, 22, 1, 22, 11, 810, DateTimeKind.Utc).AddTicks(4024), 0 },
                    { new Guid("d157fce0-b66a-4e7a-a34d-ed7b9804f0ce"), 431.288993900261000m, false, new Guid("03205baf-c226-4094-94a2-6bc60a94cc5d"), "Veniam eligendi enim fugiat dolores. Veritatis iusto enim quia.", new DateTime(2015, 1, 18, 5, 12, 15, 313, DateTimeKind.Utc).AddTicks(6538), 99 },
                    { new Guid("d20d8350-1b51-4984-817d-401c521de656"), 849.496749641773000m, false, new Guid("45827aeb-0b3d-4a6b-9f41-c53eba1c6cbc"), "Aut nulla cupiditate consequatur minima sint.", new DateTime(2015, 12, 21, 22, 55, 30, 533, DateTimeKind.Utc).AddTicks(3203), 1 },
                    { new Guid("d241411d-8621-4577-b513-48ceed9cb082"), 949.456278693869000m, false, new Guid("2763f4ef-266b-42e5-9d5c-712617d145f7"), "Ipsam soluta nihil consequuntur deserunt vel non. Libero eius vero necessitatibus velit natus dolor vel eum. Quia cumque quod.", new DateTime(2016, 3, 10, 11, 2, 3, 773, DateTimeKind.Utc).AddTicks(285), 1 },
                    { new Guid("d46069ba-2660-49d1-ad30-2ce460278848"), 693.648683755556000m, false, new Guid("03205baf-c226-4094-94a2-6bc60a94cc5d"), "Aut quasi et. Nulla ut et hic et nemo tempora. Sed enim exercitationem.", new DateTime(2018, 6, 12, 4, 25, 41, 488, DateTimeKind.Utc).AddTicks(8900), 99 },
                    { new Guid("d4a9be8d-1369-495f-b769-08f682fc31b6"), 88.7613786476719000m, false, new Guid("43752539-10d2-435c-8e68-6e8fd0e53c12"), "Nemo pariatur exercitationem molestiae nostrum quos non quod qui.", new DateTime(2014, 1, 30, 7, 54, 22, 370, DateTimeKind.Utc).AddTicks(9367), 0 },
                    { new Guid("d4cd76ac-6cbe-466a-830c-983746cf6609"), 869.766967527017000m, false, new Guid("2763f4ef-266b-42e5-9d5c-712617d145f7"), "Maxime fugit quia ipsum aliquid neque aut quod ex. Excepturi impedit nobis exercitationem et voluptatum provident dicta ut dicta. Expedita quibusdam non incidunt amet ea tempora sed assumenda sint.", new DateTime(2021, 9, 14, 5, 8, 56, 958, DateTimeKind.Utc).AddTicks(9214), 99 },
                    { new Guid("d7722401-2833-4f56-a4ca-536f8d6dc304"), 939.715109379871000m, false, new Guid("45827aeb-0b3d-4a6b-9f41-c53eba1c6cbc"), "Et asperiores est officiis. Quia sed ut laborum velit sunt. Fuga dolore illo consequatur.", new DateTime(2016, 2, 26, 16, 18, 21, 312, DateTimeKind.Utc).AddTicks(722), 0 },
                    { new Guid("d984b454-f7af-4087-9f87-c47f718c07f4"), 212.659295987289000m, false, new Guid("03205baf-c226-4094-94a2-6bc60a94cc5d"), "Recusandae non occaecati beatae est laboriosam libero dolores. Nihil est sint odio deleniti iusto culpa eligendi aperiam.", new DateTime(2019, 5, 1, 6, 8, 24, 552, DateTimeKind.Utc).AddTicks(1964), 99 },
                    { new Guid("da864e30-b1f8-441b-b772-550976d518ff"), 484.443860455521000m, false, new Guid("61fafe75-8063-4297-b42f-523c53db27db"), "Nesciunt in illo sint perferendis eum.", new DateTime(2013, 4, 23, 8, 13, 38, 267, DateTimeKind.Utc).AddTicks(109), 1 },
                    { new Guid("dc24745d-b4d7-4889-8d4c-efd0bdcd7f59"), 66.78086132445000m, false, new Guid("bf559038-abfa-4ee2-ad60-0cd92ff54447"), "Rerum fuga modi accusamus veniam voluptas nemo non ea.", new DateTime(2019, 4, 1, 19, 56, 31, 376, DateTimeKind.Utc).AddTicks(8135), 99 },
                    { new Guid("dc2e528f-cfbb-4eeb-af96-89d06cc63adf"), 464.707367410147000m, false, new Guid("892dd3cc-afc5-44ee-9c98-e08577c51e3c"), "Nesciunt explicabo cum modi omnis consequatur.", new DateTime(2018, 6, 4, 21, 32, 8, 341, DateTimeKind.Utc).AddTicks(6664), 0 },
                    { new Guid("dc3ca160-2959-4aa2-acc2-c64a6636267f"), 72.6849573958783000m, false, new Guid("1e556685-dcaf-4ba7-a8da-707b17314922"), "Quia ullam cum voluptate voluptate nobis. Eveniet veniam fuga sunt voluptates blanditiis dolorum sint voluptas facere. Quia velit reprehenderit. Laboriosam id esse enim blanditiis ut aliquid non fuga voluptatibus.", new DateTime(2016, 8, 26, 18, 54, 41, 405, DateTimeKind.Utc).AddTicks(8715), 0 },
                    { new Guid("dc7234fd-4a7d-4699-b7fa-9ee799f2fdd4"), 94.4093904543254000m, false, new Guid("583be124-ed68-4a81-b641-4dd7fba8bdd0"), "Culpa dolores voluptatem ut sed aut aut eum incidunt. Tempore provident eos fugiat. Similique optio inventore id laborum sed. Dolorem dolore est dignissimos.", new DateTime(2012, 4, 23, 11, 13, 29, 629, DateTimeKind.Utc).AddTicks(4722), 1 },
                    { new Guid("dce57350-48db-4fed-ada8-92dc88de8985"), 386.309704066034000m, false, new Guid("fe265cbe-a3ca-449b-999a-95a48da566ab"), "Saepe est ut. Non occaecati aut. Voluptas aut accusantium et accusamus eligendi aliquid. Est enim quod voluptatem officia aut dignissimos qui commodi qui.", new DateTime(2013, 6, 22, 14, 18, 33, 555, DateTimeKind.Utc).AddTicks(8165), 0 },
                    { new Guid("e0577296-ea79-48af-a576-e35359d6b747"), 94.7028380800753000m, false, new Guid("031addae-12c7-45bc-ad72-837bcbcbe949"), "Suscipit error vel nostrum consequuntur ab aliquid et quasi sed. Nostrum a praesentium itaque ut omnis. Sed suscipit et veritatis.", new DateTime(2015, 7, 8, 4, 30, 44, 820, DateTimeKind.Utc).AddTicks(7863), 0 },
                    { new Guid("e3a94ce3-29af-44a3-9342-0618be4347c6"), 180.607393156141000m, false, new Guid("19c2dac9-f6df-445a-92a0-5028b785cdf8"), "Ad rerum voluptatem nihil qui quia aliquid saepe incidunt architecto. Delectus esse aspernatur rerum.", new DateTime(2017, 2, 15, 6, 29, 51, 424, DateTimeKind.Utc).AddTicks(8739), 99 },
                    { new Guid("e4f6aacf-bacc-4fd3-91d0-2e4042280291"), 969.19242702725000m, false, new Guid("61fafe75-8063-4297-b42f-523c53db27db"), "Ipsum voluptatibus omnis ex laudantium. Tempora dolore suscipit esse neque. Blanditiis cum sint deleniti ea a et sint optio magni.", new DateTime(2017, 9, 21, 20, 12, 12, 190, DateTimeKind.Utc).AddTicks(3432), 1 },
                    { new Guid("e50dd23c-23e6-40d5-922c-7890399f74bf"), 481.171896385212000m, false, new Guid("266ff167-15bf-4dc2-b9b0-c5af915c143e"), "Nesciunt accusantium ipsam repellendus ad dolores. Voluptatem deleniti omnis quidem debitis illum.", new DateTime(2015, 7, 28, 19, 17, 32, 703, DateTimeKind.Utc).AddTicks(4037), 0 },
                    { new Guid("e57457db-99a6-4e68-ba7a-9d9214bc9e23"), 550.850329672737000m, false, new Guid("3f0b5db8-a2b4-4607-b7a1-3c277651d860"), "Ipsum non facilis sit atque ut aliquam omnis quasi. Vel quos sed. Et dolor quo ex voluptatibus animi vitae tempora velit. Tenetur voluptas sapiente ut excepturi accusantium ut.", new DateTime(2017, 2, 3, 16, 55, 29, 45, DateTimeKind.Utc).AddTicks(7815), 0 },
                    { new Guid("e7532b90-a27c-425e-a4bc-acb0613bc5a9"), 316.565628262029000m, false, new Guid("bf559038-abfa-4ee2-ad60-0cd92ff54447"), "Est commodi libero aperiam est debitis repellendus aut nihil. Est iure reprehenderit nesciunt alias placeat id quis a et. Numquam incidunt aliquam aspernatur perferendis nam eligendi vel. Et voluptatem nisi consequatur dolores.", new DateTime(2015, 12, 18, 4, 35, 11, 686, DateTimeKind.Utc).AddTicks(3666), 1 },
                    { new Guid("e852b5bc-8b8e-4296-b5f1-123246b38353"), 504.320038756171000m, false, new Guid("583be124-ed68-4a81-b641-4dd7fba8bdd0"), "Autem animi tenetur excepturi non eos voluptate blanditiis ab cum. Iste accusamus atque omnis porro beatae dolorem est. Ut soluta officia consequatur non qui voluptatem perferendis debitis earum. In eius labore sint velit tempora qui voluptas dolore est.", new DateTime(2013, 12, 9, 11, 52, 26, 387, DateTimeKind.Utc).AddTicks(7442), 99 },
                    { new Guid("e8b9b02a-8798-4261-9fc4-10df25a954f3"), 378.22104714048000m, false, new Guid("1e556685-dcaf-4ba7-a8da-707b17314922"), "Maxime beatae corporis repellendus omnis nihil.", new DateTime(2016, 2, 2, 10, 34, 52, 710, DateTimeKind.Utc).AddTicks(5686), 1 },
                    { new Guid("eb435ff2-59e9-4146-885c-7f1401aff7d3"), 461.119641018633000m, false, new Guid("b80fa2ba-d920-4153-bff5-344f9cef9e6d"), "Quod deleniti omnis maxime doloremque at modi. Qui et asperiores unde tenetur esse. Sed qui adipisci aspernatur non.", new DateTime(2014, 5, 21, 2, 21, 23, 925, DateTimeKind.Utc).AddTicks(9129), 0 },
                    { new Guid("ebb40de8-781c-4af0-ab63-1ed8eccceffe"), 996.872062869352000m, false, new Guid("19c2dac9-f6df-445a-92a0-5028b785cdf8"), "Iste quisquam ipsum sequi eius qui eius corrupti eum. Voluptatem numquam quas autem modi ut dicta inventore.", new DateTime(2016, 11, 9, 9, 6, 50, 889, DateTimeKind.Utc).AddTicks(9456), 99 },
                    { new Guid("ebdbaea3-8447-468a-8814-7006b58f71a0"), 210.721761081852000m, false, new Guid("031addae-12c7-45bc-ad72-837bcbcbe949"), "Sed numquam quia. Autem iure odio tenetur incidunt et qui ipsam. Dolorum esse praesentium modi distinctio nisi.", new DateTime(2020, 6, 15, 2, 26, 13, 989, DateTimeKind.Utc).AddTicks(3411), 0 },
                    { new Guid("ec490a42-006e-4d9c-a25c-5e91762948c9"), 65.2994179590322000m, false, new Guid("c1a480a4-7835-4156-8b5c-a0b41663c36b"), "Nihil consequuntur vero pariatur a quo vitae cumque nemo molestiae. Voluptatum repellat nobis necessitatibus hic consequatur est dolor optio excepturi.", new DateTime(2021, 12, 11, 7, 59, 18, 856, DateTimeKind.Utc).AddTicks(8674), 0 },
                    { new Guid("ecc944ce-0015-484b-b7d0-8946cf98a084"), 301.119583585396000m, false, new Guid("c1a480a4-7835-4156-8b5c-a0b41663c36b"), "Vero beatae qui. Est provident aut.", new DateTime(2012, 11, 26, 5, 57, 36, 881, DateTimeKind.Utc).AddTicks(297), 99 },
                    { new Guid("ef220dce-95fb-49e3-8426-e8e9af05520e"), 495.507186398841000m, false, new Guid("1e556685-dcaf-4ba7-a8da-707b17314922"), "Cupiditate alias eos neque. Et rerum quas sunt veritatis quos nulla distinctio officia optio. Eius molestiae quos qui est. Voluptatem suscipit autem qui est praesentium magnam doloribus vero molestias.", new DateTime(2012, 5, 11, 14, 15, 41, 625, DateTimeKind.Utc).AddTicks(5054), 1 },
                    { new Guid("ef3f76b7-21c2-47e1-9f55-226f1965f718"), 471.732562052565000m, false, new Guid("45827aeb-0b3d-4a6b-9f41-c53eba1c6cbc"), "Neque magnam facilis rerum ratione sint cupiditate magnam aperiam suscipit. Odit culpa ab.", new DateTime(2016, 3, 14, 14, 8, 45, 723, DateTimeKind.Utc).AddTicks(4001), 1 },
                    { new Guid("efd413a9-5491-4b27-9ee7-bb9887cd1f92"), 854.966721612707000m, false, new Guid("ce962a88-ee32-49bc-b2e2-8ccb5c53dcaf"), "Molestiae qui sit. Qui maxime est quod unde illum nesciunt consequatur magnam.", new DateTime(2019, 2, 20, 3, 57, 38, 418, DateTimeKind.Utc).AddTicks(8681), 1 },
                    { new Guid("f0324158-e6a2-4671-b9c0-778bbf3c622f"), 162.109976449608000m, false, new Guid("edbda49f-0a72-4a07-9ce0-cccfda5c6e7e"), "Illum quos aut enim et ut aperiam aut architecto. Accusamus autem id explicabo. Alias expedita veritatis sit omnis nam rerum molestias saepe.", new DateTime(2014, 9, 8, 6, 22, 55, 896, DateTimeKind.Utc).AddTicks(1048), 1 },
                    { new Guid("f2bfca95-51a4-4f02-bec0-f9992c4c48d3"), 705.382387808567000m, false, new Guid("031addae-12c7-45bc-ad72-837bcbcbe949"), "Accusantium repellat quia iure impedit atque aliquid id pariatur.", new DateTime(2015, 10, 27, 0, 18, 50, 897, DateTimeKind.Utc).AddTicks(6771), 0 },
                    { new Guid("f410006d-297f-48e9-9c90-c60c379dc577"), 858.142644399228000m, false, new Guid("19c2dac9-f6df-445a-92a0-5028b785cdf8"), "Voluptate consequatur voluptatem perferendis maxime. Ea esse labore perspiciatis tempora consectetur.", new DateTime(2014, 1, 12, 22, 5, 57, 550, DateTimeKind.Utc).AddTicks(6674), 99 },
                    { new Guid("f68479d5-fe14-46f8-b5d9-df2c28e13e86"), 337.609219618115000m, false, new Guid("19c2dac9-f6df-445a-92a0-5028b785cdf8"), "Autem voluptatem commodi dolorum quidem nisi molestiae. Harum id beatae autem quo ut beatae aut rerum. A et sint ad. Molestias nostrum unde voluptatibus quis.", new DateTime(2022, 1, 5, 21, 21, 50, 530, DateTimeKind.Utc).AddTicks(9481), 1 },
                    { new Guid("f87cf802-bca0-4f2e-a931-4b0b4208a0cd"), 611.302090548085000m, false, new Guid("583be124-ed68-4a81-b641-4dd7fba8bdd0"), "Esse dolores voluptates natus ea mollitia architecto doloremque. Omnis fugit sit nemo molestiae perspiciatis eos sed temporibus velit. Enim ab sed itaque numquam nostrum quis commodi.", new DateTime(2020, 1, 27, 5, 7, 53, 134, DateTimeKind.Utc).AddTicks(3088), 99 },
                    { new Guid("f8f0000b-a1c7-4d5d-980f-6ad6f32ad3b1"), 404.926922281926000m, false, new Guid("436f7a1d-cc9e-476f-8dd1-f38e9c870ab9"), "Dignissimos sint error ut reprehenderit eius dicta molestiae non odit.", new DateTime(2020, 7, 11, 15, 46, 50, 57, DateTimeKind.Utc).AddTicks(7963), 99 },
                    { new Guid("fa1079d7-df23-43eb-9697-88ec3ac1ceeb"), 166.669371358707000m, false, new Guid("892dd3cc-afc5-44ee-9c98-e08577c51e3c"), "Vel cum enim id consequatur occaecati et.", new DateTime(2021, 9, 12, 10, 39, 42, 801, DateTimeKind.Utc).AddTicks(3169), 1 },
                    { new Guid("fa570e16-4650-4c1a-8757-ded142ced932"), 603.204903580068000m, false, new Guid("edbda49f-0a72-4a07-9ce0-cccfda5c6e7e"), "Vitae sit et hic laudantium repellat aut iure eaque. Fuga quaerat eos aspernatur modi. Nostrum ut deserunt autem eum ea vero possimus tenetur.", new DateTime(2016, 12, 10, 3, 28, 11, 950, DateTimeKind.Utc).AddTicks(9579), 1 },
                    { new Guid("fad572bb-6870-4a67-a593-1d967c04fa28"), 367.373532088778000m, false, new Guid("b80fa2ba-d920-4153-bff5-344f9cef9e6d"), "Harum mollitia voluptas amet et omnis eum ullam maxime ex. Voluptate voluptas illum itaque. Vel magni distinctio soluta odio.", new DateTime(2015, 11, 7, 6, 25, 22, 736, DateTimeKind.Utc).AddTicks(9563), 99 },
                    { new Guid("fd44c255-df13-46c9-aa29-f9928ae8f949"), 350.152019689501000m, false, new Guid("266ff167-15bf-4dc2-b9b0-c5af915c143e"), "Distinctio sapiente rerum molestiae voluptatem sed rerum ducimus ratione eaque. Nemo iure amet tempora dolores porro voluptas. Voluptas consequuntur et amet eos qui. Beatae impedit dolor non eius excepturi minus alias qui.", new DateTime(2021, 1, 12, 7, 58, 54, 345, DateTimeKind.Utc).AddTicks(7326), 1 },
                    { new Guid("fda29e4b-ce04-4768-a009-a57060146f5d"), 856.2803361291000m, false, new Guid("c1a480a4-7835-4156-8b5c-a0b41663c36b"), "Aliquam facilis est officia quas facilis commodi doloribus. Sit et cum rerum nam.", new DateTime(2013, 1, 27, 14, 16, 40, 964, DateTimeKind.Utc).AddTicks(1551), 0 },
                    { new Guid("fe3276f1-ced8-4f39-8c12-f66b3d534743"), 160.370400456596000m, false, new Guid("45827aeb-0b3d-4a6b-9f41-c53eba1c6cbc"), "Qui aut quia sapiente. Voluptates maxime odio eligendi sed commodi atque consequuntur.", new DateTime(2021, 2, 23, 13, 49, 8, 864, DateTimeKind.Utc).AddTicks(5592), 99 },
                    { new Guid("fe5853f4-e926-452f-ab90-8d168b59472f"), 517.59055946093000m, false, new Guid("b80fa2ba-d920-4153-bff5-344f9cef9e6d"), "Magnam excepturi totam sequi dolores quas magni nam. Placeat qui quis sunt aliquam quod.", new DateTime(2021, 7, 6, 14, 55, 53, 213, DateTimeKind.Utc).AddTicks(3736), 99 },
                    { new Guid("fef091d5-2dcf-487e-b743-c812c59c2c86"), 483.133557626153000m, false, new Guid("45827aeb-0b3d-4a6b-9f41-c53eba1c6cbc"), "Expedita nisi labore est veniam. Et nobis quas alias.", new DateTime(2015, 2, 24, 18, 56, 4, 414, DateTimeKind.Utc).AddTicks(4143), 0 }
                });

            migrationBuilder.InsertData(
                table: "SubscriptionsPaid",
                columns: new[] { "MemberId", "Year", "April", "August", "December", "February", "January", "July", "June", "March", "May", "November", "October", "September" },
                values: new object[,]
                {
                    { new Guid("031addae-12c7-45bc-ad72-837bcbcbe949"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("031addae-12c7-45bc-ad72-837bcbcbe949"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("031addae-12c7-45bc-ad72-837bcbcbe949"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("03205baf-c226-4094-94a2-6bc60a94cc5d"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("03205baf-c226-4094-94a2-6bc60a94cc5d"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("03205baf-c226-4094-94a2-6bc60a94cc5d"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("03205baf-c226-4094-94a2-6bc60a94cc5d"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("19c2dac9-f6df-445a-92a0-5028b785cdf8"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("19c2dac9-f6df-445a-92a0-5028b785cdf8"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("19c2dac9-f6df-445a-92a0-5028b785cdf8"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("19c2dac9-f6df-445a-92a0-5028b785cdf8"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("1e556685-dcaf-4ba7-a8da-707b17314922"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("1e556685-dcaf-4ba7-a8da-707b17314922"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("1e556685-dcaf-4ba7-a8da-707b17314922"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("1e556685-dcaf-4ba7-a8da-707b17314922"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("1e556685-dcaf-4ba7-a8da-707b17314922"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("1e556685-dcaf-4ba7-a8da-707b17314922"), 2020, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("1e556685-dcaf-4ba7-a8da-707b17314922"), 2021, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("266ff167-15bf-4dc2-b9b0-c5af915c143e"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("266ff167-15bf-4dc2-b9b0-c5af915c143e"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("2763f4ef-266b-42e5-9d5c-712617d145f7"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("2eff2c74-de12-4b27-85a2-1d8ad47c50d8"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("2eff2c74-de12-4b27-85a2-1d8ad47c50d8"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("2eff2c74-de12-4b27-85a2-1d8ad47c50d8"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("2eff2c74-de12-4b27-85a2-1d8ad47c50d8"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("2eff2c74-de12-4b27-85a2-1d8ad47c50d8"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("2eff2c74-de12-4b27-85a2-1d8ad47c50d8"), 2020, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("2eff2c74-de12-4b27-85a2-1d8ad47c50d8"), 2021, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("3f0b5db8-a2b4-4607-b7a1-3c277651d860"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("3f0b5db8-a2b4-4607-b7a1-3c277651d860"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("3f0b5db8-a2b4-4607-b7a1-3c277651d860"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("3f0b5db8-a2b4-4607-b7a1-3c277651d860"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("45827aeb-0b3d-4a6b-9f41-c53eba1c6cbc"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("45827aeb-0b3d-4a6b-9f41-c53eba1c6cbc"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("583be124-ed68-4a81-b641-4dd7fba8bdd0"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("583be124-ed68-4a81-b641-4dd7fba8bdd0"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("61fafe75-8063-4297-b42f-523c53db27db"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("61fafe75-8063-4297-b42f-523c53db27db"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("61fafe75-8063-4297-b42f-523c53db27db"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("61fafe75-8063-4297-b42f-523c53db27db"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("892dd3cc-afc5-44ee-9c98-e08577c51e3c"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("892dd3cc-afc5-44ee-9c98-e08577c51e3c"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("892dd3cc-afc5-44ee-9c98-e08577c51e3c"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("892dd3cc-afc5-44ee-9c98-e08577c51e3c"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("892dd3cc-afc5-44ee-9c98-e08577c51e3c"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("892dd3cc-afc5-44ee-9c98-e08577c51e3c"), 2020, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("b80fa2ba-d920-4153-bff5-344f9cef9e6d"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("bf559038-abfa-4ee2-ad60-0cd92ff54447"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("bf559038-abfa-4ee2-ad60-0cd92ff54447"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("bf559038-abfa-4ee2-ad60-0cd92ff54447"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("bf559038-abfa-4ee2-ad60-0cd92ff54447"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("ce962a88-ee32-49bc-b2e2-8ccb5c53dcaf"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("ce962a88-ee32-49bc-b2e2-8ccb5c53dcaf"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("ce962a88-ee32-49bc-b2e2-8ccb5c53dcaf"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("ce962a88-ee32-49bc-b2e2-8ccb5c53dcaf"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("ce962a88-ee32-49bc-b2e2-8ccb5c53dcaf"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("ce962a88-ee32-49bc-b2e2-8ccb5c53dcaf"), 2020, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("ce962a88-ee32-49bc-b2e2-8ccb5c53dcaf"), 2021, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("edbda49f-0a72-4a07-9ce0-cccfda5c6e7e"), 2015, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("edbda49f-0a72-4a07-9ce0-cccfda5c6e7e"), 2016, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("edbda49f-0a72-4a07-9ce0-cccfda5c6e7e"), 2017, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("edbda49f-0a72-4a07-9ce0-cccfda5c6e7e"), 2018, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("edbda49f-0a72-4a07-9ce0-cccfda5c6e7e"), 2019, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("edbda49f-0a72-4a07-9ce0-cccfda5c6e7e"), 2020, true, true, true, true, true, true, true, true, true, true, true, true },
                    { new Guid("edbda49f-0a72-4a07-9ce0-cccfda5c6e7e"), 2021, true, true, true, true, true, true, true, true, true, true, true, true }
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
