﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
public class MainMenu : MonoBehaviour
{
    public Animator animatorPlayButton;
    public Animator animatorScene;
    private int SceneIndex;
    private bool pressed;
    void Update()
    {
        InputController();
        SceneFade();
    }
    public void SceneFade()
    {
        if (Fade.faded)
        {
            Fade.faded = false;
            SceneManager.LoadScene(SceneIndex);
        }
    }
    public void InputController()
    {
        if (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey("enter") || pressed)
        {
            animatorPlayButton.SetTrigger("Selected");
            StartCoroutine("PlayPressed");
        }
    }
    public void Play()
    {
        pressed = true;
    }
    public void Credits()
    {
        StartCoroutine("CreditsPressed");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void FadeLevel(int SceneToTransition)
    {
        SceneIndex = SceneToTransition;
        animatorScene.SetTrigger("FadeOut");
    }
    IEnumerator PlayPressed()
    {
        pressed = false;
        yield return new WaitForSeconds(1);
        FadeLevel(SceneManager.GetActiveScene().buildIndex + 2);
        yield return null;
    }
    IEnumerator CreditsPressed()
    {
        yield return new WaitForSeconds(1);
        FadeLevel(SceneManager.GetActiveScene().buildIndex + 1);
        yield return null;
    }
}
