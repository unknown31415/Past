using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class CinematicMessage : NetworkMessage
	{
        public short cinematicId;
        public override uint Id
        {
        	get { return 6053; }
        }
        public CinematicMessage()
        {
        }
        public CinematicMessage(short cinematicId)
        {
            this.cinematicId = cinematicId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(cinematicId);
        }
        public override void Deserialize(IDataReader reader)
        {
            cinematicId = reader.ReadShort();
            if (cinematicId < 0)
                throw new Exception("Forbidden value on cinematicId = " + cinematicId + ", it doesn't respect the following condition : cinematicId < 0");
		}
	}
}
