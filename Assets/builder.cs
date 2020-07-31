using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class builder : MonoBehaviour
{
    public GameObject brickPrefab;
    private Vector3 pos;
    private System.Random rnd = new System.Random();
    public int[,] map = new int[10, 7];
    private List<GameObject> bricks = new List<GameObject>();
    public List<GameObject> bonuses = new List<GameObject>();
    public void Build()
    {
        pos = new Vector3(-140, 180, 0);
        for (int k = 0; k <= 10; k++)
        {
            map[rnd.Next(0, 10),rnd.Next(0, 7)] = 1;
        }
        for (int y = 0; y < 10; y++)
        {
            
            for (int x = 0; x < 7; x++)
            {

                if (map[y, x] == 1)
                {
                    var brick = Instantiate(brickPrefab, pos, Quaternion.identity);
                    bricks.Add(brick);
                    map[y, x] = 0;
                }
                pos.x = pos.x + 40f;
            }
            pos.x = -140;
            pos.y = pos.y + 20f;
        }

    }
    public void Destroy()
    {
        foreach(var brick in bricks)
        {
            Destroy(brick);
        }
        bricks.Clear();
        foreach (var bonus in bonuses)
        {
            Destroy(bonus);
        }
        bonuses.Clear();
    }
    void Start()
    {
        Build();
    }
}
