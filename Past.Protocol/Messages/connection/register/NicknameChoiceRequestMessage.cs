using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class NicknameChoiceRequestMessage : NetworkMessage
	{
        public string nickname;
        public override uint Id
        {
        	get { return 5639; }
        }
        public NicknameChoiceRequestMessage()
        {
        }
        public NicknameChoiceRequestMessage(string nickname)
        {
            this.nickname = nickname;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(nickname);
        }
        public override void Deserialize(IDataReader reader)
        {
            nickname = reader.ReadUTF();
		}
	}
}
