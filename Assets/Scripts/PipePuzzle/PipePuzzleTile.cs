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
                             
                //   if (TilesX > 0)
                 //   {
                   //     if (TilesX == 5 || TilesX == 10 || TilesX == 15 || TilesX == 20)
                   //     {

                     //   }
                    //    else 
                    //    {
                            Debug.Log("why" + gameObject.name);
                           // Debug.Log(gameObject.name + " is connected to " + Tiles[TilesX-1].gameObject.name);
                   //     }
                 //   }
                    
                //    if (TilesX < 24)
                 //   {
                   //     if (TilesX == 4 || TilesX == 9 || TilesX == 14 || TilesX == 19)
                   //     {

                   //     }
                  //      else 
                   //     {
                     //       Debug.Log("why" + gameObject.name);
                            //Debug.Log(gameObject.name + " is connected to " + Tiles[TilesX + 1].gameObject.name);
                   //     }
                  //  }
                }
                else if (TTile)
                {
                 
                   if (TilesX > 0)
                   {
                        Debug.Log(gameObject.name + " is connected to " + Tiles[TilesX -1].gameObject.name + " from the right");
                   
                   }
                   if (TilesX < 24)
                   {
                     Debug.Log(gameObject.name + " is connected to " + Tiles[TilesX + 1].gameObject.name + " from the left");
                      
                   }
                    if (TilesX < 20)
                    {
                         Debug.Log(gameObject.name + " is connected to " + Tiles[TilesX + 5].gameObject.name + " from the bottom");
              
                    }
                             //Debug.Log(Tiles[TilesX-1].gameObject.name + " " + Tiles[TilesX + 1].gameObject.name + " " +  Tiles[TilesX + 5].gameObject.name);
                }
                else if (ArmTile)
                {
                    if (TilesX > 0)
                    {
                        if (TilesX == 5 || TilesX == 10 || TilesX == 15 || TilesX == 20)
                        {

                        }
                        else 
                        {
                            ConnectingTiles.Add(Tiles[TilesX-1].gameObject);
                            //Debug.Log(gameObject.name + " is connected to " + Tiles[TilesX - 1].gameObject.name + " from the right");
                            
                        }
                    }
                    if (TilesX < 20)
                    {
                        ConnectingTiles.Add(Tiles[TilesX + 5].gameObject);
                        //Debug.Log(gameObject.name + " is connected to " + Tiles[TilesX + 5].gameObject.name +  " from the top");
                
                    }
           
                }
            }
            else if (RotateInt == 1)
            {
                Quaternion newRotation = new Quaternion(0, 0, 90,1 );
               // transform.eulerAngles= new Vector3(0, 0, 90);
                transform.rotation = newRotation;
           
                if (transform.rotation.z < 0)
                {
                    transform.rotation = new Quaternion(0, 0, transform.rotation.z * -1, 1);
                }
                if (StraightTile)
                { 
                    if (TilesX > 4)
                    {
                        
                    }
                    if (TilesX < 20)
                    {
                        
                    }
                }
                else if (TTile)
                {
                    //if (TilesX > 4)
                    //{
                      //  Debug.Log(gameObject.name + " " + Tiles[TilesX -5].gameObject.name + " from the bottom");
                    
                  //  }
                    if (TilesX <24)
                    {
                         Debug.Log(gameObject.name + " " + Tiles[TilesX + 1].gameObject.name + " from the left");
                  
                    }
                   
                    if (TilesX > 4)
                    {
                        Debug.Log(gameObject.name + " " + Tiles[TilesX - 5].gameObject.name + " from the bottom");
                 
                    }
                    
                     // Debug.Log(Tiles[TilesX-5].gameObject.name + " " + Tiles[TilesX + 5].gameObject.name + " " +  Tiles[TilesX + 1].gameObject.name);
            
                }
                else if (ArmTile)
                {
                    
                    if (TilesX < 20)
                    {
                        if (TilesX == 9 || TilesX == 14 || TilesX == 19 || TilesX == 24)
                        {

                        }
                        else 
                        {
                            ConnectingTiles.Add(Tiles[TilesX +1].gameObject);
                            // Debug.Log(gameObject.name + " is connected to " + Tiles[TilesX + 1].name + " from the left");
                
                        }
                    }
                    if (TilesX > 4)
                    {
                        ConnectingTiles.Add(Tiles[TilesX - 5].gameObject);
                       // Debug.Log(gameObject.name + " is connected to " + Tiles[TilesX - 5].name + " from the bottom");
                    }
                    
                
                    
                   
                    
                    
                }
            }
            else if (RotateInt == 2)
            {
                Quaternion newRotation = new Quaternion(0,0, 180, 1);
               // transform.eulerAngles = new Vector3(0, 0, 180);
                transform.rotation = newRotation;
                if (transform.rotation.z < 0)
                {
                    transform.rotation = new Quaternion(0, 0, transform.rotation.z * -1, 1);
                }
         
                if (StraightTile)
                {
                   // if (TilesX > 0)
                   // {
                      //  if (TilesX == 5 || TilesX == 10 || TilesX == 15 || TilesX == 20)
                       // {

                       // }
                        //else 
                       // {
                            Debug.Log("why 180" + gameObject.name);
                            //Debug.Log(gameObject.name + " is connected to " + Tiles[TilesX-1].gameObject.name);
                     //   }
                  //  }
                    
                  //  if (TilesX < 24)
                   // {
                     //   if (TilesX == 4 || TilesX == 9 || TilesX == 14 || TilesX == 19)
                      //  {

                     //   }
                     //   else 
                     //   {
                       //     Debug.Log("why 180" + gameObject.name);
                            //Debug.Log(gameObject.name + " is connected to " + Tiles[TilesX + 1].gameObject.name);
                     //   }
                   // }
                }
                else if (TTile)
                {
                    if (TilesX > 0)
                    {
                        if (TilesX == 5 || TilesX == 10 || TilesX == 15 || TilesX == 20)
                        {
                            
                        }
                        else
                        {
                            Debug.Log("what");
                            Debug.Log(gameObject.name + " is connected to " + Tiles[TilesX - 1].gameObject.name + " from the right");
                   
                        }
                        
                    }
                    if (TilesX < 24)
                    {
                        if (TilesX == 9 || TilesX == 14 || TilesX == 19 || TilesX == 24)
                        {

                        }
                        else
                        {
                            Debug.Log("what");
                             Debug.Log(gameObject.name + " is connected to " + Tiles[TilesX + 1].gameObject.name + " from the left");
                   
                        }
                       
                    }
                    if (TilesX > 4)
                    {
                         Debug.Log(gameObject.name + " is connected to " + Tiles[TilesX - 5].gameObject.name + " from the bottom");

                    }
                   
                  
                    //  Debug.Log(Tiles[TilesX-1].gameObject.name + " " + Tiles[TilesX + 1].gameObject.name + " " +  Tiles[TilesX - 5].gameObject.name);
            
                }
                else if (ArmTile)
                {
                    if (TilesX > 4)
                    {
                       
                            ConnectingTiles.Add(Tiles[TilesX - 5].gameObject);
                           //  Debug.Log(gameObject.name + " is connected to " + Tiles[TilesX - 5].name + " from the bottom");
                     
                        
                    }
                    if (TilesX < 24)
                    {
                        if (TilesX == 9 || TilesX == 14 || TilesX == 19 || TilesX == 24)
                        {
                            
                            }
                        else 
                        {
                            //ConnectedTiles.Add(gameObject);
                            ConnectingTiles.Add(Tiles[TilesX + 1].gameObject);
                           //  Debug.Log(gameObject.name + "is connected to " + Tiles[TilesX + 1].gameObject.name + "from the left");
                       
                        }
                    }
                 
                  
                    
                }
            }
            else if (RotateInt == 3)
            {
                Quaternion newRotation = new Quaternion(0, 0, 270, 1);
               // transform.eulerAngles=new Vector3(0, 0, 270);
               
                transform.rotation = newRotation;
                if (transform.rotation.z < 0)
                {
                    transform.rotation = new Quaternion(0, 0, transform.rotation.z * -1, 1);
                }
              
                if (StraightTile)
                { 
                    if (TilesX > 4)
                    {
                    }
                    if (TilesX < 20)
                    {
                        
                    }
                }
                else if (TTile)
                {
                    if (TilesX > 4)
                    {
                        Debug.Log(gameObject.name + " is connected to " + Tiles[TilesX - 5].gameObject.name + " from the top");
           
                    }
                    //if (TilesX > 4)
                    //{
                      //  Debug.Log(gameObject.name + " is connected to " + Tiles[TilesX + 5].gameObject.name + " from the bottom");
                   // }
                    if (TilesX <24)
                    {
                        Debug.Log(gameObject.name + " is connected to " + Tiles[TilesX + 1].gameObject.name + " from the left");
                    }
                    if (TilesX > 0)
                    {
                        Debug.Log(gameObject.name + " is connected to " + Tiles[TilesX - 1].gameObject.name + " from the right");
                    }
                      //Debug.Log(Tiles[TilesX-1].gameObject.name + " " +  Tiles[TilesX + 5].gameObject.name + " " + Tiles[TilesX - 5].gameObject.name);
            
                }
                else if (ArmTile)
                {
                    if(TilesX > 4)
                    {
                     
                       ConnectingTiles.Add(Tiles[TilesX - 5].gameObject);
                          //  Debug.Log(gameObject.name + " is connected to " + Tiles[TilesX - 5].name + " from the bottom");
                       
                    }
                    if (TilesX < 24)
                    {
                        if (TilesX == 4 || TilesX == 9 || TilesX == 14 || TilesX == 19 )
                        {
                            
                         }
                        else 
                        {
                            ConnectingTiles.Add(Tiles[TilesX + 1].gameObject);
                           //  Debug.Log(gameObject.name + " is connected to " + Tiles[TilesX + 1].name + " from the left");
                      
                        }
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
