using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace BelzonaMobile
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
                Details = "<p>A 2-part&nbsp;repair composite for metal repair and resurfacing based on solvent-free epoxy resin reinforced with silicon steel alloy. This repair material will not corrode and resists a wide range of chemicals. It is easy to mix and apply without the need of specialist tools and can be machined using conventional tools.&nbsp;</p>\n\n<h4>Key benefits:</h4>\n\n<ul>\n<li>Multi-purpose durable repair composite</li>\n<li>Fully machinable using conventional tools</li>\n<li>Application and cure at room temperature - no hot work involved</li>\n<li>Simple mixing ratio</li>\n<li>Reduced health and safety risks as it is solvent-free</li>\n<li>No shrinkage, expansion or distortion</li>\n<li>Excellent adhesion to metals including stainless steel, carbon steel, aluminium, brass and copper</li>\n<li>Will adhere to many other natural and synthetic materials including glass and wood&nbsp;</li>\n<li>Outstanding corrosion resistance</li>\n<li>Excellent chemical resistance against a wide range of chemicals</li>\n<li>Excellent electrical insulation characteristics</li>\n</ul>\n\n<h4>Applications for Belzona 1111 (Super Metal) include:</h4>\n\n<ul>\n<li>Repair of cracks and holes on engine and pump casings, pipes, tanks and other equipment</li>\n<li>Resurface of pitted metal surfaces</li>\n<li>Repair of damaged shafts and hydraulic rams</li>\n<li>In-situ flange repair</li>\n<li>High strength structural adhesive for metal bonding</li>\n<li>Creation of irregular load bearing shims and reforming of bearing housings</li>\n</ul>\n\n<p>Belzona 1111 (Super Metal)&nbsp;is suitable for contact with potable water as it is certified to&nbsp;<a href=\"http://info.nsf.org/Certified/PwsComponents/Listings.asp?Company=05720&amp;Standard=061\" target=\"_blank\">NSF/ANSI Standard 61</a>&nbsp;and satisfies the UK Drinking Water Inspectorate requirements.&nbsp;</p>\n\n<table class=\"product_table\">\n<tbody>\n<tr>\n<th colspan=\"2\">Key technical data:</th>\n</tr>\n<tr>\n<td>Working life at 25&deg;C (77&deg;F)</td>\n<td>15 minutes</td>\n</tr>\n<tr>\n<td>Time to immersion service at 25&deg;C (77&deg;F)</td>\n<td>20 hours</td>\n</tr>\n<tr>\n<td>Pull off adhesion (D4541 / ISO 4624)</td>\n<td>3,240 psi (22.33MPa) ambient cure on blasted mild steel</td>\n</tr>\n<tr>\n<td>Compressive strength (ASTM D695)</td>\n<td>12,900 psi (88.9MPa) ambient cure</td>\n</tr>\n<tr>\n<td>Temperature resistance</td>\n<td>93&deg;C (200&deg;F) immersed, 200&deg;C (392&deg;F) dry</td>\n</tr>\n<tr>\n<td>Bonds to</td>\n<td>Aluminium, copper, steel, stainless steel, cast iron, lead, glass, wood and many more</td>\n</tr>\n<tr>\n<td>Typical applications</td>\n<td>Bonding, shimming, filling, gluing, patch repairs and many more</td>\n</tr>\n<tr>\n<td>Unit size</td>\n<td>1kg, 2kg, 5kg. Pack sizes may vary locally</td>\n</tr>\n<tr>\n<td>Availability*</td>\n<td>Global</td>\n</tr>\n</tbody>\n</table>\n\n<p>* All products are subject to regional restrictions. Check with your local Distributor for more information</p>\n\n<hr />\n<table class=\"product_table\">\n<tbody>\n<tr>\n<th colspan=\"2\">Approvals:</th>\n</tr>\n<tr>\n<td>\n<h4>ABS&nbsp;Approval</h4>\n</td>\n<td><img alt=\"ABS\" src=\"http://www.belzona.com/assets/data/images/approvals/ABS.jpg\" style=\"border-style:solid; border-width:0px; height:92px; width:92px\" /></td>\n</tr>\n<tr>\n<td>\n<h4>NSF/ANSI 61</h4>\n</td>\n<td><img alt=\"NSF-ANS-61\" src=\"http://www.belzona.com/assets/data/images/approvals/NSF-ANS-61.jpg\" style=\"border-style:solid; border-width:0px; height:124px; width:92px\" /></td>\n</tr>\n<tr>\n<td>\n<h4>Bureau Veritas Type Approval</h4>\n</td>\n<td><img alt=\"Bureau Veritas logo\" src=\"http://www.belzona.com/assets/data/images/approvals/bureau-veritas.jpg\" style=\"border-style:solid; border-width:0px; height:100px; width:92px\" /></td>\n</tr>\n<tr>\n<td>\n<h4>WRAS Approved Material</h4>\n</td>\n<td><img alt=\"Bureau Veritas logo\" src=\"http://www.belzona.com/assets/data/images/approvals/WRAS-logo.jpg\" style=\"border-style:solid; border-width:0px; height:55px; width:152px\" /></td>\n</tr>\n<tr>\n<td>\n<h4>Germanischer Lloyd Approval</h4>\n</td>\n<td><img alt=\"Germanischer Lloyd logo\" src=\"http://www.belzona.com/assets/data/images/approvals/Germanischer-Lloyd.jpg\" style=\"border-style:solid; border-width:0px; height:65px; width:92px\" /></td>\n</tr>\n<tr>\n<td>\n<h4>China Classification Society</h4>\n</td>\n<td><img alt=\"CSS logo\" src=\"http://www.belzona.com/assets/data/images/approvals/CSS-logo.jpg\" style=\"border-style:solid; border-width:0px; height:117px; width:90px\" /></td>\n</tr>\n</tbody>\n</table>\n",
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
