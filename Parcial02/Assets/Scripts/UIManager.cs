using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GasBar gasSlider;
    public PlayerController player;
    public Vector2 speedY;
    public Text speedTextY;
    public Text speedTextX;
    void Start()
    {
        gasSlider.SetMaxGas(player.gas);
    }
    void Update()
    {
        if (!GameManager.GetInstance().gameOver)
        {
            speedTextX.text = (player.GetComponent<Rigidbody2D>().velocity.x).ToString();
            speedTextY.text = (player.GetComponent<Rigidbody2D>().velocity.y).ToString();
            gasSlider.SetGas(player.gas);
        }
    }
}
