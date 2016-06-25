using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameRolePlayShowChallengeMessage : NetworkMessage
	{
        public FightCommonInformations commonsInfos;
        public override uint Id
        {
        	get { return 301; }
        }
        public GameRolePlayShowChallengeMessage()
        {
        }
        public GameRolePlayShowChallengeMessage(FightCommonInformations commonsInfos)
        {
            this.commonsInfos = commonsInfos;
        }
        public override void Serialize(IDataWriter writer)
        {
            commonsInfos.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            commonsInfos = new FightCommonInformations();
            commonsInfos.Deserialize(reader);
		}
	}
}
