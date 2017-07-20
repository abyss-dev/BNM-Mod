using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameInput;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Terraria.UI.Chat;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Graphics;
using Terraria.GameContent.UI.Chat;

namespace BNM
{
    public class BNM : Mod
    {
        public BNM()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true,
				AutoloadBackgrounds = true
			};//O MY RUBBER NEN
		}
    }
}
