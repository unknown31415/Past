using Past.Protocol.IO;
using System;

namespace Past.Protocol.Types
{
    public class ObjectEffect
    {
        public short actionId;
        public const short Id = 76;
        public virtual short TypeId
        {
            get { return Id; }
        }
        public ObjectEffect()
        {
        }
        public ObjectEffect(short actionId)
        {
            this.actionId = actionId;
        }
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteShort(actionId);
        }
        public virtual void Deserialize(IDataReader reader)
        {
            actionId = reader.ReadShort();
            if (actionId < 0)
                throw new Exception("Forbidden value on actionId = " + actionId + ", it doesn't respect the following condition : actionId < 0");
        }
    }
}
