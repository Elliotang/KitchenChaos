using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlatesCounterVisual : MonoBehaviour
{
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private Transform plateVisualPrefab;
    [SerializeField] private PlatesCounter platesCounter;

    private List<GameObject> plateVisualEffectObjectList;

    private void Awake()
    {
        plateVisualEffectObjectList = new List<GameObject>();
    }


    private void Start()
    {
        platesCounter.OnPlateSpawned += PlatesCounter_OnPlateSpawned;
        platesCounter.OnPlateRemoved += PlatesCounter_OnPlateRemoved;
    }

    private void PlatesCounter_OnPlateRemoved(object sender, System.EventArgs e)
    {
        GameObject plateGameObject = plateVisualEffectObjectList[plateVisualEffectObjectList.Count - 1];
        plateVisualEffectObjectList.Remove(plateGameObject);
        Destroy(plateGameObject);
    }


    private void PlatesCounter_OnPlateSpawned(object sender, System.EventArgs e)
    {
        Transform plateVisualTransform = Instantiate(plateVisualPrefab, counterTopPoint);

        float plateOffsetY = 0.1f;
        plateVisualTransform.localPosition = new Vector3(0, plateOffsetY * plateVisualEffectObjectList.Count, 0);

        plateVisualEffectObjectList.Add(plateVisualTransform.gameObject);
    }
    
}
