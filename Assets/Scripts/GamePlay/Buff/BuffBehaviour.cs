using System;
using Core;
using GamePlay.Player;
using UnityEngine;
using Utils;

namespace GamePlay.Buff
{
    public class BuffBehaviour : MonoBehaviour
    {
        private Entity.Buff buff;

        [Autowired]
        private SpriteRenderer _renderer;

        public Sprite[] sprites;

        private void Awake()
        {
            this.InitComponents();
        }

        public void OnCollisionEnter2D(Collision2D other)
        {
            var manager = other.gameObject.GetComponent<PlayerDataManager>();
            if (manager == null)
            {
                Debug.LogWarning("错误的碰撞：buff");
                return;
            }
            var playerId = manager.PlayerId;
            PlayerBuffManager.Instance.AddBuffToPlayer(playerId, buff);
            Destroy(this.gameObject);
        }

        public void SetBuff(Entity.Buff buff)
        {
            this.buff = buff;
            _renderer.sprite = sprites[buff.buffTypeId];
        }
    }
}