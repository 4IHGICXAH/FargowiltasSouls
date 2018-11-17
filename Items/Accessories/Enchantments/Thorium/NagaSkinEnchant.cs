using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using ThoriumMod;

namespace FargowiltasSouls.Items.Accessories.Enchantments.Thorium
{
    public class NagaSkinEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");
        
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetLoadedMods().Contains("ThoriumMod");
        }
        
        public override string Texture => "FargowiltasSouls/Items/Placeholder";
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Naga-Skin Enchantment");
            Tooltip.SetDefault(@"
''
Allows quicker movement in water
Every 75 mana spent will dramatically increase your magic damage and casting speed briefly");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 5;
            item.value = 150000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!Fargowiltas.Instance.ThoriumLoaded) return;
            
            NagaEffect(player);
        }
        
        private void NagaEffect(Player player)
        {
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>(thorium);
            //naga set bonus
            thoriumPlayer.nagaManaEffect = true;
            //quicker in water
            player.ignoreWater = true;
            if (player.wet)
            {
                player.moveSpeed += 0.15f;
            }
            //breath underwater
            if (player.breath <= player.breathMax + 2)
            {
                player.breath = player.breathMax + 3;
            }
        }
        
        private readonly string[] items =
        {
            "NagaSkinMask",
            "NagaSkinSuit",
            "NagaSkinTail",
            "Eelrod",
            "CycloneBook",
            "NagaRecurve",
            "NagaSpitStaff",
            "HydromancerCatalyst",
            "Leviathan",
            "OldGodGrasp"
        };

        public override void AddRecipes()
        {
            if (!Fargowiltas.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);
            
            foreach (string i in items) recipe.AddIngredient(thorium.ItemType(i));

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
