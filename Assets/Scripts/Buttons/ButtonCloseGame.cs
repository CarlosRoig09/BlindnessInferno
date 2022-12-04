using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCloseGame : GenericButton
{
    protected override void TaskOnClick()
    {
        Application.Quit();
    }
}
