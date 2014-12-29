using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppStudio.Data.DataProviders;
using AppStudio.Data.DataSchemas;

namespace AppStudio.Data
{
    public class ConcertsDataSource : DataSourceBase<ConcertSchema>
    {
        private const string _artistId = "Maroon5";

        protected override string CacheKey
        {
            get { return "ConcertsDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return false; }
        }

        public async override Task<IEnumerable<ConcertSchema>> LoadDataAsync()
        {
            try
            {
                var concertsDataProvider = new ConcertDataProvider(_artistId);
                return await concertsDataProvider.Load();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("ConcertsDataSource.LoadData", ex.ToString());
                return new ConcertSchema[0];
            }
        }
    }
}


