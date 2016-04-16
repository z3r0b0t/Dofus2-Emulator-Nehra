









// Generated on 07/24/2015 23:20:16
using System;
using System.Collections.Generic;
using System.Linq;
using Stump.DofusProtocol.Types;
using Stump.DofusProtocol.Messages;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    public class URLOpenMessage : Message
    {
        public const ushort Id = 6266;
        public override ushort MessageId
        {
            get { return Id; }
        }
        
        public sbyte urlId;
        
        public URLOpenMessage()
        {
        }
        
        public URLOpenMessage(sbyte urlId)
        {
            this.urlId = urlId;
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteSByte(urlId);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            urlId = reader.ReadSByte();
            if (urlId < 0)
                throw new Exception("Forbidden value on urlId = " + urlId + ", it doesn't respect the following condition : urlId < 0");
        }
        
    }
    
}