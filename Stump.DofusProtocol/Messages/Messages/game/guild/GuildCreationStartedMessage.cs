









// Generated on 07/24/2015 23:20:05
using System;
using System.Collections.Generic;
using System.Linq;
using Stump.DofusProtocol.Types;
using Stump.DofusProtocol.Messages;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    public class GuildCreationStartedMessage : Message
    {
        public const ushort Id = 5920;
        public override ushort MessageId
        {
            get { return Id; }
        }
        
        
        public GuildCreationStartedMessage()
        {
        }
        
        
        public override void Serialize(ICustomDataOutput writer)
        {
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
        }
        
    }
    
}