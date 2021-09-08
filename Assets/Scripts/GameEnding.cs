using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    
    public GameObject player;
    bool m_IsPlayerAtExit,m_IsPlayerCaught,m_HasAudioPlayed;
    public Canvas CanvasFather, CanvasFatherLose;

    public CanvasGroup exitBackgroundImageCanvasGroup, caughtBackgroundImageCanvasGroup;
    float m_Timer;
    public AudioSource exitAudio, caughtAudio;
    
    private void Start()
    {
        CanvasFather.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (m_IsPlayerAtExit || m_IsPlayerCaught)
        {
            EndLevel(m_IsPlayerAtExit ? exitBackgroundImageCanvasGroup : caughtBackgroundImageCanvasGroup , m_IsPlayerAtExit,m_IsPlayerAtExit ? exitAudio : caughtAudio);
        }
    }
    
    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        
        if (!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }
        
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
        Debug.Log("Enter lose");
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
