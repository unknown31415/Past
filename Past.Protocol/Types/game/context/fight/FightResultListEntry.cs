using System;
using Past.Protocol.IO;

namespace Past.Protocol.Types
{
    public class FightResultListEntry
    {
        public short outcome;
        public FightLoot rewards;
        public const short Id = 16;
        public virtual short TypeId
        {
            get { return Id; }
        }
        public FightResultListEntry()
        {
        }
        public FightResultListEntry(short outcome, FightLoot rewards)
        {
            this.outcome = outcome;
            this.rewards = rewards;
        }
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteShort(outcome);
            rewards.Serialize(writer);
        }
        public virtual void Deserialize(IDataReader reader)
        {
            outcome = reader.ReadShort();
            if (outcome < 0)
                throw new Exception("Forbidden value on outcome = " + outcome + ", it doesn't respect the following condition : outcome < 0");
            rewards = new Types.FightLoot();
            rewards.Deserialize(reader);
        }
    }
}
