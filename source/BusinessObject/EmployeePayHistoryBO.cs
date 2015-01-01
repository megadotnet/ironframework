// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeePayHistoryBO.cs" company="Megadotnet">
// Copyright (c) 2010-2014 Peter Liu.  All rights reserved. 
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
using BusinessEntiies;
using DataAccessObject;
using IronFramework.Utility;
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
        /// FindEnties 
        /// </summary>
        /// <param name="pageIndex">pageIndex</param>
        /// <param name="pageSize">pageSize</param>
        /// <returns>Enties</returns>
        public PagedList<EmployeePayHistoryDto> FindEnties(int? pageIndex, int pageSize)
        {
            var entities=entiesrepository.Repository.Find(p => p.EmployeeID>0, p => p.EmployeeID, pageIndex, pageSize);
            var listDtos=new PagedList<EmployeePayHistoryDto>() { TotalCount = entities.TotalCount };
             entities.ForEach(entity => { listDtos.Add(typeAdapter.Transform<EmployeePayHistory, EmployeePayHistoryDto>(entity)); });
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
        /// <param name="EmployeePayHistory">The EmployeePayHistory dto.</param>
        /// <returns></returns>
        public EasyuiDatagridData<EmployeePayHistoryDto> FindEnties(EmployeePayHistoryDto  _employeepayhistoryDto)
        {
            var entities = entiesrepository.Repository.Find(p => p.EmployeeID > 0, p => p.EmployeeID, _employeepayhistoryDto.pageIndex, _employeepayhistoryDto.pageSize);
            var listDtos = ConvertTOUIModel<EmployeePayHistoryDto,EmployeePayHistory>(entities);
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
           return ConvertTOUIModel<EmployeePayHistoryDto, EmployeePayHistory>(dbResults);
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
            var dbEntity=typeAdapter.Transform<EmployeePayHistoryDto, EmployeePayHistory>(t);
            entiesrepository.Add(dbEntity);
            entiesrepository.Save();
            return true;
        }

        /// <summary>
        /// Gets the Entiy
        /// </summary>
        /// <param name="pid">The pid.</param>
        /// <returns>Entiy</returns>
        public EmployeePayHistoryDto GetEntiyByPK(int _EmployeeID)
        {
            var entity=entiesrepository.Repository.Single(e => e.EmployeeID == _EmployeeID);
            return typeAdapter.Transform<EmployeePayHistory, EmployeePayHistoryDto>(entity);
         
        }

        /// <summary>
        /// Delete the With Attach Entiy.
        /// </summary>
        /// <param name="Entiy">The Entiy.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        public bool DeleteWithAttachEntiy(EmployeePayHistoryDto t)
        {
            var dbEntity = typeAdapter.Transform<EmployeePayHistoryDto, EmployeePayHistory>(t);
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
        public bool DeleteEntiy(EmployeePayHistoryDto t)
        {
            var dbEntity = typeAdapter.Transform<EmployeePayHistoryDto, EmployeePayHistory>(t);
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
            var dbentity = typeAdapter.Transform<EmployeePayHistoryDto, EmployeePayHistory>(t);
            if (StateHelpers.GetEquivalentEntityState(dbentity.State)==StateHelpers.GetEquivalentEntityState(State.Detached))
            {
               entiesrepository.Attach(dbentity); 
            }

            dbentity.State = State.Modified;
            context.ChangeObjectState<EmployeePayHistory>(dbentity, StateHelpers.GetEquivalentEntityState(dbentity.State));

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
            var dbentity = typeAdapter.Transform<EmployeePayHistoryDto, EmployeePayHistory>(t);
            dbentity.State = State.Modified;
            context.ChangeObjectState<EmployeePayHistory>(dbentity,  StateHelpers.GetEquivalentEntityState(dbentity.State));

            uow.Save();
            return true;
        }
	}
}