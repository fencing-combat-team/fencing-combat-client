
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private CapsuleCollider2D coll;
    private BoxCollider2D feet;
    private Animator anim;

    public float speed = 5f;
    public float jumpForce;
    public float doubleJumpForce;
    public bool doubleJump = false;

    public bool isGround, isJump;
    public Transform groundCheck;
    public LayerMask ground;
    public int score;

    bool jumpPressed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        feet = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jumpPressed = true;
        }

  

    }
    void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground);
        GroundMovement();
        CheckGround();
        Jump();
        SwitchAnim();
        

    }
    void CheckGround()//判断人物是否站在地面上
    {
        isGround = feet.IsTouchingLayers(LayerMask.GetMask("Ground"));
        Debug.Log(isGround);
    }
    void GroundMovement()//角色移动
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float facedirection = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);

        if(horizontalMove != 0)
        {
            rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
            anim.SetFloat("running", Mathf.Abs(facedirection)) ;
            
        }
        if (facedirection != 0)
        {
            transform.localScale = new Vector3(facedirection, 1, 1);
        }
 
   
    }
    void Jump()//角色跳跃（顺带完成跳跃动画的切换）
    {
        if (jumpPressed)
        {
            if (isGround)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                anim.SetBool("jumping", true);
                jumpPressed = false;
                doubleJump = true;
            }
            else if (doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, doubleJumpForce);
                jumpPressed = false;
                doubleJump = false;
                anim.SetBool("jumping", true);
            }


        }
    }

    void SwitchAnim()//正式实现跳跃之后回到站立状态的动画切换
    {
        

        if(anim.GetBool("jumping"))
        {
            anim.SetBool("idle", false);
            anim.SetBool("falling", false);

            if(rb.velocity.y<0)
            {
                anim.SetBool("falling", true);
                anim.SetBool("jumping", false);
            }

        }

        if (isGround)
        {
            anim.SetBool("idle", true);
            anim.SetBool("falling", false);
        }


    }

   
    private void OnTriggerEnter2D(Collider2D collision) //拾取特殊道具的基本代码，之后还会再做修改
    {
        if(collision.tag == "Cherry") 
        {
            Destroy(collision.gameObject);
            score += 1;
        }
    }
}
