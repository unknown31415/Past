using Past.Protocol.IO;

namespace Past.Protocol.Types
{
    public class FightTeamMemberInformations
    {
        public int id;
        public const short Id = 44;
        public virtual short TypeId
        {
            get { return Id; }
        }
        public FightTeamMemberInformations()
        {
        }
        public FightTeamMemberInformations(int id)
        {
            this.id = id;
        }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteInt(id);
        }
        public virtual void Deserialize(IDataReader reader)
        {
            id = reader.ReadInt();
        }
    }
}

