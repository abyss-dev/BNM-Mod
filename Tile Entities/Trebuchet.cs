using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Terraria.ModLoader;
using Terraria;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BNMMod.Tile_Entities
{
    public class Trebuchet : ModTileEntity
    {
        public override bool ValidTile(int i, int j)
        {
            return true;
        }
    }
}
