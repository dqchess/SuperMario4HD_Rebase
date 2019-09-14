using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level01_Death : MonoBehaviour
{
    public AudioSource deathSound;
    public GameObject levelMusic;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup gameOverBackgroundImageCanvasGroup;
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject cameraFollow;

    float m_Timer;
    bool m_Dead = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Dead)
        {
            if(GlobalLives.lifeCount > 1)
            {
                EndLevel(exitBackgroundImageCanvasGroup);
            }
            else if(GlobalLives.lifeCount == 1)
            {
                EndLevel(gameOverBackgroundImageCanvasGroup);
            }
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        levelMusic.SetActive(false);
        deathSound.Play();
        m_Dead = true;
        //StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        levelMusic.SetActive(false);
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(1);
    }

    void EndLevel(CanvasGroup imageGroup)
    {
        m_Timer += Time.deltaTime;
        imageGroup.alpha = m_Timer / fadeDuration;
        if (m_Timer > fadeDuration + displayImageDuration)
        {
            GlobalLives.lifeCount -= 1;
            if (GlobalLives.lifeCount > 0)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                Debug.Log("application quit");
                //Application.Quit();
                SceneManager.LoadScene(0);
            }

        }
    }
}
