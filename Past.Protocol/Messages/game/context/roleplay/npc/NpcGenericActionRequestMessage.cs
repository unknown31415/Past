using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class NpcGenericActionRequestMessage : NetworkMessage
	{
        public int npcId;
        public sbyte npcActionId;
        public override uint Id
        {
        	get { return 5898; }
        }
        public NpcGenericActionRequestMessage()
        {
        }
        public NpcGenericActionRequestMessage(int npcId, sbyte npcActionId)
        {
            this.npcId = npcId;
            this.npcActionId = npcActionId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(npcId);
            writer.WriteSByte(npcActionId);
        }
        public override void Deserialize(IDataReader reader)
        {
            npcId = reader.ReadInt();
            npcActionId = reader.ReadSByte();
            if (npcActionId < 0)
                throw new Exception("Forbidden value on npcActionId = " + npcActionId + ", it doesn't respect the following condition : npcActionId < 0");
		}
	}
}
