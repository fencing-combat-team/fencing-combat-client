using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePlay.Data;
using UnityEngine.UI;

namespace UI.Play
{
    public class playBehaviour : MonoBehaviour
    {
        public Image playerImage1;
        public Image playerCheck1;
        public Text playerlives1;
        public Image playerImage2;
        public Image playerCheck2;
        public Text playerlives2;
        public Image playerImage3;
        public Image playerCheck3;
        public Text playerlives3;
        public Image playerImage4;
        public Image playerCheck4;
        public Text playerlives4;

        public PlayerColors colors;
        public PlayerRoomData roomData;

        // Start is called before the first frame update
        void Start()
        {
            setColor();
        }

        // Update is called once per frame
        void Update()
        {

        }
        #region
        private void setColor()
        {
            Color color1 = colors[roomData.players[0].playerColor];
            color1.a = 100;
            playerImage1.color = color1;
            Color color2 = colors[roomData.players[1].playerColor];
            color2.a = 100;
            playerImage2.color = color2;
            Color color3 = colors[roomData.players[2].playerColor];
            color3.a = 100;
            playerImage3.color = color3;
            Color color4 = colors[roomData.players[3].playerColor];
            color4.a = 100;
            playerImage4.color = color4;
        }
        #endregion
    }
}

