using System;

namespace ChannelEngineAssessmentShared.Domain
{
    public abstract class AggregateRoot
    {
        public AggregateId Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; protected set; }

        protected AggregateRoot(AggregateId id)
        {
            Id = id;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = CreatedAt;
        }

        protected AggregateRoot()
        {

        }

        protected void UpdateUpdatedAt()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
