using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class TextInformationMessage : NetworkMessage
	{
        public sbyte msgType;
        public short msgId;
        public string[] parameters;
        public override uint Id
        {
        	get { return 780; }
        }
        public TextInformationMessage()
        {
        }
        public TextInformationMessage(sbyte msgType, short msgId, string[] parameters)
        {
            this.msgType = msgType;
            this.msgId = msgId;
            this.parameters = parameters;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(msgType);
            writer.WriteShort(msgId);
            writer.WriteUShort((ushort)parameters.Length);
            foreach (var entry in parameters)
            {
                 writer.WriteUTF(entry);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            msgType = reader.ReadSByte();
            if (msgType < 0)
                throw new Exception("Forbidden value on msgType = " + msgType + ", it doesn't respect the following condition : msgType < 0");
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
