using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace Tms.Service.Common
{
    public class BaseService
    {
        public Tms.Data.AppContext.TMSContext Entity;
        #region Live
        public BaseService()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Tms.Data.AppContext.TMSContext>();
           

            if (Tms.Core.Constant.DB_Integrated_Security)
            {
                optionsBuilder.UseSqlServer("data source=" + Tms.Core.Constant.DB_SERVER + ";initial catalog=" + Tms.Core.Constant.DB_NAME + ";integrated security=" + Tms.Core.Constant.DB_Integrated_Security + ";MultipleActiveResultSets=True;App=EntityFramework");
            }
            else
            {
                optionsBuilder.UseSqlServer("data source=" + Tms.Core.Constant.DB_SERVER + ";initial catalog=" + Tms.Core.Constant.DB_NAME + ";User Id=" + Tms.Core.Constant.DB_UID + ";Password=" + Tms.Core.Constant.DB_PWD + ";MultipleActiveResultSets=True;App=EntityFramework");
            }

         
            Entity = new Tms.Data.AppContext.TMSContext(optionsBuilder.Options);
        }
        #endregion


    }
}
