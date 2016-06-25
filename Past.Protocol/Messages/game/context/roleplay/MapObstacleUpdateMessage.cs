using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class MapObstacleUpdateMessage : NetworkMessage
	{
        public MapObstacle[] obstacles;
        public override uint Id
        {
        	get { return 6051; }
        }
        public MapObstacleUpdateMessage()
        {
        }
        public MapObstacleUpdateMessage(MapObstacle[] obstacles)
        {
            this.obstacles = obstacles;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)obstacles.Length);
            foreach (var entry in obstacles)
            {
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            obstacles = new MapObstacle[limit];
            for (int i = 0; i < limit; i++)
            {
                 obstacles[i] = new MapObstacle();
                 obstacles[i].Deserialize(reader);
            }
		}
	}
}
