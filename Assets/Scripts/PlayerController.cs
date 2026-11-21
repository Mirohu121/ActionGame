using KTC.Scene;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KTC.Domain
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private GameFlowController _gameFlowController = null;
        [SerializeField] private Transform _cameraTransform = null;
        [SerializeField] private float _outOfBoundsXOffset = ConstGame.OUT_OF_BOUNDS_X_OFFSET;
        [SerializeField] private float _outOfBoundsMinY = ConstGame.OUT_OF_BOUNDS_MIN_Y;

        private Rigidbody _rigidbody = null;
        private bool _isGrounded = false;

        private void Awake()
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            _rigidbody = rb;
        }

        private void Update()
        {
         
            if (_gameFlowController != null && (_gameFlowController.IsGameOver || _gameFlowController.IsCountingDown))
            {
                return;
            }

            CheckOutOfBounds();

            if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame && _isGrounded)
            {
                Jump();
            }
        }

        private void FixedUpdate()
        {
            if (_gameFlowController != null && (_gameFlowController.IsGameOver || _gameFlowController.IsCountingDown))

            {
                Vector3 stopVelocity = new Vector3(0.0f, _rigidbody.linearVelocity.y, 0.0f);
                _rigidbody.linearVelocity = stopVelocity;
                return;
            }

            Vector3 currentVelocity = _rigidbody.linearVelocity;
            currentVelocity.x = ConstGame.MOVE_SPEED;
            _rigidbody.linearVelocity = currentVelocity;
        }

        private void OnCollisionStay(Collision collision)
        {
            _isGrounded = true;
        }

        private void OnCollisionExit(Collision collision)
        {
            _isGrounded = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(ConstGame.TAG_GOAL))
            {
                if (_gameFlowController != null)
                {
                    _gameFlowController.TriggerWinner();
                }
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(ConstGame.TAG_GOAL))
            {
                if (_gameFlowController != null)
                {
                    _gameFlowController.TriggerWinner();
                }
            }
        }

        private void CheckOutOfBounds()
        {
            if (_gameFlowController == null || _cameraTransform == null)
            {
                return;
            }

            float leftLimitX = _cameraTransform.position.x + _outOfBoundsXOffset;
            bool isOutsideLeft = transform.position.x < leftLimitX;
            bool isFallenBelow = transform.position.y < _outOfBoundsMinY;

            if (isOutsideLeft || isFallenBelow)
            {
                _gameFlowController.TriggerGameOver();
            }
        }

        private void Jump()
        {
            Vector3 jumpVelocity = _rigidbody.linearVelocity;
            jumpVelocity.y = ConstGame.JUMP_FORCE;
            _rigidbody.linearVelocity = jumpVelocity;
        }
    }
}