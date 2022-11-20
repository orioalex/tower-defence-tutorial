using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nodeUI : MonoBehaviour
{
    public node target;
    turretblueprint turretblueprint;
    public GameObject ui;
    public buildingManager buildingManager;
    public Text upgradeText;
    public Button upgradeButton;
    public bool active;

    void Awake(){
        ui.SetActive(false);
        active = false;
        //ui.GetComponent<Animator>().SetBool("nodeUIend",false);
    }

    void Start(){
        buildingManager = buildingManager.instance;
    }

    public void SetTarget(node node){
        //ui.SetActive(false);
        target = node;
        transform.position = target.GetBuildPosition();
        if(!target.upgrated){
            upgradeText.text = "$"+target.toBuild.upgradeCost.ToString() ;
            upgradeButton.interactable = true;
        }
        else{
            upgradeText.text = "DONE" ;
            upgradeButton.interactable = false;
        }
        //ui.GetComponent<Animator>().SetBool("nodeUIend",false);
        ui.SetActive(true);
        active = true;
    }

    public void upgrade(){
        buildingManager.hideUI();
        target.upgradeTurret();
    }

    public void hide(){
        ui.SetActive(false);
        active = false;
        //StartCoroutine(HideProcess());
    }
    /*
    IEnumerator HideProcess(){
        ui.GetComponent<Animator>().SetBool("nodeUIend",true);
        
        float time=0f;
        
        while(time <= 5f){
            time += Time.deltaTime;
            yield return null;
        }

        Debug.Log("end animation");
        ui.SetActive(false);
        active = false;
    }*/
}
