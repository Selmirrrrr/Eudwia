﻿using System.Security.Cryptography.X509Certificates;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Eudwia.Shared.Enums;

namespace Eudwia.Server.Data.Contexts.Extensions;

public static class ModelBuilderExtensions
{
    private static readonly List<Country> Countries = new()
    {
        new Country {Id = Guid.Parse("3ecaafbc-af46-4a7c-a9dc-6bb7096f8929"), Name = "Afghanistan", Alpha2Code = "AF", Alpha3Code = "AFG"},
        new Country {Id = Guid.Parse("a33a5b08-d624-49b3-b451-8d371deef429"), Name = "Albania", Alpha2Code = "AL", Alpha3Code = "ALB"},
        new Country {Id = Guid.Parse("ef7bc59d-1c60-4cce-b78e-77447839e181"), Name = "Algeria", Alpha2Code = "DZ", Alpha3Code = "DZA"},
        new Country {Id = Guid.Parse("ac38b0f1-134e-41a9-b361-a5012e8e3d3c"), Name = "American Samoa", Alpha2Code = "AS", Alpha3Code = "ASM"},
        new Country {Id = Guid.Parse("0af6985e-b3a8-4225-afbe-42e7e5e9e26b"), Name = "Andorra", Alpha2Code = "AD", Alpha3Code = "AND"},
        new Country {Id = Guid.Parse("cf48f7ca-042f-4a25-81c2-4b48332a7f5a"), Name = "Angola", Alpha2Code = "AO", Alpha3Code = "AGO"},
        new Country {Id = Guid.Parse("011b06b2-3aa8-4047-9e52-47c0ef010e4d"), Name = "Anguilla", Alpha2Code = "AI", Alpha3Code = "AIA"},
        new Country {Id = Guid.Parse("f89b51b9-a6e5-41de-aa3c-77614e91f52e"), Name = "Antarctica", Alpha2Code = "AQ", Alpha3Code = "ATA"},
        new Country {Id = Guid.Parse("6fcffd3e-ac9a-4abd-a44b-b13a5558d743"), Name = "Antigua and Barbuda", Alpha2Code = "AG", Alpha3Code = "ATG"},
        new Country {Id = Guid.Parse("2f7371e6-33bc-4939-9735-034aa10f6ac9"), Name = "Argentina", Alpha2Code = "AR", Alpha3Code = "ARG"},
        new Country {Id = Guid.Parse("37a4d8f9-6ce1-4611-a540-4b54f936c973"), Name = "Armenia", Alpha2Code = "AM", Alpha3Code = "ARM"},
        new Country {Id = Guid.Parse("753d5556-64e7-46cd-bc97-2fa50d0970c2"), Name = "Aruba", Alpha2Code = "AW", Alpha3Code = "ABW"},
        new Country {Id = Guid.Parse("d4a71bbc-eeb2-4693-bc96-25372ccb7929"), Name = "Australia", Alpha2Code = "AU", Alpha3Code = "AUS"},
        new Country {Id = Guid.Parse("08c2fc07-b083-4ce7-8a28-e180ebf2326b"), Name = "Austria", Alpha2Code = "AT", Alpha3Code = "AUT"},
        new Country {Id = Guid.Parse("9f04b793-305a-453e-bc51-1749104536d9"), Name = "Azerbaijan", Alpha2Code = "AZ", Alpha3Code = "AZE"},
        new Country {Id = Guid.Parse("ffd997c4-6cec-4993-8edd-0376784d8973"), Name = "Bahamas (the)", Alpha2Code = "BS", Alpha3Code = "BHS"},
        new Country {Id = Guid.Parse("0841c778-23cb-4ea4-bb5b-950f3d4d2c10"), Name = "Bahrain", Alpha2Code = "BH", Alpha3Code = "BHR"},
        new Country {Id = Guid.Parse("7b56a3a2-d433-4432-a3af-5c3c1872103c"), Name = "Bangladesh", Alpha2Code = "BD", Alpha3Code = "BGD"},
        new Country {Id = Guid.Parse("1ef58b86-ffb9-4e6d-8641-8bdb6bc2e51a"), Name = "Barbados", Alpha2Code = "BB", Alpha3Code = "BRB"},
        new Country {Id = Guid.Parse("a70721d4-6426-4eee-a60f-95fca983cf28"), Name = "Belarus", Alpha2Code = "BY", Alpha3Code = "BLR"},
        new Country {Id = Guid.Parse("59532a0f-0c95-40c5-a1f5-fffb589540f5"), Name = "Belgium", Alpha2Code = "BE", Alpha3Code = "BEL"},
        new Country {Id = Guid.Parse("fd5dba2a-999b-4720-a0a6-d87f39cdd9b3"), Name = "Belize", Alpha2Code = "BZ", Alpha3Code = "BLZ"},
        new Country {Id = Guid.Parse("1b253905-4292-4941-9efb-f8e28762ebe1"), Name = "Benin", Alpha2Code = "BJ", Alpha3Code = "BEN"},
        new Country {Id = Guid.Parse("9744a74d-3c85-4c15-a23b-514580aaf41f"), Name = "Bermuda", Alpha2Code = "BM", Alpha3Code = "BMU"},
        new Country {Id = Guid.Parse("d434e065-5c31-4881-bef3-b53d8adb20ce"), Name = "Bhutan", Alpha2Code = "BT", Alpha3Code = "BTN"},
        new Country {Id = Guid.Parse("653a5814-e9ba-4afa-97c6-3856023e2a86"), Name = "Bolivia (Plurinational State of)", Alpha2Code = "BO", Alpha3Code = "BOL"},
        new Country {Id = Guid.Parse("f1b3c5c2-ad82-440d-aff2-71647f75e400"), Name = "Bonaire, Sint Eustatius and Saba", Alpha2Code = "BQ", Alpha3Code = "BES"},
        new Country {Id = Guid.Parse("20ea933e-023a-4e5b-997e-b9bad3e54cd2"), Name = "Bosnia and Herzegovina", Alpha2Code = "BA", Alpha3Code = "BIH"},
        new Country {Id = Guid.Parse("7bdbabda-d487-4ec9-89b1-015a3c5e9391"), Name = "Botswana", Alpha2Code = "BW", Alpha3Code = "BWA"},
        new Country {Id = Guid.Parse("284dca74-da6d-4228-9df8-5b2f5a344057"), Name = "Bouvet Island", Alpha2Code = "BV", Alpha3Code = "BVT"},
        new Country {Id = Guid.Parse("55024a10-cfe0-472e-8f2f-748a1f960bf5"), Name = "Brazil", Alpha2Code = "BR", Alpha3Code = "BRA"},
        new Country {Id = Guid.Parse("94035b74-9598-4912-b9d4-48f7fbc6120a"), Name = "British Indian Ocean Territory (the)", Alpha2Code = "IO", Alpha3Code = "IOT"},
        new Country {Id = Guid.Parse("30ebf3fe-ebf9-49a5-96cf-9b709a72bc4d"), Name = "Brunei Darussalam", Alpha2Code = "BN", Alpha3Code = "BRN"},
        new Country {Id = Guid.Parse("9d5d0da6-c7a0-4cb1-bdaa-35fae9616974"), Name = "Bulgaria", Alpha2Code = "BG", Alpha3Code = "BGR"},
        new Country {Id = Guid.Parse("555f9d6e-6dd3-477d-8f6a-1131c153e061"), Name = "Burkina Faso", Alpha2Code = "BF", Alpha3Code = "BFA"},
        new Country {Id = Guid.Parse("1dedcb63-8bcc-4bd9-a725-93cbc0a4644e"), Name = "Burundi", Alpha2Code = "BI", Alpha3Code = "BDI"},
        new Country {Id = Guid.Parse("2da08c51-ec1c-4896-b349-5b0d8ca66039"), Name = "Cabo Verde", Alpha2Code = "CV", Alpha3Code = "CPV"},
        new Country {Id = Guid.Parse("96c04e08-db94-4e58-aa3c-7a4b59c31da9"), Name = "Cambodia", Alpha2Code = "KH", Alpha3Code = "KHM"},
        new Country {Id = Guid.Parse("9d937d08-5fab-4689-8622-3b260d1d9a0f"), Name = "Cameroon", Alpha2Code = "CM", Alpha3Code = "CMR"},
        new Country {Id = Guid.Parse("3f95334f-14c0-437b-b7d4-eb5b7023faf2"), Name = "Canada", Alpha2Code = "CA", Alpha3Code = "CAN"},
        new Country {Id = Guid.Parse("5a5d00ef-026f-481a-a7c4-b05870e84c88"), Name = "Cayman Islands (the)", Alpha2Code = "KY", Alpha3Code = "CYM"},
        new Country {Id = Guid.Parse("8d4c6695-ceae-4f48-b6a9-39be1ee88cf4"), Name = "Central African Republic (the)", Alpha2Code = "CF", Alpha3Code = "CAF"},
        new Country {Id = Guid.Parse("3a991f3a-939a-49bf-876d-cf19db30ff14"), Name = "Chad", Alpha2Code = "TD", Alpha3Code = "TCD"},
        new Country {Id = Guid.Parse("6f4a774f-863f-4e09-b8d8-3b22cdca5deb"), Name = "Chile", Alpha2Code = "CL", Alpha3Code = "CHL"},
        new Country {Id = Guid.Parse("2bb4ea20-5db8-4d0e-a398-f6eed7db833c"), Name = "China", Alpha2Code = "CN", Alpha3Code = "CHN"},
        new Country {Id = Guid.Parse("b3639d78-54dc-4fe0-989c-a8d08ab8093d"), Name = "Christmas Island", Alpha2Code = "CX", Alpha3Code = "CXR"},
        new Country {Id = Guid.Parse("b34073c8-5ee0-4990-a7cc-6aacb209b0d3"), Name = "Cocos (Keeling) Islands (the)", Alpha2Code = "CC", Alpha3Code = "CCK"},
        new Country {Id = Guid.Parse("ec485b6a-4a69-40d6-a34e-559c0b25f96c"), Name = "Colombia", Alpha2Code = "CO", Alpha3Code = "COL"},
        new Country {Id = Guid.Parse("85cc67ab-22ec-4ef5-84b8-22490145eda5"), Name = "Comoros (the)", Alpha2Code = "KM", Alpha3Code = "COM"},
        new Country {Id = Guid.Parse("bba74714-4497-4806-bad9-e74075217ca2"), Name = "Congo (the Democratic Republic of the)", Alpha2Code = "CD", Alpha3Code = "COD"},
        new Country {Id = Guid.Parse("c70a2df5-fd2a-4a99-9b98-7254ada8460c"), Name = "Congo (the)", Alpha2Code = "CG", Alpha3Code = "COG"},
        new Country {Id = Guid.Parse("1d8a0fe1-7f8f-4fa9-a336-8902b8b27a9e"), Name = "Cook Islands (the)", Alpha2Code = "CK", Alpha3Code = "COK"},
        new Country {Id = Guid.Parse("4f5a6bb2-55f4-4cbc-9149-61d49b14ac9d"), Name = "Costa Rica", Alpha2Code = "CR", Alpha3Code = "CRI"},
        new Country {Id = Guid.Parse("f48fcde0-a6bb-4668-b8bf-92d028ca9ab3"), Name = "Croatia", Alpha2Code = "HR", Alpha3Code = "HRV"},
        new Country {Id = Guid.Parse("ed97b7e9-06b1-40ed-bae4-c14e301d5042"), Name = "Cuba", Alpha2Code = "CU", Alpha3Code = "CUB"},
        new Country {Id = Guid.Parse("9f10a9d9-3823-466c-beb6-dd7543100b80"), Name = "Curaçao", Alpha2Code = "CW", Alpha3Code = "CUW"},
        new Country {Id = Guid.Parse("fb561aec-6c55-4d51-9537-05facbd91dda"), Name = "Cyprus", Alpha2Code = "CY", Alpha3Code = "CYP"},
        new Country {Id = Guid.Parse("f293b8ea-529e-4c90-8044-7f37717e8980"), Name = "Czechia", Alpha2Code = "CZ", Alpha3Code = "CZE"},
        new Country {Id = Guid.Parse("317160b1-4cb7-45b8-8e54-e98c2373466e"), Name = "Côte d'Ivoire", Alpha2Code = "CI", Alpha3Code = "CIV"},
        new Country {Id = Guid.Parse("d69602bd-76f3-4785-a498-3874cbaa970f"), Name = "Denmark", Alpha2Code = "DK", Alpha3Code = "DNK"},
        new Country {Id = Guid.Parse("54d14be5-6a0b-4817-928d-3b63c2fcffa6"), Name = "Djibouti", Alpha2Code = "DJ", Alpha3Code = "DJI"},
        new Country {Id = Guid.Parse("cb9ec68e-1006-4525-8612-44329c816757"), Name = "Dominica", Alpha2Code = "DM", Alpha3Code = "DMA"},
        new Country {Id = Guid.Parse("60ab754a-4df0-4254-a9bc-3714a25f9764"), Name = "Dominican Republic (the)", Alpha2Code = "DO", Alpha3Code = "DOM"},
        new Country {Id = Guid.Parse("e2b629b1-bbc6-4d34-8b3c-35f7524cdd54"), Name = "Ecuador", Alpha2Code = "EC", Alpha3Code = "ECU"},
        new Country {Id = Guid.Parse("94918806-4e2c-41eb-b3db-19d0c43c4280"), Name = "Egypt", Alpha2Code = "EG", Alpha3Code = "EGY"},
        new Country {Id = Guid.Parse("ef8601c1-4735-4350-a359-5b1ebe597e0d"), Name = "El Salvador", Alpha2Code = "SV", Alpha3Code = "SLV"},
        new Country {Id = Guid.Parse("9a8ad1d0-4c5b-489f-9ef3-0774bc698943"), Name = "Equatorial Guinea", Alpha2Code = "GQ", Alpha3Code = "GNQ"},
        new Country {Id = Guid.Parse("a18ae9ac-ed68-4b3e-85a5-037a0dac5cf6"), Name = "Eritrea", Alpha2Code = "ER", Alpha3Code = "ERI"},
        new Country {Id = Guid.Parse("27265d25-3b49-4ee7-9fe7-3ba41f094e16"), Name = "Estonia", Alpha2Code = "EE", Alpha3Code = "EST"},
        new Country {Id = Guid.Parse("2d0b5d27-c0cc-4e37-bcc8-365467f8022c"), Name = "Eswatini", Alpha2Code = "SZ", Alpha3Code = "SWZ"},
        new Country {Id = Guid.Parse("2bd96788-8ae4-494e-8637-ba347f2bbbca"), Name = "Ethiopia", Alpha2Code = "ET", Alpha3Code = "ETH"},
        new Country {Id = Guid.Parse("6470d150-c33c-49e2-b0e9-4dbb9574aedb"), Name = "Falkland Islands (the) [Malvinas]", Alpha2Code = "FK", Alpha3Code = "FLK"},
        new Country {Id = Guid.Parse("e55c2bf2-266d-4af5-953a-d5cdb52e9073"), Name = "Faroe Islands (the)", Alpha2Code = "FO", Alpha3Code = "FRO"},
        new Country {Id = Guid.Parse("3713bbb1-1b45-43d0-851e-cce44e894f05"), Name = "Fiji", Alpha2Code = "FJ", Alpha3Code = "FJI"},
        new Country {Id = Guid.Parse("12df6980-409d-4129-b6f3-d71d1ce8087a"), Name = "Finland", Alpha2Code = "FI", Alpha3Code = "FIN"},
        new Country {Id = Guid.Parse("d761bb47-8477-4f67-a992-2535c789f30f"), Name = "France", Alpha2Code = "FR", Alpha3Code = "FRA"},
        new Country {Id = Guid.Parse("6faffedf-4a24-4a05-a7e3-36f10d3a6c1c"), Name = "French Guiana", Alpha2Code = "GF", Alpha3Code = "GUF"},
        new Country {Id = Guid.Parse("49b07547-6593-4a59-a296-9ae4322adca3"), Name = "French Polynesia", Alpha2Code = "PF", Alpha3Code = "PYF"},
        new Country {Id = Guid.Parse("90b599dc-4581-406b-8b8e-589b72e6bb9f"), Name = "French Southern Territories (the)", Alpha2Code = "TF", Alpha3Code = "ATF"},
        new Country {Id = Guid.Parse("c4a41ca2-1f47-4ec3-b250-0942e31603cc"), Name = "Gabon", Alpha2Code = "GA", Alpha3Code = "GAB"},
        new Country {Id = Guid.Parse("994d9d8e-ded2-4355-bb0f-f3a66a3a4779"), Name = "Gambia (the)", Alpha2Code = "GM", Alpha3Code = "GMB"},
        new Country {Id = Guid.Parse("d10ff280-01b1-4ad0-b1fa-992b9dad9b53"), Name = "Georgia", Alpha2Code = "GE", Alpha3Code = "GEO"},
        new Country {Id = Guid.Parse("80f6fadb-c0e0-41eb-bfdf-c253c3c2945b"), Name = "Germany", Alpha2Code = "DE", Alpha3Code = "DEU"},
        new Country {Id = Guid.Parse("c43bf101-d151-406f-8669-cc6e2ad0dba2"), Name = "Ghana", Alpha2Code = "GH", Alpha3Code = "GHA"},
        new Country {Id = Guid.Parse("2d235488-6cff-4a90-a2bd-2d259933fe1b"), Name = "Gibraltar", Alpha2Code = "GI", Alpha3Code = "GIB"},
        new Country {Id = Guid.Parse("74eea3e2-7f1b-4c0c-b63c-7bc1c4fa8670"), Name = "Greece", Alpha2Code = "GR", Alpha3Code = "GRC"},
        new Country {Id = Guid.Parse("b89d7b1a-27c3-4859-aa7e-23293f4b9ca0"), Name = "Greenland", Alpha2Code = "GL", Alpha3Code = "GRL"},
        new Country {Id = Guid.Parse("bff539e0-82c8-4a20-8c0b-567561a2646b"), Name = "Grenada", Alpha2Code = "GD", Alpha3Code = "GRD"},
        new Country {Id = Guid.Parse("f1526d84-2265-407a-97ba-15e4fb61ef3f"), Name = "Guadeloupe", Alpha2Code = "GP", Alpha3Code = "GLP"},
        new Country {Id = Guid.Parse("c5d646f9-009b-4d1b-b5fc-eb30a03e4b81"), Name = "Guam", Alpha2Code = "GU", Alpha3Code = "GUM"},
        new Country {Id = Guid.Parse("543b391b-a9fc-4e71-96a8-7cf94c4f4d5b"), Name = "Guatemala", Alpha2Code = "GT", Alpha3Code = "GTM"},
        new Country {Id = Guid.Parse("f3ccee21-77d5-4bc6-a05a-2383710f5477"), Name = "Guernsey", Alpha2Code = "GG", Alpha3Code = "GGY"},
        new Country {Id = Guid.Parse("9b94c3a2-2a0a-4ad0-b390-f414ac45e059"), Name = "Guinea", Alpha2Code = "GN", Alpha3Code = "GIN"},
        new Country {Id = Guid.Parse("d1dbe9ef-e4e0-44fd-a8f6-2a9b0b130a27"), Name = "Guinea-Bissau", Alpha2Code = "GW", Alpha3Code = "GNB"},
        new Country {Id = Guid.Parse("7b8484e1-0a41-466c-9903-1328e8669d1b"), Name = "Guyana", Alpha2Code = "GY", Alpha3Code = "GUY"},
        new Country {Id = Guid.Parse("883ac320-106d-4749-b225-87714d705763"), Name = "Haiti", Alpha2Code = "HT", Alpha3Code = "HTI"},
        new Country {Id = Guid.Parse("35a040fc-1049-4938-ae12-8089ff3cfe85"), Name = "Heard Island and McDonald Islands", Alpha2Code = "HM", Alpha3Code = "HMD"},
        new Country {Id = Guid.Parse("7a5a29fb-3171-4778-bb68-ede54e169111"), Name = "Holy See (the)", Alpha2Code = "VA", Alpha3Code = "VAT"},
        new Country {Id = Guid.Parse("fddff3c1-3bb3-4ee6-b9cc-628c3d53defb"), Name = "Honduras", Alpha2Code = "HN", Alpha3Code = "HND"},
        new Country {Id = Guid.Parse("719281fe-c79f-43a2-b31b-23c928faa8e6"), Name = "Hong Kong", Alpha2Code = "HK", Alpha3Code = "HKG"},
        new Country {Id = Guid.Parse("d8831f86-bd62-49c3-8805-b5c881acefa8"), Name = "Hungary", Alpha2Code = "HU", Alpha3Code = "HUN"},
        new Country {Id = Guid.Parse("15f4c5e9-24bc-494c-92d5-cb3e976fe1f5"), Name = "Iceland", Alpha2Code = "IS", Alpha3Code = "ISL"},
        new Country {Id = Guid.Parse("7f0ecd37-0e96-4271-b975-ffc72ef86cc4"), Name = "India", Alpha2Code = "IN", Alpha3Code = "IND"},
        new Country {Id = Guid.Parse("b9b8535e-1e6b-4e39-a6ac-1b7e57bfd33c"), Name = "Indonesia", Alpha2Code = "ID", Alpha3Code = "IDN"},
        new Country {Id = Guid.Parse("7bf2c229-1165-4587-bcf8-cfd0b4952879"), Name = "Iran (Islamic Republic of)", Alpha2Code = "IR", Alpha3Code = "IRN"},
        new Country {Id = Guid.Parse("5e6def8e-12af-415e-9cb9-276f97914bf0"), Name = "Iraq", Alpha2Code = "IQ", Alpha3Code = "IRQ"},
        new Country {Id = Guid.Parse("a39279d9-e93f-4a22-abb7-6cc05e5e8874"), Name = "Ireland", Alpha2Code = "IE", Alpha3Code = "IRL"},
        new Country {Id = Guid.Parse("908765e7-efe7-4c56-81ac-bb2c86bcc093"), Name = "Isle of Man", Alpha2Code = "IM", Alpha3Code = "IMN"},
        new Country {Id = Guid.Parse("bdb15a05-6afc-413d-867c-47a87c2e0074"), Name = "Israel", Alpha2Code = "IL", Alpha3Code = "ISR"},
        new Country {Id = Guid.Parse("d0958301-d073-4252-a183-0a2b34afcc94"), Name = "Italy", Alpha2Code = "IT", Alpha3Code = "ITA"},
        new Country {Id = Guid.Parse("a5f125cb-e6a2-409b-af94-54c9284204f9"), Name = "Jamaica", Alpha2Code = "JM", Alpha3Code = "JAM"},
        new Country {Id = Guid.Parse("d4993250-cdb6-40da-9474-48a97971307e"), Name = "Japan", Alpha2Code = "JP", Alpha3Code = "JPN"},
        new Country {Id = Guid.Parse("2979bb6d-2002-4abd-8785-e34dce26cfaf"), Name = "Jersey", Alpha2Code = "JE", Alpha3Code = "JEY"},
        new Country {Id = Guid.Parse("1192eb08-3026-480c-b21b-f62f6ec59f50"), Name = "Jordan", Alpha2Code = "JO", Alpha3Code = "JOR"},
        new Country {Id = Guid.Parse("52a225d1-fac4-408a-9b82-e3c411f6d0d5"), Name = "Kazakhstan", Alpha2Code = "KZ", Alpha3Code = "KAZ"},
        new Country {Id = Guid.Parse("316b9969-ce67-4aa3-8476-7adc52407150"), Name = "Kenya", Alpha2Code = "KE", Alpha3Code = "KEN"},
        new Country {Id = Guid.Parse("6a223637-18e4-4822-9c62-ba483a333d15"), Name = "Kiribati", Alpha2Code = "KI", Alpha3Code = "KIR"},
        new Country {Id = Guid.Parse("cdea498d-1b3f-4975-af1b-2e0ec2f3cafd"), Name = "Korea (the Democratic People's Republic of)", Alpha2Code = "KP", Alpha3Code = "PRK"},
        new Country {Id = Guid.Parse("aca267be-8365-4b73-a806-3cb547d5a211"), Name = "Korea (the Republic of)", Alpha2Code = "KR", Alpha3Code = "KOR"},
        new Country {Id = Guid.Parse("1a270b09-036d-4872-992e-88c357433e50"), Name = "Kuwait", Alpha2Code = "KW", Alpha3Code = "KWT"},
        new Country {Id = Guid.Parse("7ee68a9a-ad8d-4392-8146-7f393f85b7ed"), Name = "Kyrgyzstan", Alpha2Code = "KG", Alpha3Code = "KGZ"},
        new Country {Id = Guid.Parse("8596e8dc-49e8-4bae-b459-a73c9caa3767"), Name = "Lao People's Democratic Republic (the)", Alpha2Code = "LA", Alpha3Code = "LAO"},
        new Country {Id = Guid.Parse("569f984c-be17-4c77-83ea-a0d5a43d1d5e"), Name = "Latvia", Alpha2Code = "LV", Alpha3Code = "LVA"},
        new Country {Id = Guid.Parse("e8235f90-9d31-4c9d-b7cc-8e7397057380"), Name = "Lebanon", Alpha2Code = "LB", Alpha3Code = "LBN"},
        new Country {Id = Guid.Parse("91a80287-a0f5-4de1-a10f-bf3a058f2b1c"), Name = "Lesotho", Alpha2Code = "LS", Alpha3Code = "LSO"},
        new Country {Id = Guid.Parse("cc5ec694-7ce2-4883-8dab-05a6f148243b"), Name = "Liberia", Alpha2Code = "LR", Alpha3Code = "LBR"},
        new Country {Id = Guid.Parse("b15897b7-cb1c-4da2-b2f8-d3d7af5b3ad0"), Name = "Libya", Alpha2Code = "LY", Alpha3Code = "LBY"},
        new Country {Id = Guid.Parse("9fbb50fe-ff23-4abc-b524-2ed8d8b64a9b"), Name = "Liechtenstein", Alpha2Code = "LI", Alpha3Code = "LIE"},
        new Country {Id = Guid.Parse("8da1077a-231d-49d8-ae2d-8c0184eafea0"), Name = "Lithuania", Alpha2Code = "LT", Alpha3Code = "LTU"},
        new Country {Id = Guid.Parse("4e24c555-a619-48f1-afcd-7f8e536eacc1"), Name = "Luxembourg", Alpha2Code = "LU", Alpha3Code = "LUX"},
        new Country {Id = Guid.Parse("f1357ee3-156c-41fe-9715-2c6929590fc2"), Name = "Macao", Alpha2Code = "MO", Alpha3Code = "MAC"},
        new Country {Id = Guid.Parse("6e4c0de6-a8ac-481b-8e24-023d9e024c00"), Name = "Madagascar", Alpha2Code = "MG", Alpha3Code = "MDG"},
        new Country {Id = Guid.Parse("6453c40a-f697-4223-9797-821ad45c4647"), Name = "Malawi", Alpha2Code = "MW", Alpha3Code = "MWI"},
        new Country {Id = Guid.Parse("81b25266-fa29-4280-a30e-59f6d42f3f15"), Name = "Malaysia", Alpha2Code = "MY", Alpha3Code = "MYS"},
        new Country {Id = Guid.Parse("7a56db1d-0e7e-4932-9747-3f19a79f6534"), Name = "Maldives", Alpha2Code = "MV", Alpha3Code = "MDV"},
        new Country {Id = Guid.Parse("6618a417-5c7d-4e24-a77d-ccfe89ec38bf"), Name = "Mali", Alpha2Code = "ML", Alpha3Code = "MLI"},
        new Country {Id = Guid.Parse("6aa14e79-4d9a-4841-b412-367c778548b4"), Name = "Malta", Alpha2Code = "MT", Alpha3Code = "MLT"},
        new Country {Id = Guid.Parse("20e1b116-df2d-4121-be5d-0c9814248ad2"), Name = "Marshall Islands (the)", Alpha2Code = "MH", Alpha3Code = "MHL"},
        new Country {Id = Guid.Parse("aba79b10-e3d8-41b4-95ed-cb173b0d73e7"), Name = "Martinique", Alpha2Code = "MQ", Alpha3Code = "MTQ"},
        new Country {Id = Guid.Parse("147b82eb-c081-41dd-b87b-635d5c5054f3"), Name = "Mauritania", Alpha2Code = "MR", Alpha3Code = "MRT"},
        new Country {Id = Guid.Parse("6c8ab378-ddfe-4071-9f02-2cab31174dfd"), Name = "Mauritius", Alpha2Code = "MU", Alpha3Code = "MUS"},
        new Country {Id = Guid.Parse("7d810385-a431-4f6e-b1ed-abec8ecef91a"), Name = "Mayotte", Alpha2Code = "YT", Alpha3Code = "MYT"},
        new Country {Id = Guid.Parse("e8929799-dff3-443c-a417-e1871ca29c90"), Name = "Mexico", Alpha2Code = "MX", Alpha3Code = "MEX"},
        new Country {Id = Guid.Parse("983d6ec3-d9f5-4e19-a58b-efdd4d3609a7"), Name = "Micronesia (Federated States of)", Alpha2Code = "FM", Alpha3Code = "FSM"},
        new Country {Id = Guid.Parse("5aeb9baf-0198-4f2b-8183-a1ca51f66d96"), Name = "Moldova (the Republic of)", Alpha2Code = "MD", Alpha3Code = "MDA"},
        new Country {Id = Guid.Parse("3b63854e-07d3-4883-b997-d8a7496b0d45"), Name = "Monaco", Alpha2Code = "MC", Alpha3Code = "MCO"},
        new Country {Id = Guid.Parse("a49834f0-4e9e-4402-bac5-e22d04dc3767"), Name = "Mongolia", Alpha2Code = "MN", Alpha3Code = "MNG"},
        new Country {Id = Guid.Parse("f66585ce-7b53-4b9b-8122-150f8a1bdb75"), Name = "Montenegro", Alpha2Code = "ME", Alpha3Code = "MNE"},
        new Country {Id = Guid.Parse("f6ee2169-65a5-4c0c-8ebc-eef7adf29481"), Name = "Montserrat", Alpha2Code = "MS", Alpha3Code = "MSR"},
        new Country {Id = Guid.Parse("9596570c-3ed0-4a92-9ff5-8db594c072b0"), Name = "Morocco", Alpha2Code = "MA", Alpha3Code = "MAR"},
        new Country {Id = Guid.Parse("08b97c4b-ba5c-496c-a77f-5394f483ab9e"), Name = "Mozambique", Alpha2Code = "MZ", Alpha3Code = "MOZ"},
        new Country {Id = Guid.Parse("60920235-7b02-43b0-a0a9-d7a509c6cd33"), Name = "Myanmar", Alpha2Code = "MM", Alpha3Code = "MMR"},
        new Country {Id = Guid.Parse("1ce59e25-dd93-46b3-8425-3392cb35151f"), Name = "Namibia", Alpha2Code = "NA", Alpha3Code = "NAM"},
        new Country {Id = Guid.Parse("9832f4a3-ed3e-4aaf-a20c-457f4a26bd62"), Name = "Nauru", Alpha2Code = "NR", Alpha3Code = "NRU"},
        new Country {Id = Guid.Parse("66ee8fd1-1ee5-4354-af86-30edc54fda19"), Name = "Nepal", Alpha2Code = "NP", Alpha3Code = "NPL"},
        new Country {Id = Guid.Parse("c1eb37b8-e284-4c73-a6af-3b52dab81c39"), Name = "Netherlands (the)", Alpha2Code = "NL", Alpha3Code = "NLD"},
        new Country {Id = Guid.Parse("dc04de6a-e250-44f5-9299-f9f23eccd3ce"), Name = "New Caledonia", Alpha2Code = "NC", Alpha3Code = "NCL"},
        new Country {Id = Guid.Parse("59ed5d69-0838-4454-8186-629fc1621b93"), Name = "New Zealand", Alpha2Code = "NZ", Alpha3Code = "NZL"},
        new Country {Id = Guid.Parse("8eaa9550-1236-401a-ae24-810c8851ea5e"), Name = "Nicaragua", Alpha2Code = "NI", Alpha3Code = "NIC"},
        new Country {Id = Guid.Parse("0889760b-4a1d-4163-8184-9062d56e4d8c"), Name = "Niger (the)", Alpha2Code = "NE", Alpha3Code = "NER"},
        new Country {Id = Guid.Parse("a7efd015-4c3e-493c-bc62-10a7bf762825"), Name = "Nigeria", Alpha2Code = "NG", Alpha3Code = "NGA"},
        new Country {Id = Guid.Parse("ee3e97c3-e3b9-49e8-9abb-3092669fd314"), Name = "Niue", Alpha2Code = "NU", Alpha3Code = "NIU"},
        new Country {Id = Guid.Parse("9514391e-4097-4a2e-9bab-9c18d083c26d"), Name = "Norfolk Island", Alpha2Code = "NF", Alpha3Code = "NFK"},
        new Country {Id = Guid.Parse("2e8acc4a-bea1-4864-b197-a63233e8c397"), Name = "Northern Mariana Islands (the)", Alpha2Code = "MP", Alpha3Code = "MNP"},
        new Country {Id = Guid.Parse("331aafed-3986-4275-b747-e2a79b1fe134"), Name = "Norway", Alpha2Code = "NO", Alpha3Code = "NOR"},
        new Country {Id = Guid.Parse("fc6da1c1-3236-455d-8f4c-9dbc9f5214c7"), Name = "Oman", Alpha2Code = "OM", Alpha3Code = "OMN"},
        new Country {Id = Guid.Parse("b16a98b9-9b6f-4db0-94b1-5cfc0718f2bd"), Name = "Pakistan", Alpha2Code = "PK", Alpha3Code = "PAK"},
        new Country {Id = Guid.Parse("afbd6ead-3e62-4507-991e-2053f28f9278"), Name = "Palau", Alpha2Code = "PW", Alpha3Code = "PLW"},
        new Country {Id = Guid.Parse("9d6cb9ec-760b-417e-9b72-8addbec15624"), Name = "Palestine, State of", Alpha2Code = "PS", Alpha3Code = "PSE"},
        new Country {Id = Guid.Parse("2b9dae73-d40c-4f48-94e1-c00f3b963c1d"), Name = "Panama", Alpha2Code = "PA", Alpha3Code = "PAN"},
        new Country {Id = Guid.Parse("d58e62c1-78af-4307-9aea-be667612c4c4"), Name = "Papua New Guinea", Alpha2Code = "PG", Alpha3Code = "PNG"},
        new Country {Id = Guid.Parse("80a1cb0a-d12c-4418-9422-49b497c64a45"), Name = "Paraguay", Alpha2Code = "PY", Alpha3Code = "PRY"},
        new Country {Id = Guid.Parse("8d82e03f-3a66-46e1-abf4-1c03e9554236"), Name = "Peru", Alpha2Code = "PE", Alpha3Code = "PER"},
        new Country {Id = Guid.Parse("edad8646-82cc-4137-9519-18034b1f6dea"), Name = "Philippines (the)", Alpha2Code = "PH", Alpha3Code = "PHL"},
        new Country {Id = Guid.Parse("e3dd51f1-acbf-4fe9-bd53-4aa8b59d425d"), Name = "Pitcairn", Alpha2Code = "PN", Alpha3Code = "PCN"},
        new Country {Id = Guid.Parse("549fba38-4427-4c65-9071-800e0afd84dc"), Name = "Poland", Alpha2Code = "PL", Alpha3Code = "POL"},
        new Country {Id = Guid.Parse("f6422962-2b04-4470-a3c7-7bb55a7a2d45"), Name = "Portugal", Alpha2Code = "PT", Alpha3Code = "PRT"},
        new Country {Id = Guid.Parse("ed14ef85-515a-4f7c-a001-76aec44ebe59"), Name = "Puerto Rico", Alpha2Code = "PR", Alpha3Code = "PRI"},
        new Country {Id = Guid.Parse("b9939a38-eab5-4d8f-906a-e2b2c5f7da55"), Name = "Qatar", Alpha2Code = "QA", Alpha3Code = "QAT"},
        new Country {Id = Guid.Parse("ed1149bc-0dfb-4746-b800-655809739578"), Name = "Republic of North Macedonia", Alpha2Code = "MK", Alpha3Code = "MKD"},
        new Country {Id = Guid.Parse("f1a94128-3d8d-473c-baa2-1e9c0b971cdb"), Name = "Romania", Alpha2Code = "RO", Alpha3Code = "ROU"},
        new Country {Id = Guid.Parse("a731ed1b-eed0-4b67-b1fd-f9e7625d0f7e"), Name = "Russian Federation (the)", Alpha2Code = "RU", Alpha3Code = "RUS"},
        new Country {Id = Guid.Parse("23c66a5d-a9f5-4a50-bde4-b7611405a1b0"), Name = "Rwanda", Alpha2Code = "RW", Alpha3Code = "RWA"},
        new Country {Id = Guid.Parse("76e26eff-cf3f-4d6e-aae6-cf3f6a9f5ca7"), Name = "Réunion", Alpha2Code = "RE", Alpha3Code = "REU"},
        new Country {Id = Guid.Parse("488cc064-6271-425c-8562-c769da4c68e5"), Name = "Saint Barthélemy", Alpha2Code = "BL", Alpha3Code = "BLM"},
        new Country {Id = Guid.Parse("150d6279-6736-4a3b-aed7-86e1b23ca6b1"), Name = "Saint Helena, Ascension and Tristan da Cunha", Alpha2Code = "SH", Alpha3Code = "SHN"},
        new Country {Id = Guid.Parse("4e028214-1302-46c5-bce5-6ac6d7d8f550"), Name = "Saint Kitts and Nevis", Alpha2Code = "KN", Alpha3Code = "KNA"},
        new Country {Id = Guid.Parse("92a7681e-ccc7-4930-9e47-edb3d9f4e9cd"), Name = "Saint Lucia", Alpha2Code = "LC", Alpha3Code = "LCA"},
        new Country {Id = Guid.Parse("2f861285-ae1c-48d8-8edb-e1952d86ca80"), Name = "Saint Martin (French part)", Alpha2Code = "MF", Alpha3Code = "MAF"},
        new Country {Id = Guid.Parse("b937694b-9236-44d6-bec4-ee8883314aa3"), Name = "Saint Pierre and Miquelon", Alpha2Code = "PM", Alpha3Code = "SPM"},
        new Country {Id = Guid.Parse("2780f1a7-9056-4a52-9522-71b40442d886"), Name = "Saint Vincent and the Grenadines", Alpha2Code = "VC", Alpha3Code = "VCT"},
        new Country {Id = Guid.Parse("44ae2342-0fb8-4510-9963-cced7b8def4a"), Name = "Samoa", Alpha2Code = "WS", Alpha3Code = "WSM"},
        new Country {Id = Guid.Parse("36f57ced-cd3d-4763-bc60-932d6946b13c"), Name = "San Marino", Alpha2Code = "SM", Alpha3Code = "SMR"},
        new Country {Id = Guid.Parse("7462207c-12ae-42dc-bc3e-8e0bab3cf727"), Name = "Sao Tome and Principe", Alpha2Code = "ST", Alpha3Code = "STP"},
        new Country {Id = Guid.Parse("2fc41f33-eb67-4470-81e3-116ac2769304"), Name = "Saudi Arabia", Alpha2Code = "SA", Alpha3Code = "SAU"},
        new Country {Id = Guid.Parse("43164f4e-e476-4a39-a5ee-e53bf23c6fea"), Name = "Senegal", Alpha2Code = "SN", Alpha3Code = "SEN"},
        new Country {Id = Guid.Parse("60ef64ed-5cb7-4b8e-98ad-ea9fb27486a4"), Name = "Serbia", Alpha2Code = "RS", Alpha3Code = "SRB"},
        new Country {Id = Guid.Parse("50444744-61c8-4a96-8747-fe03e962eb9d"), Name = "Seychelles", Alpha2Code = "SC", Alpha3Code = "SYC"},
        new Country {Id = Guid.Parse("e1afe3c2-28ca-4078-bfe4-97064bb50719"), Name = "Sierra Leone", Alpha2Code = "SL", Alpha3Code = "SLE"},
        new Country {Id = Guid.Parse("494e855f-e3da-48f1-b40c-e45fc8e728dc"), Name = "Singapore", Alpha2Code = "SG", Alpha3Code = "SGP"},
        new Country {Id = Guid.Parse("f9fddddc-eead-4de8-b4bf-cf210c77f61c"), Name = "Sint Maarten (Dutch part)", Alpha2Code = "SX", Alpha3Code = "SXM"},
        new Country {Id = Guid.Parse("9a1a90f6-40fb-4a25-ab5a-2b044e587605"), Name = "Slovakia", Alpha2Code = "SK", Alpha3Code = "SVK"},
        new Country {Id = Guid.Parse("bcd6b8f0-38b7-4310-a532-920eb5543097"), Name = "Slovenia", Alpha2Code = "SI", Alpha3Code = "SVN"},
        new Country {Id = Guid.Parse("f71dd500-b6ae-44f8-805c-ab00d359753b"), Name = "Solomon Islands", Alpha2Code = "SB", Alpha3Code = "SLB"},
        new Country {Id = Guid.Parse("35fcf832-8028-437a-9ac1-e080cddf275d"), Name = "Somalia", Alpha2Code = "SO", Alpha3Code = "SOM"},
        new Country {Id = Guid.Parse("6f096c2e-10d6-465f-8bb6-f3ca476faa63"), Name = "South Africa", Alpha2Code = "ZA", Alpha3Code = "ZAF"},
        new Country {Id = Guid.Parse("a8e34c5a-90bc-4df4-a6b7-de7f4d211125"), Name = "South Georgia and the South Sandwich Islands", Alpha2Code = "GS", Alpha3Code = "SGS"},
        new Country {Id = Guid.Parse("9657dc08-d803-449f-8499-ab2a93267f0c"), Name = "South Sudan", Alpha2Code = "SS", Alpha3Code = "SSD"},
        new Country {Id = Guid.Parse("02e931e6-055a-4e65-aa24-e836881d3f60"), Name = "Spain", Alpha2Code = "ES", Alpha3Code = "ESP"},
        new Country {Id = Guid.Parse("1a1ed865-82ce-4090-8b0b-33a28108f2dc"), Name = "Sri Lanka", Alpha2Code = "LK", Alpha3Code = "LKA"},
        new Country {Id = Guid.Parse("01eb164b-3f0f-4e77-aa7e-a42749f63c75"), Name = "Sudan (the)", Alpha2Code = "SD", Alpha3Code = "SDN"},
        new Country {Id = Guid.Parse("b7428613-0879-4421-b15b-a438d5c50054"), Name = "Suriname", Alpha2Code = "SR", Alpha3Code = "SUR"},
        new Country {Id = Guid.Parse("98d9e46d-66c1-4f44-94f6-fb2e90b8b300"), Name = "Svalbard and Jan Mayen", Alpha2Code = "SJ", Alpha3Code = "SJM"},
        new Country {Id = Guid.Parse("e0a1bbb7-6460-42fb-9492-9344f548c773"), Name = "Sweden", Alpha2Code = "SE", Alpha3Code = "SWE"},
        new Country {Id = Guid.Parse("9bc1f1a9-7696-42e4-89aa-c93800704582"), Name = "Switzerland", Alpha2Code = "CH", Alpha3Code = "CHE"},
        new Country {Id = Guid.Parse("32617962-b412-4366-b0ea-c55f0dfc9af6"), Name = "Syrian Arab Republic", Alpha2Code = "SY", Alpha3Code = "SYR"},
        new Country {Id = Guid.Parse("4b88870d-f147-4d55-ba6b-cf470738f945"), Name = "Taiwan (Province of China)", Alpha2Code = "TW", Alpha3Code = "TWN"},
        new Country {Id = Guid.Parse("aa6c7744-f7ce-442b-aab3-cee4faa9f50b"), Name = "Tajikistan", Alpha2Code = "TJ", Alpha3Code = "TJK"},
        new Country {Id = Guid.Parse("3e7dc4b7-a517-454c-8657-0e4a2df9e67c"), Name = "Tanzania, United Republic of", Alpha2Code = "TZ", Alpha3Code = "TZA"},
        new Country {Id = Guid.Parse("a7ce5d31-a001-42ea-a5c9-9611d677df65"), Name = "Thailand", Alpha2Code = "TH", Alpha3Code = "THA"},
        new Country {Id = Guid.Parse("cad06768-0005-464d-885e-d287cdb34e5d"), Name = "Timor-Leste", Alpha2Code = "TL", Alpha3Code = "TLS"},
        new Country {Id = Guid.Parse("fc1d5164-4161-4248-a795-eee401895cac"), Name = "Togo", Alpha2Code = "TG", Alpha3Code = "TGO"},
        new Country {Id = Guid.Parse("0311f6ff-5ace-4c2d-a769-73dddfbc08ed"), Name = "Tokelau", Alpha2Code = "TK", Alpha3Code = "TKL"},
        new Country {Id = Guid.Parse("ad8f3577-f710-48be-a8ce-283082cdfd5c"), Name = "Tonga", Alpha2Code = "TO", Alpha3Code = "TON"},
        new Country {Id = Guid.Parse("4ddde8d8-f7c8-48da-96a9-7e2a10cf9ef8"), Name = "Trinidad and Tobago", Alpha2Code = "TT", Alpha3Code = "TTO"},
        new Country {Id = Guid.Parse("1da6a677-dcf9-40fe-afd6-c39b35e9d529"), Name = "Tunisia", Alpha2Code = "TN", Alpha3Code = "TUN"},
        new Country {Id = Guid.Parse("dea3d7d2-2c87-433f-8c82-3f3fc094325e"), Name = "Turkey", Alpha2Code = "TR", Alpha3Code = "TUR"},
        new Country {Id = Guid.Parse("f13ed7e7-1d76-467b-8e68-a5612cbaa169"), Name = "Turkmenistan", Alpha2Code = "TM", Alpha3Code = "TKM"},
        new Country {Id = Guid.Parse("10a74150-281e-41a3-a719-009854ccb354"), Name = "Turks and Caicos Islands (the)", Alpha2Code = "TC", Alpha3Code = "TCA"},
        new Country {Id = Guid.Parse("333fdc8c-9bc7-4769-91c7-4f02726637c4"), Name = "Tuvalu", Alpha2Code = "TV", Alpha3Code = "TUV"},
        new Country {Id = Guid.Parse("7514bcc3-7881-4fb1-bc8f-c346d44fb58f"), Name = "Uganda", Alpha2Code = "UG", Alpha3Code = "UGA"},
        new Country {Id = Guid.Parse("0663734e-c1d4-4a58-9c64-bb8463c82fbf"), Name = "Ukraine", Alpha2Code = "UA", Alpha3Code = "UKR"},
        new Country {Id = Guid.Parse("c1badf50-9f25-4e84-a3e0-69e9fa545984"), Name = "United Arab Emirates (the)", Alpha2Code = "AE", Alpha3Code = "ARE"},
        new Country {Id = Guid.Parse("b3188d20-7572-4879-9f12-44ea7c06745c"), Name = "United Kingdom of Great Britain and Northern Ireland (the)", Alpha2Code = "GB", Alpha3Code = "GBR"},
        new Country {Id = Guid.Parse("e69d03f7-a99d-4c6c-b392-ce217b1dc868"), Name = "United States Minor Outlying Islands (the)", Alpha2Code = "UM", Alpha3Code = "UMI"},
        new Country {Id = Guid.Parse("014f2bc5-6ec6-483d-abcf-3ad3c10e0c71"), Name = "United States of America (the)", Alpha2Code = "US", Alpha3Code = "USA"},
        new Country {Id = Guid.Parse("86b175ea-352f-4437-87dd-7a64ab0a9a57"), Name = "Uruguay", Alpha2Code = "UY", Alpha3Code = "URY"},
        new Country {Id = Guid.Parse("e00e2f21-a661-4e32-abf8-9c593cc62a4c"), Name = "Uzbekistan", Alpha2Code = "UZ", Alpha3Code = "UZB"},
        new Country {Id = Guid.Parse("fea13ee2-a1fe-473d-97db-117027425402"), Name = "Vanuatu", Alpha2Code = "VU", Alpha3Code = "VUT"},
        new Country {Id = Guid.Parse("4f8d0d0e-c5b0-4990-ac31-d80d8099e84b"), Name = "Venezuela (Bolivarian Republic of)", Alpha2Code = "VE", Alpha3Code = "VEN"},
        new Country {Id = Guid.Parse("4fab2d4b-44f1-4d5c-9072-5aed6b58f5d1"), Name = "Viet Nam", Alpha2Code = "VN", Alpha3Code = "VNM"},
        new Country {Id = Guid.Parse("36e874da-595b-4f43-b6ed-9baf25abe8d9"), Name = "Virgin Islands (British)", Alpha2Code = "VG", Alpha3Code = "VGB"},
        new Country {Id = Guid.Parse("3a02147b-7946-4b6b-9456-462ca47f11e6"), Name = "Virgin Islands (U.S.)", Alpha2Code = "VI", Alpha3Code = "VIR"},
        new Country {Id = Guid.Parse("4fb924e5-d1fb-40c7-9b48-a40441ecf3b2"), Name = "Wallis and Futuna", Alpha2Code = "WF", Alpha3Code = "WLF"},
        new Country {Id = Guid.Parse("009dfcfd-7e30-4bf8-a10b-bd7b0a476651"), Name = "Western Sahara", Alpha2Code = "EH", Alpha3Code = "ESH"},
        new Country {Id = Guid.Parse("c683f637-ddff-4238-9a1f-5ad10eeb36d9"), Name = "Yemen", Alpha2Code = "YE", Alpha3Code = "YEM"},
        new Country {Id = Guid.Parse("99abee71-db3e-4909-b4b6-c47e1b2ec49b"), Name = "Zambia", Alpha2Code = "ZM", Alpha3Code = "ZMB"},
        new Country {Id = Guid.Parse("50aa4ab0-3c14-4550-a87f-bdfca7d90638"), Name = "Zimbabwe", Alpha2Code = "ZW", Alpha3Code = "ZWE"},
        new Country {Id = Guid.Parse("bb38feee-4d81-4f56-a11b-673ca15a95a0"), Name = "Åland Islands", Alpha2Code = "AX", Alpha3Code = "ALA"}
    };

