using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using ThoriumMod;

namespace FargowiltasSouls.Items.Accessories.Enchantments.Thorium
{
    public class CryoMagusEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");
        
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetLoadedMods().Contains("ThoriumMod");
        }
        
        public override string Texture => "FargowiltasSouls/Items/Placeholder";
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cryo Magus Enchantment");
            Tooltip.SetDefault(
@"''
Magic damage will duplicate itself for 33% of the damage and apply the Frozen debuff to hit enemies
Damage done against slowed targets is increased by 15% and has a chance to heal you lightly
Your symphonic damage will empower all nearby allies with: Mana Regeneration II
Summons a Snowy Owl to watch over you");
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
            
            CryoEffect(player);
        }
        
        private void CryoEffect(Player player)
        {
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>(thorium);
            //cryo set bonus, dmg duplicate
            thoriumPlayer.cryoSet = true;
            //strider hide
            thoriumPlayer.frostBonusDamage = true; 
            //music player
            thoriumPlayer.musicPlayer = true;
            thoriumPlayer.MP3ManaRegen = 2;

            //PET
        }
        
        private readonly string[] items =
        {
            "CryoMagusSpark",
            "CryoMagusTabard",
            "CryoMagusLeggings",
            "IceBoundStriderHide",
            "TunePlayerManaRegen",
            "IceFairyStaff",
            "FrostBurntTongue",
        };

        public override void AddRecipes()
        {
            if (!Fargowiltas.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);
            
            foreach (string i in items) recipe.AddIngredient(thorium.ItemType(i));

            recipe.AddIngredient(ItemID.FrostStaff);
            recipe.AddIngredient(thorium.ItemType("GatewayGlass"));
            recipe.AddIngredient(thorium.ItemType("LostMail"));

            //frost

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
