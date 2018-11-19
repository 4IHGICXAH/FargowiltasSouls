using System.Linq;
using Terraria;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.ID;

namespace FargowiltasSouls.Items.Accessories.Souls
{
    public class BardSoul : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");
        
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetLoadedMods().Contains("ThoriumMod");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rhapsodist's Soul");

            Tooltip.SetDefault(
@"'Every note you produce births a new world'
40% increased symphonic damage
25% increased symphonic playing speed
20% increased symphonic critical strike chance
Your symphonic damage empowers all nearby allies with: Cold Shoulder, Spider Bite, Abomination's Blood, Vile Flames and Terrarian
Damage done against frostburnt, envenomed, ichor'd, and cursed flamed enemies is increased by 10%
Doubles the range of your empowerments effect radius
Percussion critical strikes will deal 10% more damage
Percussion critical strikes will briefly stun enemies
Your wind instrument attacks now attempt to quickly home in on enemies
If the attack already homes onto enemies, it does so far more quickly
String weapon projectiles bounce five additional times
Critical strikes caused by brass instrument attacks release a spread of energy");

//band kit
//Increases symphonic damage by 8%
//Increases symphonic playing speed by 8%
//Increases inspiration regeneration by 8%

//digital tuner
//10% increased symphonic damage
//Increases maximum inspiration by 4
//Percussion critical strikes will deal 10% more damage
//Percussion critical strikes will briefly stun enemies

//epic mouthpiece
//10% increased symphonic damage
//5% increased symphonic playing speed
//Your wind instrument attacks now attempt to quickly home in on enemies
//If the attack already homes onto enemies, it does so far more quickly

//guitar pick claw
//10% increased symphonic damage
//5% increased symphonic critical strike chance
//String weapon projectiles bounce three additional times

//striaght mute
//10% increased symphonic damage
//5% increased inspiration regeneration rate
//Critical strikes caused by brass instrument attacks release a spread of energy


        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            item.value = 1000000;
            item.expert = true;
            item.rare = -12;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (Fargowiltas.Instance.ThoriumLoaded) Bard(player);
        }

        private void Bard(Player player)
        {
            //general

            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>(thorium);

            thoriumPlayer.symphonicDamage += 0.4f;
            thoriumPlayer.symphonicCrit += 20;
            thoriumPlayer.symphonicSpeed += .25f;

            //woofers
            thoriumPlayer.subwooferFrost = true;
            thoriumPlayer.subwooferVenom = true;
            thoriumPlayer.subwooferIchor = true;
            thoriumPlayer.subwooferCursed = true;
            thoriumPlayer.subwooferTerrarium = true;

            //type buffs
            thoriumPlayer.bardHomingBool = true;
            thoriumPlayer.bardHomingBonus = 5f;
            thoriumPlayer.bardMute2 = true;
            thoriumPlayer.tuner2 = true;
            thoriumPlayer.bardBounceBonus = 5;
        }
        
        private readonly string[] _items =
        {
            "BardEssence",
            "DigitalVibrationTuner",
            "EpicMouthpiece",
            "GuitarPickClaw",
            "StraightMute",
            "BandKit",
            "FishBone",
            "PrimesRoar",
            "EskimoBanjo",
            "SoundSagesLament",
            "ChronoOcarina",
            "TheMaw",
            "SonicAmplifier",
            "TheSet"   
        };
        
        public override void AddRecipes()
        {
            if (!Fargowiltas.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            foreach (string i in _items) recipe.AddIngredient(thorium.ItemType(i));

            if (Fargowiltas.Instance.FargosLoaded)
                recipe.AddTile(ModLoader.GetMod("Fargowiltas"), "CrucibleCosmosSheet");
            else
                recipe.AddTile(TileID.LunarCraftingStation);
                
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
