using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class MountEmoteIconUsedOkMessage : NetworkMessage
	{
        public int mountId;
        public sbyte reactionType;
        public override uint Id
        {
        	get { return 5978; }
        }
        public MountEmoteIconUsedOkMessage()
        {
        }
        public MountEmoteIconUsedOkMessage(int mountId, sbyte reactionType)
        {
            this.mountId = mountId;
            this.reactionType = reactionType;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(mountId);
            writer.WriteSByte(reactionType);
        }
        public override void Deserialize(IDataReader reader)
        {
            mountId = reader.ReadInt();
            reactionType = reader.ReadSByte();
            if (reactionType < 0)
                throw new Exception("Forbidden value on reactionType = " + reactionType + ", it doesn't respect the following condition : reactionType < 0");
		}
	}
}
