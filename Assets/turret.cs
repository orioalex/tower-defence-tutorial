using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    [Header("Unity Objects")]
    public Transform target=null;
    public Transform RotatePart;
    public GameObject bullet;
    public GameObject firePlace;

    [Header("datas")]
    public float range=15f;
    public float turnSpeed=10f;
    public float firePerSec=2f;
    public float fireCountDown=0f;

    void Start()
    {
        InvokeRepeating("UpdateTarget",0f,0.5f);
    }

    void UpdateTarget(){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        bool find=false;
        foreach (GameObject enemy in enemies){
            float disToEnemy=Vector3.Distance(transform.position,enemy.transform.position);
            if(disToEnemy<=range){
                target=enemy.transform;
                find=true;
                break;
            }
        }
        if(!find) target=null;
    }

    void Shoot(){
        GameObject bulletGO = (GameObject)Instantiate(bullet,firePlace.transform.position,firePlace.transform.rotation);
        //Bullet bullet = bullet.GetComponent<Bullet>();
        if(bulletGO!=null){
            bulletGO.GetComponent<bullet>().target = this.target;
        }
    }

    void Update()
    {
        if(target==null) return;
        //鎖定目標
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation=Quaternion.Lerp(RotatePart.rotation,lookRotation,Time.deltaTime*turnSpeed).eulerAngles;
        RotatePart.rotation= Quaternion.Euler(0f,rotation.y,0f);

        fireCountDown -= Time.deltaTime;
        if(fireCountDown <= 0f){
            Shoot();
            fireCountDown = 1f/firePerSec;
        }
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,range);
    }


    
}
