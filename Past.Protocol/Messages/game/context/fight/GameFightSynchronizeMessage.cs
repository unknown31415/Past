using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameFightSynchronizeMessage : NetworkMessage
	{
        public GameFightFighterInformations[] fighters;
        public override uint Id
        {
        	get { return 5921; }
        }
        public GameFightSynchronizeMessage()
        {
        }
        public GameFightSynchronizeMessage(GameFightFighterInformations[] fighters)
        {
            this.fighters = fighters;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)fighters.Length);
            foreach (var entry in fighters)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            fighters = new GameFightFighterInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 fighters[i] = (GameFightFighterInformations)ProtocolTypeManager.GetInstance(reader.ReadUShort());
                 fighters[i].Deserialize(reader);
            }
		}
	}
}
