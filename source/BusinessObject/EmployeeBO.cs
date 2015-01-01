// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeBO.cs" company="Megadotnet">
// Copyright (c) 2010-2014 Peter Liu.  All rights reserved. 
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
using BusinessEntiies;
using DataAccessObject;
using IronFramework.Utility;
using IronFramework.Utility.UI;
using IronFramework.Utility.EntityFramewrok;

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
        /// The Employee repository
        /// </summary>
        private EmployeeRepository entiesrepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeBusniessLogicObject"/> class.
        /// </summary>
        public EmployeeBO()
        {
            context = RepositoryHelper.GetDbContext();
            uow = RepositoryHelper.GetUnitOfWork(context);
            this.entiesrepository = RepositoryHelper.GetEmployeeRepository(context);
        }

        /// <summary>
        /// FindEnties 
        /// </summary>
        /// <param name="pageIndex">pageIndex</param>
        /// <param name="pageSize">pageSize</param>
        /// <returns>Enties</returns>
        public PagedList<EmployeeDto> FindEnties(int? pageIndex, int pageSize)
        {
            var entities=entiesrepository.Repository.Find(p => p.EmployeeID>0, p => p.EmployeeID, pageIndex, pageSize);
            var listDtos=new PagedList<EmployeeDto>() { TotalCount = entities.TotalCount };
             entities.ForEach(entity => { listDtos.Add(typeAdapter.Transform<Employee, EmployeeDto>(entity)); });
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
        /// <param name="Employee">The Employee dto.</param>
        /// <returns></returns>
        public EasyuiDatagridData<EmployeeDto> FindEnties(EmployeeDto  _employeeDto)
        {
            var entities = entiesrepository.Repository.Find(p => p.EmployeeID > 0, p => p.EmployeeID, _employeeDto.pageIndex, _employeeDto.pageSize);
            var listDtos = ConvertTOUIModel<EmployeeDto,Employee>(entities);
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
           return ConvertTOUIModel<EmployeeDto, Employee>(dbResults);
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
            var dbEntity=typeAdapter.Transform<EmployeeDto, Employee>(t);
            entiesrepository.Add(dbEntity);
            entiesrepository.Save();
            return true;
        }

        /// <summary>
        /// Gets the Entiy
        /// </summary>
        /// <param name="pid">The pid.</param>
        /// <returns>Entiy</returns>
        public EmployeeDto GetEntiyByPK(int _EmployeeID)
        {
            var entity=entiesrepository.Repository.Single(e => e.EmployeeID == _EmployeeID);
            return typeAdapter.Transform<Employee, EmployeeDto>(entity);
         
        }

        /// <summary>
        /// Delete the With Attach Entiy.
        /// </summary>
        /// <param name="Entiy">The Entiy.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        public bool DeleteWithAttachEntiy(EmployeeDto t)
        {
            var dbEntity = typeAdapter.Transform<EmployeeDto, Employee>(t);
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
        public bool DeleteEntiy(EmployeeDto t)
        {
            var dbEntity = typeAdapter.Transform<EmployeeDto, Employee>(t);
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
            var dbentity = typeAdapter.Transform<EmployeeDto, Employee>(t);
            if (StateHelpers.GetEquivalentEntityState(dbentity.State)==StateHelpers.GetEquivalentEntityState(State.Detached))
            {
               entiesrepository.Attach(dbentity); 
            }

            dbentity.State = State.Modified;
            context.ChangeObjectState<Employee>(dbentity, StateHelpers.GetEquivalentEntityState(dbentity.State));

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
            var dbentity = typeAdapter.Transform<EmployeeDto, Employee>(t);
            dbentity.State = State.Modified;
            context.ChangeObjectState<Employee>(dbentity,  StateHelpers.GetEquivalentEntityState(dbentity.State));

            uow.Save();
            return true;
        }
	}
}