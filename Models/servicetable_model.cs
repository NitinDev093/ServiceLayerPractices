using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceLayerPractices.Models
{
    public class servicetable_model
    {
        public int sr_no { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public string facemark { get; set; }

    }
    public class ResponseModel<T>
    {    //generic class
        public T Data { get; set; }
        public bool status { get; set; }
        public string message { get; set; }
    }


}