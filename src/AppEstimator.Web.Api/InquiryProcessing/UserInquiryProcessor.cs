using AppEstimator.Common.TypeMapping;
using AppEstimator.Data.Exceptions;
using AppEstimator;
using AppEstimator.Data.QueryProcessors;
using AppEstimator.Web.Api.Calculators;
using AppEstimator.Web.Api.LinkServices;
using AppEstimator.Web.Api.Models;
using AppEstimator.Web.Common.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppEstimator.Web.Api.InquiryProcessing
{
    public class UserInquiryProcessor : IUserInquiryProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly IUserFetcherQueryProcessor _queryProcessor;
        private readonly IWebUserSession _webUserSession;
        private readonly IAppUserLinkService _linkService;

        public UserInquiryProcessor(IAutoMapper autoMapper, IUserFetcherQueryProcessor queryProcessor,
                                    IWebUserSession userSession, IAppUserLinkService appUserLinkSvc)
        {
            _autoMapper = autoMapper;
            _queryProcessor = queryProcessor;
            _webUserSession = userSession;
            _linkService = appUserLinkSvc;
        }

        public Models.AppUser GetUserById(long userId)
        {
            var userEntity = _queryProcessor.GetUserById(userId);
            if(userEntity == null)
            {
                throw new RootObjectNotFoundException("User not found");
            }

            var userModel = _autoMapper.Map<Models.AppUser>(userEntity);
            this.ManageHttpLinks(userModel);
            return userModel;
        }

        public IList<Models.AppUser> GetUsersByName(string name)
        {
            var usersEntity = _queryProcessor.GetUsersByName(name);
            if(usersEntity == null)
            {
                throw new RootObjectNotFoundException(string.Format("User with name like '{0}' was not found",name));
            }

            var usersModel = new List<Models.AppUser>();

            foreach (var userEntity in usersEntity)
            {
                var userModel = _autoMapper.Map<Models.AppUser>(userEntity);
                usersModel.Add(userModel);
            }            
            return usersModel;
        }

        public IList<Models.AppUserInfo> GetUsers()
        {
            var userEntities = _queryProcessor.GetUsers();
            if(userEntities == null)
            {
                throw new RootObjectNotFoundException("No users are defined");
            }

            IList<Models.AppUserInfo> userModels = new List<Models.AppUserInfo>();
            foreach (Data.EntityViews.AppUserInfo userEntity in userEntities)
            {
                Models.AppUserInfo userInfoModel = _autoMapper.Map<Models.AppUserInfo>(userEntity);
                this.ManageHttpLinks(userInfoModel);
                userModels.Add(userInfoModel);
            }
            return userModels;
        }

        private void ManageHttpLinks(Models.AppUser userModel)
        {
            _linkService.AddSelfLink(userModel);
            _linkService.AddEstimatesLink(userModel);
        }

        private void ManageHttpLinks(Models.AppUserInfo userModel)
        {
            _linkService.AddSelfLink(userModel);
        }
    }
}