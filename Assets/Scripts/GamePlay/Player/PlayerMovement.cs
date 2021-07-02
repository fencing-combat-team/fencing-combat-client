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

        private void Start()
        {
            this.InitComponents();
        }

        public void ChangeSpeed(float newSpeed, bool smooth = true)
        {
            StopCoroutine(nameof(ChangeSpeedCor));
            if (Mathf.Approximately(newSpeed, 0))
            {
                if (!smooth)
                {
                    _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
                    return;
                }

                StartCoroutine(nameof(ChangeSpeedCor), 0);
                return;
            }

            if (!smooth)
            {
                _rigidbody2D.velocity = new Vector2(newSpeed, _rigidbody2D.velocity.y);
                return;
            }

            StartCoroutine(nameof(ChangeSpeedCor), newSpeed);
        }

        IEnumerator ChangeSpeedCor(float end)
        {
            var currentVec = 0f;
            var smoothing = 0.1f;
            while (Mathf.Abs(_rigidbody2D.velocity.x - end) > 0.01f)
            {
                _rigidbody2D.velocity = new Vector2(
                    Mathf.SmoothDamp(_rigidbody2D.velocity.x, end, ref currentVec, smoothing), _rigidbody2D.velocity.y);
                yield return null;
            }

            _rigidbody2D.velocity = new Vector2(end, _rigidbody2D.velocity.y);
        }
    }
}