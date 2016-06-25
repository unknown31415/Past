using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class LockableStateUpdateStorageMessage : LockableStateUpdateAbstractMessage
	{
        public int mapId;
        public int elementId;
        public override uint Id
        {
        	get { return 5669; }
        }
        public LockableStateUpdateStorageMessage()
        {
        }
        public LockableStateUpdateStorageMessage(bool locked, int mapId, int elementId) : base(locked)
        {
            this.mapId = mapId;
            this.elementId = elementId;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(mapId);
            writer.WriteInt(elementId);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            mapId = reader.ReadInt();
            elementId = reader.ReadInt();
            if (elementId < 0)
                throw new Exception("Forbidden value on elementId = " + elementId + ", it doesn't respect the following condition : elementId < 0");
		}
	}
}
