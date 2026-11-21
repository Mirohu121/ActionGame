using UnityEngine;

namespace KTC.Domain
{
    public class GoalVisual : MonoBehaviour
    {
        private Vector3 _initialPosition = Vector3.zero;

        private void Awake()
        {
            _initialPosition = transform.position;
        }

        private void Update()
        {
            // è„â∫Ç…Ç”ÇÌÇ¡Ç∆ìÆÇ©Ç∑
            float bobOffset = Mathf.Sin(Time.time * ConstGame.GOAL_BOB_SPEED) * ConstGame.GOAL_BOB_AMPLITUDE;
            Vector3 nextPosition = _initialPosition;
            nextPosition.y = _initialPosition.y + bobOffset;
            transform.position = nextPosition;

            // Yé≤é¸ÇËÇ…Ç‰Ç¡Ç≠ÇËâÒì]Ç≥ÇπÇÈ
            transform.Rotate(0.0f, ConstGame.GOAL_ROTATE_SPEED * Time.deltaTime, 0.0f);
        }
    }
}