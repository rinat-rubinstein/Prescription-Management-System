using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrescriptionBE;
using PrescriptionDAL;

namespace PrescriptionBL
{
    public class ImagesTagsLogic
    {
        public List<string> GetTags(string path)
        {
            List<string> Result = new List<string>();
            ImageDetails DrugImage = new ImageDetails(path);
            ImageAnalysis dal = new ImageAnalysis();
            dal.GetTags(DrugImage);
            var threshold = 60.0;
            foreach(var item in DrugImage.Details)
            {
                if (item.Value > threshold)
                {
                    Result.Add(item.Key);
                }
                else
                    break;
            }
            return Result;
        }
    }
}
