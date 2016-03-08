using AppEstimator.Common;
using AppEstimator.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppEstimator.Web.Api.MaintenanceProcessing
{
    public static class LocationLinkCalculator
    {
        public static Uri GetLocationLink(IContainLinks linkContaining)
        {
            var locationLink = linkContaining.Links
                .FirstOrDefault( x => x.Rel == Constants.CommonLinkRelvalues.Self);
            return locationLink == null ? null : new Uri(locationLink.Href);
        }
    }
}