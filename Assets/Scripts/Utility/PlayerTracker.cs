using UnityEngine;

namespace Game
{
    public static class PlayerTracker
    {
        public static int PlayerCount { get; set; }

        public static Color P1Colour { get { return Color.white; } }
        public static Color P2Colour { get { return Color.gray; } }

        public const float BOSSMAXHEALTH = 50f;
        public const KeyCode P1_UP = KeyCode.W;
        public const KeyCode P1_DOWN = KeyCode.S;
        public const KeyCode P1_RIGHT = KeyCode.D;
        public const KeyCode P1_LEFT = KeyCode.A;
        public const KeyCode P2_UP = KeyCode.UpArrow;
        public const KeyCode P2_DOWN = KeyCode.DownArrow;
        public const KeyCode P2_RIGHT = KeyCode.RightArrow;
        public const KeyCode P2_LEFT = KeyCode.LeftArrow;
        public static float BossCurrentHealth = BOSSMAXHEALTH;
    }
}