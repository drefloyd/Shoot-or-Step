using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width, height;
    [SerializeField] private Tile atile;
    [SerializeField] private Transform theCam;
    private void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                var addedTile = Instantiate(atile, new Vector3(i,j),Quaternion.identity);
                addedTile.name = $"Grid Tile {i} {j}";
                //changing color to make a checkboard pattern

                if ((i%2 == 0 && j % 2!=0)||(i%2!=0&&j%2==0))
                {
                    addedTile.Init(true);
                }
                else
                {
                    addedTile.Init(false);
                }
            }
        }
        /*
        //center cam in the middle of the grid
        theCam.transform.position = new Vector3((float)width/2-0.5f,(float)height/2-.5f,-10);
        */
    }
}
