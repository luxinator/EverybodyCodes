using System;

namespace API.Model
{
    public class Camera : IEquatable<Camera>
    {
        public int Id { get; set; }
        
        public string CamId { get; set; }
        
        public string Street { get; set; }
        
        public float Latitude { get; set; }
        
        public float Longitude { get; set; }
        


        /**
         * Auto generated, Rider rules
         */
        public bool Equals(Camera other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return CamId == other.CamId && Street == other.Street && Latitude.Equals(other.Latitude) && Longitude.Equals(other.Longitude);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Camera) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (CamId != null ? CamId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Street != null ? Street.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Latitude.GetHashCode();
                hashCode = (hashCode * 397) ^ Longitude.GetHashCode();
                return hashCode;
            }
        }
    }
}