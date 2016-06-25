using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class DocumentReadingBeginMessage : NetworkMessage
	{
        public short documentId;
        public override uint Id
        {
        	get { return 5675; }
        }
        public DocumentReadingBeginMessage()
        {
        }
        public DocumentReadingBeginMessage(short documentId)
        {
            this.documentId = documentId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(documentId);
        }
        public override void Deserialize(IDataReader reader)
        {
            documentId = reader.ReadShort();
            if (documentId < 0)
                throw new Exception("Forbidden value on documentId = " + documentId + ", it doesn't respect the following condition : documentId < 0");
		}
	}
}
