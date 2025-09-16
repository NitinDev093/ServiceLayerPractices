using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceLayerPractices.Models
{
    public class CountryModel
    {
        public int countryid { get; set; }
        public string countryname { get; set; }
        public string statename { get; set; }
        public int statecount { get; set; }

    }
}