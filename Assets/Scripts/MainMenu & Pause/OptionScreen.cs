using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionScreen : MonoBehaviour
{
    public Toggle fullscreenTog, vysncTog;

    // Start is called before the first frame update
    void Start()
    {
        fullscreenTog.isOn = Screen.fullScreen;
        
        if(QualitySettings.vSyncCount == 0)
        {
            vysncTog.isOn = false;
        }
        else
        {
            vysncTog.isOn = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplySetting()
    {
        Screen.fullScreen = fullscreenTog.isOn;

        if (vysncTog.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
    }
}
