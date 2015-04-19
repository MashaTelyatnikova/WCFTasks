using System.Linq;
using RestfulServiceTask.Data;

namespace RestfulServiceTask.MagazineService
{
    public class MagazineService :IMagazineService
    {
        private static readonly ILibrary Library = new Library();
        public int[] GetYears()
        {
            return Library.GetYears();
        }

        public string SaveYear(string year)
        {
            int y;
            if (int.TryParse(year, out y))
            {
                Library.AddYear(y);
                return "Year successfully added.";
            }

            return "Incorrect year.";
        }

        public string[] GetMagazineNames(string year)
        {
            int y;
            if (int.TryParse(year, out y) && Library.ContainsYear(y))
            {
                
                return
                    Library.GetMagazinesAtYear(y)
                        .Select(magazine => string.Format("{0}({1})", magazine.Name, magazine.ReleaseMonth))
                        .ToArray();
            }
            return null;
        }

        public Article[] GetArticles(string year, string magazineName, string month)
        {
            int y;
            if (int.TryParse(year, out y) && Library.ContainsYear(y))
            {
                return Library.GetMagazine(y, magazineName, month).Articles.ToArray();
            }

            return null;
        }

        public string SaveMagazine(string year, Magazine magazine)
        {
            int y;
            if (int.TryParse(year, out y) && Library.ContainsYear(y) && magazine != null)
            {
                if (Library.ContainsMagazine(y, magazine))
                {
                    return "Magasine already exist.";
                }

                Library.AddMagazine(y, magazine);

                return "Magazine successfully added.";
            }

            return "Incorrect data";
        }
    }
}
