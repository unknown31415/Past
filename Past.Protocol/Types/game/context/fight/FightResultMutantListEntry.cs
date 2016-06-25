using Past.Protocol.IO;
using System;

namespace Past.Protocol.Types
{
    public class FightResultMutantListEntry : FightResultFighterListEntry
    {
        public ushort level;

        public new const short Id = 216;
        public override short TypeId
        {
            get { return Id; }
        }
        public FightResultMutantListEntry()
        {
        }
        public FightResultMutantListEntry(short outcome, Types.FightLoot rewards, int id, bool alive, ushort level) : base(outcome, rewards, id, alive)
        {
            this.level = level;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort(level);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            level = reader.ReadUShort();
            if (level < 0 || level > 255)
                throw new Exception("Forbidden value on level = " + level + ", it doesn't respect the following condition : level < 0 || level > 255");
        }
    }
}
