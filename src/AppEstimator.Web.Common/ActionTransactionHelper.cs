﻿using NHibernate;
using NHibernate.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Web.Common
{
    public class ActionTransactionHelper : IActionTransactionHelper
    {
        private readonly ISessionFactory _sessionFactory;

        public ActionTransactionHelper(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public bool TransactionHandled { get; private set; }

        public bool SessionClosed { get; private set; }


        public void BeginTransaction()
        {
            if (!CurrentSessionContext.HasBind(_sessionFactory)) return;

            var session = _sessionFactory.GetCurrentSession();
            if(session != null)
            {
                session.BeginTransaction();
            }
        }

        public void EndTransaction(System.Web.Http.Filters.HttpActionExecutedContext filterContext)
        {
            if (!CurrentSessionContext.HasBind(_sessionFactory)) return;

            var session = _sessionFactory.GetCurrentSession();

            if(session == null)
            {
                return;
            }
            else 
            {
                if (!session.Transaction.IsActive)
                {
                    return;
                }
                if (filterContext.Exception == null)
                {
                    session.Flush();
                    session.Transaction.Commit();
                }
                else
                {
                    session.Transaction.Rollback();
                }                
            }
            TransactionHandled = true;
        }

        public void CloseSession()
        {
            if (!CurrentSessionContext.HasBind(_sessionFactory)) return;

            var session = _sessionFactory.GetCurrentSession();
            if(session == null)
            {
                return;
            }
            else
            {
                session.Close();
                session.Dispose();
                CurrentSessionContext.Unbind(_sessionFactory);
                SessionClosed = true;
            }
        }
    }
}
