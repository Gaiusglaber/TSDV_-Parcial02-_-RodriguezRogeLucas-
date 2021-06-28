using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animatorScene;
    public GameObject next;
    public GameObject win;
    public GameObject lose;
    public Text ScoreText;
    private int SceneIndex;
    private void Start()
    {
        if (GameManager.GetInstance().win)
        {
            win.SetActive(true);
        }
        else
        { 
            lose.SetActive(true);
            next.SetActive(false);
        }
        ScoreText.text = GameManager.GetInstance().HighScore.ToString();
    }
    private void Update()
    {
        SceneFade();
    }
    public void Back()
    {
        StartCoroutine("BackPressed");
        GameManager.GetInstance().gameOver = false;
        GameManager.GetInstance().HighScore = 0;
    }
    public void SceneFade()
    {
        if (Fade.faded)
        {
            Fade.faded = false;
            SceneManager.LoadScene(SceneIndex);
        }
    }
    public void Next()
    {
        GameManager.GetInstance().gameOver = false;
        StartCoroutine("NextPressed");
    }
    public void FadeLevel(int SceneToTransition)
    {
        SceneIndex = SceneToTransition;
        animatorScene.SetTrigger("FadeOut");
    }
    IEnumerator NextPressed()
    {
        yield return new WaitForSeconds(1);
        FadeLevel(SceneManager.GetActiveScene().buildIndex -1);
        yield return null;
    }
    IEnumerator BackPressed()
    {
        yield return new WaitForSeconds(1);
        GameManager.GetInstance().HighScore = 0;
        FadeLevel(SceneManager.GetActiveScene().buildIndex - 3);
        yield return null;
    }
}
