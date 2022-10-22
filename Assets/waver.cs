using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class waver : MonoBehaviour
{
    float timeBetweenWaves=5f , countdown=2f;
    public GameObject enemies;
    public Text waveTimer;
    public int wave=0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(countdown<=0f){
            StartCoroutine(addWave());
            countdown=timeBetweenWaves;
            //Debug.Log("here");
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveTimer.text = string.Format("{0:00.00}",countdown);
    }

    IEnumerator addWave(){
        //Debug.Log("here");
        wave++;
        for (int i = 0; i < wave; i++){
            Instantiate(enemies,new Vector3(70,2.5f,-5),transform.rotation);
            yield return new WaitForSeconds(0.5f);
        }        
    }
}
