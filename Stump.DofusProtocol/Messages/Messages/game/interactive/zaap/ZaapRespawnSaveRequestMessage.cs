









// Generated on 07/24/2015 23:20:08
using System;
using System.Collections.Generic;
using System.Linq;
using Stump.DofusProtocol.Types;
using Stump.DofusProtocol.Messages;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    public class ZaapRespawnSaveRequestMessage : Message
    {
        public const ushort Id = 6572;
        public override ushort MessageId
        {
            get { return Id; }
        }
        
        
        public ZaapRespawnSaveRequestMessage()
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