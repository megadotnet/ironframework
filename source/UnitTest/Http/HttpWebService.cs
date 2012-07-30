#region BSD License
/* 
Copyright (c) 2010, NETFx
All rights reserved.

Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

* Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.

* Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.

* Neither the name of Clarius Consulting nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ApplicationServer.Http.Description;
using Microsoft.ApplicationServer.Http;
using Microsoft.ApplicationServer.Http.Activation;
using System.Net.Http;
using System.Collections.Concurrent;

namespace Microsoft.ApplicationServer.Http
{
	/// <summary>
	/// Factory class for HTTP web services.
	/// </summary>
	/// <remarks>
	/// If VS is run without elevated permissions, you need to run the 
	/// following command from an elevated command prompt ONCE for the 
	/// port you plan to use as the base Url:
	/// <code>
	/// netsh http add urlacl http://+:[port]/ user=[DOMAIN\USER]
	/// </code>
	/// </remarks>
	internal static partial class HttpWebService
	{
		/// <summary>
		/// Creates an HTTP web service using the given instance to run it, and the specified 
		/// service configuration.
		/// </summary>
		public static HttpWebService<TService> Create<TService>(TService serviceInstance, string serviceBaseUrl, string serviceResourcePath, HttpConfiguration serviceConfiguration = null)
			where TService : class
		{
			return new HttpWebService<TService>(serviceBaseUrl, serviceResourcePath, serviceConfiguration, serviceInstance);
		}
	}

	/// <summary>
	/// Instantiates the host for the given service, and closes it on Dispose.
	/// </summary>
	/// <remarks>
	/// If VS is run without elevated permissions, you need to run the 
	/// following command from an elevated command prompt ONCE for the 
	/// port you plan to use as the base Url:
	/// <code>
	/// netsh http add urlacl http://+:[port]/ user=[DOMAIN\USER]
	/// </code>
	/// </remarks>
	internal partial class HttpWebService<TService> : IDisposable
		where TService : class
	{
		private HttpServiceHost serviceHost;
		private Uri serviceUri;

		/// <summary>
		/// Initializes a new instance of the <see cref="HttpWebService&lt;TService&gt;"/> class.
		/// </summary>
		/// <param name="serviceBaseUrl">The service base URL without the resource path, such as "http://localhost:2000".</param>
		/// <param name="serviceResourcePath">The service resource path, such as "products".</param>
		/// <param name="serviceConfiguration">The configuration for the service.</param>
		/// <param name="cacheServiceInstance">Whether to cache the service instance created by the configured 
		/// resource factory across HTTP requests.</param>
		public HttpWebService(string serviceBaseUrl, string serviceResourcePath,
			bool cacheServiceInstance,
			HttpConfiguration serviceConfiguration = null)
			: this(serviceBaseUrl, serviceResourcePath, cacheServiceInstance, serviceConfiguration, null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="HttpWebService&lt;TService&gt;"/> class.
		/// </summary>
		/// <param name="serviceBaseUrl">The service base URL without the resource path, such as "http://localhost:2000".</param>
		/// <param name="serviceResourcePath">The service resource path, such as "products".</param>
		/// <param name="serviceConfiguration">The configuration for the service.</param>
		/// <param name="serviceInstance">The optional service instance. If not specified, the default resource factory 
		/// on the configuration will be invoked. Otherwise, a single-instance resource factory will be setup automatically 
		/// to return this instance to satisfy HTTP requests.</param>
		public HttpWebService(string serviceBaseUrl, string serviceResourcePath,
			HttpConfiguration serviceConfiguration = null,
			TService serviceInstance = null)
			: this(serviceBaseUrl, serviceResourcePath, false, serviceConfiguration, serviceInstance)
		{
		}

		private HttpWebService(
			string serviceBaseUrl,
			string serviceResourcePath,
			bool cacheServiceInstance,
			HttpConfiguration serviceConfiguration,
			TService serviceInstance)
		{
			this.BaseUri = new Uri(serviceBaseUrl);
			this.serviceUri = new Uri(new Uri(serviceBaseUrl), serviceResourcePath);

            if (serviceConfiguration == null)
                serviceConfiguration = serviceConfiguration;

            //if (serviceInstance != null)
            //    serviceConfiguration.SetResourceFactory(new SingletonResourceFactory(serviceInstance));
            //else if (cacheServiceInstance)
            //    serviceConfiguration.SetResourceFactory(new CachingResourceFactory(serviceConfiguration.Configuration.InstanceFactory ?? new ActivatorResourceFactory()));

			this.serviceHost = new HttpServiceHost(typeof(TService), serviceConfiguration, this.serviceUri);
			this.serviceHost.Open();
		}

		public Uri BaseUri { get; private set; }

		public Uri Uri(object id)
		{
			return this.Uri(id.ToString());
		}

		public Uri Uri(string relativeUri)
		{
			return new Uri(this.serviceUri + "/" + relativeUri);
		}

		public void Dispose()
		{
			this.serviceHost.Close();
		}
	}
}