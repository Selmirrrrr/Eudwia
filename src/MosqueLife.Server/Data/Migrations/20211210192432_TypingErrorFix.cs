using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MosqueLife.Server.Data.Migrations
{
    public partial class TypingErrorFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionPaid_Members_MemberId",
                table: "SubscriptionPaid");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubscriptionPaid",
                table: "SubscriptionPaid");

            migrationBuilder.DropIndex(
                name: "IX_SubscriptionPaid_MemberId",
                table: "SubscriptionPaid");

            migrationBuilder.DropColumn(
                name: "MemeberId",
                table: "SubscriptionPaid");

            migrationBuilder.AlterColumn<Guid>(
                name: "MemberId",
                table: "SubscriptionPaid",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "Members",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubscriptionPaid",
                table: "SubscriptionPaid",
                columns: new[] { "MemberId", "Year", "Month" });

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
                columns: new[] { "Id", "BirthDate", "City", "Firstname", "HouseNumber", "Language", "Lastname", "MemberSince", "StateId", "StreetLine1", "StreetLine2", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), new DateOnly(1983, 12, 22), "Ernesttown", "Clara", "7048", 1, "Cronin", new DateOnly(2020, 12, 20), new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "87773 Pagac Mount", "Apt. 499", "68158-7579" },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), new DateOnly(1983, 12, 22), "South Nina", "Clara", "50879", 0, "Cronin", new DateOnly(2016, 6, 12), new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "194 Barrows Brook", "Apt. 143", "09229" },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), new DateOnly(1983, 12, 22), "Aurelioside", "Clara", "7767", 2, "Cronin", new DateOnly(2013, 9, 21), new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "3468 Daisha Camp", "Suite 107", "79978-3813" },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), new DateOnly(1983, 12, 22), "South Keaganberg", "Clara", "5037", 1, "Cronin", new DateOnly(2016, 6, 25), new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "37454 Shanna Heights", "Suite 892", "01842-5060" },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), new DateOnly(1983, 12, 22), "East Kadeshire", "Clara", "629", 0, "Cronin", new DateOnly(2017, 12, 27), new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "3566 Connor Ranch", "Apt. 007", "82761-0009" },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), new DateOnly(1983, 12, 22), "New Ricohaven", "Clara", "907", 2, "Cronin", new DateOnly(2014, 12, 18), new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "5238 Zakary River", "Suite 067", "62059-5524" },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), new DateOnly(1983, 12, 22), "Esthermouth", "Clara", "922", 1, "Cronin", new DateOnly(2014, 6, 22), new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "719 Kertzmann Isle", "Apt. 403", "21495" },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), new DateOnly(1983, 12, 22), "Hudsonstad", "Clara", "165", 0, "Cronin", new DateOnly(2013, 10, 3), new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "7589 Madeline Mission", "Apt. 255", "48769-0744" },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), new DateOnly(1983, 12, 22), "Port Amparo", "Clara", "126", 2, "Cronin", new DateOnly(2015, 10, 2), new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "569 Gleichner Streets", "Suite 197", "79959-0473" },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), new DateOnly(1983, 12, 22), "East Floychester", "Clara", "646", 2, "Cronin", new DateOnly(2018, 2, 28), new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "888 Francesco Trafficway", "Suite 847", "64084-0467" },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), new DateOnly(1983, 12, 22), "Isabellefurt", "Clara", "650", 0, "Cronin", new DateOnly(2017, 3, 28), new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "9891 Eusebio Parkway", "Suite 682", "11931-1551" },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), new DateOnly(1983, 12, 22), "Edwinatown", "Clara", "44082", 2, "Cronin", new DateOnly(2012, 6, 29), new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "706 Schulist Motorway", "Apt. 835", "71034-4170" },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), new DateOnly(1983, 12, 22), "Lake Bereniceview", "Clara", "78641", 1, "Cronin", new DateOnly(2016, 2, 24), new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "0853 Streich Fork", "Apt. 213", "09715" },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), new DateOnly(1983, 12, 22), "North Vita", "Clara", "9853", 1, "Cronin", new DateOnly(2012, 6, 28), new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "221 Legros Hollow", "Apt. 091", "45016-4478" },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), new DateOnly(1983, 12, 22), "Jamirfurt", "Clara", "2227", 1, "Cronin", new DateOnly(2019, 6, 29), new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "768 Jovani Ramp", "Apt. 143", "28562" },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), new DateOnly(1983, 12, 22), "Beierfurt", "Clara", "036", 0, "Cronin", new DateOnly(2015, 9, 3), new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "6006 Heller Park", "Suite 060", "02535-4020" },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), new DateOnly(1983, 12, 22), "Quintonhaven", "Clara", "41991", 0, "Cronin", new DateOnly(2020, 6, 5), new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "477 Hammes Isle", "Apt. 139", "49061" },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), new DateOnly(1983, 12, 22), "Muellerborough", "Clara", "79564", 2, "Cronin", new DateOnly(2013, 3, 18), new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "061 Leilani Alley", "Apt. 818", "12977" },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), new DateOnly(1983, 12, 22), "Emilioview", "Clara", "9698", 1, "Cronin", new DateOnly(2020, 6, 4), new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "49052 Gaylord Meadows", "Apt. 724", "50368" },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), new DateOnly(1983, 12, 22), "South Alberthamouth", "Clara", "715", 1, "Cronin", new DateOnly(2020, 8, 9), new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"), "61720 Durgan Summit", "Apt. 758", "24345" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "MemberId", "Note", "PaymentType" },
                values: new object[,]
                {
                    { new Guid("0299b1c6-d691-43e9-9bba-a3c5f49ca89b"), new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), "ꤷ䈠ꌫ⫭碅唞鋏齉⨽䲼띛ꠊ铛䃥蹛ᓀ殾蟧꿀", 1 },
                    { new Guid("02b893d1-0f36-405b-a975-3b2e2aedec19"), new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), "ꮒ㨬�厑큇蕹䑩걭ʝ㞷慖ᵠ㣊䟘搉貙캔ꒆ塚", 99 },
                    { new Guid("036530d7-0b1f-4e47-88fb-94ffb57c327c"), new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), "◱쥵ꚟ瓎ᒦ童猁櫔ꡄﳽ�븺跺ᬪ聵캖⑱㝻큡", 99 },
                    { new Guid("036999c9-6d44-4433-b665-4b8fc5a89c09"), new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), "⹱夅퉌�壥仛ꆥ棼걫❷㸄�戔ꅧ䀌퍸℥著⟘", 0 },
                    { new Guid("07647051-dac6-4fcc-a8a2-fc124a037d21"), new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), "᥍嗠駋뷀偪䧎ꑸ꒾ᙦ쩖쐲�˚⃐ꡌ勌≝藟", 0 },
                    { new Guid("09984f5b-bfa3-4a52-85be-87b52d79b820"), new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), "哏붫膂증忉산꩚뙩䥅儱䓖噩쬌蠿㍆豕�", 1 },
                    { new Guid("09f87079-008a-46ff-8800-63378e9e004c"), new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), "뵼췯�랚㗥竍ᦱ১⯟㌃壚䁟쿮㝜㠸≨潄ꋻ", 99 },
                    { new Guid("0a8d3c2f-5f5c-4424-9787-50cca6618580"), new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), "⩦갟ᄤ꓊휚쭝⑚②쯅ጸႹ䥴Ƣ⺑ޚ䮳莊䋑", 99 },
                    { new Guid("0c4e9f46-d21d-427c-88d7-f3505560399f"), new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), "쭋崹┆漜蛀⟣淤೑땃⩆暟勩쉤躈븥쇾浤�", 0 },
                    { new Guid("0ec1d47b-d80e-4b88-8e7b-82ba6333e44b"), new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), "怂鉡ꧧᮞᩧ䁈㠭嬦ƛ︑㐌襡䈕姤㊀", 0 },
                    { new Guid("0f07ed40-3c65-46b7-b23b-bc86bec1f768"), new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), "��ኆை믎稭៧㔎₊ѣ韮͂纥쪸촋䋦栆ހ", 0 },
                    { new Guid("0faae868-d6a1-4d55-b203-079f40f3d71c"), new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), "䒃蝝搦ﳽꂁ䔚謻혇ᶵꡜ爫怰⚲꜉寫訢俨", 99 },
                    { new Guid("10439635-6d82-4ca6-bea9-ddf5007ee35d"), new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), "뀯뼬Ẉ瞯䔻뾟ㆶ뭚쥅״̜ﳲॵ侑簱䡆幮", 99 },
                    { new Guid("10911b73-964d-49eb-8fb5-70951fa02021"), new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), "ⷈ毛걳蠾袩怋烥ⵙᒜ슺糞ࢇ㲊ᑀ䑷咇昋将", 99 },
                    { new Guid("11c7b9bb-e29e-42b5-ae6b-2426ef31fa1f"), new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), "茏ᎋ٧꺂斊衦敀ᝆ兏ጀꎿ둓둈㜆⟡줖㚴ꪼ繲", 99 },
                    { new Guid("11d676df-54d0-468a-ab4a-318269532d54"), new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), "㈌緧海挒떌쏨┤뉎͏㫒謄峒Ϲ䄳껿ǰꮮ傩�", 1 },
                    { new Guid("11e9daf3-a5dd-471a-9406-106cffc937d3"), new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), "찷襲臟﴿�涫푉ಢ鄨淧歰ᓗ撓睴뛸筙됯ᄹ", 0 },
                    { new Guid("11ff9b1a-6450-4d29-a2d1-3c4ec75a336b"), new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), "秫坔쫚㘧䘳랖᭏墅髾稓쿌䧲跪삩瑴㭓䚓뉖", 99 },
                    { new Guid("179db9da-7a92-49bc-8404-bb0bc99b82e6"), new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), "豂닐鉭⌑✧뿀홸㾻䏓ఀ䘓肉ﯱꀊ□ꗾັ⎫ꢯ", 1 },
                    { new Guid("19aa4f31-b839-439e-bc91-13faee7ad8c6"), new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), "ែ蟅푵筬�픟�憋駲髀䞐蕇≠恴각泟餉༇", 0 },
                    { new Guid("19b79715-a021-495b-bfbd-7a43abe4ef85"), new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), "భ庭욼ឯ勁쭙ㄕ緐㸃㩙⟂Ⱆﺓর箌挆ꏿꨅ킵", 0 },
                    { new Guid("19f47dfd-173c-4787-964d-d133bae1800c"), new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), "߅鮫小藴ㅶꍁ阘ㅵ栠串Һ଱뱒곡蜣沫闷癙瑺", 99 },
                    { new Guid("1ce78307-f537-4734-b0ac-6e36b1fa4ab2"), new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), "뷄盏㛤찌뗹郔�禸涮ᷔ銁셾ℰ啃躛꾱棬ཀྵ갭䒗", 0 },
                    { new Guid("1d158dbe-6ec1-41ca-99ad-8067b1c3679a"), new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), "尼ﮕ꬏씓�뽡Ｋ堸鱾炿夌⚩鮭ꁷ䴹ퟶ瀋ẻ", 0 },
                    { new Guid("1e57622f-2d5d-4d7e-bca4-810b3d868d11"), new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), "ꕨ匍㏍팟괛泎ᱛ㯥⳦廖ッ箙鈁䋔썮柉", 0 },
                    { new Guid("1e627596-543d-42a7-b9a6-3041a6477024"), new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), "翩挺℄理飷࿌䢻㭌哊䖊볷÷舸ꎏ⳰ਖ聠䃑柂", 99 },
                    { new Guid("21241f98-de48-4621-895f-85769fc3546d"), new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), "쯹鉥〮⺝㮂嵔ﺞ꩹廼鮮◖屶៵举ᐐ䐹˪㠩", 1 },
                    { new Guid("232b2392-3063-4c12-8051-6e1de77bb141"), new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), "薸筳쟣촰鮬۝୑앏薲姴뎈꛰⒫友몈櫥�㠞", 0 },
                    { new Guid("242d3e5b-d59b-46db-abc8-8ff5dbd2c92a"), new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), "獤ꤦ搊舭犆깆㪇♹칫햳䆾咡뱓㯑ꌋ䯕ᵎ", 99 },
                    { new Guid("24337f2f-5567-43ad-bbb8-3512aaad5c41"), new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), "㕸龙�㹎뗎ྕ⬬㤨ꆺꚢ᭼솉쳯儽䀝ĳ껥⃴", 0 },
                    { new Guid("2461e8df-a701-4f9f-a6e8-6254c2bd0a8c"), new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), "ꐎ赔೏措妜೿䰬䖻꺧䮣츨ْ࠽䆥�⏆髎ꖆ詼͵", 0 },
                    { new Guid("2462f2d3-0ffb-4431-9fc3-62dc316494b8"), new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), "攩爛ᘋ՛翰㯰䞁ꊡ뜉ᾠ擹詠쩅햷৸瑖�", 0 },
                    { new Guid("24799b6c-6c12-44ff-9f65-60d4fa2f58c7"), new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), "䶤菝땩ⴻ엞៕㗐搣ڼ朠躁⦍痠苩䵻ﳈ㟄ᝩ", 99 },
                    { new Guid("24caeda4-ab79-4d6d-b8f1-89c320ef4b21"), new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), "석蓷ﾖງ⣠ꅩ硫铎钤합ࠤ䶭ԁ螙ꊊ堞ᒅⲄ噧撇", 1 },
                    { new Guid("259950c1-3873-4f60-b4d5-45cbabfe4c2a"), new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), "푗锡骀蝐㜊䳱⏳♸ꊶ곦蕆뭛ዔ집膏쀙ᾩꦢ㓜", 1 },
                    { new Guid("269b7641-c49c-43a2-9031-56532bb71a9b"), new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), "㎓憢�ﻦᚣ궢謨驒뗙㚅㴼唂裰愞漺蔼磗溚冢", 99 },
                    { new Guid("273843a9-ef1e-475e-8c59-ac7337ba0a90"), new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), "胅걹簈砀婥聝끽畉む⽐폹䚃뽆䞉隞━쭲븕洶黆", 1 },
                    { new Guid("2ae15c91-0ffe-42d3-9d8d-385663a547e5"), new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), "姪┶閘↔㝄祗ㅗ�ᙆ飔솕ᆡ剴옑䃾䱸ᬁ䆟", 0 },
                    { new Guid("2b7e5cc4-a707-4895-bfe5-6f08c11fc574"), new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), "뺩ꮵำﺞ䜁ⶰ㬝檍歗⠒诎쿡ﱠ辿虗뿞β跧퀣", 99 },
                    { new Guid("2c72ab14-4781-46a0-a339-dfb0881b2497"), new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), "⯲珴㝂ᡗ掖䝊ꪓ䈂㧑�㊪娚셻ᨆ坩✡皸똼㜌", 0 },
                    { new Guid("2da9bf22-da72-493f-bac0-82ecaacd796a"), new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), "㇍⊢ꅲ࢈ϊ흼⳾틘螵䖘縯쾬̗㰫̼릆닻恰", 1 },
                    { new Guid("3011139c-5e45-42bc-98f8-0b37fc233ddb"), new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), "哄ڐ쇦環老䘭鴷蔧漝낱䎉ꂄ㿀㛇�ほꈔ", 0 },
                    { new Guid("30a745a1-8d3f-41a2-a66e-82e82f6e7372"), new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), "룺埈ฅ�竕㱜鐴⽹ꔬ鶲㣁匉ℍᬿՠ琀͓", 0 },
                    { new Guid("30aa2f8f-b57e-4c65-a23e-1bd1497bbcfe"), new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), "㮈䤝쮩䦠툇稝豜鿒蹿⮝읡矷銟묶୊鍥", 99 },
                    { new Guid("34053bc9-dc33-4ea6-95a2-a44fd1c0943e"), new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), "蚐败짚諹몀샚쮌䔷붅Ꝡ두㪯湾ꃬ碅ꠄ샫阐", 1 },
                    { new Guid("3424a46b-d79e-4452-a0c6-f8967a0cf28a"), new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), "쉴෍䵁皑뀊飉멦쩗㦄횅窑㑲掁馳卻〄๥Ꮥ", 0 },
                    { new Guid("346cbc6f-c8e3-41d7-8f48-569acfe2e0e4"), new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), "๪殌嘲拙滯僅臋蹪ᗜ耊ᨽ�䈲뺎嬚녀燮", 1 },
                    { new Guid("347d9547-de25-4653-a9e1-6dea195bcae5"), new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), "Ȕ죽莫ᨪ쏈鉆黟ꈜ玾쪆蔄컈줢弒듄编㗺鲛꩞", 99 },
                    { new Guid("35c45c37-f757-488d-a25e-2de63753b8fa"), new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), "ឍ㉷鮶志�澅Ⅵ続蘀忣┮퀼뵯䲔竏뇢�", 99 },
                    { new Guid("3707ce56-f216-4c70-80d9-deed4f7cd054"), new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), "燐壀咞⦅ࣿ�輘駴䢢渪瀃홎襙砦ᕄ畕ꡎﾰ㝎纗", 1 },
                    { new Guid("386eddb8-07d1-434f-a52c-40b6b2744031"), new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), "⟃첣峼䮄奒丿㔡뵭䨒埝觢镋ⰽ∬싇䥤屬ㅭ뻵", 0 },
                    { new Guid("3c7b1e26-6bc3-4dd0-8248-55e5188a64af"), new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), "溱槮쭐䨅驣连幛ෆ잼泼첓椤�鸲褂嬠ٝ겕", 1 },
                    { new Guid("3c839503-d62e-49ce-9a0f-fad270cf51c1"), new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), "☯洪㺱嘇뢍䴖䢆㦛դ瓀闅迺ƫ瓀遪롐缸�窅킩", 99 },
                    { new Guid("3cdcd982-241a-4a72-aac6-bb009ff60cb0"), new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), "ς椈遒㫖퓯�ﺗ䏭╼蟯䁏�局ׁ䚘⦿蘈贩嗝", 0 },
                    { new Guid("3cf8d38f-f21d-47d4-9c1d-6c2c20e133e9"), new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), "᭢檇쟊炠댮➆올炟臺콾圵❵⧸笥墍帒蹝秃", 0 },
                    { new Guid("3e3f6637-09b8-4808-b130-2c235207b390"), new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), "ᕓ톔콃ધ퇢샸纩�磢漓씯蘢줤띋ሇ獎겉虷", 99 },
                    { new Guid("43d2a8c3-0991-406d-b13e-c6cc6ab0e942"), new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), "⹳惔衙㢰荠ᧆ鼔䴦�剈炌경缃䍍ݏ뤼၄", 1 },
                    { new Guid("44f0bb3f-f4df-4a79-b7cc-093c746398e5"), new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), "↹钼閡ࡊ鑓뺤數喳엊໏⢂찬㴩뀫ᬞ䑴庸", 1 },
                    { new Guid("4631af53-5896-407a-bcc0-ae8a8b07d1da"), new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), "嬚垙藍Ǭ﵂竿῎㭿㣔몰襺⽔舏ﻝ㣦愨㋅", 99 },
                    { new Guid("4639b988-7140-40c3-b602-e3b87da8bb0c"), new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), "㱪ਏ킬⭝᳽燅嚬�刔㑌﮹㼙뜜쩟ꘑᔑ", 1 },
                    { new Guid("4ba216a7-8639-4ee2-8cb9-a881936b0504"), new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), "⁕꜐釠�㩚懀ㄩ짲ׄ汹⊜ꀴፕ볛랖迆䱞", 0 },
                    { new Guid("4be7d434-e2be-4ff7-9cda-e88d47d9e2a2"), new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), "�⹃슃瀌╼熺幷♪ꂸ�薍�䐷䐜໮�凬恄蒬", 0 },
                    { new Guid("4bfd8669-9339-4501-bdfb-3110432d7cf1"), new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), "쫓合콐㣶堳⒡敖Є륈Ȥ礀끄趡㓼៰鮫ਝ踘搛㝮", 1 },
                    { new Guid("4c5c1354-a37a-4dd7-9910-b38fff6189e3"), new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), "뢟嵏ঊ⟰뙙叫ᧄ뢋㔡긜⩗涄吣ࣜ�闸漗", 0 },
                    { new Guid("4e39ec92-158c-4880-acb0-c43654488b60"), new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), "૴衷ᴙ믝炉ꛪ킔䶡헰謕힔㮻Ắᨚ싅�Ꮒ䉝뜵", 1 },
                    { new Guid("50283af1-515c-4c16-b3e9-c22dc355f4d2"), new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), "㺇껭଱婜ɒႀᢉ浜濂씍놲⫓鳺૝옥ቿ딋", 99 },
                    { new Guid("50928a4d-8df8-4563-ac2a-d1fb57294393"), new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), "쿞ﹰ涰䠔⸑嶩ϭ魳徘ꛇ輍昅槳㈓潔", 1 },
                    { new Guid("52341505-93cc-4ef3-bdc2-b64ce41a808d"), new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), "㳂䰨槛呠㾸끨꯫臥蠶㊱ꓷ⌙쪜筴쎢᧓霈䫓ﭗ⇼", 99 },
                    { new Guid("5248e527-d5be-461d-b2bb-58071c0a78dd"), new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), "櫔戌⺧ĩ삞䆐潝映춤쿺蚐⧘矜ﯱ䈌灭湅෢宔蟌", 99 },
                    { new Guid("52e1e587-b510-453e-a7fe-b315d1c19ba9"), new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), "ꟈ䬂꧶價쀦⥽␹帤䪛᫛ሧ爲ﵳ끆鳞₏皵筓㜰", 99 },
                    { new Guid("5474f454-0fe7-487e-83cc-70b9aed1cdb6"), new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), "倨䙴눔㋚ἦ潷ߧ弬惋䚖꧇�頧㟢࿒열ʹꂖ믣", 1 },
                    { new Guid("56be3fbe-6b8a-4899-a677-c3942659c6c4"), new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), "锃뭺햪ǊⅥ곎躍숽⌷큵᠖眩斡鳁鯰ओ૑�庘", 0 },
                    { new Guid("59cb3ba8-86b6-40c2-8407-44d9ac48c60b"), new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), "᡺셽䧹䍠嘱털瞸氻엵裡訆퇿슮㛞軧⯌", 99 },
                    { new Guid("5a982436-b296-4e11-a05a-1c7c64659cb3"), new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), "劈膳拉稹׆榵鶃⸍䶿깖આኜ耉魿鳟̀絻", 1 },
                    { new Guid("5f333ab7-65d6-4992-83ba-abc2f759928f"), new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), "전㶟❥㬠評狍됩衻拐Ⓑ㬏Ѣಕ昞댔ႝꁑ샜", 0 },
                    { new Guid("628dce06-646d-4709-ac3e-625d9af17583"), new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), "㤧쓧濾뢋쿋�떅卅Ɥ�븂㲫놭ᨸ錄涆", 1 },
                    { new Guid("631c2291-4d19-4aa3-96e2-0adf24722dee"), new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), "峹ੁ꓌�簈왳㦅嬶丌것쪰᷿ま稄幥౎䱢", 1 },
                    { new Guid("63ca9a4b-1ace-4d8a-a9b9-cdfbf478c764"), new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), "ꮙ붳㇆쩒庭罬᭧ȷ솫︓斧ꈿᰖ۟퍺즥洅ࢡ", 1 },
                    { new Guid("6437b407-df55-44b3-bcd1-061f668e3f3e"), new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), "騳ዹ캔ꄗ➆᧤ꖿቂ㓶晒垅དྷ翢�ڢ퇩厪㧕쏞", 99 },
                    { new Guid("658b6c7b-1fa0-4f35-a020-90e291ad0276"), new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), "嵄꒰쮷놴칧櫒ẋꖶ矻䜒㋳괔䫬樣ဇ⒲ꨪ㻞Ԧ", 99 },
                    { new Guid("67315dbe-2836-4475-8e64-ea336b63477c"), new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), "鼌믧ⰰᣁ៬勛辶隡=⹵䵟㻵鮡ზ䁽ꦐꕟ꼪掗", 99 },
                    { new Guid("67d48127-4052-41de-9334-502b1bbda24c"), new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), "肻唦ᶣ뚑㜁选ꪪ⁜�凋ﲜ쵔ﺿᨴ㴕뾪手゗猳쀩", 0 },
                    { new Guid("6874ef16-7dbf-4728-8774-da1cf7b0c5a2"), new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), "⡉苜摏犣ꀫꜫꊈ늤츆룐帞渘閤䂉", 99 },
                    { new Guid("68a5316c-949d-403b-936e-1d421835181f"), new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), "灣闸汑켉骏즍࢒�싇冄�㦎䷴ြ걎Ј쬐", 0 },
                    { new Guid("6a7867c2-d282-4eec-8645-91b2ad83adc0"), new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), "礔ᑄ厡苹鸌引㰍죌姀�蟛㜩拜겧뫒蓙僊캕븚", 0 },
                    { new Guid("6c754b53-7f9e-49b5-a4dc-19f4d0c2aa39"), new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), "䢠Ớ皧ﾙᐠ콰İ쬩횁捪瑲Ỗᡭ駡﹝㚻浏첷塛ϒ", 0 },
                    { new Guid("6e77faf1-4003-4900-90c5-c1db629b7b41"), new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), "뻟얫璕墟�㳓ﵱ們婔᫬￉㊔䈏Ả麍匔ꄖ䵄鼯", 1 },
                    { new Guid("72a7a61e-dd21-4aa5-a0e9-a6c5108716d5"), new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), "玨⻓䓦ଉ㊭㗅蹆鞞쌶쪽ꊍ颪郴汘颎朔塻㋒ﮭ", 0 },
                    { new Guid("73155cba-b088-489d-8961-d0b99d428ac3"), new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), "쫃껈猴䰥奪फ़ൌ헪ⅺ熐ё淯㹐櫊⮰�䖭ᑥ錗", 1 },
                    { new Guid("75848a91-215c-45b8-babd-6868457bd7bf"), new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), "뽟⫺㹗̷묋�⑼騝溳ꅏ챦ᰏ䢝ڈ워什澧鮤", 1 },
                    { new Guid("77d258b7-4c16-4338-9956-9dc65ff73387"), new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), "ጛ剞ൊ쎮鷸�곘﷤데녩葜粭⤻ꥼ", 99 },
                    { new Guid("7aa582a1-5123-4824-bd50-e5f6cd389326"), new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), "埃뤧⭋☖ጧ绯礗᳅煗臸綀섣钣ꔗ验ᮔ糳�妅", 99 },
                    { new Guid("7ad46726-25da-478b-aeca-a60b94eb6eca"), new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), "䣳㊅乜鐓駒ˌ퉴翕쁨䷍༤勱旔⫵�䈥濌�鑞", 1 },
                    { new Guid("7bcdeb48-d407-4fa0-a4bc-453d5e577d34"), new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), "悉匄㒛극岞鴍霋茫칦㾠䵎襕ꅊ롊眢畊㎰䎞", 0 },
                    { new Guid("7cf393f6-a474-4be4-be9b-56d1d51334db"), new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), "䅓哖囷﨩쀪痀꾰墔娉ꀧ㭦᝟넮쮞嫨嶫୿", 1 },
                    { new Guid("7e03261a-b6ea-48b1-ad9a-e143b36f486a"), new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), "詿蹾䚙䯨刕ᒰ㌇犵撰�尓䫇墖ྉ代鸨쨏與", 0 },
                    { new Guid("7f852c4d-4607-4406-8803-00aef2d50c87"), new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), "ꏪο拍醒礢⭊㨈ጏΎ맟ᰈ旣嫹ꪚ鵙虈ꍖ㪋", 0 },
                    { new Guid("7fc95971-55a1-4261-9f1d-aa0883bc8020"), new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), "㝘뙩㞕僈蚢ꂝ萀㞿췳諷싍࡙⧘셒ꦹ믶꿶", 0 },
                    { new Guid("8121e94a-195b-43fa-89ba-7bca51b8f33f"), new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), "慚ꩮᚗ銶벾纶껫䫬猸잁不鎜벛�씹컛䈟꺓䫗", 0 },
                    { new Guid("82f3b824-c7b9-4467-9388-f81896247f7e"), new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), "㘕ᷱ厂▂亞䬹悗�찈᪩锳驷ർᰨ똼⮼휿艎ݻ", 1 },
                    { new Guid("83500a5c-d0e8-4298-a62e-c0639fa03f37"), new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), "ꥮ郳啁Ĵ䓚哜퍐�衽踞᥮ʱ憣ಛ㼴葳ኹ", 1 },
                    { new Guid("8461c703-e876-4860-b1ea-df14c83cc425"), new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), "ㅱⴛ堋ꢳ䟶蝹鎀〓쎇庢Ἁ斂着Έ阩馮ᒡᱢ", 99 },
                    { new Guid("84fbaee4-f1d9-435e-8fb5-08c3b943edda"), new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), "ꢴ盎⨙劭皜纪ꡦ氞Ｓᕏ쳞㬍뇟妢趎ᅽ௟", 99 },
                    { new Guid("8528eeb7-0955-4bc0-9daa-fe7260cc472f"), new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), "⑁悩幮ী筥䎆祖珰ᩤ䘇蛍䀈뺍ᢤ㴪�펹놛", 99 },
                    { new Guid("87398fe6-b561-4b87-8d27-11c0355e9967"), new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), "䍸翺梬鉃䏰䇈⸨辨爳仸朇邇ⷺᮁ⳺꺭♍", 99 },
                    { new Guid("89df0610-576b-410e-a711-a41eab091d67"), new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), "귔嗳㧏嚲裨䓷昉宦䩈ⵎꑙ�⟛＇ᩌ㮵夦郾록", 0 },
                    { new Guid("89e52898-70c3-47b9-9b3f-fac07f29306d"), new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), "켞閻⢛瑭浯깏뻿㣭鐷搢䶏嗫芲ᨒ읯聦ꉫ", 0 },
                    { new Guid("8b2aaded-85af-49d6-9406-514946faecd8"), new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), "❂ﭰꌻ麯霩崥ಛ쀅�鹇⊢￠蓻刓⿰敪눶漦", 1 },
                    { new Guid("8c74d397-d2af-454f-b9bd-a15ce368afa3"), new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), "癧﬜㨓驑�㘺꾽削虍ᕶꫠ薺၍�ࢫ鳷쩫菀蒇", 1 },
                    { new Guid("8c893c34-adc7-4658-b80b-eb1698623c5c"), new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), "갯䐲氧㩗免⵳熞﫨躲Ⴒ쾒뒣딻㗺溒昽把뒫畼⢾", 99 },
                    { new Guid("8d2254f7-0e52-49d6-a161-95db10c9e515"), new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), "챾�傏䗵鯪�뺝‖ꁇ楈펁囤完髈�뢍踏浖", 1 },
                    { new Guid("8e09b500-1d3c-46b7-9791-ec0d7370a7db"), new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), "逨곦졍ᝏ맡踊著铇ထ⩃틥휽≈⼏쮡슣Ȱ", 99 },
                    { new Guid("8ecd5e3a-0e42-4dba-92ac-a72de2822b59"), new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), "䒝ᰕ῟顂ঝ啋䐳駞躘裫穀甠ꛟ㭅Ꞧ孾嚆윖嵢�", 99 },
                    { new Guid("8f208fcd-b1b6-4326-8760-e57582f7bcb6"), new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), "䄺᫶뤨ᤈ畃櫫劇紞昻ꅝ瑦ꦓ鰥ནග⟏墛ƽ", 99 },
                    { new Guid("9491eddc-25a9-4e56-b210-48d7f3741fca"), new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), "ᄻ燆뤡㗺갚䊓☖ᥥ쩨֓鈆㸂锶ᓕ끦얝탈潧現", 1 },
                    { new Guid("99759217-05c0-4e68-afb6-d900e29d3227"), new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), "熶豋�뼭�煃䴆覀紙様녦䫍ኡ❲⡘䥿劌谻", 99 },
                    { new Guid("99ba6500-c11e-47b5-ada7-bcaa25a44260"), new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), "溟Ẕ躬棃ᡃ뷴艢ക�縉�ⶈ᧺壄ꮈ።翐끺ݲ춍", 1 },
                    { new Guid("9b806b79-a84d-4a94-a46a-8e0d6d4150b4"), new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), "᱑壐牷⹆ಳ䛒ᗔȓࠧɠ飴䁬彫瑬쨘㍗㪌ၵ", 1 },
                    { new Guid("9d0f0468-4714-4936-baf9-1d68c7a47ce8"), new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), "ᓟ䴽䂜뤪숎୞屠癙쯟얓ࢢ㇍漱䙗댣捚흷ጰ齛", 1 },
                    { new Guid("9d8b03dc-abac-4302-85a9-bffaf06238b1"), new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), "�ᲃ巜�⠧楤팇痎Ὄ袨ᖲ髉ᛅ�납�篴", 99 },
                    { new Guid("9f5d73f7-2ef0-4357-8cf7-7a148dc3c95c"), new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), "償ꇰᮢ诮疍煲岎ベໄ䲜ꌼ룕⅑緉斜ᒹ鯂Ȩᙍ", 1 },
                    { new Guid("a068f6b3-3275-436e-87b4-c1b96a98fa43"), new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), "商즖삱ᑷ捛埿矵䜧곓볫엀萂ⲫ妔傹ຏ껫ࣺ", 99 },
                    { new Guid("a2bbb6bf-03e3-45b2-b1b0-4c397ad3d641"), new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), "ਣꑥ⮚ᔷ᐀ી⍶嫿馬:◦恝燬繋櫖⮷", 1 },
                    { new Guid("a34263ad-219b-4626-9769-42b78d440ce8"), new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), "㰟但�㇨䄰퇥꾱栧㨂ꇑ犾ᡳ릌�ᜯ洛쫈῁", 1 },
                    { new Guid("a46cf232-14c9-4ab0-a8cb-3974a6ca07bb"), new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), "壶麗∅㺙૤ĩژ뛬ᇴ뙊▅Ⲧ漋䙪⺹郷䀌紉㩝", 1 },
                    { new Guid("a571016a-64ba-4755-9a0d-b93868a85f8d"), new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), "逓뜸뺱觴�㐣ᄫ쥻ߊ鑢闹㱌溻㋫ꖲ進", 99 },
                    { new Guid("a5d07af5-6bbb-4821-a3a1-1b3335c7d65a"), new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), "䇓剽්㭋쒡䈯맩벓ꍸ�␞鮀笷ﴧ፣㶊卽Ⱖ䡝", 1 },
                    { new Guid("a9131280-e941-43d5-8f2c-19e78cbf288b"), new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), "鵟◚ꬶ꤭㣤ब�ॎ賽侊⏌೦熉쾺嫤戍", 0 },
                    { new Guid("ab865754-a8cb-4372-9224-d91acfd525e6"), new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), "蠟�唞鎗ꮪ틈龟㖼햸굩懁ꩲ뤽羥覦ᗞ㮉", 1 },
                    { new Guid("aba52b80-8c90-448e-99ed-28af085ca1ae"), new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), "ꗁ訒멘气똢ᆆ셛鄩Ʀㅷ礣ꖡ٢֝ɜ玶젽뷺ᬹ", 0 },
                    { new Guid("aeb26b4e-371f-43f6-a889-2b45824d8711"), new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), "觋赳鎅൴뢡ቝ튧컡੣瓑篶้踠춼ᔆ岫ᆗ줳", 1 },
                    { new Guid("afa6d9e5-a045-4fe4-99f4-5d801a4e54a2"), new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), "ҏ✪盲筜◚륜ꛊ㈆卑䨔ṃ놠돊⸑眎ꜿﳤ䅓�䲶", 1 },
                    { new Guid("afbc571e-f635-4807-8f4f-c8bc3a1b294d"), new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), "悎熘ᴥꀥ噈ꩠ睡蓗ᅥ誇Ꝑ�㩣暲꛳窼眏", 1 },
                    { new Guid("b1e933f6-6168-45bd-a41e-50e96dbe8321"), new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), "膀㈶⁯潠ﾏ刂㜗독礟嬍㊃꧱瀦蚪涙ꛘ榐ಘꏚ둧", 99 },
                    { new Guid("b250936a-961c-4b7f-abc0-20760d534438"), new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), "ú蟓淌嫭��㛦ɪ渒뛦㰔⣫푓䎇暚ಪ늷�舕น", 0 },
                    { new Guid("b269822f-55e7-477e-a727-5c0a718a621a"), new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), "렒䋠⋐圹羉䑯젵瓨竁䲜큡龋㦋鈯걊ⓗ㓅", 0 },
                    { new Guid("b2de3aab-a7f8-4be8-92eb-43cf3e1d71cd"), new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), "蝯䘝�㒦৔쫣靬ϖ⇩䦌阮ᣦ櫎꣌놔撪ާ", 1 },
                    { new Guid("b32231bc-4ac2-4097-a0b1-e69be725db5b"), new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), "뇏됷簥됊ᭆ喗來뜴碉ᶝ᛹⏰ꢔᳯ銘건㌯蕻谔", 0 },
                    { new Guid("b4a2876f-332e-40a8-a431-fd4ee9811006"), new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), "嵄詞榁쁖瑹軧꬝ਦ沎ծ濫검⫾녢팜枨�闲ᰢ횦", 99 },
                    { new Guid("b5519773-a991-42fe-92a3-d51a3ccdd5a6"), new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), "⃪ཁ⩴ꎊ꣋ソ큇킖范똗ꀾ菤㞼킺䗆뺖聊", 1 },
                    { new Guid("b586d8d8-703b-4763-92ee-36674b0eb924"), new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), "㩮飹㒼殐숺승ᗯ蕌↸躻윱㶚ꀩ�䷬ꏑﲓꄼ", 99 },
                    { new Guid("b6079a00-adc6-46d2-9a81-eef08f27f95c"), new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), "탿䰀ﰩ�꣡޺蒿඄ⲅ稓윌ᾘ㍉㳃ө淃꡻ቴ", 99 },
                    { new Guid("b707fa25-361d-4791-a5f4-ccd2f4648e70"), new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), "෧濱䡹ᒶ亮꣢㮝悷䓄਎⸺ᘹ㟠泼�蹞ﭣ÷僓", 1 },
                    { new Guid("b7a0f942-b249-449f-ab8f-f1a48ae54e83"), new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), "颗ዳ﮼Шាꝴ㬄㘜侞䎮嵻輤딩࣯犖꾢뜒", 1 },
                    { new Guid("b83597ef-677b-4eb9-ac46-ed5e66e2e537"), new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), "蹋崮눅檨렠蜾䇡數熢蝖Ｌꅦ︌ছ⌑Ġ", 1 },
                    { new Guid("b90c8165-def6-4bec-80a6-4f148d8f1cf3"), new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), "気癘滬᮴⮔魇ᮑ芆Ⱡ뛄힜ေ⹶实ﵡ๞呞ﻡ쎸", 99 },
                    { new Guid("b9320128-02a3-4f23-9fe2-dc6226983630"), new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), "썔ガɒរ褸ﴡ㲬쓇籞ꓝ믰ᯖ퀿抔炈촾嶅", 1 },
                    { new Guid("b97f61f4-7aed-4bb0-92cd-164b4ec61488"), new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), "碼匙鴤࣡ә灀툳鰶쮘柮铸㼬ﶔ時֟骯", 99 },
                    { new Guid("be8d504f-385d-49bb-9c42-fde20217de0a"), new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), "툗衚㽾磸긌�琰ꊯ⢦꠼䵁�苒䱱㝀�秿ԙꄶ躀", 0 },
                    { new Guid("bf5ac642-d03e-458f-bca6-7bc3cc8383c3"), new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), "꬟焙䮺䃹ᒗꁶ듾礫啈꣍㉏䞨⎮↎ড়৪⮵췤烐", 99 },
                    { new Guid("c0a3546a-da43-4a1d-b119-3da53b3762fb"), new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), "慙뒘⁪਷猊࿜ꙶ༦憳툥庿ᎀ攑ᩄ挘ꂐ�ᏺ鲡", 1 },
                    { new Guid("c134f909-c1ef-42f0-8b15-238cbfee9fc8"), new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), "�⎗⍷袧ￗ薼ﵜ赴￡簲ꋶ⢠춲ц侗鿗榞", 1 },
                    { new Guid("c1b1a0e7-b2a7-4c90-856c-c67457a4bca3"), new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), "舌풂켊ቅ纱ﰊ曡䌇ῷ뭝跄䆒桛≠훦臝휌㿕", 1 },
                    { new Guid("c2406330-dfd3-4d26-afb5-b9ab3a111927"), new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), "仵剱蠪ꧥω槺∴ᘡ颬厕⡞ߑ瀦岩乌紁钓삊ꀙ䌉", 99 },
                    { new Guid("c282efa5-2ffd-4db5-8831-a0f804280fa9"), new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), "꺈帜뛎ﲍ䢣ᴺ阊臶ڳ먝ᖥꊘ칚喂䆍�㈓", 0 },
                    { new Guid("c31c163a-3798-418b-8041-d71f4731cabd"), new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), "㕷禎㞰秈硩ꆩ驺Ꚁ湽輞㺴嬘뷡呵ݴ向㚡趉", 0 },
                    { new Guid("c4e524b3-9f46-4137-a7d3-eccde1b3f62e"), new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), "昈ꟍ뾭穼特Ⓦ뫿읠Ꜻ爚苺컿呄颍芋Ĭ㐏뱝볩醒", 99 },
                    { new Guid("c5b897a4-2988-40c5-844d-66546411f05f"), new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), "쯂愖㲻祩寸�ଣ఩鮦⬈饵롺六㋽㲜㐚⬺晈엓", 1 },
                    { new Guid("c6757e7c-d4b3-4cd6-88f2-112cd92a21e4"), new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), "ꟼᗗ笤厖徚鸐䉓助뗦阀鞁㕱ꏃ슥శ딄⢲풴ꐮ", 99 },
                    { new Guid("c77bfdd4-686b-40cd-8282-f49ee343c9ca"), new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), "⮔뷪什䒗ᔲ쳷ꀻ譤䎺顽ᰆ힘䒣焘∝Қ玹", 99 },
                    { new Guid("cc2ce12f-4fcf-4fd8-bc1e-d8a81f4f6a4c"), new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), "蹌᧻ﮯध፠╴軾탍㣦⁐隞侪썍璚ঢ宅�ꂂ", 0 },
                    { new Guid("ccc2b873-f894-4690-8daf-25a9049fe040"), new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), "勦휵荣짰斨ᚕ➟ቻ�ᮚ薧ᵱ枴饱⏽�Ꮧ匘雎뎖", 1 },
                    { new Guid("cce44449-60ab-4481-b72f-d676c6beb120"), new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), "䛌㽋�׌ಌ㳔ﲳ旵㢽熑웥р⼊殣쥲⺤", 1 },
                    { new Guid("cdd1d5dd-4346-410c-bdd3-0182b11014de"), new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), "퀨闑超䴻⌯쐮杲췫摌歝�廠ꓘㆾᩮ믕⢬ﳥݶ", 0 },
                    { new Guid("cdffb4fe-dad4-4844-8b13-add96b16f1aa"), new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), "ﶼ闟퓀郦髪Ϣ蛗괤䬐薂뀪틲磩Ⓧ新ᣫᄕ烀", 0 },
                    { new Guid("ce5f60f3-94df-469a-a72e-bb54a9962aba"), new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), "㚝卧牖ᖏꖂ概袌뻤奠ꕠ쀥վᤅ�硔쀖쒛", 1 },
                    { new Guid("d295d7ce-1013-442a-ada0-72871eac84e8"), new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), "Չョퟺ状鄈ᡯဒ밪萝῏饋ᩃ╀㗣膏荀亽�䢌", 99 },
                    { new Guid("d518db83-ca37-4957-9cb5-80d289d18991"), new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), "欅엌迌䴌鴊鑱ݴ꟏褗໕㨣ẗ풺꧋㈝阁磑౞劏", 1 },
                    { new Guid("d60fef30-8fc5-4f8c-a023-60a08a615e88"), new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), "鳛ﻇ毐쉷䂞䮩癥㞠㑣敓�妟谾눏༞㑡쯙ꥍⵉ", 0 },
                    { new Guid("d6ef68a8-a2c5-4bd9-b393-be54d40a3e20"), new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), "뎝䍽鵙祱鍕銬䮔꾡뉀䰃며ᣞ툋�埗Ꮒ깒", 0 },
                    { new Guid("d8e87519-0d58-4ad0-b83b-216c5db71767"), new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), "Ռ硖֍ᬍ쓜둀툿⃕Ꞇ篂㡪쑌ཻ㫒짌�ϥ篕첝", 99 },
                    { new Guid("da293678-720f-4bad-b778-8aad17623da1"), new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), "ᜳ메绂졏둃폙恚⺾찐ꀰ訩ൈ䠂쇂혈戓愬", 0 },
                    { new Guid("dacc17a6-6cd2-4d1e-95d5-5788260213ec"), new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), "⒚㐇⇿엺簱䝝勶厂譬頫ꀜീ嶱ᗑ㴁臝ጞ뽉", 1 },
                    { new Guid("db97cc63-91f9-4280-9006-b2f74f643694"), new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), "ꠒ꼆ᖄꙺᖾ᣶馟♝솻箴ꢛࢶ읝澿缉ሐ絷㑖", 0 },
                    { new Guid("dc3c5337-9f74-4686-b852-22de7742e7d1"), new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), "⁹ᐈ低帯˖睵㓳嗕ඁਜ਼䢶뤵뫧骄⌇ྯ檽", 99 },
                    { new Guid("dc876568-eab4-4f8f-aa29-717c7d90ae20"), new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), "鸚妁靤⛵ᮝ휹ᒘ㐬줨⨟ﻭ֚듔聃렌", 0 },
                    { new Guid("df0bea3a-9e9a-4444-a3a8-f3676da01df0"), new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), "酹䄲巎夓〳䡒⿎曊숧䉧螓╒ꐱ貅劙ü﹮⧊�", 1 },
                    { new Guid("e098b51a-6dda-47cd-a54b-cf1ad691ef8c"), new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), "㖚�⵲ᤸɽ測阮뻇挷グΌᓯ䉄ㄥ櫈ఏ湘뗱ё", 1 },
                    { new Guid("e1e1e638-9bb9-41e4-8992-165e5f69af1a"), new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), "㼶飂髖幢俪㥱퉨凞睝顰♮東⠇版窋퓶髉寙", 0 },
                    { new Guid("e38b671e-bad7-4fb5-aafb-0ee0ca93cd6c"), new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), "ꁵ᤿鈐ꇅ樌䈓矫벪ᣝṓ뭥漙Ⳙ�怒﹭", 99 },
                    { new Guid("e451141e-7065-45c7-aaad-e378009f3025"), new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), "�榫⶿貰懯ዉ�빐罙ﮜ햸蟬뻂�䷎┹㴷셀", 99 },
                    { new Guid("e61912e6-cb74-4d63-9490-decf85ba6c3b"), new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), "見㤸慡ﺧྜྷɵយ燧㩭붐ꗣࢿ㓟때䒊膯楷ʯ", 0 },
                    { new Guid("e8252464-26f9-4ce5-8f64-c8bc2560051d"), new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), "�䥎T㑩ლ㏴顏ఛ蕐橿⸬婱�ៈ稈잷堋", 99 },
                    { new Guid("e889bc6e-837e-46bf-a0a7-5f10a9c1c3aa"), new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), "幉䶋楽࢘掇䁈ⳑӤ㐚㐐┢�蚓텧㩈⊲䲼惑巑", 1 },
                    { new Guid("eae35487-2284-45ef-9b7d-ebcea7ff076d"), new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), "ጥᢲ�굃埅鴬獬치畝➳⒪ᝯⱯ텢씚ᆓ㘅�", 0 },
                    { new Guid("ec86caf7-a108-4b2a-862b-071740a4651c"), new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), "ⴉ猝檯ᒛ鰃闹쩙Iᘷ镬კ瓇ဝ앮佬鄫㒚ℤ�Ქ", 1 },
                    { new Guid("ed58c916-ea8a-4eb9-8f01-2ec5a895eaa4"), new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), "降贖ꉺ鷏螤᭔憃䊖갥͚吤ᬨ꺻ퟻ尟ﾌ罪�", 1 },
                    { new Guid("ef1e0368-5e74-4781-a6d3-fe7c0c660515"), new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), "曣臂ꍀ딩㿁ﱜ렙�话鼘臒侀篘︧桟젺릃ダᲅﲣ", 99 },
                    { new Guid("f143f7ac-7ac8-4800-9435-014c6eedd600"), new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), "廫ⅼ좺悾̏쭥Ԛ汎뾖猀ꕄ裣뀧ે벣眥䕱蝍", 1 },
                    { new Guid("f1d64476-eda7-489c-b960-8ef99938c5db"), new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), "ꢷ濷⿏붗긪쓰ꥉ峎蒌㰙虷鍏鯷췓贕ヵ䀚ۏ", 0 },
                    { new Guid("f3eff3c7-c911-414c-8e72-2358195ef9a1"), new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), "⇹䃪䣚͎沀鷒ஶ൫廧㒈䰥归బ꥚蟜鑄ꑅ㱗⳪冰", 1 },
                    { new Guid("f515b436-394a-44e1-aa17-7ce1c7f46410"), new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), "8뭜频࡟퉈亣᩹鴉Ḯ˽ᚶ╢縘禈ଭ෌뫚旅", 0 },
                    { new Guid("f6924e32-7dea-4001-aaef-67e3afc21ae9"), new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), "밠햪말ﰵ톦ᴨ蹉珐՟펮뷇瀺緳빳ѯ렚ጎ교", 1 },
                    { new Guid("f6f18900-9130-40e6-9365-bcaaf83761b4"), new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), "ꋬ헪볌퐭햞䳵錧럱謒夑ྤ풢⽥稝┝㊞⍁㝸", 0 },
                    { new Guid("f77ef7fe-f9dd-48a8-b990-8f0c6ceb7f53"), new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), "뗈檟鑺῟ፘ⒴碹⁴清㦧私騢딷⪲䚞㵖儬", 0 },
                    { new Guid("f7b6b5a0-30b1-492a-8efc-e1618100a897"), new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), "降둘滵੊嗫ष㟝쫌錑甶⠚諞횲厖휽钓༖", 0 },
                    { new Guid("fb029faa-e7ba-4d24-8f6b-590a3fcc4c96"), new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), "齒崜嫵屾篫菋ꘕ藱ꨉꡯ盆�圙力㺙祾랔ᩛﱣ", 99 },
                    { new Guid("fd35c274-bb1d-4af6-b210-0e5c7d537ba1"), new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), "鹢ᤑ䤚ࣚ恻䷌�귄ﻩ䢓瓏銒ϛ᦭縠ꛢ褐⇲", 1 },
                    { new Guid("fe70745b-f8e1-4af4-b8ae-4770132750e6"), new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), "꒽柿뉷�刣每シ奓〻噢麳ꇹ颪퇟絹靀橂쀓", 99 },
                    { new Guid("ff955b51-b459-4c9a-875b-2a44a6bb9d66"), new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), "똔￘ባ紋쪫猌쬅㑇⸽�퓍꽬෮ⷜ쐖뗪颍Ვ﯑谧", 99 }
                });

            migrationBuilder.InsertData(
                table: "SubscriptionPaid",
                columns: new[] { "MemberId", "Month", "Year" },
                values: new object[,]
                {
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 1, 2014 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 2, 2014 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 3, 2014 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 4, 2014 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 5, 2014 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 6, 2014 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 7, 2014 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 8, 2014 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 9, 2014 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 10, 2014 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 11, 2014 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 12, 2014 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 1, 2015 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 2, 2015 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 3, 2015 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 4, 2015 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 5, 2015 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 6, 2015 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 7, 2015 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 8, 2015 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 9, 2015 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 10, 2015 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 11, 2015 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 12, 2015 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 1, 2016 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 2, 2016 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 3, 2016 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 4, 2016 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 5, 2016 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 6, 2016 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 8, 2016 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 9, 2016 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 10, 2016 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 11, 2016 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 12, 2016 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 1, 2017 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 2, 2017 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 3, 2017 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 4, 2017 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 5, 2017 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 6, 2017 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 7, 2017 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 8, 2017 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 9, 2017 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 10, 2017 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 11, 2017 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 1, 2018 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 2, 2018 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 3, 2018 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 4, 2018 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 5, 2018 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 6, 2018 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 7, 2018 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 8, 2018 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 10, 2018 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 11, 2018 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 12, 2018 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 1, 2019 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 2, 2019 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 3, 2019 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 4, 2019 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 6, 2019 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 7, 2019 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 8, 2019 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 9, 2019 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 10, 2019 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 11, 2019 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 12, 2019 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 1, 2020 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 2, 2020 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 3, 2020 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 4, 2020 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 5, 2020 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 6, 2020 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 7, 2020 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 8, 2020 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 9, 2020 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 10, 2020 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 11, 2020 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 12, 2020 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 1, 2021 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 2, 2021 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 4, 2021 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 5, 2021 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 6, 2021 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 7, 2021 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 8, 2021 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 9, 2021 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 10, 2021 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 11, 2021 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 12, 2021 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 1, 2022 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 2, 2022 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 4, 2022 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 5, 2022 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 7, 2022 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 8, 2022 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 9, 2022 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 10, 2022 },
                    { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 11, 2022 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 1, 2014 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 2, 2014 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 3, 2014 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 4, 2014 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 5, 2014 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 6, 2014 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 7, 2014 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 8, 2014 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 9, 2014 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 10, 2014 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 11, 2014 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 12, 2014 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 1, 2015 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 2, 2015 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 3, 2015 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 4, 2015 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 5, 2015 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 6, 2015 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 7, 2015 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 8, 2015 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 9, 2015 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 10, 2015 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 11, 2015 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 12, 2015 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 1, 2016 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 2, 2016 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 3, 2016 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 4, 2016 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 5, 2016 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 6, 2016 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 7, 2016 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 8, 2016 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 9, 2016 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 10, 2016 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 11, 2016 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 1, 2017 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 2, 2017 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 3, 2017 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 4, 2017 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 5, 2017 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 6, 2017 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 7, 2017 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 8, 2017 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 9, 2017 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 10, 2017 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 11, 2017 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 1, 2018 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 2, 2018 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 3, 2018 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 4, 2018 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 5, 2018 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 7, 2018 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 8, 2018 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 9, 2018 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 10, 2018 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 11, 2018 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 12, 2018 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 2, 2019 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 3, 2019 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 4, 2019 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 5, 2019 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 6, 2019 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 8, 2019 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 9, 2019 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 10, 2019 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 11, 2019 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 12, 2019 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 1, 2020 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 2, 2020 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 3, 2020 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 4, 2020 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 5, 2020 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 6, 2020 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 7, 2020 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 8, 2020 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 9, 2020 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 10, 2020 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 11, 2020 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 12, 2020 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 1, 2021 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 2, 2021 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 3, 2021 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 4, 2021 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 5, 2021 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 6, 2021 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 8, 2021 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 9, 2021 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 10, 2021 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 11, 2021 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 12, 2021 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 2, 2022 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 3, 2022 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 4, 2022 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 5, 2022 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 6, 2022 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 7, 2022 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 8, 2022 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 10, 2022 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 11, 2022 },
                    { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 12, 2022 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 1, 2014 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 2, 2014 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 3, 2014 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 4, 2014 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 5, 2014 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 6, 2014 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 7, 2014 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 8, 2014 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 9, 2014 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 10, 2014 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 11, 2014 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 12, 2014 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 1, 2015 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 2, 2015 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 3, 2015 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 5, 2015 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 6, 2015 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 7, 2015 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 8, 2015 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 9, 2015 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 10, 2015 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 11, 2015 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 2, 2016 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 3, 2016 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 4, 2016 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 5, 2016 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 6, 2016 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 8, 2016 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 9, 2016 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 10, 2016 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 12, 2016 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 1, 2017 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 2, 2017 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 3, 2017 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 4, 2017 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 7, 2017 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 8, 2017 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 9, 2017 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 10, 2017 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 11, 2017 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 12, 2017 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 1, 2018 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 2, 2018 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 3, 2018 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 4, 2018 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 5, 2018 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 6, 2018 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 7, 2018 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 8, 2018 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 9, 2018 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 10, 2018 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 11, 2018 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 12, 2018 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 1, 2019 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 2, 2019 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 3, 2019 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 5, 2019 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 6, 2019 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 7, 2019 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 8, 2019 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 9, 2019 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 10, 2019 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 11, 2019 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 12, 2019 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 1, 2020 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 2, 2020 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 3, 2020 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 4, 2020 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 5, 2020 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 6, 2020 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 7, 2020 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 8, 2020 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 9, 2020 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 10, 2020 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 11, 2020 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 12, 2020 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 1, 2021 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 2, 2021 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 3, 2021 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 4, 2021 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 5, 2021 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 6, 2021 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 7, 2021 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 8, 2021 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 9, 2021 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 10, 2021 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 11, 2021 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 12, 2021 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 1, 2022 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 2, 2022 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 3, 2022 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 4, 2022 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 5, 2022 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 6, 2022 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 7, 2022 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 8, 2022 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 9, 2022 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 10, 2022 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 11, 2022 },
                    { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 12, 2022 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 1, 2014 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 2, 2014 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 3, 2014 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 4, 2014 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 5, 2014 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 6, 2014 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 7, 2014 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 8, 2014 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 9, 2014 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 10, 2014 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 11, 2014 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 1, 2015 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 2, 2015 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 3, 2015 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 4, 2015 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 5, 2015 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 6, 2015 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 7, 2015 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 8, 2015 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 9, 2015 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 10, 2015 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 11, 2015 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 12, 2015 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 1, 2016 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 2, 2016 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 3, 2016 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 4, 2016 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 5, 2016 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 6, 2016 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 7, 2016 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 8, 2016 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 9, 2016 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 10, 2016 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 11, 2016 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 1, 2017 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 2, 2017 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 3, 2017 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 4, 2017 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 5, 2017 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 6, 2017 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 7, 2017 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 8, 2017 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 9, 2017 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 11, 2017 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 12, 2017 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 1, 2018 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 2, 2018 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 3, 2018 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 4, 2018 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 5, 2018 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 6, 2018 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 8, 2018 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 9, 2018 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 10, 2018 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 11, 2018 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 12, 2018 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 1, 2019 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 2, 2019 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 3, 2019 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 4, 2019 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 5, 2019 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 6, 2019 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 7, 2019 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 8, 2019 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 9, 2019 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 10, 2019 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 11, 2019 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 12, 2019 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 1, 2020 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 2, 2020 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 3, 2020 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 4, 2020 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 5, 2020 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 6, 2020 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 7, 2020 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 8, 2020 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 9, 2020 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 10, 2020 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 11, 2020 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 12, 2020 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 1, 2021 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 3, 2021 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 4, 2021 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 5, 2021 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 6, 2021 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 8, 2021 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 9, 2021 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 10, 2021 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 11, 2021 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 12, 2021 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 1, 2022 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 2, 2022 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 4, 2022 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 5, 2022 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 6, 2022 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 7, 2022 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 8, 2022 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 9, 2022 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 10, 2022 },
                    { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 11, 2022 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 1, 2014 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 2, 2014 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 3, 2014 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 4, 2014 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 5, 2014 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 6, 2014 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 7, 2014 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 8, 2014 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 9, 2014 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 10, 2014 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 11, 2014 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 12, 2014 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 1, 2015 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 2, 2015 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 3, 2015 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 4, 2015 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 5, 2015 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 6, 2015 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 7, 2015 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 9, 2015 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 10, 2015 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 11, 2015 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 12, 2015 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 1, 2016 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 2, 2016 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 3, 2016 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 4, 2016 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 6, 2016 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 7, 2016 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 8, 2016 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 9, 2016 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 11, 2016 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 12, 2016 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 1, 2017 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 2, 2017 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 3, 2017 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 4, 2017 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 7, 2017 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 8, 2017 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 9, 2017 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 10, 2017 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 11, 2017 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 12, 2017 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 1, 2018 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 2, 2018 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 3, 2018 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 4, 2018 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 5, 2018 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 6, 2018 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 7, 2018 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 8, 2018 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 9, 2018 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 10, 2018 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 11, 2018 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 12, 2018 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 1, 2019 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 2, 2019 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 3, 2019 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 4, 2019 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 5, 2019 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 6, 2019 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 7, 2019 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 8, 2019 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 9, 2019 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 10, 2019 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 11, 2019 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 12, 2019 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 1, 2020 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 2, 2020 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 3, 2020 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 4, 2020 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 5, 2020 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 6, 2020 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 7, 2020 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 9, 2020 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 10, 2020 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 11, 2020 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 12, 2020 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 1, 2021 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 2, 2021 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 3, 2021 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 4, 2021 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 5, 2021 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 7, 2021 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 9, 2021 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 10, 2021 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 11, 2021 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 12, 2021 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 1, 2022 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 2, 2022 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 3, 2022 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 4, 2022 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 5, 2022 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 6, 2022 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 7, 2022 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 8, 2022 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 9, 2022 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 10, 2022 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 11, 2022 },
                    { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 12, 2022 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 2, 2014 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 3, 2014 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 4, 2014 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 5, 2014 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 6, 2014 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 7, 2014 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 8, 2014 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 10, 2014 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 11, 2014 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 12, 2014 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 1, 2015 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 2, 2015 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 3, 2015 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 4, 2015 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 5, 2015 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 6, 2015 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 7, 2015 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 8, 2015 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 9, 2015 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 10, 2015 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 11, 2015 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 12, 2015 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 1, 2016 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 2, 2016 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 3, 2016 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 4, 2016 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 5, 2016 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 6, 2016 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 7, 2016 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 8, 2016 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 9, 2016 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 10, 2016 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 11, 2016 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 12, 2016 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 1, 2017 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 3, 2017 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 5, 2017 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 6, 2017 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 7, 2017 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 8, 2017 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 9, 2017 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 10, 2017 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 11, 2017 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 12, 2017 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 1, 2018 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 2, 2018 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 3, 2018 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 4, 2018 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 5, 2018 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 6, 2018 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 7, 2018 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 8, 2018 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 9, 2018 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 10, 2018 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 11, 2018 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 12, 2018 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 1, 2019 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 2, 2019 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 3, 2019 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 4, 2019 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 5, 2019 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 6, 2019 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 7, 2019 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 8, 2019 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 9, 2019 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 11, 2019 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 12, 2019 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 1, 2020 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 2, 2020 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 3, 2020 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 4, 2020 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 5, 2020 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 6, 2020 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 7, 2020 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 8, 2020 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 9, 2020 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 10, 2020 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 11, 2020 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 1, 2021 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 3, 2021 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 4, 2021 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 5, 2021 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 6, 2021 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 7, 2021 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 8, 2021 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 9, 2021 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 10, 2021 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 11, 2021 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 12, 2021 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 1, 2022 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 2, 2022 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 3, 2022 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 4, 2022 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 5, 2022 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 6, 2022 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 7, 2022 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 8, 2022 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 9, 2022 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 11, 2022 },
                    { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 12, 2022 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 1, 2014 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 2, 2014 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 3, 2014 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 4, 2014 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 5, 2014 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 6, 2014 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 7, 2014 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 9, 2014 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 10, 2014 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 11, 2014 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 12, 2014 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 1, 2015 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 2, 2015 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 3, 2015 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 4, 2015 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 5, 2015 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 6, 2015 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 7, 2015 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 8, 2015 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 9, 2015 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 10, 2015 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 11, 2015 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 12, 2015 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 1, 2016 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 2, 2016 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 3, 2016 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 5, 2016 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 6, 2016 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 8, 2016 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 9, 2016 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 10, 2016 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 12, 2016 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 1, 2017 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 2, 2017 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 3, 2017 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 4, 2017 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 6, 2017 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 7, 2017 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 8, 2017 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 9, 2017 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 10, 2017 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 11, 2017 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 12, 2017 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 1, 2018 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 2, 2018 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 3, 2018 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 4, 2018 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 5, 2018 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 6, 2018 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 7, 2018 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 8, 2018 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 9, 2018 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 10, 2018 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 11, 2018 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 12, 2018 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 1, 2019 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 2, 2019 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 3, 2019 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 4, 2019 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 5, 2019 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 6, 2019 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 7, 2019 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 8, 2019 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 9, 2019 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 10, 2019 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 11, 2019 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 12, 2019 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 1, 2020 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 2, 2020 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 3, 2020 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 4, 2020 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 5, 2020 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 6, 2020 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 7, 2020 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 8, 2020 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 9, 2020 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 10, 2020 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 11, 2020 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 12, 2020 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 1, 2021 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 2, 2021 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 3, 2021 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 4, 2021 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 5, 2021 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 6, 2021 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 7, 2021 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 8, 2021 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 9, 2021 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 10, 2021 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 11, 2021 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 2, 2022 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 3, 2022 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 4, 2022 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 5, 2022 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 6, 2022 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 7, 2022 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 8, 2022 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 9, 2022 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 10, 2022 },
                    { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 11, 2022 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 2, 2014 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 4, 2014 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 5, 2014 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 6, 2014 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 7, 2014 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 8, 2014 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 9, 2014 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 10, 2014 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 11, 2014 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 1, 2015 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 2, 2015 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 3, 2015 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 4, 2015 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 5, 2015 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 6, 2015 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 7, 2015 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 8, 2015 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 9, 2015 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 10, 2015 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 12, 2015 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 1, 2016 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 2, 2016 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 3, 2016 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 4, 2016 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 5, 2016 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 6, 2016 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 7, 2016 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 8, 2016 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 9, 2016 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 10, 2016 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 11, 2016 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 12, 2016 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 1, 2017 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 2, 2017 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 3, 2017 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 4, 2017 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 5, 2017 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 6, 2017 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 7, 2017 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 8, 2017 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 9, 2017 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 10, 2017 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 11, 2017 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 12, 2017 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 1, 2018 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 2, 2018 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 3, 2018 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 4, 2018 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 5, 2018 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 6, 2018 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 7, 2018 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 8, 2018 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 9, 2018 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 10, 2018 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 11, 2018 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 12, 2018 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 1, 2019 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 2, 2019 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 3, 2019 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 4, 2019 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 5, 2019 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 6, 2019 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 7, 2019 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 8, 2019 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 9, 2019 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 10, 2019 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 11, 2019 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 1, 2020 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 2, 2020 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 3, 2020 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 4, 2020 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 5, 2020 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 6, 2020 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 7, 2020 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 9, 2020 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 11, 2020 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 12, 2020 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 1, 2021 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 2, 2021 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 4, 2021 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 5, 2021 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 6, 2021 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 7, 2021 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 8, 2021 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 9, 2021 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 10, 2021 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 11, 2021 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 12, 2021 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 1, 2022 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 2, 2022 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 3, 2022 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 4, 2022 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 5, 2022 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 6, 2022 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 7, 2022 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 8, 2022 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 9, 2022 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 10, 2022 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 11, 2022 },
                    { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 12, 2022 }
                });

            migrationBuilder.InsertData(
                table: "SubscriptionPaid",
                columns: new[] { "MemberId", "Month", "Year" },
                values: new object[,]
                {
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 1, 2014 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 3, 2014 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 4, 2014 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 5, 2014 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 6, 2014 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 7, 2014 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 8, 2014 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 9, 2014 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 10, 2014 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 11, 2014 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 12, 2014 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 1, 2015 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 3, 2015 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 4, 2015 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 5, 2015 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 6, 2015 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 7, 2015 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 8, 2015 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 9, 2015 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 10, 2015 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 11, 2015 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 12, 2015 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 1, 2016 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 2, 2016 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 3, 2016 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 4, 2016 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 5, 2016 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 6, 2016 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 7, 2016 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 8, 2016 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 9, 2016 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 10, 2016 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 11, 2016 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 12, 2016 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 1, 2017 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 2, 2017 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 4, 2017 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 5, 2017 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 6, 2017 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 7, 2017 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 8, 2017 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 9, 2017 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 11, 2017 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 12, 2017 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 1, 2018 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 2, 2018 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 3, 2018 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 4, 2018 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 5, 2018 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 6, 2018 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 7, 2018 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 8, 2018 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 9, 2018 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 10, 2018 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 11, 2018 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 12, 2018 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 1, 2019 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 2, 2019 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 3, 2019 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 4, 2019 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 5, 2019 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 6, 2019 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 7, 2019 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 8, 2019 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 9, 2019 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 10, 2019 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 12, 2019 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 1, 2020 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 3, 2020 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 5, 2020 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 6, 2020 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 7, 2020 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 8, 2020 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 9, 2020 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 10, 2020 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 11, 2020 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 1, 2021 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 2, 2021 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 3, 2021 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 4, 2021 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 5, 2021 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 6, 2021 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 7, 2021 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 8, 2021 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 9, 2021 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 10, 2021 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 11, 2021 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 12, 2021 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 1, 2022 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 2, 2022 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 3, 2022 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 4, 2022 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 5, 2022 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 6, 2022 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 7, 2022 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 8, 2022 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 9, 2022 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 10, 2022 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 11, 2022 },
                    { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 12, 2022 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 1, 2014 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 2, 2014 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 3, 2014 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 4, 2014 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 5, 2014 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 7, 2014 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 8, 2014 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 10, 2014 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 11, 2014 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 12, 2014 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 1, 2015 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 2, 2015 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 3, 2015 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 4, 2015 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 5, 2015 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 6, 2015 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 7, 2015 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 8, 2015 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 9, 2015 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 10, 2015 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 11, 2015 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 12, 2015 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 2, 2016 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 3, 2016 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 4, 2016 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 5, 2016 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 6, 2016 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 7, 2016 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 8, 2016 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 9, 2016 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 10, 2016 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 11, 2016 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 12, 2016 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 1, 2017 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 2, 2017 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 3, 2017 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 4, 2017 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 5, 2017 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 6, 2017 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 7, 2017 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 8, 2017 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 9, 2017 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 10, 2017 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 11, 2017 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 12, 2017 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 1, 2018 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 2, 2018 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 3, 2018 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 4, 2018 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 6, 2018 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 8, 2018 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 9, 2018 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 10, 2018 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 11, 2018 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 12, 2018 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 1, 2019 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 2, 2019 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 3, 2019 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 4, 2019 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 5, 2019 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 6, 2019 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 7, 2019 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 8, 2019 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 9, 2019 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 10, 2019 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 12, 2019 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 1, 2020 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 2, 2020 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 3, 2020 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 4, 2020 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 5, 2020 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 6, 2020 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 7, 2020 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 8, 2020 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 9, 2020 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 10, 2020 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 11, 2020 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 12, 2020 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 1, 2021 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 2, 2021 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 3, 2021 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 4, 2021 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 5, 2021 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 6, 2021 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 7, 2021 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 8, 2021 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 9, 2021 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 10, 2021 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 11, 2021 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 12, 2021 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 1, 2022 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 2, 2022 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 3, 2022 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 4, 2022 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 5, 2022 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 8, 2022 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 9, 2022 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 10, 2022 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 11, 2022 },
                    { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 12, 2022 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 1, 2014 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 3, 2014 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 4, 2014 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 5, 2014 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 7, 2014 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 8, 2014 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 9, 2014 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 10, 2014 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 11, 2014 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 12, 2014 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 1, 2015 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 2, 2015 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 3, 2015 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 4, 2015 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 5, 2015 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 6, 2015 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 7, 2015 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 8, 2015 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 9, 2015 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 10, 2015 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 11, 2015 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 12, 2015 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 1, 2016 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 2, 2016 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 3, 2016 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 4, 2016 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 5, 2016 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 6, 2016 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 7, 2016 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 9, 2016 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 10, 2016 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 11, 2016 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 12, 2016 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 1, 2017 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 2, 2017 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 3, 2017 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 4, 2017 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 5, 2017 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 6, 2017 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 7, 2017 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 8, 2017 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 9, 2017 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 10, 2017 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 11, 2017 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 12, 2017 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 1, 2018 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 3, 2018 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 4, 2018 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 5, 2018 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 6, 2018 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 7, 2018 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 9, 2018 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 10, 2018 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 12, 2018 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 1, 2019 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 2, 2019 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 3, 2019 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 4, 2019 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 5, 2019 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 6, 2019 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 7, 2019 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 8, 2019 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 9, 2019 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 10, 2019 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 11, 2019 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 1, 2020 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 2, 2020 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 3, 2020 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 4, 2020 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 5, 2020 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 6, 2020 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 7, 2020 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 8, 2020 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 9, 2020 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 10, 2020 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 11, 2020 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 12, 2020 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 1, 2021 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 3, 2021 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 4, 2021 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 5, 2021 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 6, 2021 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 7, 2021 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 8, 2021 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 9, 2021 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 10, 2021 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 11, 2021 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 12, 2021 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 1, 2022 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 2, 2022 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 3, 2022 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 4, 2022 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 5, 2022 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 6, 2022 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 7, 2022 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 8, 2022 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 9, 2022 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 10, 2022 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 11, 2022 },
                    { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 12, 2022 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 1, 2014 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 2, 2014 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 3, 2014 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 4, 2014 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 5, 2014 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 6, 2014 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 7, 2014 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 8, 2014 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 9, 2014 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 10, 2014 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 11, 2014 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 12, 2014 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 1, 2015 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 2, 2015 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 3, 2015 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 4, 2015 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 5, 2015 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 6, 2015 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 7, 2015 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 8, 2015 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 10, 2015 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 11, 2015 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 12, 2015 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 1, 2016 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 2, 2016 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 3, 2016 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 4, 2016 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 5, 2016 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 6, 2016 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 7, 2016 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 8, 2016 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 9, 2016 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 10, 2016 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 11, 2016 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 12, 2016 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 1, 2017 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 2, 2017 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 3, 2017 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 4, 2017 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 5, 2017 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 6, 2017 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 7, 2017 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 8, 2017 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 9, 2017 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 10, 2017 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 11, 2017 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 12, 2017 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 1, 2018 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 2, 2018 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 3, 2018 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 4, 2018 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 6, 2018 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 7, 2018 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 9, 2018 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 10, 2018 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 12, 2018 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 1, 2019 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 2, 2019 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 3, 2019 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 4, 2019 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 5, 2019 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 6, 2019 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 8, 2019 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 9, 2019 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 10, 2019 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 11, 2019 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 12, 2019 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 1, 2020 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 2, 2020 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 3, 2020 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 4, 2020 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 6, 2020 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 7, 2020 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 9, 2020 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 10, 2020 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 11, 2020 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 12, 2020 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 1, 2021 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 2, 2021 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 3, 2021 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 4, 2021 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 5, 2021 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 6, 2021 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 7, 2021 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 8, 2021 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 9, 2021 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 10, 2021 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 11, 2021 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 12, 2021 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 1, 2022 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 2, 2022 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 3, 2022 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 4, 2022 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 5, 2022 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 6, 2022 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 7, 2022 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 8, 2022 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 9, 2022 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 10, 2022 },
                    { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 12, 2022 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 1, 2014 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 3, 2014 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 5, 2014 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 6, 2014 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 7, 2014 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 8, 2014 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 9, 2014 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 10, 2014 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 11, 2014 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 12, 2014 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 1, 2015 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 2, 2015 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 3, 2015 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 4, 2015 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 5, 2015 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 6, 2015 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 8, 2015 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 9, 2015 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 10, 2015 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 11, 2015 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 12, 2015 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 1, 2016 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 2, 2016 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 3, 2016 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 5, 2016 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 6, 2016 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 7, 2016 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 10, 2016 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 11, 2016 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 12, 2016 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 1, 2017 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 2, 2017 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 3, 2017 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 4, 2017 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 5, 2017 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 6, 2017 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 7, 2017 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 8, 2017 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 9, 2017 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 10, 2017 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 11, 2017 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 12, 2017 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 1, 2018 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 2, 2018 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 3, 2018 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 4, 2018 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 5, 2018 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 6, 2018 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 7, 2018 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 8, 2018 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 9, 2018 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 10, 2018 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 11, 2018 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 12, 2018 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 1, 2019 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 2, 2019 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 3, 2019 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 4, 2019 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 5, 2019 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 6, 2019 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 7, 2019 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 8, 2019 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 9, 2019 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 10, 2019 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 12, 2019 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 1, 2020 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 2, 2020 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 3, 2020 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 4, 2020 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 5, 2020 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 6, 2020 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 8, 2020 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 9, 2020 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 10, 2020 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 11, 2020 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 12, 2020 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 1, 2021 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 2, 2021 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 3, 2021 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 4, 2021 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 5, 2021 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 6, 2021 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 7, 2021 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 8, 2021 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 9, 2021 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 10, 2021 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 11, 2021 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 12, 2021 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 1, 2022 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 2, 2022 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 3, 2022 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 4, 2022 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 5, 2022 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 6, 2022 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 7, 2022 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 8, 2022 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 9, 2022 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 10, 2022 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 11, 2022 },
                    { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 12, 2022 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 1, 2014 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 2, 2014 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 3, 2014 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 4, 2014 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 5, 2014 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 6, 2014 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 7, 2014 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 8, 2014 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 9, 2014 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 10, 2014 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 11, 2014 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 12, 2014 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 1, 2015 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 2, 2015 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 3, 2015 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 4, 2015 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 5, 2015 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 6, 2015 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 7, 2015 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 8, 2015 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 9, 2015 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 10, 2015 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 11, 2015 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 12, 2015 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 1, 2016 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 3, 2016 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 5, 2016 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 6, 2016 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 7, 2016 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 8, 2016 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 9, 2016 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 10, 2016 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 11, 2016 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 12, 2016 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 1, 2017 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 2, 2017 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 3, 2017 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 6, 2017 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 7, 2017 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 8, 2017 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 9, 2017 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 10, 2017 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 12, 2017 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 1, 2018 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 2, 2018 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 3, 2018 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 4, 2018 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 5, 2018 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 6, 2018 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 7, 2018 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 8, 2018 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 9, 2018 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 10, 2018 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 11, 2018 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 12, 2018 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 1, 2019 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 2, 2019 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 3, 2019 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 4, 2019 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 5, 2019 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 6, 2019 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 7, 2019 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 8, 2019 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 9, 2019 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 10, 2019 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 11, 2019 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 12, 2019 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 1, 2020 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 2, 2020 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 3, 2020 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 4, 2020 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 5, 2020 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 6, 2020 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 7, 2020 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 9, 2020 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 10, 2020 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 11, 2020 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 2, 2021 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 3, 2021 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 4, 2021 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 5, 2021 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 6, 2021 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 7, 2021 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 8, 2021 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 9, 2021 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 10, 2021 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 11, 2021 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 12, 2021 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 1, 2022 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 2, 2022 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 3, 2022 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 4, 2022 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 5, 2022 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 6, 2022 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 7, 2022 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 8, 2022 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 9, 2022 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 10, 2022 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 11, 2022 },
                    { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 12, 2022 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 1, 2014 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 2, 2014 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 3, 2014 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 4, 2014 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 5, 2014 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 6, 2014 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 7, 2014 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 8, 2014 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 9, 2014 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 10, 2014 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 11, 2014 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 12, 2014 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 1, 2015 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 2, 2015 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 3, 2015 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 4, 2015 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 7, 2015 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 8, 2015 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 9, 2015 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 11, 2015 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 1, 2016 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 2, 2016 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 3, 2016 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 4, 2016 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 5, 2016 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 6, 2016 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 7, 2016 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 8, 2016 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 9, 2016 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 10, 2016 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 11, 2016 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 12, 2016 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 2, 2017 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 3, 2017 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 4, 2017 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 5, 2017 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 6, 2017 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 7, 2017 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 8, 2017 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 9, 2017 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 10, 2017 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 11, 2017 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 12, 2017 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 1, 2018 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 2, 2018 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 3, 2018 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 4, 2018 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 5, 2018 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 6, 2018 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 7, 2018 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 8, 2018 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 9, 2018 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 10, 2018 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 11, 2018 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 12, 2018 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 1, 2019 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 2, 2019 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 3, 2019 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 4, 2019 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 5, 2019 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 6, 2019 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 7, 2019 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 8, 2019 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 9, 2019 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 10, 2019 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 11, 2019 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 12, 2019 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 1, 2020 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 2, 2020 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 3, 2020 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 4, 2020 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 5, 2020 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 6, 2020 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 7, 2020 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 8, 2020 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 9, 2020 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 10, 2020 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 11, 2020 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 12, 2020 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 1, 2021 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 2, 2021 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 3, 2021 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 4, 2021 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 7, 2021 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 8, 2021 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 9, 2021 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 11, 2021 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 12, 2021 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 1, 2022 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 2, 2022 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 3, 2022 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 4, 2022 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 5, 2022 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 6, 2022 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 7, 2022 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 8, 2022 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 9, 2022 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 10, 2022 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 11, 2022 },
                    { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 12, 2022 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 1, 2014 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 2, 2014 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 3, 2014 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 4, 2014 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 5, 2014 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 6, 2014 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 7, 2014 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 8, 2014 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 9, 2014 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 10, 2014 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 11, 2014 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 12, 2014 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 1, 2015 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 2, 2015 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 3, 2015 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 4, 2015 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 5, 2015 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 6, 2015 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 8, 2015 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 9, 2015 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 10, 2015 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 12, 2015 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 1, 2016 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 3, 2016 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 5, 2016 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 6, 2016 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 7, 2016 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 9, 2016 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 10, 2016 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 11, 2016 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 12, 2016 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 1, 2017 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 2, 2017 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 3, 2017 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 4, 2017 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 5, 2017 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 6, 2017 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 7, 2017 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 9, 2017 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 10, 2017 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 11, 2017 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 1, 2018 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 2, 2018 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 3, 2018 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 4, 2018 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 5, 2018 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 6, 2018 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 7, 2018 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 8, 2018 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 9, 2018 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 11, 2018 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 12, 2018 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 1, 2019 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 2, 2019 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 3, 2019 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 4, 2019 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 5, 2019 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 6, 2019 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 7, 2019 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 8, 2019 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 9, 2019 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 10, 2019 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 11, 2019 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 12, 2019 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 1, 2020 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 2, 2020 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 3, 2020 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 4, 2020 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 5, 2020 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 6, 2020 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 7, 2020 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 8, 2020 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 9, 2020 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 10, 2020 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 11, 2020 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 12, 2020 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 1, 2021 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 2, 2021 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 3, 2021 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 4, 2021 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 5, 2021 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 6, 2021 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 7, 2021 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 8, 2021 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 9, 2021 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 10, 2021 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 11, 2021 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 12, 2021 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 1, 2022 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 2, 2022 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 3, 2022 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 4, 2022 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 5, 2022 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 6, 2022 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 7, 2022 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 8, 2022 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 9, 2022 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 10, 2022 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 11, 2022 },
                    { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 12, 2022 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 1, 2014 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 2, 2014 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 3, 2014 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 4, 2014 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 5, 2014 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 6, 2014 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 7, 2014 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 8, 2014 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 9, 2014 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 10, 2014 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 11, 2014 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 12, 2014 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 1, 2015 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 2, 2015 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 3, 2015 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 4, 2015 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 6, 2015 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 7, 2015 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 8, 2015 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 9, 2015 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 10, 2015 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 11, 2015 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 12, 2015 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 1, 2016 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 2, 2016 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 3, 2016 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 4, 2016 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 5, 2016 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 7, 2016 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 9, 2016 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 10, 2016 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 11, 2016 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 12, 2016 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 1, 2017 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 3, 2017 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 4, 2017 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 5, 2017 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 6, 2017 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 7, 2017 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 8, 2017 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 9, 2017 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 10, 2017 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 11, 2017 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 12, 2017 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 1, 2018 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 2, 2018 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 3, 2018 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 4, 2018 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 5, 2018 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 6, 2018 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 7, 2018 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 8, 2018 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 10, 2018 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 11, 2018 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 12, 2018 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 1, 2019 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 2, 2019 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 3, 2019 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 4, 2019 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 5, 2019 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 6, 2019 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 7, 2019 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 8, 2019 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 9, 2019 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 10, 2019 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 11, 2019 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 12, 2019 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 1, 2020 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 2, 2020 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 3, 2020 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 4, 2020 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 5, 2020 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 6, 2020 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 7, 2020 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 8, 2020 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 9, 2020 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 10, 2020 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 11, 2020 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 1, 2021 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 2, 2021 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 3, 2021 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 4, 2021 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 5, 2021 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 7, 2021 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 8, 2021 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 9, 2021 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 10, 2021 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 11, 2021 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 12, 2021 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 1, 2022 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 2, 2022 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 3, 2022 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 4, 2022 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 5, 2022 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 6, 2022 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 7, 2022 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 8, 2022 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 9, 2022 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 10, 2022 },
                    { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 12, 2022 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 1, 2014 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 2, 2014 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 3, 2014 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 4, 2014 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 5, 2014 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 6, 2014 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 7, 2014 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 8, 2014 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 9, 2014 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 10, 2014 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 11, 2014 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 12, 2014 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 1, 2015 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 2, 2015 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 3, 2015 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 4, 2015 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 5, 2015 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 6, 2015 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 7, 2015 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 8, 2015 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 9, 2015 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 10, 2015 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 11, 2015 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 12, 2015 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 1, 2016 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 2, 2016 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 3, 2016 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 4, 2016 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 5, 2016 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 6, 2016 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 7, 2016 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 8, 2016 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 10, 2016 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 11, 2016 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 12, 2016 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 2, 2017 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 3, 2017 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 4, 2017 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 5, 2017 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 6, 2017 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 7, 2017 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 8, 2017 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 9, 2017 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 10, 2017 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 11, 2017 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 12, 2017 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 1, 2018 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 2, 2018 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 3, 2018 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 4, 2018 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 5, 2018 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 6, 2018 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 7, 2018 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 8, 2018 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 9, 2018 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 10, 2018 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 11, 2018 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 12, 2018 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 1, 2019 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 3, 2019 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 4, 2019 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 5, 2019 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 7, 2019 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 9, 2019 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 10, 2019 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 11, 2019 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 12, 2019 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 1, 2020 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 2, 2020 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 3, 2020 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 4, 2020 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 5, 2020 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 6, 2020 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 7, 2020 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 8, 2020 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 9, 2020 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 10, 2020 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 11, 2020 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 12, 2020 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 1, 2021 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 2, 2021 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 3, 2021 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 4, 2021 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 5, 2021 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 6, 2021 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 8, 2021 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 9, 2021 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 10, 2021 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 11, 2021 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 12, 2021 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 3, 2022 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 4, 2022 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 5, 2022 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 6, 2022 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 7, 2022 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 8, 2022 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 9, 2022 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 10, 2022 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 11, 2022 },
                    { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 12, 2022 }
                });

            migrationBuilder.InsertData(
                table: "SubscriptionPaid",
                columns: new[] { "MemberId", "Month", "Year" },
                values: new object[,]
                {
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 1, 2014 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 2, 2014 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 3, 2014 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 4, 2014 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 5, 2014 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 6, 2014 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 7, 2014 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 8, 2014 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 9, 2014 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 10, 2014 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 11, 2014 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 12, 2014 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 1, 2015 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 2, 2015 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 3, 2015 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 4, 2015 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 5, 2015 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 6, 2015 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 7, 2015 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 8, 2015 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 9, 2015 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 10, 2015 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 12, 2015 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 1, 2016 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 2, 2016 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 4, 2016 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 5, 2016 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 6, 2016 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 7, 2016 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 8, 2016 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 9, 2016 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 10, 2016 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 11, 2016 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 12, 2016 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 1, 2017 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 2, 2017 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 3, 2017 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 4, 2017 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 5, 2017 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 6, 2017 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 7, 2017 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 9, 2017 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 10, 2017 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 11, 2017 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 12, 2017 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 1, 2018 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 2, 2018 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 3, 2018 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 5, 2018 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 6, 2018 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 7, 2018 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 8, 2018 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 9, 2018 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 10, 2018 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 11, 2018 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 12, 2018 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 1, 2019 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 2, 2019 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 3, 2019 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 4, 2019 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 5, 2019 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 7, 2019 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 8, 2019 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 9, 2019 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 10, 2019 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 11, 2019 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 1, 2020 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 2, 2020 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 3, 2020 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 4, 2020 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 5, 2020 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 6, 2020 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 7, 2020 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 8, 2020 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 10, 2020 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 11, 2020 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 12, 2020 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 1, 2021 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 2, 2021 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 3, 2021 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 4, 2021 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 5, 2021 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 6, 2021 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 7, 2021 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 8, 2021 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 9, 2021 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 10, 2021 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 11, 2021 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 12, 2021 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 1, 2022 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 2, 2022 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 3, 2022 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 4, 2022 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 6, 2022 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 7, 2022 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 8, 2022 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 9, 2022 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 10, 2022 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 11, 2022 },
                    { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 12, 2022 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 1, 2014 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 2, 2014 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 3, 2014 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 4, 2014 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 6, 2014 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 7, 2014 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 8, 2014 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 9, 2014 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 10, 2014 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 11, 2014 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 12, 2014 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 1, 2015 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 2, 2015 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 3, 2015 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 4, 2015 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 5, 2015 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 6, 2015 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 7, 2015 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 9, 2015 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 10, 2015 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 11, 2015 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 12, 2015 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 1, 2016 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 2, 2016 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 3, 2016 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 4, 2016 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 5, 2016 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 6, 2016 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 7, 2016 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 8, 2016 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 9, 2016 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 10, 2016 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 11, 2016 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 12, 2016 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 1, 2017 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 2, 2017 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 3, 2017 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 4, 2017 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 5, 2017 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 6, 2017 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 7, 2017 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 8, 2017 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 9, 2017 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 10, 2017 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 11, 2017 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 12, 2017 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 1, 2018 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 3, 2018 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 4, 2018 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 5, 2018 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 7, 2018 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 8, 2018 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 9, 2018 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 10, 2018 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 11, 2018 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 12, 2018 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 1, 2019 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 2, 2019 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 3, 2019 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 5, 2019 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 6, 2019 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 7, 2019 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 8, 2019 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 10, 2019 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 11, 2019 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 12, 2019 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 1, 2020 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 2, 2020 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 3, 2020 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 4, 2020 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 5, 2020 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 6, 2020 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 7, 2020 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 8, 2020 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 9, 2020 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 10, 2020 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 11, 2020 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 12, 2020 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 1, 2021 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 2, 2021 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 3, 2021 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 4, 2021 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 5, 2021 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 6, 2021 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 7, 2021 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 8, 2021 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 9, 2021 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 10, 2021 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 1, 2022 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 2, 2022 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 3, 2022 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 4, 2022 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 5, 2022 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 6, 2022 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 7, 2022 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 8, 2022 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 9, 2022 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 10, 2022 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 11, 2022 },
                    { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 12, 2022 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionPaid_Members_MemberId",
                table: "SubscriptionPaid",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionPaid_Members_MemberId",
                table: "SubscriptionPaid");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubscriptionPaid",
                table: "SubscriptionPaid");

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("0299b1c6-d691-43e9-9bba-a3c5f49ca89b"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("02b893d1-0f36-405b-a975-3b2e2aedec19"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("036530d7-0b1f-4e47-88fb-94ffb57c327c"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("036999c9-6d44-4433-b665-4b8fc5a89c09"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("07647051-dac6-4fcc-a8a2-fc124a037d21"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("09984f5b-bfa3-4a52-85be-87b52d79b820"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("09f87079-008a-46ff-8800-63378e9e004c"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("0a8d3c2f-5f5c-4424-9787-50cca6618580"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("0c4e9f46-d21d-427c-88d7-f3505560399f"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("0ec1d47b-d80e-4b88-8e7b-82ba6333e44b"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("0f07ed40-3c65-46b7-b23b-bc86bec1f768"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("0faae868-d6a1-4d55-b203-079f40f3d71c"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("10439635-6d82-4ca6-bea9-ddf5007ee35d"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("10911b73-964d-49eb-8fb5-70951fa02021"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("11c7b9bb-e29e-42b5-ae6b-2426ef31fa1f"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("11d676df-54d0-468a-ab4a-318269532d54"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("11e9daf3-a5dd-471a-9406-106cffc937d3"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("11ff9b1a-6450-4d29-a2d1-3c4ec75a336b"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("179db9da-7a92-49bc-8404-bb0bc99b82e6"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("19aa4f31-b839-439e-bc91-13faee7ad8c6"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("19b79715-a021-495b-bfbd-7a43abe4ef85"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("19f47dfd-173c-4787-964d-d133bae1800c"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("1ce78307-f537-4734-b0ac-6e36b1fa4ab2"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("1d158dbe-6ec1-41ca-99ad-8067b1c3679a"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("1e57622f-2d5d-4d7e-bca4-810b3d868d11"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("1e627596-543d-42a7-b9a6-3041a6477024"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("21241f98-de48-4621-895f-85769fc3546d"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("232b2392-3063-4c12-8051-6e1de77bb141"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("242d3e5b-d59b-46db-abc8-8ff5dbd2c92a"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("24337f2f-5567-43ad-bbb8-3512aaad5c41"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("2461e8df-a701-4f9f-a6e8-6254c2bd0a8c"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("2462f2d3-0ffb-4431-9fc3-62dc316494b8"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("24799b6c-6c12-44ff-9f65-60d4fa2f58c7"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("24caeda4-ab79-4d6d-b8f1-89c320ef4b21"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("259950c1-3873-4f60-b4d5-45cbabfe4c2a"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("269b7641-c49c-43a2-9031-56532bb71a9b"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("273843a9-ef1e-475e-8c59-ac7337ba0a90"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("2ae15c91-0ffe-42d3-9d8d-385663a547e5"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("2b7e5cc4-a707-4895-bfe5-6f08c11fc574"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("2c72ab14-4781-46a0-a339-dfb0881b2497"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("2da9bf22-da72-493f-bac0-82ecaacd796a"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("3011139c-5e45-42bc-98f8-0b37fc233ddb"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("30a745a1-8d3f-41a2-a66e-82e82f6e7372"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("30aa2f8f-b57e-4c65-a23e-1bd1497bbcfe"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("34053bc9-dc33-4ea6-95a2-a44fd1c0943e"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("3424a46b-d79e-4452-a0c6-f8967a0cf28a"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("346cbc6f-c8e3-41d7-8f48-569acfe2e0e4"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("347d9547-de25-4653-a9e1-6dea195bcae5"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("35c45c37-f757-488d-a25e-2de63753b8fa"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("3707ce56-f216-4c70-80d9-deed4f7cd054"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("386eddb8-07d1-434f-a52c-40b6b2744031"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("3c7b1e26-6bc3-4dd0-8248-55e5188a64af"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("3c839503-d62e-49ce-9a0f-fad270cf51c1"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("3cdcd982-241a-4a72-aac6-bb009ff60cb0"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("3cf8d38f-f21d-47d4-9c1d-6c2c20e133e9"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("3e3f6637-09b8-4808-b130-2c235207b390"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("43d2a8c3-0991-406d-b13e-c6cc6ab0e942"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("44f0bb3f-f4df-4a79-b7cc-093c746398e5"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("4631af53-5896-407a-bcc0-ae8a8b07d1da"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("4639b988-7140-40c3-b602-e3b87da8bb0c"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("4ba216a7-8639-4ee2-8cb9-a881936b0504"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("4be7d434-e2be-4ff7-9cda-e88d47d9e2a2"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("4bfd8669-9339-4501-bdfb-3110432d7cf1"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("4c5c1354-a37a-4dd7-9910-b38fff6189e3"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("4e39ec92-158c-4880-acb0-c43654488b60"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("50283af1-515c-4c16-b3e9-c22dc355f4d2"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("50928a4d-8df8-4563-ac2a-d1fb57294393"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("52341505-93cc-4ef3-bdc2-b64ce41a808d"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("5248e527-d5be-461d-b2bb-58071c0a78dd"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("52e1e587-b510-453e-a7fe-b315d1c19ba9"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("5474f454-0fe7-487e-83cc-70b9aed1cdb6"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("56be3fbe-6b8a-4899-a677-c3942659c6c4"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("59cb3ba8-86b6-40c2-8407-44d9ac48c60b"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("5a982436-b296-4e11-a05a-1c7c64659cb3"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("5f333ab7-65d6-4992-83ba-abc2f759928f"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("628dce06-646d-4709-ac3e-625d9af17583"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("631c2291-4d19-4aa3-96e2-0adf24722dee"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("63ca9a4b-1ace-4d8a-a9b9-cdfbf478c764"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("6437b407-df55-44b3-bcd1-061f668e3f3e"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("658b6c7b-1fa0-4f35-a020-90e291ad0276"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("67315dbe-2836-4475-8e64-ea336b63477c"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("67d48127-4052-41de-9334-502b1bbda24c"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("6874ef16-7dbf-4728-8774-da1cf7b0c5a2"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("68a5316c-949d-403b-936e-1d421835181f"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("6a7867c2-d282-4eec-8645-91b2ad83adc0"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("6c754b53-7f9e-49b5-a4dc-19f4d0c2aa39"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("6e77faf1-4003-4900-90c5-c1db629b7b41"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("72a7a61e-dd21-4aa5-a0e9-a6c5108716d5"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("73155cba-b088-489d-8961-d0b99d428ac3"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("75848a91-215c-45b8-babd-6868457bd7bf"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("77d258b7-4c16-4338-9956-9dc65ff73387"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("7aa582a1-5123-4824-bd50-e5f6cd389326"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("7ad46726-25da-478b-aeca-a60b94eb6eca"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("7bcdeb48-d407-4fa0-a4bc-453d5e577d34"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("7cf393f6-a474-4be4-be9b-56d1d51334db"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("7e03261a-b6ea-48b1-ad9a-e143b36f486a"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("7f852c4d-4607-4406-8803-00aef2d50c87"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("7fc95971-55a1-4261-9f1d-aa0883bc8020"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("8121e94a-195b-43fa-89ba-7bca51b8f33f"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("82f3b824-c7b9-4467-9388-f81896247f7e"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("83500a5c-d0e8-4298-a62e-c0639fa03f37"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("8461c703-e876-4860-b1ea-df14c83cc425"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("84fbaee4-f1d9-435e-8fb5-08c3b943edda"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("8528eeb7-0955-4bc0-9daa-fe7260cc472f"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("87398fe6-b561-4b87-8d27-11c0355e9967"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("89df0610-576b-410e-a711-a41eab091d67"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("89e52898-70c3-47b9-9b3f-fac07f29306d"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("8b2aaded-85af-49d6-9406-514946faecd8"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("8c74d397-d2af-454f-b9bd-a15ce368afa3"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("8c893c34-adc7-4658-b80b-eb1698623c5c"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("8d2254f7-0e52-49d6-a161-95db10c9e515"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("8e09b500-1d3c-46b7-9791-ec0d7370a7db"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("8ecd5e3a-0e42-4dba-92ac-a72de2822b59"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("8f208fcd-b1b6-4326-8760-e57582f7bcb6"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("9491eddc-25a9-4e56-b210-48d7f3741fca"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("99759217-05c0-4e68-afb6-d900e29d3227"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("99ba6500-c11e-47b5-ada7-bcaa25a44260"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("9b806b79-a84d-4a94-a46a-8e0d6d4150b4"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("9d0f0468-4714-4936-baf9-1d68c7a47ce8"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("9d8b03dc-abac-4302-85a9-bffaf06238b1"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("9f5d73f7-2ef0-4357-8cf7-7a148dc3c95c"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("a068f6b3-3275-436e-87b4-c1b96a98fa43"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("a2bbb6bf-03e3-45b2-b1b0-4c397ad3d641"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("a34263ad-219b-4626-9769-42b78d440ce8"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("a46cf232-14c9-4ab0-a8cb-3974a6ca07bb"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("a571016a-64ba-4755-9a0d-b93868a85f8d"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("a5d07af5-6bbb-4821-a3a1-1b3335c7d65a"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("a9131280-e941-43d5-8f2c-19e78cbf288b"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("ab865754-a8cb-4372-9224-d91acfd525e6"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("aba52b80-8c90-448e-99ed-28af085ca1ae"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("aeb26b4e-371f-43f6-a889-2b45824d8711"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("afa6d9e5-a045-4fe4-99f4-5d801a4e54a2"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("afbc571e-f635-4807-8f4f-c8bc3a1b294d"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("b1e933f6-6168-45bd-a41e-50e96dbe8321"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("b250936a-961c-4b7f-abc0-20760d534438"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("b269822f-55e7-477e-a727-5c0a718a621a"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("b2de3aab-a7f8-4be8-92eb-43cf3e1d71cd"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("b32231bc-4ac2-4097-a0b1-e69be725db5b"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("b4a2876f-332e-40a8-a431-fd4ee9811006"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("b5519773-a991-42fe-92a3-d51a3ccdd5a6"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("b586d8d8-703b-4763-92ee-36674b0eb924"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("b6079a00-adc6-46d2-9a81-eef08f27f95c"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("b707fa25-361d-4791-a5f4-ccd2f4648e70"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("b7a0f942-b249-449f-ab8f-f1a48ae54e83"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("b83597ef-677b-4eb9-ac46-ed5e66e2e537"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("b90c8165-def6-4bec-80a6-4f148d8f1cf3"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("b9320128-02a3-4f23-9fe2-dc6226983630"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("b97f61f4-7aed-4bb0-92cd-164b4ec61488"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("be8d504f-385d-49bb-9c42-fde20217de0a"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("bf5ac642-d03e-458f-bca6-7bc3cc8383c3"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("c0a3546a-da43-4a1d-b119-3da53b3762fb"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("c134f909-c1ef-42f0-8b15-238cbfee9fc8"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("c1b1a0e7-b2a7-4c90-856c-c67457a4bca3"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("c2406330-dfd3-4d26-afb5-b9ab3a111927"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("c282efa5-2ffd-4db5-8831-a0f804280fa9"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("c31c163a-3798-418b-8041-d71f4731cabd"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("c4e524b3-9f46-4137-a7d3-eccde1b3f62e"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("c5b897a4-2988-40c5-844d-66546411f05f"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("c6757e7c-d4b3-4cd6-88f2-112cd92a21e4"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("c77bfdd4-686b-40cd-8282-f49ee343c9ca"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("cc2ce12f-4fcf-4fd8-bc1e-d8a81f4f6a4c"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("ccc2b873-f894-4690-8daf-25a9049fe040"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("cce44449-60ab-4481-b72f-d676c6beb120"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("cdd1d5dd-4346-410c-bdd3-0182b11014de"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("cdffb4fe-dad4-4844-8b13-add96b16f1aa"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("ce5f60f3-94df-469a-a72e-bb54a9962aba"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("d295d7ce-1013-442a-ada0-72871eac84e8"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("d518db83-ca37-4957-9cb5-80d289d18991"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("d60fef30-8fc5-4f8c-a023-60a08a615e88"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("d6ef68a8-a2c5-4bd9-b393-be54d40a3e20"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("d8e87519-0d58-4ad0-b83b-216c5db71767"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("da293678-720f-4bad-b778-8aad17623da1"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("dacc17a6-6cd2-4d1e-95d5-5788260213ec"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("db97cc63-91f9-4280-9006-b2f74f643694"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("dc3c5337-9f74-4686-b852-22de7742e7d1"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("dc876568-eab4-4f8f-aa29-717c7d90ae20"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("df0bea3a-9e9a-4444-a3a8-f3676da01df0"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("e098b51a-6dda-47cd-a54b-cf1ad691ef8c"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("e1e1e638-9bb9-41e4-8992-165e5f69af1a"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("e38b671e-bad7-4fb5-aafb-0ee0ca93cd6c"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("e451141e-7065-45c7-aaad-e378009f3025"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("e61912e6-cb74-4d63-9490-decf85ba6c3b"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("e8252464-26f9-4ce5-8f64-c8bc2560051d"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("e889bc6e-837e-46bf-a0a7-5f10a9c1c3aa"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("eae35487-2284-45ef-9b7d-ebcea7ff076d"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("ec86caf7-a108-4b2a-862b-071740a4651c"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("ed58c916-ea8a-4eb9-8f01-2ec5a895eaa4"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("ef1e0368-5e74-4781-a6d3-fe7c0c660515"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("f143f7ac-7ac8-4800-9435-014c6eedd600"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("f1d64476-eda7-489c-b960-8ef99938c5db"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("f3eff3c7-c911-414c-8e72-2358195ef9a1"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("f515b436-394a-44e1-aa17-7ce1c7f46410"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("f6924e32-7dea-4001-aaef-67e3afc21ae9"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("f6f18900-9130-40e6-9365-bcaaf83761b4"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("f77ef7fe-f9dd-48a8-b990-8f0c6ceb7f53"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("f7b6b5a0-30b1-492a-8efc-e1618100a897"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("fb029faa-e7ba-4d24-8f6b-590a3fcc4c96"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("fd35c274-bb1d-4af6-b210-0e5c7d537ba1"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("fe70745b-f8e1-4af4-b8ae-4770132750e6"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("ff955b51-b459-4c9a-875b-2a44a6bb9d66"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("09bbfd7a-2dd3-4ab8-86c1-1cf76a93bf5a"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("0aaf91b7-b1f9-4b82-9efd-8f9d7069ac7b"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("0b0404af-da77-4a5d-84c1-149fed6795e9"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("4fc833b0-7bb6-45a7-8b57-40d77cde7927"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("561f6eee-921e-4638-8e35-51a8bc2b4b9b"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("58545b2b-bf38-47f2-a4e7-b78c68225d1f"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("6a5165e9-d667-4984-82e3-5bcc12009da5"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("6bd940fa-f1bf-437c-bb6b-993a2da33701"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("849c8f78-501a-40ce-b374-73e0a7249790"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("9a71b829-fb15-42d4-b733-028d0ff5a387"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("9baa5577-eca8-49b7-8ccb-0e9ade6fdc92"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("9d7b864a-ee6f-46c6-ab2d-ad6a8e803cb7"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("a2be2120-bea1-462e-8ddc-0d218cb0628b"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("a82b7de4-969a-4c30-837d-fd90883d4901"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("c653c92b-3d0a-4faa-b605-1fd2c9ec180d"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("c89f3cb9-a5ae-4b68-a0fc-807d7f4331a6"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("ca8e3cdf-1425-41d1-9493-aaab5ecad07f"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("cce40cc0-8e6d-41e2-9bbe-1127690bb70d"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("dab9e513-99c2-4d4f-91ad-6da85be3a317"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("db02d941-c810-427c-9fe0-e3e93ab34094"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("e515b746-6c8b-4bd5-a6b0-2c5f35d258e9"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("eb9afd42-0165-4074-99bf-e9e114e49a64"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("ef15a7dd-6f56-47b6-8b1b-88e9424b5d41"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("f5a28e04-194b-442b-a590-f6a94d356ce9"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("f7eeae1c-9aa9-4e91-b372-ed433a1cbcc7"));

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 1, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 2, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 3, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 4, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 5, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 6, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 7, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 8, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 9, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 10, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 11, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 12, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 1, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 2, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 3, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 4, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 5, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 6, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 7, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 8, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 9, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 10, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 11, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 12, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 1, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 2, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 3, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 4, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 5, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 6, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 8, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 9, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 10, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 11, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 12, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 1, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 2, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 3, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 4, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 5, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 6, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 7, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 8, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 9, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 10, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 11, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 1, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 2, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 3, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 4, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 5, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 6, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 7, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 8, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 10, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 11, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 12, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 1, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 2, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 3, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 4, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 6, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 7, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 8, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 9, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 10, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 11, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 12, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 1, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 2, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 3, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 4, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 5, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 6, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 7, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 8, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 9, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 10, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 11, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 12, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 1, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 2, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 4, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 5, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 6, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 7, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 8, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 9, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 10, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 11, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 12, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 1, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 2, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 4, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 5, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 7, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 8, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 9, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 10, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"), 11, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 1, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 2, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 3, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 4, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 5, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 6, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 7, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 8, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 9, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 10, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 11, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 12, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 1, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 2, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 3, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 4, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 5, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 6, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 7, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 8, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 9, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 10, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 11, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 12, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 1, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 2, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 3, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 4, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 5, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 6, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 7, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 8, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 9, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 10, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 11, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 1, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 2, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 3, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 4, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 5, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 6, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 7, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 8, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 9, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 10, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 11, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 1, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 2, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 3, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 4, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 5, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 7, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 8, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 9, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 10, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 11, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 12, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 2, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 3, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 4, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 5, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 6, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 8, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 9, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 10, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 11, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 12, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 1, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 2, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 3, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 4, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 5, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 6, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 7, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 8, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 9, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 10, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 11, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 12, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 1, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 2, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 3, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 4, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 5, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 6, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 8, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 9, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 10, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 11, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 12, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 2, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 3, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 4, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 5, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 6, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 7, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 8, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 10, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 11, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"), 12, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 1, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 2, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 3, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 4, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 5, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 6, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 7, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 8, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 9, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 10, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 11, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 12, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 1, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 2, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 3, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 5, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 6, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 7, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 8, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 9, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 10, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 11, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 2, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 3, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 4, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 5, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 6, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 8, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 9, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 10, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 12, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 1, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 2, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 3, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 4, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 7, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 8, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 9, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 10, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 11, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 12, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 1, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 2, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 3, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 4, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 5, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 6, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 7, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 8, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 9, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 10, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 11, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 12, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 1, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 2, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 3, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 5, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 6, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 7, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 8, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 9, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 10, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 11, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 12, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 1, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 2, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 3, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 4, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 5, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 6, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 7, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 8, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 9, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 10, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 11, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 12, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 1, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 2, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 3, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 4, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 5, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 6, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 7, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 8, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 9, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 10, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 11, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 12, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 1, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 2, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 3, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 4, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 5, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 6, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 7, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 8, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 9, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 10, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 11, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"), 12, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 1, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 2, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 3, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 4, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 5, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 6, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 7, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 8, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 9, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 10, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 11, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 1, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 2, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 3, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 4, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 5, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 6, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 7, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 8, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 9, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 10, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 11, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 12, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 1, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 2, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 3, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 4, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 5, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 6, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 7, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 8, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 9, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 10, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 11, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 1, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 2, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 3, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 4, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 5, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 6, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 7, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 8, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 9, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 11, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 12, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 1, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 2, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 3, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 4, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 5, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 6, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 8, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 9, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 10, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 11, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 12, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 1, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 2, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 3, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 4, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 5, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 6, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 7, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 8, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 9, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 10, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 11, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 12, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 1, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 2, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 3, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 4, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 5, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 6, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 7, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 8, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 9, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 10, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 11, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 12, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 1, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 3, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 4, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 5, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 6, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 8, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 9, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 10, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 11, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 12, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 1, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 2, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 4, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 5, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 6, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 7, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 8, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 9, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 10, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"), 11, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 1, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 2, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 3, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 4, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 5, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 6, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 7, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 8, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 9, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 10, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 11, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 12, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 1, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 2, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 3, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 4, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 5, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 6, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 7, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 9, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 10, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 11, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 12, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 1, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 2, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 3, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 4, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 6, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 7, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 8, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 9, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 11, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 12, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 1, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 2, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 3, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 4, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 7, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 8, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 9, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 10, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 11, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 12, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 1, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 2, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 3, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 4, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 5, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 6, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 7, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 8, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 9, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 10, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 11, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 12, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 1, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 2, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 3, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 4, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 5, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 6, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 7, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 8, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 9, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 10, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 11, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 12, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 1, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 2, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 3, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 4, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 5, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 6, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 7, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 9, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 10, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 11, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 12, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 1, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 2, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 3, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 4, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 5, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 7, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 9, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 10, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 11, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 12, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 1, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 2, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 3, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 4, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 5, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 6, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 7, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 8, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 9, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 10, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 11, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"), 12, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 2, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 3, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 4, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 5, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 6, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 7, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 8, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 10, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 11, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 12, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 1, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 2, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 3, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 4, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 5, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 6, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 7, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 8, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 9, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 10, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 11, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 12, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 1, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 2, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 3, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 4, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 5, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 6, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 7, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 8, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 9, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 10, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 11, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 12, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 1, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 3, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 5, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 6, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 7, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 8, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 9, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 10, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 11, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 12, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 1, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 2, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 3, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 4, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 5, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 6, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 7, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 8, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 9, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 10, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 11, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 12, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 1, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 2, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 3, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 4, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 5, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 6, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 7, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 8, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 9, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 11, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 12, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 1, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 2, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 3, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 4, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 5, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 6, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 7, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 8, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 9, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 10, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 11, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 1, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 3, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 4, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 5, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 6, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 7, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 8, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 9, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 10, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 11, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 12, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 1, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 2, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 3, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 4, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 5, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 6, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 7, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 8, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 9, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 11, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"), 12, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 1, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 2, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 3, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 4, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 5, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 6, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 7, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 9, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 10, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 11, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 12, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 1, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 2, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 3, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 4, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 5, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 6, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 7, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 8, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 9, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 10, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 11, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 12, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 1, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 2, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 3, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 5, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 6, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 8, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 9, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 10, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 12, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 1, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 2, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 3, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 4, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 6, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 7, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 8, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 9, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 10, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 11, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 12, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 1, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 2, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 3, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 4, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 5, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 6, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 7, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 8, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 9, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 10, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 11, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 12, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 1, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 2, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 3, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 4, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 5, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 6, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 7, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 8, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 9, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 10, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 11, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 12, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 1, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 2, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 3, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 4, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 5, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 6, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 7, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 8, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 9, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 10, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 11, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 12, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 1, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 2, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 3, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 4, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 5, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 6, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 7, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 8, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 9, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 10, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 11, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 2, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 3, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 4, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 5, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 6, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 7, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 8, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 9, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 10, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"), 11, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 2, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 4, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 5, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 6, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 7, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 8, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 9, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 10, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 11, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 1, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 2, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 3, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 4, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 5, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 6, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 7, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 8, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 9, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 10, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 12, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 1, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 2, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 3, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 4, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 5, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 6, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 7, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 8, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 9, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 10, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 11, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 12, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 1, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 2, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 3, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 4, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 5, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 6, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 7, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 8, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 9, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 10, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 11, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 12, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 1, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 2, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 3, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 4, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 5, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 6, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 7, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 8, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 9, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 10, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 11, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 12, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 1, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 2, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 3, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 4, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 5, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 6, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 7, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 8, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 9, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 10, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 11, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 1, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 2, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 3, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 4, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 5, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 6, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 7, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 9, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 11, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 12, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 1, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 2, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 4, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 5, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 6, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 7, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 8, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 9, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 10, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 11, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 12, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 1, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 2, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 3, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 4, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 5, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 6, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 7, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 8, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 9, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 10, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 11, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"), 12, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 1, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 3, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 4, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 5, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 6, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 7, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 8, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 9, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 10, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 11, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 12, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 1, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 3, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 4, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 5, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 6, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 7, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 8, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 9, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 10, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 11, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 12, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 1, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 2, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 3, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 4, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 5, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 6, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 7, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 8, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 9, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 10, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 11, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 12, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 1, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 2, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 4, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 5, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 6, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 7, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 8, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 9, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 11, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 12, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 1, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 2, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 3, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 4, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 5, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 6, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 7, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 8, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 9, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 10, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 11, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 12, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 1, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 2, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 3, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 4, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 5, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 6, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 7, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 8, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 9, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 10, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 12, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 1, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 3, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 5, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 6, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 7, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 8, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 9, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 10, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 11, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 1, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 2, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 3, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 4, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 5, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 6, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 7, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 8, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 9, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 10, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 11, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 12, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 1, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 2, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 3, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 4, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 5, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 6, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 7, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 8, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 9, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 10, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 11, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"), 12, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 1, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 2, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 3, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 4, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 5, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 7, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 8, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 10, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 11, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 12, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 1, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 2, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 3, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 4, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 5, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 6, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 7, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 8, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 9, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 10, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 11, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 12, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 2, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 3, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 4, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 5, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 6, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 7, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 8, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 9, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 10, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 11, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 12, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 1, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 2, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 3, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 4, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 5, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 6, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 7, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 8, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 9, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 10, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 11, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 12, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 1, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 2, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 3, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 4, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 6, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 8, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 9, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 10, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 11, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 12, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 1, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 2, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 3, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 4, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 5, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 6, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 7, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 8, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 9, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 10, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 12, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 1, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 2, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 3, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 4, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 5, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 6, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 7, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 8, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 9, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 10, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 11, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 12, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 1, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 2, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 3, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 4, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 5, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 6, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 7, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 8, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 9, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 10, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 11, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 12, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 1, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 2, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 3, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 4, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 5, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 8, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 9, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 10, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 11, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"), 12, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 1, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 3, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 4, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 5, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 7, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 8, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 9, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 10, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 11, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 12, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 1, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 2, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 3, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 4, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 5, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 6, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 7, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 8, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 9, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 10, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 11, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 12, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 1, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 2, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 3, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 4, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 5, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 6, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 7, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 9, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 10, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 11, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 12, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 1, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 2, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 3, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 4, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 5, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 6, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 7, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 8, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 9, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 10, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 11, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 12, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 1, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 3, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 4, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 5, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 6, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 7, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 9, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 10, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 12, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 1, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 2, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 3, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 4, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 5, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 6, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 7, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 8, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 9, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 10, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 11, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 1, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 2, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 3, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 4, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 5, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 6, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 7, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 8, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 9, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 10, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 11, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 12, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 1, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 3, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 4, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 5, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 6, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 7, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 8, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 9, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 10, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 11, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 12, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 1, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 2, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 3, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 4, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 5, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 6, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 7, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 8, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 9, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 10, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 11, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"), 12, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 1, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 2, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 3, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 4, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 5, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 6, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 7, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 8, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 9, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 10, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 11, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 12, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 1, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 2, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 3, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 4, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 5, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 6, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 7, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 8, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 10, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 11, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 12, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 1, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 2, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 3, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 4, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 5, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 6, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 7, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 8, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 9, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 10, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 11, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 12, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 1, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 2, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 3, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 4, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 5, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 6, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 7, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 8, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 9, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 10, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 11, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 12, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 1, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 2, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 3, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 4, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 6, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 7, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 9, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 10, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 12, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 1, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 2, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 3, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 4, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 5, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 6, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 8, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 9, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 10, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 11, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 12, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 1, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 2, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 3, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 4, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 6, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 7, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 9, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 10, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 11, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 12, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 1, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 2, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 3, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 4, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 5, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 6, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 7, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 8, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 9, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 10, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 11, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 12, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 1, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 2, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 3, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 4, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 5, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 6, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 7, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 8, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 9, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 10, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"), 12, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 1, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 3, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 5, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 6, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 7, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 8, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 9, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 10, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 11, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 12, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 1, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 2, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 3, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 4, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 5, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 6, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 8, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 9, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 10, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 11, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 12, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 1, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 2, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 3, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 5, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 6, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 7, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 10, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 11, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 12, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 1, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 2, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 3, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 4, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 5, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 6, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 7, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 8, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 9, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 10, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 11, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 12, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 1, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 2, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 3, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 4, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 5, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 6, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 7, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 8, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 9, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 10, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 11, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 12, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 1, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 2, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 3, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 4, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 5, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 6, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 7, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 8, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 9, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 10, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 12, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 1, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 2, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 3, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 4, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 5, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 6, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 8, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 9, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 10, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 11, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 12, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 1, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 2, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 3, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 4, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 5, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 6, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 7, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 8, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 9, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 10, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 11, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 12, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 1, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 2, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 3, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 4, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 5, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 6, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 7, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 8, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 9, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 10, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 11, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"), 12, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 1, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 2, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 3, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 4, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 5, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 6, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 7, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 8, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 9, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 10, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 11, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 12, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 1, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 2, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 3, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 4, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 5, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 6, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 7, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 8, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 9, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 10, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 11, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 12, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 1, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 3, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 5, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 6, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 7, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 8, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 9, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 10, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 11, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 12, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 1, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 2, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 3, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 6, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 7, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 8, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 9, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 10, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 12, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 1, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 2, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 3, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 4, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 5, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 6, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 7, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 8, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 9, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 10, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 11, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 12, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 1, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 2, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 3, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 4, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 5, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 6, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 7, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 8, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 9, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 10, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 11, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 12, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 1, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 2, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 3, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 4, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 5, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 6, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 7, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 9, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 10, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 11, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 2, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 3, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 4, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 5, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 6, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 7, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 8, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 9, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 10, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 11, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 12, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 1, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 2, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 3, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 4, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 5, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 6, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 7, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 8, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 9, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 10, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 11, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"), 12, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 1, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 2, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 3, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 4, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 5, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 6, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 7, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 8, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 9, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 10, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 11, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 12, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 1, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 2, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 3, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 4, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 7, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 8, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 9, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 11, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 1, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 2, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 3, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 4, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 5, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 6, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 7, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 8, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 9, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 10, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 11, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 12, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 2, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 3, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 4, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 5, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 6, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 7, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 8, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 9, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 10, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 11, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 12, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 1, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 2, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 3, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 4, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 5, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 6, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 7, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 8, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 9, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 10, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 11, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 12, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 1, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 2, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 3, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 4, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 5, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 6, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 7, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 8, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 9, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 10, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 11, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 12, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 1, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 2, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 3, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 4, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 5, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 6, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 7, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 8, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 9, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 10, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 11, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 12, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 1, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 2, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 3, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 4, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 7, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 8, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 9, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 11, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 12, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 1, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 2, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 3, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 4, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 5, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 6, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 7, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 8, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 9, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 10, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 11, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"), 12, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 1, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 2, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 3, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 4, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 5, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 6, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 7, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 8, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 9, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 10, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 11, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 12, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 1, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 2, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 3, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 4, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 5, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 6, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 8, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 9, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 10, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 12, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 1, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 3, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 5, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 6, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 7, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 9, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 10, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 11, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 12, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 1, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 2, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 3, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 4, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 5, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 6, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 7, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 9, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 10, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 11, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 1, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 2, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 3, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 4, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 5, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 6, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 7, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 8, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 9, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 11, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 12, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 1, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 2, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 3, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 4, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 5, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 6, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 7, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 8, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 9, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 10, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 11, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 12, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 1, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 2, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 3, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 4, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 5, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 6, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 7, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 8, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 9, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 10, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 11, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 12, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 1, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 2, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 3, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 4, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 5, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 6, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 7, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 8, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 9, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 10, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 11, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 12, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 1, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 2, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 3, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 4, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 5, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 6, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 7, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 8, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 9, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 10, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 11, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"), 12, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 1, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 2, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 3, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 4, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 5, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 6, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 7, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 8, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 9, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 10, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 11, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 12, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 1, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 2, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 3, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 4, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 6, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 7, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 8, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 9, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 10, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 11, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 12, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 1, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 2, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 3, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 4, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 5, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 7, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 9, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 10, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 11, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 12, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 1, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 3, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 4, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 5, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 6, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 7, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 8, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 9, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 10, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 11, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 12, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 1, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 2, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 3, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 4, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 5, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 6, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 7, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 8, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 10, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 11, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 12, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 1, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 2, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 3, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 4, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 5, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 6, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 7, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 8, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 9, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 10, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 11, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 12, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 1, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 2, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 3, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 4, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 5, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 6, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 7, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 8, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 9, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 10, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 11, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 1, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 2, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 3, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 4, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 5, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 7, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 8, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 9, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 10, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 11, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 12, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 1, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 2, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 3, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 4, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 5, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 6, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 7, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 8, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 9, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 10, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"), 12, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 1, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 2, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 3, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 4, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 5, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 6, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 7, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 8, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 9, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 10, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 11, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 12, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 1, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 2, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 3, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 4, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 5, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 6, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 7, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 8, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 9, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 10, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 11, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 12, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 1, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 2, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 3, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 4, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 5, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 6, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 7, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 8, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 10, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 11, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 12, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 2, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 3, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 4, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 5, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 6, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 7, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 8, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 9, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 10, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 11, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 12, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 1, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 2, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 3, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 4, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 5, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 6, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 7, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 8, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 9, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 10, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 11, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 12, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 1, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 3, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 4, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 5, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 7, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 9, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 10, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 11, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 12, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 1, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 2, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 3, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 4, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 5, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 6, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 7, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 8, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 9, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 10, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 11, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 12, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 1, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 2, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 3, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 4, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 5, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 6, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 8, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 9, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 10, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 11, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 12, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 3, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 4, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 5, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 6, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 7, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 8, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 9, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 10, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 11, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"), 12, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 1, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 2, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 3, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 4, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 5, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 6, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 7, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 8, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 9, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 10, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 11, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 12, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 1, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 2, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 3, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 4, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 5, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 6, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 7, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 8, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 9, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 10, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 12, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 1, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 2, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 4, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 5, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 6, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 7, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 8, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 9, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 10, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 11, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 12, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 1, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 2, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 3, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 4, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 5, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 6, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 7, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 9, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 10, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 11, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 12, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 1, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 2, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 3, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 5, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 6, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 7, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 8, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 9, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 10, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 11, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 12, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 1, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 2, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 3, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 4, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 5, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 7, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 8, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 9, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 10, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 11, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 1, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 2, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 3, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 4, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 5, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 6, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 7, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 8, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 10, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 11, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 12, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 1, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 2, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 3, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 4, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 5, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 6, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 7, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 8, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 9, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 10, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 11, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 12, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 1, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 2, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 3, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 4, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 6, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 7, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 8, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 9, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 10, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 11, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"), 12, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 1, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 2, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 3, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 4, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 6, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 7, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 8, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 9, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 10, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 11, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 12, 2014 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 1, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 2, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 3, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 4, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 5, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 6, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 7, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 9, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 10, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 11, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 12, 2015 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 1, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 2, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 3, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 4, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 5, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 6, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 7, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 8, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 9, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 10, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 11, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 12, 2016 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 1, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 2, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 3, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 4, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 5, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 6, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 7, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 8, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 9, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 10, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 11, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 12, 2017 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 1, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 3, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 4, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 5, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 7, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 8, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 9, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 10, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 11, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 12, 2018 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 1, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 2, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 3, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 5, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 6, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 7, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 8, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 10, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 11, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 12, 2019 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 1, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 2, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 3, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 4, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 5, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 6, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 7, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 8, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 9, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 10, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 11, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 12, 2020 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 1, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 2, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 3, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 4, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 5, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 6, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 7, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 8, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 9, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 10, 2021 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 1, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 2, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 3, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 4, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 5, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 6, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 7, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 8, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 9, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 10, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 11, 2022 });

            migrationBuilder.DeleteData(
                table: "SubscriptionPaid",
                keyColumns: new[] { "MemberId", "Month", "Year" },
                keyValues: new object[] { new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"), 12, 2022 });

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("10f63855-e956-4988-bef1-4ed538e0bed5"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("1a38497b-743e-4d90-ac68-d8fc53dd3f93"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("2776782f-e6f8-4558-8576-7229d193bc6d"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("2a034009-9ea0-4bac-8033-8cbe7a1e3033"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("3542bdf0-3e38-4b4a-8ce5-bf48cb2f3425"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("43d45f25-3652-4ae8-a0c9-c4b3297142c6"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("45f87280-fbc8-48bf-be53-df5f94ee1fc5"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("5336de74-b1a7-4a0c-8c8b-1850fc871576"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("6612a5d7-10ac-4a51-8d8c-bb5d5f43f141"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("763ef1b7-fc64-45f8-821a-286e532270c8"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("92f88252-ab90-4367-9115-b903c7f16cb0"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("9fd85099-46be-4814-821f-04d0c8a8468f"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("a0add675-d6ca-4859-ba97-d916ec0204fb"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("aee3d7c5-0b2a-451b-8703-99ce7f310019"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("b83a6a17-9862-4b38-b765-70e3c06420a9"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("bda98634-62dc-4070-8c45-486c66a08d0c"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("d0fa8e9a-649b-4c51-bccf-84e99a9aace4"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("dd9a8aa8-28dc-40f8-867c-b676547eabfd"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("e50853e8-64dc-4c3b-9586-861131cb841f"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("faa12bff-f492-42f4-9d18-6fccc4e71eed"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("c646563e-0623-4dc3-aa3b-d87fa69e692f"));

            migrationBuilder.AlterColumn<Guid>(
                name: "MemberId",
                table: "SubscriptionPaid",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "MemeberId",
                table: "SubscriptionPaid",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<int>(
                name: "ZipCode",
                table: "Members",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubscriptionPaid",
                table: "SubscriptionPaid",
                columns: new[] { "MemeberId", "Year", "Month" });

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionPaid_MemberId",
                table: "SubscriptionPaid",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionPaid_Members_MemberId",
                table: "SubscriptionPaid",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");
        }
    }
}
