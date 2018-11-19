using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using ThoriumMod;

namespace FargowiltasSouls.Items.Accessories.Enchantments.Thorium
{
    public class ThoriumEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");
        
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetLoadedMods().Contains("ThoriumMod");
        }
        
        public override string Texture => "FargowiltasSouls/Items/Placeholder";
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Thorium Enchantment");
            Tooltip.SetDefault(
@"'It pulses with energy'
Damage done increased by 10%
Taking more than three damage will replenish health and mana");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 1;
            item.value = 40000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!Fargowiltas.Instance.ThoriumLoaded) return;
            
            ThoriumEffect(player);
        }
        
        private void ThoriumEffect(Player player)
        {
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>(thorium);
            //set bonus 
            player.meleeDamage += 0.1f;
            player.thrownDamage += 0.1f;
            player.rangedDamage += 0.1f;
            player.magicDamage += 0.1f;
            player.minionDamage += 0.1f;
            thoriumPlayer.radiantBoost += 0.1f;
            thoriumPlayer.symphonicDamage += 0.1f;
            //band of replesnishment
            thoriumPlayer.BandofRep = true;
        }
        
        private readonly string[] items =
        {
            "ThoriumHelmet",
            "ThoriumMail",
            "ThoriumGreaves",
            "GrandThoriumHelmet",
            "GrandThoriumBreastPlate",
            "GrandThoriumGreaves",
            "BandofReplenishment",
            "ThoriumBlade",
            "WhirlpoolSaber",
            "ThoriumCube"
        };

        public override void AddRecipes()
        {
            if (!Fargowiltas.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);
            
            foreach (string i in items) recipe.AddIngredient(thorium.ItemType(i));

            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
