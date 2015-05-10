// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeePayHistoryBO.cs" company="Megadotnet">
// Copyright (c) 2010-2015 Peter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The EmployeePayHistoryBo
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
	
namespace BusinessObject
{   
    /// <summary>
    /// EmployeePayHistory Business object, rules etc.
    /// </summary>
	public class EmployeePayHistoryBO : IEmployeePayHistoryBO
	{
        /// <summary>
        /// The type adapter
        /// </summary>
        private IEmployeePayHistoryConverter typeAdapter = new EmployeePayHistoryConverter();
        /// <summary>
        /// The dbcontext
        /// </summary>
        private IObjectContext context;
        /// <summary>
        /// The unit of work interface
        /// </summary>
        private IUnitOfWork uow;
        /// <summary>
        /// The EmployeePayHistory repository
        /// </summary>
        private EmployeePayHistoryRepository entiesrepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeePayHistoryBusniessLogicObject"/> class.
        /// </summary>
        public EmployeePayHistoryBO()
        {
            context = RepositoryHelper.GetDbContext();
            uow = RepositoryHelper.GetUnitOfWork(context);
            this.entiesrepository = RepositoryHelper.GetEmployeePayHistoryRepository(context);
        }

        /// <summary>
        /// Find Enties 
        /// </summary>
        /// <param name="pageIndex">pageIndex</param>
        /// <param name="pageSize">pageSize</param>
        /// <returns>Enties</returns>
        public PagedList<EmployeePayHistoryDto> FindEnties(int? pageIndex, int pageSize)
        {
            var entities=entiesrepository.Repository.Find(p => p.EmployeeID>0, p => p.EmployeeID, pageIndex, pageSize);
            var listDtos=new PagedList<EmployeePayHistoryDto>() { TotalCount = entities.TotalCount };
             entities.ForEach(entity => { listDtos.Add(typeAdapter.ConvertEntitiesToDto(entity)); });
             return listDtos;
        }

		/// <summary>
        /// Find Enties Async
        /// </summary>
        /// <param name="pageIndex">pageIndex</param>
        /// <param name="pageSize">pageSize</param>
        /// <returns>Enties</returns>
        public async Task<PagedList<EmployeePayHistoryDto>> FindEntiesAsync(int? pageIndex, int pageSize)
        {
            var entities = await entiesrepository.Repository.FindAsync(p => p.EmployeeID > 0, p => p.EmployeeID, pageIndex, pageSize);
            var listDtos = new PagedList<EmployeePayHistoryDto>() { TotalCount = entities.TotalCount };
            entities.ForEach(entity => { listDtos.Add(typeAdapter.ConvertEntitiesToDto(entity)); });
            return listDtos;
        }

        /// <summary>
        /// Converts the to UI model.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>EmployeePayHistory list</returns>
        private EasyuiDatagridData<EmployeePayHistoryDto> ConvertTOUIModel(PagedList<EmployeePayHistory> entities)
        {
            var listDtos = new EasyuiDatagridData<EmployeePayHistoryDto>() { total = entities.TotalCount };
            var lists = new List<EmployeePayHistoryDto>();
            
            entities.ForEach(entity => { lists.Add(this.typeAdapter.ConvertEntitiesToDto(entity)); });
            listDtos.rows = lists.ToArray();
            return listDtos;
        }

        /// <summary>
        /// Finds the enties.
        /// </summary>
        /// <param name="EmployeePayHistory">The EmployeePayHistory dto.</param>
        /// <returns></returns>
        public EasyuiDatagridData<EmployeePayHistoryDto> FindEnties(EmployeePayHistoryDto  _employeepayhistoryDto)
        {
            var entities = entiesrepository.Repository.Find(p => p.EmployeeID > 0, p => p.EmployeeID, _employeepayhistoryDto.pageIndex, _employeepayhistoryDto.pageSize);
            var listDtos = ConvertTOUIModel(entities);
            return listDtos;
        }


        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="_EmployeePayHistoryDto">The EmployeePayHistorydto.</param>
        /// <returns></returns>
        public EasyuiDatagridData<EmployeePayHistoryDto> FindAll(EmployeePayHistoryDto _employeepayhistoryDto)
        {
           var dbResults=this.entiesrepository.Repository.Find(
                BuildAllQuery(_employeepayhistoryDto),
                e => e.EmployeeID,
                _employeepayhistoryDto.pageIndex,
                _employeepayhistoryDto.pageSize);
           return ConvertTOUIModel(dbResults);
        }


