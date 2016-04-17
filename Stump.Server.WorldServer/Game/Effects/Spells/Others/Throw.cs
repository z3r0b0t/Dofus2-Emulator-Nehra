﻿using System;
using Stump.DofusProtocol.Enums;
using Stump.DofusProtocol.Messages;
using Stump.Server.BaseServer.Network;
using Stump.Server.WorldServer.Database.World;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Effects.Handlers;
using Stump.Server.WorldServer.Game.Effects.Instances;
using Stump.Server.WorldServer.Game.Spells;
using System.Linq;
using Stump.Server.WorldServer.Game.Fights.Buffs;

namespace Stump.Server.WorldServer.Game.Effects.Spells.Others
{
    [EffectHandler(EffectsEnum.Effect_Carry)]
    class Throw : SpellEffectHandler
    {
        public Throw(EffectDice effect, FightActor caster, Spell spell, Cell targetedCell, bool critical) : base(effect, caster, spell, targetedCell, critical)
        {
        }
        public override bool Apply()
        {
            if(this.Caster.Carrier == this.Caster && this.Caster.Carried != null)
            {
                this.Caster.Throw(this.TargetedCell);
                this.OnApply();
                return true;
            }
            return false;
        }
        private void OnApply()
        {
        }
    }
}