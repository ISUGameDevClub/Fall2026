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

    }
    
    public void SetTile(int RotateInt)
    {
        //int RotateInt = Random.Range(0, 4);
        if (!EndTile)
        {
            if (RotateInt == 0)
            {
                if (StraightTile)
                {
                    
                    if (TilesX > 0)
                    {
                        if (TilesX != 5 || TilesX != 10 || TilesX != 15 || TilesX != 20)
                        {

                        }
                        else 
                        {
                            
                       // Debug.Log(Tiles[TilesX - 1].gameObject.name);
                        }
                    }
                    
                    if (TilesX < 24)
                    {
                        if (TilesX != 4 || TilesX != 9 || TilesX != 14 || TilesX != 19)
                        {

                        }
                        else 
                        {
                            
                           // Debug.Log(Tiles[TilesX + 1].gameObject.name);
                        }
                    }
                }
                else if (TTile)
                {
                   if (TilesX< 20)
                   {
                    
                   }
                }
                else if (ArmTile)
                {
                    if (TilesX > 0)
                    {
                        if (TilesX != 5 || TilesX != 10 || TilesX != 15 || TilesX != 20)
                        {

                        }
                        else 
                        {
                            
                        Debug.Log(Tiles[TilesX - 1].gameObject.name);
                        }
                    }
                    if (TilesX < 20)
                    {
                        Debug.Log(Tiles[TilesX + 5].gameObject.name);
                    }
                }
            }
            else if (RotateInt == 1)
            {
                transform.eulerAngles= new Vector3(0, 0, 90);
                if (StraightTile)
                { 
                    if (TilesX > 4)
                    {
                        
                       // Debug.Log(Tiles[TilesX - 5].gameObject.name);
                    }
                    if (TilesX < 20)
                    {
                        
                    //Debug.Log(Tiles[TilesX + 5].gameObject.name);
                    }
                }
                else if (ArmTile)
                {
                    if (TilesX < 20)
                    {
                        Debug.Log(Tiles[TilesX + 5].gameObject.name);
                    }
                    if (TilesX != 4 || TilesX != 9 || TilesX != 14 || TilesX != 19)
                    {

                    }
                    else 
                    {
                            
                        Debug.Log(Tiles[TilesX + 1].gameObject.name);
                    }
                }
            }
            else if (RotateInt == 2)
            {
                transform.eulerAngles = new Vector3(0, 0, 180);
                if (StraightTile)
                {
                     if (TilesX > 0)
                    {
                        if (TilesX != 5 || TilesX != 10 || TilesX != 15 || TilesX != 20)
                        {

                        }
                        else 
                        {
                            
                        //Debug.Log(Tiles[TilesX - 1].gameObject.name);
                        }
                    }
                    if (TilesX < 24)
                    {
                        if (TilesX != 4 || TilesX != 9 || TilesX != 14 || TilesX != 19)
                        {

                        }
                        else 
                        {
                            
                            //Debug.Log(Tiles[TilesX + 1].gameObject.name);
                        }
                    }
                }
                else if (TTile)
                {

                }
                else if (ArmTile)
                {
                    if (TilesX > 5)
                    {
                        
                        Debug.Log(Tiles[TilesX - 5].gameObject.name);
                    }
                    if (TilesX != 4 || TilesX != 9 || TilesX != 14 || TilesX != 19 || TilesX != 24)
                    {
                        Debug.Log(Tiles[TilesX + 1].gameObject.name);
                    }
                    
                }
            }
            else if (RotateInt == 3)
            {
                transform.eulerAngles=new Vector3(0, 0, 270);
                if (StraightTile)
                { 
                    if (TilesX > 4)
                    {
                        //Debug.Log(Tiles[TilesX - 5].gameObject.name);
                    }
                    if (TilesX < 20)
                    {
                        
                    //Debug.Log(Tiles[TilesX + 5].gameObject.name);
                    }
                }
                else if (ArmTile)
                {
                    if (TilesX > 4)
                    {
                        Debug.Log(Tiles[TilesX - 5].gameObject.name);
                    
                    }
                    if (TilesX != 5 || TilesX != 10 || TilesX != 15|| TilesX !=20)
                    {
                        Debug.Log(Tiles[TilesX - 1].gameObject.name);
                    }
                }
            }   
        }
    }
    
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
