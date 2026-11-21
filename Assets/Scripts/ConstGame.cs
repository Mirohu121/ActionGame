namespace KTC.Domain
{
    public static class ConstGame
    {
        public const float MOVE_SPEED = 5.0f;
        public const float JUMP_FORCE = 7.0f;
        public const float FALL_ACCELERATION = 20.0f;
        public const float CAMERA_SCROLL_SPEED = 5.0f;
        public const float CAMERA_ZOOM_SPEED = 5.0f;
        public const float OUT_OF_BOUNDS_X_OFFSET = -9.0f;
        public const float OUT_OF_BOUNDS_MIN_Y = -10.0f;
        public const float COUNTDOWN_STEP_SECONDS = 1.0f;
        public const float GOAL_BOB_AMPLITUDE = 0.25f;
        public const float GOAL_BOB_SPEED = 3.0f;
        public const float GOAL_ROTATE_SPEED = 90.0f;

        public const string TAG_GOAL = "Goal";
        public const string VIEW_COUNT_THREE = "3";
        public const string VIEW_COUNT_TWO = "2";
        public const string VIEW_COUNT_ONE = "1";
        public const string VIEW_START = "START!";
        public const string VIEW_GAME_OVER = "GAME OVER - Rキーでリトライ";
        public const string VIEW_WINNER = "GOAL! Winner!!";
        public const string VIEW_PLAYING = "SPACE: ジャンプ / R: リトライ";
    }
}