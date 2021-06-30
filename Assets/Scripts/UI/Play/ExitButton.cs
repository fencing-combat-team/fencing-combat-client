using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Play
{
    public class ExitButton : MonoBehaviour
    {
        public Menu menu;

        public void OnButtonClicked()
        {
            menu.Show();
            Time.timeScale = 0;
        }

    }
}
