using Past.Protocol.IO;

namespace Past.Protocol.Types
{
    public class IgnoredInformations
    {
        public string name;
        public const short Id = 106;
        public virtual short TypeId
        {
            get { return Id; }
        }
        public IgnoredInformations()
        {
        }
        public IgnoredInformations(string name)
        {
            this.name = name;
        }
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(name);
        }
        public virtual void Deserialize(IDataReader reader)
        {
            name = reader.ReadUTF();
        }
    }
}

