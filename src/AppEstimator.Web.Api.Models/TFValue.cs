﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Web.Api.Models
{
    public class TFValue
    {

        private List<Link> _links;
        public TFInfo TechnicalFactorInfo { get; set; }
        public int Value { get; set; }
        public List<Link> Links
        {
            get { return _links ?? (_links = new List<Link>()); }
            set { _links = value; }
        }
        public void AddLink(Link link)
        {
            this.Links.Add(link);
        }
    }
}
