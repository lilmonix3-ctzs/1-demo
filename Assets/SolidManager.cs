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
        int sortorder = 0;
        for (int j = 0; j < height; j++,sortorder++)
        {
            
            for (int i = 0; i < j + 1; i++)
            {
                GameObject solidObj = Instantiate(solidPrefab);
                solidObj.transform.position = new Vector2(positionx, positiony);

                positionx += 0.32f;

                Solid solid = solidObj.GetComponent<Solid>();

                int randomType = Random.Range(0, solid.Images.Count);
                solid.SetType(randomType);
                solid.GetComponent<SpriteRenderer>().sortingOrder = sortorder;
            }

            positionx = -0.16f * (j + 1);
            positiony -= 0.18f;
        }
        positionx = -0.16f * width;
        positiony = -0.18f * height;
        for (int j = 0; j < width; j++, sortorder++)
        {
            for (int i = 0; i < width; i++)
            {
                GameObject solidObj = Instantiate(solidPrefab);
                solidObj.transform.position = new Vector2(positionx, positiony);

                positionx += 0.32f;

                Solid solid = solidObj.GetComponent<Solid>();

                int randomType = Random.Range(0, solid.Images.Count);
                solid.SetType(randomType);
                solid.GetComponent<SpriteRenderer>().sortingOrder = sortorder;

            }
            if (j % 2 == 0)
                positionx = -0.16f * (width + 1);
            else
                positionx = -0.16f * height;
            positiony -= 0.18f;
        }
        positionx = 0.16f * (width - 2);
        for (int j = 0; j < height; j++, sortorder++)
        {
            
            for (int i = 0; i < width - j; i++)
            {
                GameObject solidObj = Instantiate(solidPrefab);
                solidObj.transform.position = new Vector2(positionx, positiony);

                positionx -= 0.32f;

                Solid solid = solidObj.GetComponent<Solid>();

                int randomType = Random.Range(0, solid.Images.Count);
                solid.SetType(randomType);
                solid.GetComponent<SpriteRenderer>().sortingOrder = sortorder;
            }
            positionx = 0.16f * (width - 3 - j);
            positiony -= 0.18f;
        }

    }

    void Start()
    {
        InitializeGrid(20, 20);
        GenerateGrid();
    }
}
