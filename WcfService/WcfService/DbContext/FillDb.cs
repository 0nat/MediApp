﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityModels;

namespace WcfService.DbContext
{
    public class FillDb
    {
        public FillDb()
        {
            using (var db = new PatientsContext())
            {
                var users = db.Set<User>();
                User u = new User { Email = "abc@rak.pl" };
                User u1 = new User { Email = "efg@hiv.pl" };

                users.Add(u);
                users.Add(u1);

                db.SaveChanges();

                
                var roles = db.Set<Role>();
                Role r = new Role { Name = RolesKind.PATIENT, Users = db.TableUser.ToList() };
                Role r1 = new Role { Name = RolesKind.MEDIC };
                Role r3 = new Role { Name = RolesKind.ADMIN };

                roles.Add(r);
                roles.Add(r1);
                roles.Add(r3);

                db.SaveChanges();

                Patient patient = new Patient {  Height = 180, Sex = true };
                Patient patient1 = new Patient { Height = 160, Sex = true };
                var patients = db.Set<Patient>();
                patients.Add(patient);
                patients.Add(patient1);

                db.SaveChanges();

                Illness i1 = new Illness { Name = "Grypa" };
                Illness i2 = new Illness { Name = "Rak" };
                Illness i3 = new Illness { Name = "Rzeżączka" };

                var illness = db.Set<Illness>();
                illness.Add(i1);
                illness.Add(i2);
                illness.Add(i3);

                db.SaveChanges();

                var patientwassick = db.Set<PatientWasSick>();
                patientwassick.Add(new PatientWasSick { Date = DateTime.Now,Illness = i1,Patient = patient });
                patientwassick.Add(new PatientWasSick { Date = DateTime.Now, Illness = i2, Patient = patient });
                patientwassick.Add(new PatientWasSick { Date = DateTime.Now, Illness = i3, Patient = patient1 });

                db.SaveChanges();
            }
        }
    }
}