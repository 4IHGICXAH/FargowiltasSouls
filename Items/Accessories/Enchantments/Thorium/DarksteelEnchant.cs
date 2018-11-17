using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using ThoriumMod;

namespace FargowiltasSouls.Items.Accessories.Enchantments.Thorium
{
    public class DarksteelEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");
        
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetLoadedMods().Contains("ThoriumMod");
        }
        
        public override string Texture => "FargowiltasSouls/Items/Placeholder";
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Darksteel Enchantment");
            Tooltip.SetDefault(
                @"'Light yet durable'
Grants the ability to dash, knockback immunity and Ice Skates effect");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 3;
            item.value = 80000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!Fargowiltas.Instance.ThoriumLoaded) return;
            
            DarksteelEffect(player);
        }
        
        private void DarksteelEffect(Player player)
        {
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>(thorium);
            player.noKnockback = true;
            player.iceSkate = true;
            player.dash = 1;
        }
        
        private readonly string[] items =
        {
            "BallnChain",
            "eeDarksteelMace",
            "eeSoulSiphon",
            "ManHacker",
            "DarksteelHelmetStand",
            "GrayDPaintingItem",
        };

        public override void AddRecipes()
        {
            if (!Fargowiltas.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(thorium.ItemType("hDarksteelFaceGuard"));
            recipe.AddIngredient(thorium.ItemType("iDarksteelBreastPlate"));
            recipe.AddIngredient(thorium.ItemType("jDarksteelGreaves"));
            recipe.AddIngredient(null, "SteelEnchant");

            foreach (string i in items) recipe.AddIngredient(thorium.ItemType(i));

            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
