using RestfulServiceTask.Data;

namespace RestfulServiceTask.MagazineService
{
    public class MagazineService :IMagazineService
    {
        public int[] GetYears()
        {
            return new[] {1, 2, 3};
        }

        public string SaveYear(string year)
        {
            return "Already exist";
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
