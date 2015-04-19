using System;
using System.Linq;
using System.Xml.Linq;

namespace RestfulServiceTask.Data
{
    public class Library : ILibrary
    {
        private const string Location = "Library.xml";
        private static readonly XDocument Document;

        static Library()
        {
            Document = XDocument.Load(Location);
        }

        public int[] GetYears()
        {
            return Document.Root == null ? new int[0] :
                    
                Document.Root.Elements()
                    .Where(element => element.Name == "Year")
                    .Select(element => int.Parse(element.Value))
                    .ToArray();
        }

        public Magazine[] GetMagazinesAtYear(int year)
        {
            throw new NotImplementedException();
        }

        public Magazine GetMagazine(int year, string name, string releaseMonth)
        {
            throw new NotImplementedException();
        }

        public void AddYear(int year)
        {
            if (!Document.Root.Elements().Any(element => element.Name == "Year" && element.Value == year.ToString()))
            {
                Document.Root.Add(new XElement("Year", year.ToString()));
                Document.Save(Location);
            }
        }

        public void AddMagazine(int year, Magazine magazine)
        {
            throw new NotImplementedException();
        }
    }
}
