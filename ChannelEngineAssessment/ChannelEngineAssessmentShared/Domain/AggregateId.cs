using System;

namespace ChannelEngineAssessmentShared.Domain
{
    public struct AggregateId : IEquatable<AggregateId>
    {

        public override int GetHashCode()
        {
            return (Id != null ? Id.GetHashCode() : 0);
        }

        public string Id { get; private set; }

        public AggregateId(string id) : this()
        {
            ValidateId(id);
        }

        public bool Equals(AggregateId? other)
            => other.HasValue && Equals(other.Value.Id);

        public bool Equals(AggregateId other)
            => other.Id == Id;

        public override string ToString()
        {
            return Id;
        }

        public static bool operator ==(AggregateId id1, AggregateId id2)
        {
            return id1.Equals(id2);
        }

        public static bool operator !=(AggregateId id1, AggregateId id2)
        {
            return !(id1 == id2);
        }

        public override bool Equals(object obj)
        {
            return obj is AggregateId other && Equals(other);
        }

        private void ValidateId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            Id = id;
        }
    }
}