using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenu : ViewPanelBehaviourBase
{
    public OptionMenu menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region
    public void ExitButtonClick()
    {
        menu.Hide();
    }

    #endregion
}
