using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeIsReadyMessage : NetworkMessage
	{
        public int id;
        public bool ready;
        public override uint Id
        {
        	get { return 5509; }
        }
        public ExchangeIsReadyMessage()
        {
        }
        public ExchangeIsReadyMessage(int id, bool ready)
        {
            this.id = id;
            this.ready = ready;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(id);
            writer.WriteBoolean(ready);
        }
        public override void Deserialize(IDataReader reader)
        {
            id = reader.ReadInt();
            if (id < 0)
                throw new Exception("Forbidden value on id = " + id + ", it doesn't respect the following condition : id < 0");
            ready = reader.ReadBoolean();
		}
	}
}
