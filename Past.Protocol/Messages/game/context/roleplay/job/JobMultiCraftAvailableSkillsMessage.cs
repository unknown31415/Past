using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class JobMultiCraftAvailableSkillsMessage : JobAllowMultiCraftRequestMessage
	{
        public int playerId;
        public short[] skills;
        public override uint Id
        {
        	get { return 5747; }
        }
        public JobMultiCraftAvailableSkillsMessage()
        {
        }
        public JobMultiCraftAvailableSkillsMessage(bool enabled, int playerId, short[] skills) : base(enabled)
        {
            this.playerId = playerId;
            this.skills = skills;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(playerId);
            writer.WriteUShort((ushort)skills.Length);
            foreach (var entry in skills)
            {
                 writer.WriteShort(entry);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            playerId = reader.ReadInt();
            if (playerId < 0)
                throw new Exception("Forbidden value on playerId = " + playerId + ", it doesn't respect the following condition : playerId < 0");
            var limit = reader.ReadUShort();
            skills = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 skills[i] = reader.ReadShort();
            }
		}
	}
}
