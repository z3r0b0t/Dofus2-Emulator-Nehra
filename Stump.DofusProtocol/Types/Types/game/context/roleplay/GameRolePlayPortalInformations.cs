


















// Generated on 07/24/2015 23:20:22
using System;
using System.Collections.Generic;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{

public class GameRolePlayPortalInformations : GameRolePlayActorInformations
{

public const short Id = 467;
public override short TypeId
{
    get { return Id; }
}

public Types.PortalInformation portal;
        

public GameRolePlayPortalInformations()
{
}

public GameRolePlayPortalInformations(int contextualId, Types.EntityLook look, Types.EntityDispositionInformations disposition, Types.PortalInformation portal)
         : base(contextualId, look, disposition)
        {
            this.portal = portal;
        }
        

public override void Serialize(ICustomDataOutput writer)
{

base.Serialize(writer);
            writer.WriteShort(portal.TypeId);
            portal.Serialize(writer);
            

}

public override void Deserialize(ICustomDataInput reader)
{

base.Deserialize(reader);
            portal = Types.ProtocolTypeManager.GetInstance<Types.PortalInformation>(reader.ReadShort());
            portal.Deserialize(reader);
            

}


}


}