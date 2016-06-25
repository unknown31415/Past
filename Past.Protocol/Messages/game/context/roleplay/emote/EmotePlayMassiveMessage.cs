using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class EmotePlayMassiveMessage : EmotePlayAbstractMessage
	{
        public int[] actorIds;
        public override uint Id
        {
        	get { return 5691; }
        }
        public EmotePlayMassiveMessage()
        {
        }
        public EmotePlayMassiveMessage(sbyte emoteId, byte duration, int[] actorIds) : base(emoteId, duration)
        {
            this.actorIds = actorIds;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort((ushort)actorIds.Length);
            foreach (var entry in actorIds)
            {
                 writer.WriteInt(entry);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadUShort();
            actorIds = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 actorIds[i] = reader.ReadInt();
            }
		}
	}
}
