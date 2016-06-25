using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class TaxCollectorDialogQuestionBasicMessage : NetworkMessage
	{
        public string guildName;
        public override uint Id
        {
        	get { return 5619; }
        }
        public TaxCollectorDialogQuestionBasicMessage()
        {
        }
        public TaxCollectorDialogQuestionBasicMessage(string guildName)
        {
            this.guildName = guildName;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(guildName);
        }
        public override void Deserialize(IDataReader reader)
        {
            guildName = reader.ReadUTF();
		}
	}
}
