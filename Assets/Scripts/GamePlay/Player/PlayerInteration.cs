using System.Linq;
using Core;
using UnityEngine;
using UnityEngine.Serialization;
using Utils;

namespace GamePlay.Player
{
    public class PlayerInteration : MonoBehaviour
    {
        private static readonly int ONGround = Animator.StringToHash("onGround");
        
        
        [Autowired]
        private BoxCollider2D _collider;

        [Autowired]
        private Animator _animator;

        [FormerlySerializedAs("_ground")]
        [Tooltip("地面的碰撞箱子")]
        public BoxCollider2D[] ground;


        // Start is called before the first frame update
        void Start()
        {
            this.InitComponents();
        }

        // Update is called once per frame
        void Update()
        {

            //判断是否着地
            var onGround = OnGround();
            _animator.SetBool(ONGround, onGround);
        }

        bool OnGround()
        {
            Ray2D ray = new Ray2D(transform.position, Vector2.down);
            LayerMask ignoreMask = ~LayerMask.GetMask("Player");
            Debug.DrawLine(ray.origin, ray.origin + Vector2.down * 0.9f, Color.white);
            RaycastHit2D info = Physics2D.Raycast(ray.origin, ray.direction,0.95f,ignoreMask);

            if (info.collider != null && info.collider.gameObject.tag == "Ground")
                return true;
            else
                return false;
        }

    }
}