// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactBO.cs" company="Megadotnet">
// Copyright (c) 2010-2015 Peter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The ContactBo
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
    /// Contact Business object, rules etc.
    /// </summary>
	public class ContactBO : IContactBO
	{
        /// <summary>
        /// The type adapter
        /// </summary>
        private IContactConverter typeAdapter;
        /// <summary>
        /// The dbcontext
        /// </summary>
        private IObjectContext context;
        /// <summary>
        /// The unit of work interface
        /// </summary>
        private IUnitOfWork uow;
        /// <summary>
        /// The Contact repository
        /// </summary>
        private ContactRepository entiesrepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactBusniessLogicObject"/> class.
        /// </summary>
	    [InjectionConstructor]
        public ContactBO(IContactConverter _ContactConverter)
        {
            context = RepositoryHelper.GetDbContext();
            uow = RepositoryHelper.GetUnitOfWork(context);
            this.entiesrepository = RepositoryHelper.GetContactRepository(context);
			this.typeAdapter = _ContactConverter;
        }

        /// <summary>
        /// Find Enties 
        /// </summary>
        /// <param name="pageIndex">pageIndex</param>
        /// <param name="pageSize">pageSize</param>
        /// <returns>Enties</returns>
        public PagedList<ContactDto> FindEnties(int? pageIndex, int pageSize)
        {
            var entities=entiesrepository.Repository.Find(p => p.ContactID>0, p => p.ContactID, pageIndex, pageSize);
            var listDtos=new PagedList<ContactDto>() { TotalCount = entities.TotalCount };
             entities.ForEach(entity => { listDtos.Add(typeAdapter.ConvertEntitiesToDto(entity)); });
             return listDtos;
        }

		/// <summary>
        /// Find Enties Async
        /// </summary>
        /// <param name="pageIndex">pageIndex</param>
        /// <param name="pageSize">pageSize</param>
        /// <returns>Enties</returns>
        public async Task<PagedList<ContactDto>> FindEntiesAsync(int? pageIndex, int pageSize)
        {
            var entities = await entiesrepository.Repository.FindAsync(p => p.ContactID > 0, p => p.ContactID, pageIndex, pageSize);
            var listDtos = new PagedList<ContactDto>() { TotalCount = entities.TotalCount, PageIndex=pageIndex.Value,PageSize=pageSize  };
            entities.ForEach(entity => { listDtos.Add(typeAdapter.ConvertEntitiesToDto(entity)); });
            return listDtos;
        }

        /// <summary>
        /// Converts the to UI model.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>Contact list</returns>
        private EasyuiDatagridData<ContactDto> ConvertTOUIModel(PagedList<Contact> entities)
        {
            var listDtos = new EasyuiDatagridData<ContactDto>() { Total = entities.TotalCount };
            var lists = new List<ContactDto>();
            
            entities.ForEach(entity => { lists.Add(this.typeAdapter.ConvertEntitiesToDto(entity)); });
            listDtos.Rows = lists.ToArray();
            return listDtos;
        }

        /// <summary>
        /// Finds the enties.
        /// </summary>
        /// <param name="Contact">The Contact dto.</param>
        /// <returns></returns>
        public EasyuiDatagridData<ContactDto> FindEnties(ContactDto  _contactDto)
        {
            var entities = entiesrepository.Repository.Find(p => p.ContactID > 0, p => p.ContactID, _contactDto.pageIndex, _contactDto.pageSize);
            var listDtos = ConvertTOUIModel(entities);
            return listDtos;
        }


        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="_ContactDto">The Contactdto.</param>
        /// <returns></returns>
        public EasyuiDatagridData<ContactDto> FindAll(ContactDto _contactDto)
        {
           var dbResults=this.entiesrepository.Repository.Find(
                BuildAllQuery(_contactDto),
                e => e.ContactID,
                _contactDto.pageIndex,
                _contactDto.pageSize);
           return ConvertTOUIModel(dbResults);
        }


        /// <summary>
        /// Builds all query.
        /// </summary>
        /// <param name="_Contact">The Contact dto.</param>
        /// <returns></returns>
        private static  Expression<Func<Contact, bool>> BuildAllQuery(ContactDto _contactDto)
       { 
           var list = new List<Expression<Func<Contact, bool>>>();

                if (_contactDto.ContactID > 0) list.Add(c => c.ContactID == _contactDto.ContactID);
    if (_contactDto.NameStyle != null) list.Add(c => c.NameStyle == _contactDto.NameStyle);
    if (!string.IsNullOrEmpty(_contactDto.Title)) list.Add(c => c.Title.Contains(_contactDto.Title));
    if (!string.IsNullOrEmpty(_contactDto.FirstName)) list.Add(c => c.FirstName.Contains(_contactDto.FirstName));
    if (!string.IsNullOrEmpty(_contactDto.MiddleName)) list.Add(c => c.MiddleName.Contains(_contactDto.MiddleName));
    if (!string.IsNullOrEmpty(_contactDto.LastName)) list.Add(c => c.LastName.Contains(_contactDto.LastName));
    if (!string.IsNullOrEmpty(_contactDto.Suffix)) list.Add(c => c.Suffix.Contains(_contactDto.Suffix));
    if (!string.IsNullOrEmpty(_contactDto.EmailAddress)) list.Add(c => c.EmailAddress.Contains(_contactDto.EmailAddress));
    if (_contactDto.EmailPromotion > 0) list.Add(c => c.EmailPromotion == _contactDto.EmailPromotion);
    if (!string.IsNullOrEmpty(_contactDto.Phone)) list.Add(c => c.Phone.Contains(_contactDto.Phone));
    if (!string.IsNullOrEmpty(_contactDto.PasswordHash)) list.Add(c => c.PasswordHash.Contains(_contactDto.PasswordHash));
    if (!string.IsNullOrEmpty(_contactDto.PasswordSalt)) list.Add(c => c.PasswordSalt.Contains(_contactDto.PasswordSalt));
    if (!string.IsNullOrEmpty(_contactDto.AdditionalContactInfo)) list.Add(c => c.AdditionalContactInfo.Contains(_contactDto.AdditionalContactInfo));
    
    
          //Add more condition
            Expression<Func<Contact, bool>> entityQueryConditionTotal = null;
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
        public bool CreateEntiy(ContactDto t)
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
        public async Task<int> CreateEntiyAsync(ContactDto tDTo)
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
        public ContactDto GetEntiyByPK(int _ContactID)
        {
            var entity=entiesrepository.Repository.Single(e => e.ContactID == _ContactID);
            return typeAdapter.ConvertEntitiesToDto(entity);
         
        }

        /// <summary>
        /// Delete the With Attach Entiy.
        /// </summary>
        /// <param name="Entiy">The Entiy.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        public bool DeleteWithAttachEntiy(ContactDto t)
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
        public async Task<int> DeleteWithAttachEntiyAsync(ContactDto tDTo)
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
        public bool DeleteWithAttachEntiy(ContactDto[] entities)
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
        public bool DeleteEntiy(ContactDto t)
        {
            var dbEntity = typeAdapter.ConvertDtoToEntities(t);
            entiesrepository.Delete(dbEntity);
            entiesrepository.Save();
            return true;
        }

         /// <summary>
        /// Update With Attach the ContactEntiy.
        /// </summary>
        /// <param name="Entiy">The Entiy.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</return
        public bool UpdateWithAttachEntiy(ContactDto t)
        {
            var dbentity = typeAdapter.ConvertDtoToEntities(t);
            if (StateHelpers.GetEquivalentEntityState(dbentity.State)==StateHelpers.GetEquivalentEntityState(State.Detached))
            {
               entiesrepository.Attach(dbentity); 
            }

            dbentity.State = State.Modified;
            context.ChangeObjectState<Contact>(dbentity,  StateHelpers.GetEquivalentEntityState(dbentity.State));

            uow.Save();
            return true;
        }

         /// <summary>
        /// Update  the ContactEntiy.
        /// </summary>
        /// <param name="Entiy">The Entiy.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</return
        public bool UpdateEntiy(ContactDto t)
        {
            var dbentity = typeAdapter.ConvertDtoToEntities(t);
            dbentity.State = State.Modified;
            context.ChangeObjectState<Contact>(dbentity,  StateHelpers.GetEquivalentEntityState(dbentity.State));

            uow.Save();
            return true;
        }


        /// <summary>
        /// Updates the Contactentiy with get.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</return>
        public bool UpdateEntiyWithGet(ContactDto entity)
        {
            var dbEntity = entiesrepository.Repository.Single(e => e.ContactID == entity.ContactID);
            dbEntity = typeAdapter.ConvertDtoToEntities(entity,dbEntity,skipNullPropertyValue:true);
            uow.Save();
            return true;
        }

        /// <summary>
        /// Updates the entiy asynchronous.
        /// </summary>
        /// <param name="tDTo">The t d to.</param>
        /// <returns></returns>
        public async Task<int> UpdateEntiyAsync(ContactDto tDTo)
        {
            var dbentity = typeAdapter.ConvertDtoToEntities(tDTo);
            dbentity.State = State.Modified;
            context.ChangeObjectState<Contact>(dbentity, StateHelpers.GetEquivalentEntityState(dbentity.State));

            return await uow.SaveAsync();
        }


        /// <summary>
        /// Updates the with attach entiy asynchronous.
        /// </summary>
        /// <param name="tDTo">The t d to.</param>
        /// <returns></returns>
        public async Task<int> UpdateWithAttachEntiyAsync(ContactDto tDTo)
        {
            var dbentity = typeAdapter.ConvertDtoToEntities(tDTo);
            if (StateHelpers.GetEquivalentEntityState(dbentity.State) == StateHelpers.GetEquivalentEntityState(State.Detached))
            {
                entiesrepository.Attach(dbentity);
            }

            dbentity.State = State.Modified;
            context.ChangeObjectState<Contact>(dbentity, StateHelpers.GetEquivalentEntityState(dbentity.State));

            return await uow.SaveAsync();
        }

        /// <summary>
        /// Updates the entiy with get asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<int> UpdateEntiyWithGetAsync(ContactDto entity)
        {
            var dbEntity = entiesrepository.Repository.Single(e => e.ContactID == entity.ContactID);
            dbEntity = typeAdapter.ConvertDtoToEntities(entity, dbEntity, skipNullPropertyValue: true);
            return await uow.SaveAsync();
        }
	}
}