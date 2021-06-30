using Core;
using GamePlay.Camera;
using UnityEngine;
using Utils;

namespace GamePlay.Player
{
    public class CameraLocator : MonoBehaviour
    {
        [Autowired(GameObject = "Main Camera")]
        private AutoCamera _autoCamera;
        private void Awake()
        {
            this.InitComponents();
        }

        private void OnEnable()
        {
            _autoCamera.AddPlayerTag(this);
        }

        private void OnDisable()
        {
            _autoCamera.RemovePlayerTag(this);
        }

    }
}
