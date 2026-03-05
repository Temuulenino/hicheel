using Microsoft.AspNetCore.Mvc;
using ZodiacApp.Models;

namespace ZodiacApp.Controllers
{
    public class ZodiacController : Controller
    {
        public IActionResult Index()
        {
            return View(GetZodiacs());
        }

        public IActionResult Details(int id)
        {
            var zodiac = GetZodiacs()
                .FirstOrDefault(z => z.Id == id);

            return View(zodiac);
        }

        private List<Zodiac> GetZodiacs()
        {
            return new List<Zodiac>() {
                new Zodiac{
                    Id=1,
                    AnimalMN="Хулгана",
                    AnimalENG="Rat",
                    DescriptionMN="Ухаантай, зохион байгуулалт сайтай.",
                    DescriptionENG="Intelligent and organized.",
                    ImageURL="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ3toFVXiChQwOGkRNg3g_yvSF1kiOFLvF004WDykjc1uiCYi0l2BaQHe0PhSy6T13v8ir8QvTJhcgp9ZsKLr-pJNkAWXF88psBbM0TOvWGFQ&s=10",
                    ElementMN="Ус",
                    ElementENG="Water"
                },

                new Zodiac{
                    Id=2,
                    AnimalMN="Үхэр",
                    AnimalENG="Ox",
                    DescriptionMN="Тэвчээртэй, хөдөлмөрч.",
                    DescriptionENG="Hardworking and patient.",
                    ImageURL="https://images.unsplash.com/photo-1500595046743-cd271d694d30?w=800",
                    ElementMN="Газар",
                    ElementENG="Earth"
                },

                new Zodiac{
                    Id=3,
                    AnimalMN="Бар",
                    AnimalENG="Tiger",
                    DescriptionMN="Зоригтой, удирдагч.",
                    DescriptionENG="Brave and confident leader.",
                    ImageURL="https://images.unsplash.com/photo-1546182990-dffeafbe841d?w=800",
                    ElementMN="Мод",
                    ElementENG="Wood"
                },
                new Zodiac
                   {
                    Id = 4,
                    AnimalMN = "Туулай",
                    AnimalENG = "Rabbit",
                    DescriptionMN = "Эелдэг, тайван, дипломат зан чанартай, урлагийн мэдрэмжтэй.",
                    DescriptionENG = "Gentle, calm, diplomatic, and artistic personality.",
                    ImageURL = "https://images.unsplash.com/photo-1585110396000-c9ffd4e4b308?w=800",
                    ElementMN = "Мод",
                    ElementENG = "Wood"
                },

                new Zodiac
                {
                    Id=5,
                    AnimalMN="Луу",
                    AnimalENG="Dragon",
                    DescriptionMN="Эрч хүчтэй, өөртөө итгэлтэй, манлайлагч зан чанартай.",
                    DescriptionENG="Energetic, confident, and natural leader.",
                    ImageURL="data:image/jpeg;base64,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",
                    ElementMN="Газар",
                    ElementENG="Earth"
                },

                new Zodiac{
                    Id=6,
                    AnimalMN="Могой",
                    AnimalENG="Snake",
                    DescriptionMN="Ухаалаг, нууцлаг, гүн бодолтой, шийдвэр гаргах чадвартай.",
                    DescriptionENG="Wise, mysterious, thoughtful, and strategic thinker.",
                    ImageURL="https://images.unsplash.com/photo-1531386151447-fd76ad50012f?w=800",
                    ElementMN="Гал",
                    ElementENG="Fire"
                },
                new Zodiac{
                    Id=7,
                    AnimalMN="Морь",
                    AnimalENG="Horse",
                    DescriptionMN="Эрч хүчтэй, эрх чөлөөнд дуртай, нийтэч зан чанартай.",
                    DescriptionENG="Energetic, freedom-loving, and social personality.",
                    ImageURL="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSSH6ACmKsSXoww14vYxz-6qqqhFPatON2446yUVxRxm0QcetZGEkJl7xFsVrzkrLphGYviSb3QeZru5yQ1d7Xoc0cn9vbd7NzvNAIZ7jQJ&s=10",
                    ElementMN="Гал",
                    ElementENG="Fire"
                },
                new Zodiac{
                    Id=8,
                    AnimalMN="Хонь",
                    AnimalENG="Goat",
                    DescriptionMN="Зөөлөн сэтгэлтэй, бүтээлч, энэрэнгүй зан чанартай.",
                    DescriptionENG="Kind, creative, and compassionate personality.",
                    ImageURL="data:image/jpeg;base64,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",
                    ElementMN="Газар",
                    ElementENG="Earth"
                },
                new Zodiac{
                    Id=9,
                    AnimalMN="Бич",
                    AnimalENG="Monkey",
                    DescriptionMN="Сэргэлэн, ухаалаг, хөгжилтэй, асуудал шийдэх чадвартай.",
                    DescriptionENG="Smart, playful, and excellent problem solver.",
                    ImageURL="https://images.unsplash.com/photo-1540573133985-87b6da6d54a9?w=800",
                    ElementMN="Металл",
                    ElementENG="Metal"
                },
                new Zodiac{
                    Id=10,
                    AnimalMN="Тахиа",
                    AnimalENG="Rooster",
                    DescriptionMN="Нямбай, хөдөлмөрч, итгэлтэй, зохион байгуулалт сайтай.",
                    DescriptionENG="Hardworking, confident, and organized personality.",
                    ImageURL="https://images.unsplash.com/photo-1548550023-2bdb3c5beed7?w=800",
                    ElementMN="Металл",
                    ElementENG="Metal"
                },
                new Zodiac{
                    Id=11,
                    AnimalMN="Нохой",
                    AnimalENG="Dog",
                    DescriptionMN="Үнэнч, шударга, хамгаалагч зан чанартай.",
                    DescriptionENG="Loyal, honest, and protective personality.",
                    ImageURL="https://images.unsplash.com/photo-1517849845537-4d257902454a?w=800",
                    ElementMN="Газар",
                    ElementENG="Earth"
                },
                new Zodiac{
                    Id=12,
                    AnimalMN="Гахай",
                    AnimalENG="Pig",
                    DescriptionMN="Өгөөмөр, тайван, нөхөрсөг, амьдралаас таашаал авдаг.",
                    DescriptionENG="Generous, calm, friendly, and pleasure-loving personality.",
                    ImageURL="https://images.unsplash.com/photo-1516467508483-a7212febe31a?w=800",
                    ElementMN="Ус",
                    ElementENG="Water"
                }
            };
        }
    }
}
