using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;

namespace FargowiltasSouls
{
    internal class Soulcheck : UIState
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public static bool Visible = false;
        public static string owner = "";

        public static readonly Dictionary<string, bool> ToggleDict = new Dictionary<string, bool>();
        public static readonly Dictionary<string, UiCheckbox> checkboxDict = new Dictionary<string, UiCheckbox>();

        public static readonly Dictionary<string, Color> toggles = new Dictionary<string, Color>
        {
            #region enchantment toggles

            ["Hunter Buff"] = new Color(81, 181, 113),
            ["Dangersense Buff"] = new Color(81, 181, 113),
            ["Spelunker Buff"] = new Color(81, 181, 113),
            ["Shine Buff"] = new Color(81, 181, 113),
            ["Cactus Needles"] = new Color(81, 181, 113),
            ["Pumpkin Fire"] = new Color(81, 181, 113),
            ["Copper Lightning"] = new Color(81, 181, 113),
            ["Tin Crit"] = new Color(81, 181, 113),
            ["Iron Fall Speed"] = new Color(81, 181, 113),
            //["Lead Poisoning"] = new Color(81, 181, 113),
            ["Gladiator Speedup"] = new Color(81, 181, 113),
            ["Silver Sword Familiar"] = new Color(81, 181, 113),
            ["Tungsten Effect"] = new Color(81, 181, 113),
            //["Gold Coin Trashing"] = new Color(81, 181, 113),
            ["Shadow Darkness"] = new Color(81, 181, 113),
            ["Jungle Spores"] = new Color(81, 181, 113),
            ["Meteor Shower"] = new Color(81, 181, 113),
            ["Necro Guardian"] = new Color(81, 181, 113),
            ["Molten Inferno"] = new Color(81, 181, 113),
            ["Cobalt Shards"] = new Color(81, 181, 113),
            //["Orichalcum Petals"] = new Color(81, 181, 113),
            ["Orichalcum Fireballs"] = new Color(81, 181, 113),
            ["Adamantite Splitting"] = new Color(81, 181, 113),
            ["Spider Swarm"] = new Color(81, 181, 113),
            ["Frost Icicles"] = new Color(81, 181, 113),
            ["Forbidden Storm"] = new Color(81, 181, 113),
            ["Enchanted Sword Familiar"] = new Color(81, 181, 113),
            ["Hallowed Shield"] = new Color(81, 181, 113),
            ["Chlorophyte Leaf Crystal"] = new Color(81, 181, 113),
            ["Turtle Shell Buff"] = new Color(81, 181, 113),
            ["Beetles"] = new Color(81, 181, 113),
            ["Shroomite Stealth"] = new Color(81, 181, 113),
            ["Spectre Orbs"] = new Color(81, 181, 113),
            ["Spooky Scythes"] = new Color(81, 181, 113),
            ["Dark Artist Effect"] = new Color(81, 181, 113),
            ["Shinobi Through Walls"] = new Color(81, 181, 113),
            ["Red Riding Super Bleed"] = new Color(81, 181, 113),
            ["Valhalla Knockback"] = new Color(81, 181, 113),
            ["Solar Shield"] = new Color(81, 181, 113),
            ["Vortex Voids"] = new Color(81, 181, 113),
            ["Nebula Boosters"] = new Color(81, 181, 113),
            ["Stardust Guardian"] = new Color(81, 181, 113),



            #endregion

            #region soul toggles

            #endregion

            #region pet toggles

            #endregion

            ["Universe Speedup"] = new Color(81, 181, 113),
            ["Universe Scope"] = new Color(81, 181, 113),

            ["Spore Sac"] = new Color(81, 181, 113),
            ["Super Speed"] = new Color(81, 181, 113),
            ["Melee Speed"] = new Color(81, 181, 113),

            ["Black Cat Pet"] = new Color(81, 181, 113),
            ["Companion Cube Pet"] = new Color(81, 181, 113),
            ["Crimson Heart Pet"] = new Color(81, 181, 113),
            ["Cursed Sapling Pet"] = new Color(81, 181, 113),
            ["Dino Pet"] = new Color(81, 181, 113),
            ["Dragon Pet"] = new Color(81, 181, 113),
            ["Eater Pet"] = new Color(81, 181, 113),
            ["Eye Spring Pet"] = new Color(81, 181, 113),
            ["Fairy Pet"] = new Color(81, 181, 113),
            ["Face Monster Pet"] = new Color(81, 181, 113),
            ["Flickerwick Pet"] = new Color(81, 181, 113),
            ["Gato Pet"] = new Color(81, 181, 113),
            //["Grinch Pet"] = new Color(81, 181, 113),
            ["Hornet Pet"] = new Color(81, 181, 113),
            ["Lizard Pet"] = new Color(81, 181, 113),
            ["Magic Lantern Pet"] = new Color(81, 181, 113),
            ["Mini Minotaur Pet"] = new Color(81, 181, 113),
            ["Parrot Pet"] = new Color(81, 181, 113),
            ["Penguin Pet"] = new Color(81, 181, 113),
            ["Puppy Pet"] = new Color(81, 181, 113),
            ["Seedling Pet"] = new Color(81, 181, 113),
            ["Shadow Orb Pet"] = new Color(81, 181, 113),
            ["Skeletron Pet"] = new Color(81, 181, 113),
            ["Snowman Pet"] = new Color(81, 181, 113),
            ["Spider Pet"] = new Color(81, 181, 113),
            ["Squashling Pet"] = new Color(81, 181, 113),
            ["Suspicious Eye Pet"] = new Color(81, 181, 113),
            ["Tiki Pet"] = new Color(81, 181, 113),
            ["Truffle Pet"] = new Color(81, 181, 113),
            ["Turtle Pet"] = new Color(81, 181, 113),
            ["Wisp Pet"] = new Color(81, 181, 113),
            ["Zephyr Fish Pet"] = new Color(81, 181, 113),

            //thorium
            ["Omega Pet"] = new Color(81, 181, 113),
            ["I.F.O. Pet"] = new Color(81, 181, 113),
            ["Bio-Feeder Pet"] = new Color(81, 181, 113),
            ["Blister Pet"] = new Color(81, 181, 113),
            ["Wyvern Pet"] = new Color(81, 181, 113),
        };

