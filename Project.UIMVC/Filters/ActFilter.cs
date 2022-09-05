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
    public class ActFilter : FilterAttribute , IActionFilter
    {
        LogContext _db;

        public ActFilter()
        {
            _db = LogDBTool.DBInstance;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            DataLog logger = new DataLog();

            if (filterContext.HttpContext.Session["oturum"] == null) logger.UserName = "Anonim Kullanıcı";
            else logger.UserName = (filterContext.HttpContext.Session["oturum"] as LogAppUser).UserName;

            logger.UserName = filterContext.ActionDescriptor.ActionName;
            logger.ActionName = filterContext.ActionDescriptor.ActionName;
            logger.ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            logger.Information = "Action tetiklenme surecinde";

            logger.Description = Keyword.Entry;
            _db.DataLogs.Add(logger);
            _db.SaveChanges();
            

            

            
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            DataLog logger = new DataLog();

            if (filterContext.HttpContext.Session["oturum"] == null) logger.UserName = "Anonim Kullanıcı";
            else logger.UserName = (filterContext.HttpContext.Session["oturum"] as LogAppUser).UserName;

            logger.UserName = filterContext.ActionDescriptor.ActionName;
            logger.ActionName = filterContext.ActionDescriptor.ActionName;
            logger.ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            logger.Information = "Action calısması bitmistir";

            logger.Description = Keyword.Exit;
            _db.DataLogs.Add(logger);
            _db.SaveChanges();
        }

       
    }
}