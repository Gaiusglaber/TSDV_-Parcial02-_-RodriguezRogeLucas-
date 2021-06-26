using System.Collections;
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
    private bool videoEnded=false;
    private void Start()
    {
        GameObject video = GameObject.FindGameObjectWithTag("VideoObject");
        if (video!=null)
        video.GetComponent<VideoPlayer>().loopPointReached += CheckOver;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey("enter") ||pressed)
        {
            animatorPlayButton.SetTrigger("Selected");
            StartCoroutine("PlayPressed");
        }
        if (Fade.faded)
        {
            Fade.faded = false;
            SceneManager.LoadScene(SceneIndex);
        }
    }
    public void Play()
    {
        pressed = true;
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
    void CheckOver(VideoPlayer vp)
    {
        videoEnded = true;
    }
    IEnumerator PlayPressed()
    {

        pressed = false;
        yield return new WaitForSeconds(1);
        FadeLevel(SceneManager.GetActiveScene().buildIndex + 1);
        yield return null;
    }
}
