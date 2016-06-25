using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ChallengeFightJoinRefusedMessage : NetworkMessage
	{
        public int playerId;
        public sbyte reason;
        public override uint Id
        {
        	get { return 5908; }
        }
        public ChallengeFightJoinRefusedMessage()
        {
        }
        public ChallengeFightJoinRefusedMessage(int playerId, sbyte reason)
        {
            this.playerId = playerId;
            this.reason = reason;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(playerId);
            writer.WriteSByte(reason);
        }
        public override void Deserialize(IDataReader reader)
        {
            playerId = reader.ReadInt();
            if (playerId < 0)
                throw new Exception("Forbidden value on playerId = " + playerId + ", it doesn't respect the following condition : playerId < 0");
            reason = reader.ReadSByte();
		}
	}
}
