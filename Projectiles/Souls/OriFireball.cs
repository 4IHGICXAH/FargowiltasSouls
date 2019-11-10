﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasSouls.Projectiles.Souls
{
    public class OriFireball : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ori Fireball");
        }

        public override void SetDefaults()
        {
            projectile.netImportant = true;
            projectile.width = 14;
            projectile.height = 34;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 2;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            projectile.usesLocalNPCImmunity = true;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>();

            projectile.timeLeft = 2;

            if (player.dead)
            {
                modPlayer.OriEnchant = false;
            }

            if (!(modPlayer.OriEnchant) || !SoulConfig.Instance.GetValue("Orichalcum Fireballs"))
            {
                projectile.Kill();
                return;
            }

            //Factors for calculations
            double deg = projectile.ai[1];
            double rad = deg * (Math.PI / 180);
            int dist = 120;

            projectile.position.X = player.Center.X - (int)(Math.Cos(rad) * dist) - projectile.width / 2;
            projectile.position.Y = player.Center.Y - (int)(Math.Sin(rad) * dist) - projectile.height / 2;

            projectile.ai[1] += projectile.ai[0];
        }

        public override void Kill(int timeLeft)
        {
            //dust soon tm


            Player player = Main.player[projectile.owner];
            FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>();

            modPlayer.OriSpawn = false;
        }
    }
}