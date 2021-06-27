﻿using System.Collections;
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
    public bool win = false;
    public bool gameOver = false;
    public void GameOver()
    {
        if (gameOver)
        {
            GameObject animatorScene = GameObject.FindGameObjectWithTag("SceneTransition");
            animatorScene.GetComponent<Animator>().SetTrigger("FadeOut");
            StartCoroutine("Transition");
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
