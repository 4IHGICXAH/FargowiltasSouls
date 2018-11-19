using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasSouls.Items
{
    public class FargoGlobalItem : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.type == ItemID.DogWhistle)
            {
                TooltipLine line = new TooltipLine(mod, "fun", "Shoutout to Browny and Paca");
                tooltips.Add(line);
            }
        }

        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            if (player.manaCost <= 0f) player.manaCost = 0f;
        }

        public override void GrabRange(Item item, Player player, ref int grabRange)
        {
            FargoPlayer p = (FargoPlayer) player.GetModPlayer(mod, "FargoPlayer");
            //ignore money, hearts, mana stars
            if (p.IronEnchant && item.type != 71 && item.type != 72 && item.type != 73 && item.type != 74 && item.type != 54 && item.type != 1734 && item.type != 1735 &&
                item.type != 184) grabRange += 250;
        }

        public override void PickAmmo(Item item, Player player, ref int type, ref float speed, ref int damage, ref float knockback)
        {
            FargoPlayer modPlayer = (FargoPlayer) player.GetModPlayer(mod, "FargoPlayer");

            if (modPlayer.Jammed) type = ProjectileID.ConfettiGun;
        }

        public override bool ConsumeItem(Item item, Player player)
        {
            FargoPlayer p = player.GetModPlayer<FargoPlayer>(mod);

            if (p.Infinity && item.createTile == -1 && item.type != ItemID.LifeFruit) return false;

            if (p.BuilderMode && (item.createTile != -1 || item.createWall != -1)) return false;
            return true;
        }

        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            if (Main.rand.Next(10) != 0) return;
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (arg)
            {
                case ItemID.KingSlimeBossBag:
                    player.QuickSpawnItem(mod.ItemType("SlimeKingsSlasher"));
                    break;
                case ItemID.EyeOfCthulhuBossBag:
                    player.QuickSpawnItem(mod.ItemType("EyeFlail"));
                    break;
                case ItemID.EaterOfWorldsBossBag:
                    player.QuickSpawnItem(mod.ItemType("EaterStaff"));
                    break;
                case ItemID.BrainOfCthulhuBossBag:
                    player.QuickSpawnItem(mod.ItemType("BrainStaff"));
                    break;
                case ItemID.SkeletronBossBag:
                    player.QuickSpawnItem(mod.ItemType("Bonezone"));
                    break;
                case ItemID.QueenBeeBossBag:
                    player.QuickSpawnItem(mod.ItemType("QueenStinger"));
                    break;
                case ItemID.DestroyerBossBag:
                    player.QuickSpawnItem(mod.ItemType("Probe"));
                    break;
                case ItemID.TwinsBossBag:
                    player.QuickSpawnItem(mod.ItemType("TwinBoomerangs"));
                    break;
                case ItemID.SkeletronPrimeBossBag:
                    player.QuickSpawnItem(mod.ItemType("PrimeStaff"));
                    break;
                case ItemID.PlanteraBossBag:
                    player.QuickSpawnItem(mod.ItemType("Dicer"));
                    break;
                case ItemID.GolemBossBag:
                    player.QuickSpawnItem(mod.ItemType("GolemStaff"));
                    break;
                case ItemID.FishronBossBag:
                    player.QuickSpawnItem(mod.ItemType("FishStick"));
                    break;
            }
        }

        public override bool OnPickup(Item item, Player player)
        {
            FargoPlayer p = player.GetModPlayer<FargoPlayer>(mod);

            if (p.ChloroEnchant && item.stack == 1 && (item.type == ItemID.Daybloom || item.type == ItemID.Blinkroot || item.type == ItemID.Deathweed || item.type == ItemID.Fireblossom ||
                                                       item.type == ItemID.Moonglow || item.type == ItemID.Shiverthorn || item.type == ItemID.Waterleaf || item.type == ItemID.Mushroom ||
                                                       item.type == ItemID.VileMushroom || item.type == ItemID.ViciousMushroom || item.type == ItemID.GlowingMushroom)) item.stack = 2;

            if (p.TerrariaSoul)
            {
                // ReSharper disable once SwitchStatementMissingSomeCases
                switch (item.type)
                {
                    case ItemID.Heart:
                        player.HealEffect(40);
                        player.statLife += 40;
                        return false;
                    case ItemID.Star:
                        player.ManaEffect(200);
                        player.statMana += 200;
                        return false;
                }
            }
            else if (p.CrimsonEnchant && item.type == ItemID.Heart)
            {
                player.HealEffect(30);
                player.statLife += 30;
                return false;
            }

            return true;
        }

        public override void GetWeaponKnockback(Item item, Player player, ref float knockback)
        {
            FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>();

            if (modPlayer.UniverseEffect) knockback *= 2;
        }

        public override bool CanUseItem(Item item, Player player)
        {
            if (item.type == ItemID.PumpkinPie && player.HasBuff(BuffID.PotionSickness)) return false;

            return true;
        }

        public override bool UseItem(Item item, Player player)
        {
            FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>();

            if (item.type == ItemID.PumpkinPie && modPlayer.PumpkinEnchant)
            {
                int heal = player.statLifeMax2 - player.statLife;
                player.HealEffect(heal);
                player.statLife += heal;
                player.AddBuff(BuffID.PotionSickness, 10800);
            }

            if (modPlayer.UniverseEffect && item.damage > 0) item.shootSpeed *= 1.5f;

            return false;
        }
    }
}