// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddressBO.cs" company="Megadotnet">
// Copyright (c) 2010-2014 Peter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The AddressBo
//   This file is auto generated and will be overwritten as soon as the template is executed
//   Do not modify this file...
// </summary>
// --------------------------------------------------------------------------------------------------------------------	
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using BusinessEntiies;
using DataAccessObject;
using IronFramework.Utility;
using IronFramework.Utility.UI;
using IronFramework.Utility.EntityFramewrok;

namespace BusinessObject
{   
    /// <summary>
    /// Address Business object, rules etc.
    /// </summary>
	public class AddressBO : IAddressBO
	{
        /// <summary>
        /// The type adapter
        /// </summary>
        private ITypeAdapter typeAdapter = new TypeAdapter();
        /// <summary>
        /// The dbcontext
        /// </summary>
        private IObjectContext context;
        /// <summary>
        /// The unit of work interface
        /// </summary>
        private IUnitOfWork uow;
        /// <summary>
        /// The Address repository
        /// </summary>
        private AddressRepository entiesrepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressBusniessLogicObject"/> class.
        /// </summary>
        public AddressBO()
        {
            context = RepositoryHelper.GetDbContext();
            uow = RepositoryHelper.GetUnitOfWork(context);
            this.entiesrepository = RepositoryHelper.GetAddressRepository(context);
        }

        /// <summary>
        /// FindEnties 
        /// </summary>
        /// <param name="pageIndex">pageIndex</param>
        /// <param name="pageSize">pageSize</param>
        /// <returns>Enties</returns>
        public PagedList<AddressDto> FindEnties(int? pageIndex, int pageSize)
        {
            var entities=entiesrepository.Repository.Find(p => p.AddressID>0, p => p.AddressID, pageIndex, pageSize);
            var listDtos=new PagedList<AddressDto>() { TotalCount = entities.TotalCount };
             entities.ForEach(entity => { listDtos.Add(typeAdapter.Transform<Address, AddressDto>(entity)); });
             return listDtos;
        }


        /// <summary>
        /// Converts the toui model.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        private EasyuiDatagridData<UIT> ConvertTOUIModel<UIT, DBT>(PagedList<DBT> entities)
        {
            var listDtos = new EasyuiDatagridData<UIT>() { total = entities.TotalCount };
            var lists = new List<UIT>();
            entities.ForEach(entity => { lists.Add(typeAdapter.Transform<DBT, UIT>(entity)); });
            listDtos.rows = lists.ToArray();
            return listDtos;
        }

        /// <summary>
        /// Finds the enties.
        /// </summary>
        /// <param name="Address">The Address dto.</param>
        /// <returns></returns>
        public EasyuiDatagridData<AddressDto> FindEnties(AddressDto  _addressDto)
        {
            var entities = entiesrepository.Repository.Find(p => p.AddressID > 0, p => p.AddressID, _addressDto.pageIndex, _addressDto.pageSize);
            var listDtos = ConvertTOUIModel<AddressDto,Address>(entities);
            return listDtos;
        }


        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="_AddressDto">The Addressdto.</param>
        /// <returns></returns>
        public EasyuiDatagridData<AddressDto> FindAll(AddressDto _addressDto)
        {
           var dbResults=this.entiesrepository.Repository.Find(
                BuildAllQuery(_addressDto),
                e => e.AddressID,
                _addressDto.pageIndex,
                _addressDto.pageSize);
           return ConvertTOUIModel<AddressDto, Address>(dbResults);
        }


        /// <summary>
        /// Builds all query.
        /// </summary>
        /// <param name="_Address">The Address dto.</param>
        /// <returns></returns>
        private static  Expression<Func<Address, bool>> BuildAllQuery(AddressDto _addressDto)
       { 
           var list = new List<Expression<Func<Address, bool>>>();

                if (_addressDto.AddressID > 0) list.Add(c => c.AddressID == _addressDto.AddressID);
    if (!string.IsNullOrEmpty(_addressDto.AddressLine1)) list.Add(c => c.AddressLine1.Contains(_addressDto.AddressLine1));
    if (!string.IsNullOrEmpty(_addressDto.AddressLine2)) list.Add(c => c.AddressLine2.Contains(_addressDto.AddressLine2));
    if (!string.IsNullOrEmpty(_addressDto.City)) list.Add(c => c.City.Contains(_addressDto.City));
    if (_addressDto.StateProvinceID > 0) list.Add(c => c.StateProvinceID == _addressDto.StateProvinceID);
    if (!string.IsNullOrEmpty(_addressDto.PostalCode)) list.Add(c => c.PostalCode.Contains(_addressDto.PostalCode));
    
    
          //Add more condition
            Expression<Func<Address, bool>> entityQueryConditionTotal = null;
            foreach (var e in list)
            {
                entityQueryConditionTotal= entityQueryConditionTotal == null ? e : entityQueryConditionTotal.And(e);

            }
            return entityQueryConditionTotal;
       }

        /// <summary>
        /// CreateEntiy
        /// </summary>
        /// <param name="product">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        public bool CreateEntiy(AddressDto t)
        {
            var dbEntity=typeAdapter.Transform<AddressDto, Address>(t);
            entiesrepository.Add(dbEntity);
            entiesrepository.Save();
            return true;
        }

        /// <summary>
        /// Gets the Entiy
        /// </summary>
        /// <param name="pid">The pid.</param>
        /// <returns>Entiy</returns>
        public AddressDto GetEntiyByPK(int _AddressID)
        {
            var entity=entiesrepository.Repository.Single(e => e.AddressID == _AddressID);
            return typeAdapter.Transform<Address, AddressDto>(entity);
         
        }

        /// <summary>
        /// Delete the With Attach Entiy.
        /// </summary>
        /// <param name="Entiy">The Entiy.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        public bool DeleteWithAttachEntiy(AddressDto t)
        {
            var dbEntity = typeAdapter.Transform<AddressDto, Address>(t);
            entiesrepository.Attach(dbEntity);
            entiesrepository.Delete(dbEntity);
            entiesrepository.Save();
            return true;
        }

        /// <summary>
        /// Dels the With Attach Entiy.
        /// </summary>
        /// <param name="Entiy">The Entiy.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        public bool DeleteEntiy(AddressDto t)
        {
            var dbEntity = typeAdapter.Transform<AddressDto, Address>(t);
            entiesrepository.Delete(dbEntity);
            entiesrepository.Save();
            return true;
        }

         /// <summary>
        /// Update With Attach the AddressEntiy.
        /// </summary>
        /// <param name="Entiy">The Entiy.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</return
        public bool UpdateWithAttachEntiy(AddressDto t)
        {
            var dbentity = typeAdapter.Transform<AddressDto, Address>(t);
            if (StateHelpers.GetEquivalentEntityState(dbentity.State)==StateHelpers.GetEquivalentEntityState(State.Detached))
            {
               entiesrepository.Attach(dbentity); 
            }

            dbentity.State = State.Modified;
            context.ChangeObjectState<Address>(dbentity, StateHelpers.GetEquivalentEntityState(dbentity.State));

            uow.Save();
            return true;
        }

         /// <summary>
        /// Update  the AddressEntiy.
        /// </summary>
        /// <param name="Entiy">The Entiy.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</return
        public bool UpdateEntiy(AddressDto t)
        {
            var dbentity = typeAdapter.Transform<AddressDto, Address>(t);
            dbentity.State = State.Modified;
            context.ChangeObjectState<Address>(dbentity,  StateHelpers.GetEquivalentEntityState(dbentity.State));

            uow.Save();
            return true;
        }
	}
}