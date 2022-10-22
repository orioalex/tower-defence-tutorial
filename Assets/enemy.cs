using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed = 10f,no=0f;
    public GameObject DieEffect;
    //public static enemy instance;
    Transform target;
    int waveIndex = 0;

    void Start()
    {
        while(!ways.prepared){
            no+=0.000001f;
        }
        //Debug.Log("OK");
        target = ways.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime,Space.World);
        if(Vector3.Distance(transform.position,target.position) <= 0.2f){
            if(waveIndex >= ways.points.Length-1){
                Destroy(gameObject);
            }
            else{
                waveIndex++;
                target=ways.points[waveIndex];
            }
            
        }
    }

    public void Die(){
        GameObject effect = Instantiate(DieEffect , transform.position,transform.rotation);
        playerPocess.money += 50;
        Destroy(effect,2f);
        Destroy(gameObject);
    }
}
