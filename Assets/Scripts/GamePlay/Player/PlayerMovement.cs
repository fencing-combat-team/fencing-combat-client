using System;
using System.Collections;
using Core;
using UnityEngine;
using Utils;

namespace GamePlay.Player
{
    /// <summary>
    /// Íæ¼ÒÒÆ¶¯
    /// </summary>
    public class PlayerMovement : MonoBehaviour
    {
        [Autowired]
        private Rigidbody2D _rigidbody2D;

        private int _changeFrames = 5;

        private void Start()
        {
            this.InitComponents();
        }

        public void ChangeSpeed(float newSpeed)
        {
            if (Mathf.Approximately(newSpeed, 0))
            {
                _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
                return;
            }
            var old = _rigidbody2D.velocity.x;
            var delta = (newSpeed - old) / _changeFrames;
            StartCoroutine(ChangeSpeedCor(delta, newSpeed));
        }

        IEnumerator ChangeSpeedCor(float delta, float end)
        {
            for (int i = 0; i < _changeFrames; i++)
            {
                var vec = _rigidbody2D.velocity;
                vec.x += delta;
                _rigidbody2D.velocity = vec;
                yield return new WaitForFixedUpdate();
            }
            _rigidbody2D.velocity = new Vector2(end, _rigidbody2D.velocity.y);
        }
    }
}