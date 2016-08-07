using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Task1.helpers;
using Task1.Models;

namespace Task1.Controllers
{
    public class Task1Controller : BaseController
    {
        // GET: Task1
        
        public ActionResult Index(Task1ViewModel model)
        {
            if (model.htmlFile == null)
            {
                return View();
            }

            string fileHTNMLContent = new StreamReader(model.htmlFile.InputStream).ReadToEnd();

            string hotelName = regexHelper.getValueByRegex(fileHTNMLContent, "<span[^>]+id\\s*=\\s*.hp_hotel_name.[^>]*>([^<]*)</span>");
            string hotelAddress = regexHelper.getValueByRegex(fileHTNMLContent, "hp_address_subtitle.[^>]*>([^<]*)</span>");
            string hotelStars = regexHelper.getValueByRegex(fileHTNMLContent, "<span[^>]+class\\s*=\\s*.invisible_spoken.[^>]*>([\\d-]+star hotel)</span>");
            string hotelReview = regexHelper.getValueByRegex(fileHTNMLContent, "class=\"count\">([\\d,\\.]+)<");
            string hotelScore = regexHelper.getValueByRegex(fileHTNMLContent, "js--hp-scorecard-scoreval\">([\\d\\.]+)<");
            string hotelDescription = regexHelper.getValueByRegex(fileHTNMLContent, "<div id=\"summary\".*?</div>(.*?)<div class=\"property_hightlights_wrapper");
            string hotelRoomCategories = regexHelper.getValueByRegex(fileHTNMLContent, "hp_last_booking\">(.*?)<div class=\"hotel_quick_links_back_to_top hp_align_right");
            string hotelAlternative = regexHelper.getValueByRegex(fileHTNMLContent, "althotels-wrapper\"[^>]+>(.*?)</div>\\s*</div>");
            

            string jsonresult = regexHelper.getJsonResult(new HotelViewModel
            {
                Name = hotelName,
                Address = hotelAddress,
                Stars = hotelStars,
                Review = hotelReview,
                Score = hotelScore,
                Description = hotelDescription,
                RoomCategories = hotelRoomCategories,
                Alternative = hotelAlternative
            });

            model.JsonResult = jsonresult;
            return View(model);
        }
    }
}