using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameFightLeaveMessage : NetworkMessage
	{
        public int charId;
        public override uint Id
        {
        	get { return 721; }
        }
        public GameFightLeaveMessage()
        {
        }
        public GameFightLeaveMessage(int charId)
        {
            this.charId = charId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(charId);
        }
        public override void Deserialize(IDataReader reader)
        {
            charId = reader.ReadInt();
		}
	}
}
