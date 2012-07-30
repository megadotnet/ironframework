// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CyclicReferencesAwareContractBehavior.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   CyclicReferencesAwareContractBehavior and ApplyCyclicDataContractSerializerOperationBehavior and
//   CyclicReferencesAwareAttribute 
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IronFramework.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;
    using System.Xml;

    /// <summary>
    /// WCF DataContract serializer isn't by default aware of cyclic object graphs. 
    /// If you encounter the Object graph for type 'X.Y.Z' contains cycles and cannot be serialized
    /// if reference tracking is disabled error - read to the end. 
    /// <seealso cref="http://chabster.blogspot.com/2008/02/wcf-cyclic-references-support.html"/>
    /// <seealso cref="http://devblog.petrellyn.com/?p=278"/>
    /// </summary>
    public class CyclicReferencesAwareContractBehavior : IContractBehavior
    {
        #region Constants and Fields

        /// <summary>
        /// The ignore extension data object.
        /// </summary>
        private const bool ignoreExtensionDataObject = false;

        /// <summary>
        /// The max items in object graph 
        /// The value of this constant is 2,147,483,647
        /// </summary>
        /// <seealso cref="http://msdn.microsoft.com/en-us/library/system.int32.maxvalue(v=vs.85).aspx"/>
        private const int maxItemsInObjectGraph = 0x7FFFFFFF;

        /// <summary>
        /// The _on.
        /// </summary>
        private readonly bool _on;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CyclicReferencesAwareContractBehavior"/> class.
        /// </summary>
        /// <param name="on">
        /// The on.
        /// </param>
        public CyclicReferencesAwareContractBehavior(bool on)
        {
            this._on = on;
        }

        #endregion

        #region Implemented Interfaces

        #region IContractBehavior

        /// <summary>
        /// The add binding parameters.
        /// </summary>
        /// <param name="contractDescription">
        /// The contract description.
        /// </param>
        /// <param name="endpoint">
        /// The endpoint.
        /// </param>
        /// <param name="bindingParameters">
        /// The binding parameters.
        /// </param>
        public void AddBindingParameters(
            ContractDescription contractDescription, 
            ServiceEndpoint endpoint, 
            BindingParameterCollection bindingParameters)
        {
        }

        /// <summary>
        /// The apply client behavior.
        /// </summary>
        /// <param name="contractDescription">
        /// The contract description.
        /// </param>
        /// <param name="endpoint">
        /// The endpoint.
        /// </param>
        /// <param name="clientRuntime">
        /// The client runtime.
        /// </param>
        public void ApplyClientBehavior(
            ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            ReplaceDataContractSerializerOperationBehaviors(contractDescription, this._on);
        }

        /// <summary>
        /// The apply dispatch behavior.
        /// </summary>
        /// <param name="contractDescription">
        /// The contract description.
        /// </param>
        /// <param name="endpoint">
        /// The endpoint.
        /// </param>
        /// <param name="dispatchRuntime">
        /// The dispatch runtime.
        /// </param>
        public void ApplyDispatchBehavior(
            ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        {
            ReplaceDataContractSerializerOperationBehaviors(contractDescription, this._on);
        }

        /// <summary>
        /// The validate.
        /// </summary>
        /// <param name="contractDescription">
        /// The contract description.
        /// </param>
        /// <param name="endpoint">
        /// The endpoint.
        /// </param>
        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
        }

        #endregion

        #endregion

        #region Methods

        /// <summary>
        /// The replace data contract serializer operation behavior.
        /// </summary>
        /// <param name="operation">
        /// The operation.
        /// </param>
        /// <param name="on">
        /// The on.
        /// </param>
        internal static void ReplaceDataContractSerializerOperationBehavior(OperationDescription operation, bool on)
        {
            if (operation.Behaviors.Remove(typeof(DataContractSerializerOperationBehavior))
                || operation.Behaviors.Remove(typeof(ApplyCyclicDataContractSerializerOperationBehavior)))
            {
                operation.Behaviors.Add(
                    new ApplyCyclicDataContractSerializerOperationBehavior(
                        operation, maxItemsInObjectGraph, ignoreExtensionDataObject, on));
            }
        }

        /// <summary>
        /// The replace data contract serializer operation behaviors.
        /// </summary>
        /// <param name="contractDescription">
        /// The contract description.
        /// </param>
        /// <param name="on">
        /// The on.
        /// </param>
        internal static void ReplaceDataContractSerializerOperationBehaviors(
            ContractDescription contractDescription, bool on)
        {
            foreach (OperationDescription operation in contractDescription.Operations)
            {
                ReplaceDataContractSerializerOperationBehavior(operation, on);
            }
        }

        #endregion
    }

    /// <summary>
    /// The cyclic references aware attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Method)]
    public class CyclicReferencesAwareAttribute : Attribute, IContractBehavior, IOperationBehavior
    {
        #region Constants and Fields

        /// <summary>
        /// The _on.
        /// </summary>
        private readonly bool _on = true;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CyclicReferencesAwareAttribute"/> class.
        /// </summary>
        /// <param name="on">
        /// The on.
        /// </param>
        public CyclicReferencesAwareAttribute(bool on)
        {
            this._on = on;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether On.
        /// </summary>
        public bool On
        {
            get
            {
                return this._on;
            }
        }

        #endregion

        #region Implemented Interfaces

        #region IContractBehavior

        /// <summary>
        /// The add binding parameters.
        /// </summary>
        /// <param name="contractDescription">
        /// The contract description.
        /// </param>
        /// <param name="endpoint">
        /// The endpoint.
        /// </param>
        /// <param name="bindingParameters">
        /// The binding parameters.
        /// </param>
        void IContractBehavior.AddBindingParameters(
            ContractDescription contractDescription, 
            ServiceEndpoint endpoint, 
            BindingParameterCollection bindingParameters)
        {
        }

        /// <summary>
        /// The apply client behavior.
        /// </summary>
        /// <param name="contractDescription">
        /// The contract description.
        /// </param>
        /// <param name="endpoint">
        /// The endpoint.
        /// </param>
        /// <param name="clientRuntime">
        /// The client runtime.
        /// </param>
        void IContractBehavior.ApplyClientBehavior(
            ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            CyclicReferencesAwareContractBehavior.ReplaceDataContractSerializerOperationBehaviors(
                contractDescription, this.On);
        }

        /// <summary>
        /// The apply dispatch behavior.
        /// </summary>
        /// <param name="contractDescription">
        /// The contract description.
        /// </param>
        /// <param name="endpoint">
        /// The endpoint.
        /// </param>
        /// <param name="dispatchRuntime">
        /// The dispatch runtime.
        /// </param>
        void IContractBehavior.ApplyDispatchBehavior(
            ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        {
            CyclicReferencesAwareContractBehavior.ReplaceDataContractSerializerOperationBehaviors(
                contractDescription, this.On);
        }

        /// <summary>
        /// The validate.
        /// </summary>
        /// <param name="contractDescription">
        /// The contract description.
        /// </param>
        /// <param name="endpoint">
        /// The endpoint.
        /// </param>
        void IContractBehavior.Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
        }

        #endregion

        #region IOperationBehavior

        /// <summary>
        /// The add binding parameters.
        /// </summary>
        /// <param name="operationDescription">
        /// The operation description.
        /// </param>
        /// <param name="bindingParameters">
        /// The binding parameters.
        /// </param>
        void IOperationBehavior.AddBindingParameters(
            OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {
        }

        /// <summary>
        /// The apply client behavior.
        /// </summary>
        /// <param name="operationDescription">
        /// The operation description.
        /// </param>
        /// <param name="clientOperation">
        /// The client operation.
        /// </param>
        void IOperationBehavior.ApplyClientBehavior(
            OperationDescription operationDescription, ClientOperation clientOperation)
        {
            CyclicReferencesAwareContractBehavior.ReplaceDataContractSerializerOperationBehavior(
                operationDescription, this.On);
        }

        /// <summary>
        /// The apply dispatch behavior.
        /// </summary>
        /// <param name="operationDescription">
        /// The operation description.
        /// </param>
        /// <param name="dispatchOperation">
        /// The dispatch operation.
        /// </param>
        void IOperationBehavior.ApplyDispatchBehavior(
            OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            CyclicReferencesAwareContractBehavior.ReplaceDataContractSerializerOperationBehavior(
                operationDescription, this.On);
        }

        /// <summary>
        /// The validate.
        /// </summary>
        /// <param name="operationDescription">
        /// The operation description.
        /// </param>
        void IOperationBehavior.Validate(OperationDescription operationDescription)
        {
        }

        #endregion

        #endregion
    }

    /// <summary>
    /// The apply cyclic data contract serializer operation behavior.
    /// </summary>
    internal class ApplyCyclicDataContractSerializerOperationBehavior : DataContractSerializerOperationBehavior
    {
        #region Constants and Fields

        /// <summary>
        /// The _ignore extension data object.
        /// </summary>
        private readonly bool _ignoreExtensionDataObject;

        /// <summary>
        /// The _max items in object graph.
        /// </summary>
        private readonly int _maxItemsInObjectGraph;

        /// <summary>
        /// The _preserve object references.
        /// </summary>
        private readonly bool _preserveObjectReferences;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplyCyclicDataContractSerializerOperationBehavior"/> class.
        /// </summary>
        /// <param name="operationDescription">
        /// The operation description.
        /// </param>
        /// <param name="maxItemsInObjectGraph">
        /// The max items in object graph.
        /// </param>
        /// <param name="ignoreExtensionDataObject">
        /// The ignore extension data object.
        /// </param>
        /// <param name="preserveObjectReferences">
        /// The preserve object references.
        /// </param>
        public ApplyCyclicDataContractSerializerOperationBehavior(
            OperationDescription operationDescription, 
            int maxItemsInObjectGraph, 
            bool ignoreExtensionDataObject, 
            bool preserveObjectReferences)
            : base(operationDescription)
        {
            this._maxItemsInObjectGraph = maxItemsInObjectGraph;
            this._ignoreExtensionDataObject = ignoreExtensionDataObject;
            this._preserveObjectReferences = preserveObjectReferences;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The create serializer.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="ns">
        /// The ns.
        /// </param>
        /// <param name="knownTypes">
        /// The known types.
        /// </param>
        /// <returns>
        /// </returns>
        public override XmlObjectSerializer CreateSerializer(Type type, string name, string ns, IList<Type> knownTypes)
        {
            return
                new DataContractSerializer(
                    type, 
                    name, 
                    ns, 
                    knownTypes, 
                    this._maxItemsInObjectGraph, 
                    this._ignoreExtensionDataObject, 
                    this._preserveObjectReferences, 
                    null /*dataContractSurrogate*/);
        }

        /// <summary>
        /// The create serializer.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="ns">
        /// The ns.
        /// </param>
        /// <param name="knownTypes">
        /// The known types.
        /// </param>
        /// <returns>
        /// </returns>
        public override XmlObjectSerializer CreateSerializer(
            Type type, XmlDictionaryString name, XmlDictionaryString ns, IList<Type> knownTypes)
        {
            return
                new DataContractSerializer(
                    type, 
                    name, 
                    ns, 
                    knownTypes, 
                    this._maxItemsInObjectGraph, 
                    this._ignoreExtensionDataObject, 
                    this._preserveObjectReferences, 
                    null /*dataContractSurrogate*/);
        }

        #endregion
    }
}