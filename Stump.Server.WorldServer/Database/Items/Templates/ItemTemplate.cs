using Stump.Core.IO;
using Stump.Core.Reflection;
using Stump.DofusProtocol.Classes;
using Stump.DofusProtocol.Tools.D2o;
using Stump.ORM;
using Stump.ORM.SubSonic.SQLGeneration.Schema;
using Stump.Server.WorldServer.Database.I18n;
using Stump.Server.WorldServer.Game.Conditions;
using Stump.Server.WorldServer.Game.Effects;
using Stump.Server.WorldServer.Game.Effects.Instances;
using Stump.Server.WorldServer.Game.Items;
using System;
using System.Linq;
namespace Stump.Server.WorldServer.Database.Items.Templates
{
	[D2OClass("Item", "com.ankamagames.dofus.datacenter.items", true), TableName("items_templates")]
	public class ItemTemplate : IAutoGeneratedRecord, ISaveIntercepter, IAssignedByD2O
	{
        // FIELDS
		public const uint EquipementCategory = 0u;
		public const uint ConsumablesCategory = 1u;
		public const uint RessourcesCategory = 2u;
		public const uint QuestCategory = 3u;
		public const uint OtherCategory = 4u;
		private ConditionExpression m_criteriaExpression;
		private string m_description;
		private System.Collections.Generic.List<EffectBase> m_effects;
		private uint[] m_favoriteSubAreas;
		private string m_favoriteSubAreasCSV;
		private ItemSetTemplate m_itemSet;
		private string m_name;
		private System.Collections.Generic.List<EffectInstance> m_possibleEffects;
		private byte[] m_possibleEffectsBin;
		private uint[] m_recipeIds;
		private string m_recipeIdsCSV;
		private ItemTypeRecord m_type;

        // PROPERTIES
		[PrimaryKey("Id", false)]
		public int Id
		{
			get;
			set;
		}
		public uint Weight
		{
			get;
			set;
		}
		public uint RealWeight
		{
			get;
			set;
		}
		public uint NameId
		{
			get;
			set;
		}
		public string Name
		{
			get
			{
				string arg_23_0;
				if ((arg_23_0 = this.m_name) == null)
				{
					arg_23_0 = (this.m_name = Singleton<TextManager>.Instance.GetText(this.NameId));
				}
				return arg_23_0;
			}
		}
		public uint TypeId
		{
			get;
			set;
		}
		public ItemTypeRecord Type
		{
			get
			{
				ItemTypeRecord arg_23_0;
				if ((arg_23_0 = this.m_type) == null)
				{
					arg_23_0 = (this.m_type = Singleton<ItemManager>.Instance.TryGetItemType((int)this.TypeId));
				}
				return arg_23_0;
			}
		}
		public uint DescriptionId
		{
			get;
			set;
		}
		public string Descrption
		{
			get
			{
				string arg_23_0;
				if ((arg_23_0 = this.m_description) == null)
				{
					arg_23_0 = (this.m_description = Singleton<TextManager>.Instance.GetText(this.DescriptionId));
				}
				return arg_23_0;
			}
		}
		public int IconId
		{
			get;
			set;
		}
		public uint Level
		{
			get;
			set;
		}
		public bool Cursed
		{
			get;
			set;
		}
		public int UseAnimationId
		{
			get;
			set;
		}
		public bool Usable
		{
			get;
			set;
		}
		public bool Targetable
		{
			get;
			set;
		}
		public double Price
		{
			get;
			set;
		}
		public bool TwoHanded
		{
			get;
			set;
		}
		public bool Etheral
		{
			get;
			set;
		}
		public int ItemSetId
		{
			get;
			set;
		}
		[Ignore]
		public ItemSetTemplate ItemSet
		{
			get
			{
				ItemSetTemplate arg_2F_0;
				if (this.ItemSetId >= 0)
				{
					if ((arg_2F_0 = this.m_itemSet) == null)
					{
						arg_2F_0 = (this.m_itemSet = Singleton<ItemManager>.Instance.TryGetItemSetTemplate((uint)this.ItemSetId));
					}
				}
				else
				{
					arg_2F_0 = null;
				}
				return arg_2F_0;
			}
		}
		[NullString]
		public string Criteria
		{
			get;
			set;
		}
		[Ignore]
		public ConditionExpression CriteriaExpression
		{
			get
			{
				ConditionExpression result;
				if (string.IsNullOrEmpty(this.Criteria) || this.Criteria == "null")
				{
					result = null;
				}
				else
				{
					ConditionExpression arg_47_0;
					if ((arg_47_0 = this.m_criteriaExpression) == null)
					{
						arg_47_0 = (this.m_criteriaExpression = ConditionExpression.Parse(this.Criteria));
					}
					result = arg_47_0;
				}
				return result;
			}
			set
			{
				this.m_criteriaExpression = value;
				this.Criteria = ((value != null) ? value.ToString() : null);
			}
		}
		public bool HideEffects
		{
			get;
			set;
		}
		public uint AppearanceId
		{
			get;
			set;
		}
		public string RecipeIdsCSV
		{
			get
			{
				return this.m_recipeIdsCSV;
			}
			set
			{
				this.m_recipeIdsCSV = value;
                this.m_recipeIds = value.FromCSV<uint>(",");
			}
		}
		[Ignore]
		public uint[] RecipeIds
		{
			get
			{
				return this.m_recipeIds;
			}
			set
			{
				this.m_recipeIds = value;
				this.m_recipeIdsCSV = value.ToCSV(",");
			}
		}
		public string FavoriteSubAreasCSV
		{
			get
			{
				return this.m_favoriteSubAreasCSV;
			}
			set
			{
				this.m_favoriteSubAreasCSV = value;
                this.m_favoriteSubAreas = value.FromCSV<uint>(",");
			}
		}
		[Ignore]
		public uint[] FavoriteSubAreas
		{
			get
			{
				return this.m_favoriteSubAreas;
			}
			set
			{
				this.m_favoriteSubAreas = value;
				this.m_favoriteSubAreasCSV = value.ToCSV(",");
			}
		}
		public bool BonusIsSecret
		{
			get;
			set;
		}
		public byte[] PossibleEffectsBin
		{
			get
			{
				return this.m_possibleEffectsBin;
			}
			set
			{
				this.m_possibleEffectsBin = value;
				this.m_possibleEffects = ((value == null) ? null : value.ToObject<System.Collections.Generic.List<EffectInstance>>());
			}
		}
		[Ignore]
		public System.Collections.Generic.List<EffectInstance> PossibleEffects
		{
			get
			{
				return this.m_possibleEffects;
			}
			set
			{
				this.m_possibleEffects = value;
				this.m_possibleEffectsBin = ((value == null) ? null : value.ToBinary());
				this.m_effects = ((value == null) ? new System.Collections.Generic.List<EffectBase>() : new System.Collections.Generic.List<EffectBase>(this.PossibleEffects.Select(new Func<EffectInstance, EffectBase>(Singleton<EffectManager>.Instance.ConvertExportedEffect))));
			}
		}
		[Ignore]
		public System.Collections.Generic.List<EffectBase> Effects
		{
			get
			{
				System.Collections.Generic.List<EffectBase> result;
				if (this.m_effects != null)
				{
					result = this.m_effects;
				}
				else
				{
					if (this.PossibleEffects == null)
					{
						result = (this.m_effects = new System.Collections.Generic.List<EffectBase>());
					}
					else
					{
						result = (this.m_effects = new System.Collections.Generic.List<EffectBase>(this.PossibleEffects.Select(new Func<EffectInstance, EffectBase>(Singleton<EffectManager>.Instance.ConvertExportedEffect))));
					}
				}
				return result;
			}
			set
			{
				this.m_effects = value;
			}
		}
		public uint FavoriteSubAreasBonus
		{
			get;
			set;
		}
		public bool IsLinkedToOwner
		{
			get;
			set;
		}

