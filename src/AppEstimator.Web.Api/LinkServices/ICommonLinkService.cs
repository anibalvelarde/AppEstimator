using AppEstimator.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Web.Api.LinkServices
{
    public interface ICommonLinkService
    {
        // TODO: need to create the IPageLinkContaining interface
        void AddPageLinks(object linkContainer,
            string currentPageQueryString,
            string previousPageQueryString,
            string nextPageQueryString);

        Link GetLink(string pathFragment, string relValue, HttpMethod httpMethod);
    }
}
