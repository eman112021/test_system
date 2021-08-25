﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MMSystem.Model;
using MMSystem.Model.Dto;
using MMSystem.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.MailServeic
{
    public class MooKExernalnbox : IExtrenal_inbox
    {
        private readonly AppDbCon _dbCon;
        private readonly IMapper _mapper;

        public MooKExernalnbox(AppDbCon dbCon,IMapper mapper)
        {
            _dbCon = dbCon;
            _mapper = mapper;
        }
   

        public async Task<bool> Add(Extrenal_inbox extrenal)
        {
            try
            {
          
                Mail mail = await _dbCon.Mails.FindAsync(extrenal.MailID);
                if (mail != null)
                {

                    await _dbCon.Extrenal_Inboxes.AddAsync(extrenal);
                    await _dbCon.SaveChangesAsync();
                 
                    return true;
                }
              
                return false;

            }

            catch (Exception)
            {

                throw;
            }
           
            }
        

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ExInbox> Get(int id)
        {
            try
            {
                ExInbox ExMail = new ExInbox();
                Mail mail = await _dbCon.Mails.FindAsync(id);



                if (mail != null)
                {
                    ExMail.mail = _mapper.Map<Mail, MailDto>(mail);

                   
                    Extrenal_inbox external = await _dbCon.Extrenal_Inboxes.FirstAsync(x => x.MailID == id);
                    ExMail.extrenal  = _mapper.Map<Extrenal_inbox, Extrenal_inboxDto>(external);
                  List<Mail_Resourcescs> resourcescs = await _dbCon.Mail_Resourcescs.Where(x => x.MailID == mail.MailID).ToListAsync();
                    ExMail.resourcescsDto = _mapper.Map<List<Mail_Resourcescs>, List<Mail_ResourcescsDto>>(resourcescs);


                    return ExMail;

                }
                return ExMail;

            }
            catch (Exception)
            {

                throw;
            }

          
           
        }

        public async Task<List<ExInbox>> GetAll()
        {
            try
            {
                List<Extrenal_inbox> list = await _dbCon.Extrenal_Inboxes.OrderByDescending(x => x.Id).ToListAsync();
                List<Extrenal_inboxDto> listOfEmail = _mapper.Map<List<Extrenal_inbox>, List<Extrenal_inboxDto>>(list);
                return null;
            }
            catch (Exception)
            {

                throw;
            }
     
        }

        public async Task<bool> Update(Extrenal_inbox model)
        {
            Extrenal_inbox _Inbox = await _dbCon.Extrenal_Inboxes.FindAsync(model.Id);

            if (_Inbox != null) {

                await _dbCon.Extrenal_Inboxes.AddAsync(model);
                await _dbCon.SaveChangesAsync();

                return true;
            }
            return false;
        }
    }
}