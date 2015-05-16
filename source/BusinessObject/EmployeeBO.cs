// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeBO.cs" company="Megadotnet">
// Copyright (c) 2010-2015 Peter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The EmployeeBo
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
    /// Employee Business object, rules etc.
    /// </summary>
	public class EmployeeBO : IEmployeeBO
	{
        /// <summary>
        /// The type adapter
        /// </summary>
        private IEmployeeConverter typeAdapter;
        /// <summary>
        /// The dbcontext
        /// </summary>
        private IObjectContext context;
        /// <summary>
        /// The unit of work interface
        /// </summary>
        private IUnitOfWork uow;
        /// <summary>
        /// The Employee repository
        /// </summary>
        private EmployeeRepository entiesrepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeBusniessLogicObject"/> class.
        /// </summary>
	    [InjectionConstructor]
        public EmployeeBO(IEmployeeConverter _EmployeeConverter)
        {
            context = RepositoryHelper.GetDbContext();
            uow = RepositoryHelper.GetUnitOfWork(context);
            this.entiesrepository = RepositoryHelper.GetEmployeeRepository(context);
			this.typeAdapter = _EmployeeConverter;
        }

        /// <summary>
        /// Find Enties 
        /// </summary>
        /// <param name="pageIndex">pageIndex</param>
        /// <param name="pageSize">pageSize</param>
        /// <returns>Enties</returns>
        public PagedList<EmployeeDto> FindEnties(int? pageIndex, int pageSize)
        {
            var entities=entiesrepository.Repository.Find(p => p.EmployeeID>0, p => p.EmployeeID, pageIndex, pageSize);
            var listDtos=new PagedList<EmployeeDto>() { TotalCount = entities.TotalCount };
             entities.ForEach(entity => { listDtos.Add(typeAdapter.ConvertEntitiesToDto(entity)); });
             return listDtos;
        }

		/// <summary>
        /// Find Enties Async
        /// </summary>
        /// <param name="pageIndex">pageIndex</param>
        /// <param name="pageSize">pageSize</param>
        /// <returns>Enties</returns>
        public async Task<PagedList<EmployeeDto>> FindEntiesAsync(int? pageIndex, int pageSize)
        {
            var entities = await entiesrepository.Repository.FindAsync(p => p.EmployeeID > 0, p => p.EmployeeID, pageIndex, pageSize);
            var listDtos = new PagedList<EmployeeDto>() { TotalCount = entities.TotalCount, PageIndex=pageIndex.Value,PageSize=pageSize  };
            entities.ForEach(entity => { listDtos.Add(typeAdapter.ConvertEntitiesToDto(entity)); });
            return listDtos;
        }

        /// <summary>
        /// Converts the to UI model.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>Employee list</returns>
        private EasyuiDatagridData<EmployeeDto> ConvertTOUIModel(PagedList<Employee> entities)
        {
            var listDtos = new EasyuiDatagridData<EmployeeDto>() { Total = entities.TotalCount };
            var lists = new List<EmployeeDto>();
            
            entities.ForEach(entity => { lists.Add(this.typeAdapter.ConvertEntitiesToDto(entity)); });
            listDtos.Rows = lists.ToArray();
            return listDtos;
        }

        /// <summary>
        /// Finds the enties.
        /// </summary>
        /// <param name="Employee">The Employee dto.</param>
        /// <returns></returns>
        public EasyuiDatagridData<EmployeeDto> FindEnties(EmployeeDto  _employeeDto)
        {
            var entities = entiesrepository.Repository.Find(p => p.EmployeeID > 0, p => p.EmployeeID, _employeeDto.pageIndex, _employeeDto.pageSize);
            var listDtos = ConvertTOUIModel(entities);
            return listDtos;
        }


        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="_EmployeeDto">The Employeedto.</param>
        /// <returns></returns>
        public EasyuiDatagridData<EmployeeDto> FindAll(EmployeeDto _employeeDto)
        {
           var dbResults=this.entiesrepository.Repository.Find(
                BuildAllQuery(_employeeDto),
                e => e.EmployeeID,
                _employeeDto.pageIndex,
                _employeeDto.pageSize);
           return ConvertTOUIModel(dbResults);
        }


        /// <summary>
        /// Builds all query.
        /// </summary>
        /// <param name="_Employee">The Employee dto.</param>
        /// <returns></returns>
        private static  Expression<Func<Employee, bool>> BuildAllQuery(EmployeeDto _employeeDto)
       { 
           var list = new List<Expression<Func<Employee, bool>>>();

                if (_employeeDto.EmployeeID > 0) list.Add(c => c.EmployeeID == _employeeDto.EmployeeID);
    if (!string.IsNullOrEmpty(_employeeDto.NationalIDNumber)) list.Add(c => c.NationalIDNumber.Contains(_employeeDto.NationalIDNumber));
    if (_employeeDto.ContactID > 0) list.Add(c => c.ContactID == _employeeDto.ContactID);
    if (!string.IsNullOrEmpty(_employeeDto.LoginID)) list.Add(c => c.LoginID.Contains(_employeeDto.LoginID));
    if (_employeeDto.ManagerID > 0) list.Add(c => c.ManagerID == _employeeDto.ManagerID);
    if (!string.IsNullOrEmpty(_employeeDto.Title)) list.Add(c => c.Title.Contains(_employeeDto.Title));
    
    if (!string.IsNullOrEmpty(_employeeDto.MaritalStatus)) list.Add(c => c.MaritalStatus.Contains(_employeeDto.MaritalStatus));
    if (!string.IsNullOrEmpty(_employeeDto.Gender)) list.Add(c => c.Gender.Contains(_employeeDto.Gender));
    
    if (_employeeDto.SalariedFlag != null) list.Add(c => c.SalariedFlag == _employeeDto.SalariedFlag);
    
    
    if (_employeeDto.CurrentFlag != null) list.Add(c => c.CurrentFlag == _employeeDto.CurrentFlag);
    
    
          //Add more condition
            Expression<Func<Employee, bool>> entityQueryConditionTotal = null;
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
        public bool CreateEntiy(EmployeeDto t)
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
        public async Task<int> CreateEntiyAsync(EmployeeDto tDTo)
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
        public EmployeeDto GetEntiyByPK(int _EmployeeID)
        {
            var entity=entiesrepository.Repository.Single(e => e.EmployeeID == _EmployeeID);
            return typeAdapter.ConvertEntitiesToDto(entity);
         
        }

        /// <summary>
        /// Delete the With Attach Entiy.
        /// </summary>
        /// <param name="Entiy">The Entiy.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        public bool DeleteWithAttachEntiy(EmployeeDto t)
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
        public async Task<int> DeleteWithAttachEntiyAsync(EmployeeDto tDTo)
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
        public bool DeleteWithAttachEntiy(EmployeeDto[] entities)
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
        public bool DeleteEntiy(EmployeeDto t)
        {
            var dbEntity = typeAdapter.ConvertDtoToEntities(t);
            entiesrepository.Delete(dbEntity);
            entiesrepository.Save();
            return true;
        }

         /// <summary>
        /// Update With Attach the EmployeeEntiy.
        /// </summary>
        /// <param name="Entiy">The Entiy.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</return
        public bool UpdateWithAttachEntiy(EmployeeDto t)
        {
            var dbentity = typeAdapter.ConvertDtoToEntities(t);
            if (StateHelpers.GetEquivalentEntityState(dbentity.State)==StateHelpers.GetEquivalentEntityState(State.Detached))
            {
               entiesrepository.Attach(dbentity); 
            }

            dbentity.State = State.Modified;
            context.ChangeObjectState<Employee>(dbentity,  StateHelpers.GetEquivalentEntityState(dbentity.State));

            uow.Save();
            return true;
        }

         /// <summary>
        /// Update  the EmployeeEntiy.
        /// </summary>
        /// <param name="Entiy">The Entiy.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</return
        public bool UpdateEntiy(EmployeeDto t)
        {
            var dbentity = typeAdapter.ConvertDtoToEntities(t);
            dbentity.State = State.Modified;
            context.ChangeObjectState<Employee>(dbentity,  StateHelpers.GetEquivalentEntityState(dbentity.State));

            uow.Save();
            return true;
        }


        /// <summary>
        /// Updates the Employeeentiy with get.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</return>
        public bool UpdateEntiyWithGet(EmployeeDto entity)
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
        public async Task<int> UpdateEntiyAsync(EmployeeDto tDTo)
        {
            var dbentity = typeAdapter.ConvertDtoToEntities(tDTo);
            dbentity.State = State.Modified;
            context.ChangeObjectState<Employee>(dbentity, StateHelpers.GetEquivalentEntityState(dbentity.State));

            return await uow.SaveAsync();
        }


        /// <summary>
        /// Updates the with attach entiy asynchronous.
        /// </summary>
        /// <param name="tDTo">The t d to.</param>
        /// <returns></returns>
        public async Task<int> UpdateWithAttachEntiyAsync(EmployeeDto tDTo)
        {
            var dbentity = typeAdapter.ConvertDtoToEntities(tDTo);
            if (StateHelpers.GetEquivalentEntityState(dbentity.State) == StateHelpers.GetEquivalentEntityState(State.Detached))
            {
                entiesrepository.Attach(dbentity);
            }

            dbentity.State = State.Modified;
            context.ChangeObjectState<Employee>(dbentity, StateHelpers.GetEquivalentEntityState(dbentity.State));

            return await uow.SaveAsync();
        }

        /// <summary>
        /// Updates the entiy with get asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<int> UpdateEntiyWithGetAsync(EmployeeDto entity)
        {
            var dbEntity = entiesrepository.Repository.Single(e => e.EmployeeID == entity.EmployeeID);
            dbEntity = typeAdapter.ConvertDtoToEntities(entity, dbEntity, skipNullPropertyValue: true);
            return await uow.SaveAsync();
        }
	}
}