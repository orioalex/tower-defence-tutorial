using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    public turretblueprint Turret;
    public turretblueprint Laser;
    public turretblueprint Missile;
    buildingManager buildingManager;

    public void PurchaseTurret(){
        buildingManager.SelectToBuild(Turret);
        
    }

    public void PurchaseLaser(){
        buildingManager.SelectToBuild(Laser);
        
    }

    public void PurchaseMissile(){
        buildingManager.SelectToBuild(Missile);
        
    }

    void Start()
    {
        buildingManager = buildingManager.instance;
    }
}
