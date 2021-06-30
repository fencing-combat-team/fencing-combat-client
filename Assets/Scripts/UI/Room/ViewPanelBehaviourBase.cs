using UnityEngine;


//这是所有界面控制类的基础类
    public class ViewPanelBehaviourBase : MonoBehaviour
    {
        public void Show()
        {
            transform.gameObject.SetActive(true);
            OnShow();
        }

        public void Hide()
        {
            if (OnHide())
            {
                transform.gameObject.SetActive(false);
            }
        }

        protected virtual void OnShow()
        {
        
        }

        protected virtual bool OnHide()
        {
            return true;
        }
    }