        // CONSTRUCTORS

        // METHODS
		public virtual void AssignFields(object d2oObject)
		{
			Item item = (Item)d2oObject;
			this.Id = item.id;
			this.Weight = item.weight;
			this.RealWeight = item.realWeight;
			this.NameId = item.nameId;
			this.TypeId = item.typeId;
			this.DescriptionId = item.descriptionId;
			this.IconId = item.iconId;
			this.Level = item.level;
			this.Cursed = item.cursed;
			this.UseAnimationId = item.useAnimationId;
			this.Usable = item.usable;
			this.Targetable = item.targetable;
			this.Price = item.price;
			this.TwoHanded = item.twoHanded;
			this.Etheral = item.etheral;
			this.ItemSetId = item.itemSetId;
			this.Criteria = item.criteria;
			this.HideEffects = item.hideEffects;
			this.AppearanceId = item.appearanceId;
			this.RecipeIds = item.recipeIds.ToArray();
			this.FavoriteSubAreas = item.favoriteSubAreas.ToArray();
			this.BonusIsSecret = item.bonusIsSecret;
			this.PossibleEffects = item.possibleEffects;
			this.FavoriteSubAreasBonus = item.favoriteSubAreasBonus;
		}
		public void BeforeSave(bool insert)
		{
			System.Collections.Generic.List<EffectInstance> arg_39_1;
			if (this.m_effects != null)
			{
				arg_39_1 = (
					from entry in this.m_effects
					select entry.GetEffectInstance()).ToList<EffectInstance>();
			}
			else
			{
				arg_39_1 = null;
			}
			this.m_possibleEffects = arg_39_1;
			this.m_possibleEffectsBin = ((this.m_possibleEffects == null) ? null : this.m_possibleEffects.ToBinary());
			this.m_favoriteSubAreasCSV = this.m_favoriteSubAreas.ToCSV(",");
			this.m_recipeIdsCSV = this.m_recipeIds.ToCSV(",");
		}
		public bool IsWeapon()
		{
			return this is WeaponTemplate;
		}
		public override string ToString()
		{
			return string.Format("{0} ({1})", this.Name, this.Id);
		}
	}
}
