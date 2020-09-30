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
    class BLImplement : IBL
    {
        
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
                IDal dal = new PrescriptionDAL.DalImplement();
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
                IDal dal = new PrescriptionDAL.DalImplement();
                dal.updateAdministrator(administrator);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IEnumerable<Administrator> getAllAdministrators()
        {
            IDal dal = new PrescriptionDAL.DalImplement();
            return dal.getAllAdministrators();
        }

        //------------ Doctors ---------------
        public void addDoctor(Doctor doctor)
        {
            try
            {
                IDal dal = new PrescriptionDAL.DalImplement();
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
                IDal dal = new PrescriptionDAL.DalImplement();
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
                IDal dal = new PrescriptionDAL.DalImplement();
                dal.addDoctor(doctor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Doctor> getAllDoctors()
        {
            IDal dal = new PrescriptionDAL.DalImplement();
            return dal.getAllDoctors();
        }
        public IEnumerable<Prescription> allPrescriptionByDoctor(Doctor doctor)
        {
            IDal dal = new PrescriptionDAL.DalImplement();
            return dal.getAllPrescriptions().Where(prescription => prescription.Doctor == doctor.Id);
        }

        //------------ Medicines ---------------
        public void addMedicine(Medicine medicine)
        {
            try
            {
                IDal dal = new PrescriptionDAL.DalImplement();
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
                IDal dal = new PrescriptionDAL.DalImplement();
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
                IDal dal = new PrescriptionDAL.DalImplement();
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
                IDal dal = new PrescriptionDAL.DalImplement();
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
                IDal dal = new PrescriptionDAL.DalImplement();
                dal.updateMedicinePicture(medicineId,file);
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
                IDal dal = new PrescriptionDAL.DalImplement();
                return dal.getMedicinePicture(medicinId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Medicine> getAllMedicines()
        {
            IDal dal = new PrescriptionDAL.DalImplement();
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
                IDal dal = new PrescriptionDAL.DalImplement();
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
                IDal dal = new PrescriptionDAL.DalImplement();
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
                IDal dal = new PrescriptionDAL.DalImplement();
                dal.updatePatient(patient);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Patient> getAllPatients()
        {
            IDal dal = new PrescriptionDAL.DalImplement();
            return dal.getAllPatients();
        }

        //------------ Prescriptions ---------------
        public void addPrescription(Prescription prescription)
        {
            IDal dal = new PrescriptionDAL.DalImplement();
            //Checks if the doctor's license is valid
            if (dal.getAllDoctors().ToList().Find(d => d.Id == prescription.Id).License.ExpirationDate >= DateTime.Today)
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
            IDal dal = new PrescriptionDAL.DalImplement();
            return dal.getAllPrescriptions();
        }
        public IEnumerable<Prescription> allPrescriptionFromPatient(Patient patient)
        {
            IDal dal = new PrescriptionDAL.DalImplement();
            return dal.getAllPrescriptions().Where(prescription => prescription.Patient == patient.Id);
        }


        //------------ Specialties ---------------
        public void addSpecialty(Specialty specialty)
        {
            try
            {
                IDal dal = new PrescriptionDAL.DalImplement();
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
                IDal dal = new PrescriptionDAL.DalImplement();
                dal.deleteSpecialty(specialty);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Specialty> getAllSpecialties()
        {
            IDal dal = new PrescriptionDAL.DalImplement();
            return dal.getAllSpecialties();
        }

        

    }
}
