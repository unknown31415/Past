using Past.Protocol.IO;

namespace Past.Protocol.Types
{
    public class MountInformationsForPaddock
    {
        public int modelId;
        public string name;
        public string ownerName;
        public const short Id = 184;
        public virtual short TypeId
        {
            get { return Id; }
        }
        public MountInformationsForPaddock()
        {
        }
        public MountInformationsForPaddock(int modelId, string name, string ownerName)
        {
            this.modelId = modelId;
            this.name = name;
            this.ownerName = ownerName;
        }
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteInt(modelId);
            writer.WriteUTF(name);
            writer.WriteUTF(ownerName);
        }
        public virtual void Deserialize(IDataReader reader)
        {
            modelId = reader.ReadInt();
            name = reader.ReadUTF();
            ownerName = reader.ReadUTF();
        }
    }
}