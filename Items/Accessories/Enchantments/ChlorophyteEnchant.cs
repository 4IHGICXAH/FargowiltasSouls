using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasSouls.Items.Accessories.Enchantments
{
    public class ChlorophyteEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chlorophyte Enchantment");
            Tooltip.SetDefault(
                @"'The jungle's essence crystallizes above you'
Summons a leaf crystal to shoot at nearby enemies
Flowers grow on the grass you walk on
All herb collection is doubled
Summons a pet Seedling");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 7;
            item.value = 150000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //crystal and pet
            player.GetModPlayer<FargoPlayer>(mod).ChloroEffect(hideVisual, 100);
            //herb double
            player.GetModPlayer<FargoPlayer>(mod).ChloroEnchant = true;
            player.GetModPlayer<FargoPlayer>(mod).FlowerBoots();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("FargowiltasSouls:AnyChloroHead");
            recipe.AddIngredient(ItemID.ChlorophytePlateMail);
            recipe.AddIngredient(ItemID.ChlorophyteGreaves);
            recipe.AddIngredient(ItemID.FlowerBoots);
            recipe.AddIngredient(ItemID.StaffofRegrowth);

            if(Fargowiltas.Instance.ThoriumLoaded)
            {      
                recipe.AddIngredient(thorium.ItemType("ChlorophyteStaff"));
                recipe.AddIngredient(ItemID.FlowerPow);
                recipe.AddIngredient(ItemID.LeafBlower);
                recipe.AddIngredient(thorium.ItemType("ChlorophyteButterfly"));
            }
            else
            {
                recipe.AddIngredient(ItemID.LeafBlower);
            }
            
            recipe.AddIngredient(ItemID.Seedling);
            
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
