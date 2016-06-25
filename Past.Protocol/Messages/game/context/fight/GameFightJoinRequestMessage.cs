using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameFightJoinRequestMessage : NetworkMessage
	{
        public int fightId;
        public int fighterId;
        public override uint Id
        {
        	get { return 701; }
        }
        public GameFightJoinRequestMessage()
        {
        }
        public GameFightJoinRequestMessage(int fightId, int fighterId)
        {
            this.fightId = fightId;
            this.fighterId = fighterId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(fightId);
            writer.WriteInt(fighterId);
        }
        public override void Deserialize(IDataReader reader)
        {
            fightId = reader.ReadInt();
            fighterId = reader.ReadInt();
		}
	}
}
