using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameActionFightSummonMessage : AbstractGameActionMessage
	{
        public GameFightFighterInformations summon;
        public override uint Id
        {
        	get { return 5825; }
        }
        public GameActionFightSummonMessage()
        {
        }
        public GameActionFightSummonMessage(short actionId, int sourceId, GameFightFighterInformations summon) : base(actionId, sourceId)
        {
            this.summon = summon;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(summon.TypeId);
            summon.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            summon = (GameFightFighterInformations)ProtocolTypeManager.GetInstance(reader.ReadUShort());
            summon.Deserialize(reader);
		}
	}
}