        private readonly Color _defaultColor = new Color(81, 181, 113);
        private readonly Color _wtf = new Color(173, 94, 171);
        private UIPanel _checklistPanel;
        private bool _dragging;

        private Vector2 _offset;
        private float _left;
        private float _top = 20f;

        public static bool GetValue(string buff)
        {
            bool ret;
            ToggleDict.TryGetValue(buff, out ret);
            //ErrorLogger.Log(buff + ": " + ret);
            return ret;
        }

        private void CreateCheckbox(string name, Color color)
        {
            if (ToggleDict.Count != toggles.Count) ToggleDict.Add(name, true);

            UiCheckbox uibox = new UiCheckbox(name, "", color, _wtf);
            
            uibox.Left.Set(_left, 0f);
            uibox.Top.Set(_top, 0f);
            
            uibox.OnSelectedChanged += (o, e) =>
            {
                ToggleDict[name] = !ToggleDict[name];
                uibox.Color = uibox.Color == _defaultColor ? Color.Gray : _defaultColor;
            };

            _checklistPanel.Append(uibox);

            checkboxDict.Add(name, uibox);

            _top += 25f;
            if (!(_top >= 565)) return;
            _top = 20f;
            _left += 260f;
        }

        public override void OnInitialize()
        {
            // Is initialize called? (Yes it is called on reload) I want to reset nicely with new character or new loaded mods: visible = false;

            _checklistPanel = new UIPanel();
            _checklistPanel.SetPadding(10);
            _checklistPanel.Width.Set(1000f, 0f);
            _checklistPanel.Height.Set(600f, 0f);
            _checklistPanel.Left.Set((Main.screenWidth - 1000f) / 2f, 0f);
            _checklistPanel.Top.Set((Main.screenHeight - 600f) / 2f, 0f);
            _checklistPanel.BackgroundColor = new Color(73, 94, 171, 150);
            _checklistPanel.OnMouseDown += DragOn;
            _checklistPanel.OnMouseUp += DragOff;
            Append(_checklistPanel);

            UiCheckbox.CheckboxTexture = Fargowiltas.Instance.GetTexture("checkBox");

            if (thorium == null)
            {
                int count = 0;

                foreach (KeyValuePair<string, Color> toggle in toggles)
                {
                    CreateCheckbox(toggle.Key, toggle.Value);
                    count++;

                    if(count >= toggles.Count - 1)
                    {
                        break;
                    }
                    
                }
            }
            else
            {
                foreach (KeyValuePair<string, Color> toggle in toggles)
                {
                    CreateCheckbox(toggle.Key, toggle.Value);
                }
            }
        }

        private void DragOn(UIMouseEvent evt, UIElement listeningElement)
        {
            _offset = new Vector2(evt.MousePosition.X - _checklistPanel.Left.Pixels,
                evt.MousePosition.Y - _checklistPanel.Top.Pixels);

            _dragging = true;
        }

        private void DragOff(UIMouseEvent evt, UIElement listeningElement)
        {
            Vector2 end = evt.MousePosition;
            _dragging = false;

            _checklistPanel.Left.Set(end.X - _offset.X, 0f);
            _checklistPanel.Top.Set(end.Y - _offset.Y, 0f);

            Recalculate();
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Vector2 mousePosition = new Vector2(Main.mouseX, Main.mouseY);
            
            if (_checklistPanel.ContainsPoint(mousePosition)) Main.LocalPlayer.mouseInterface = true;
            
            if (!_dragging) return;
            
            _checklistPanel.Left.Set(mousePosition.X - _offset.X, 0f);
            _checklistPanel.Top.Set(mousePosition.Y - _offset.Y, 0f);
            Recalculate();
        }
    }
}