using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    public turretblueprint ThisTurret;

    [Header("Unity Objects")]
    public Transform target=null;
    public enemy targetEnemy;
    public Transform RotatePart;
    public GameObject bullet;
    public GameObject firePlace;
    public ParticleSystem LaserPracticle;
    public LineRenderer LineRenderer;
    public Light light;

    [Header("datas")]
    public float range=15f;
    public float turnSpeed=10f;
    public float firePerSec=2f;
    public float fireCountDown=0f;
    public bool UseLaser = false;
    public int DamagePerSec = 30;
    public float slowPct = 0.5f;

    void Start()
    {
        InvokeRepeating("UpdateTarget",0f,0.5f);
        if(transform.gameObject.tag == "laser"){
            UseLaser = true;
        }
        if(transform.tag == "laser"){
            light = gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Light>();
        }
        //Instantiate(LaserPracticle,LaserPracticle.transform.position,LaserPracticle.transform.rotation);
    }

    void UpdateTarget(){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        bool find=false;
        foreach (GameObject enemy in enemies){
            float disToEnemy=Vector3.Distance(transform.position,enemy.transform.position);
            if(disToEnemy<=range){
                target=enemy.transform;
                targetEnemy = target.GetComponent<enemy>();
                find=true;
                break;
            }
        }
        if(!find) target=null;
    }

    void Shoot(){
        GameObject bulletGO = (GameObject)Instantiate(bullet,firePlace.transform.position,firePlace.transform.rotation);
        if(bulletGO!=null){
            bulletGO.GetComponent<bullet>().target = this.target;
            bulletGO.GetComponent<bullet>().bullets = ThisTurret;
            //bulletGO.GetComponent<bullet>().damage = DamagePerSec;
        }
    }

    void Update()
    {
        if(target==null){
            if(UseLaser && LineRenderer.enabled){
                LineRenderer.enabled = false;
                LaserPracticle.Stop();
                light.enabled = false;
            }
            return;
        }
        //鎖定目標
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation=Quaternion.Lerp(RotatePart.rotation,lookRotation,Time.deltaTime*turnSpeed).eulerAngles;
        RotatePart.rotation= Quaternion.Euler(0f,rotation.y,0f);

        fireCountDown -= Time.deltaTime;

        if(UseLaser){
            if(!LineRenderer.enabled)
            {
                LineRenderer.enabled = true;
                LaserPracticle.Play();
                light.enabled = true;
            }
            
            targetEnemy.Damage(DamagePerSec*Time.deltaTime);
            targetEnemy.slow(slowPct);

            LineRenderer.SetPosition(0,firePlace.transform.position);
            LineRenderer.SetPosition(1,target.position);
            
            Vector3 look = firePlace.transform.position - target.position;
            LaserPracticle.transform.position = target.position + look.normalized * 0.5f;
            LaserPracticle.transform.rotation = Quaternion.LookRotation(look) ;


        }
        else{
            if(fireCountDown <= 0f){
                Shoot();
                fireCountDown = 1f/firePerSec;
            }
        }
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,range);
    }


    
}
