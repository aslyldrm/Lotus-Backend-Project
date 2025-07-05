using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dictionary
{
    public static class FetusPictureDictionary
    {
        private static readonly Dictionary<int, string> FetusPictureUrls = new Dictionary<int, string>
        {
            { 1, "C:\\Users\\GRNT\\source\\repos\\LotusProject\\Entities\\PregnantPictures\\1.jpg" },
            { 2, "C:\\Users\\GRNT\\source\\repos\\LotusProject\\Entities\\PregnantPictures\\2.jpg" },
            { 3, "C:\\Users\\GRNT\\source\\repos\\LotusProject\\Entities\\PregnantPictures\\3.jpg" },
            { 4, "C:\\Users\\GRNT\\source\\repos\\LotusProject\\Entities\\PregnantPictures\\4.jpg" },
            { 5, "C:\\Users\\GRNT\\source\\repos\\LotusProject\\Entities\\PregnantPictures\\5.jpg" },
            { 6, "C:\\Users\\GRNT\\source\\repos\\LotusProject\\Entities\\PregnantPictures\\6.jpg" },
            { 7, "C:\\Users\\GRNT\\source\\repos\\LotusProject\\Entities\\PregnantPictures\\7.jpg" },
            { 8, "C:\\Users\\GRNT\\source\\repos\\LotusProject\\Entities\\PregnantPictures\\8.jpg" },
            { 9, "C:\\Users\\GRNT\\source\\repos\\LotusProject\\Entities\\PregnantPictures\\9.jpg" }
        };

        private const string DefaultFetusPictureUrl = "C:\\Users\\GRNT\\source\\repos\\LotusProject\\Entities\\PregnantPictures\\NotPregnant.webp";

        public static string GetFetusPictureUrl(int month)
        {
            if (FetusPictureUrls.TryGetValue(month, out var path))
            {
                return path;
            }
            return DefaultFetusPictureUrl;
        }
    }
}
