// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactBO.cs" company="Megadotnet">
// Copyright (c) 2010-2014 Peter Liu.  All rights reserved. 
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
using BusinessEntiies;
using DataAccessObject;
using IronFramework.Utility;
using IronFramework.Utility.UI;
using IronFramework.Utility.EntityFramewrok;

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
        /// The Contact repository
        /// </summary>
        private ContactRepository entiesrepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactBusniessLogicObject"/> class.
        /// </summary>
        public ContactBO()
        {
            context = RepositoryHelper.GetDbContext();
            uow = RepositoryHelper.GetUnitOfWork(context);
            this.entiesrepository = RepositoryHelper.GetContactRepository(context);
        }

        /// <summary>
        /// FindEnties 
        /// </summary>
        /// <param name="pageIndex">pageIndex</param>
        /// <param name="pageSize">pageSize</param>
        /// <returns>Enties</returns>
        public PagedList<ContactDto> FindEnties(int? pageIndex, int pageSize)
        {
            var entities=entiesrepository.Repository.Find(p => p.ContactID>0, p => p.ContactID, pageIndex, pageSize);
            var listDtos=new PagedList<ContactDto>() { TotalCount = entities.TotalCount };
             entities.ForEach(entity => { listDtos.Add(typeAdapter.Transform<Contact, ContactDto>(entity)); });
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
        /// <param name="Contact">The Contact dto.</param>
        /// <returns></returns>
        public EasyuiDatagridData<ContactDto> FindEnties(ContactDto  _contactDto)
        {
            var entities = entiesrepository.Repository.Find(p => p.ContactID > 0, p => p.ContactID, _contactDto.pageIndex, _contactDto.pageSize);
            var listDtos = ConvertTOUIModel<ContactDto,Contact>(entities);
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
           return ConvertTOUIModel<ContactDto, Contact>(dbResults);
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
            var dbEntity=typeAdapter.Transform<ContactDto, Contact>(t);
            entiesrepository.Add(dbEntity);
            entiesrepository.Save();
            return true;
        }

        /// <summary>
        /// Gets the Entiy
        /// </summary>
        /// <param name="pid">The pid.</param>
        /// <returns>Entiy</returns>
        public ContactDto GetEntiyByPK(int _ContactID)
        {
            var entity=entiesrepository.Repository.Single(e => e.ContactID == _ContactID);
            return typeAdapter.Transform<Contact, ContactDto>(entity);
         
        }

        /// <summary>
        /// Delete the With Attach Entiy.
        /// </summary>
        /// <param name="Entiy">The Entiy.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        public bool DeleteWithAttachEntiy(ContactDto t)
        {
            var dbEntity = typeAdapter.Transform<ContactDto, Contact>(t);
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
        public bool DeleteEntiy(ContactDto t)
        {
            var dbEntity = typeAdapter.Transform<ContactDto, Contact>(t);
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
            var dbentity = typeAdapter.Transform<ContactDto, Contact>(t);
            if (StateHelpers.GetEquivalentEntityState(dbentity.State)==StateHelpers.GetEquivalentEntityState(State.Detached))
            {
               entiesrepository.Attach(dbentity); 
            }

            dbentity.State = State.Modified;
            context.ChangeObjectState<Contact>(dbentity, StateHelpers.GetEquivalentEntityState(dbentity.State));

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
            var dbentity = typeAdapter.Transform<ContactDto, Contact>(t);
            dbentity.State = State.Modified;
            context.ChangeObjectState<Contact>(dbentity,  StateHelpers.GetEquivalentEntityState(dbentity.State));

            uow.Save();
            return true;
        }
	}
}