using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using ThoriumMod;

namespace FargowiltasSouls.Items.Accessories.Enchantments.Thorium
{
    public class DemonBloodEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");
        
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetLoadedMods().Contains("ThoriumMod");
        }
        
        public override string Texture => "FargowiltasSouls/Items/Placeholder";
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Demon Blood Enchantment");
            Tooltip.SetDefault(
                @"'Infused with Corrupt Blood'
Maximum life increased by 100
Getting hit will trigger 'Sanguine', increasing defensive abilities briefly.
Flail weapons have a chance to release rolling spike balls on hit that apply ichor to damaged enemies.
Your symphonic damage empowers all nearby allies with: Abomination's Blood
Damage done against ichor'd enemies is increased by 5%
Doubles the range of your empowerments effect radius
Your symphonic damage will empower all nearby allies with: Critical Strike II");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 7;
            item.value = 200000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!Fargowiltas.Instance.ThoriumLoaded) return;
            
            DemonEffect(player);
        }
        
        private void DemonEffect(Player player)
        {
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>(thorium);
            thoriumPlayer.demonbloodSet = true;
            player.statLifeMax2 += 100;
            //demon blood badge
            thoriumPlayer.CrimsonBadge = true;
            //vile core
            thoriumPlayer.vileCore = true;
            //subwoofer
            thoriumPlayer.subwooferIchor = true;
            thoriumPlayer.bardRangeBoost += 450;
            //music player
            thoriumPlayer.musicPlayer = true;
            thoriumPlayer.MP3CriticalStrike = 2;
        }
        
        private readonly string[] items =
        {
            "DemonBloodHelmet",
            "DemonBloodBreastPlate",
            "DemonBloodGreaves",
            "DemonRageBadge",
            "VileCore",
            "CrimsonSubwoofer",
            "TunePlayerCritChance",
            "DemonBloodStaff",
            "DarkContagionBook",
            "IchorButterfly"
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
