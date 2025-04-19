using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeChicken : MonoBehaviour
{
    public int Level { get; private set; }

    [SerializeField] private Sprite[] levelSprites; // 0 = Level 1, 1 = Level 2 ...
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Init(int level)
    {
        Level = level;
        spriteRenderer.sprite = levelSprites[Level - 1];
    }

    public void Upgrade()
    {
        if (Level < levelSprites.Length)
        {
            Init(Level + 1);
        }
        else
        {
            Debug.Log("MAX level!");
        }
    }
}
