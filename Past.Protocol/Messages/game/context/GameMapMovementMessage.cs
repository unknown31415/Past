using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameMapMovementMessage : NetworkMessage
	{
        public int actorId;
        public short[] keyMovements;
        public override uint Id
        {
        	get { return 951; }
        }
        public GameMapMovementMessage()
        {
        }
        public GameMapMovementMessage(int actorId, short[] keyMovements)
        {
            this.actorId = actorId;
            this.keyMovements = keyMovements;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(actorId);
            writer.WriteUShort((ushort)keyMovements.Length);
            foreach (var entry in keyMovements)
            {
                 writer.WriteShort(entry);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            actorId = reader.ReadInt();
            var limit = reader.ReadUShort();
            keyMovements = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 keyMovements[i] = reader.ReadShort();
            }
		}
	}
}
