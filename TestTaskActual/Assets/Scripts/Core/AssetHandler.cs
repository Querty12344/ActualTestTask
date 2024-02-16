using DefaultNamespace.GamePlay;
using DefaultNamespace.UI;
using UnityEngine;

namespace DefaultNamespace
{
    public class AssetHandler:MonoBehaviour
    {
        public AddHealthBonus AddHealthBonus;
        public RestoreHealthBonus RestoreHealthBonus;
        public HudWindow Hud;
        public UIWindow Pause;
        public LoseWindow Lose;
        public MainMenuWindow Menu;
        public Enemy[] Enemies;
        public Player Player;
    }
}