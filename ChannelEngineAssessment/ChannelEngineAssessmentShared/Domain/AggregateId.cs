using System;

namespace ChannelEngineAssessmentShared.Domain
{
    public struct AggregateId : IEquatable<AggregateId>
    {
        public string Id { get; private set; }

        public AggregateId(string id) : this()
        {
            ValidateId(id);
        }

        public bool Equals(AggregateId? other)
            => other.HasValue && Equals(other.Value.Id);

        public bool Equals(AggregateId other)
            => other.Id == Id;

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