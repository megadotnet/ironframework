// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TransactionScopeCallHandlerAttribute.cs" company="Megadotent">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   An attribute used to apply the <see cref="TransactionScopeCallHandler" /> to the target.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IronFramework.Utility.PolicyInjection.CallHandlers
{
    using System;
    using System.ComponentModel;
    using System.Transactions;

    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.InterceptionExtension;

    /// <summary>
    /// An attribute used to apply the <see cref="TransactionScopeCallHandler"/> to the target.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class TransactionScopeCallHandlerAttribute : HandlerAttribute
    {
        #region Constants and Fields

        /// <summary>
        /// The time span converter.
        /// </summary>
        private static readonly TimeSpanConverter timeSpanConverter = new TimeSpanConverter();

        /// <summary>
        /// The complete.
        /// </summary>
        private bool complete = true;

        /// <summary>
        /// The interop option.
        /// </summary>
        private EnterpriseServicesInteropOption interopOption = EnterpriseServicesInteropOption.None;

        /// <summary>
        /// The isolation level.
        /// </summary>
        private IsolationLevel isolationLevel = IsolationLevel.Serializable;

        /// <summary>
        /// The timeout.
        /// </summary>
        private TimeSpan timeout = TimeSpan.FromMinutes(1);

        /// <summary>
        /// The transaction scope option.
        /// </summary>
        private TransactionScopeOption transactionScopeOption = TransactionScopeOption.Required;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets whether the handler will complete the TransactionScope on success.
        /// </summary>
        /// <value><c>true</c> if complete; otherwise, <c>false</c>.</value>
        public bool Complete
        {
            get
            {
                return this.complete;
            }

            set
            {
                this.complete = value;
            }
        }

        /// <summary>
        /// Gets or sets the Interop Option used by the handler.
        /// </summary>
        /// <value>Interop Option.</value>
        public EnterpriseServicesInteropOption InteropOption
        {
            get
            {
                return this.interopOption;
            }

            set
            {
                this.interopOption = value;
            }
        }

        /// <summary>
        /// Gets or sets the Isolation Level used by the handler.
        /// </summary>
        /// <value>Scope Option.</value>
        public IsolationLevel IsolationLevel
        {
            get
            {
                return this.isolationLevel;
            }

            set
            {
                this.isolationLevel = value;
            }
        }

        /// <summary>
        /// Gets the timeout.
        /// </summary>
        /// <value>The timeout.</value>
        public TimeSpan Timeout
        {
            get
            {
                return this.timeout;
            }
        }

        /// <summary>
        /// Gets or sets the timeout string.
        /// </summary>
        /// <value>The timeout string.</value>
        public string TimeoutString
        {
            get
            {
                return timeSpanConverter.ConvertToString(this.timeout);
            }

            set
            {
                this.timeout = (TimeSpan)timeSpanConverter.ConvertFromString(value);
            }
        }

        /// <summary>
        /// Gets or sets the Transaction Scope Option used by the handler.
        /// </summary>
        /// <value>Transaction Scope Option.</value>
        public TransactionScopeOption TransactionScopeOption
        {
            get
            {
                return this.transactionScopeOption;
            }

            set
            {
                this.transactionScopeOption = value;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Derived classes implement this method. When called, it
        /// creates a new call handler as specified in the attribute
        /// configuration.
        /// </summary>
        /// <param name="container">
        /// The <see cref="T:Microsoft.Practices.Unity.IUnityContainer"/> to use when creating handlers,
        /// if necessary.
        /// </param>
        /// <returns>
        /// A new call handler object.
        /// </returns>
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            var transactionOptions = new TransactionOptions();
            transactionOptions.Timeout = this.Timeout;
            transactionOptions.IsolationLevel = this.IsolationLevel;
            return new TransactionScopeCallHandler(
                this.TransactionScopeOption, transactionOptions, this.InteropOption, this.Complete, this.Order);
        }

        #endregion
    }
}