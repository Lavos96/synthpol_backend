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

            AddProviders(context);
            AddCategories(context);
            AddProducts(context);
            
            context.SaveChanges();
        }

        private static void AddProviders(SyntPolDbContext context)
        {
			Provider[] providers = new Provider[]
			{
				new Provider {
					ProviderNumber = 1,
					FirstName = "OLIMP",
					LastName = "LABORATORIES",
					Street = "random 5/12",
					HomeNumber = 123456789,
					ZipCode = "42-207",
					City = "Warsaw",
					NIP = "1234567890",
					ShallDisplay = true
				},
				new Provider {
					ProviderNumber = 2,
					FirstName = "DOMYOS",
					LastName = "LABORATORIES",
					Street = "random 5/12",
					HomeNumber = 123456789,
					ZipCode = "42-207",
					City = "Poznań",
					NIP = "1234567890",
					ShallDisplay = true
				},
				new Provider {
					ProviderNumber = 3,
					FirstName = "WEIDER",
					LastName = "LABORATORIES",
					Street = "random 5/12",
					HomeNumber = 123456789,
					ZipCode = "42-207",
					City = "Szczecin",
					NIP = "1234567890",
					ShallDisplay = true
				}
			};

			foreach (var prov in providers)
			{
				context.Add(prov);
			}
            context.SaveChanges();
        }

        private static void AddCategories(SyntPolDbContext context)
        {
			Category[] categories = new Category[]
			{
				new Category {
					CategoryName = "BCAA",
					ShallDisplay = true
				},
				new Category {
					CategoryName = "ODŻYWKA BIAŁKOWA",
					ShallDisplay = true
				},
				new Category {
					CategoryName = "GAINERY",
					ShallDisplay = true
				},
				new Category {
					CategoryName = "KREATYNA",
					ShallDisplay = true
				},
				new Category {
					CategoryName = "CARBO",
					ShallDisplay = true
				},
				new Category {
					CategoryName = "WITAMINY",
					ShallDisplay = true
				},
			};
			foreach(var cat in categories)
			{
				context.Categories.Add(cat);
			}
            context.SaveChanges();
        }

        private static void AddProducts(SyntPolDbContext context)
        {
			Product[] products = new Product[]
			{
				new Product
				{
					Name = "BCAA Xplode Energy",
					VAT = 18,
					NettoPrice = 109.00M,
					Description = "Dzięki zawartości kofeiny i beta-alaniny jest idealnym preparatem do stosowania przed lub w trakcie wysiłku fizycznego. Zachowanie odpowiednich parametrów wytrzymałości organizmu ma pozytywny wpływ na odsuwanie w czasie momentu fizycznego i psychicznego zmęczenia sportowca.",
					PhotoString = "https://olimpsport.com/pub/media/catalog/product/optimized/6/b/6bb4e4678e754f753b5fc0bafcd2103b7d9cca9ecd9e094c923cc95254c081da/bcaa_xplode_energy_sleeve_2.png",
					ProviderId = 1,
					CategoryId = 1,
					ShallDisplay = false
				},
				new Product
				{
					Name = "BCAA 1100 MEGA CAPS",
					VAT = 18,
					NettoPrice = 11.00M,
					Description = "Suplement diety BCAA Mega Caps to preparat pozwalający na szybkie dostarczenie organizmowi optymalnej dawki wolnych aminokwasów rozgałęzionych. Produkt powstał na podstawie wiedzy specjalistów marki Olimp, innowacyjnej technologię produkcji, a także licznych badań wykorzystanych surowców pod kątem gatunkowości oraz czystości mikrobiologicznej i fizykochemicznej. Pieczołowita praca nad tym suplementem pozwoliła stworzyć kompleks trzech najważniejszych aminokwasów egzogennych, które zostały zamknięte w unikalnej formie Mega Caps. Oto skoncentrowana porcja BCAA stworzona z myślą o każdym, kto pragnie efektów i dba o swoją codzienną dietę.",
					PhotoString = "https://olimpsport.com/pub/media/catalog/product/optimized/b/f/bf4f5187971340a9129d13606bb1dde9ea3a7fb6b7e1d6bb62a6aeb33c1efcd7/bcaa-120-caps_2_2.png",
					ProviderId = 1,
					CategoryId = 1,
					ShallDisplay = true
				},
				new Product
				{
					Name = "AMINOKWASY BCAA",
					VAT = 18,
					NettoPrice = 109.99M,
					Description = "Trzymać poza zasięgiem małych dzieci. Oprócz aktywności fizycznej istotna jest zróżnicowana i zbilansowana dieta oraz zdrowy tryb życia.",
					PhotoString = "https://www.decathlon.pl/media/817/8176804/classic_1732203.jpg",
					ProviderId = 3,
					CategoryId = 1,
					ShallDisplay = true
				},
				new Product
				{
					Name = "BCAA 2.1.1 ARBUZOWY",
					VAT = 18,
					NettoPrice = 44.99M,
					Description = "BCAA 2:1:1 składa się z witamin B6, B9, C, a także z L-leucyny, L-izoleucyny, L-waliny w proporcji 2:1:1 oraz L-glutaminy. Witamina B6 usprawnia metabolizm białka i glikogenu. Witamina B9 pomaga w odpowiedniej syntezie aminokwasów. Witaminy C, B6 i B9 zmniejszają uczucie zmęczenia.",
					PhotoString = "https://www.decathlon.pl/media/854/8545107/classic_1630976.jpg",
					ProviderId = 2,
					CategoryId = 1,
					ShallDisplay = true
				},
				new Product
				{
					Name = "BCAA 2.1.1 OWOCE LEŚNE",
					VAT = 18,
					NettoPrice = 44.99M,
					Description = "BCAA 2:1:1 składa się z witamin B6, B9, C, a także z L-leucyny, L-izoleucyny, L-waliny w proporcji 2:1:1 oraz L-glutaminy. Witamina B6 usprawnia metabolizm białka i glikogenu. Witamina B9 pomaga w odpowiedniej syntezie aminokwasów. Witaminy C, B6 i B9 zmniejszają uczucie zmęczenia.",
					PhotoString = "https://www.decathlon.pl/media/854/8545108/classic_1630977.jpg",
					ProviderId = 2,
					CategoryId = 1,
					ShallDisplay = true
				},
				new Product
				{
					Name = "Natural Whey Protein Concentrate",
					VAT = 18,
					NettoPrice = 49.00M,
					Description = "100% Natural Whey Protein Concentrate. Dietetyczny środek spożywczy. Koncentrat białek serwatkowych w instant (77% białka. Wysokiej jakości, czysty koncentrat białek serwatkowych WPC.Białko przyczynia się do wzrostu i utrzymania masy mięśniowej. Zaufaj marce z tradycją i wieloletnim doświadczeniem - z OLIMP SPORT NUTRITION JESTEŚ PEWNY TEGO CO PIJESZ!!! TYLKO TERAZ -W NOWEJ PRAKTYCZNEJ FOLII ZIP!!!",
					PhotoString = "https://olimpsport.com/pub/media/catalog/product/optimized/8/0/809e47589a94763e9cfb427050e80cbefa27ab81801e51463b0adc8876f17280/whey-concentrate.png",
					ProviderId = 1,
					CategoryId = 2,
					ShallDisplay = true
				},
				new Product
				{
					Name = "Veggie Protein Complex",
					VAT = 18,
					NettoPrice = 77.00M,
					Description = "Suplement diety Veggie Protein Complex to odżywka białkowa, którą stworzono z myślą o osobach będących weganami lub wegetarianami. Specjaliści firmy Olimp zdecydowali się na wykorzystanie tylko naturalnych składników, odznaczających się wysokim stopniem czystości i pozwalających na uzupełnienie codziennej diety o niezbędną dawkę protein i aminokwasów pochodzących z aż trzech różnych źródeł. Skład Veggie Protein Complex został pozbawiony syntetycznych substancji słodzących, a każda porcja stanowi prosty i wygodny sposób na dostarczenie pełnowartościowego białka roślinnego.",
					PhotoString = "https://olimpsport.com/pub/media/catalog/product/optimized/9/1/9184074167d4e387e8460797bbfb129ae9e88a24a6bf49e3ae68b9d66368a7d9/veggie_protein_final_2.png",
					ProviderId = 1,
					CategoryId = 2,
					ShallDisplay = true
				},
				new Product
				{
					Name = "Mega Strong Protein",
					VAT = 18,
					NettoPrice = 74.00M,
					Description = "Mega Strong Protein- najwyższy poziom wtajemniczenia w uzupełnianiu protein. Ta elitarna odżywka wysokobiałkowa gwarantuje dostarczanie najwyższej jakości białka, przez ponad 5 godzin od chwili spożycia. Osiągnięte zostało to dzięki swoistej proporcji aż sześciu pełnowartościowych źródeł białka, gwarantujących całkowite nasycenie krwi najbardziej pożądanym profilem aminokwasowym. Ekskluzywny skład i magia smaku oferowana przez Mega Strong Protein spełnia wymagania najbardziej wybrednych profesjonalistów sportowych, jak i każdej osoby ćwiczącej rekreacyjnie, wykazującej zwiększone zapotrzebowanie na białko czy też dążącej do szybkiego rozwoju masy mięśniowej.",
					PhotoString = "https://olimpsport.com/pub/media/catalog/product/optimized/8/9/89a631288e2a403c5efb3d4756434726f3569491bd7e18b6125ac235e34af105/mega_strongprotein.png",
					ProviderId = 1,
					CategoryId = 2,
					ShallDisplay = true
				},
				new Product
				{
					Name = "ODŻYWKA BIAŁKOWA WHEY 900G CZEKOLADOWA",
					VAT = 18,
					NettoPrice = 64.99M,
					Description = "Odżywka składa się w 70% z białka serwatki i zapewnia szybkie wchłanianie. Posiada niską zawartość tłuszczu. Jest szczególnie dostosowana do początkujących sportowców, ponieważ zawiera nie tylko białka, które przyczyniają się do wzrostu masy mięśniowej, ale także w naturalny sposób zapewnia 4,5 g węglowodanów, tak ważnych po treningu.",
					PhotoString = "https://www.decathlon.pl/media/854/8545089/classic_1614821.jpg",
					ProviderId = 2,
					CategoryId = 2,
					ShallDisplay = true
				},
				new Product
				{
					Name = "ODŻYWKA BIAŁKOWA WHEY WANILIA 900G",
					VAT = 18,
					NettoPrice = 64.99M,
					Description = "Odżywka składa się w 70% z białka serwatki i zapewnia szybkie wchłanianie. Posiada niską zawartość tłuszczu. Jest szczególnie dostosowana do początkujących sportowców, ponieważ zawiera nie tylko białka, które przyczyniają się do wzrostu masy mięśniowej, ale także w naturalny sposób zapewnia 4,5 g węglowodanów, tak ważnych po treningu.",
					PhotoString = "https://www.decathlon.pl/media/854/8545090/classic_1739740.jpg",
					ProviderId = 2,
					CategoryId = 2,
					ShallDisplay = true
				},
				new Product
				{
					Name = "ODŻYWKA BIAŁKOWA WHEY 250G",
					VAT = 18,
					NettoPrice = 19.99M,
					Description = "Odżywka składa się w 70% z białka serwatki i zapewnia szybkie wchłanianie. Posiada niską zawartość tłuszczu. Jest szczególnie dostosowana do początkujących sportowców, ponieważ zawiera nie tylko białka, które przyczyniają się do wzrostu masy mięśniowej, ale także w naturalny sposób zapewnia 4,5 g węglowodanów, tak ważnych po treningu.",
					PhotoString = "https://www.decathlon.pl/media/854/8545088/classic_1614786.jpg",
					ProviderId = 2,
					CategoryId = 2,
					ShallDisplay = true
				},
				new Product
				{
					Name = "Gain Bolic 6000",
					VAT = 18,
					NettoPrice = 36.00M,
					Description = "Firma Olimp Sport Nutrition dzięki surowcom o wysokim stopniu czystości i innowacyjnej technologii produkcji od wielu lat wyznacza trendy na rynku suplementów diety. Farmaceutyczna jakość oferowanych produktów, podyktowana nowatorskimi laboratoriami, to gwarancja ich realnego działania, a przede wszystkim prawdziwe wsparcie dla każdego ćwiczącego. Nie inaczej jest z preparatem Gain Bolic 6000 – wieloskładnikowej mieszance najważniejszych substancji aktywnych do spektakularnej rozbudowy masy mięśniowej, a także wzmocnienia efektów płynących ze zbilansowanej diety i systematycznych treningów! Zapomnij o dotychczasowych suplementach, wybierz Gain Bolic 6000!",
					PhotoString = "https://olimpsport.com/pub/media/catalog/product/optimized/5/e/5e712b4731ca615f31ad74f56eee4b04ac65703bf7d44c5cb74ecad3a4885737/gain-bolic-3500-czekolada_1_2.png",
					ProviderId = 1,
					CategoryId = 3,
					ShallDisplay = true
				},
				new Product
				{
					Name = "Gainer MCT",
					VAT = 18,
					NettoPrice = 254.00M,
					Description = "Gainer MCT to kultowa odżywka węglowodanowo-białkowa, popularny „gainer”, którego pierwsza wersja pojawiła się na rynku w 1994 roku. Dzięki wieloletniej tradycji i uważnej pracy na składem, nowy Gainer MCT to preparat doskonały w swej dzisiejszej postaci. Ponad 20 lat od premiery to czas, który musiał upłynąć, aby powstał produkt w ocenie elitarnego Olimp Team – doskonały! Zawdzięcza to sztabowi ludzi z laboratoriów Olimp, którzy przed laty stworzyli pierwszą formułę a po latach analizując stan wiedzy, badania z udziałem sportowców i nowości technologiczne, oddają w Twoje ręce najnowszą odsłonę produktu, który dziś możesz stosować sam i polecić swojemu synowi.",
					PhotoString = "https://olimpsport.com/pub/media/catalog/product/optimized/d/b/db423092104dcaa4942918bfadeb3a8c7165e31db12e30feca38b5f77d2f3c3e/gainer-mct_2_1.png",
					ProviderId = 1,
					CategoryId = 3,
					ShallDisplay = true
				},
				new Product
				{
					Name = "MASS GAINER 3KG 900G CZEKOLADA",
					VAT = 18,
					NettoPrice = 34.99M,
					Description = "Preparat w proszku do przygotowania napoju będącego źródłem białka serwatki; aromatyzowany. Czekoladowy smak. Skład: dekstroza (38%), maltodekstryna (37%), koncentrat białka serwatki(21%), kakao o obniżonej zawartości tłuszczu w proszku (3%), aromat, emulgator: lecytyna sojowa. W zakładzie produkcyjnym wykorzystuje się: gluten, jaka, siarczyny, skorupiaki, gorczycę, ryby, seler.",
					PhotoString = "https://www.decathlon.pl/media/834/8348915/classic_184360.jpg",
					ProviderId = 2,
					CategoryId = 3,
					ShallDisplay = true
				},
				new Product
				{
					Name = "MASS GAINER 3 WANILIOWY 2,5KG",
					VAT = 18,
					NettoPrice = 109.99M,
					Description = "Preparat w proszku do przygotowania napoju będącego źródłem białka serwatki; aromatyzowany. Skład: maltodekstryna (46%), dekstroza (31%), koncentrat białka serwatki (22%) (MLEKO*), aromat, emulgator: lecytyna SOJOWA*. W zakładzie produkcyjnym wykorzystuje się: GLUTEN*, JAJKA*, SIARCZYNY*, SKORUPIAKI*, GORCZYCĘ*, RYBY*, SELER*, ORZECHY ŁUPINOWE* *Alergeny",
					PhotoString = "https://www.decathlon.pl/media/855/8553078/classic_1637417.jpg",
					ProviderId = 2,
					CategoryId = 3,
					ShallDisplay = true
				},
				new Product
				{
					Name = "Creatine Magna Power",
					VAT = 18,
					NettoPrice = 18.75M,
					Description = "Kreatyna jest najskuteczniejszym – obok argininy – dozwolonym środkiem anabolicznym. Fakt ten potwierdziły zarówno liczne badania naukowe, jak też wieloletnia praktyka stosowania jej w sporcie. Jednakże, pełne wykorzystanie kreatyny jako suplementu stymulującego rozwój siły i masy ogranicza reakcja laktamacji, przekształcająca znaczną część spożywanej kreatyny w nieaktywną kreatyninę. W reakcji tej, grupa aminowa kreatyny wiąże się z jej grupą kwasową, co prowadzi do zamknięcia cząsteczki, utworzenia kreatyniny i utraty aktywności anabolicznej. Reakcję tę przyspiesza wysoka kwasowość środowiska, jaka panuje w roztworach kreatyny przygotowanych do bezpośredniego spożycia, jak też w górnym odcinku przewodu pokarmowego.",
					PhotoString = "https://olimpsport.com/pub/media/catalog/product/optimized/b/1/b19d7112eaed10236b0cf1a613d3f1903671e96f187bd8e6a1c08ade9cebc0f9/creatine-magna-power-120_1.png",
					ProviderId = 1,
					CategoryId = 4,
					ShallDisplay = true
				},
				new Product
				{
					Name = "TCM Xplode",
					VAT = 18,
					NettoPrice = 33.00M,
					Description = "W świecie współczesnej suplementacji w sporcie można odnieść wrażenie, że powiedziano już wszystko, a nasza wiedza osiągnęła pełnię, zwłaszcza, jeśli chodzi o stosowanie produktów bazujących na kreatynie i różnych jej formach. Jedną z najczęściej stosowanych we wspomaganiu wysiłku sportowego, a przez to doskonale sprawdzoną przez osoby aktywnie fizycznie jest jabłczan kreatyny. Okazuje się, że nawet ten związek może być jeszcze skuteczniej wykorzystany przez organizm sportowca. Mimo swej znacznie większej stabilności w niskim pH przewodu pokarmowego i biodostępności, w porównaniu w monohydratem kreatyny, dalsza poprawa skuteczności okazała się możliwa, ale tylko dzięki wiedzy i doświadczeniu ekspertów z R&D Olimp Laboratories.",
					PhotoString = "https://olimpsport.com/pub/media/catalog/product/optimized/b/c/bc065f648e3b611a86cde98e80bf715bbee23acc23ada267f900d344d65c0277/tcm.png",
					ProviderId = 1,
					CategoryId = 4,
					ShallDisplay = true
				},
				new Product
				{
					Name = "KREATYNA JEDNOWODNA 500G",
					VAT = 18,
					NettoPrice = 29.99M,
					Description = "Suplement diety w proszku, na bazie kreatyny jednowodnej. Bez aromatów. Skład: kreatyna jednowodna (100%). W zakładzie produkcyjnym wykorzystuje się: GLUTEN*, JAJKA*, SIARCZYNY*, SKORUPIAKI*, GORCZYCĘ*, RYBY*, SELER*, ORZECHY ŁUPINOWE*, SOJĘ*, MLEKO*. *Alergeny",
					PhotoString = "https://www.decathlon.pl/media/837/8378664/classic_1056748.jpg",
					ProviderId = 2,
					CategoryId = 4,
					ShallDisplay = true
				},
				new Product
				{
					Name = "KREATYNA JEDNOWODNA",
					VAT = 18,
					NettoPrice = 54.99M,
					Description = "Suplement diety w kapsułkach, na bazie kreatyny jednowodnej. Bez aromatów. Skład: kreatyna jednowodna, kapsułka roślinna (hydroksypropylometyloceluloza), substancja przeciwzbrylająca: stearynian magnezu.",
					PhotoString = "https://www.decathlon.pl/media/848/8484824/classic_1334433.jpg",
					ProviderId = 2,
					CategoryId = 4,
					ShallDisplay = true
				},
				new Product
				{
					Name = "STAND-BY",
					VAT = 18,
					NettoPrice = 7.50M,
					Description = "Wnikliwie analizując wysiłek fizyczny, jakiemu poddawane są osoby uprawiające sporty dyscyplin wytrzymałościowych, zauważamy, iż często jest to praca o dużej charakterystyce zmian, gdzie takie czynności, jak dynamiczne starty, szybkie zmiany kierunku, gwałtowne hamowania i przyspieszenia, a także pokonywanie jednorazowo dłuższych dystansów z różną prędkością, niezwykle płynnie się przeplatają, budując sumarycznie wysoką intensywność wysiłku. W takich warunkach beztlenowe mechanizmy pozyskiwania energii uzupełniane są przez przemiany tlenowe, które w ogólnym rozrachunku stanowią dominujące źródło energii wytwarzanej przez organizm na potrzeby realizowanego wysiłku. Z tego też powodu, dobrze skomponowana suplementacja powinna obejmować stosowanie wysokiej jakości preparatów dla piłkarzy, pozwalających utrzymać wysoką efektywność tlenowego i beztlenowego wytwarzania energii (np. ENDUGEN).",
					PhotoString = "https://olimpsport.com/pub/media/catalog/product/optimized/3/b/3b4150142b173c724ab42030a2fa87d5fa4dfd43485694317355a0003f6955f6/stand-by_recover_gel.png",
					ProviderId = 1,
					CategoryId = 5,
					ShallDisplay = true
				},
				new Product
				{
					Name = "HYDRATONIC ENERGY",
					VAT = 18,
					NettoPrice = 16.50M,
					Description = "HYDRATONIC ENERGY to rewelacyjny, zaawansowany napój izotoniczny, zawierający kompleksowe zestawienie witamin składników mineralnych, oraz kofeiny i tauryny, aby zapewnić pożądany stopień nawodnienia organizmu i dostarczyć dodatkowej energii osobie aktywnej.",
					PhotoString = "https://olimpsport.com/pub/media/catalog/product/optimized/6/8/68a5fb24f172fcd38bd9ad53cba42700d50c9106d880d5aba7ab385990757fe7/hydratonicenergy.png",
					ProviderId = 1,
					CategoryId = 5,
					ShallDisplay = true
				},
				new Product
				{
					Name = "Dextrex Juice",
					VAT = 18,
					NettoPrice = 19.99M,
					Description = "Dextrex Juice to przemyślany kompleks farmaceutycznej dekstrozy, mikronizowanej tauryny wraz ze sporym dodatkiem magnezu. Całość służy m.in. optymalizacji działania kreatyny. Suplementacja kreatyną prowadzi m.in. do zwiększenia tempa odnawiania ATP w komórkach mięśniowych, co w konsekwencji może skutkować wzrostem siły jak i masy mięśniowej. Przy wykorzystaniu Dextrex Juice upewniamy się, że jesteśmy w stanie zoptymalizować jej efekty.",
					PhotoString = "https://olimpsport.com/pub/media/catalog/product/optimized/0/9/0934550332b2d436c4bb458899840df3e7dc6842fac2ad67537b75d426d9c5d0/carbonox_1_1.png",
					ProviderId = 1,
					CategoryId = 5,
					ShallDisplay = true
				},
				new Product
				{
					Name = "ISO PLUS",
					VAT = 18,
					NettoPrice = 3.00M,
					Description = "ISO PLUS to starannie skomponowany koncentrat w proszku do przyrządzania napoju izotonicznego, który intensywnie i w maksymalnym stopniu nawadnia organizm, przywracając mu równowagę wodno-elektrolitową podczas i po wysiłku. Specjalna receptura izotoniczna została wzbogacona L-karnityną i L-glutaminą, które dodatkowo wspomagają organizm w trakcie długotrwałego wysiłku fizycznego. Dodatek witamin uzupełnia zwiększoną ich utratę z organizmu w trakcie treningu.",
					PhotoString = "https://olimpsport.com/pub/media/catalog/product/optimized/4/f/4f0ca8d9d24f60e865e4c2c070275b240bdf4b543260e5053bd101dcbc5f4d80/iso-plus-700_2.png",
					ProviderId = 1,
					CategoryId = 5,
					ShallDisplay = true
				},
				new Product
				{
					Name = "Hydratonic Fast",
					VAT = 18,
					NettoPrice = 20.34M,
					Description = "Hydratonic Fast to suplement diety w postaci tabletek musujących, który po rozpuszczeniu w wodzie przechodzi w pyszny napój gaszący pragnienie w każdej sytuacji. Zawiera kluczowe elektrolity (sód, potas, wapń, magnez), dodatkowo uzupełniony o glukozę i witaminę C. Szybsze wchłonięcie składników zapewnia płynna forma produktu.",
					PhotoString = "https://olimpsport.com/pub/media/catalog/product/optimized/e/7/e7e8e5b0cbdfaba7c2484978e3571d3c8506a04fa4e07aab4f0c9ec598191fa1/hydratonicfast.png",
					ProviderId = 1,
					CategoryId = 6,
					ShallDisplay = true
				},
				new Product
				{
					Name = "HYDRA-FAST LADY",
					VAT = 18,
					NettoPrice = 26.33M,
					Description = "Hydra-Fast Lady - musująca, odświeżająca formuła dla aktywnych kobiet, do przygotowania doskonałego napoju gaszącego pragnienie w każdej sytuacji. Idealnie sprawdza się podczas treningu, rekreacji, upalnego dnia czy przy zwykłych, codziennych czynności.",
					PhotoString = "https://olimpsport.com/pub/media/catalog/product/optimized/9/d/9d0bb0b531faf0d75528806392cc3560d7c548374fb9985f90aa9b08453f9aec/hydrafastlady.png",
					ProviderId = 1,
					CategoryId = 6,
					ShallDisplay = true
				},
				new Product
				{
					Name = "Vita-MIN AntiOX EFFER MAX",
					VAT = 18,
					NettoPrice = 16.90M,
					Description = "W procesach metabolicznych z udziałem tlenu (np. wysiłki tlenowe) produktem ubocznym jest niewielka ilość wolnych rodników tlenowych (ROS), która utrzymywana jest na stałym poziomie przez system wewnątrz – i zewnątrzkomórkowych antyoksydantów  (przeciwutleniaczy). W warunkach homeostazy spoczynkowej istnieje równowaga między ilością wytworzonych i zutylizowanych ROS i określana jest jako równowaga red – ox (perodyksacyjno – antyoksydacyjna). Zaburzenie równowagi między procesami powstawania i utylizacji ROS na skutek intensywnego wysiłku fizycznego prowadzi w komórkach i tkankach do stresu oksydacyjnego.",
					PhotoString = "https://olimpsport.com/pub/media/catalog/product/optimized/7/b/7b5f90be8d1af23c4015594d24b5a12cf72be39d7258c85b87714f56b27e64dc/vita_min_antiox.png",
					ProviderId = 1,
					CategoryId = 6,
					ShallDisplay = true
				},
				new Product
				{
					Name = "Gold-Vit C 1000",
					VAT = 18,
					NettoPrice = 45.00M,
					Description = "Gold-Vit C 1000 to innowacyjny suplement diety zawierający maksymalną dawkę witaminy C, w postaci opatentowanej PureWay-C, czyli kompleksu kwasu L-askorbinowego i bioflawonoidów cytrusowych.",
					PhotoString = "https://olimpsport.com/pub/media/catalog/product/optimized/c/3/c322577bae8ceb42a8a0bdf52bd4c035dd9fddac0cc9452ed83d49a023c51e3b/gold_vit_c_1000_osn.png",
					ProviderId = 1,
					CategoryId = 6,
					ShallDisplay = true
				},
			};

			foreach (var product in products)
            {
                context.Products.Add(product);
            }
            context.SaveChanges();
        }
    }
}