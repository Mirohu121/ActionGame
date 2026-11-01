using UnityEngine;


namespace KTC.Scene
{
    public class CameraController : MonoBehaviour
    {
        [Header("Target Settings")]
        [SerializeField] private Transform _target = null;

        [Header("Camera Offset & Speed")]
        [SerializeField] private Vector3 _offset = new Vector3(0.0f, 3.0f, -7.0f);
        [SerializeField] private float _smoothSpeed = 10.0f;

        private void LateUpdate()
        {
            if (_target == null)
            {
                return;
            }

            // プレイヤーの位置にオフセットを加えた目標位置を計算
            Vector3 targetPosition = _target.position + _offset;

            // 現在の位置から目標位置へスムーズに移動させる
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, _smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }
}
