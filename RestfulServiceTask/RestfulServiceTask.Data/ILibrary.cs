namespace RestfulServiceTask.Data
{
    public interface ILibrary
    {
        int[] GetYears();
        Magazine[] GetMagazinesAtYear(int year);
        Magazine GetMagazine(int year, string name, string releaseMonth);
        void AddYear(int year);
        void AddMagazine(int year, Magazine magazine);
    }
}
