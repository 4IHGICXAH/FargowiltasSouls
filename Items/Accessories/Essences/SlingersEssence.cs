using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasSouls.Items.Accessories.Essences
{
    public class SlingersEssence : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slinger's Essence");
            Tooltip.SetDefault(
@"'This is only the beginning..'
18% increased throwing damage
5% increased throwing critical chance
5% increased throwing velocity");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            item.value = 150000;
            item.rare = 4;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.thrownDamage += 0.18f;
            player.thrownCrit += 5;
            player.thrownVelocity += 0.05f;
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            /*if (Fargowiltas.Instance.ThoriumLoaded)
            {
                //ninja emblem
                //desert wind rune
                recipe.AddIngredient(ModLoader.GetMod("Fargowiltas").ItemType("WoodenYoyoThrown"));
                recipe.AddIngredient(ModLoader.GetMod("Fargowiltas").ItemType("BloodyMacheteThrown"));
                recipe.AddIngredient(ModLoader.GetMod("Fargowiltas").ItemType("IceBoomerangThrown"));
                //goblin war spear
                recipe.AddIngredient(ModLoader.GetMod("Fargowiltas").ItemType("MeatballThrown"));
                //sea ninja star
                recipe.AddIngredient(ModLoader.GetMod("Fargowiltas").ItemType("ThornChakramThrown"));
                recipe.AddIngredient(ItemID.BoneGlove);
                recipe.AddIngredient(ItemID.BlueMoon);
                //champion god hand // champion
                //gauss flinger //saucer

            }
            else*/ if (Fargowiltas.Instance.FargosLoaded)
            {
                //no others
                recipe.AddIngredient(ModLoader.GetMod("Fargowiltas").ItemType("WoodenYoyoThrown"));
                recipe.AddIngredient(ModLoader.GetMod("Fargowiltas").ItemType("BloodyMacheteThrown"));
                recipe.AddIngredient(ModLoader.GetMod("Fargowiltas").ItemType("IceBoomerangThrown"));
                recipe.AddIngredient(ItemID.MolotovCocktail, 99);
                recipe.AddIngredient(ModLoader.GetMod("Fargowiltas").ItemType("TheMeatballThrown"));
                recipe.AddIngredient(ModLoader.GetMod("Fargowiltas").ItemType("ThornChakramThrown"));
                recipe.AddIngredient(ItemID.BoneGlove);
                recipe.AddIngredient(ItemID.BlueMoon);
                recipe.AddIngredient(ModLoader.GetMod("Fargowiltas").ItemType("FlamarangThrown"));
            }
            else
            {
                recipe.AddIngredient(ItemID.WoodYoyo);
                recipe.AddIngredient(ItemID.BloodyMachete);
                recipe.AddIngredient(ItemID.IceBoomerang);
                recipe.AddIngredient(ItemID.MolotovCocktail, 99);
                recipe.AddIngredient(ItemID.TheMeatball);
                recipe.AddIngredient(ItemID.ThornChakram);
                recipe.AddIngredient(ItemID.BoneGlove);
                recipe.AddIngredient(ItemID.BlueMoon);
                recipe.AddIngredient(ItemID.Flamarang);
            }

            recipe.AddIngredient(ItemID.BlueMoon);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
