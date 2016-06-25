using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class MapComplementaryInformationsDataMessage : NetworkMessage
	{
        public int mapId;
        public short subareaId;
        public HouseInformations[] houses;
        public GameRolePlayActorInformations[] actors;
        public InteractiveElement[] interactiveElements;
        public StatedElement[] statedElements;
        public MapObstacle[] obstacles;
        public FightCommonInformations[] fights;
        public override uint Id
        {
        	get { return 226; }
        }
        public MapComplementaryInformationsDataMessage()
        {
        }
        public MapComplementaryInformationsDataMessage(int mapId, short subareaId, HouseInformations[] houses, GameRolePlayActorInformations[] actors, InteractiveElement[] interactiveElements, StatedElement[] statedElements, MapObstacle[] obstacles, FightCommonInformations[] fights)
        {
            this.mapId = mapId;
            this.subareaId = subareaId;
            this.houses = houses;
            this.actors = actors;
            this.interactiveElements = interactiveElements;
            this.statedElements = statedElements;
            this.obstacles = obstacles;
            this.fights = fights;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(mapId);
            writer.WriteShort(subareaId);
            writer.WriteUShort((ushort)houses.Length);
            foreach (var entry in houses)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
            writer.WriteUShort((ushort)actors.Length);
            foreach (var entry in actors)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
            writer.WriteUShort((ushort)interactiveElements.Length);
            foreach (var entry in interactiveElements)
            {
                 entry.Serialize(writer);
            }
            writer.WriteUShort((ushort)statedElements.Length);
            foreach (var entry in statedElements)
            {
                 entry.Serialize(writer);
            }
            writer.WriteUShort((ushort)obstacles.Length);
            foreach (var entry in obstacles)
            {
                 entry.Serialize(writer);
            }
            writer.WriteUShort((ushort)fights.Length);
            foreach (var entry in fights)
            {
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            mapId = reader.ReadInt();
            if (mapId < 0)
                throw new Exception("Forbidden value on mapId = " + mapId + ", it doesn't respect the following condition : mapId < 0");
            subareaId = reader.ReadShort();
            if (subareaId < 0)
                throw new Exception("Forbidden value on subareaId = " + subareaId + ", it doesn't respect the following condition : subareaId < 0");
            var limit = reader.ReadUShort();
            houses = new HouseInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 houses[i] = (HouseInformations)ProtocolTypeManager.GetInstance(reader.ReadUShort());
                 houses[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            actors = new GameRolePlayActorInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 actors[i] = (GameRolePlayActorInformations)ProtocolTypeManager.GetInstance(reader.ReadUShort());
                 actors[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            interactiveElements = new InteractiveElement[limit];
            for (int i = 0; i < limit; i++)
            {
                 interactiveElements[i] = new InteractiveElement();
                 interactiveElements[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            statedElements = new StatedElement[limit];
            for (int i = 0; i < limit; i++)
            {
                 statedElements[i] = new StatedElement();
                 statedElements[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            obstacles = new MapObstacle[limit];
            for (int i = 0; i < limit; i++)
            {
                 obstacles[i] = new MapObstacle();
                 obstacles[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            fights = new FightCommonInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 fights[i] = new FightCommonInformations();
                 fights[i].Deserialize(reader);
            }
		}
	}
}
