using PrescriptionBE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrescriptionDAL
{
    public interface IDal
    {
        //------------ Administrators ---------------
        void addAdministrator(Administrator administrator);
        void deleteAdministrator(Administrator administrator);
        void updateAdministrator(Administrator administrator);
        IEnumerable<Administrator> getAllAdministrators();

        //------------ Doctors ---------------
        void addDoctor(Doctor doctor);
        void deleteDoctor(Doctor doctor);
        void updateDoctor(Doctor doctor);
        IEnumerable<Doctor> getAllDoctors();

        //------------ Medicines ---------------
        void addMedicine(Medicine medicine);
        void deleteMedicine(Medicine medicine);
        void updateMedicine(Medicine medicine);
        IEnumerable<Medicine> getAllMedicines();

        //------------ Patients ---------------
        void addPatient(Patient patient);
        void deletePatient(Patient patient);
        void updatePatient(Patient patient);
        IEnumerable<Patient> getAllPatients();

        //------------ Prescriptions ---------------
        void addPrescription(Prescription prescription);
        IEnumerable<Prescription> getAllPrescriptions();

        //------------ Specialties ---------------
        void addSpecialty(Specialty specialty);
        void deleteSpecialty(Specialty specialty);
        IEnumerable<Specialty> getAllSpecialties();
    }
}
