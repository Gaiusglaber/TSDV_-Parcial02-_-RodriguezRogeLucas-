using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region SINGLETON
    static private GameManager instance;
    static public GameManager GetInstance() { return instance; }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion
    public bool win;
    public bool gameOver = false;
    public int HighScore = 0;
    public int level = 0;

    private void Start()
    {
        
    }
    public void GameOver()
    {
        if (gameOver)
        {
            GameObject animatorScene = GameObject.FindGameObjectWithTag("SceneTransition");
            if (animatorScene != null)
            {
                animatorScene.GetComponent<Animator>().SetTrigger("FadeOut");
                StartCoroutine("Transition");
            }
        }
    }
    public void TransitionToNewScene()
    {
        if (Fade.faded)
        {
            Fade.faded = false;
            SceneManager.LoadScene(4);
        }
    }
    IEnumerator Transition()
    {
        yield return new WaitForSeconds(2);
        TransitionToNewScene();
        yield return null;
    }
}
