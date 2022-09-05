using Project.BLL.DesingPatterns.SingletonPattern;
using Project.DAL.LogContext;
using Project.ENTITES.Enums;
using Project.ENTITES.LogEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.UIMVC.Filters
{
    public class ResFilter : FilterAttribute , IResultFilter
    {
        LogContext _db;

        public ResFilter()
        {
            _db = LogDBTool.DBInstance;
        }
        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            DataLog logger = new DataLog();

            if (filterContext.HttpContext.Session["oturum"] != null) logger.UserName = (filterContext.HttpContext.Session["oturum"] as LogAppUser).UserName;
            else logger.UserName = "Anonim kullanıcı";
            
            logger.ActionName = filterContext.RouteData.Values["Action"].ToString();

            logger.ControllerName = filterContext.RouteData.Values["Controller"].ToString();

            logger.Description = Keyword.Entry;

            _db.DataLogs.Add(logger);
            _db.SaveChanges();

            
        }
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            DataLog logger = new DataLog();

            if (filterContext.HttpContext.Session["oturum"] != null) logger.UserName = (filterContext.HttpContext.Session["oturum"] as LogAppUser).UserName;
            else logger.UserName = "Anonim kullanıcı";

            logger.ActionName = filterContext.RouteData.Values["Action"].ToString();
            logger.ControllerName = filterContext.RouteData.Values["Controller"].ToString();
            logger.Description = Keyword.Exit;
            logger.Information = "Sayfa render edildi";
            _db.DataLogs.Add(logger);
            _db.SaveChanges();
        }

      
    }
}