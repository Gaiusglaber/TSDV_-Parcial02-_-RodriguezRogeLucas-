using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SceneFade : MonoBehaviour
{
    private Animator animator;
    private int SceneIndex;
    private bool videoEnded=false;
    private void Start()
    {
        animator = GetComponent<Animator>();
        GameObject video = GameObject.FindGameObjectWithTag("VideoObject");
        if (video!=null)
        video.GetComponent<VideoPlayer>().loopPointReached += CheckOver;
    }
    void Update()
    {
        if (CheckSkipScene())
        {
            if (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey("enter") || Input.GetKey(KeyCode.Space) || videoEnded)
            {
                FadeLevel(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
    public void FadeLevel(int SceneToTransition)
    {
        SceneIndex = SceneToTransition;
        animator.SetTrigger("FadeOut");
    }
    public void FadeComplete()
    {
        SceneManager.LoadScene(SceneIndex);
    }
    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        videoEnded = true;
    }
    bool CheckSkipScene()
    {
        return SceneManager.GetActiveScene().buildIndex == 0; //checks if the scene is the intro
    }
}
