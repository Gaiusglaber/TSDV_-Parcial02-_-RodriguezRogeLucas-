using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GasBar gasSlider;
    public GameObject resumeButton;
    public GameObject backButton;
    public PlayerController player;
    public Vector2 speedY;
    public Text speedTextY;
    public Text speedTextX;
    public Text level;
    public Animator animatorScene;
    private int SceneIndex;
    void Start()
    {
        gasSlider.SetMaxGas(player.gas);
        level.text= GameManager.GetInstance().level.ToString();
    }
    void Update()
    {
        if (!GameManager.GetInstance().gameOver)
        {
            speedTextX.text = ((int)(player.GetComponent<Rigidbody2D>().velocity.x*10)).ToString();
            speedTextY.text = ((int)(player.GetComponent<Rigidbody2D>().velocity.y*10)).ToString();
            gasSlider.SetGas(player.gas);
        }
        SceneFade();
    }
    public void SceneFade()
    {
        if (Fade.faded&&SceneIndex!=0)
        {
            Fade.faded = false;
            SceneManager.LoadScene(SceneIndex);
        }
    }
    public void PauseButtonPressed()
    {
        resumeButton.SetActive(true);
        backButton.SetActive(true);
        GameManager.GetInstance().pause = true;
    }
    public void BackButtonPressed()
    {
        GameManager.GetInstance().pause = false;
        StartCoroutine("GoBack");
    }
    public void ResumeButtonPressed()
    {
        StartCoroutine("ResumeButton");
    }
    public void FadeLevel(int SceneToTransition)
    {
        SceneIndex = SceneToTransition;
        animatorScene.SetTrigger("FadeOut");
    }
    IEnumerator GoBack()
    {
        yield return new WaitForSeconds(1);
        GameManager.GetInstance().HighScore = 0;
        FadeLevel(SceneManager.GetActiveScene().buildIndex - 2);
        yield return null;
    }
    void Resume()
    {
        resumeButton.SetActive(false);
        backButton.SetActive(false);
        GameManager.GetInstance().pause = false;
    }
    IEnumerator ResumeButton()
    {
        yield return new WaitForSeconds(1);
        Resume();
        yield return null;
    }
}
