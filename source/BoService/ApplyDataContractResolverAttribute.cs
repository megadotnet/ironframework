// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplyDataContractResolverAttribute.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   http://msdn.microsoft.com/en-us/library/ee705457.aspx
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BoService
{
    using System;
    using System.Data.Entity.Core.Objects;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;

    /// <summary>
    /// http://msdn.microsoft.com/en-us/library/ee705457.aspx
    /// </summary>
    public class ApplyDataContractResolverAttribute : Attribute, IOperationBehavior
    {
        #region Implemented Interfaces

        #region IOperationBehavior

        /// <summary>
        /// The add binding parameters.
        /// </summary>
        /// <param name="description">
        /// The description.
        /// </param>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        public void AddBindingParameters(OperationDescription description, BindingParameterCollection parameters)
        {
        }

        /// <summary>
        /// The apply client behavior.
        /// </summary>
        /// <param name="description">
        /// The description.
        /// </param>
        /// <param name="proxy">
        /// The proxy.
        /// </param>
        public void ApplyClientBehavior(OperationDescription description, ClientOperation proxy)
        {
            var dataContractSerializerOperationBehavior =
                description.Behaviors.Find<DataContractSerializerOperationBehavior>();
            dataContractSerializerOperationBehavior.DataContractResolver = new ProxyDataContractResolver();
        }

        /// <summary>
        /// The apply dispatch behavior.
        /// </summary>
        /// <param name="description">
        /// The description.
        /// </param>
        /// <param name="dispatch">
        /// The dispatch.
        /// </param>
        public void ApplyDispatchBehavior(OperationDescription description, DispatchOperation dispatch)
        {
            var dataContractSerializerOperationBehavior =
                description.Behaviors.Find<DataContractSerializerOperationBehavior>();
            dataContractSerializerOperationBehavior.DataContractResolver = new ProxyDataContractResolver();
        }

        /// <summary>
        /// The validate.
        /// </summary>
        /// <param name="description">
        /// The description.
        /// </param>
        public void Validate(OperationDescription description)
        {
            // Do validation.
        }

        #endregion

        #endregion
    }
}