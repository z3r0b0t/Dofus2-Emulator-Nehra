









// Generated on 07/24/2015 23:20:02
using System;
using System.Collections.Generic;
using System.Linq;
using Stump.DofusProtocol.Types;
using Stump.DofusProtocol.Messages;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    public class PartyKickRequestMessage : AbstractPartyMessage
    {
        public const ushort Id = 5592;
        public override ushort MessageId
        {
            get { return Id; }
        }
        
        public uint playerId;
        
        public PartyKickRequestMessage()
        {
        }
        
        public PartyKickRequestMessage(uint partyId, uint playerId)
         : base(partyId)
        {
            this.playerId = playerId;
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(playerId);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            playerId = reader.ReadVarUhInt();
            if (playerId < 0)
                throw new Exception("Forbidden value on playerId = " + playerId + ", it doesn't respect the following condition : playerId < 0");
        }
        
    }
    
}