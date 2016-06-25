using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ContactLookMessage : NetworkMessage
	{
        public int requestId;
        public string playerName;
        public int playerId;
        public EntityLook look;
        public override uint Id
        {
        	get { return 5934; }
        }
        public ContactLookMessage()
        {
        }
        public ContactLookMessage(int requestId, string playerName, int playerId, EntityLook look)
        {
            this.requestId = requestId;
            this.playerName = playerName;
            this.playerId = playerId;
            this.look = look;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(requestId);
            writer.WriteUTF(playerName);
            writer.WriteInt(playerId);
            look.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            requestId = reader.ReadInt();
            if (requestId < 0)
                throw new Exception("Forbidden value on requestId = " + requestId + ", it doesn't respect the following condition : requestId < 0");
            playerName = reader.ReadUTF();
            playerId = reader.ReadInt();
            if (playerId < 0)
                throw new Exception("Forbidden value on playerId = " + playerId + ", it doesn't respect the following condition : playerId < 0");
            look = new EntityLook();
            look.Deserialize(reader);
		}
	}
}
