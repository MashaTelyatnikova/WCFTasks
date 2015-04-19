using System.Collections.Generic;

namespace RestfulServiceTask.Data
{
    public interface ILibrary
    {
        int[] GetYears();
        IEnumerable<Magazine> GetMagazinesAtYear(int year);
        Magazine GetMagazine(int year, string name, string releaseMonth);
        void AddYear(int year);
        void AddMagazine(int year, Magazine magazine);
        bool ContainsYear(int year);
        bool ContainsMagazine(int year, Magazine magazine);
    }
}
