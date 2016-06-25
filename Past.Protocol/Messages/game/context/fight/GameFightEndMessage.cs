using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameFightEndMessage : NetworkMessage
	{
        public int duration;
        public short ageBonus;
        public FightResultListEntry[] results;
        public override uint Id
        {
        	get { return 720; }
        }
        public GameFightEndMessage()
        {
        }
        public GameFightEndMessage(int duration, short ageBonus, FightResultListEntry[] results)
        {
            this.duration = duration;
            this.ageBonus = ageBonus;
            this.results = results;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(duration);
            writer.WriteShort(ageBonus);
            writer.WriteUShort((ushort)results.Length);
            foreach (var entry in results)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            duration = reader.ReadInt();
            if (duration < 0)
                throw new Exception("Forbidden value on duration = " + duration + ", it doesn't respect the following condition : duration < 0");
            ageBonus = reader.ReadShort();
            var limit = reader.ReadUShort();
            results = new FightResultListEntry[limit];
            for (int i = 0; i < limit; i++)
            {
                 results[i] = (FightResultListEntry)ProtocolTypeManager.GetInstance(reader.ReadUShort());
                 results[i].Deserialize(reader);
            }
		}
	}
}
