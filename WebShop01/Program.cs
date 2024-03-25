using BLL;

using WebShop01.Interfaces;
using WebShop01.Services;


using Serilog;
using Serilog.Events;
using System.Data;
using BLL.Entity;

using DAL_V2.Entity;

namespace WebShop01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //FillDatabase();
            var builder = WebApplication.CreateBuilder(args);

            IConfiguration configuration = builder.Configuration;
            builder.Services.AddBusinessLogicLayer(configuration);
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();


            builder.Host.UseSerilog((ctx, lg) =>
            {
                lg.WriteTo.Console(LogEventLevel.Error);
                lg.WriteTo.Seq("http://localhost:4000", LogEventLevel.Error);
            });


            var app = builder.Build();



            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Shop}/{action=Index}/{category?}");

            app.Run();
        }
        public static void FillDatabase()
        {
            using DAL_V2.EntityDatabase db = new DAL_V2.EntityDatabase();
            #region creating instances
            //USERS
            Guid[] userIds = new Guid[2];
            for (int i = 0; i < userIds.Length; i++)
            {
                userIds[i] = Guid.NewGuid();
            }
            DAL_V2.Entity.User[] users =
            {
                        new DAL_V2.Entity.User
                        {
                            Id = userIds[0],
                            Name= "Ben",
                            Login = "qwerty",
                            Password = "pass1212",
                            Email = "trin@gmai.com"
                        },
                        new DAL_V2.Entity.User
                        {
                            Id = userIds[1],
                            Name = "Ron",
                            Login = "zxcvbn",
                            Password = "word3232",
                            Email = "kipin@yahoo.com"
                        }
                };

            //CATEGORIES
            Guid[] categoryIds = new Guid[3];
            for (int i = 0; i < categoryIds.Length; i++)
            {
                categoryIds[i] = Guid.NewGuid();
            }
            DAL_V2.Entity.Category[] categories =
            {
                    new DAL_V2.Entity.Category
                    {
                        Id = categoryIds[0],
                        Name = "Computers"
                    },
                    new DAL_V2.Entity.Category
                    {
                        Id = categoryIds[1],
                        Name = "Garden equipment"
                    },
                    new DAL_V2.Entity.Category
                    {
                        Id = categoryIds[2],
                        Name = "Household chemicals"
                    }
                };

            //PRODUCTS
            Guid[] productIds = new Guid[7];
            for (int i = 0; i < productIds.Length; i++)
            {
                productIds[i] = Guid.NewGuid();
            }
            var imgUrlLegion = "https://www.tuexperto.com/wp-content/uploads/2021/01/lenovo-legion-5-pro-08.jpg";
            var imgUrlTinkPad = "https://m.media-amazon.com/images/I/61d25KoXV+L.jpg";
            var imgUrlSteamDeck = "https://sometimesiplaygames.com/wp-content/uploads/2022/07/image.png";
            var imgUrlShears = "https://images-na.ssl-images-amazon.com/images/I/71i4T5A9ZfL._SL1500_.jpg";
            var imgUrlTrimmer = "https://www.wheeliebinstoragedirect.co.uk/wp-content/uploads/2019/04/hedge-trimmer-cordles.jpg";
            var imgUrlBleach = "https://th.bing.com/th/id/OIP.Jy9kkZxGIOQo4KJrtOdhBQHaHa?rs=1&pid=ImgDetMain";
            var imgUrlAllPurposeCleaner = "https://th.bing.com/th/id/OIP.IpCzx7ZLQbjJmL9QEqNpVgHaHa?rs=1&pid=ImgDetMain";
            DAL_V2.Entity.Product[] products =
            {
                    new DAL_V2.Entity.Product
                    {
                        Id = productIds[0],
                        Name = "Laptop Lenovo Legion",
                        Price = 50000,
                        CategoryId = categoryIds[0],
                        Description = "Powerful laptop that let to enjoy the best AAA-games wherever you are",
                        ImgUrl = imgUrlLegion
                    },
                    new DAL_V2.Entity.Product
                    {
                        Id = productIds[1],
                        Name = "Laptop ThinkPad carbon",
                        Price = 75000,
                        CategoryId = categoryIds[0],
                        Description = "Real working station that suits people who value quality and reliability",
                        ImgUrl = imgUrlTinkPad
                    },
                    new DAL_V2.Entity.Product
                    {
                        Id = productIds[2],
                        Name = "Steam Deck",
                        Price = 20000,
                        CategoryId = categoryIds[0],
                        Description = "Portable game console can run any game on Steam even when traveling on an airplane or in the middle of the forest in a tent",
                        ImgUrl = imgUrlSteamDeck
                    },
                    new DAL_V2.Entity.Product
                    {
                        Id = productIds[3],
                        Name = "Garden Shears",
                        Price = 2500,
                        CategoryId = categoryIds[1],
                        Description = "Professional-grade garden shears for precise cutting and trimming",
                        ImgUrl = imgUrlShears
                    },
                    new DAL_V2.Entity.Product
                    {
                        Id = productIds[4],
                        Name = "Hedge Trimmer",
                        Price = 15000,
                        CategoryId = categoryIds[1],
                        Description = "Electric hedge trimmer for effortless shaping and maintenance of hedges",
                        ImgUrl = imgUrlTrimmer
                    },
                    new DAL_V2.Entity.Product
                    {
                        Id = productIds[5],
                        Name = "Bleach Cleaner",
                        Price = 500,
                        CategoryId = categoryIds[2],
                        Description = "Powerful bleach cleaner for disinfecting and whitening surfaces",
                        ImgUrl = imgUrlBleach
                    },
                    new DAL_V2.Entity.Product
                    {
                        Id = productIds[6],
                        Name = "All-Purpose Cleaner",
                        Price = 1000,
                        CategoryId = categoryIds[2],
                        Description = "Versatile all-purpose cleaner for effectively cleaning various surfaces",
                        ImgUrl = imgUrlAllPurposeCleaner
                    }
                };

            //CARTS
            Guid[] cartIds = new Guid[7];
            for (int i = 0; i < cartIds.Length; i++)
            {
                cartIds[i] = Guid.NewGuid();
            }
            DAL_V2.Entity.Cart[] carts =
            {
                    new DAL_V2.Entity.Cart
                    {
                        Id = cartIds[0],
                        UserId = userIds[0],
                        ProductId = productIds[0],
                    },
                    new DAL_V2.Entity.Cart
                    {
                        Id = cartIds[1],
                        UserId = userIds[0],
                        ProductId = productIds[2],
                    },
                    new DAL_V2.Entity.Cart
                    {
                        Id = cartIds[2],
                        UserId = userIds[0],
                        ProductId = productIds[3],
                    },
                    new DAL_V2.Entity.Cart
                    {
                        Id = cartIds[3],
                        UserId = userIds[1],
                        ProductId = productIds[3],
                    },
                    new DAL_V2.Entity.Cart
                    {
                        Id = cartIds[4],
                        UserId = userIds[1],
                        ProductId = productIds[5],
                    },
                    /*new DAL_V2.Entity.Cart
                    {
                        Id = cartIds[5],
                        UserId = userIds[1],
                        ProductId = productIds[5],
                    },*/
                    new DAL_V2.Entity.Cart
                    {
                        Id = cartIds[6],
                        UserId = userIds[1],
                        ProductId = productIds[1],
                    },
                };

            //WORDS
            Guid[] wordIds = new Guid[13];
            for (int i = 0; i < wordIds.Length; i++)
            {
                wordIds[i] = Guid.NewGuid();
            }
            DAL_V2.Entity.Word[] words =
            {
                    new DAL_V2.Entity.Word
                    {
                        Id = wordIds[0],
                        Header = "computer",
                        KeyWord = "laptop"
                    },
                    new DAL_V2.Entity.Word
                    {
                        Id = wordIds[1],
                        Header = "computer",
                        KeyWord = "Lenovo"
                    },
                    new DAL_V2.Entity.Word
                    {
                        Id = wordIds[2],
                        Header = "computer",
                        KeyWord = "Thinkpad"
                    },
                    new DAL_V2.Entity.Word
                    {
                        Id = wordIds[3],
                        Header = "computer",
                        KeyWord = "Legion"
                    },
                    new DAL_V2.Entity.Word
                    {
                        Id = wordIds[4],
                        Header = "computer",
                        KeyWord = "game"
                    },
                    new DAL_V2.Entity.Word
                    {
                        Id = wordIds[5],
                        Header = "computer",
                        KeyWord = "console"
                    },
                    new DAL_V2.Entity.Word
                    {
                        Id = wordIds[6],
                        Header = "garden",
                        KeyWord = "scissors"
                    },
                    new DAL_V2.Entity.Word
                    {
                        Id = wordIds[7],
                        Header = "garden",
                        KeyWord = "shears"
                    },
                    new DAL_V2.Entity.Word
                    {
                        Id = wordIds[8],
                        Header = "garden",
                        KeyWord = "bushes"
                    },
                    new DAL_V2.Entity.Word
                    {
                        Id = wordIds[9],
                        Header = "garden",
                        KeyWord = "trimmer"
                    },
                    new DAL_V2.Entity.Word
                    {
                        Id = wordIds[10],
                        Header = "chemical",
                        KeyWord = "cleaner"
                    },
                    new DAL_V2.Entity.Word
                    {
                        Id = wordIds[11],
                        Header = "chemical",
                        KeyWord = "bleach"
                    },
                    new DAL_V2.Entity.Word
                    {
                        Id = wordIds[12],
                        Header = "chemical",
                        KeyWord = "all-purpose"
                    }
                };

            //KEY PARAMS
            Guid[] keyParamsIds = new Guid[16];
            for (int i = 0; i < keyParamsIds.Length; i++)
            {
                keyParamsIds[i] = Guid.NewGuid();
            }
            DAL_V2.Entity.KeyParams[] keyParamses =
            {
                    new DAL_V2.Entity.KeyParams
                    {
                        Id = keyParamsIds[0],
                        ProductId = productIds[0],
                        KeyWordsId = wordIds[0],
                    },
                    new DAL_V2.Entity.KeyParams
                    {
                        Id = keyParamsIds[1],
                        ProductId = productIds[0],
                        KeyWordsId = wordIds[1],
                    },
                    new DAL_V2.Entity.KeyParams
                    {
                        Id = keyParamsIds[2],
                        ProductId = productIds[0],
                        KeyWordsId = wordIds[3],
                    },
                    new DAL_V2.Entity.KeyParams
                    {
                        Id = keyParamsIds[3],
                        ProductId = productIds[1],
                        KeyWordsId = wordIds[1],
                    },
                    new DAL_V2.Entity.KeyParams
                    {
                        Id = keyParamsIds[4],
                        ProductId = productIds[1],
                        KeyWordsId = wordIds[2],
                    },
                    new DAL_V2.Entity.KeyParams
                    {
                        Id = keyParamsIds[5],
                        ProductId = productIds[2],
                        KeyWordsId = wordIds[4],
                    },
                    new DAL_V2.Entity.KeyParams
                    {
                        Id = keyParamsIds[6],
                        ProductId = productIds[2],
                        KeyWordsId = wordIds[5],
                    },
                    new DAL_V2.Entity.KeyParams
                    {
                        Id = keyParamsIds[7],
                        ProductId = productIds[3],
                        KeyWordsId = wordIds[6],
                    },
                    new DAL_V2.Entity.KeyParams
                    {
                        Id = keyParamsIds[8],
                        ProductId = productIds[3],
                        KeyWordsId = wordIds[7],
                    },
                    new DAL_V2.Entity.KeyParams
                    {
                        Id = keyParamsIds[9],
                        ProductId = productIds[3],
                        KeyWordsId = wordIds[8],
                    },
                    new DAL_V2.Entity.KeyParams
                    {
                        Id = keyParamsIds[10],
                        ProductId = productIds[4],
                        KeyWordsId = wordIds[8],
                    },
                    new DAL_V2.Entity.KeyParams
                    {
                        Id = keyParamsIds[11],
                        ProductId = productIds[4],
                        KeyWordsId = wordIds[9],
                    },
                    new DAL_V2.Entity.KeyParams
                    {
                        Id = keyParamsIds[12],
                        ProductId = productIds[5],
                        KeyWordsId = wordIds[10],
                    },
                    new DAL_V2.Entity.KeyParams
                    {
                        Id = keyParamsIds[13],
                        ProductId = productIds[5],
                        KeyWordsId = wordIds[11],
                    },
                    new DAL_V2.Entity.KeyParams
                    {
                        Id = keyParamsIds[14],
                        ProductId = productIds[6],
                        KeyWordsId = wordIds[10],
                    },
                    new DAL_V2.Entity.KeyParams
                    {
                        Id = keyParamsIds[15],
                        ProductId = productIds[6],
                        KeyWordsId = wordIds[12],
                    }
                };
            #endregion

            #region pushing data to db
            //Save data to Db
            foreach (DAL_V2.Entity.User user in users)
            {
                db.Add(user);
            }
            db.SaveChanges();

            foreach (DAL_V2.Entity.Category category in categories)
            {
                db.Add(category);
            }
            db.SaveChanges();

            foreach (DAL_V2.Entity.Product product in products)
            {
                db.Add(product);
            }
            db.SaveChanges();

            foreach (DAL_V2.Entity.Cart cart in carts)
            {
                db.Add(cart);
            }
            db.SaveChanges();

            foreach (DAL_V2.Entity.Word word in words)
            {
                db.Add(word);
            }
            db.SaveChanges();

            foreach (DAL_V2.Entity.KeyParams keyParams in keyParamses)
            {
                db.Add(keyParams);
            }
            db.SaveChanges();
            //Console.Out.WriteLine("Data was successfully written to db");

            #endregion
        }
    }
}