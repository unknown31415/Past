using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameContextMoveMultipleElementsMessage : NetworkMessage
	{
        public EntityMovementInformations[] movements;
        public override uint Id
        {
        	get { return 254; }
        }
        public GameContextMoveMultipleElementsMessage()
        {
        }
        public GameContextMoveMultipleElementsMessage(EntityMovementInformations[] movements)
        {
            this.movements = movements;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)movements.Length);
            foreach (var entry in movements)
            {
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            movements = new EntityMovementInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 movements[i] = new EntityMovementInformations();
                 movements[i].Deserialize(reader);
            }
		}
	}
}
