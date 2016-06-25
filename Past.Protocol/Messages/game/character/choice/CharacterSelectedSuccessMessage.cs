using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class CharacterSelectedSuccessMessage : NetworkMessage
	{
        public CharacterBaseInformations infos;
        public override uint Id
        {
        	get { return 153; }
        }
        public CharacterSelectedSuccessMessage()
        {
        }
        public CharacterSelectedSuccessMessage(CharacterBaseInformations infos)
        {
            this.infos = infos;
        }
        public override void Serialize(IDataWriter writer)
        {
            infos.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            infos = new CharacterBaseInformations();
            infos.Deserialize(reader);
		}
	}
}
