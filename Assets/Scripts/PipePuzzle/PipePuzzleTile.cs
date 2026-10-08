using UnityEngine;
using System.Collections.Generic;
//using System;

public class PipePuzzleTile : MonoBehaviour
{
    public bool watered;
    public List<GameObject> ConnectingTiles = new List<GameObject>();
    public bool EndTile;
    public bool StraightTile, TTile, ArmTile, solutionTile;
    public List<GameObject> Tiles = new List<GameObject>();
    // public bool TileChild;
    public GameObject Child;
    //
    public int TilesX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //int RotateInt = Random.Range(0, 4);

        //foreach(GameObject Tile in ConnectingTiles)
        //{
        // Debug.Log(Tile.name);
        //}
        //Debug.Log(ConnectingTiles)
        //      if (StraightTile)
        //        {

        //  gameObject.GetComponent<Image>().sprite = 
        //    }
        /*if (RotateInt == 0)
        {

        }
        else if (RotateInt == 1)
        {

        }
        else if (RotateInt == 2)
        {

        }
        else if (RotateInt == 3)
        {

        }*/
        //Debug.Log(RotateInt);
        // if (!EndTile)
        //{

        //  if (RotateInt == 0)
        //{
        //Debug.Log(StraightTile);
        /*if (StraightTile)
        {
            if (Tiles[TilesX - 1] != null)
            {
                Debug.Log(Tiles[TilesX - 1].gameObject.name);
            }
            if (Tiles[TilesX + 1] != null)
            {

                Debug.Log(Tiles[TilesX + 1].gameObject.name);
            }

        }*/
        //GetNeighboringTiles();
        //}
        //}
        //if (!EndTile)
        //{
        /*switch (RotateInt)
        {
            //GetNeighboringTiles();
            case 0:
                //Debug.Log(RotateInt);
                //transform.rotation = new Vector3(0, 0, 90);
                //transform.rotation = Quaternion.Euler(0, 0, 90);
                //transform.Rotate(new Vector3(0, 0, 90));
                //Debug.Log(Tiles[TilesX + 5].gameObject.name);
                if (StraightTile)
                {
                    //Debug.Log(Tiles[TilesX + 5]);
                    GetNeighboringTiles();
                    //  Debug.Log(Tiles[TilesX + 5].gameObject.name);
                    //ConnectingTiles.Add(Tiles[TilesX + 1]);
                }
                else if (TTile)
                {
                    GetNeighboringTiles();
                    //Debug.Log(Tiles[TilesX + 5]);
                    //Debug.Log(Tiles[TilesX + 5].gameObject.name);
                }
                else if (ArmTile)
                {
                    GetNeighboringTiles();
                    //Debug.Log(Tiles[TilesX + 5]);
                    //Debug.Log(Tiles[TilesX + 5].gameObject.name);
                }
                break;
            case 1:
                //transform.rotation = new Vector3(0, 0, 180);
                // transform.rotation = Quaternion.Euler(0, 0, 180);

                if (StraightTile)
                {
                    GetNeighboringTiles();
                   // Debug.Log(Tiles[TilesX + 1].gameObject.name);
                   // Debug.Log(Tiles[TilesX - 1].gameObject.name);
                }
                else if (TTile)
                {
                    GetNeighboringTiles();
                }
                else if (ArmTile)
                {
                    GetNeighboringTiles();
                }
                //Debug.Log(RotateInt);
                break;
            case 2:
                //transform.rotation = new Vector3(0, 0, 270);
                // transform.rotation = Quaternion.Euler(0, 0, 270);
                if (StraightTile)
                {
                    GetNeighboringTiles();
                }
                else if (TTile)
                {
                    GetNeighboringTiles();
                }
                else if (ArmTile)
                {
                    GetNeighboringTiles();
                }
                //Debug.Log(RotateInt);
                break;
            case 3:
                //transform.rotation = new Vector3(0, 0, 0);
                // transform.rotation = Quaternion.Euler(0, 0, 0);
                if (StraightTile)
                {
                    GetNeighboringTiles();
                }
                else if (TTile)
                {
                    GetNeighboringTiles();
                }
                else if (ArmTile)
                {
                    GetNeighboringTiles();
                }
                //Debug.Log(RotateInt);
                break;
        }*/
        //}
    }
    
    public void SetTile()
    {
        int RotateInt = Random.Range(0, 4);
        if (!EndTile)
        {
            if (RotateInt == 0)
            {
                if (StraightTile)
                {
                    Debug.Log(transform.rotation.z);
                }
            }
            else if (RotateInt == 1)
            {

            }
            else if (RotateInt == 2)
            {

            }
            else if (RotateInt == 3)
            {
                
            }
        }
    }
    /*public void SetConnectingTiles(GameObject Tile)
    {
        if (ConnectingTiles[0] == null)
        {
            ConnectingTiles[0] = Tile;
        }
        else if (ConnectingTiles[1] == null)
        {
            ConnectingTiles[1] = Tile;
        }
        else if (ConnectingTiles[2] == null)
        {
            ConnectingTiles[2] = Tile;
        }
        
    }*/
    /* void GetNeighboringTiles()
     {
        // Debug.Log(transform.rotation.z);
         //if (!EndTile)
         //{


             if (transform.rotation.z == 270)
             {
                 //transform.rotation = Quaternion.Euler(0, 0, 0);
                 Debug.Log("Rotate from 270");
             }
             else if (transform.rotation.z == 0)
             {
                 //transform.rotation = Quaternion.Euler(0, 0, 90);
                 Debug.Log("Rotate from 0");
                 //transform.rotation = Quaternion.Euler(0, 0, (transform.rotation.z + 90));
             }
             else if (transform.rotation.z == 90)
             {
                 //transform.rotation = Quaternion.Euler(0, 0, 180);
                 Debug.Log("Rotate from 90");
             }
             else if (transform.rotation.z == 180)
             {
                 //transform.Rotate(new Vector3(0, 0, 90));
                 //transform.rotation = Quaternion.Euler(0, 0, 270);
                 Debug.Log("Rotate from 180");
             }
        // }
     }*/
    public void Rotate()
    {
        /*if (!EndTile)
        {
            if (transform.rotation.z == 270)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                Debug.Log("Rotate from 270");
            }
            else if (transform.rotation.z == 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
                Debug.Log("Rotate from 0");
                //transform.rotation = Quaternion.Euler(0, 0, (transform.rotation.z + 90));
            }
            else if (transform.rotation.z == 90)
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
                Debug.Log("Rotate from 90");
            }
            else if (transform.rotation.z == 180)
            {
                transform.Rotate(new Vector3(0, 0, 90));
                //transform.rotation = Quaternion.Euler(0, 0, 270);
                Debug.Log("Rotate from 180");
            }
            //for some reason, putting (transform.rotation = Quaternion.Euler(0, 0, (transform.rotation.z + 90))) doesnt work
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        /*foreach (GameObject Tile in ConnectedTiles)
        {
            if (Tile.GetComponent<PipePuzzleTile>().watered)
            {
                watered = true;
                return;
            }
        }*/

    }
}
