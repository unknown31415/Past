using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeReplayCountModifiedMessage : NetworkMessage
	{
        public int count;
        public override uint Id
        {
        	get { return 6023; }
        }
        public ExchangeReplayCountModifiedMessage()
        {
        }
        public ExchangeReplayCountModifiedMessage(int count)
        {
            this.count = count;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(count);
        }
        public override void Deserialize(IDataReader reader)
        {
            count = reader.ReadInt();
		}
	}
}
