using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using PrescriptionBE;
using PrescriptionBL;
namespace PrescriptionUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //IBL bl = new BLImplement();
            //bl.addAdministrator(new Administrator { UserName = "Manager", Password = "12345678" });
            //bl.ImportDataFromExcel();
            //bl.addSpecialty(new Specialty() { SpecialtyName = "Anesthesiology" });
            //bl.addSpecialty(new Specialty() { SpecialtyName = "Cardiology" });
            //bl.addSpecialty(new Specialty() { SpecialtyName = "Dermatology" });
            //bl.addSpecialty(new Specialty() { SpecialtyName = "Endocrinology" });
            //bl.addSpecialty(new Specialty() { SpecialtyName = "Physician" });
            //bl.addSpecialty(new Specialty() { SpecialtyName = "Gastroenterology" });
            //bl.addSpecialty(new Specialty() { SpecialtyName = "Geriatric Medicine Speciality" });
            //bl.addSpecialty(new Specialty() { SpecialtyName = "Hematology" });
            //bl.addSpecialty(new Specialty() { SpecialtyName = "Internism" });
            //bl.addSpecialty(new Specialty() { SpecialtyName = "Nephrology" });
            //bl.addSpecialty(new Specialty() { SpecialtyName = "Neurology" });
            //bl.addSpecialty(new Specialty() { SpecialtyName = "Gynecology" });
            //bl.addSpecialty(new Specialty() { SpecialtyName = "Oncology" });
            //bl.addSpecialty(new Specialty() { SpecialtyName = "Osteopath" });
            //bl.addSpecialty(new Specialty() { SpecialtyName = "Otolaryngology" });
            //bl.addSpecialty(new Specialty() { SpecialtyName = "Pathology" });
            //bl.addSpecialty(new Specialty() { SpecialtyName = "Pediatricia" });
            //bl.addSpecialty(new Specialty() { SpecialtyName = "Ophthalmology" });
            //bl.addSpecialty(new Specialty() { SpecialtyName = "Physiatrist" });
            //bl.addSpecialty(new Specialty() { SpecialtyName = "Plastic Surgeon" });
            //bl.addSpecialty(new Specialty() { SpecialtyName = "Podiatrist" });
            //bl.addSpecialty(new Specialty() { SpecialtyName = "Psychiatry" });
            //bl.addSpecialty(new Specialty() { SpecialtyName = "Pulmonology" });
            //bl.addSpecialty(new Specialty() { SpecialtyName = "Radiology" });
            //bl.addSpecialty(new Specialty() { SpecialtyName = "Rheumatology" });
            //bl.addSpecialty(new Specialty() { SpecialtyName = "Urologist" });
            //bl.addDoctor(new Doctor { DoctorId = "326636296", LicenseExpirationDate = DateTime.Now.AddDays(879), Name = "Racheli Bloch", Special = bl.getAllSpecialties().FirstOrDefault(s => s.SpecialtyName == "Cardiology").Id });
            //bl.addDoctor(new Doctor { DoctorId = "212456785", LicenseExpirationDate = DateTime.Now.AddDays(333), Name = "Rinat Rubinstein", Special = bl.getAllSpecialties().FirstOrDefault(s => s.SpecialtyName == "Dermatology").Id });
            //bl.addDoctor(new Doctor { DoctorId = "012359638", LicenseExpirationDate = DateTime.Now.AddDays(298), Name = "Chana Indig", Special = bl.getAllSpecialties().FirstOrDefault(s => s.SpecialtyName == "Anesthesiology").Id });
            //bl.addDoctor(new Doctor { DoctorId = "322630252", LicenseExpirationDate = DateTime.Now.AddDays(150), Name = "Ruth Fridman", Special = bl.getAllSpecialties().FirstOrDefault(s => s.SpecialtyName == "Ophthalmology").Id });
            //bl.addDoctor(new Doctor { DoctorId = "356678907", LicenseExpirationDate = DateTime.Now.AddDays(689), Name = "Avi Levi", Special = bl.getAllSpecialties().FirstOrDefault(s => s.SpecialtyName == "Rheumatology").Id });
            //bl.addDoctor(new Doctor { DoctorId = "025792797", LicenseExpirationDate = DateTime.Now.AddDays(3000), Name = "Shay Nitzan", Special = bl.getAllSpecialties().FirstOrDefault(s => s.SpecialtyName == "Cardiology").Id });
            //bl.addDoctor(new Doctor { DoctorId = "327258652", LicenseExpirationDate = DateTime.Now.AddDays(879), Name = "Malenia Trump", Special = bl.getAllSpecialties().FirstOrDefault(s => s.SpecialtyName == "Oncology").Id });
            //bl.addDoctor(new Doctor { DoctorId = "017895243", LicenseExpirationDate = DateTime.Now.AddDays(8000), Name = "Donald J Trump", Special = bl.getAllSpecialties().FirstOrDefault(s => s.SpecialtyName == "Psychiatry").Id });
            //bl.addDoctor(new Doctor { DoctorId = "321760151", LicenseExpirationDate = DateTime.Now.AddDays(2000), Name = "Thomas Edison", Special = bl.getAllSpecialties().FirstOrDefault(s => s.SpecialtyName == "Pathology").Id });
            //bl.addDoctor(new Doctor { DoctorId = "233620393", LicenseExpirationDate = DateTime.Now.AddDays(777), Name = "Grahm Bell", Special = bl.getAllSpecialties().FirstOrDefault(s => s.SpecialtyName == "Rheumatology").Id });
            //bl.addDoctor(new Doctor { DoctorId = "028910329", LicenseExpirationDate = DateTime.Now.AddDays(9000), Name = "Benjamin Netanyahu", Special = bl.getAllSpecialties().FirstOrDefault(s => s.SpecialtyName == "Urologist").Id });
            //bl.addDoctor(new Doctor { DoctorId = "211521114", LicenseExpirationDate = DateTime.Now.AddDays(5090), Name = "Albert Aienstein", Special = bl.getAllSpecialties().FirstOrDefault(s => s.SpecialtyName == "Pulmonology").Id });
            //bl.addDoctor(new Doctor { DoctorId = "128919329", LicenseExpirationDate = DateTime.Now.AddDays(650), Name = "Isaac Newton", Special = bl.getAllSpecialties().FirstOrDefault(s => s.SpecialtyName == "Cardiology").Id });
            //bl.addDoctor(new Doctor { DoctorId = "252036223", LicenseExpirationDate = DateTime.Now.AddDays(950), Name = "Shimon Peres", Special = bl.getAllSpecialties().FirstOrDefault(s => s.SpecialtyName == "Podiatrist").Id });
            //bl.addDoctor(new Doctor { DoctorId = "381298710", LicenseExpirationDate = DateTime.Now.AddDays(1467), Name = "Sara Netanyahu", Special = bl.getAllSpecialties().FirstOrDefault(s => s.SpecialtyName == "Psychiatry").Id });
            //bl.addPatient(new Patient { PatientId = "286564248", Name = "Reuven Cohen" });
            //bl.addPatient(new Patient { PatientId = "023497427", Name = "Ofra Efroni" });
            //bl.addPatient(new Patient { PatientId = "342683839", Name = "Shay Man" });
            //bl.addPatient(new Patient { PatientId = "386564248", Name = "Sheli Lev" });
            //bl.addPatient(new Patient { PatientId = "281564248", Name = "Debi Weiss" });
            //bl.addPatient(new Patient { PatientId = "023457427", Name = "Sara Ram" });
            //bl.addPatient(new Patient { PatientId = "344683839", Name = "Dani Ordman" });
            //bl.addPatient(new Patient { PatientId = "383569248", Name = "Shevi Levi" });
            //bl.addPatient(new Patient { PatientId = "016564248", Name = "Tamar Braun" });
            //bl.addPatient(new Patient { PatientId = "323497427", Name = "Eli Gafni" });
            //bl.addPatient(new Patient { PatientId = "342638839", Name = "Shani Fine" });
            //bl.addPatient(new Patient { PatientId = "343564169", Name = "Shalom Israel" });
            //bl.addPatient(new Patient { PatientId = "345764248", Name = "Israel Israeli" });
            //bl.addPatient(new Patient { PatientId = "023672427", Name = "Ofra Levi" });
            //bl.addPatient(new Patient { PatientId = "395327839", Name = "David Ber" });
            //bl.addPatient(new Patient { PatientId = "386394248", Name = "Yael Frid" });
            //bl.addPatient(new Patient { PatientId = "286564568", Name = "Rachel Rubin" });
            //bl.addPatient(new Patient { PatientId = "028997427", Name = "Ita Kahn" });
            //bl.addPatient(new Patient { PatientId = "342593839", Name = "Natan Fucs" });
            //bl.addPatient(new Patient { PatientId = "386563948", Name = "Tali Zaguri" });
            //bl.addPatient(new Patient { PatientId = "283464248", Name = "Yoni Tzur" });
            //bl.addPatient(new Patient { PatientId = "023424427", Name = "Ari Ravinski" });
            //bl.addPatient(new Patient { PatientId = "342656839", Name = "Dan Sinai" });
            //bl.addPrescription(new Prescription { Patient = "286564248", Doctor = "326636296", Cause = "pain", StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(5), medicine = 34 });
            //bl.addPrescription(new Prescription { Patient = "342683839", Doctor = "012359638", Cause = "fever", StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(3), medicine = 67 });
            //bl.addPrescription(new Prescription { Patient = "786564248", Doctor = "356678907", Cause = "aches", StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(10), medicine = 5 });
            //bl.addPrescription(new Prescription { Patient = "023497427", Doctor = "212456785", Cause = "infection", StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(8), medicine = 24 });
            //bl.addPrescription(new Prescription { Patient = "342656839", Doctor = "326636296", Cause = "pain", StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(5), medicine = 74 });
            //bl.addPrescription(new Prescription { Patient = "023424427", Doctor = "012359638", Cause = "fever", StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(3), medicine = 12 });
            //bl.addPrescription(new Prescription { Patient = "283464248", Doctor = "356678907", Cause = "aches", StartDate = DateTime.Today.AddDays(3), EndDate = DateTime.Today.AddDays(10), medicine = 45 });
            //bl.addPrescription(new Prescription { Patient = "386563948", Doctor = "212456785", Cause = "infection", StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(8), medicine = 97 });
            //bl.addPrescription(new Prescription { Patient = "386394248", Doctor = "326636296", Cause = "pain", StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(5), medicine = 34 });
            //bl.addPrescription(new Prescription { Patient = "023672427", Doctor = "012359638", Cause = "fever", StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(3), medicine = 77 });
            //bl.addPrescription(new Prescription { Patient = "342638839", Doctor = "356678907", Cause = "aches", StartDate = DateTime.Today.AddDays(3), EndDate = DateTime.Today.AddDays(10), medicine = 4 });
            //bl.addPrescription(new Prescription { Patient = "023497427", Doctor = "212456785", Cause = "infection", StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(8), medicine = 29 });
            //bl.addPrescription(new Prescription { Patient = "286564248", Doctor = "326636296", Cause = "pain", StartDate = DateTime.Today.AddDays(3), EndDate = DateTime.Today.AddDays(5), medicine = 37 });
            //bl.addPrescription(new Prescription { Patient = "342683839", Doctor = "012359638", Cause = "fever", StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(3), medicine = 63 });
            //bl.addPrescription(new Prescription { Patient = "386564248", Doctor = "356678907", Cause = "aches", StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(10), medicine = 25 });
            //bl.addPrescription(new Prescription { Patient = "342638839", Doctor = "212456785", Cause = "infection", StartDate = DateTime.Today.AddDays(5), EndDate = DateTime.Today.AddDays(8), medicine = 84 });

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
