﻿using Microsoft.EntityFrameworkCore;
using MMSystem.Model;
using MMSystem.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.DashBords
{
    public class MokDashBord : IDashBord
    {
        private AppDbCon DbCon { get; }

        public MokDashBord(AppDbCon dbCon)
        {
            DbCon = dbCon;
        }

        public async Task<Dashbord> GetDashbord(int ManagementId)
        {
            Dashbord Dashbord = new Dashbord();


            ////////////////////////////   الصاادر   //////////////////////////////////////

            //////////// مجموع  الداخلي //////////////

            var Totale_internell_externl = await (from x in DbCon.Mails.Where(x => x.Department_Id == ManagementId && x.Mail_Type == 1 && x.state == true)
                                               //   join y in DbCon.Sends.Where(y => y.flag >= 1) on x.MailID equals y.MailID
                                                 // select x).Distinct().ToListAsync();
                                //***********  الكود السابق قبل merge 14/8/2024
                                                 //select x).Distinct().CountAsync();
          ///  int Totale_internell_externl_count = Totale_internell_externl;//.Count();
          //*********end 14/8/2024
                                                  join y in DbCon.Sends.Where(y => y.flag >= 1 && y.resendfrom!= ManagementId) on x.MailID equals y.MailID
                                                  join p in DbCon.Departments.Where(p => p.state == true && p.perent != ManagementId) on y.to equals p.Id
                                                //**************14/8/2024 stop
                                                 // select x).Distinct().ToListAsync();
                                                 //  int Totale_internell_externl_count = Totale_internell_externl.Count();
                          //*****************end 14/8/2024
                select x).Distinct().CountAsync();
            int Totale_internell_externl_count = Totale_internell_externl;

            //////////// مجموع  الداخلي التي لم يقرائ //////////////

            var Notreaded_internell_externl = await (from x in DbCon.Mails.Where(x => x.Department_Id == ManagementId && x.Mail_Type == 1 && x.state == true)
                                                     join y in DbCon.Sends.Where(y => y.flag == 2) on x.MailID equals y.MailID
                                                    // select x).Distinct().ToListAsync();
                                                     //***********  الكود السابق قبل merge 14/8/2024
                                               //     select x).Distinct().CountAsync();
            //int Notreaded_internell_externl_count = Notreaded_internell_externl;//.Count();
            //*********************14/8/2024
                                                     join y in DbCon.Sends.Where(y => y.flag == 2 && y.resendfrom != ManagementId) on x.MailID equals y.MailID
                                                     join p in DbCon.Departments.Where(p => p.state == true && p.perent != ManagementId) on y.to equals p.Id
                                                  //***********14/8/2024 
                                                   //  select x).Distinct().ToListAsync();
            //int Notreaded_internell_externl_count = Notreaded_internell_externl.Count();
              select x).Distinct().CountAsync();
            int Notreaded_internell_externl_count = Notreaded_internell_externl;//.Count();
            //**********end 14/8/2024

            //////////////////////////////////////////////////////////////////////////////////////////
            /////////////// مجموع الصادر الخارجي //////////////

            var Totale_externl = await (from x in DbCon.Mails.Where(x => x.Department_Id == ManagementId && x.Mail_Type == 2 && x.state == true)
                                            // join y in DbCon.Sends.Where(y => y.flag >= 1) on x.MailID equals y.MailID
                                            //select x).Distinct().ToListAsync();
                                        //     select x).Distinct().CountAsync();
            //int Totale_externl_count = Totale_externl;//.Count();

               join y in DbCon.Sends.Where(y => y.flag >= 1 && y.resendfrom != ManagementId) on x.MailID equals y.MailID
                                        join p in DbCon.Departments.Where(p => p.state == true && p.perent != ManagementId) on y.to equals p.Id
//***************14/8/2024 
                                      //  select x).Distinct().ToListAsync();
           // int Totale_externl_count = Totale_externl.Count();
             select x).Distinct().CountAsync();
            int Totale_externl_count = Totale_externl;
            //*****end 14/8/2024

            //////////// مجموع الصادر الخارجي التي لم يقرائ //////////////
           // var Notreaded_Totale_externl = await (from x in DbCon.Mails.Where(x => x.Department_Id == ManagementId && x.Mail_Type == 2 && x.state == true)
                        //                          join y in DbCon.Sends.Where(y => y.flag == 2) on x.MailID equals y.MailID
                                            //      //select x).Distinct().ToListAsync();
                                                //  select x).Distinct().CountAsync();
            //int Notreaded_Totale_externl_count = Notreaded_Totale_externl;//.Count();
                                     

            //////////// مجموع الصادر الخارجي التي لم يقرائ //////////////
            var Notreaded_Totale_externl = await (from x in DbCon.Mails.Where(x => x.Department_Id == ManagementId && x.Mail_Type == 2 && x.state == true)
                                                  join y in DbCon.Sends.Where(y => y.flag == 2 && y.resendfrom != ManagementId) on x.MailID equals y.MailID
                                                  join p in DbCon.Departments.Where(p => p.state == true && p.perent != ManagementId) on y.to equals p.Id
                                              //***********14/8/2024
                                                //  select x).Distinct().ToListAsync();
           // int Notreaded_Totale_externl_count = Notreaded_Totale_externl.Count();
             select x).Distinct().CountAsync();
            int Notreaded_Totale_externl_count = Notreaded_Totale_externl;
            //*****end 14/8/2024

            ///////////////////////////////////////////////////////////////////////////////////////////
            /////////////// مجموع  الوارد الخارجي //////////////
            var Totale_inbox = await (from x in DbCon.Mails.Where(x => x.Department_Id == ManagementId && x.Mail_Type == 3 && x.state == true)
                                      //    //  join y in DbCon.Sends.Where(y => y.flag >= 1) on x.MailID equals y.MailID
                                      //    //select x).Distinct().ToListAsync();
                                      //   select x).Distinct().CountAsync();
           // int Totale_inbox_count = Totale_inbox;//.Count();
                                      join y in DbCon.Sends.Where(y => y.flag >= 1 && y.resendfrom != ManagementId) on x.MailID equals y.MailID
                                      join p in DbCon.Departments.Where(p => p.state == true && p.perent != ManagementId) on y.to equals p.Id

                                      select x).Distinct().CountAsync();//.ToListAsync();
            int Totale_inbox_count = Totale_inbox;//.Count();

            ///////////////  مجموع الوارد الخارجي التي لم يقرائ //////////////

            var Notreaded_Totale_inbox = await (from x in DbCon.Mails.Where(x => x.Department_Id == ManagementId && x.Mail_Type == 3 && x.state == true)
                                              //  join y in DbCon.Sends.Where(y => y.flag == 2) on x.MailID equals y.MailID
                                             //   //select x).Distinct().ToListAsync();
                                              //  select x).Distinct().CountAsync();
           // int Notreaded_Totale_inbox_count = Notreaded_Totale_inbox;//.Count();
                                                join y in DbCon.Sends.Where(y => y.flag == 2 && y.resendfrom != ManagementId) on x.MailID equals y.MailID
                                                join p in DbCon.Departments.Where(p => p.state == true && p.perent != ManagementId) on y.to equals p.Id

                                                select x).Distinct().CountAsync();//.ToListAsync();
            int Notreaded_Totale_inbox_count = Notreaded_Totale_inbox;//.Count();







            /////////////////////////////// الوارد ////////////////////////////////////////////



            //////////////////////////////////////////////////////////////////////////////////////
            //////////// مجموع  الداخلي //////////////
            var Totale_Internal_inbox = await (from x in DbCon.Mails.Where(x => x.Mail_Type == 1)
                                               join p in DbCon.Departments.Where(p => p.state == true && p.perent != ManagementId) on x.Department_Id equals p.Id
                                               join y in DbCon.Sends.Where(y => y.flag > 1 && y.to == ManagementId && y.State.Equals(true)) on x.MailID equals y.MailID

                                               select x).ToListAsync();
            int Totale_Internal_inbox_count = Totale_Internal_inbox.Count();
            //////////// مجموع  الداخلي التي لم تقرائ//////////////
            var Notreaded_Totale_Internal_inbox = await (from x in DbCon.Mails.Where(x => x.Mail_Type == 1)
                                                         join p in DbCon.Departments.Where(p => p.state == true && p.perent != ManagementId) on x.Department_Id equals p.Id
                                                         join y in DbCon.Sends.Where(y => y.flag == 2 && y.to == ManagementId && y.State.Equals(true)) on x.MailID equals y.MailID
                                                         select x).ToListAsync();
            int Notreaded_Totale_Internal_inbox_count = Notreaded_Totale_Internal_inbox.Count();




            //////////// مجموع الصادر الخارجي //////////////
            var Total_externl2 = await (from x in DbCon.Mails.Where(x => x.Mail_Type == 2)
                                        join p in DbCon.Departments.Where(p => p.state == true && p.perent != ManagementId) on x.Department_Id equals p.Id
                                        join y in DbCon.Sends.Where(y => y.flag > 1 && y.to == ManagementId && y.State.Equals(true)) on x.MailID equals y.MailID
                                        select x).ToListAsync();
            int Total_externl2_count = Total_externl2.Count();
            //////////// مجموع الصادر الخارجي التي لم تقرائ//////////////
            var Notreaded_Total_externl2 = await (from x in DbCon.Mails.Where(x => x.Mail_Type == 2)
                                                  join p in DbCon.Departments.Where(p => p.state == true && p.perent != ManagementId) on x.Department_Id equals p.Id
                                                  join y in DbCon.Sends.Where(y => y.flag == 2 && y.to == ManagementId && y.State.Equals(true)) on x.MailID equals y.MailID
                                                  select x).ToListAsync();
            int Notreaded_Total_externl2_count = Notreaded_Total_externl2.Count();




            //////////// مجموع الوارد الخارجي //////////////
            var Totale_inbox2 = await (from x in DbCon.Mails.Where(x => x.Mail_Type == 3)
                                       join p in DbCon.Departments.Where(p => p.state == true && p.perent != ManagementId) on x.Department_Id equals p.Id
                                       join y in DbCon.Sends.Where(y => y.flag > 1 && y.to == ManagementId && y.State.Equals(true)) on x.MailID equals y.MailID
                                       select x).ToListAsync();
            int Totale_inbox2_count = Totale_inbox2.Count();
            //////////// مجموع الوارد الخارجي التي لم تقرائ//////////////
            var Notreaded_Totale_inbox2 = await (from x in DbCon.Mails.Where(x => x.Mail_Type == 3)
                                                 join p in DbCon.Departments.Where(p => p.state == true && p.perent != ManagementId) on x.Department_Id equals p.Id
                                                 join y in DbCon.Sends.Where(y => y.flag == 2 && y.to == ManagementId && y.State.Equals(true)) on x.MailID equals y.MailID
                                                 select x).ToListAsync();
            int Notreaded_Totale_inbox2_count = Notreaded_Totale_inbox2.Count();






            ////////// الصادر
            ///
            Dashbord.Totale_internell_externl = Totale_internell_externl_count;
            Dashbord.Notreaded_internell_externl = Notreaded_internell_externl_count;
            Dashbord.Totale_externl = Totale_externl_count;
            Dashbord.Notreaded_Totale_externl = Notreaded_Totale_externl_count;
            Dashbord.Totale_inbox = Totale_inbox_count;
            Dashbord.Notreaded_Totale_inbox = Notreaded_Totale_inbox_count;

            //////////الوارد
            ///
            Dashbord.Totale_Internal_inbox = Totale_Internal_inbox_count;
            Dashbord.Notreaded_Totale_Internal_inbox = Notreaded_Totale_Internal_inbox_count;
            Dashbord.Total_externl2 = Total_externl2_count;
            Dashbord.Notreaded_Total_externl2 = Notreaded_Total_externl2_count;
            Dashbord.Totale_inbox2 = Totale_inbox2_count;
            Dashbord.Notreaded_Totale_inbox2 = Notreaded_Totale_inbox2_count;


            return Dashbord;
        }

        public async Task<Dashbord> GetDashbordofSections(int ManagementId)
        {
            Dashbord Dashbord = new Dashbord();
          




            ////////////////////////////   الصاادر   //////////////////////////////////////

            //////////// مجموع  الداخلي //////////////

            var Totale_internell_externl = await (from x in DbCon.Mails.Where(x => x.state == true && x.Mail_Type == 1 )
                                                  join y in DbCon.Sends.Where(y => y.flag >= 1 ) on x.MailID equals y.MailID
                                                  join p in DbCon.Departments.Where(p=>p.state==true && p.perent==ManagementId) on y.to equals p.Id
                                                  select x).Distinct().ToListAsync();

           
            
            int Totale_internell_externl_count = Totale_internell_externl.Count() /*+ Totale_Internal_inbox.Count()*/; ;

            //////////// مجموع  الداخلي التي لم يقرائ //////////////

            var Notreaded_internell_externl = await (from x in DbCon.Mails.Where(x => x.Mail_Type == 1 && x.state == true)
                                                     join y in DbCon.Sends.Where(y => y.flag ==2 ) on x.MailID equals y.MailID
                                                     join p in DbCon.Departments.Where(p => p.state == true && p.perent == ManagementId) on y.to equals p.Id
                                                     select x).Distinct().ToListAsync();


            int Notreaded_internell_externl_count = Notreaded_internell_externl.Count();

            //////////////////////////////////////////////////////////////////////////////////////////
            /////////////// مجموع الصادر الخارجي //////////////

            var Totale_externl = await (from x in DbCon.Mails.Where(x => x.Department_Id == ManagementId && x.Mail_Type == 2 && x.state == true)
                                        join y in DbCon.Sends.Where(y => y.flag >= 1) on x.MailID equals y.MailID
                                        join p in DbCon.Departments.Where(p => p.state == true && p.perent == ManagementId) on y.to equals p.Id
                                        select x).Distinct().ToListAsync();
            int Totale_externl_count = Totale_externl.Count();

            //////////// مجموع الصادر الخارجي التي لم يقرائ //////////////
            var Notreaded_Totale_externl = await (from x in DbCon.Mails.Where(x =>  x.Mail_Type == 2 && x.state == true)
                                                  join y in DbCon.Sends.Where(y => y.flag == 2) on x.MailID equals y.MailID
                                                  join p in DbCon.Departments.Where(p => p.state == true && p.perent == ManagementId) on y.to equals p.Id
                                                  select x).Distinct().ToListAsync();
            int Notreaded_Totale_externl_count = Notreaded_Totale_externl.Count();

            ///////////////////////////////////////////////////////////////////////////////////////////
            /////////////// مجموع  الوارد الخارجي //////////////
            var Totale_inbox = await (from x in DbCon.Mails.Where(x => x.Department_Id == ManagementId && x.Mail_Type == 3 && x.state == true)
                                      join y in DbCon.Sends.Where(y => y.flag >= 1) on x.MailID equals y.MailID
                                      join p in DbCon.Departments.Where(p => p.state == true && p.perent == ManagementId) on y.to equals p.Id
                                      select x).Distinct().ToListAsync();
            int Totale_inbox_count = Totale_inbox.Count();

            ///////////////  مجموع الوارد الخارجي التي لم يقرائ //////////////

            var Notreaded_Totale_inbox = await (from x in DbCon.Mails.Where(x => x.Mail_Type == 3 && x.state == true)
                                                join y in DbCon.Sends.Where(y => y.flag == 2) on x.MailID equals y.MailID
                                                join p in DbCon.Departments.Where(p => p.state == true && p.perent == ManagementId) on y.to equals p.Id
                                                select x).Distinct().ToListAsync();
            int Notreaded_Totale_inbox_count = Notreaded_Totale_inbox.Count();







            /////////////////////////////// الوارد ////////////////////////////////////////////



            //////////////////////////////////////////////////////////////////////////////////////
            //////////// مجموع  الداخلي //////////////
            var Totale_Internal_inbox = await (from x in DbCon.Mails.Where(x => x.Mail_Type == 1)
                                               join p in DbCon.Departments.Where(p => p.state == true && p.perent==ManagementId) on x.Department_Id equals p.Id
                                               join y in DbCon.Sends.Where(y => y.flag > 1 && y.to == ManagementId && y.State.Equals(true)) on x.MailID equals y.MailID
                                               select x).ToListAsync();
            int Totale_Internal_inbox_count = Totale_Internal_inbox.Count();
            //////////// مجموع  الداخلي التي لم تقرائ//////////////
            var Notreaded_Totale_Internal_inbox = await (from x in DbCon.Mails.Where(x => x.Mail_Type == 1)
                                                         join p in DbCon.Departments.Where(p => p.state == true && p.perent == ManagementId) on x.Department_Id equals p.Id
                                                         join y in DbCon.Sends.Where(y => y.flag == 2 && y.to == ManagementId && y.State.Equals(true)) on x.MailID equals y.MailID

                                                         select x).ToListAsync();
            int Notreaded_Totale_Internal_inbox_count = Notreaded_Totale_Internal_inbox.Count();




            //////////// مجموع الصادر الخارجي //////////////
            var Total_externl2 = await (from x in DbCon.Mails.Where(x => x.Mail_Type == 2)
                                        join p in DbCon.Departments.Where(p => p.state == true && p.perent == ManagementId) on x.Department_Id equals p.Id
                                        join y in DbCon.Sends.Where(y => y.flag > 1 && y.to == ManagementId && y.State.Equals(true)) on x.MailID equals y.MailID
                                        select x).ToListAsync();
            int Total_externl2_count = Total_externl2.Count();
            //////////// مجموع الصادر الخارجي التي لم تقرائ//////////////
            var Notreaded_Total_externl2 = await (from x in DbCon.Mails.Where(x => x.Mail_Type == 2)
                                                  join p in DbCon.Departments.Where(p => p.state == true && p.perent == ManagementId) on x.Department_Id equals p.Id
                                                  join y in DbCon.Sends.Where(y => y.flag == 2 && y.to == ManagementId && y.State.Equals(true)) on x.MailID equals y.MailID
                                                  select x).ToListAsync();
            int Notreaded_Total_externl2_count = Notreaded_Total_externl2.Count();




            //////////// مجموع الوارد الخارجي //////////////
            var Totale_inbox2 = await (from x in DbCon.Mails.Where(x => x.Mail_Type == 3)
                                       join p in DbCon.Departments.Where(p => p.state == true && p.perent == ManagementId) on x.Department_Id equals p.Id
                                       join y in DbCon.Sends.Where(y => y.flag > 1 && y.to == ManagementId && y.State.Equals(true)) on x.MailID equals y.MailID
                                       select x).ToListAsync();
            int Totale_inbox2_count = Totale_inbox2.Count();
            //////////// مجموع الوارد الخارجي التي لم تقرائ//////////////
            var Notreaded_Totale_inbox2 = await (from x in DbCon.Mails.Where(x => x.Mail_Type == 3)
                                                 join p in DbCon.Departments.Where(p => p.state == true && p.perent == ManagementId) on x.Department_Id equals p.Id
                                                 join y in DbCon.Sends.Where(y => y.flag == 2 && y.to == ManagementId && y.State.Equals(true)) on x.MailID equals y.MailID
                                                 select x).ToListAsync();
            int Notreaded_Totale_inbox2_count = Notreaded_Totale_inbox2.Count();






            ////////// الصادر
            ///
            Dashbord.Totale_internell_externl = Totale_internell_externl_count;
            Dashbord.Notreaded_internell_externl = Notreaded_internell_externl_count;
            Dashbord.Totale_externl = Totale_externl_count;
            Dashbord.Notreaded_Totale_externl = Notreaded_Totale_externl_count;
            Dashbord.Totale_inbox = Totale_inbox_count;
            Dashbord.Notreaded_Totale_inbox = Notreaded_Totale_inbox_count;

            //////////الوارد
            ///
            Dashbord.Totale_Internal_inbox = Totale_Internal_inbox_count;
            Dashbord.Notreaded_Totale_Internal_inbox = Notreaded_Totale_Internal_inbox_count;
            Dashbord.Total_externl2 = Total_externl2_count;
            Dashbord.Notreaded_Total_externl2 = Notreaded_Total_externl2_count;
            Dashbord.Totale_inbox2 = Totale_inbox2_count;
            Dashbord.Notreaded_Totale_inbox2 = Notreaded_Totale_inbox2_count;


            return Dashbord;
        }
    }
}
