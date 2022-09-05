using Project.DAL.LogContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesingPatterns.SingletonPattern
{
    public class LogDBTool
    {
         LogDBTool()
        {

        }

        static LogContext _dbInstance;

        public static LogContext DBInstance
        {
            get
            {
                if (_dbInstance == null) _dbInstance = new LogContext();
                return _dbInstance;
            }
        }
    }
}
