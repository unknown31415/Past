using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameFightSpectateMessage : NetworkMessage
	{
        public FightDispellableEffectExtendedInformations[] effects;
        public override uint Id
        {
        	get { return 6069; }
        }
        public GameFightSpectateMessage()
        {
        }
        public GameFightSpectateMessage(FightDispellableEffectExtendedInformations[] effects)
        {
            this.effects = effects;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)effects.Length);
            foreach (var entry in effects)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            effects = new FightDispellableEffectExtendedInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 effects[i] = (FightDispellableEffectExtendedInformations)ProtocolTypeManager.GetInstance(reader.ReadUShort());
                 effects[i].Deserialize(reader);
            }
		}
	}
}
