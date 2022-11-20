using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 100f;
    public int damage;
    public Transform target;
    public GameObject BulletImpactEffect;
    public turretblueprint bullets;

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
        if(bullets.explosionRadius > 0f){
            Explode();
        }
        else{
            target.GetComponent<enemy>().Damage(damage);
        }   
        Destroy(gameObject);
    }

    void Explode(){
        Collider [] colliders = Physics.OverlapSphere(transform.position,bullets.explosionRadius);
        foreach (Collider col in colliders){
            if(col.tag == "enemy"){
                col.transform.GetComponent<enemy>().Damage(damage);
            }
        }

    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,bullets.explosionRadius);
    }
}
