using UnityEngine;


//�������н��������Ļ�����
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

