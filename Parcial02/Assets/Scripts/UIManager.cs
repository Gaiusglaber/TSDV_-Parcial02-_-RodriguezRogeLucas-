using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GasBar gasSlider;
    public PlayerController player;
    void Start()
    {
        gasSlider.SetMaxGas(player.gas);
    }
    void Update()
    {
        gasSlider.SetGas(player.gas);
    }
}
