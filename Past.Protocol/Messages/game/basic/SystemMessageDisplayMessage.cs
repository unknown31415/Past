using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class SystemMessageDisplayMessage : NetworkMessage
	{
        public bool hangUp;
        public short msgId;
        public string[] parameters;
        public override uint Id
        {
        	get { return 189; }
        }
        public SystemMessageDisplayMessage()
        {
        }
        public SystemMessageDisplayMessage(bool hangUp, short msgId, string[] parameters)
        {
            this.hangUp = hangUp;
            this.msgId = msgId;
            this.parameters = parameters;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(hangUp);
            writer.WriteShort(msgId);
            writer.WriteUShort((ushort)parameters.Length);
            foreach (var entry in parameters)
            {
                 writer.WriteUTF(entry);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            hangUp = reader.ReadBoolean();
            msgId = reader.ReadShort();
            if (msgId < 0)
                throw new Exception("Forbidden value on msgId = " + msgId + ", it doesn't respect the following condition : msgId < 0");
            var limit = reader.ReadUShort();
            parameters = new string[limit];
            for (int i = 0; i < limit; i++)
            {
                 parameters[i] = reader.ReadUTF();
            }
		}
	}
}
