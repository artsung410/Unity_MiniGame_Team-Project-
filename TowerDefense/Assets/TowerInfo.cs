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

    private void Awake()
    {
        Instance = this;
    }

    public void BtnClick()
    {
        TowerInventory.Instance.isGripTower = true;
        TowerButtonClickSignal(SilhouetteTower, Unable_SilhouetteTower, BuildingTower);
    }
}
