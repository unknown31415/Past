using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class PrismFightAttackerRemoveMessage : NetworkMessage
	{
        public double fightId;
        public int fighterToRemoveId;
        public override uint Id
        {
        	get { return 5897; }
        }
        public PrismFightAttackerRemoveMessage()
        {
        }
        public PrismFightAttackerRemoveMessage(double fightId, int fighterToRemoveId)
        {
            this.fightId = fightId;
            this.fighterToRemoveId = fighterToRemoveId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(fightId);
            writer.WriteInt(fighterToRemoveId);
        }
        public override void Deserialize(IDataReader reader)
        {
            fightId = reader.ReadDouble();
            fighterToRemoveId = reader.ReadInt();
            if (fighterToRemoveId < 0)
                throw new Exception("Forbidden value on fighterToRemoveId = " + fighterToRemoveId + ", it doesn't respect the following condition : fighterToRemoveId < 0");
		}
	}
}
