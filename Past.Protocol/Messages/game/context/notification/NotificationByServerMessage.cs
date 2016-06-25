using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class NotificationByServerMessage : NetworkMessage
	{
        public ushort id;
        public string[] parameters;
        public override uint Id
        {
        	get { return 6103; }
        }
        public NotificationByServerMessage()
        {
        }
        public NotificationByServerMessage(ushort id, string[] parameters)
        {
            this.id = id;
            this.parameters = parameters;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort(id);
            writer.WriteUShort((ushort)parameters.Length);
            foreach (var entry in parameters)
            {
                 writer.WriteUTF(entry);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            id = reader.ReadUShort();
            if (id < 0 || id > 65535)
                throw new Exception("Forbidden value on id = " + id + ", it doesn't respect the following condition : id < 0 || id > 65535");
            var limit = reader.ReadUShort();
            parameters = new string[limit];
            for (int i = 0; i < limit; i++)
            {
                 parameters[i] = reader.ReadUTF();
            }
		}
	}
}
