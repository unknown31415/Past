using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class LockableStateUpdateAbstractMessage : NetworkMessage
	{
        public bool locked;
        public override uint Id
        {
        	get { return 5671; }
        }
        public LockableStateUpdateAbstractMessage()
        {
        }
        public LockableStateUpdateAbstractMessage(bool locked)
        {
            this.locked = locked;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(locked);
        }
        public override void Deserialize(IDataReader reader)
        {
            locked = reader.ReadBoolean();
		}
	}
}
