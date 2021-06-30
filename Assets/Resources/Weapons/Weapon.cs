using UnityEngine;

namespace Resources.Weapons
{
    public class Weapon : ScriptableObject
    {
        public float AttackDistance;
        public float AttackFeq;

        public virtual GameObject[] Attack(Vector2 position,Vector2 direction){ return null; }
    }

    //ÉÈÐÎ¹¥»÷
    public class Sword : Weapon
    {
        //
        private float AttackAngle=90f;
        private float AttackDistace = 1.5f;
        private float rotate = 3f;
        override public GameObject[] Attack(Vector2 position, Vector2 direction)
        {
            GameObject[] gameObject = null;
            int RayNum = (int)(AttackAngle / rotate);
            Ray2D[] ray = new Ray2D[RayNum];

            float angle = 60f;

            for (int i= 0; i < RayNum;i++)
            {
                Vector2 dir = new Vector2(Mathf.Cos(angle*Mathf.PI/180), Mathf.Sin(angle*Mathf.PI / 180));
                Debug.Log(dir);
                ray[i] = new Ray2D(position+direction*0.25f,dir);
                Debug.DrawLine(ray[i].origin, ray[i].origin+ray[i].direction*AttackDistace, Color.red);
                angle -= rotate * direction.x;
                Debug.Log(angle);
            }

            return gameObject;
        }
    }


}
