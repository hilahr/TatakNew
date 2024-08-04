/*using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.Video;

public class OpeningSceneHandler : MonoBehaviour
{
    //Const
    private const float fadeTime = 0.75f;

    //Fields - Value Types
    private bool videoPlayed;

    //Fields  - Reference Types
    [SerializeField] private Animator fadeAnimator;
    [SerializeField] private Transform openningUIObjects;

    //Events
    public static event EventHandler StartTour;

    //Functions
    private void Awake()
    {
        PlayOpeningVideo.VideoEnded += LoadnextScene;
    }

    public void OnVideoButton()
    {
        StartCoroutine(startFade());
    }

    private void LoadnextScene(object sender, EventArgs e)
    {
        StartCoroutine(startFade());
    }

    private IEnumerator startFade()
    {
        fadeAnimator.SetTrigger("ButtonPressed");
        yield return new WaitForSeconds(fadeTime);
        if(videoPlayed)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("TatakTour 1");
        }
        else
        {
            openningUIObjects.gameObject.SetActive(false);
            OnWatchOpenningVideoClick();
            videoPlayed = true;
        }
    }

    private void OnWatchOpenningVideoClick()
    {
        StartTour?.Invoke(this, EventArgs.Empty);
    }

    private void OnDestroy()
    {
        PlayOpeningVideo.VideoEnded -= LoadnextScene;
    }
}*/

/*using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class OpeningSceneHandler : MonoBehaviour
{
    // Const
    private const float fadeTime = 0.75f;

    // Fields - Value Types
    public bool videoPlayed;

    // Fields - Reference Types
    [SerializeField] private Animator fadeAnimator;
    [SerializeField] private Transform openningUIObjects;

    // Events
    public static event EventHandler StartTour;

    // Functions
    private void Awake()
    {
        videoPlayed = false; // Reset the flag on Awake
    }

    private void OnEnable()
    {
        PlayOpeningVideo.VideoEnded += LoadnextScene;
    }

    private void OnDisable()
    {
        PlayOpeningVideo.VideoEnded -= LoadnextScene;
    }
    private void Start()
    {
        //fadeAnimator.GetT

    }

    public void OnVideoButton()
    {
        Debug.Log("fuck");
        StartCoroutine(startFade());
    }

    private void LoadnextScene(object sender, EventArgs e)
    {
        StartCoroutine(startFade());
    }

    private IEnumerator startFade()
    {
        Debug.Log("you");
        fadeAnimator.SetTrigger("ButtonPressed");
        Debug.Log("fuck1");
        yield return new WaitForSeconds(fadeTime);
        Debug.Log("fuck2");

        if (videoPlayed)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("TatakTour 1");
            Debug.Log("hello");
        }
        else
        {
            Debug.Log("hi");
            openningUIObjects.gameObject.SetActive(false);
            OnWatchOpenningVideoClick();
            videoPlayed = true;
        }
    }

    private void OnWatchOpenningVideoClick()
    {
        StartTour?.Invoke(this, EventArgs.Empty);
    }

    private void OnDestroy()
    {
        PlayOpeningVideo.VideoEnded -= LoadnextScene;
    }
}*/

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class OpeningSceneHandler : MonoBehaviour
{
    // Const
    private const float fadeTime = 0.75f;

    // Fields - Value Types
    private bool videoPlayed;

    // Fields - Reference Types
    [SerializeField] private Animator fadeAnimator;
    [SerializeField] private Transform openningUIObjects;

    // Events
    public static event EventHandler StartTour;

    // Functions
    private void Awake()
    {
        videoPlayed = false; // Reset the flag on Awake
    }

    private void OnEnable()
    {
        PlayOpeningVideo.VideoEnded += LoadnextScene;
    }

    private void OnDisable()
    {
        PlayOpeningVideo.VideoEnded -= LoadnextScene;
    }

    private void Start()
    {
        // Add any initialization logic here
    }

    public void OnVideoButton()
    {
        Debug.Log("OnVideoButton called");
        StartCoroutine(StartFade());
    }

    private void LoadnextScene(object sender, EventArgs e)
    {
        StartCoroutine(StartFade());
    }


    private IEnumerator StartFade()
    {
        Debug.Log("StartFade called");
        fadeAnimator.SetTrigger("ButtonPressed");
        yield return new WaitForSeconds(fadeTime);
        Debug.Log("Fade completed");

        if (videoPlayed)
        {
            Debug.Log("Loading next scene");
            UnityEngine.SceneManagement.SceneManager.LoadScene("TatakTour 3");
        }
        else
        {
            Debug.Log("Hiding opening UI objects and starting video");
            openningUIObjects.gameObject.SetActive(false);
            OnWatchOpenningVideoClick();
            videoPlayed = true;
        }
    }

    private void OnWatchOpenningVideoClick()
    {
        StartTour?.Invoke(this, EventArgs.Empty);
    }

    private void OnDestroy()
    {
        PlayOpeningVideo.VideoEnded -= LoadnextScene;
    }

    public void Skip()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TatakTour 3");
    }
}

