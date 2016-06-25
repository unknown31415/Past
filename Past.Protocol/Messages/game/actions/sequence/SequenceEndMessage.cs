using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class SequenceEndMessage : NetworkMessage
	{
        public short actionId;
        public int authorId;
        public sbyte sequenceType;
        public override uint Id
        {
        	get { return 956; }
        }
        public SequenceEndMessage()
        {
        }
        public SequenceEndMessage(short actionId, int authorId, sbyte sequenceType)
        {
            this.actionId = actionId;
            this.authorId = authorId;
            this.sequenceType = sequenceType;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(actionId);
            writer.WriteInt(authorId);
            writer.WriteSByte(sequenceType);
        }
        public override void Deserialize(IDataReader reader)
        {
            actionId = reader.ReadShort();
            if (actionId < 0)
                throw new Exception("Forbidden value on actionId = " + actionId + ", it doesn't respect the following condition : actionId < 0");
            authorId = reader.ReadInt();
            sequenceType = reader.ReadSByte();
		}
	}
}
