using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    //float no=0f;
    int waveIndex = 0;
    public float normalSpeed = 30f;
    public float speed;
    public float health = 100f;
    public bool alive=true;
    

    lives lives;
    Transform target;
    playerPocess playerPocess;
    public GameObject DieEffect;
    

    void Awake()
    {
        
        target = ways.points[0];
        lives = lives.instance;
        playerPocess = playerPocess.instance;
    }

    void Start(){
        speed = normalSpeed;
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime,Space.World);
        if(Vector3.Distance(transform.position,target.position) <= 0.2f){
            if(waveIndex >= ways.points.Length-1){
                lives.DecreaseLive(1);
                Destroy(gameObject);
                playerPocess.AddMoney(50);
            }
            else{
                waveIndex++;
                target=ways.points[waveIndex];
            }
            
        }
        speed = normalSpeed;
    }

    public void Damage(float val){
        health -= val;
        if(health <= 0f && alive){
            alive = false;
            Die();
        }
    }

    public void Die(){
        GameObject effect = Instantiate(DieEffect , transform.position,transform.rotation);
        playerPocess.AddMoney(50);
        Destroy(effect,2f);
        Destroy(gameObject);
    }

    public void slow(float pct){
        speed = normalSpeed*(1 - pct);
    }
}
