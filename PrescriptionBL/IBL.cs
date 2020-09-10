using PrescriptionBE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrescriptionBL
{
    /// <summary>
    /// add more functions of course, these are just the basic fanctions for the mean time
    /// </summary>
    public interface IBL
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
        IEnumerable<Prescription> allPrescriptionByDoctor(Doctor doctor);

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
        IEnumerable<Prescription> allPrescriptionFromPatient(Patient patient);

        //------------ Specialties ---------------
        void addSpecialty(Specialty specialty);
        void deleteSpecialty(Specialty specialty);
        IEnumerable<Specialty> getAllSpecialties();
    }
}
