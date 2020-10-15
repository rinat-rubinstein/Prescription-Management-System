using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using PrescriptionBE;

namespace PrescriptionDAL.MedicineInteraction
{
    class MedicineInteractionHelper
    {
        private string checkDrugs(string medicine, long id, DateTime start, DateTime end) //שם תרופה, תז פציינט, תאריך התחלה, תאריך סיום
        {
            IDal dal = new PrescriptionDAL.DalImplement();
            string ndc = (from x in dal.getAllMedicines() where x.Name == medicine select x.GenericName).First();
            string siteContent = string.Empty;
            string url = "https://rxnav.nlm.nih.gov/REST/rxcui?idtype=NDC&id=" + ndc;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())  // Go query google
            using (Stream responseStream = response.GetResponseStream())               // Load the response stream
            using (StreamReader streamReader = new StreamReader(responseStream))       // Load the stream reader to read the response
            {
                siteContent = streamReader.ReadToEnd(); // Read the entire response and store it in the siteContent variable
            }
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(siteContent);
            XmlNodeList xnList = doc.SelectNodes("/rxnormdata/idGroup");
            string rxcui = string.Empty;
            string tmp2 = string.Empty;
            if (xnList[0]["rxnormId"] != null)//the drug has rxcui code
            {
                rxcui = xnList[0]["rxnormId"].InnerText;
                //find all the other drugs the patient use
                List<string> rxcuis = new List<string>();
                List<Prescription> allPrescription = (from x in dal.getAllPrescriptions() where x.Patient == id.ToString() select x).ToList();
                foreach (Prescription p in allPrescription)
                {
                    if (!((p.StartDate < start && p.EndDate < start) || (p.StartDate > end)))//משתמש בתרופה אחרת במקביל לתרופה החדשה
                    {
                        Medicine m = (from x in dal.getAllMedicines() where x.Id == p.medicine select x).First();
                        url = "https://rxnav.nlm.nih.gov/REST/rxcui?idtype=NDC&id=" + m.GenericName;
                        request = (HttpWebRequest)WebRequest.Create(url);
                        request.AutomaticDecompression = DecompressionMethods.GZip;

                        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())  // Go query google
                        using (Stream responseStream = response.GetResponseStream())               // Load the response stream
                        using (StreamReader streamReader = new StreamReader(responseStream))       // Load the stream reader to read the response
                        {
                            siteContent = streamReader.ReadToEnd();
                        }
                        doc.LoadXml(siteContent);
                        xnList = doc.SelectNodes("/rxnormdata/idGroup");
                        if (xnList[0]["rxnormId"] != null)
                            rxcuis.Add(xnList[0]["rxnormId"].InnerText);

                    }
                }
                string tmp = string.Empty;
                for (int i = 0; i < rxcuis.Count; i++)
                {
                    tmp = tmp + "+" + rxcuis[i];

                };
                url = "https://rxnav.nlm.nih.gov/REST/interaction/list.json?rxcuis=" + rxcui + tmp;
                request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())  // Go query google
                using (Stream responseStream = response.GetResponseStream())               // Load the response stream
                using (StreamReader streamReader = new StreamReader(responseStream))       // Load the stream reader to read the response
                {
                    siteContent = streamReader.ReadToEnd();
                }

                RootMedicionInteraction DetailsTree = JsonConvert.DeserializeObject<RootMedicionInteraction>(siteContent);

                foreach (FullInteractionType fullI in DetailsTree.fullInteractionTypeGroup[0].fullInteractionType)
                {
                    tmp2 = tmp2 + fullI.interactionPair[0].description + "\n";
                }

                foreach (FullInteractionType fullI in DetailsTree.fullInteractionTypeGroup[0].fullInteractionType)
                {
                    if (fullI.interactionPair[0].severity == "high")
                        throw new Exception("The severity is high");
                }

            }
            return tmp2;
        }
    }
}
