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
            throw new System.NotImplementedException();
        }

        public Article[] GetArticles(string year, string magazineName, string month)
        {
            throw new System.NotImplementedException();
        }

        public void SaveMagazine(string year, Magazine magazine)
        {
            throw new System.NotImplementedException();
        }
    }
}
