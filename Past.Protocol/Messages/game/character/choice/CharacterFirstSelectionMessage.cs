using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class CharacterFirstSelectionMessage : CharacterSelectionMessage
	{
        public bool doTutorial;
        public override uint Id
        {
        	get { return 6084; }
        }
        public CharacterFirstSelectionMessage()
        {
        }
        public CharacterFirstSelectionMessage(int id, bool doTutorial) : base(id)
        {
            this.doTutorial = doTutorial;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(doTutorial);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            doTutorial = reader.ReadBoolean();
		}
	}
}
