using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    public turretblueprint Turret;
    public turretblueprint Laser;
    public turretblueprint Missile;
    buildingManager buildingManager;

    void Awake(){
        Turret.cost = 100;
        Turret.damage = 30;
        Turret.explosionRadius = 0f;

        Missile.cost = 250;
        Missile.damage = 50;
        Missile.explosionRadius = 8f;
        
        Laser.cost = 350;
        Laser.damage = 0;
        Laser.explosionRadius = 0f;
    }

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
