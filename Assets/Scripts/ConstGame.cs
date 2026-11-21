using UnityEngine;

namespace KTC.Domain
{
    public static class ConstGame
    {
        public const float MOVE_SPEED = 5f;
        public const float JUMP_FORCE = 7f;
        public const float COUNTDOWN_STEP_SECONDS = 1.0f;


        public const string TAG_OBSTACLE = "Obstacle";
        public const string VIEW_COUNT_THREE = "3";
        public const string VIEW_COUNT_TWO = "2";
        public const string VIEW_COUNT_ONE = "1";
        public const string VIEW_START = "START!";
        public const string VIEW_GAME_OVER = "GAME OVER - Rキーでリトライ";
        public const string VIEW_PLAYING = "SPACE: ジャンプ / R:リトライ";
    }
}
