









// Generated on 07/24/2015 23:20:11
using System;
using System.Collections.Generic;
using System.Linq;
using Stump.DofusProtocol.Types;
using Stump.DofusProtocol.Messages;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    public class ExchangeRequestedTradeMessage : ExchangeRequestedMessage
    {
        public const ushort Id = 5523;
        public override ushort MessageId
        {
            get { return Id; }
        }
        
        public uint source;
        public uint target;
        
        public ExchangeRequestedTradeMessage()
        {
        }
        
        public ExchangeRequestedTradeMessage(sbyte exchangeType, uint source, uint target)
         : base(exchangeType)
        {
            this.source = source;
            this.target = target;
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(source);
            writer.WriteVarUhInt(target);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            source = reader.ReadVarUhInt();
            if (source < 0)
                throw new Exception("Forbidden value on source = " + source + ", it doesn't respect the following condition : source < 0");
            target = reader.ReadVarUhInt();
            if (target < 0)
                throw new Exception("Forbidden value on target = " + target + ", it doesn't respect the following condition : target < 0");
        }
        
    }
    
}