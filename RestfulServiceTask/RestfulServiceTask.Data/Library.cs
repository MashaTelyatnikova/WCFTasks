using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace RestfulServiceTask.Data
{
    public class Library : ILibrary
    {
        private const string Location = "Library.xml";
        private static readonly XDocument Document;
        private static readonly Func<XElement, string, string> GetAtributeValue = (element, attributeName) => element.Attributes().FirstOrDefault(atr => atr.Name == attributeName).Value;
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

        public IEnumerable<Magazine> GetMagazinesAtYear(int year)
        {
            var y =
                Document.Root.Elements()
                    .FirstOrDefault(element => element.Name == "Year" && int.Parse(element.Value) == year);

            if (y != null)
            {
                foreach (var magazine in y.Elements().Where(element => element.Name == "Magazine"))
                {
                    yield return new Magazine(){Name = magazine.FirstAttribute.Value, ReleaseMonth = magazine.LastAttribute.Value, Articles = GetArticlesFromMagazineNode(magazine)};
                }
            }
        }

        private IEnumerable<Article> GetArticlesFromMagazineNode(XElement magazineNode)
        {
            return magazineNode.Elements()
                                .Where(element => element.Name == "Article")
                                .Select(articleNode => 
                                    new Article()
                                    {
                                        Text = GetAtributeValue(articleNode, "text"), Author = GetAtributeValue(articleNode, "author"), Title = GetAtributeValue(articleNode, "title")
                                    });
        }

        public Magazine GetMagazine(int year, string name, string releaseMonth)
        {
            var y =
                Document.Root.Elements()
                    .FirstOrDefault(element => element.Name == "Year" && int.Parse(element.Value) == year);

            if (y != null)
            {
                var magazineNode =
                    y.Elements()
                        .FirstOrDefault(
                            element =>
                                element.Name == "Magazine" && element.FirstAttribute.Value == name &&
                                element.LastAttribute.Value == releaseMonth);

                if (magazineNode != null)
                {
                    return new Magazine(){Name = name, ReleaseMonth = releaseMonth, Articles = GetArticlesFromMagazineNode(magazineNode)};
                }
            }

            return null;
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
            var y = Document.Root.Elements()
                    .FirstOrDefault(element => element.Name == "Year" && int.Parse(element.Value) == year);

            if (y != null)
            {
                var magazineNode = new XElement("Magazine", new XAttribute("name", magazine.Name), new XAttribute("month", magazine.ReleaseMonth));
                foreach (var article in magazine.Articles)
                {
                    magazineNode.Add(new XElement("Article", new XAttribute("title", article.Title), new XAttribute("text", article.Text), new XAttribute("author", article.Author)));   
                }
                y.Add(magazineNode);
                Document.Save(Location);
            }
        }

        public bool ContainsYear(int year)
        {
            return Document.Root.Elements().Any(element => element.Name == "Year" && int.Parse(element.Value) == year);
        }

        public bool ContainsMagazine(int year, Magazine magazine)
        {
            return GetMagazine(year, magazine.Name, magazine.ReleaseMonth) != null;
        }
    }
}
