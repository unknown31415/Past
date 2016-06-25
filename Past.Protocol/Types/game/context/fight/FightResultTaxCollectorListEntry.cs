using Past.Protocol.IO;
using System;

namespace Past.Protocol.Types
{
    public class FightResultTaxCollectorListEntry : FightResultFighterListEntry
    {
        public byte level;
        public string guildName;
        public int experienceForGuild;
        public new const short Id = 84;
        public override short TypeId
        {
            get { return Id; }
        }
        public FightResultTaxCollectorListEntry()
        {
        }
        public FightResultTaxCollectorListEntry(short outcome, Types.FightLoot rewards, int id, bool alive, byte level, string guildName, int experienceForGuild) : base(outcome, rewards, id, alive)
        {
            this.level = level;
            this.guildName = guildName;
            this.experienceForGuild = experienceForGuild;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(level);
            writer.WriteUTF(guildName);
            writer.WriteInt(experienceForGuild);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            level = reader.ReadByte();
            if (level < 1 || level > 200)
                throw new Exception("Forbidden value on level = " + level + ", it doesn't respect the following condition : level < 1 || level > 200");
            guildName = reader.ReadUTF();
            experienceForGuild = reader.ReadInt();
        }
    }
}

