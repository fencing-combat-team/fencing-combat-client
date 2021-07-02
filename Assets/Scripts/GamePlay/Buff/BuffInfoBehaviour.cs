using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace GamePlay.Buff
{
    public class BuffInfoBehaviour : MonoBehaviour
    {
        private Entity.Buff buff = null;


        private Image _image;
        private Text _text;

        public Sprite[] sprites;

        private void Awake()
        {
            this.InitComponents();
        }


        void Update()
        {
            if (buff == null)
                return;
            switch(buff.buffTypeId)
            {
                case 1:
                case 3:
                    _text.text = buff.activeTime.ToString();
                    break;
                case 2:
                    _text.text = buff.activeCount.ToString();
                    break;
                default:
                    break;
            }
            
        }

        public void SetBuffInfo(Entity.Buff buff)
        {
            this.buff = buff;
            _image = this.gameObject.GetComponentInChildren<Image>();
            _text = this.gameObject.GetComponentInChildren<Text>();
            _image.sprite = sprites[buff.buffTypeId];

        }
    }
}
