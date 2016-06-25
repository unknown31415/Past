using Past.Protocol.IO;

namespace Past.Protocol.Types
{
    public class GameContextActorInformations
    {
        public int contextualId;
        public EntityLook look;
        public EntityDispositionInformations disposition;
        public const short Id = 150;
        public virtual short TypeId
        {
            get { return Id; }
        }
        public GameContextActorInformations()
        {
        }
        public GameContextActorInformations(int contextualId, EntityLook look, EntityDispositionInformations disposition)
        {
            this.contextualId = contextualId;
            this.look = look;
            this.disposition = disposition;
        }
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteInt(contextualId);
            look.Serialize(writer);
            writer.WriteShort(disposition.TypeId);
            disposition.Serialize(writer);
        }
        public virtual void Deserialize(IDataReader reader)
        {
            contextualId = reader.ReadInt();
            look = new Types.EntityLook();
            look.Deserialize(reader);
            disposition = (EntityDispositionInformations)ProtocolTypeManager.GetInstance(reader.ReadUShort());
            disposition.Deserialize(reader);
        }
    }
}
