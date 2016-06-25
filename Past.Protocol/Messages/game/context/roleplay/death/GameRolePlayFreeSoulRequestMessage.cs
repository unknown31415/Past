using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameRolePlayFreeSoulRequestMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 745; }
        }
        public GameRolePlayFreeSoulRequestMessage()
        {
        }
        public override void Serialize(IDataWriter writer)
        {
        }
        public override void Deserialize(IDataReader reader)
        {
		}
	}
}
