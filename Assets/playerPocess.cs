using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerPocess : MonoBehaviour
{
    public static int money = 0;
    public int StartMoney = 300;
    public bool prepared=false;
    public playerPocess instance;
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
        money = StartMoney;
        //Debug.Log(money);
    }

    void Update()
    {
        currency.text = "$" + money.ToString();
    }
}
