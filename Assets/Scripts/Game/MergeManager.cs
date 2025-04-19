using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeManager : MonoBehaviour
{
    public static MergeManager Instance;

    [SerializeField] private GameObject chickenPrefab;

    private void Awake()
    {
        Instance = this;
    }

    public void TryMerge(MergeChicken a, MergeChicken b)
    {
        if (a.Level != b.Level) return;

        Vector3 spawnPos = (a.transform.position + b.transform.position) / 2f;

        Destroy(a.gameObject);
        Destroy(b.gameObject);

        GameObject newChicken = Instantiate(chickenPrefab, spawnPos, Quaternion.identity);
        newChicken.GetComponent<MergeChicken>().Init(a.Level + 1);
    }
}
