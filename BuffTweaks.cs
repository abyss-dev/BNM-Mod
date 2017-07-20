using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace BNM
{
	public class BuffTweaks : GlobalBuff
	{
		public override void ModifyBuffTip(int type, ref string tip, ref int rare)
		{
			switch(type)
        	{
        	    case BuffID.WeaponImbueConfetti:
        	    case BuffID.WeaponImbueCursedFlames:
        	    case BuffID.WeaponImbueFire:
        	    case BuffID.WeaponImbueGold:
        	    case BuffID.WeaponImbueIchor:
        	    case BuffID.WeaponImbueNanites:
        	    case BuffID.WeaponImbuePoison:
        	    case BuffID.WeaponImbueVenom:
					tip = tip.Insert(6, "& Throwing ");
        	        break;
        	}
    	}
	}
}