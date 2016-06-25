using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GuildCharacsUpgradeRequestMessage : NetworkMessage
	{
        public sbyte charaTypeTarget;
        public override uint Id
        {
        	get { return 5706; }
        }
        public GuildCharacsUpgradeRequestMessage()
        {
        }
        public GuildCharacsUpgradeRequestMessage(sbyte charaTypeTarget)
        {
            this.charaTypeTarget = charaTypeTarget;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(charaTypeTarget);
        }
        public override void Deserialize(IDataReader reader)
        {
            charaTypeTarget = reader.ReadSByte();
            if (charaTypeTarget < 0)
                throw new Exception("Forbidden value on charaTypeTarget = " + charaTypeTarget + ", it doesn't respect the following condition : charaTypeTarget < 0");
		}
	}
}
