using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle : MonoBehaviour
{
    public ParticleSystem me;
    void Start()
    {
        
    }

    float time=0f;
    void Update()
    {
        time += Time.deltaTime;
        if(time >= 5f){
            time -= 5f;
            me.Play();
        }
        else if(time >= 1f){
            me.Stop();
        }
    }
}
