using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameMapMovementRequestMessage : NetworkMessage
	{
        public int mapId;
        public short[] keyMovements;
        public override uint Id
        {
        	get { return 950; }
        }
        public GameMapMovementRequestMessage()
        {
        }
        public GameMapMovementRequestMessage(int mapId, short[] keyMovements)
        {
            this.mapId = mapId;
            this.keyMovements = keyMovements;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(mapId);
            writer.WriteUShort((ushort)keyMovements.Length);
            foreach (var entry in keyMovements)
            {
                 writer.WriteShort(entry);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            mapId = reader.ReadInt();
            if (mapId < 0)
                throw new Exception("Forbidden value on mapId = " + mapId + ", it doesn't respect the following condition : mapId < 0");
            var limit = reader.ReadUShort();
            keyMovements = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 keyMovements[i] = reader.ReadShort();
            }
		}
	}
}
