using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class BasicWhoIsMessage : NetworkMessage
	{
        public bool self;
        public sbyte position;
        public string accountNickname;
        public string characterName;
        public short areaId;
        public override uint Id
        {
        	get { return 180; }
        }
        public BasicWhoIsMessage()
        {
        }
        public BasicWhoIsMessage(bool self, sbyte position, string accountNickname, string characterName, short areaId)
        {
            this.self = self;
            this.position = position;
            this.accountNickname = accountNickname;
            this.characterName = characterName;
            this.areaId = areaId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(self);
            writer.WriteSByte(position);
            writer.WriteUTF(accountNickname);
            writer.WriteUTF(characterName);
            writer.WriteShort(areaId);
        }
        public override void Deserialize(IDataReader reader)
        {
            self = reader.ReadBoolean();
            position = reader.ReadSByte();
            accountNickname = reader.ReadUTF();
            characterName = reader.ReadUTF();
            areaId = reader.ReadShort();
		}
	}
}
