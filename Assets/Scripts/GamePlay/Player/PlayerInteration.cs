using System.Linq;
using Core;
using UnityEngine;
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

        [Tooltip("地面的碰撞箱子")]
        [SerializeField]
        private BoxCollider2D[] _ground;


        // Start is called before the first frame update
        void Start()
        {
            this.InitComponents();
        }

        // Update is called once per frame
        void Update()
        {
            
            //判断是否着地
            var onGround = _ground.Any(g => Physics2D.IsTouching(_collider, g));
            _animator.SetBool(ONGround, onGround);
        }



    }
}