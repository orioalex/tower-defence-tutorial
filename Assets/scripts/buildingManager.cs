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
    
    public node SelectedNode;
    public nodeUI nodeUI;
    playerPocess playerPocess;
    node HideNode;
        
    void Awake (){
        if(instance != null){
            Debug.Log("More than one");
            return;
        }
        instance = this;
    }

    void Start(){
        playerPocess = playerPocess.instance;
    }

    public bool HasSelectedBuilding{
        get{
            return toBuild != null;
        }
    }

    public void SelectToBuild(turretblueprint build){
        toBuild = build;
        SelectedNode = null;
        nodeUI.hide();
    }

    public void SelectNode(node node){
        if(SelectedNode == node){
            hideUI();
        }
        else{
            SelectedNode = node;
            toBuild = null;
            nodeUI.SetTarget(SelectedNode);

            /*
            HideNode = node;
            float time=0f;
            
            hideUI();*/
        }
    }

    public void hideUI(){
        //node had changed
        //if(SelectedNode != HideNode) return;
        
        nodeUI.hide();
        SelectedNode = null;
    }

    
    
}
