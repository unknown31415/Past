using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class EmotePlayMessage : EmotePlayAbstractMessage
	{
        public int actorId;
        public override uint Id
        {
        	get { return 5683; }
        }
        public EmotePlayMessage()
        {
        }
        public EmotePlayMessage(sbyte emoteId, byte duration, int actorId) : base(emoteId, duration)
        {
            this.actorId = actorId;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(actorId);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            actorId = reader.ReadInt();
		}
	}
}
