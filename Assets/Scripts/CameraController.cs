using UnityEngine;
using KTC.Domain;

namespace KTC.Scene
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform _player = null;
        [SerializeField] private GameFlowController _gameFlowController = null;
        [SerializeField] private Vector3 _winnerOffset = new Vector3(0.0f, 1.5f, -4.0f);
        [SerializeField] private float _scrollSpeed = ConstGame.CAMERA_SCROLL_SPEED;
        [SerializeField] private float _zoomSpeed = ConstGame.CAMERA_ZOOM_SPEED;

        private void LateUpdate()
        {
            if (_gameFlowController == null)
            {
                return;
            }

            if (_gameFlowController.IsCountingDown)
            {
                return;
            }

            if (_gameFlowController.IsWinner)
            {
                MoveTowardWinnerView();
                return;
            }

            if (_gameFlowController.IsGameOver)
            {
                return;
            }

            ScrollRight();
        }

        private void ScrollRight()
        {
            Vector3 nextPosition = transform.position;
            nextPosition.x += _scrollSpeed * Time.deltaTime;
            transform.position = nextPosition;
        }

        private void MoveTowardWinnerView()
        {
            if (_player == null)
            {
                return;
            }

            Vector3 targetPosition = _player.position + _winnerOffset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, _zoomSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }
}
