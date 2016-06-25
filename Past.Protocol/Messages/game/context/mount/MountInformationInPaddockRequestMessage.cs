using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class MountInformationInPaddockRequestMessage : NetworkMessage
	{
        public int mapRideId;
        public override uint Id
        {
        	get { return 5975; }
        }
        public MountInformationInPaddockRequestMessage()
        {
        }
        public MountInformationInPaddockRequestMessage(int mapRideId)
        {
            this.mapRideId = mapRideId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(mapRideId);
        }
        public override void Deserialize(IDataReader reader)
        {
            mapRideId = reader.ReadInt();
            if (mapRideId < 0)
                throw new Exception("Forbidden value on mapRideId = " + mapRideId + ", it doesn't respect the following condition : mapRideId < 0");
		}
	}
}
