using System;
using System.Runtime.Serialization;

namespace AppStudio.Data.DataSchemas
{

    public class ConcertSchema : BindableSchemaBase, IEquatable<ConcertSchema>, IComparable<ConcertSchema>
    {
        #region Properties
        public string ticket_url { get; set; }
        public string id { get; set; }
        public object on_sale_datetime { get; set; }
        public string ticket_status { get; set; }
        public ArtistSchema[] artists { get; set; }
        public string url { get; set; }
        public DateTime datetime { get; set; }
        public VenueSchema venue { get; set; }
        #endregion

        #region BindableSchemaBase implementation
        public override string GetValue(string propertyName)
        {            
            return String.Empty;
        }

        public override string DefaultTitle
        {
            get { return venue.name; }
        }

        public override string DefaultSummary
        {
            get { return string.Format("{0}, {1}", venue.city, venue.country); }
        }

        public override string DefaultImageUrl
        {
            get { return string.Empty; }
        }

        public override string DefaultContent
        {
            get
            {
                return datetime.ToString("f");
            }
        }
        #endregion

        public bool Equals(ConcertSchema other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(null, other)) return false;

            return this.id == other.id;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ConcertSchema);
        }

        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }

        public int CompareTo(ConcertSchema other)
        {
            return this.datetime.CompareTo(other.datetime);
        }

    }


}
