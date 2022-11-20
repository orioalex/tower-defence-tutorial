using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamemanager1 : MonoBehaviour
{
    public GameObject GameOverUI;
    public Text waveText;
    public bool end;

    void OnEnable(){
        waveText.text = playerPocess.rounds.ToString();
    }

    void Start(){
        end = false;
        GameOverUI.SetActive(false);
    }

    void Update()
    {
        if(end){
            return;
        }
        if(Input.GetKeyDown("e")){
            GameOver();
        }
        if(lives.RemainLives <= 0){
            GameOver();
        }
    }

    void GameOver(){
        camaraControl.doMovement = false;
        end = true;
        waveText.text = playerPocess.rounds.ToString();
        GameOverUI.SetActive(true);
    }

    public void Retry(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
