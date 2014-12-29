
using System.Collections.ObjectModel;
using System.Xml.Linq;
using System.Linq;
using System;
using AppStudio.Data.DataSchemas;

namespace AppStudio.ViewModels
{
    public class CreditsViewModel
    {
        public ObservableCollection<CreditSchema> CreditsList { get; set; }

        public CreditsViewModel()
        {
            this.CreditsList = LoadCredits();
        }

        public ObservableCollection<CreditSchema> LoadCredits()
        {
            XDocument creditsXmlDoc = XDocument.Load("Credits.xml");

            ObservableCollection<CreditSchema> credits =
                new ObservableCollection<CreditSchema>(
                                from quote in creditsXmlDoc.Descendants("Credit")
                                select new CreditSchema
                                {
                                    Id = Convert.ToInt32(quote.Attribute("Id").Value),
                                    DisplayName = quote.Attribute("DisplayName").Value,
                                    Link = quote.Attribute("Link").Value
                                });

            return credits;
        }

        
    }
}
