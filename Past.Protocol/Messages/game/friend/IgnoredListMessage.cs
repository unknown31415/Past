using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class IgnoredListMessage : NetworkMessage
	{
        public IgnoredInformations[] ignoredList;
        public override uint Id
        {
        	get { return 5674; }
        }
        public IgnoredListMessage()
        {
        }
        public IgnoredListMessage(IgnoredInformations[] ignoredList)
        {
            this.ignoredList = ignoredList;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)ignoredList.Length);
            foreach (var entry in ignoredList)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            ignoredList = new IgnoredInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 ignoredList[i] = (IgnoredInformations)ProtocolTypeManager.GetInstance(reader.ReadUShort());
                 ignoredList[i].Deserialize(reader);
            }
		}
	}
}