        /// <summary>
        /// Builds all query.
        /// </summary>
        /// <param name="_EmployeePayHistory">The EmployeePayHistory dto.</param>
        /// <returns></returns>
        private static  Expression<Func<EmployeePayHistory, bool>> BuildAllQuery(EmployeePayHistoryDto _employeepayhistoryDto)
       { 
           var list = new List<Expression<Func<EmployeePayHistory, bool>>>();

                if (_employeepayhistoryDto.EmployeeID > 0) list.Add(c => c.EmployeeID == _employeepayhistoryDto.EmployeeID);
    
    
    
    
          //Add more condition
            Expression<Func<EmployeePayHistory, bool>> entityQueryConditionTotal = null;
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
        public bool CreateEntiy(EmployeePayHistoryDto t)
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
        public async Task<int> CreateEntiyAsync(EmployeePayHistoryDto tDTo)
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
        public EmployeePayHistoryDto GetEntiyByPK(int _EmployeeID)
        {
            var entity=entiesrepository.Repository.Single(e => e.EmployeeID == _EmployeeID);
            return typeAdapter.ConvertEntitiesToDto(entity);
         
        }

        /// <summary>
        /// Delete the With Attach Entiy.
        /// </summary>
        /// <param name="Entiy">The Entiy.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        public bool DeleteWithAttachEntiy(EmployeePayHistoryDto t)
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
        public async Task<int> DeleteWithAttachEntiyAsync(EmployeePayHistoryDto tDTo)
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
        public bool DeleteWithAttachEntiy(EmployeePayHistoryDto[] entities)
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
        public bool DeleteEntiy(EmployeePayHistoryDto t)
        {
            var dbEntity = typeAdapter.ConvertDtoToEntities(t);
            entiesrepository.Delete(dbEntity);
            entiesrepository.Save();
            return true;
        }

         /// <summary>
        /// Update With Attach the EmployeePayHistoryEntiy.
        /// </summary>
        /// <param name="Entiy">The Entiy.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</return
        public bool UpdateWithAttachEntiy(EmployeePayHistoryDto t)
        {
            var dbentity = typeAdapter.ConvertDtoToEntities(t);
            if (StateHelpers.GetEquivalentEntityState(dbentity.State)==StateHelpers.GetEquivalentEntityState(State.Detached))
            {
               entiesrepository.Attach(dbentity); 
            }

            dbentity.State = State.Modified;
            context.ChangeObjectState<EmployeePayHistory>(dbentity,  StateHelpers.GetEquivalentEntityState(dbentity.State));

            uow.Save();
            return true;
        }

         /// <summary>
        /// Update  the EmployeePayHistoryEntiy.
        /// </summary>
        /// <param name="Entiy">The Entiy.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</return
        public bool UpdateEntiy(EmployeePayHistoryDto t)
        {
            var dbentity = typeAdapter.ConvertDtoToEntities(t);
            dbentity.State = State.Modified;
            context.ChangeObjectState<EmployeePayHistory>(dbentity,  StateHelpers.GetEquivalentEntityState(dbentity.State));

            uow.Save();
            return true;
        }


        /// <summary>
        /// Updates the EmployeePayHistoryentiy with get.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</return>
        public bool UpdateEntiyWithGet(EmployeePayHistoryDto entity)
        {
            var dbEntity = entiesrepository.Repository.Single(e => e.EmployeeID == entity.EmployeeID);
            dbEntity = typeAdapter.ConvertDtoToEntities(entity,dbEntity,skipNullPropertyValue:true);
            uow.Save();
            return true;
        }

        /// <summary>
        /// Updates the entiy asynchronous.
        /// </summary>
        /// <param name="tDTo">The t d to.</param>
        /// <returns></returns>
        public async Task<int> UpdateEntiyAsync(EmployeePayHistoryDto tDTo)
        {
            var dbentity = typeAdapter.ConvertDtoToEntities(tDTo);
            dbentity.State = State.Modified;
            context.ChangeObjectState<EmployeePayHistory>(dbentity, StateHelpers.GetEquivalentEntityState(dbentity.State));

            return await uow.SaveAsync();
        }


        /// <summary>
        /// Updates the with attach entiy asynchronous.
        /// </summary>
        /// <param name="tDTo">The t d to.</param>
        /// <returns></returns>
        public async Task<int> UpdateWithAttachEntiyAsync(EmployeePayHistoryDto tDTo)
        {
            var dbentity = typeAdapter.ConvertDtoToEntities(tDTo);
            if (StateHelpers.GetEquivalentEntityState(dbentity.State) == StateHelpers.GetEquivalentEntityState(State.Detached))
            {
                entiesrepository.Attach(dbentity);
            }

            dbentity.State = State.Modified;
            context.ChangeObjectState<EmployeePayHistory>(dbentity, StateHelpers.GetEquivalentEntityState(dbentity.State));

            return await uow.SaveAsync();
        }

        /// <summary>
        /// Updates the entiy with get asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<int> UpdateEntiyWithGetAsync(EmployeePayHistoryDto entity)
        {
            var dbEntity = entiesrepository.Repository.Single(e => e.EmployeeID == entity.EmployeeID);
            dbEntity = typeAdapter.ConvertDtoToEntities(entity, dbEntity, skipNullPropertyValue: true);
            return await uow.SaveAsync();
        }
	}
}