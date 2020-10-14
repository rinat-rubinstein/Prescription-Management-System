using Newtonsoft.Json;
using PrescriptionBE;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PrescriptionDAL
{
    public class DalImplement : IDal
    {
        //------------ Administrators ---------------
        public void addAdministrator(Administrator administrator)
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
        public void deleteAdministrator(Administrator administrator)
        {
            using (var context = new PrescriptionContext())
            {
                if (context.Administrators.ToList().Exists(admin => admin.Id == administrator.Id))
                {
                    var deletedAdministrator = context.Administrators.Where(a => a.Id == administrator.Id).FirstOrDefault();
                    context.Administrators.Remove(deletedAdministrator);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This administrator does not exist");
                }
            }


        }
        public void updateAdministrator(Administrator administrator)
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
        public IEnumerable<Administrator> getAllAdministrators()
        {
            PrescriptionContext db = new PrescriptionContext();
            return db.Administrators;
        }

        //------------ Doctors ---------------
        public void addDoctor(Doctor doctor)
        {
            PrescriptionContext db = new PrescriptionContext();
            if (db.Doctors.ToList().Exists(doc => doc.Id == doctor.Id))
            {
                throw new Exception("This doctor exists already");
            }
            else
            {
                db.Doctors.Add(doctor);
                db.SaveChanges();
            }
        }
        public void deleteDoctor(Doctor doctor)
        {
            using (var context = new PrescriptionContext())
            {
                if (context.Doctors.ToList().Exists(doc => doc.Id == doctor.Id))
                {
                    var deletedDoctor = context.Doctors.Where(doc => doc.Id == doctor.Id).FirstOrDefault();
                    context.Doctors.Remove(deletedDoctor);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This doctor does not exist");
                }
            }
        }
        public void updateDoctor(Doctor doctor)
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
        public IEnumerable<Doctor> getAllDoctors()
        {
            PrescriptionContext db = new PrescriptionContext();
            return db.Doctors;
        }

        //------------ Medicines ---------------
        public void addMedicine(Medicine medicine)
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
        public void addMedicine(Medicine medicine, HttpPostedFileBase file)
        {
            this.addMedicine(medicine);
            GoogleDriveAPIHelper gd = new GoogleDriveAPIHelper();
            gd.UplaodFileOnDriveInFolder(file, medicine.Id.ToString(), "cloudComputing");
        }
        public void deleteMedicine(Medicine medicine)
        {
            using (var context = new PrescriptionContext())
            {
                if (context.Medicines.ToList().Exists(mdn => mdn.Id == medicine.Id))
                {
                    var deletedMedicine = context.Medicines.Where(m => m.Id == medicine.Id).FirstOrDefault();
                    context.Medicines.Remove(deletedMedicine);
                    context.SaveChanges();
                    GoogleDriveAPIHelper gd = new GoogleDriveAPIHelper();
                    gd.deleteFile(medicine.Id.ToString());
                }
                else
                {
                    throw new Exception("This medicine does not exist");
                }
            }
        }
        public void updateMedicine(Medicine medicine)
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
        public void updateMedicinePicture(int medicineId, HttpPostedFileBase file)
        {
            GoogleDriveAPIHelper gd = new GoogleDriveAPIHelper();
            gd.deleteAllFiles(medicineId.ToString());
            gd.UplaodFileOnDriveInFolder(file, medicineId.ToString(), "cloudComputing");
        }
        public string getMedicinePicture(int medicinId)
        {
            GoogleDriveAPIHelper gd = new GoogleDriveAPIHelper();
            return gd.DownloadGoogleFileByName(medicinId.ToString());
        }
        public IEnumerable<Medicine> getAllMedicines()
        {
            PrescriptionContext db = new PrescriptionContext();
            return db.Medicines;
        }

        //------------ Patients ---------------
        public void addPatient(Patient patient)
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
        public void deletePatient(Patient patient)
        {
            using (var context = new PrescriptionContext())
            {
                if (context.Patients.ToList().Exists(pt => pt.Id == patient.Id))
                {
                    var deletedPatient = context.Patients.Where(pt => pt.Id == patient.Id).FirstOrDefault();
                    context.Patients.Remove(deletedPatient);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This patient does not exist");
                }
            }
        }

        public void updatePatient(Patient patient)
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
        public IEnumerable<Patient> getAllPatients()
        {
            PrescriptionContext db = new PrescriptionContext();
            return db.Patients;
        }

        //------------ Prescriptions ---------------
        public void addPrescription(Prescription prescription)
        {
            PrescriptionContext db = new PrescriptionContext();
            if (db.Prescriptions.ToList().Exists(prs => prs.Id == prescription.Id))
            {
                throw new Exception("This prescription exsits already");
            }
            else
            {
                db.Prescriptions.Add(prescription);
                db.SaveChanges();
            }
        }
        public IEnumerable<Prescription> getAllPrescriptions()
        {
            PrescriptionContext db = new PrescriptionContext();
            return db.Prescriptions;
        }

        //------------ Specialties ---------------
        public void addSpecialty(Specialty specialty)
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
        public void deleteSpecialty(Specialty specialty)
        {
            using (var context = new PrescriptionContext())
            {
                if (context.Specialties.ToList().Exists(s => s.Id == specialty.Id))
                {
                    var deletedSpecialty = context.Specialties.Where(pt => pt.Id == specialty.Id).FirstOrDefault();
                    context.Specialties.Remove(deletedSpecialty);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This patient does not exist");
                }
            }
        }
        public IEnumerable<Specialty> getAllSpecialties()
        {
            PrescriptionContext db = new PrescriptionContext();
            return db.Specialties;
        }


    }
    public class PrescriptionContext : DbContext
    {
        public PrescriptionContext() : base("PrescriptionContext") { }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<PrescriptionContext>(new DropCreateDatabaseIfModelChanges<PrescriptionContext>());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        private void FixEfProviderServicesProblem()
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

    }
}