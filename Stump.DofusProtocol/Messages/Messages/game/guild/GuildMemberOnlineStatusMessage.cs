









// Generated on 07/24/2015 23:20:06
using System;
using System.Collections.Generic;
using System.Linq;
using Stump.DofusProtocol.Types;
using Stump.DofusProtocol.Messages;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    public class GuildMemberOnlineStatusMessage : Message
    {
        public const ushort Id = 6061;
        public override ushort MessageId
        {
            get { return Id; }
        }
        
        public uint memberId;
        public bool online;
        
        public GuildMemberOnlineStatusMessage()
        {
        }
        
        public GuildMemberOnlineStatusMessage(uint memberId, bool online)
        {
            this.memberId = memberId;
            this.online = online;
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarUhInt(memberId);
            writer.WriteBoolean(online);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            memberId = reader.ReadVarUhInt();
            if (memberId < 0)
                throw new Exception("Forbidden value on memberId = " + memberId + ", it doesn't respect the following condition : memberId < 0");
            online = reader.ReadBoolean();
        }
        
    }
    
}