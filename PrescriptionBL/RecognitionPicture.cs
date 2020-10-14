using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrescriptionBE;
using PrescriptionDAL;
using PrescriptionDAL.RegonitionPicture;

namespace PrescriptionBL
{
    class RecognitionPicture
    {
        public List<string> GetPicturesTags(string path)
        {
            List<string> Result = new List<string>();
            ImageDetails DrugImage = new ImageDetails(path);
            PicuresTags p = new PicuresTags();
            p.GetPicturesTags(DrugImage);//DAL
            var threshold = 50.0;
            foreach (var item in DrugImage.Details)
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
