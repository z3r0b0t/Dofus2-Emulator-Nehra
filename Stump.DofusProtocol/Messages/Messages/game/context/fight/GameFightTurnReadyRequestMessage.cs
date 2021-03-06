









// Generated on 07/24/2015 23:19:55
using System;
using System.Collections.Generic;
using System.Linq;
using Stump.DofusProtocol.Types;
using Stump.DofusProtocol.Messages;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    public class GameFightTurnReadyRequestMessage : Message
    {
        public const ushort Id = 715;
        public override ushort MessageId
        {
            get { return Id; }
        }
        
        public int id;
        
        public GameFightTurnReadyRequestMessage()
        {
        }
        
        public GameFightTurnReadyRequestMessage(int id)
        {
            this.id = id;
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(id);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            id = reader.ReadInt();
        }
        
    }
    
}