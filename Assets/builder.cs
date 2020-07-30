using System;
using System.Collections;
using UnityEngine;

public class builder : MonoBehaviour
{
    public Transform brick;
    private Vector3 pos;
    private System.Random rnd = new System.Random();
    public int[,] map = new int[10, 7];
    // Start is called before the first frame update
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
                    Instantiate(brick, pos, Quaternion.identity);
                    map[y, x] = 0;
                }
                pos.x = pos.x + 40f;
            }
            pos.x = -140;
            pos.y = pos.y + 20f;
        }

    }
    void Start()
    {
        Build();
    }


    // Update is called once per frame
    void Update()
    {

    }


}
