using Microsoft.Office.Interop.Excel;
using PrescriptionBE;
using PrescriptionDAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using _Excel = Microsoft.Office.Interop.Excel;


namespace PrescriptionBL
{


    public class BLImplement : IBL
    {

        //------------ Administrators ---------------
        public void addAdministrator(Administrator administrator)
        {
            try
            {
                IDal dal = new DalImplement();
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
                dal.updateDoctor(doctor);
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
        public Medicine getMedicine(int medicineID)
        {
            return this.getAllMedicines().Where(medicine => medicine.Id == medicineID).FirstOrDefault();
        }
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
            RecognitionPicture r = new RecognitionPicture();
            List<string> tagsPictures =r.GetPicturesTags(path);
            foreach (var item in tagsPictures)
            {
                if (item == "medicine" || item == "drug" || item == "pill" || item == "medicines" || item == "drugs" || item == "pills")
                    return true;
            }
            return false;
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

        //------------ Statistics ---------------
        private int[,] medicinTokenWeekAgo(IEnumerable<int> medicinesID)
        {
            int[,] weekmat = new int[medicinesID.Count(), 1];
            DateTime weekAgo = DateTime.Today.AddDays(-7);
            int i = 0;
            foreach (var medicineID in medicinesID)
            {
                weekmat[i, 0] = (from prescription in this.getAllPrescriptions()
                                 where prescription.medicine == medicineID
                                 && ((prescription.StartDate <= weekAgo && prescription.EndDate > weekAgo) || (prescription.StartDate > weekAgo && prescription.StartDate < DateTime.Today))
                                 select prescription).Count();
                i++;
            }
            return weekmat;
        }
        /// <summary>
        /// calculate the total number of patients take one of the medicines the func reseives to the last X months
        /// </summary>
        /// <param name="medicinesID">list of medicines to calculate</param>
        /// <param name="X">to the last X months</param>
        /// <returns></returns>
        private int[][] medicinTokenXMonthAgo(IEnumerable<int> medicinesID, int X, ref string[] medicineNamesArr)
        {
            int[][] XMonthAgoMat = new int[medicinesID.Count()][];
            int i = 0;
            //initialize the matrix to 0
            for (i = 0; i < medicinesID.Count(); i++)
            {
                XMonthAgoMat[i] = new int[X];
                for (int j = 0; j < X; j++)
                {
                    XMonthAgoMat[i][j] = 0;
                }
            }
            DateTime XMonthAgo = DateTime.Today.AddMonths(-X);
            i = 0;
            foreach (var medicineID in medicinesID)
            {
                medicineNamesArr[i] = this.getMedicine(medicineID).Name;
                foreach (var prescription in this.getAllPrescriptions())
                {
                    if (prescription.medicine == medicineID && ((prescription.StartDate <= XMonthAgo && prescription.EndDate > XMonthAgo) || (prescription.StartDate > XMonthAgo && prescription.StartDate < DateTime.Today)))
                    {
                        int beginMonth = X - this.GetMonthsBetween(prescription.StartDate, DateTime.Now) - 1;
                        int endMonth = X - this.GetMonthsBetween(prescription.EndDate, DateTime.Now) - 1;

                        for (int j = beginMonth; j <= endMonth; j++)
                        {
                            if (j >= 0 && j < X)
                            {
                                XMonthAgoMat[i][j]++;
                            }
                        }
                    }
                }
                i++;
            }
            return XMonthAgoMat;
        }
        private int GetMonthsBetween(DateTime start, DateTime end)
        {
            return ((end.Month + end.Year * 12) - (start.Month + start.Year * 12));
        }
        /// <summary>
        /// send empty string[] for the 'medicineNamesArr', we will fill it with the appropriate data
        /// </summary>
        /// <param name="medicinesID"></param>
        /// <param name="numMonthAgo"></param>
        /// <param name="medicineNamesArr"></param>
        /// <returns></returns>
        public int[][] MedicinesStatistics(IEnumerable<int> medicinesID, int numMonthAgo, ref string[] medicineNamesArr)
        {
            medicineNamesArr = new string[medicinesID.Count()];
            return medicinTokenXMonthAgo(medicinesID, numMonthAgo, ref medicineNamesArr);          
        }

        public int medicinePerPeriod(string medicine, DateTime startDate, DateTime endDate)
        {
            IDal dal = new PrescriptionDAL.DalImplement();
            int medicineId = dal.getAllMedicines().FirstOrDefault(m => m.Name == medicine).Id;
            return dal.getAllPrescriptions().Count(prescription => prescription.StartDate >= startDate && prescription.StartDate <= endDate && prescription.medicine==medicineId);
        }

        public bool isAdministrator(string username, string password)
        {
            IDal dal = new PrescriptionDAL.DalImplement();
            return dal.getAllAdministrators().ToList().Exists(admin => admin.Password == password && admin.UserName == username);
        }
        public Administrator getAdministrator(string id)
        {
            return getAllAdministrators().FirstOrDefault(administrator => administrator.Id == id);
        }

        public Doctor getDoctor(string id)
        {
            return getAllDoctors().FirstOrDefault(doc => doc.Id == id);
        }
        
        public Prescription getPrescription(int id)
        {
            return getAllPrescriptions().FirstOrDefault(p => p.Id == id);

        }
        public Specialty getSpecialty(int id)
        {
            return getAllSpecialties().FirstOrDefault(s => s.Id == id);
        }
        public Patient getPatient(string id)
        {
            return getAllPatients().FirstOrDefault(patient => patient.Id == id);
        }

        public void ImportDataFromExcel()
        {
            {
                string FilePath = "C:\\Users\\aannr\\Desktop\\‏‏תיקיה חדשה\\prescription-management-system\\medicine.xlsx";
                _Application excel = new _Excel.Application();
                Workbook wb = excel.Workbooks.Open(FilePath);
                Worksheet ws = wb.Worksheets[1];

                string name = string.Empty, genericName = string.Empty, producer = string.Empty, active = string.Empty, properties = string.Empty, ndc = string.Empty;
                for (int i = 2; i < 1001; i++)
                {
                    name = Convert.ToString(ws.Cells[1][i].Value2);
                    genericName = Convert.ToString(ws.Cells[2][i].Value2);
                    producer = Convert.ToString(ws.Cells[3][i].Value2);
                    active = Convert.ToString(ws.Cells[4][i].Value2);
                    properties = Convert.ToString(ws.Cells[5][i].Value2);
                    ndc = Convert.ToString(ws.Cells[7][i].Value2);
                    using (var context = new PrescriptionContext())
                    {
                        var medicine = new Medicine { PortionProperties = properties, ActiveIngredients = active, GenericName = ndc, Name = name, Producer = producer };
                        context.Medicines.Add(medicine);
                        context.SaveChanges();
                    }
                }
            }
        }

        public Administrator getAdministrator()
        {
            return getAllAdministrators().FirstOrDefault();
        }
        public void doctorEntrance(string name, string id)
        {
            if (getAllDoctors().ToList().Exists(d => d.Id == id && d.Name == name))
            {
                if (!getAllDoctors().ToList().Exists(d => d.Id == id && d.LicenseExpirationDate >= DateTime.Today))
                {
                    throw new Exception("The license has expired");
                }
            }
            else
                throw new Exception("Incorrect Details");
        }
    }
}
