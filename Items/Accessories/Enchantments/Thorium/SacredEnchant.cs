using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using ThoriumMod;

namespace FargowiltasSouls.Items.Accessories.Enchantments.Thorium
{
    public class SacredEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");
        
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetLoadedMods().Contains("ThoriumMod");
        }
        
        public override string Texture => "FargowiltasSouls/Items/Placeholder";
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sacred Enchantment");
            Tooltip.SetDefault(
                @"''
Healing spells heal an additional 5 life
Summons a li'l cherub to periodically heal damaged allies
Summons a spirit composed of distant stars
The spirit will generate healing energy that can be picked up if you are hurt
When energy is generated, 10 mana will be spent");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 4;
            item.value = 120000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!Fargowiltas.Instance.ThoriumLoaded) return;
            
            SacredEffect(player);
        }
        
        private void SacredEffect(Player player)
        {
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>(thorium);
            //set bonus
            thoriumPlayer.healBonus += 5;
            //cherub
            thoriumPlayer.angelMinion = true;
            //twinkle pet
            thoriumPlayer.lifePet = true;
        }
        
        private readonly string[] items =
        {
            "HallowedPaladinHelmet",
            "HallowedPaladinBreastplate",
            "HallowedPaladinLeggings",
            "RegenStaff",
            "LightBurstWand",
            "SacredCharge",
            "HallowedBludgeon",
            "AngelStaff",
            "Liberation",
            "Twinkle"
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
