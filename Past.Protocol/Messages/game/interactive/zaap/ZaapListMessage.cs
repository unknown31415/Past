using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ZaapListMessage : TeleportDestinationsListMessage
	{
        public int spawnMapId;
        public override uint Id
        {
        	get { return 1604; }
        }
        public ZaapListMessage()
        {
        }
        public ZaapListMessage(sbyte teleporterType, int[] mapIds, short[] subareaIds, short[] costs, int spawnMapId) : base(teleporterType, mapIds, subareaIds, costs)
        {
            this.spawnMapId = spawnMapId;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(spawnMapId);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            spawnMapId = reader.ReadInt();
            if (spawnMapId < 0)
                throw new Exception("Forbidden value on spawnMapId = " + spawnMapId + ", it doesn't respect the following condition : spawnMapId < 0");
		}
	}
}
