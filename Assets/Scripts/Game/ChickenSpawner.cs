using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenSpawner : MonoBehaviour
{
    [SerializeField] private GameObject chickenPrefab;

    private void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-4f, 4f), Random.Range(-4f, 4f), 0);
            GameObject go = Instantiate(chickenPrefab, pos, Quaternion.identity);
            go.GetComponent<MergeChicken>().Init(Random.Range(3, 5)); // Стартовий рівень 1 або 2
        }
    }
}
