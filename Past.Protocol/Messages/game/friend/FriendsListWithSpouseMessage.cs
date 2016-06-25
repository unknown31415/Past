using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class FriendsListWithSpouseMessage : FriendsListMessage
	{
        public FriendSpouseInformations spouse;
        public override uint Id
        {
        	get { return 5931; }
        }
        public FriendsListWithSpouseMessage()
        {
        }
        public FriendsListWithSpouseMessage(FriendInformations[] friendsList, FriendSpouseInformations spouse) : base(friendsList)
        {
            this.spouse = spouse;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(spouse.TypeId);
            spouse.Serialize(writer);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            spouse = (FriendSpouseInformations)ProtocolTypeManager.GetInstance(reader.ReadUShort());
            spouse.Deserialize(reader);
		}
	}
}
