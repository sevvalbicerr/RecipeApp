using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Service.Helpers
{
    public static class ImageHelper
    {
        public static byte[] GetBytesFromImageUrl(string imageUrl)
        {
            byte[] imageData = null;

            try
            {
                using (var wc = new WebClient())
                {
                    imageData = wc.DownloadData(imageUrl);
                }
            }
            catch (Exception ex)
            {
                // Handle exception here
            }

            return imageData;
        }
    }
}
