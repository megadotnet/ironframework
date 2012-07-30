// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TransactionScopeCallHandler.cs" company="Megaodnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   An <see cref="ICallHandler" /> that wraps the next handler with a TransactionScope
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IronFramework.Utility.PolicyInjection.CallHandlers
{
    using System.Transactions;

    using Microsoft.Practices.Unity.InterceptionExtension;

    /// <summary>
    /// An <see cref="ICallHandler"/> that wraps the next handler with a TransactionScope
    /// </summary>
    public class TransactionScopeCallHandler : ICallHandler
    {
        #region Constants and Fields

        /// <summary>
        /// The complete.
        /// </summary>
        private bool complete;

        /// <summary>
        /// The interop option.
        /// </summary>
        private EnterpriseServicesInteropOption interopOption;

        /// <summary>
        /// The transaction options.
        /// </summary>
        private TransactionOptions transactionOptions;

        /// <summary>
        /// The transaction scope option.
        /// </summary>
        private TransactionScopeOption transactionScopeOption;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionScopeCallHandler"/> class. 
        /// Creates a new <see cref="TransactionScopeCallHandler"/>.
        /// </summary>
        /// <param name="transactionScopeOption">
        /// An instance of the TransactionScopeOption enumeration that describes the transaction requirements associated with this transaction scope.
        /// </param>
        /// <param name="transactionOptions">
        /// A TransactionOptions structure that describes the transaction options to use if a new transaction is created. If an existing transaction is used, the timeout value in this parameter applies to the transaction scope. If that time expires before the scope is disposed, the transaction is aborted.
        /// </param>
        /// <param name="interopOption">
        /// An instance of the EnterpriseServicesInteropOption enumeration that describes how the associated transaction interacts with COM+ transactions.
        /// </param>
        /// <param name="complete">
        /// Whether the Transaction should be completed when the next handler executed without exceptions.
        /// </param>
        public TransactionScopeCallHandler(
            TransactionScopeOption transactionScopeOption, 
            TransactionOptions transactionOptions, 
            EnterpriseServicesInteropOption interopOption, 
            bool complete)
        {
            this.transactionScopeOption = transactionScopeOption;
            this.transactionOptions = transactionOptions;
            this.interopOption = interopOption;
            this.complete = complete;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionScopeCallHandler"/> class.
        /// </summary>
        /// <param name="transactionScopeOption">
        /// An instance of the TransactionScopeOption enumeration that describes the transaction requirements associated with this transaction scope.
        /// </param>
        /// <param name="transactionOptions">
        /// A TransactionOptions structure that describes the transaction options to use if a new transaction is created. If an existing transaction is used, the timeout value in this parameter applies to the transaction scope. If that time expires before the scope is disposed, the transaction is aborted.
        /// </param>
        /// <param name="interopOption">
        /// An instance of the EnterpriseServicesInteropOption enumeration that describes how the associated transaction interacts with COM+ transactions.
        /// </param>
        /// <param name="complete">
        /// Whether the Transaction should be completed when the next handler executed without exceptions.
        /// </param>
        /// <param name="order">
        /// Order in which handler will be executed.
        /// </param>
        public TransactionScopeCallHandler(
            TransactionScopeOption transactionScopeOption, 
            TransactionOptions transactionOptions, 
            EnterpriseServicesInteropOption interopOption, 
            bool complete, 
            int order)
            : this(transactionScopeOption, transactionOptions, interopOption, complete)
        {
            this.Order = order;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="TransactionScopeCallHandler"/> is complete.
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
        /// Gets or sets the enterprise services interop option.
        /// </summary>
        /// <value>The enterprise services interop option.</value>
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
        /// Order in which the handler will be executed
        /// </summary>
        /// <value></value>
        public int Order { get; set; }

        /// <summary>
        /// Gets or sets the transaction options.
        /// </summary>
        /// <value>The transaction options.</value>
        public TransactionOptions TransactionOptions
        {
            get
            {
                return this.transactionOptions;
            }

            set
            {
                this.transactionOptions = value;
            }
        }

        /// <summary>
        /// Gets or sets the transaction scope option.
        /// </summary>
        /// <value>The transaction scope option.</value>
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

        #region Implemented Interfaces

        #region ICallHandler

        /// <summary>
        /// Implement this method to execute your handler processing.
        /// </summary>
        /// <param name="input">
        /// Inputs to the current call to the target.
        /// </param>
        /// <param name="getNext">
        /// Delegate to execute to get the next delegate in the handler
        /// chain.
        /// </param>
        /// <returns>
        /// Return value from the target.
        /// </returns>
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            IMethodReturn result = null;

            using (TransactionScope scope = this.CreateTransactionScope())
            {
                result = getNext()(input, getNext);

                if (this.complete && result.Exception == null)
                {
                    scope.Complete();
                }
            }

            return result;
        }

        #endregion

        #endregion

        #region Methods

        /// <summary>
        /// Creates the transaction scope.
        /// </summary>
        /// <returns>
        /// </returns>
        protected virtual TransactionScope CreateTransactionScope()
        {
            if (this.interopOption == EnterpriseServicesInteropOption.None)
            {
                return new TransactionScope(this.transactionScopeOption, this.transactionOptions);
            }
            else
            {
                return new TransactionScope(this.transactionScopeOption, this.transactionOptions, this.interopOption);
            }
        }

        #endregion
    }
}