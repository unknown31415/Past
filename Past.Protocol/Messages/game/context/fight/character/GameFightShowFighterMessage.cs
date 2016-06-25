using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameFightShowFighterMessage : NetworkMessage
	{
        public GameFightFighterInformations informations;
        public override uint Id
        {
        	get { return 5864; }
        }
        public GameFightShowFighterMessage()
        {
        }
        public GameFightShowFighterMessage(GameFightFighterInformations informations)
        {
            this.informations = informations;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(informations.TypeId);
            informations.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            informations = (GameFightFighterInformations)ProtocolTypeManager.GetInstance(reader.ReadUShort());
            informations.Deserialize(reader);
		}
	}
}
