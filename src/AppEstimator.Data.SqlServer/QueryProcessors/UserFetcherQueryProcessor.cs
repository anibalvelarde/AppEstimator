using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppEstimator.Data.QueryProcessors;
using NHibernate;
using NHibernate.Transform;

namespace AppEstimator.Data.SqlServer.QueryProcessors
{
    public class UserFetcherQueryProcessor : IUserFetcherQueryProcessor
    {
        private readonly ISession _session;

        public UserFetcherQueryProcessor(ISession session)
        {
            _session = session;
        }

        public Entities.AppUser GetUserById(long userId)
        {
            var user = _session.Get<Entities.AppUser>(userId);
            return user;
        }

        public IList<EntityViews.AppUserInfo> GetUsers()
        {
            IList<EntityViews.AppUserInfo> userList = _session.QueryOver<EntityViews.AppUserInfo>()
                            .OrderBy(x => x.Name).Asc
                            .TransformUsing(Transformers.RootEntity)
                            .List<EntityViews.AppUserInfo>();
            return userList;
        }

        public IList<Entities.AppUser> GetUsersByName(string userName)
        {
            var userNameFilter = string.Format("%{0}%",userName);
            IList<Entities.AppUser> userList = _session.QueryOver<Entities.AppUser>()
                            .Where(new NHibernate.Criterion.LikeExpression("Name",userNameFilter))
                            .OrderBy(x => x.Name).Asc
                            .TransformUsing(Transformers.RootEntity)
                            .List<Entities.AppUser>();
            return userList;
        }
    }
}
