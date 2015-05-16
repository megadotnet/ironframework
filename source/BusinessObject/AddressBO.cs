// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddressBO.cs" company="Megadotnet">
// Copyright (c) 2010-2015 Peter Liu.  All rights reserved. 
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
using System.Threading.Tasks;
using BusinessEntities;
using DataAccessObject;
using DataTransferObject.Model;
using DataTransferObject;
using BusinessObject.Util;
using IronFramework.Utility.UI;
using IronFramework.Utility.EntityFramewrok;
using Microsoft.Practices.Unity;
	
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
        private IAddressConverter typeAdapter;
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
	    [InjectionConstructor]
        public AddressBO(IAddressConverter _AddressConverter)
        {
            context = RepositoryHelper.GetDbContext();
            uow = RepositoryHelper.GetUnitOfWork(context);
            this.entiesrepository = RepositoryHelper.GetAddressRepository(context);
			this.typeAdapter = _AddressConverter;
        }

        /// <summary>
        /// Find Enties 
        /// </summary>
        /// <param name="pageIndex">pageIndex</param>
        /// <param name="pageSize">pageSize</param>
        /// <returns>Enties</returns>
        public PagedList<AddressDto> FindEnties(int? pageIndex, int pageSize)
        {
            var entities=entiesrepository.Repository.Find(p => p.AddressID>0, p => p.AddressID, pageIndex, pageSize);
            var listDtos=new PagedList<AddressDto>() { TotalCount = entities.TotalCount };
             entities.ForEach(entity => { listDtos.Add(typeAdapter.ConvertEntitiesToDto(entity)); });
             return listDtos;
        }

		/// <summary>
        /// Find Enties Async
        /// </summary>
        /// <param name="pageIndex">pageIndex</param>
        /// <param name="pageSize">pageSize</param>
        /// <returns>Enties</returns>
        public async Task<PagedList<AddressDto>> FindEntiesAsync(int? pageIndex, int pageSize)
        {
            var entities = await entiesrepository.Repository.FindAsync(p => p.AddressID > 0, p => p.AddressID, pageIndex, pageSize);
            var listDtos = new PagedList<AddressDto>() { TotalCount = entities.TotalCount, PageIndex=pageIndex.Value,PageSize=pageSize  };
            entities.ForEach(entity => { listDtos.Add(typeAdapter.ConvertEntitiesToDto(entity)); });
            return listDtos;
        }

        /// <summary>
        /// Converts the to UI model.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>Address list</returns>
        private EasyuiDatagridData<AddressDto> ConvertTOUIModel(PagedList<Address> entities)
        {
            var listDtos = new EasyuiDatagridData<AddressDto>() { Total = entities.TotalCount };
            var lists = new List<AddressDto>();
            
            entities.ForEach(entity => { lists.Add(this.typeAdapter.ConvertEntitiesToDto(entity)); });
            listDtos.Rows = lists.ToArray();
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
            var listDtos = ConvertTOUIModel(entities);
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
           return ConvertTOUIModel(dbResults);
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
            var dbEntity=typeAdapter.ConvertDtoToEntities(t);
            entiesrepository.Add(dbEntity);
            entiesrepository.Save();
            return true;
        }

        /// <summary>
        /// Creates the entiy asynchronous.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns></returns>
        public async Task<int> CreateEntiyAsync(AddressDto tDTo)
        {
            var dbEntity = typeAdapter.ConvertDtoToEntities(tDTo);
            entiesrepository.Add(dbEntity);
            return await entiesrepository.SaveAsync();
        }

        /// <summary>
        /// Gets the Entiy
        /// </summary>
        /// <param name="pid">The pid.</param>
        /// <returns>Entiy</returns>
        public AddressDto GetEntiyByPK(int _AddressID)
        {
            var entity=entiesrepository.Repository.Single(e => e.AddressID == _AddressID);
            return typeAdapter.ConvertEntitiesToDto(entity);
         
        }

        /// <summary>
        /// Delete the With Attach Entiy.
        /// </summary>
        /// <param name="Entiy">The Entiy.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        public bool DeleteWithAttachEntiy(AddressDto t)
        {
            var dbEntity = typeAdapter.ConvertDtoToEntities(t);
            entiesrepository.Attach(dbEntity);
            entiesrepository.Delete(dbEntity);
            entiesrepository.Save();
            return true;
        }

        /// <summary>
        /// Deletes the with attach entiy asynchronous.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns></returns>
        public async Task<int> DeleteWithAttachEntiyAsync(AddressDto tDTo)
        {
            var dbEntity = typeAdapter.ConvertDtoToEntities(tDTo);
            entiesrepository.Attach(dbEntity);
            entiesrepository.Delete(dbEntity);
            return await entiesrepository.SaveAsync();
        }

        /// <summary>
        /// The del entiy.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns>
        /// The <see cref="bool" />.
        /// </returns>
        public bool DeleteWithAttachEntiy(AddressDto[] entities)
        {
            bool flag = false;
           if (entities!=null& entities.Length>0)
           {
               foreach(var entity in entities)
               {
                   flag=DeleteWithAttachEntiy(entity);
               }
           }
           return flag;
        }

        /// <summary>
        /// Dels the With Attach Entiy.
        /// </summary>
        /// <param name="Entiy">The Entiy.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        public bool DeleteEntiy(AddressDto t)
        {
            var dbEntity = typeAdapter.ConvertDtoToEntities(t);
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
            var dbentity = typeAdapter.ConvertDtoToEntities(t);
            if (StateHelpers.GetEquivalentEntityState(dbentity.State)==StateHelpers.GetEquivalentEntityState(State.Detached))
            {
               entiesrepository.Attach(dbentity); 
            }

            dbentity.State = State.Modified;
            context.ChangeObjectState<Address>(dbentity,  StateHelpers.GetEquivalentEntityState(dbentity.State));

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
            var dbentity = typeAdapter.ConvertDtoToEntities(t);
            dbentity.State = State.Modified;
            context.ChangeObjectState<Address>(dbentity,  StateHelpers.GetEquivalentEntityState(dbentity.State));

            uow.Save();
            return true;
        }


        /// <summary>
        /// Updates the Addressentiy with get.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</return>
        public bool UpdateEntiyWithGet(AddressDto entity)
        {
            var dbEntity = entiesrepository.Repository.Single(e => e.AddressID == entity.AddressID);
            dbEntity = typeAdapter.ConvertDtoToEntities(entity,dbEntity,skipNullPropertyValue:true);
            uow.Save();
            return true;
        }

        /// <summary>
        /// Updates the entiy asynchronous.
        /// </summary>
        /// <param name="tDTo">The t d to.</param>
        /// <returns></returns>
        public async Task<int> UpdateEntiyAsync(AddressDto tDTo)
        {
            var dbentity = typeAdapter.ConvertDtoToEntities(tDTo);
            dbentity.State = State.Modified;
            context.ChangeObjectState<Address>(dbentity, StateHelpers.GetEquivalentEntityState(dbentity.State));

            return await uow.SaveAsync();
        }


        /// <summary>
        /// Updates the with attach entiy asynchronous.
        /// </summary>
        /// <param name="tDTo">The t d to.</param>
        /// <returns></returns>
        public async Task<int> UpdateWithAttachEntiyAsync(AddressDto tDTo)
        {
            var dbentity = typeAdapter.ConvertDtoToEntities(tDTo);
            if (StateHelpers.GetEquivalentEntityState(dbentity.State) == StateHelpers.GetEquivalentEntityState(State.Detached))
            {
                entiesrepository.Attach(dbentity);
            }

            dbentity.State = State.Modified;
            context.ChangeObjectState<Address>(dbentity, StateHelpers.GetEquivalentEntityState(dbentity.State));

            return await uow.SaveAsync();
        }

        /// <summary>
        /// Updates the entiy with get asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<int> UpdateEntiyWithGetAsync(AddressDto entity)
        {
            var dbEntity = entiesrepository.Repository.Single(e => e.AddressID == entity.AddressID);
            dbEntity = typeAdapter.ConvertDtoToEntities(entity, dbEntity, skipNullPropertyValue: true);
            return await uow.SaveAsync();
        }
	}
}