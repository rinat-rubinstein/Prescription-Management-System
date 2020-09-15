using Newtonsoft.Json;
using PrescriptionBE;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrescriptionDAL
{
    public class ImageAnalysis
    {
        public void GetTags(ImageDetails curentImage)
        {
            string apiKey = "acc_0179023530ce71a";
            string apiSecret = "0b76efe4d5500a74f4dd49a699405170";
            string image = curentImage.ImagePath;

            string basicAuthValue = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(String.Format("{0}:{1}", apiKey, apiSecret)));

            var client = new RestClient("https://api.imagga.com/v2/tags");
            client.Timeout = -1;

            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", String.Format("Basic {0}", basicAuthValue));
            request.AddFile("image", image);

            IRestResponse response = client.Execute(request);
            Root TagList = JsonConvert.DeserializeObject<Root>(response.Content); 
            foreach(var item in TagList.result.tags)
            {
                curentImage.Details.Add(item.tag.en, item.confidence);
            }
        }
          
    }
}
