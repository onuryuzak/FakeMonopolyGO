using UnityEngine;

namespace MyGame.Game
{
    public class PlayerFollowCamera : MonoBehaviour
    {
        private Transform _playerTransform;
        private Vector3 _offset;

        private void LateUpdate()
        {
            if (_playerTransform != null)
            {
                transform.position = new Vector3(_playerTransform.position.x, 0, _playerTransform.position.z) + _offset;
            }
        }

        public void Initialize(Transform playerTransform, Vector3 offset)
        {
            _playerTransform = playerTransform;
            _offset = offset;
        }
    }
}