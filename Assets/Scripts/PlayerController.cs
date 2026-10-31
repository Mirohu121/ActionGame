using UnityEditor.Media;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KTC.Domain
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {

        [Header("Movement Settings")]
        [SerializeField] private float _jumpForce = 5f;

        private Rigidbody _rigidbody=null;
        private bool _isGrounded = true;

        private void Awake()
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            _rigidbody = rb;
        }
        // Update is called once per frame
        void Update()
        {
            if(Keyboard.current.spaceKey.wasPressedThisFrame && _isGrounded)
            {
                   Jump();
            }
        }

        private void FixedUpdate()
        {
            Vector3 currentVeloctiy = _rigidbody.linearVelocity;
            currentVeloctiy.x = ConstGame.MOVE_SPEED;
            _rigidbody.linearVelocity = currentVeloctiy;
        }

        private void OnCollisionStay(Collision collision)
        {
            _isGrounded = true;
        }

        private void OnCollisionExit(Collision collision)
        {
            _isGrounded = false;
        }

        private void Jump()
        {
            Vector3 jumpVelocity =_rigidbody.linearVelocity;
            jumpVelocity.y=ConstGame.JUMP_FORCE;
            _rigidbody.linearVelocity = jumpVelocity;

        }
    }
}
