using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasSouls.Items.Accessories.Souls
{
    //[AutoloadEquip(EquipType.HandsOn, EquipType.HandsOff)]
    public class OlympiansSoul : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Olympian's Soul");
            Tooltip.SetDefault(
@"'Strike with deadly precision'
30% increased throwing damage
20% increased throwing speed
15% increased throwing critical chance and velocity");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            item.value = 1000000;
            item.rare = -12;
            item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //throw speed
            player.GetModPlayer<FargoPlayer>(mod).ThrowSoul = true;
            player.thrownDamage += 0.3f;
            player.thrownCrit += 15;
            player.thrownVelocity += 0.15f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(null, "SlingersEssence");

            /*if (Fargowiltas.Instance.ThoriumLoaded)
            {
                //bone grip
                //complete set
                recipe.AddIngredient(ItemID.Bananarang, 5);
                //cryo fang //borean
                recipe.AddIngredient(ItemID.ShadowFlameKnife);
                //hot pot
                //volt tomahawk
                //spark taser
                //pharoahs slab
                recipe.AddIngredient(ItemID.VampireKnives);
                recipe.AddIngredient(ItemID.PaladinsHammer);
                //cosmic dagger
                recipe.AddIngredient(ItemID.Terrarian);
            /*
            sou
            deity trefork
            
            }
            else
            {*/
            if (Fargowiltas.Instance.FargosLoaded)
            {
                //no others
                recipe.AddIngredient(ModLoader.GetMod("Fargowiltas").ItemType("ChikThrown"));
                recipe.AddIngredient(ModLoader.GetMod("Fargowiltas").ItemType("MagicDaggerThrown"));
                recipe.AddIngredient(ModLoader.GetMod("Fargowiltas").ItemType("BananarangThrown"), 5);
                recipe.AddIngredient(ModLoader.GetMod("Fargowiltas").ItemType("AmarokThrown"));
                recipe.AddIngredient(ModLoader.GetMod("Fargowiltas").ItemType("ShadowflameKnifeThrown"));
                recipe.AddIngredient(ModLoader.GetMod("Fargowiltas").ItemType("FlyingKnifeThrown"));
                recipe.AddIngredient(ModLoader.GetMod("Fargowiltas").ItemType("LightDiscThrown"), 5);
                recipe.AddIngredient(ModLoader.GetMod("Fargowiltas").ItemType("FlowerPowThrown"));
                recipe.AddIngredient(ModLoader.GetMod("Fargowiltas").ItemType("ToxicFlaskThrown"));
                recipe.AddIngredient(ModLoader.GetMod("Fargowiltas").ItemType("VampireKnivesThrown"));
                recipe.AddIngredient(ModLoader.GetMod("Fargowiltas").ItemType("PaladinsHammerThrown"));
                recipe.AddIngredient(ModLoader.GetMod("Fargowiltas").ItemType("PossessedHatchetThrown"));
                recipe.AddIngredient(ModLoader.GetMod("Fargowiltas").ItemType("TerrarianThrown"));
            }
            else
            {
                recipe.AddIngredient(ItemID.Chik);
                recipe.AddIngredient(ItemID.MagicDagger);
                recipe.AddIngredient(ItemID.Bananarang, 5);
                recipe.AddIngredient(ItemID.Amarok);
                recipe.AddIngredient(ItemID.ShadowFlameKnife);
                recipe.AddIngredient(ItemID.FlyingKnife);
                recipe.AddIngredient(ItemID.LightDisc, 5);
                recipe.AddIngredient(ItemID.FlowerPow);
                recipe.AddIngredient(ItemID.ToxicFlask);
                recipe.AddIngredient(ItemID.VampireKnives);
                recipe.AddIngredient(ItemID.PaladinsHammer);
                recipe.AddIngredient(ItemID.PossessedHatchet);
                recipe.AddIngredient(ItemID.Terrarian);
            }

            //}


            if (Fargowiltas.Instance.FargosLoaded)
                recipe.AddTile(ModLoader.GetMod("Fargowiltas"), "CrucibleCosmosSheet");
            else
                recipe.AddTile(TileID.LunarCraftingStation);
                
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
