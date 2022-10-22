using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 100f;
    public float explosionRadius = 8f;
    public Transform target;
    public GameObject BulletImpactEffect;

    void Start()
    {
        
    }

    void Update()
    {
        if(target == null){
            Destroy(gameObject);
            return;
        }
        Vector3 dir=target.position - transform.position;
        if(dir.magnitude <= speed*Time.deltaTime){//剩餘不到一幀
            HitEnemy();
            return;
        }
        transform.Translate(dir.normalized*speed*Time.deltaTime,Space.World);

        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation,lookRotation,Time.deltaTime*50f).eulerAngles;
        transform.rotation = Quaternion.Euler(0f,rotation.y,0f);
    }

    void HitEnemy(){
        GameObject effect = (GameObject)Instantiate(BulletImpactEffect,transform.position,transform.rotation);
        Destroy(effect,2f);
        if(explosionRadius > 0f){
            Explode();
        }
        else{
            Damage(target);
        }   
        Destroy(gameObject);
    }

    void Explode(){
        Collider [] colliders = Physics.OverlapSphere(transform.position,explosionRadius);
        foreach (Collider col in colliders){
            if(col.tag == "enemy"){
                Damage(col.transform);
            }
        }

    }

    void Damage(Transform enemy){
        enemy.GetComponent<enemy>().Die();
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,explosionRadius);
    }
}
