using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Task1.Models;

namespace Task1.helpers
{
    public class RegexHelper
    {
        // Multiple parameters.
        /// <param name="htmlContent">is content of file which is uploaded from Index page of Task1</param>
        /// <param name="regexPattern">is pattern to find part of html string based on</param>
        public string getValueByRegex(string htmlContent,string regexPattern)
        {            
            Match regexValue = Regex.Match(
                           htmlContent,
                           regexPattern,
                           RegexOptions.Singleline);

            return regexValue.Groups[1].Value.Trim();
        }
        public string getJsonResult(HotelViewModel model)
        {
            HotelViewModel hotelModel = new HotelViewModel();
            hotelModel.Name = model.Name;
            hotelModel.Address = model.Address;
            hotelModel.Stars = model.Stars;
            hotelModel.Review = model.Review;
            hotelModel.Score = model.Score;
            hotelModel.Description = model.Description;
            hotelModel.RoomCategories = model.RoomCategories;
            hotelModel.Alternative = model.Alternative;

            return JsonConvert.SerializeObject(hotelModel);
        }
    }
}