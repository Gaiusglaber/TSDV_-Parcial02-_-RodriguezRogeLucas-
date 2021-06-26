using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
public class Intro : MonoBehaviour
{
    public Animator animatorScene;
    private int SceneIndex;
    private bool videoEnded = false;
    private void Start()
    {
        GameObject video = GameObject.FindGameObjectWithTag("VideoObject");
        if (video != null)
            video.GetComponent<VideoPlayer>().loopPointReached += CheckOver;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey("enter") || Input.GetKey(KeyCode.Space) || videoEnded)
        {
            FadeLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (Fade.faded)
        {
            Fade.faded = false;
            SceneManager.LoadScene(SceneIndex);
        }
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
}
