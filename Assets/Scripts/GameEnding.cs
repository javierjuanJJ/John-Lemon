using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public GameObject player;
    bool m_IsPlayerAtExit;
    bool m_IsPlayerCaught;
    public Canvas CanvasFather;
    public Canvas CanvasFatherLose;
    
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    float m_Timer;
    public float displayImageDuration = 1f;

    private void Start()
    {
        CanvasFather.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (m_IsPlayerAtExit || m_IsPlayerCaught)
        {
            EndLevel(m_IsPlayerAtExit ? exitBackgroundImageCanvasGroup : caughtBackgroundImageCanvasGroup , m_IsPlayerAtExit);
        }
    }
    
    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart)
    {
        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;
        
        if(m_Timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene (0);
            }
            else
            {
                Application.Quit ();
            }
        }
        
    }
    
    public void CaughtPlayer ()
    {
        CanvasFatherLose.gameObject.SetActive(true);
        Debug.Log("Enter victorious");
        m_IsPlayerCaught = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(player.tag))
        {
            CanvasFather.gameObject.SetActive(true);
            Debug.Log("Enter victorious");
            m_IsPlayerAtExit = true;
        }
    }
}
