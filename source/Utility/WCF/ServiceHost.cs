// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceHost.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   ServiceHost helper class
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace IronFramework.Utility.WCF
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using System.ServiceModel.Channels;

    /// <summary>
    /// ServiceHost<C, I>
    /// </summary>
    /// <typeparam name="C"></typeparam>
    /// <typeparam name="I"></typeparam>
    public class ServiceHost<C, I> : ServiceHost
    {
        /// <summary>
        /// Gets or sets the contact.
        /// </summary>
        /// <value>The contact.</value>
        public C Contract { get; set; }

        /// <summary>
        /// myChannelFactory
        /// </summary>
        private ChannelFactory<C> myChannelFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceHost&lt;C, I&gt;"/> class.
        /// </summary>
        /// <param name="uris">The uris.</param>
        public ServiceHost(params Uri[] uris)
            : this(null, new BasicHttpBinding(), uris)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceHost&lt;C, I&gt;"/> class.
        /// </summary>
        /// <param name="behaviors">The behaviors.</param>
        /// <param name="binding">The binding.</param>
        /// <param name="uris">The uris.</param>
        public ServiceHost(IEnumerable<IEndpointBehavior> behaviors, Binding binding, params Uri[] uris)
            : base(typeof(I), uris)
        {
            var myEndpoint = new EndpointAddress(uris.SingleOrDefault());
            myChannelFactory = new ChannelFactory<C>(binding, myEndpoint);

            if (behaviors != null)
            {
                behaviors.ToList().ForEach(b =>
                {
                    myChannelFactory.Endpoint.Behaviors.Add(b);
                    this.AddServiceEndpoint(typeof(C), binding, "").Behaviors.Add(b);
                });
            }

            Contract = myChannelFactory.CreateChannel();
        }

        /// <summary>
        /// Disposes of disposable services that are being hosted when the service host is closed.
        /// </summary>
        protected override void OnClosed()
        {
            base.OnClosed();
            myChannelFactory.Close();
        }
    }
}
