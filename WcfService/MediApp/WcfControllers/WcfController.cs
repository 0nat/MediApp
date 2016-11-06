﻿using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using System.Web;
using EntityModels; 

namespace MediApp.WcfControllers
{
    public static class WcfController
    {
        static DbServices.PatientsContext db = new DbServices.PatientsContext(WcfConfig.WcfUri);

        public static bool checkIfExist(string email)
        {
            try
            {
                if (1 == db.TableUser.Where(p => p.Email == email.ToLower()).Count())
                    return true;

                return false;
            }
            catch(InvalidOperationException e)
            {
                return false;
            }            
        }
        public static bool authenticateUser(string login, byte[] password)
        {
            if (!checkIfExist(login))
                return false;

            var pat = db.TableUser.Where(p => p.Email == login.ToLower()).First();

            if (null == pat.Pass)
                return false;

            return pat.Pass.SequenceEqual(password);
        }

        public static void createPatient(User user)
        {
            
            var userWcf = new DbServices.User
            {
                
                FstName = user.FstName,
                Surname = user.Surname,
                Email = user.Email,
                Pass = user.Pass
            };
            
            try
            {
                db.AddToTableUser(userWcf);

                DataServiceResponse response = db.SaveChanges();
                foreach (ChangeOperationResponse change in response)
                {
                    EntityDescriptor descriptor = change.Descriptor as EntityDescriptor;

                    if (descriptor != null)
                    {
                        DbServices.User added= descriptor.Entity as DbServices.User;

                        if (added != null)
                        {
                            Console.WriteLine("New patient added with email {0}.",
                                added.Email);
                        }
                    }
                }

            }
            catch (DataServiceRequestException ex)
            {
                throw new ApplicationException(
                    "An error occurred when saving changes.", ex);
            }
        }
    }
}