using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class EntityTalkMessage : NetworkMessage
	{
        public int entityId;
        public short textId;
        public string[] parameters;
        public override uint Id
        {
        	get { return 6110; }
        }
        public EntityTalkMessage()
        {
        }
        public EntityTalkMessage(int entityId, short textId, string[] parameters)
        {
            this.entityId = entityId;
            this.textId = textId;
            this.parameters = parameters;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(entityId);
            writer.WriteShort(textId);
            writer.WriteUShort((ushort)parameters.Length);
            foreach (var entry in parameters)
            {
                 writer.WriteUTF(entry);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            entityId = reader.ReadInt();
            textId = reader.ReadShort();
            if (textId < 0)
                throw new Exception("Forbidden value on textId = " + textId + ", it doesn't respect the following condition : textId < 0");
            var limit = reader.ReadUShort();
            parameters = new string[limit];
            for (int i = 0; i < limit; i++)
            {
                 parameters[i] = reader.ReadUTF();
            }
		}
	}
}
