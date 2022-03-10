using CarFiltering.UI.Models.Dtos;
using CarFiltering.UI.Provider;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarFiltering.UI.Controllers
{
    public class FilterController : Controller
    {
        FilterProvider _filterProv;

        public FilterController(FilterProvider filterProv)
        {
            _filterProv = filterProv;
        }

        [HttpGet]
        public IActionResult Index()
        {

            ViewBag.Colors = ColorList();
            ViewBag.Transmissions = TransmissionList();
            ViewBag.Years = YearList();
            ViewBag.Brands = BrandList();

            return View(new Filters());
        }

        [HttpPost]
        public async Task<IActionResult> Index(Filters filters)
        {
            ViewBag.Colors = ColorList();
            ViewBag.Transmissions = TransmissionList();
            ViewBag.Years = YearList();
            ViewBag.Brands = BrandList();

            string filteringUrlExtension = string.Empty;

            if (filters.Brand != null)
            {
                filteringUrlExtension += $"brand={filters.Brand}";
            }
            if (filters.Color != null)
            {
                filteringUrlExtension = Separator(filteringUrlExtension);
                filteringUrlExtension += $"extcolor={filters.Color}";
            }
            if (filters.Transmission != null)
            {
                filteringUrlExtension = Separator(filteringUrlExtension);
                filteringUrlExtension += $"trans={filters.Transmission}";
            }
            if (filters.Year != null)
            {
                filteringUrlExtension = Separator(filteringUrlExtension);
                filteringUrlExtension += $"year={filters.Year}";
            }

            if (filteringUrlExtension != string.Empty)
                filteringUrlExtension = "?" + filteringUrlExtension;

            //string filteringUrlExtension = $"?brand={filters.Brand}&year={filters.Year}&extcolor={filters.Color}&trans={filters.Transmission}";
            //

            ViewBag.Cars = await _filterProv.GetCarsAsync(filteringUrlExtension);

            return View("Index");
        }

        private List<string> ColorList()
        {
            List<string> colors = new List<string>();

            colors.Add("beige");
            colors.Add("black");
            colors.Add("blue");
            colors.Add("brown");
            colors.Add("gold");
            colors.Add("gray");
            colors.Add("green");
            colors.Add("orange");
            colors.Add("purple");
            colors.Add("red");
            colors.Add("silver");
            colors.Add("white");
            colors.Add("yellow");

            return colors;
        }

        private List<string> TransmissionList()
        {
            List<string> transmissions = new List<string>();

            transmissions.Add("automanual");
            transmissions.Add("automatic");
            transmissions.Add("cvt");
            transmissions.Add("manual");
            transmissions.Add("unknown");

            return transmissions;
        }

        private List<string> YearList()
        {
            List<string> years = new List<string>();

            for (int i = DateTime.Now.Year; i > 1940; i--)
            {
                years.Add(i.ToString());
            }

            return years;
        }

        private List<string> BrandList()
        {
            List<string> brands = new List<string>();

            brands.Add("acura");
            brands.Add("alfa_romeo");
            brands.Add("american_motors");
            brands.Add("am_general");
            brands.Add("aston_martin");
            brands.Add("auburn");
            brands.Add("audi");
            brands.Add("auistin");
            brands.Add("austin_healey");
            brands.Add("avanti_motors");
            brands.Add("aentley");
            brands.Add("bmw");
            brands.Add("bricklin");
            brands.Add("bugatti");
            brands.Add("buick");
            brands.Add("cadillac");
            brands.Add("checker");
            brands.Add("chevrolet");
            brands.Add("chrysler");
            brands.Add("daewoo");
            brands.Add("daihatsu");
            brands.Add("datsun");
            brands.Add("delahaye");
            brands.Add("delorean");
            brands.Add("desoto");
            brands.Add("detomaso");
            brands.Add("dodge");
            brands.Add("eagle");
            brands.Add("edsel");
            brands.Add("essex");
            brands.Add("ferrari");
            brands.Add("fiat");
            brands.Add("fisker");
            brands.Add("ford");
            brands.Add("franklin");
            brands.Add("genesis");
            brands.Add("geo");
            brands.Add("gmc");
            brands.Add("honda");
            brands.Add("hudson");
            brands.Add("hummer");
            brands.Add("hupmobile");
            brands.Add("hyundai");
            brands.Add("infiniti");
            brands.Add("international");
            brands.Add("isuzu");
            brands.Add("jaguar");
            brands.Add("jeep");
            brands.Add("jensen");
            brands.Add("kaiser");
            brands.Add("karma");
            brands.Add("kia");
            brands.Add("koenigsegg");
            brands.Add("lamborghini");
            brands.Add("lancia");
            brands.Add("land_rover");
            brands.Add("lasalle");
            brands.Add("lexus");
            brands.Add("lincoln");
            brands.Add("lotus");
            brands.Add("lucid");
            brands.Add("maserati");
            brands.Add("maybach");
            brands.Add("mazda");
            brands.Add("mclaren");
            brands.Add("mercedes_benz");
            brands.Add("mercury");
            brands.Add("merkur");
            brands.Add("mg");
            brands.Add("mini");
            brands.Add("mitsubishi");
            brands.Add("morgan");
            brands.Add("morris");
            brands.Add("nash");
            brands.Add("nissan");
            brands.Add("oldsmobile");
            brands.Add("opel");
            brands.Add("packard");
            brands.Add("pagani");
            brands.Add("panoz");
            brands.Add("peugeut");
            brands.Add("plymouth");
            brands.Add("polestar");
            brands.Add("pontiac");
            brands.Add("porsche");
            brands.Add("qvale");
            brands.Add("ram");
            brands.Add("renault");
            brands.Add("rivian");
            brands.Add("rolls_royce");
            brands.Add("rover");
            brands.Add("saab");
            brands.Add("saleen");
            brands.Add("saturn");
            brands.Add("scion");
            brands.Add("smart");
            brands.Add("spyker");
            brands.Add("sterling");
            brands.Add("studebaker");
            brands.Add("subaru");
            brands.Add("sunbeam");
            brands.Add("suzuki");
            brands.Add("tesla");
            brands.Add("toyota");
            brands.Add("triumph");
            brands.Add("tvr");
            brands.Add("volkswagen");
            brands.Add("volvo");
            brands.Add("willys");
            brands.Add("yugo");

            return brands; 
        }

        private string Separator(string filteringUrlExtension)
        {
            if (filteringUrlExtension != string.Empty)
                filteringUrlExtension += "&";

            return filteringUrlExtension;
        }

    }
}
