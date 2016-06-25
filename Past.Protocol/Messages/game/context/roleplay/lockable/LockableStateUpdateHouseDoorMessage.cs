using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class LockableStateUpdateHouseDoorMessage : LockableStateUpdateAbstractMessage
	{
        public int houseId;
        public override uint Id
        {
        	get { return 5668; }
        }
        public LockableStateUpdateHouseDoorMessage()
        {
        }
        public LockableStateUpdateHouseDoorMessage(bool locked, int houseId) : base(locked)
        {
            this.houseId = houseId;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(houseId);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            houseId = reader.ReadInt();
		}
	}
}
