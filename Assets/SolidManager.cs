using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolidManager : MonoBehaviour
{
    private int width, height;
    private float positionx = 0 , positiony = 0;
    private Solid[,] grid;

    public GameObject solidPrefab;

    void InitializeGrid(int gridWidth, int gridHeight)
    {
        width = gridWidth;
        height = gridHeight;
        grid = new Solid[width, height];
    }

    void GenerateGrid()
    {
        for (int j = 0; j < height; j++)
        {
            
            for (int i = 0; i < j + 1; i++)
            {
                GameObject solidObj = Instantiate(solidPrefab);
                solidObj.transform.position = new Vector2(positionx, positiony);

                positionx += 0.32f;

                Solid solid = solidObj.GetComponent<Solid>();

                int randomType = Random.Range(0, solid.Images.Count);
                solid.SetType(randomType);
                solid.GetComponent<SpriteRenderer>().sortingOrder = j;
            }

            positionx = -0.16f * (j + 1);
            positiony -= 0.18f;
        }
        positionx = -0.16f * 20;
        positiony = -0.18f * 20;
        //for (int j = 0;j < width; j++)
        //{
        //    for(int i = 0;i < width; i++)
        //    {
        //        GameObject solidObj = Instantiate(solidPrefab);
        //        solidObj.transform.position = new Vector2(positionx, positiony);

        //        positionx += 0.32f;

        //        Solid solid = solidObj.GetComponent<Solid>();

        //        int randomType = Random.Range(0, solid.Images.Count);
        //        solid.SetType(randomType);
        //        solid.GetComponent<SpriteRenderer>().sortingOrder = j;

        //    }
        //    positionx = -0.16f * 20;
        //    positiony -= 0.18f;
        //}


    }

    void Start()
    {
        InitializeGrid(20, 20);
        GenerateGrid();
    }
}
