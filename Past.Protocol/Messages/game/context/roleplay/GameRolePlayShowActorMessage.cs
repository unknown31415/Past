using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameRolePlayShowActorMessage : NetworkMessage
	{
        public GameRolePlayActorInformations informations;
        public override uint Id
        {
        	get { return 5632; }
        }
        public GameRolePlayShowActorMessage()
        {
        }
        public GameRolePlayShowActorMessage(GameRolePlayActorInformations informations)
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
            informations = (GameRolePlayActorInformations)ProtocolTypeManager.GetInstance(reader.ReadUShort());
            informations.Deserialize(reader);
		}
	}
}
