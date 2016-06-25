using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class StartupActionsListMessage : NetworkMessage
	{
        public StartupActionAddObject[] actions;
        public override uint Id
        {
        	get { return 1301; }
        }
        public StartupActionsListMessage()
        {
        }
        public StartupActionsListMessage(StartupActionAddObject[] actions)
        {
            this.actions = actions;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)actions.Length);
            foreach (var entry in actions)
            {
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            actions = new StartupActionAddObject[limit];
            for (int i = 0; i < limit; i++)
            {
                 actions[i] = new StartupActionAddObject();
                 actions[i].Deserialize(reader);
            }
		}
	}
}
