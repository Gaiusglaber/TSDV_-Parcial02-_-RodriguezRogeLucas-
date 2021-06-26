using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxGas(float gas)
    {
        slider.maxValue = gas;
        slider.value = gas;
    }
    public void SetGas(float gas)
    {
        slider.value = gas;
    }
}
