using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Common
{
    public static class Constants
    {
        public static class MediaTypeNames
        {
            public const string ApplicationXml = "application/xml";
            public const string TextXml = "text/xml";
            public const string ApplicationJson = "text/json";
            public const string TextJson = "text/json";
        }

        public static class Paging
        {
            public const int MinPageSize = 1;
            public const int MinPageNumber = 1;
            public const int DefaultPageNumber = 1;
        }

        public static class CommonParameterNames
        {
            public const string PageNumber = "pageNumber";
            public const string PageSize = "pageSize";
        }

        public static class CommonLinkRelvalues
        {
            public const string Self = "self";
            public const string All = "all";
            public const string CurrentPage = "currentPage";
            public const string PreviousPage = "previousPage";
            public const string NextPage = "nextPage";
        }

        public static class CommonRoutingDefinitions
        {
            public const string ApiSegmentName = "api";
            public const string ApiVersionSegmentName = "apiVersion";
            public const string CurrentApiVersion = "v1";
        }

        public static class SchemeTypes
        {
            public const string Basic = "basic";
        }

        public static class RoleNames
        {
            public const string Administrator = "Admin";
            public const string User = "user";
            public const string VipUser = "vip";
        }

        public static class AppEstimatorClaimTypes
        {
            public const string UserIdentifier = "AppEstimator-UserId";
        }

        public static class UseCasePointAnalysisTheoryConstants
        {
            public const decimal TechnicalComplexityBaseLine = 0.6M;
            public const decimal EnvironmentalComplexityBaseLine = 1.4M;
            public const decimal EnvironmentalComplexityMagnitude = 0.3M;
            public const int MaxHoursPerUseCasePoint = 28;
            public const int MinHoursPerUseCasePoint = 23;
        }

        public const string DefaultLegacyNamespace = "http://tempuri.org/";
    }
}
