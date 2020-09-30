using Newtonsoft.Json;
using PrescriptionBE;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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
            PrescriptionContext db = new PrescriptionContext();
            if (db.Administrators.ToList().Exists(admin => admin.Id == administrator.Id))
            {
                db.Administrators.Remove(administrator);
                db.SaveChanges();

            }
            else
            {
                throw new Exception("This administrator does not exist");
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
            PrescriptionContext db = new PrescriptionContext();
            if (db.Medicines.ToList().Exists(mdn => mdn.Id == medicine.Id))
            {
                db.Medicines.Remove(medicine);
                db.SaveChanges();
                GoogleDriveAPIHelper gd = new GoogleDriveAPIHelper();
                gd.deleteFile(medicine.Id.ToString());
            }
            else
            {
                throw new Exception("This medicine does not exist");
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
        public void GetPicturesTags(ImageDetails curentImage)
        {
            string apiKey = "acc_0179023530ce71a";
            string apiSecret = "0b76efe4d5500a74f4dd49a699405170";
            string image = curentImage.ImagePath;

            string basicAuthValue = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(String.Format("{0}:{1}", apiKey, apiSecret)));

            var client = new RestClient("https://api.imagga.com/v2/tags");
            client.Timeout = -1;

            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", String.Format("Basic {0}", basicAuthValue));
            request.AddFile("image", image);

            IRestResponse response = client.Execute(request);
            Root TagList = JsonConvert.DeserializeObject<Root>(response.Content);
            foreach (var item in TagList.result.tags)
            {
                curentImage.Details.Add(item.tag.en, item.confidence);
            }
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
        public IEnumerable<Specialty> getAllSpecialties()
        {
            PrescriptionContext db = new PrescriptionContext();
            return db.Specialties;
        }


    }
    public class PrescriptionContext : DbContext
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
