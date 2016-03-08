using AppEstimator.Common;
using AppEstimator.Common.TypeMapping;
using AppEstimator.Data.QueryProcessors;
using AppEstimator.Web.Api.LinkServices;
using AppEstimator.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace AppEstimator.Web.Api.MaintenanceProcessing
{
    public class AddUserMaintenanceProcessor : IAddUserMaintenanceProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly IAddUserQueryProcessor _queryProcessor;

        public AddUserMaintenanceProcessor(IAddUserQueryProcessor queryProcessor, IAutoMapper autoMapper)
        {
            _queryProcessor = queryProcessor;
            _autoMapper = autoMapper;
        }

        public Models.AppUser AddUser(Models.NewAppUser newUser)
        {
            var newUserEntity = _autoMapper.Map<Data.Entities.AppUser>(newUser);

            var persistedUserEntity = _queryProcessor.AddUser(newUserEntity);

            var userModel = _autoMapper.Map<Models.AppUser>(persistedUserEntity);

            // TODO: Implement link service... Like:
            //_estimateLinkService.AddSelfLink(estimate);
            //_estimateLinkService.AddLinksToChildObjects(estimate);

            return userModel;
        }
    }
}