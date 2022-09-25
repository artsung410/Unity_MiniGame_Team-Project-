using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class TowerInfo : MonoBehaviour
{
    public static event Action<GameObject, GameObject, GameObject> TowerButtonClickSignal = delegate { };
    public static TowerInfo Instance;

    public int ID;
    public GameObject SilhouetteTower;
    public GameObject Unable_SilhouetteTower;
    public GameObject BuildingTower;

    public int GunTowerPrice;
    public int HowitzerTowerPrice;

    private void Awake()
    {
        Instance = this;

        GunTowerPrice = 1000;
        HowitzerTowerPrice = 1500;
    }

    public void BtnClick()
    {
        
        //TowerInventory.Instance.isGripTower = true;
        //TowerButtonClickSignal(SilhouetteTower, Unable_SilhouetteTower, BuildingTower);

        if (BuildingTower.name == "Ally_GunTower")
        {
            if (GameManager.Instance.PlayerGold - GunTowerPrice < 0)
            {
                return;
            }
            Debug.Log("ÃÑÅ¸¿ö");
            GameManager.Instance.PlayerGold -= GunTowerPrice;
            TowerInventory.Instance.isGripTower = true;
            TowerButtonClickSignal(SilhouetteTower, Unable_SilhouetteTower, BuildingTower);

        }
        else if(BuildingTower.name == "Ally_HowitzerTower")
        {
            if (GameManager.Instance.PlayerGold - HowitzerTowerPrice < 0)
            {
                return;
            }
            Debug.Log("°î»çÆ÷");
            GameManager.Instance.PlayerGold -= HowitzerTowerPrice;
            TowerInventory.Instance.isGripTower = true;
            TowerButtonClickSignal(SilhouetteTower, Unable_SilhouetteTower, BuildingTower);
        }
        
    }
}
