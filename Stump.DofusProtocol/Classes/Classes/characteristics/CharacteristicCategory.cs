

















// Generated on 07/24/2015 19:45:54
using System;
using System.Collections.Generic;
using Stump.DofusProtocol.Classes;
using Stump.DofusProtocol.Tools.D2o;

namespace Stump.DofusProtocol.Classes
{

[D2OClass("CharacteristicCategories")]
    
public class CharacteristicCategory : IDataObject
{

public const String MODULE = "CharacteristicCategories";
        public int id;
        public uint nameId;
        public int order;
        public List<uint> characteristicIds;
        

}

}