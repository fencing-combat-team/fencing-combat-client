using UnityEngine;
using System.Collections.Generic;

namespace Resources.Weapons
{
    public class Weapon 
    {
        public float AttackDistance;
        public float AttackFeq;

        public virtual List<GameObject> Attack(Vector2 position,Vector2 direction){ return null; }
        public virtual List<GameObject> DropAttack(Vector2 position, Vector2 direction) { return null; }
    }

    //ÉÈÐÎ¹¥»÷
    public class Sword : Weapon
    {
        //
        private float AttackAngle=120f;
        private float AttackDistace = 1f;
        private float rotate = 3f;
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
                Debug.DrawLine(ray[i].origin, ray[i].origin+ray[i].direction*AttackDistace, Color.red);
                angle -= rotate ;
            }
            for (int i = 0; i < RayNum; i++)
            {
                info[i] = Physics2D.Raycast(ray[i].origin, ray[i].direction, AttackDistace, Mask);
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
                info[i] = Physics2D.Raycast(ray[i].origin, ray[i].direction, AttackDistace, Mask);
                if (info[i].collider != null && !gameObject.Exists(g => g == info[i].collider.gameObject))
                    gameObject.Add(info[i].collider.gameObject);
            }
            return gameObject;
        }
    }

    //´Ì½£¹¥»÷
    public class LongSword : Weapon
    {
        private float AttackDistace = 2f;
        override public List<GameObject> Attack(Vector2 position, Vector2 direction)
        {
            List<GameObject> gameObject = new List<GameObject>();

            LayerMask Mask = LayerMask.GetMask("Player");
            Ray2D ray = new Ray2D(position,direction);

            Debug.DrawLine(ray.origin, ray.origin + ray.direction * AttackDistace, Color.red);

            RaycastHit2D[] info = Physics2D.RaycastAll(ray.origin, ray.direction, AttackDistace, Mask);
            
            for(int i=0;i<info.Length;i++)
                if (info[i].collider != null && !gameObject.Exists(g => g == info[i].collider.gameObject))
                    gameObject.Add(info[i].collider.gameObject);
            return gameObject;
        }

        override public List<GameObject> DropAttack(Vector2 position, Vector2 direction)
        {
            List<GameObject> gameObject = new List<GameObject>();

            LayerMask Mask = LayerMask.GetMask("Player");
            Ray2D ray = new Ray2D(position + direction * 0.3f , Vector2.down);

            Debug.DrawLine(ray.origin, ray.origin + ray.direction * AttackDistace, Color.red);

            RaycastHit2D[] info = Physics2D.RaycastAll(ray.origin, ray.direction, AttackDistace, Mask);

            for (int i = 0; i < info.Length; i++)
                if (info[i].collider != null && !gameObject.Exists(g => g == info[i].collider.gameObject))
                    gameObject.Add(info[i].collider.gameObject);
            return gameObject;

        }
    }

}
