using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;

namespace BNM
{
	public class ItemTweaks : GlobalItem
	{

		const string CobaltSet = "cobalt";
		
		public override void SetDefaults(Item item)
		{
			//Shortsword Buff
			if (Config.shortswordBuff)
			{
				switch(item.type)
				{
					
					case ItemID.CopperShortsword:
						item.damage = 9;
						item.useAnimation = 15;
						item.useTime = 15;
						break;
					case ItemID.TinShortsword:
						item.damage = 10;
						item.useAnimation = 14;
						item.useTime = 14;
						break;
					case ItemID.IronShortsword:
						item.damage = 11;
						item.useAnimation = 14;
						item.useTime = 14;
						break;
					case ItemID.LeadShortsword:
						item.damage = 12;
						item.useAnimation = 13;
						item.useTime = 13;
						break;
					case ItemID.SilverShortsword:
						item.damage = 12;
						item.useAnimation = 13;
						item.useTime = 13;
						break;
					case ItemID.TungstenShortsword:
						item.damage = 13;
						item.useAnimation = 13;
						item.useTime = 13;
						break;
					case ItemID.GoldShortsword:
						item.damage = 14;
						item.useAnimation = 12;
						item.useTime = 12;
						break;
					case ItemID.PlatinumShortsword:
						item.damage = 16;
						item.useAnimation = 11;
						item.useTime = 11;
						break;
				}
			}
			//Misc. Pre-Hardmode
			switch(item.type)
			{
				case ItemID.ZombieArm:
					item.knockBack = 10f;
					break;
				case ItemID.StylistKilLaKillScissorsIWish: //lmao
					item.autoReuse = true;
					break;
				//Magic Weapon Tweaks

				//Ranged Weapon Tweaks

				//Summoner Weapon Tweaks

				//Throwing Weapon Tweaks

				//Other Tweaks
				
				/*case ItemID.Blindfold:
					AddTooltip2(item, "Immunity to Stoned");
					break;
				case ItemID.RuneHat:
					item.vanity = false;
					item.defense = 4;
					AddTooltip(item, "+20% Increased Magic Damage and Crit Chance");
					AddTooltip2(item, "-50 Mana");
					break;
				case ItemID.RuneRobe:
					item.vanity = false;
					item.defense = 8;
					AddTooltip(item, "+15% Increased Magic Damage and 6% Increased Movement Speed");
					AddTooltip2(item, "+12% Increased Mana Usage");
					break;*/
			}
			//
			switch(item.type)
			{

			}
		}
		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
		{
			try
			{
				//Flasks
		    	switch(item.type)
    			{
    			    case ItemID.FlaskofGold:
    			    case ItemID.FlaskofVenom:
    			    case ItemID.FlaskofCursedFlames:
    			    case ItemID.FlaskofFire:
    			    case ItemID.FlaskofIchor:
    			    case ItemID.FlaskofNanites:
    			    case ItemID.FlaskofParty:
    			    case ItemID.FlaskofPoison:
                        //Causes an error
						int index = tooltips.FindIndex(i => i.Name == "Tooltip1");
						string text = tooltips[index].text;
						tooltips[index].text = text.Insert(6, "& Throwing ");
						break;
    			}
    			//Armor Penetration
    			switch(item.type)
    			{
    				case ItemID.StylistKilLaKillScissorsIWish:
					case ItemID.AntlionClaw:
						tooltips.Add(new TooltipLine(mod, "armorPenetration", "Slight armor penetration"));
						break;
					case ItemID.BluePhaseblade:
					case ItemID.RedPhaseblade:
					case ItemID.GreenPhaseblade:
					case ItemID.PurplePhaseblade:
					case ItemID.WhitePhaseblade:
					case ItemID.YellowPhaseblade:
						tooltips.Add(new TooltipLine(mod, "armorPenetration", "Minor armor penetration"));
						break;
					case ItemID.BluePhasesaber:
					case ItemID.RedPhasesaber:
					case ItemID.GreenPhasesaber:
					case ItemID.PurplePhasesaber:
					case ItemID.WhitePhasesaber:
					case ItemID.YellowPhasesaber:
						tooltips.Add(new TooltipLine(mod, "armorPenetration", "Decent armor penetration"));
						break;
    			}
    			//IDK
    			switch(item.type)
    			{
    				case ItemID.MechanicalGlove:
    					tooltips[tooltips.FindIndex(i => i.Name == "Tooltip2")].text = "20% increased melee damage and speed";
    					break;
    				case ItemID.CelestialEmblem:
    					tooltips[tooltips.FindIndex(i => i.Name == "Tooltip2")].text = "20% increased magic damage";
    					break;
    			}
		    }
			catch(Exception e)
    		{
    		    Main.NewText(e.ToString()); 
    		}
		}
		public override void UpdateEquip(Item item, Player player)
		{
			switch(item.type)
			{
				case ItemID.CelestialEmblem:
					player.magicDamage *= 1.05f;
					break;
				case ItemID.MechanicalGlove:
					player.meleeDamage *= 1.08f;
					player.meleeSpeed *= 1.08f;
					break;
			}
		}
		public override string IsArmorSet(Item head, Item body, Item legs)
		{
			if (head.type == ItemID.CobaltHat && body.type == ItemID.CobaltBreastplate && legs.type == ItemID.CobaltLeggings || head.type == ItemID.CobaltHelmet && body.type == ItemID.CobaltBreastplate && legs.type == ItemID.CobaltLeggings || head.type == ItemID.CobaltMask && body.type == ItemID.CobaltBreastplate && legs.type == ItemID.CobaltLeggings)
				return CobaltSet;
			return string.Empty;	
		}
		public override void UpdateArmorSet(Player player, string armorSet)
		{
			switch(armorSet)
			{
				case CobaltSet:
					player.setBonus = @"Weapon speed rapidly increases to 1.5x while being used
            Doesn't work with non-autoswing weapons";
					player.GetModPlayer<MPlayer>(mod).cobaltOverdrive = true;
					break;
			}
		}
	}
}