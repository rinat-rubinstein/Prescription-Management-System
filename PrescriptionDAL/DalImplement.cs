using PrescriptionBE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrescriptionDAL
{
    class DalImplement: IDal
    {
        //------------ Administrators ---------------
        void IDal.addAdministrator(Administrator administrator)
        {
            throw new NotImplementedException();
        }
        void IDal.deleteAdministrator(Administrator administrator)
        {
            throw new NotImplementedException();
        }
        void IDal.updateAdministrator(Administrator administrator)
        {
            throw new NotImplementedException();
        }
        IEnumerable<Administrator> IDal.getAllAdministrators()
        {
            throw new NotImplementedException();
        }

        //------------ Doctors ---------------
        void IDal.addDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }
        void IDal.deleteDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }
        void IDal.updateDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }
        IEnumerable<Doctor> IDal.getAllDoctors()
        {
            throw new NotImplementedException();
        }

        //------------ Medicines ---------------
        void IDal.addMedicine(Medicine medicine)
        {
            throw new NotImplementedException();
        }
        void IDal.deleteMedicine(Medicine medicine)
        {
            throw new NotImplementedException();
        }
        void IDal.updateMedicine(Medicine medicine)
        {
            throw new NotImplementedException();
        }
        IEnumerable<Medicine> IDal.getAllMedicines()
        {
            throw new NotImplementedException();
        }

        //------------ Patients ---------------
        void IDal.addPatient(Patient patient)
        {
            throw new NotImplementedException();
        }
        void IDal.deletePatient(Patient patient)
        {
            throw new NotImplementedException();
        }
        void IDal.updatePatient(Patient patient)
        {
            throw new NotImplementedException();
        }
        IEnumerable<Patient> IDal.getAllPatients()
        {
            throw new NotImplementedException();
        }

        //------------ Prescriptions ---------------
        void IDal.addPrescription(Prescription prescription)
        {
            throw new NotImplementedException();
        }
        IEnumerable<Prescription> IDal.getAllPrescriptions()
        {
            throw new NotImplementedException();
        }

        //------------ Specialties ---------------
        void IDal.addSpecialty(Specialty specialty)
        {
            throw new NotImplementedException();
        }
        void IDal.deleteSpecialty(Specialty specialty)
        {
            throw new NotImplementedException();
        }
        IEnumerable<Specialty> IDal.getAllSpecialties()
        {
            throw new NotImplementedException();
        }
    }
}
