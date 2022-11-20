using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerPocess : MonoBehaviour
{
    public static int money = 0;
    public int StartMoney = 350;
    public static int rounds;
    public bool prepared=false;
    public static playerPocess instance;
    public Text currency;

    void Awake(){
        if(instance != null){
            Debug.Log("More than one PP");
            return;
        }
        instance = this;
        prepared = true;
    }

    void Start()
    {
        rounds = 0;
        money = StartMoney;
        currency.text = "$" + money.ToString();
    }

    public void AddMoney(int val){
        money += val;
        currency.text = "$" + money.ToString();
    }
}
