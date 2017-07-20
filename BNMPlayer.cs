using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BNM
{
	public class MPlayer : ModPlayer
	{
		public bool cobaltOverdrive;

		public float minUseTime;
		public float minUseAnimation;

		public int lastSelectedItem;
		public int useTimer;

		public byte itemPrefix;

		public override void ResetEffects()
		{
			cobaltOverdrive = false;
		}

		public bool HasBuff(int type)
		{
		    for(int i = 0; i < player.buffType.Length; i++)
		    {
		        if (player.buffType[i] == type)
		        {
		            return true;
		        }
		    }
		    return false;
		}
		public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            if (item.type == ItemID.StylistKilLaKillScissorsIWish)
            {
                damage = (int)(Main.DamageVar(item.damage * player.meleeDamage) + target.checkArmorPenetration(2));
            }
            if (item.type == ItemID.AntlionClaw)
            {
                damage = (int)(Main.DamageVar(item.damage * player.meleeDamage) + target.checkArmorPenetration(3));
            }
            if (item.type == ItemID.BluePhaseblade || item.type == ItemID.RedPhaseblade || item.type == ItemID.GreenPhaseblade || item.type == ItemID.PurplePhaseblade || item.type == ItemID.WhitePhaseblade || item.type == ItemID.YellowPhaseblade)
            {
                damage = (int)(Main.DamageVar(item.damage * player.meleeDamage) + target.checkArmorPenetration(7));
            }
            if (item.type == ItemID.BluePhasesaber || item.type == ItemID.RedPhasesaber || item.type == ItemID.GreenPhasesaber || item.type == ItemID.PurplePhasesaber || item.type == ItemID.WhitePhasesaber || item.type == ItemID.YellowPhasesaber)
            {
                damage = (int)(Main.DamageVar(item.damage * player.meleeDamage) + target.checkArmorPenetration(15));
            }
        }

        public override void PreUpdate()
    	{
    		if (player.selectedItem != lastSelectedItem)
			{
			    lastSelectedItem = player.selectedItem;
			    minUseTime = (int)player.inventory[player.selectedItem].useTime / 1.75f;
				minUseAnimation = (int)player.inventory[player.selectedItem].useAnimation / 1.75f;
				itemPrefix = player.inventory[player.selectedItem].prefix;
			}
    		if (cobaltOverdrive)
    		{
    			Item heldItem = player.inventory[player.selectedItem];
				if (heldItem == null) { return; }

				if (heldItem.damage > 0 && heldItem.autoReuse)
				{
					if (Main.mouseLeft)
					{
						if (Main.rand.Next(heldItem.useTime) == 0)
						{
							int i = Dust.NewDust(player.position, player.width, player.height, 68, player.velocity.X, player.velocity.Y, 1, default(Color), 1.1f);
            				Main.dust[i].noGravity = true;
						}
						useTimer++;
						if (useTimer > 120)
						{
							useTimer = 0;
							heldItem.useTime -= 1;
							heldItem.useAnimation -= 1;
						}
						if (heldItem.useTime < minUseTime)
						{
							heldItem.useTime = (int)minUseTime;
						}
						if (heldItem.useAnimation < minUseAnimation)
						{
							heldItem.useAnimation = (int)minUseAnimation;
						}
					}
					else
					{
						heldItem.SetDefaults(heldItem.type);
						player.inventory[player.selectedItem].prefix = itemPrefix;
					}
				}
    		}
    	}
	}
}