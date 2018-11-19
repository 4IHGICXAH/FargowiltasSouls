using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using ThoriumMod;

namespace FargowiltasSouls.Items.Accessories.Enchantments.Thorium
{
    public class DragonEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");
        
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetLoadedMods().Contains("ThoriumMod");
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragon Enchantment");
            Tooltip.SetDefault(
@"'Made from mythical scales'
Your attacks have a chance to unleash an explosion of Dragon's Flame
Increases armor penetration by 15
Summons a juvenile... wyvern pup?");
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
            
            DragonEffect(player);
        }
        
        private void DragonEffect(Player player)
        {
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>(thorium);
            thoriumPlayer.dragonSet = true;
            //dragon tooth necklace
            player.armorPenetration += 15;
            //wyvern pet
            thoriumPlayer.wyvernPet = true;
        }
        
        private readonly string[] items =
        {
            "DragonMask",
            "DragonBreastplate",
            "DragonGreaves",
            "DragonWings",
            "DragonTalonNecklace",
            "DragonsBreath",
            "EbonyTail",
            "DragonkinStaff",
            "CursedFlameButterfly",
            "CloudyChewToy"
        };

        public override void AddRecipes()
        {
            if (!Fargowiltas.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            //shadow
            
            foreach (string i in items) recipe.AddIngredient(thorium.ItemType(i));

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
