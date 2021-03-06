


















// Generated on 07/24/2015 23:20:22
using System;
using System.Collections.Generic;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{

public class HumanOptionOrnament : HumanOption
{

public const short Id = 411;
public override short TypeId
{
    get { return Id; }
}

public ushort ornamentId;
        

public HumanOptionOrnament()
{
}

public HumanOptionOrnament(ushort ornamentId)
        {
            this.ornamentId = ornamentId;
        }
        

public override void Serialize(ICustomDataOutput writer)
{

base.Serialize(writer);
            writer.WriteVarUhShort(ornamentId);
            

}

public override void Deserialize(ICustomDataInput reader)
{

base.Deserialize(reader);
            ornamentId = reader.ReadVarUhShort();
            if (ornamentId < 0)
                throw new Exception("Forbidden value on ornamentId = " + ornamentId + ", it doesn't respect the following condition : ornamentId < 0");
            

}


}


}