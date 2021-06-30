using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace UI.Play {
    public class Menu : ViewPanelBehaviourBase
    {
        public OptionMenu optionMenu;
        public Menu menu;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }


        #region
        public void OnSettingButtonClicked()
        {
            optionMenu.Show();
        }
        public void OnReturnButtonClicked()
        {
            Time.timeScale = 1;
            menu.Hide();
        }
        public void OnRoomButtonClicked()
        {
            AsyncOperation ass = SceneManager.LoadSceneAsync("Room", LoadSceneMode.Single);
        }
        public void OnExitButtonClicked()
        {

        }

        #endregion

    }
}
