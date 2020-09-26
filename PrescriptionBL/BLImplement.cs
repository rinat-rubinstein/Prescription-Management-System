using PrescriptionBE;
using PrescriptionDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrescriptionBL
{
    class BLImplement : IBL
    {
        PrescriptionDAL.IDal dal = new PrescriptionDAL.DalImplement();
        //------------ Administrators ---------------
        void IBL.addAdministrator(Administrator administrator)
        {
            try
            {
                dal.addAdministrator(administrator);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void IBL.deleteAdministrator(Administrator administrator)
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
        void IBL.updateAdministrator(Administrator administrator)
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
        IEnumerable<Administrator> IBL.getAllAdministrators()
        {
            return dal.getAllAdministrators();
        }

        //------------ Doctors ---------------
        void IBL.addDoctor(Doctor doctor)
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
        void IBL.deleteDoctor(Doctor doctor)
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
        void IBL.updateDoctor(Doctor doctor)
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
        IEnumerable<Doctor> IBL.getAllDoctors()
        {
            return dal.getAllDoctors();
        }
        IEnumerable<Prescription> IBL.allPrescriptionByDoctor(Doctor doctor)
        {
            return dal.getAllPrescriptions().Where(prescription => prescription.Doctor == doctor.Id);
        }

        //------------ Medicines ---------------
        void IBL.addMedicine(Medicine medicine)
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
        void IBL.deleteMedicine(Medicine medicine)
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
        void IBL.updateMedicine(Medicine medicine)
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
        IEnumerable<Medicine> IBL.getAllMedicines()
        {
            return dal.getAllMedicines();
        }

        //------------ Patients ---------------
        void IBL.addPatient(Patient patient)
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
        void IBL.deletePatient(Patient patient)
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
        void IBL.updatePatient(Patient patient)
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
        IEnumerable<Patient> IBL.getAllPatients()
        {
            return dal.getAllPatients();
        }

        //------------ Prescriptions ---------------
        void IBL.addPrescription(Prescription prescription)
        {
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
        IEnumerable<Prescription> IBL.getAllPrescriptions()
        {
            return dal.getAllPrescriptions();
        }
        IEnumerable<Prescription> IBL.allPrescriptionFromPatient(Patient patient)
        {
            return dal.getAllPrescriptions().Where(prescription => prescription.Patient == patient.Id);
        }


        //------------ Specialties ---------------
        void IBL.addSpecialty(Specialty specialty)
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
        void IBL.deleteSpecialty(Specialty specialty)
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
        IEnumerable<Specialty> IBL.getAllSpecialties()
        {
            return dal.getAllSpecialties();
        }

        

    }
}
