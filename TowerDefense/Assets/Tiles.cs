using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tiles : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private Color prevMeshColor;

    private GameObject SilhouetteTower;
    private GameObject NewSilhouetteTower;

    private GameObject Unable_SilhouetteTower;
    private GameObject NewUnable_SilhouetteTower;

    private GameObject BuildingTower;

    private void Awake()
    {
        TowerInfo.TowerButtonClickSignal += OnTower;
        meshRenderer = GetComponent<MeshRenderer>();
        prevMeshColor = meshRenderer.material.color;
    }

    private void OnTower(GameObject SilhouetteTower, GameObject Un_SilhouetteTower, GameObject BuildingTower)
    {
        this.SilhouetteTower = SilhouetteTower;
        Unable_SilhouetteTower = Un_SilhouetteTower;
        this.BuildingTower = BuildingTower;
    }

    private void OnMouseEnter()
    {
        if (TowerInventory.Instance.isGripTower)
        {
            if (gameObject.tag == "ValidTiles")
            {
                NewSilhouetteTower = Instantiate(SilhouetteTower);
                NewSilhouetteTower.transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
                meshRenderer.material.color = Color.green;
            }

            if (gameObject.tag == "UnavailableTiles")
            {
                NewUnable_SilhouetteTower = Instantiate(Unable_SilhouetteTower);
                NewUnable_SilhouetteTower.transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
                meshRenderer.material.color = Color.red;
            }
        }
    }

    private void OnMouseDown()
    {
        if (TowerInventory.Instance.isGripTower && gameObject.tag == "ValidTiles")
        {
            GameObject newBuildingTower = Instantiate(BuildingTower);
            newBuildingTower.transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
            TowerInventory.Instance.isGripTower = false;

            if (NewSilhouetteTower != null)
            {
                Destroy(NewSilhouetteTower);
            }
        }
    }

    private void OnMouseExit()
    {
        meshRenderer.material.color = prevMeshColor;

        if (NewSilhouetteTower != null)
        {
            Destroy(NewSilhouetteTower);
        }

        if (NewUnable_SilhouetteTower != null)
        {
            Destroy(NewUnable_SilhouetteTower);
        }

    }
}
