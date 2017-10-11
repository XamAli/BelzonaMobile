using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BelzonaMobile.Models;
using System.Linq;

namespace BelzonaMobile.Helpers
{
    public static class ProductHelper
    {

        private static Random random;

        public static Product GetRandomMonkey()
        {
            //var output = Newtonsoft.Json.JsonConvert.SerializeObject(Products);
            return Products[random.Next(0, Products.Count)];
        }


        public static ObservableCollection<Grouping<string, Product>> ProdGrouped { get; set; }

        public static ObservableCollection<Product> Products { get; set; }

        static ProductHelper()
        {
            random = new Random();
            Products = new ObservableCollection<Product>();
            Products.Add(new Product
            {
                Name = "Belzona 1111 (Super Metal)",
                Location = "An epoxy-based composite for metal repair.",
                Details = "A 2-part&nbsp;repair composite for metal repair and resurfacing based on solvent-free epoxy resin reinforced with silicon steel alloy. This repair material will not corrode and resists a wide range of chemicals",
                Image = "http://www.belzona.com/assets/data/images/approvals/NSF-ANS-61.jpg"
            });

            Products.Add(new Product
            {
                Name = "Belzona 1111 (Super Metal)",
                Location = "CAn epoxy-based composite for metal repair.",
                Details = "A 2-part&nbsp;repair composite for metal repair and resurfacing based on solvent-free epoxy resin reinforced with silicon steel alloy. This repair material will not corrode and resists a wide range of chemicals. It is easy to mix and apply without the need of specialist tools and can be machined using conventional tools",
                Image = "http://www.belzona.com/assets/data/images/approvals/WRAS-logo.jpg"
            });

            Products.Add(new Product
            {
                Name = "Blue Monkey",
                Location = "Central and East Africa",
                Details = "The blue monkey or diademed monkey is a species of Old World monkey native to Central and East Africa, ranging from the upper Congo River basin east to the East African Rift and south to northern Angola and Zambia",
                Image = "http://upload.wikimedia.org/wikipedia/commons/thumb/8/83/BlueMonkey.jpg/220px-BlueMonkey.jpg"
            });


            Products.Add(new Product
            {
                Name = "Squirrel Monkey",
                Location = "Central & South America",
                Details = "The squirrel monkeys are the New World monkeys of the genus Saimiri. They are the only genus in the subfamily Saimirinae. The name of the genus Saimiri is of Tupi origin, and was also used as an English name by early researchers.",
                Image = "http://upload.wikimedia.org/wikipedia/commons/thumb/2/20/Saimiri_sciureus-1_Luc_Viatour.jpg/220px-Saimiri_sciureus-1_Luc_Viatour.jpg"
            });

            Products.Add(new Product
            {
                Name = "Golden Lion Tamarin",
                Location = "Brazil",
                Details = "The golden lion tamarin also known as the golden marmoset, is a small New World monkey of the family Callitrichidae.",
                Image = "http://upload.wikimedia.org/wikipedia/commons/thumb/8/87/Golden_lion_tamarin_portrait3.jpg/220px-Golden_lion_tamarin_portrait3.jpg"
            });

            Products.Add(new Product
            {
                Name = "Howler Monkey",
                Location = "South America",
                Details = "Howler monkeys are among the largest of the New World monkeys. Fifteen species are currently recognised. Previously classified in the family Cebidae, they are now placed in the family Atelidae.",
                Image = "http://upload.wikimedia.org/wikipedia/commons/thumb/0/0d/Alouatta_guariba.jpg/200px-Alouatta_guariba.jpg"
            });

            Products.Add(new Product
            {
                Name = "Japanese Macaque",
                Location = "Japan",
                Details = "The Japanese macaque, is a terrestrial Old World monkey species native to Japan. They are also sometimes known as the snow monkey because they live in areas where snow covers the ground for months each",
                Image = "http://upload.wikimedia.org/wikipedia/commons/thumb/c/c1/Macaca_fuscata_fuscata1.jpg/220px-Macaca_fuscata_fuscata1.jpg"
            });

            Products.Add(new Product
            {
                Name = "Mandrill",
                Location = "Southern Cameroon, Gabon, Equatorial Guinea, and Congo",
                Details = "The mandrill is a primate of the Old World monkey family, closely related to the baboons and even more closely to the drill. It is found in southern Cameroon, Gabon, Equatorial Guinea, and Congo.",
                Image = "http://upload.wikimedia.org/wikipedia/commons/thumb/7/75/Mandrill_at_san_francisco_zoo.jpg/220px-Mandrill_at_san_francisco_zoo.jpg"
            });

            Products.Add(new Product
            {
                Name = "Proboscis Monkey",
                Location = "Borneo",
                Details = "The proboscis monkey or long-nosed monkey, known as the bekantan in Malay, is a reddish-brown arboreal Old World monkey that is endemic to the south-east Asian island of Borneo.",
                Image = "http://upload.wikimedia.org/wikipedia/commons/thumb/e/e5/Proboscis_Monkey_in_Borneo.jpg/250px-Proboscis_Monkey_in_Borneo.jpg"
            });


            var sorted = from prd in Products
                         orderby prd.Name
                         group prd by prd.NameSort into prdGroup
                                       select new Grouping<string, Product>(prdGroup.Key, prdGroup);

            ProdGrouped = new ObservableCollection<Grouping<string, Product>>(sorted);

        }
    }
}
