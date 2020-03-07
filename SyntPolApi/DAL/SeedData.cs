using SyntPolApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyntPolApi.DAL
{
    public class SeedData
    {
        public static void Initialize(SyntPolDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            Provider provider = new Provider
            {

                ProviderNumber = 1,
                FirstName = "OLIMP",
                LastName = "LABORATORIES",
                Street = "random 5/12",
                HomeNumber = 123456789,
                ZipCode = "42-207",
                City = "Warsaw",
                NIP = "1234567890"
            };

            context.Providers.Add(provider);
            context.SaveChanges();

            var products = new Product[]
            {
                new Product 
                {
                    Name = "Natural Whey Protein Concentrate",
                    VAT = 18,
                    NettoPrice = 49.00M,
                    Description = "100% Natural Whey Protein Concentrate. Dietetyczny środek spożywczy. Koncentrat białek serwatkowych w instant (77% białka. Wysokiej jakości, czysty koncentrat białek serwatkowych WPC.Białko przyczynia się do wzrostu i utrzymania masy mięśniowej. Zaufaj marce z tradycją i wieloletnim doświadczeniem - z OLIMP SPORT NUTRITION® JESTEŚ PEWNY TEGO CO PIJESZ!!! TYLKO TERAZ -W NOWEJ PRAKTYCZNEJ FOLII ZIP!!!",
                    PhotoString = "https://olimpsport.com/pub/media/catalog/product/optimized/8/0/809e47589a94763e9cfb427050e80cbefa27ab81801e51463b0adc8876f17280/whey-concentrate.png",
                    ProviderId = 1
                },

                new Product
                {
                    Name = "AMOK",
                    VAT = 18,
                    NettoPrice = 39.00M,
                    Description = "Pewnie znowu ciężki dzień w pracy? Nie chce Ci się ruszać, a wiesz, że kumple na treningu Ci nie odpuszczą. Dokładnie tak! Będą wypoczęci i żądni zwycięstwa. Muszą się na kimś wyżyć, a osoba bez weny do treningu jest bardzo dobrym celem. Nie dziw się, każdy chce być NAJLEPSZY! Pogrążą Cię jak się w końcu nie zmobilizujesz. Musisz wziąć się w garść, zacząć działać precyzyjnie i wreszcie pozamiatać towarzystwo. Koniec z użalaniem się: że jest ciężko, że się nie chce, że inni mają łatwiej. Może i tak, ale czas najwyższy wytłuc z nich myśli o zwycięstwie.",
                    PhotoString = "https://olimpsport.com/pub/media/catalog/product/optimized/1/9/192b1a81b134ca8d610e4be9689266de1ca3889e85aeb88c0fdc0e153e0fa55e/amok_2.png",
                    ProviderId = 1
                },

                new Product
                {
                    Name = "BCAA Xplode Energy",
                    VAT = 18,
                    NettoPrice = 109.00M,
                    Description = "Dzięki zawartości kofeiny i beta-alaniny jest idealnym preparatem do stosowania przed lub w trakcie wysiłku fizycznego. Zachowanie odpowiednich parametrów wytrzymałości organizmu ma pozytywny wpływ na odsuwanie w czasie momentu fizycznego i psychicznego zmęczenia sportowca.",
                    PhotoString = "https://olimpsport.com/pub/media/catalog/product/optimized/6/b/6bb4e4678e754f753b5fc0bafcd2103b7d9cca9ecd9e094c923cc95254c081da/bcaa_xplode_energy_sleeve_2.png",
                    ProviderId = 1
                }
            };

            foreach(var product in products)
            {
                context.Products.Add(product);
            }
            context.SaveChanges();
        }
    }
}
