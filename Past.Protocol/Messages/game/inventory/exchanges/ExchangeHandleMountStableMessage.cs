using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeHandleMountStableMessage : NetworkMessage
	{
        public sbyte actionType;
        public int rideId;
        public override uint Id
        {
        	get { return 5965; }
        }
        public ExchangeHandleMountStableMessage()
        {
        }
        public ExchangeHandleMountStableMessage(sbyte actionType, int rideId)
        {
            this.actionType = actionType;
            this.rideId = rideId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(actionType);
            writer.WriteInt(rideId);
        }
        public override void Deserialize(IDataReader reader)
        {
            actionType = reader.ReadSByte();
            rideId = reader.ReadInt();
            if (rideId < 0)
                throw new Exception("Forbidden value on rideId = " + rideId + ", it doesn't respect the following condition : rideId < 0");
		}
	}
}
