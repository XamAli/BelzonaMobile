using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelzonaMobile
{
    public class MockDataStore : IDataStore<BelProduct>
    {
        List<BelProduct> BelItem;

        public MockDataStore()
        {
            BelItem = new List<BelProduct>();
            var mockItems = new List<BelProduct>
            {
                new BelProduct { file_path="", name = "Belzona 1111 (Super Metal)", series_id =1, type_id=1, short_description="An epoxy-based composite for metal repair.", long_description="A water-based acrylic emulsion membrane incorporating a polymer bonded glass reinforcing sheet (Belzona 9321) designed to provide seamless, flexible protection to all types of thermal insulation and cladding systems.</p>\n\n<p>Belzona 3211 (Lagseal) is water, weather and fire resistant, and conforms to the requirements for a &lsquo;Class O&rsquo; surface for &lsquo;The UK Building Regulations 1991&rsquo; and &lsquo;Class A&rsquo; in accordance with &lsquo;ASTM E84&rsquo;. The system provides protection from water ingress whilst its microporous nature allows trapped moisture from within the insulation to evaporate. This solvent-free, single pack system requires no mixing and is simple to apply to damp as well as dry insulation" },
                new BelProduct { file_path="", name = "Belzona 1121 (Super Metal)", series_id =1, type_id=1, short_description="An epoxy-based composite for metal repair.", long_description="A water-based acrylic emulsion membrane incorporating a polymer bonded glass reinforcing sheet (Belzona 9321) designed to provide seamless, flexible protection to all types of thermal insulation and cladding systems.</p>\n\n<p>Belzona 3211 (Lagseal) is water, weather and fire resistant, and conforms to the requirements for a &lsquo;Class O&rsquo; surface for &lsquo;The UK Building Regulations 1991&rsquo; and &lsquo;Class A&rsquo; in accordance with &lsquo;ASTM E84&rsquo;. The system provides protection from water ingress whilst its microporous nature allows trapped moisture from within the insulation to evaporate. This solvent-free, single pack system requires no mixing and is simple to apply to damp as well as dry insulation" },
                new BelProduct { file_path="", name = "Belzona 1111 (Super Metal)", series_id =1, type_id=1, short_description="This is an item description.", long_description="" },
                new BelProduct { file_path="", name = "Belzona 3211 (Lagseal)", series_id =1, type_id=1, short_description="A single-component, seamless and flexible coating for encapsulation of all types of thermal insulation and cladding systems.", long_description="A water-based acrylic emulsion membrane incorporating a polymer bonded glass reinforcing sheet (Belzona 9321) designed to provide seamless, flexible protection to all types of thermal insulation and cladding systems.</p>\n\n<p>Belzona 3211 (Lagseal) is water, weather and fire resistant, and conforms to the requirements for a &lsquo;Class O&rsquo; surface for &lsquo;The UK Building Regulations 1991&rsquo; and &lsquo;Class A&rsquo; in accordance with &lsquo;ASTM E84&rsquo;. The system provides protection from water ingress whilst its microporous nature allows trapped moisture from within the insulation to evaporate. This solvent-free, single pack system requires no mixing and is simple to apply to damp as well as dry insulation" },
                new BelProduct { file_path="", name = "Belzona 5122 (Clear Cladding)", series_id =1, type_id=1, short_description="Clear, water-repellent treatment for masonry surfaces..", long_description="A water-based acrylic emulsion membrane incorporating a polymer bonded glass reinforcing sheet (Belzona 9321) designed to provide seamless, flexible protection to all types of thermal insulation and cladding systems.</p>\n\n<p>Belzona 3211 (Lagseal) is water, weather and fire resistant, and conforms to the requirements for a &lsquo;Class O&rsquo; surface for &lsquo;The UK Building Regulations 1991&rsquo; and &lsquo;Class A&rsquo; in accordance with &lsquo;ASTM E84&rsquo;. The system provides protection from water ingress whilst its microporous nature allows trapped moisture from within the insulation to evaporate. This solvent-free, single pack system requires no mixing and is simple to apply to damp as well as dry insulation" },
                new BelProduct { file_path="", name = "Sixth item", series_id =1, type_id=1, short_description="Clear, water-repellent treatment for masonry surfaces.", long_description="A water-based acrylic emulsion membrane incorporating a polymer bonded glass reinforcing sheet (Belzona 9321) designed to provide seamless, flexible protection to all types of thermal insulation and cladding systems.</p>\n\n<p>Belzona 3211 (Lagseal) is water, weather and fire resistant, and conforms to the requirements for a &lsquo;Class O&rsquo; surface for &lsquo;The UK Building Regulations 1991&rsquo; and &lsquo;Class A&rsquo; in accordance with &lsquo;ASTM E84&rsquo;. The system provides protection from water ingress whilst its microporous nature allows trapped moisture from within the insulation to evaporate. This solvent-free, single pack system requires no mixing and is simple to apply to damp as well as dry insulation" },
                //new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                //new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                //new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                //new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                //new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." },
            };

            //foreach (var item in mockItems)
            //{
            //    BelItem.Add(item);
            //}
            BelItem = mockItems;
        }

        public async Task<bool> AddItemAsync(BelProduct item)
        {
            BelItem.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(BelProduct item)
        {
            var _item = BelItem.Where((BelProduct arg) => arg.short_description == item.short_description).FirstOrDefault();
            BelItem.Remove(_item);
            BelItem.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = BelItem.Where((BelProduct arg) => arg.short_description == id).FirstOrDefault();
            BelItem.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<BelProduct> GetItemAsync(string id)
        {
            return await Task.FromResult(BelItem.FirstOrDefault(s => s.short_description == id));
        }

        public async Task<IEnumerable<BelProduct>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(BelItem);
        }
    }
}