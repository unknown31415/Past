using Past.Protocol.IO;
using System;

namespace Past.Protocol.Types
{
    public class GroupMonsterStaticInformations
    {
        public int mainCreatureGenericId;
        public short mainCreaturelevel;
        public MonsterInGroupInformations[] underlings;
        public const short Id = 140;
        public virtual short TypeId
        {
            get { return Id; }
        }
        public GroupMonsterStaticInformations()
        {
        }
        public GroupMonsterStaticInformations(int mainCreatureGenericId, short mainCreaturelevel, MonsterInGroupInformations[] underlings)
        {
            this.mainCreatureGenericId = mainCreatureGenericId;
            this.mainCreaturelevel = mainCreaturelevel;
            this.underlings = underlings;
        }
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteInt(mainCreatureGenericId);
            writer.WriteShort(mainCreaturelevel);
            writer.WriteUShort((ushort)underlings.Length);
            foreach (var entry in underlings)
            {
                entry.Serialize(writer);
            }
        }
        public virtual void Deserialize(IDataReader reader)
        {
            mainCreatureGenericId = reader.ReadInt();
            mainCreaturelevel = reader.ReadShort();
            if (mainCreaturelevel < 0)
                throw new Exception("Forbidden value on mainCreaturelevel = " + mainCreaturelevel + ", it doesn't respect the following condition : mainCreaturelevel < 0");
            var limit = reader.ReadUShort();
            underlings = new MonsterInGroupInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                underlings[i] = new MonsterInGroupInformations();
                underlings[i].Deserialize(reader);
            }
        }
    }
}
