using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class node : MonoBehaviour
{
    public Color HoverColor;
    public Color HoverWithoutMoneyColor;
    //public turretblueprint building;

    [Header("Optional")]
    public GameObject turret;

    buildingManager buildingManager;
    Color StartColor;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        StartColor = rend.material.color;
        buildingManager = buildingManager.instance;
    }

    void OnMouseEnter(){
        if(EventSystem.current.IsPointerOverGameObject())
            return;
        if(!buildingManager.HasSelectedBuilding || turret != null){ // You haven't set anything || There has been something
            //Debug.Log("You haven't set anything");
            return;
        }
        if(playerPocess.money < buildingManager.toBuild.cost){
            rend.material.color = HoverWithoutMoneyColor;
        }
        else{
            rend.material.color = HoverColor;
        }
        
    }

    void OnMouseExit(){
        rend.material.color = StartColor;
    }

    void OnMouseDown(){
        if(EventSystem.current.IsPointerOverGameObject())
            return;
        if(turret != null){ // There has been something
            Debug.Log("There has been something");
            return;
        }
        if(buildingManager.toBuild.prefab == null){
            Debug.Log("You haven't set anything");
            return;
        }
        //Debug.Log(buildingManager.CanBuild);
        buildingManager.BuildOn(this);
    }

    public Vector3 GetBuildPosition(){
        return transform.position + new Vector3(0f,2.5f,0f);
    }
}
