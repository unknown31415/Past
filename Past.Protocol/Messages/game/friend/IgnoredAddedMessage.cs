using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class IgnoredAddedMessage : NetworkMessage
	{
        public IgnoredInformations ignoreAdded;
        public override uint Id
        {
        	get { return 5678; }
        }
        public IgnoredAddedMessage()
        {
        }
        public IgnoredAddedMessage(IgnoredInformations ignoreAdded)
        {
            this.ignoreAdded = ignoreAdded;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(ignoreAdded.TypeId);
            ignoreAdded.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            ignoreAdded = (IgnoredInformations)ProtocolTypeManager.GetInstance(reader.ReadUShort());
            ignoreAdded.Deserialize(reader);
		}
	}
}
