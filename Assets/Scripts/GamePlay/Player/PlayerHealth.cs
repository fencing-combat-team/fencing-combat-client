using UnityEngine;

namespace GamePlay.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        //ÉúÃüÊı
        public int life { get; set; }
        // Start is called before the first frame update
        void Start()
        {
            life = 3;
        }

        // Update is called once per frame
        void Update()
        {
            if (life <= 0)
            {

            }
                
        }
    }
}
