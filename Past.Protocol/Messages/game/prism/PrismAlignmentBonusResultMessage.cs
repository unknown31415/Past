using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class PrismAlignmentBonusResultMessage : NetworkMessage
	{
        public AlignmentBonusInformations alignmentBonus;
        public override uint Id
        {
        	get { return 5842; }
        }
        public PrismAlignmentBonusResultMessage()
        {
        }
        public PrismAlignmentBonusResultMessage(AlignmentBonusInformations alignmentBonus)
        {
            this.alignmentBonus = alignmentBonus;
        }
        public override void Serialize(IDataWriter writer)
        {
            alignmentBonus.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            alignmentBonus = new AlignmentBonusInformations();
            alignmentBonus.Deserialize(reader);
		}
	}
}
