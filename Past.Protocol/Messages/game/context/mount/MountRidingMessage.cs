using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class MountRidingMessage : NetworkMessage
	{
        public bool isRiding;
        public override uint Id
        {
        	get { return 5967; }
        }
        public MountRidingMessage()
        {
        }
        public MountRidingMessage(bool isRiding)
        {
            this.isRiding = isRiding;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(isRiding);
        }
        public override void Deserialize(IDataReader reader)
        {
            isRiding = reader.ReadBoolean();
		}
	}
}
