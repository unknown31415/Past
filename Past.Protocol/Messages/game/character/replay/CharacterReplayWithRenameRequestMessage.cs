using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class CharacterReplayWithRenameRequestMessage : CharacterReplayRequestMessage
	{
        public string name;
        public override uint Id
        {
        	get { return 6122; }
        }
        public CharacterReplayWithRenameRequestMessage()
        {
        }
        public CharacterReplayWithRenameRequestMessage(int characterId, string name) : base(characterId)
        {
            this.name = name;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(name);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            name = reader.ReadUTF();
		}
	}
}
