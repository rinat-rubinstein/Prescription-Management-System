using PrescriptionBE;
using PrescriptionDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrescriptionBL
{
    class BLImplement: IBL
    {
        IDal dal = DalFactory.getDal();
        //------------ Administrators ---------------
        void IBL.addAdministrator(Administrator administrator)
        {
            throw new NotImplementedException();
        }
        void IBL.deleteAdministrator(Administrator administrator)
        {
            throw new NotImplementedException();
        }
        void IBL.updateAdministrator(Administrator administrator)
        {
            throw new NotImplementedException();
        }
        IEnumerable<Administrator> IBL.getAllAdministrators()
        {
            throw new NotImplementedException();
        }

        //------------ Doctors ---------------
        void IBL.addDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }
        void IBL.deleteDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }
        void IBL.updateDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }
        IEnumerable<Doctor> IBL.getAllDoctors()
        {
            throw new NotImplementedException();
        }

        //------------ Medicines ---------------
        void IBL.addMedicine(Medicine medicine)
        {
            throw new NotImplementedException();
        }
        void IBL.deleteMedicine(Medicine medicine)
        {
            throw new NotImplementedException();
        }
        void IBL.updateMedicine(Medicine medicine)
        {
            throw new NotImplementedException();
        }
        IEnumerable<Medicine> IBL.getAllMedicines()
        {
            throw new NotImplementedException();
        }

        //------------ Patients ---------------
        void IBL.addPatient(Patient patient)
        {
            throw new NotImplementedException();
        }
        void IBL.deletePatient(Patient patient)
        {
            throw new NotImplementedException();
        }
        void IBL.updatePatient(Patient patient)
        {
            throw new NotImplementedException();
        }
        IEnumerable<Patient> IBL.getAllPatients()
        {
            throw new NotImplementedException();
        }

        //------------ Prescriptions ---------------
        void IBL.addPrescription(Prescription prescription)
        {
            throw new NotImplementedException();
        }
        IEnumerable<Prescription> IBL.getAllPrescriptions()
        {
            throw new NotImplementedException();
        }

        //------------ Specialties ---------------
        void IBL.addSpecialty(Specialty specialty)
        {
            throw new NotImplementedException();
        }
        void IBL.deleteSpecialty(Specialty specialty)
        {
            throw new NotImplementedException();
        }
        IEnumerable<Specialty> IBL.getAllSpecialties()
        {
            throw new NotImplementedException();
        }
    }
}
