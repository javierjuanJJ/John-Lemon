using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public GameObject player;
    bool m_IsPlayerAtExit;
    
    public Canvas CanvasFather;
    
    public CanvasGroup exitBackgroundImageCanvasGroup;
    float m_Timer;
    public float displayImageDuration = 1f;

    private void Start()
    {
        CanvasFather.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel();
        }
    }
    
    void EndLevel ()
    {
        m_Timer += Time.deltaTime;
        exitBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration;
        
        if(m_Timer > fadeDuration + displayImageDuration)
        {
            Application.Quit();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(player.tag))
        {
            CanvasFather.gameObject.SetActive(true);
            Debug.Log("Enter");
            m_IsPlayerAtExit = true;
        }
    }
}
