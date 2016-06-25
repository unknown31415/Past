using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameContextMoveElementMessage : NetworkMessage
	{
        public EntityMovementInformations movement;
        public override uint Id
        {
        	get { return 253; }
        }
        public GameContextMoveElementMessage()
        {
        }
        public GameContextMoveElementMessage(EntityMovementInformations movement)
        {
            this.movement = movement;
        }
        public override void Serialize(IDataWriter writer)
        {
            movement.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            movement = new EntityMovementInformations();
            movement.Deserialize(reader);
		}
	}
}
