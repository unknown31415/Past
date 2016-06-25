using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class SequenceStartMessage : NetworkMessage
	{
        public int authorId;
        public sbyte sequenceType;
        public override uint Id
        {
        	get { return 955; }
        }
        public SequenceStartMessage()
        {
        }
        public SequenceStartMessage(int authorId, sbyte sequenceType)
        {
            this.authorId = authorId;
            this.sequenceType = sequenceType;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(authorId);
            writer.WriteSByte(sequenceType);
        }
        public override void Deserialize(IDataReader reader)
        {
            authorId = reader.ReadInt();
            sequenceType = reader.ReadSByte();
		}
	}
}
