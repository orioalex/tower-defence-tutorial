using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class node : MonoBehaviour
{
    public Color HoverColor;
    public Color HoverWithoutMoneyColor;
    public GameObject BuildPracticle;

    [HideInInspector]
    public GameObject turret;
    public turretblueprint toBuild;
    public bool upgrated=false;

    buildingManager buildingManager;
    playerPocess playerPocess;
    Color StartColor;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        StartColor = rend.material.color;
        buildingManager = buildingManager.instance;
        playerPocess = playerPocess.instance;
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
            buildingManager.SelectNode(this);
            return;
        }
        if(buildingManager.toBuild == null){
            Debug.Log("You haven't set anything");
            return;
        }
        //Debug.Log(buildingManager.CanBuild);
        toBuild = buildingManager.toBuild;
        BuildOn();
    }

    public Vector3 GetBuildPosition(){
        return transform.position + new Vector3(0f,2.5f,0f);
    }
    
    public void BuildOn(){
        if(playerPocess.money < toBuild.cost){
            Debug.Log("not enough money");
            return;
        }
        Vector3 toBuildPosition;
        if(toBuild.cost == 350){ // laser
            toBuildPosition = GetBuildPosition();
            toBuildPosition.y = 0.9f;
        }else{
            toBuildPosition = GetBuildPosition();
        }

        GameObject _turret = (GameObject)Instantiate(toBuild.prefab , toBuildPosition , Quaternion.identity);
        Destroy(Instantiate(BuildPracticle,GetBuildPosition() , Quaternion.identity),2);
        turret = _turret;
        turret.GetComponent<turret>().ThisTurret = toBuild;
        
        playerPocess.AddMoney(-toBuild.cost);
    }

    public void upgradeTurret(){
        if(playerPocess.money < toBuild.upgradeCost){
            Debug.Log("not enough money");
            return;
        }
        if(upgrated){
            Debug.Log("upgraded");
            return;
        }
        Vector3 toBuildPosition;
        if(toBuild.cost == 350){ // laser
            toBuildPosition = GetBuildPosition();
            toBuildPosition.y = 0.9f;
        }else{
            toBuildPosition = GetBuildPosition();
        }

        Destroy(turret);

        GameObject _turret = (GameObject)Instantiate(toBuild.upgrade , toBuildPosition , Quaternion.identity);
        Destroy(Instantiate(BuildPracticle,GetBuildPosition() , Quaternion.identity),2);
        turret = _turret;
        turret.GetComponent<turret>().ThisTurret = toBuild;
        upgrated = true;
        playerPocess.AddMoney(-toBuild.upgradeCost);
    }
    
}
