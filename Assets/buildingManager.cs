using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingManager : MonoBehaviour
{
    //public static int money = 300;
    //public static int toCost = 0;
    public turretblueprint toBuild;
    public static buildingManager instance;
    public GameObject TurretPrefab;
    public GameObject LaserPrefab;
    public GameObject MissilePrefab;
    public GameObject BuildPracticle;
    playerPocess playerPocess;
        
    void Awake (){
        if(instance != null){
            Debug.Log("More than one");
            return;
        }
        instance = this;
    }

    void Start(){
        float no = 0f;
        while(!playerPocess.prepared){
            no+=0.000001f;
        }
        playerPocess = playerPocess.instance;
    }

    public bool HasSelectedBuilding{
        get{
            return toBuild.prefab != null;
        }
    }

    public void SelectToBuild(turretblueprint build){
        toBuild = build;
    }

    public void BuildOn(node node){
        if(playerPocess.money < toBuild.cost){
            Debug.Log("not enough money");
            return;
        }
        
        GameObject turret = (GameObject)Instantiate(toBuild.prefab , node.GetBuildPosition() , Quaternion.identity);
        Destroy(Instantiate(BuildPracticle,node.GetBuildPosition() , Quaternion.identity),2);
        node.turret = turret;
        playerPocess.money -= toBuild.cost;
    }
}
