using PrescriptionBE;
using PrescriptionDAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PrescriptionBL
{
    public class BLImplement : IBL
    {
        IDal dal = new PrescriptionDAL.DalImplement();

        //------------ Administrators ---------------
        public void addAdministrator(Administrator administrator)
        {
            try
            {
                IDal dal = new PrescriptionDAL.DalImplement();
                dal.addAdministrator(administrator);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void deleteAdministrator(Administrator administrator)
        {
            try
            {
                dal.deleteAdministrator(administrator);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void updateAdministrator(Administrator administrator)
        {
            try
            {
                dal.updateAdministrator(administrator);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IEnumerable<Administrator> getAllAdministrators()
        {
            return dal.getAllAdministrators();
        }

        //------------ Doctors ---------------
        public void addDoctor(Doctor doctor)
        {
            try
            {
                dal.addDoctor(doctor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void deleteDoctor(Doctor doctor)
        {
            try
            {
                dal.deleteDoctor(doctor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void updateDoctor(Doctor doctor)
        {
            try
            {
                dal.updateDoctor(doctor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Doctor> getAllDoctors()
        {
            return dal.getAllDoctors();
        }
        public IEnumerable<Prescription> allPrescriptionByDoctor(Doctor doctor)
        {
            return dal.getAllPrescriptions().Where(prescription => prescription.Doctor == doctor.Id);
        }

        //------------ Medicines ---------------
        public void addMedicine(Medicine medicine)
        {
            try
            {
                dal.addMedicine(medicine);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void addMedicine(Medicine medicine, HttpPostedFileBase file)
        {
            try
            {
                string filePath = Path.Combine(HttpContext.Current.Server.MapPath("~/GoogleDriveFiles"),
                Path.GetFileName(file.FileName));
                if (!validMedicinePicture(filePath))
                    throw new Exception("the picture does not contain a medicine");
                dal.addMedicine(medicine, file);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void deleteMedicine(Medicine medicine)
        {
            try
            {
                dal.deleteMedicine(medicine);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void updateMedicine(Medicine medicine)
        {
            try
            {
                dal.updateMedicine(medicine);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void updateMedicinePicture(int medicineId, HttpPostedFileBase file)
        {
            try
            {
                string filePath = Path.Combine(HttpContext.Current.Server.MapPath("~/GoogleDriveFiles"),
                Path.GetFileName(file.FileName));
                if (!validMedicinePicture(filePath))
                    throw new Exception("the picture does not contain a medicine");
                dal.updateMedicinePicture(medicineId, file);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string getMedicinePicture(int medicinId)
        {
            try
            {
                return dal.getMedicinePicture(medicinId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Medicine> getAllMedicines()
        {
            return dal.getAllMedicines();
        }

        /// <summary>
        /// check if the picture is of medicine, using IMAGA api (chanale this for you...)
        /// </summary>
        /// <returns></returns>
        private bool validMedicinePicture(string path)
        {
            throw new NotImplementedException();
        }

        //------------ Patients ---------------
        public void addPatient(Patient patient)
        {
            try
            {
                dal.addPatient(patient);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void deletePatient(Patient patient)
        {
            try
            {
                dal.deletePatient(patient);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void updatePatient(Patient patient)
        {
            try
            {
                dal.updatePatient(patient);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Patient> getAllPatients()
        {
            return dal.getAllPatients();
        }

        //------------ Prescriptions ---------------
        public void addPrescription(Prescription prescription)
        {
            //Checks if the doctor's license is valid
            if (dal.getAllDoctors().ToList().Find(d => d.Id == prescription.Doctor).LicenseExpirationDate >= DateTime.Today)
            {
                try
                {
                    dal.addPrescription(prescription);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                throw new Exception("The the doctor's license is not valid ");
            }
        }
        public IEnumerable<Prescription> getAllPrescriptions()
        {
            return dal.getAllPrescriptions();
        }
        public IEnumerable<Prescription> allPrescriptionFromPatient(Patient patient)
        {
            return dal.getAllPrescriptions().Where(prescription => prescription.Patient == patient.Id);
        }


        //------------ Specialties ---------------
        public void addSpecialty(Specialty specialty)
        {
            try
            {
                dal.addSpecialty(specialty);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void deleteSpecialty(Specialty specialty)
        {
            try
            {
                dal.deleteSpecialty(specialty);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Specialty> getAllSpecialties()
        {
            return dal.getAllSpecialties();
        }

        public int medicinePerPeriod(string medicine, DateTime startDate, DateTime endDate)
        {
            /*
            int medicineId = dal.getAllMedicines().FirstOrDefault(m => m.Name == medicine).Id;
            return dal.getAllPrescriptions().Count(prescription => prescription.StartDate >= startDate && prescription.StartDate <= endDate && prescription.medicine.Exists(m => m == medicineId));
            */
            return 1;
        }

        public bool isAdministrator(string password, string username)
        {
            return dal.getAllAdministrators().ToList().Exists(admin => admin.Password == password && admin.UserName == username);
        }
    }
}