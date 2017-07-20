using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BNM
{
	public class GProjectile : GlobalProjectile
	{
		public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
		{
			for (int i = 0; i < Main.projectile.Length; i++)
			{
				if (Main.projectile[i].thrown)
				{
					if (Main.player[projectile.owner].GetModPlayer<MPlayer>(mod).HasBuff(79))
					{
						target.AddBuff(20, 60 * Main.rand.Next(5, 10), false);
					}
					if (Main.player[projectile.owner].GetModPlayer<MPlayer>(mod).HasBuff(74))
					{
						target.AddBuff(24, 60 * Main.rand.Next(3, 7), false);
					}
					if (Main.player[projectile.owner].GetModPlayer<MPlayer>(mod).HasBuff(71))
					{
						target.AddBuff(70, 60 * Main.rand.Next(5, 10), false);
					}
					if (Main.player[projectile.owner].GetModPlayer<MPlayer>(mod).HasBuff(75))
					{
						target.AddBuff(72, 120, false);
					}
					if (Main.player[projectile.owner].GetModPlayer<MPlayer>(mod).HasBuff(76))
					{
						target.AddBuff(69, 60 * Main.rand.Next(10, 20), false);
					}
					if (Main.player[projectile.owner].GetModPlayer<MPlayer>(mod).HasBuff(73))
					{
						target.AddBuff(39, 60 * Main.rand.Next(3, 7), false);
					}
					if (Main.player[projectile.owner].GetModPlayer<MPlayer>(mod).HasBuff(77))
					{
						target.AddBuff(31, 60 * Main.rand.Next(1, 4), false);
					}
					if (Main.player[projectile.owner].GetModPlayer<MPlayer>(mod).HasBuff(78))
					{
						Projectile.NewProjectile(target.Center.X, target.Center.Y, target.velocity.X, target.velocity.Y, 289, 0, 0f, projectile.whoAmI, 0f, 0f);
					}
				}
			}		
		}		
	}
}