    private static Faker? _faker;

    public static void Seed(this ModelBuilder modelBuilder)
    {
        var tenantGuid = modelBuilder.SeedTenant();
        modelBuilder.SeedCountries();
        modelBuilder.SeedPersons(tenantGuid);
    }

    private static Guid SeedTenant(this ModelBuilder modelBuilder)
    {
        var guid = Guid.NewGuid();
        modelBuilder.Entity<Tenant>().HasData(new Tenant
        {
            TenantId = guid,
            Name = "DEMO"
        });
        return guid;
    }

    private static void SeedPersons(this ModelBuilder modelBuilder, Guid tenantGuid)
    {
        _faker = new Faker("fr");
        var members = new List<Member>();
        var payments = new List<Payment>();
        var subscriptions = new List<SubscriptionPaid>();

        for (var i = 0; i < 20; i++)
        {
            var member = CreateMember(tenantGuid);
            payments.AddRange(Enumerable.Range(0, 10).Select(_ => new Payment
            {
                Id = Guid.NewGuid(),
                Note = _faker.Lorem.Sentence(),
                PaymentType = _faker.Random.Enum<PaymentType>(),
                MemberId = member.Id,
                Amount = _faker.Random.Decimal(0, 1000),
                PaymentDate = DateTime.SpecifyKind(_faker.Date.Past(10), DateTimeKind.Utc),
                TenantId = tenantGuid
            }).ToList());

            subscriptions.AddRange(Enumerable.Range(2015, _faker.Random.Int(0, 7)).Select(s => new SubscriptionPaid
            {
                Year = s,
                January = true,
                February = true,
                March = true,
                April = true,
                May = true,
                June = true,
                July = true,
                August = true,
                September = true,
                October = true,
                November = true,
                December = true,
                MemberId = member.Id,
                TenantId = tenantGuid
            }).ToList());
            members.Add(member);
        }

        modelBuilder.Entity<Member>().HasData(members);
        modelBuilder.Entity<Payment>().HasData(payments);
        modelBuilder.Entity<SubscriptionPaid>().HasData(subscriptions);
    }

    public static Member CreateMember() => CreateMember(Guid.NewGuid());
    public static Member CreateMember(Guid tenantGuid)
    {
        var faker = new Faker("fr");

        var guid = Guid.NewGuid();
        return new Member
        {
            Id = guid,
            FirstName = faker.Name.FirstName(),
            LastName = faker.Name.LastName(),
            Email = faker.Person.Email,
            PhoneNumber = faker.Person.Phone,
            BirthDate = faker.Date.Past(50, new DateTime(2000, 1, 1)),
            MemberSince = faker.Date.Past(10),
            StreetLine1 = faker.Address.StreetAddress(),
            StreetLine2 = faker.Address.SecondaryAddress(),
            HouseNumber = faker.Address.BuildingNumber(),
            City = faker.Address.City(),
            ZipCode = faker.Address.ZipCode(),
            State = "VD",
            CountryId = Guid.Parse("9bc1f1a9-7696-42e4-89aa-c93800704582"),
            Language = faker.Random.Enum<Language>(),
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = faker.Person.Email,
            TenantId = tenantGuid
        };
    }

    private static void SeedCountries(this ModelBuilder modelBuilder) =>
        modelBuilder
            .Entity<Country>()
            .HasData(Countries);
}
