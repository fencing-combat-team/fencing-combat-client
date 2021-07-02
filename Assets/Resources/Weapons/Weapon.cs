using UnityEngine;
using GamePlay.Player;
using System.Collections.Generic;

namespace Resources.Weapons
{
    public abstract class Weapon 
    {
        public float AttackDistance;
        public float AttackFeq=2000f;
        //¸ÃÎäÆ÷ÊÇ·ñÓÐ·ÀÓù¹¦ÄÜ
        public bool NoDefending=false;
        //¸ÃÎäÆ÷ÊÇ·ñÓÐÆÆ·À¹¦ÄÜ
        public bool BreakDefending = false;
        //³å»÷Á¦£¨»÷ÍËÁ¦£©
        public  float ImpactingForce;

        public virtual List<GameObject> Attack(Vector2 position,Vector2 direction){ return null; }
        public virtual List<GameObject> DropAttack(Vector2 position, Vector2 direction) { return null; }
    }

    //ÉÈÐÎ¹¥»÷
    public class Sword : Weapon
    {
        private float rotate = 3f;
        private float AttackAngle = 120f;
        //
        public Sword()
        {
            AttackDistance=1f;
            AttackFeq = 2000f;
            ImpactingForce=2f;
        }

        override public List<GameObject> Attack(Vector2 position, Vector2 direction)
        {
            List<GameObject> gameObject = new List<GameObject>();
            int RayNum = (int)(AttackAngle / rotate);
            Ray2D[] ray = new Ray2D[RayNum];
            RaycastHit2D[] info = new RaycastHit2D[RayNum];

            LayerMask Mask = LayerMask.GetMask("Player");

            float angle = 60f;

            for (int i= 0; i < RayNum;i++)
            {
                Vector2 dir;
                if (direction.x>=0)
                    dir = new Vector2(Mathf.Cos(angle*Mathf.PI/180), Mathf.Sin(angle*Mathf.PI / 180));
                else
                    dir = new Vector2(Mathf.Cos((180-angle) * Mathf.PI / 180), Mathf.Sin((180-angle) * Mathf.PI / 180));
                ray[i] = new Ray2D(position+direction*0.45f,dir);
                Debug.DrawLine(ray[i].origin, ray[i].origin+ray[i].direction*AttackDistance, Color.red);
                angle -= rotate ;
            }
            for (int i = 0; i < RayNum; i++)
            {
                info[i] = Physics2D.Raycast(ray[i].origin, ray[i].direction, AttackDistance, Mask);
                if (  info[i].collider!= null && !gameObject.Exists(g => g == info[i].collider.gameObject))
                    gameObject.Add(info[i].collider.gameObject);
            }
            return gameObject;
        }

        override public List<GameObject> DropAttack(Vector2 position, Vector2 direction)
        {
            float angle = 15f;
            List<GameObject> gameObject = new List<GameObject>();
            int RayNum = (int)(angle / rotate);
            Ray2D[] ray = new Ray2D[RayNum];
            RaycastHit2D[] info = new RaycastHit2D[RayNum];

            LayerMask Mask = LayerMask.GetMask("Player");


            for (int i = 0; i < RayNum; i++)
            {
                Vector2 dir;
                dir = new Vector2(Mathf.Cos((273 - angle*direction.x) * Mathf.PI / 180), Mathf.Sin((273 - angle * direction.x) * Mathf.PI / 180));
                ray[i] = new Ray2D(position + direction * 0.3f+Vector2.down*0.7f, dir);
                Debug.DrawLine(ray[i].origin, ray[i].origin + ray[i].direction * 0.4f, Color.red);
                angle += rotate*direction.x;
            }
            for (int i = 0; i < RayNum; i++)
            {
                info[i] = Physics2D.Raycast(ray[i].origin, ray[i].direction, AttackDistance, Mask);
                if (info[i].collider != null && !gameObject.Exists(g => g == info[i].collider.gameObject))
                    gameObject.Add(info[i].collider.gameObject);
            }
            return gameObject;
        }
    }

    //´Ì½£¹¥»÷
    public class LongSword : Weapon
    {
        public LongSword()
        {
            AttackDistance = 1.5f;
            AttackFeq = 2000f;
            ImpactingForce = 2f;
        }
        
        override public List<GameObject> Attack(Vector2 position, Vector2 direction)
        {
            List<GameObject> gameObject = new List<GameObject>();

            LayerMask Mask = LayerMask.GetMask("Player");
            Ray2D ray = new Ray2D(position,direction);

            Debug.DrawLine(ray.origin, ray.origin + ray.direction * AttackDistance, Color.red);

            RaycastHit2D[] info = Physics2D.RaycastAll(ray.origin, ray.direction, AttackDistance, Mask);
            
            for(int i=0;i<info.Length;i++)
                if (info[i].collider != null && !gameObject.Exists(g => g == info[i].collider.gameObject))
                    gameObject.Add(info[i].collider.gameObject);
            return gameObject;
        }

        override public List<GameObject> DropAttack(Vector2 position, Vector2 direction)
        {
            List<GameObject> gameObject = new List<GameObject>();

            LayerMask Mask = LayerMask.GetMask("Player");
            Ray2D ray = new Ray2D(position + direction * 0.5f , Vector2.down);

            Debug.DrawLine(ray.origin, ray.origin + ray.direction * AttackDistance, Color.red);

            RaycastHit2D[] info = Physics2D.RaycastAll(ray.origin, ray.direction, AttackDistance, Mask);

            for (int i = 0; i < info.Length; i++)
                if (info[i].collider != null && !gameObject.Exists(g => g == info[i].collider.gameObject))
                    gameObject.Add(info[i].collider.gameObject);
            return gameObject;

        }
    }

    public class Hammer : Weapon
    {
        public Hammer()
        {
            AttackDistance = 2f;
            AttackFeq = 1000f;
            ImpactingForce = 2f;
        }

        override public List<GameObject> Attack(Vector2 position, Vector2 direction)
        {
            List<GameObject> gameObject = new List<GameObject>();

            LayerMask Mask = LayerMask.GetMask("Player");
            Ray2D ray = new Ray2D(position+direction*0.4f+Vector2.down*0.5f-direction*AttackDistance, direction);

            Debug.DrawLine(ray.origin, ray.origin + ray.direction * AttackDistance * 2f, Color.red);

            RaycastHit2D[] info = Physics2D.RaycastAll(ray.origin, ray.direction, 2f*AttackDistance, Mask);

            for (int i = 0; i < info.Length; i++)
                if (info[i].collider != null && 
                    info[i].collider.gameObject.GetComponent<PlayerInteration>().OnGround() && 
                    !gameObject.Exists(g => g == info[i].collider.gameObject))

                    gameObject.Add(info[i].collider.gameObject);
            return gameObject;
        }

        override public List<GameObject> DropAttack(Vector2 position, Vector2 direction)
        {
            List<GameObject> gameObject = new List<GameObject>();

            LayerMask Mask = LayerMask.GetMask("Player");
            Ray2D ray = new Ray2D(position + direction * 0.3f, Vector2.down);

            Debug.DrawLine(ray.origin, ray.origin + ray.direction * AttackDistance, Color.red);

            RaycastHit2D[] info = Physics2D.RaycastAll(ray.origin, ray.direction, AttackDistance, Mask);

            for (int i = 0; i < info.Length; i++)
                if (info[i].collider != null && !gameObject.Exists(g => g == info[i].collider.gameObject))
                    gameObject.Add(info[i].collider.gameObject);
            return gameObject;

        }


    }

}
