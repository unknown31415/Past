using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameActionFightDispellableEffectMessage : AbstractGameActionMessage
	{
        public AbstractFightDispellableEffect effect;
        public override uint Id
        {
        	get { return 6070; }
        }
        public GameActionFightDispellableEffectMessage()
        {
        }
        public GameActionFightDispellableEffectMessage(short actionId, int sourceId, AbstractFightDispellableEffect effect) : base(actionId, sourceId)
        {
            this.effect = effect;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(effect.TypeId);
            effect.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            effect = (AbstractFightDispellableEffect)ProtocolTypeManager.GetInstance(reader.ReadUShort());
            effect.Deserialize(reader);
		}
	}
}
