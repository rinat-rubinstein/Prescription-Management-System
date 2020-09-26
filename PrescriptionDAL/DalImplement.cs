using PrescriptionBE;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrescriptionDAL
{
   public class DalImplement: IDal
    {
        //------------ Administrators ---------------
        void IDal.addAdministrator(Administrator administrator)
        {
            PrescriptionContext db = new PrescriptionContext();
            if (db.Administrators.ToList().Exists(admin => admin.Id == administrator.Id))
            {
                throw new Exception("This administrator exists already");
            }
            else
            {
                db.Administrators.Add(administrator);
                db.SaveChanges();
            }
           

        }
        void IDal.deleteAdministrator(Administrator administrator)
        {
            PrescriptionContext db = new PrescriptionContext();
            if (db.Administrators.ToList().Exists(admin=> admin.Id==administrator.Id))
            {
                db.Administrators.Remove(administrator);
                db.SaveChanges();

            }
            else
            {
                throw new Exception("This administrator does not exist");
            }
        }
        void IDal.updateAdministrator(Administrator administrator)
        {
            PrescriptionContext db = new PrescriptionContext();
            if (db.Administrators.ToList().Exists(admin => admin.Id == administrator.Id))
            {
                db.Administrators.AddOrUpdate(administrator);
                db.SaveChanges();
            }
            else
            {
                throw new Exception("This administrator does not exist");
            }
        }
        IEnumerable<Administrator> IDal.getAllAdministrators()
        {
            PrescriptionContext db = new PrescriptionContext();
            return db.Administrators;
        }

        //------------ Doctors ---------------
        void IDal.addDoctor(Doctor doctor)
        {
            PrescriptionContext db = new PrescriptionContext();
            if (db.Doctors.ToList().Exists(doc=>doc.Id==doctor.Id))
            {
                throw new Exception("This doctor exists already");
            }
            else
            {
                db.Doctors.Add(doctor);
                db.SaveChanges();
            }
        }
        void IDal.deleteDoctor(Doctor doctor)
        {
            PrescriptionContext db = new PrescriptionContext();
            if (db.Doctors.ToList().Exists(doc => doc.Id == doctor.Id))
            {
                db.Doctors.Remove(doctor);
                db.SaveChanges();
            }
            else
            {
                throw new Exception("This doctor does not exist");
            }
        }
        void IDal.updateDoctor(Doctor doctor)
        {
            PrescriptionContext db = new PrescriptionContext();
            if (db.Doctors.ToList().Exists(doc => doc.Id == doctor.Id))
            {
                db.Doctors.AddOrUpdate(doctor);
                db.SaveChanges();
            }
            else
            {
                throw new Exception("This doctor does not exist");
            }
        }
        IEnumerable<Doctor> IDal.getAllDoctors()
        {
            PrescriptionContext db = new PrescriptionContext();
            return db.Doctors;
        }

        //------------ Medicines ---------------
        void IDal.addMedicine(Medicine medicine)
        {
            PrescriptionContext db = new PrescriptionContext();
            if (db.Medicines.ToList().Exists(mdn => mdn.Id == medicine.Id))
            {
                throw new Exception("This medicine exists already");
            }
            else
            {
                db.Medicines.Add(medicine);
                db.SaveChanges();
            }
        }
        void IDal.deleteMedicine(Medicine medicine)
        {
            PrescriptionContext db = new PrescriptionContext();
            if (db.Medicines.ToList().Exists(mdn => mdn.Id == medicine.Id))
            {
                db.Medicines.Remove(medicine);
                db.SaveChanges();
            }
            else
            {
                throw new Exception("This medicine does not exist");
            }
        }
        void IDal.updateMedicine(Medicine medicine)
        {
            PrescriptionContext db = new PrescriptionContext();
            if (db.Medicines.ToList().Exists(mdn => mdn.Id == medicine.Id))
            {
                db.Medicines.AddOrUpdate(medicine);
                db.SaveChanges();
            }
            else
            {
                throw new Exception("This medicine does not exist");
            }
        }
        IEnumerable<Medicine> IDal.getAllMedicines()
        {
            PrescriptionContext db = new PrescriptionContext();
            return db.Medicines;
        }

        //------------ Patients ---------------
        void IDal.addPatient(Patient patient)
        {
            PrescriptionContext db = new PrescriptionContext();
            if (db.Patients.ToList().Exists(pt => pt.Id == patient.Id))
            {
                throw new Exception("This patient exists already");
            }
            else
            {
                db.Patients.Add(patient);
                db.SaveChanges();
            }
        }
        void IDal.deletePatient(Patient patient)
        {
            PrescriptionContext db = new PrescriptionContext();
            if (db.Patients.ToList().Exists(pt => pt.Id == patient.Id))
            {
                db.Patients.Remove(patient);
                db.SaveChanges();
            }
            else
            {
                throw new Exception("This patient does not exist");
            }
        }
        void IDal.updatePatient(Patient patient)
        {
            PrescriptionContext db = new PrescriptionContext();
            if (db.Patients.ToList().Exists(pt => pt.Id == patient.Id))
            {
                db.Patients.AddOrUpdate(patient);
                db.SaveChanges();
            }
            else
            {
                throw new Exception("This patient does not exist");
            }
        }
        IEnumerable<Patient> IDal.getAllPatients()
        {
            PrescriptionContext db = new PrescriptionContext();
            return db.Patients;
        }

        //------------ Prescriptions ---------------
        void IDal.addPrescription(Prescription prescription)
        {
            PrescriptionContext db = new PrescriptionContext();
            if(db.Prescriptions.ToList().Exists(prs=> prs.Id==prescription.Id))
            {
                throw new Exception("This prescription exsits already");
            }
            else
            {
                db.Prescriptions.Add(prescription);
                db.SaveChanges();
            }
        }
        IEnumerable<Prescription> IDal.getAllPrescriptions()
        {
            PrescriptionContext db = new PrescriptionContext();
            return db.Prescriptions;
        }

        //------------ Specialties ---------------
        void IDal.addSpecialty(Specialty specialty)
        {
            PrescriptionContext db = new PrescriptionContext();
            if (db.Specialties.ToList().Exists(spc => spc.Id == specialty.Id))
            {
                throw new Exception("This specialty exsits already");
            }
            else
            {
                db.Specialties.Add(specialty);
                db.SaveChanges();
            }
        }
        void IDal.deleteSpecialty(Specialty specialty)
        {
            PrescriptionContext db = new PrescriptionContext();
            if (db.Prescriptions.ToList().Exists(spc => spc.Id == specialty.Id))
            {
                throw new Exception("This specialty exsits already");
            }
            else
            {
                db.Specialties.Add(specialty);
                db.SaveChanges();
            }
        }
        IEnumerable<Specialty> IDal.getAllSpecialties()
        {
            PrescriptionContext db = new PrescriptionContext();
            return db.Specialties;
        }
    }
    public class PrescriptionContext:DbContext
    {
        public PrescriptionContext() : base() { }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Specialty> Specialties { get; set; }



    }
}
