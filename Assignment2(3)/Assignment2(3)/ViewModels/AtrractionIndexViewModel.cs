using Assignment2_3_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace Assignment2_3_.ViewModels
{
    public class AtrractionIndexViewModel
    {
        public IPagedList<Atrraction> Atrractions { get; set; }
        /*public IQueryable<Atrraction> Attractions { get; set; }*/
        public string Search { get; set; }
        public IEnumerable<CityWithCount> CityWithCount { get; set; }
        public string City { get; set; }
        public IEnumerable<SelectListItem> CityFilterItems
        {
            get
            {
                var allCities = CityWithCount.Select(cc => new SelectListItem
                {
                    Value = cc.CityName,
                    Text = cc.CityNameWithCount
                });
                return allCities;
            }
        }
    }
    public class CityWithCount
    {
        public int AttractionCount { get; set; }
        public string CityName { get; set; }
        public string CityNameWithCount
        {
            get
            {
                return CityName + " (" + AttractionCount.ToString() + ")";
            }
        }
    }
}