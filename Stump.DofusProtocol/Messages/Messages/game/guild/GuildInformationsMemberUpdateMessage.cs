









// Generated on 07/24/2015 23:20:06
using System;
using System.Collections.Generic;
using System.Linq;
using Stump.DofusProtocol.Types;
using Stump.DofusProtocol.Messages;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    public class GuildInformationsMemberUpdateMessage : Message
    {
        public const ushort Id = 5597;
        public override ushort MessageId
        {
            get { return Id; }
        }
        
        public Types.GuildMember member;
        
        public GuildInformationsMemberUpdateMessage()
        {
        }
        
        public GuildInformationsMemberUpdateMessage(Types.GuildMember member)
        {
            this.member = member;
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            member.Serialize(writer);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            member = new Types.GuildMember();
            member.Deserialize(reader);
        }
        
    }
    
}