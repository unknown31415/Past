using System;
using Past.Protocol.IO;

namespace Past.Protocol.Types
{
    public class ObjectEffectString : ObjectEffect
    {
        public string value;
        public new const short Id = 74;
        public override short TypeId
        {
            get { return Id; }
        }
        public ObjectEffectString()
        {
        }
        public ObjectEffectString(short actionId, string value) : base(actionId)
        {
            this.value = value;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(value);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            value = reader.ReadUTF();
        }
    }
}

