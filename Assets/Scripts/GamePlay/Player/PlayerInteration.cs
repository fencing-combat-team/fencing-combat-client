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
            Ray2D[] ray=new Ray2D[3];
            ray[0] = new Ray2D(transform.position, Vector2.down);
            ray[1]= new Ray2D(transform.position + Vector3.left * 0.38f, Vector2.down);
            ray[2] = new Ray2D(transform.position + Vector3.right * 0.38f, Vector2.down);

            RaycastHit2D[] info = new RaycastHit2D[3];

            LayerMask ignoreMask = ~LayerMask.GetMask("Player");


            for(int i=0;i<=2;i++)
            {
                Debug.DrawLine(ray[i].origin, ray[i].origin + Vector2.down * 0.9f, Color.white);
                info[i] = Physics2D.Raycast(ray[i].origin, ray[i].direction, 0.9f, ignoreMask);
            }

            foreach (var i in info)
            {
                if (i && i.collider.gameObject.CompareTag("Ground"))
                    return true;
            }
             return false;
        }

    }
}