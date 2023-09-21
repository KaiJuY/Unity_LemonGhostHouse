using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndTrigger : MonoBehaviour
{
    public GameObject player;
    bool isplayerEscape, isplayerbecatched, HasAudioPlayed;
    float timer;
    public CanvasGroup GameEndUI;
    public CanvasGroup BeCatchedUI;
    float fadeDuration = 1f;
    public AudioSource escapedAudio, GetCatchAudio;
    void Start()
    {
        
    }

    void Update()
    {
        if(isplayerEscape)
        {
            GameEnd(GameEndUI, false, escapedAudio);
        }
        else if(isplayerbecatched)
        {
            GameEnd(BeCatchedUI, true, GetCatchAudio);
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
            isplayerEscape = true;
    }

    void GameEnd(CanvasGroup ui, bool restart, AudioSource audio)
    {
            if(!HasAudioPlayed)
            {
                audio.Play();
                HasAudioPlayed = true;
            }
            timer += Time.deltaTime;
            ui.alpha = timer / fadeDuration;
            if(timer > fadeDuration + 1f)
            {
                if(restart)
                    SceneManager.LoadScene(0);
                else
                    Application.Quit();
            }
    }

    public void GetPlayer()
    {
        isplayerbecatched = true;
    }
}
