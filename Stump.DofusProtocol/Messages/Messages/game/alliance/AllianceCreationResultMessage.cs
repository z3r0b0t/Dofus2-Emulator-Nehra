









// Generated on 07/24/2015 23:19:49
using System;
using System.Collections.Generic;
using System.Linq;
using Stump.DofusProtocol.Types;
using Stump.DofusProtocol.Messages;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    public class AllianceCreationResultMessage : Message
    {
        public const ushort Id = 6391;
        public override ushort MessageId
        {
            get { return Id; }
        }
        
        public sbyte result;
        
        public AllianceCreationResultMessage()
        {
        }
        
        public AllianceCreationResultMessage(sbyte result)
        {
            this.result = result;
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteSByte(result);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            result = reader.ReadSByte();
            if (result < 0)
                throw new Exception("Forbidden value on result = " + result + ", it doesn't respect the following condition : result < 0");
        }
        
    }
    
}