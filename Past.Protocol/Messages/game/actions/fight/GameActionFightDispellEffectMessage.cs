using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameActionFightDispellEffectMessage : GameActionFightDispellMessage
	{
        public int boostUID;
        public override uint Id
        {
        	get { return 6113; }
        }
        public GameActionFightDispellEffectMessage()
        {
        }
        public GameActionFightDispellEffectMessage(short actionId, int sourceId, int targetId, int boostUID) : base(actionId, sourceId, targetId)
        {
            this.boostUID = boostUID;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(boostUID);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            boostUID = reader.ReadInt();
            if (boostUID < 0)
                throw new Exception("Forbidden value on boostUID = " + boostUID + ", it doesn't respect the following condition : boostUID < 0");
		}
	}
}
