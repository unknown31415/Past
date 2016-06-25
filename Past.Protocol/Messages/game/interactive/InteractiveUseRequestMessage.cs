using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class InteractiveUseRequestMessage : NetworkMessage
	{
        public int elemId;
        public short skillId;
        public override uint Id
        {
        	get { return 5001; }
        }
        public InteractiveUseRequestMessage()
        {
        }
        public InteractiveUseRequestMessage(int elemId, short skillId)
        {
            this.elemId = elemId;
            this.skillId = skillId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(elemId);
            writer.WriteShort(skillId);
        }
        public override void Deserialize(IDataReader reader)
        {
            elemId = reader.ReadInt();
            if (elemId < 0)
                throw new Exception("Forbidden value on elemId = " + elemId + ", it doesn't respect the following condition : elemId < 0");
            skillId = reader.ReadShort();
            if (skillId < 0)
                throw new Exception("Forbidden value on skillId = " + skillId + ", it doesn't respect the following condition : skillId < 0");
		}
	}
}
