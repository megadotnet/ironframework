using DataAccessObject;
//------------------------------------------------------------------------------
// <copyright file="WebDataService.svc.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Data.Services.Providers;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;

namespace ODataService
{
    /// <summary>
    /// ODataService with EF6 
    /// </summary>
    /// <see cref="http://blogs.msdn.com/b/odatateam/archive/2013/10/02/using-wcf-data-services-5-6-0-with-entity-framework-6.aspx"/>
    /// <seealso cref="http://www.asp.net/web-api/overview/odata-support-in-aspnet-web-api/odata-v3/creating-an-odata-endpoint"/>
    /// <seealso cref="http://www.odata.org/getting-started/basic-tutorial/"/>
    /// <seealso cref="https://odata.codeplex.com/"/>
    /// <seealso cref="http://blogs.msdn.com/b/odatateam/archive/2014/08/01/announcement-odatalib-6-6-0-release.aspx"/>
    public class ODataService : EntityFrameworkDataService<AdventureWorksEntities>
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
           
            config.SetEntitySetAccessRule("*", EntitySetRights.AllRead);
            config.SetServiceOperationAccessRule("*", ServiceOperationRights.All);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
        }
    }
}
