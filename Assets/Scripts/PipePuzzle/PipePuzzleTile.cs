using UnityEngine;
using System.Collections.Generic;
//using System;
using UnityEngine.UI;
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
    public int EndTileRotateX;
    public int manualRotationInt;
    //EndTileRotateX  0 = no rotation
    //EndTileRotateX 1 = 90 degrees 
    //EndTileRotateX 2 = 180 degrees
    //EndTileRotateX 3 = 270 degrees
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    public void CheckWater()
    {
        for(int i = 0; i < ConnectingTiles.Count; i++)
        {
            if (ConnectingTiles[i].GetComponent<PipePuzzleTile>().ConnectingTiles.Contains(gameObject))
            {
                Debug.Log(gameObject + " is connected to " + ConnectingTiles[i].gameObject.name + " fully");
                if (ConnectingTiles[i].gameObject.GetComponent<PipePuzzleTile>().watered)
                {
                    watered = true;
                }
            }
        }
    }
    public void CheckEndTile()
    {
        if (EndTileRotateX == 0)
        {
            if (TilesX < 20)
            {
                ConnectingTiles.Add(Tiles[TilesX + 5].gameObject);
            }
        }
        else if (EndTileRotateX == 1)
        {
            if (TilesX < 24)
            {
                ConnectingTiles.Add(Tiles[TilesX + 1].gameObject);
            }
        }
        else if (EndTileRotateX == 2)
        {
            if (TilesX > 4)
            {
                ConnectingTiles.Add(Tiles[TilesX - 5].gameObject);
            }
        }
        else if (EndTileRotateX == 3)
        {
            if (TilesX > 0)
            {
                ConnectingTiles.Add(Tiles[TilesX - 1].gameObject);
            }
        }
        
    }
    public void SetTile(int RotateInt, bool manual)
    {
        //int RotateInt = Random.Range(0, 4);
        if (!EndTile)
        {
            if (RotateInt == 0)
            {
                manualRotationInt = RotateInt;
                if (StraightTile)
                {
                    if (TilesX > 0)
                    {
                        if (TilesX == 5 || TilesX == 10 || TilesX == 15 || TilesX == 20)
                        {

                        }
                        else
                        {
                            ConnectingTiles.Add(Tiles[TilesX - 1].gameObject);
                        }
                    }
                    if (TilesX < 24)
                    {
                        if (TilesX == 4 || TilesX == 9 || TilesX == 14 || TilesX == 19)
                        {

                        }
                        else
                        {
                            ConnectingTiles.Add(Tiles[TilesX + 1].gameObject);
                        }
                    }
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
                            ConnectingTiles.Add(Tiles[TilesX - 1].gameObject);
                            // Debug.Log(gameObject.name + " is connected to " + Tiles[TilesX - 1] + " from the right");
                        }
                    }
                    if (TilesX < 24)
                    {
                        if (TilesX == 4 || TilesX == 9 || TilesX == 14 || TilesX == 19)
                        {

                        }
                        else
                        {
                            ConnectingTiles.Add(Tiles[TilesX + 1].gameObject);
                            //Debug.Log(gameObject.name + " is connected to " + Tiles[TilesX + 1] + " from the left");
                        }
                    }
                    if (TilesX < 20)
                    {
                        ConnectingTiles.Add(Tiles[TilesX + 5].gameObject);
                        //  Debug.Log(gameObject.name + " is connected to " + Tiles[TilesX + 5] + " from the up");
                    }

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
                            ConnectingTiles.Add(Tiles[TilesX - 1].gameObject);

                        }
                    }
                    if (TilesX < 20)
                    {
                        ConnectingTiles.Add(Tiles[TilesX + 5].gameObject);

                    }

                }
                //  }
            }
            else if (RotateInt == 1)
            {
                // if (EndTile)
                //{
                //  if (TilesX < 24)
                //  {
                //     ConnectingTiles.Add(Tiles[TilesX + 1].gameObject);

                //   }

                //  }
                //  else
                // {
                Quaternion newRotation = new Quaternion(0, 0, 90, 1);
                // transform.eulerAngles= new Vector3(0, 0, 90);
                // transform.rotation = newRotation;
                if (manual)
                {

                }
                else
                {
                    
                transform.Rotate(0, 0, 90);
                }
                manualRotationInt = RotateInt;
                //Debug.Log(gameObject.name + " should be rotated 90 degrees");
                //if (transform.rotation.z < 0)
                //{
                //  transform.rotation = new Quaternion(0, 0, transform.rotation.z * -1, 1);
                // }
                if (StraightTile)
                {
                    if (TilesX > 4)
                    {
                        ConnectingTiles.Add(Tiles[TilesX - 5].gameObject);
                    }
                    if (TilesX < 20)
                    {
                        ConnectingTiles.Add(Tiles[TilesX + 5].gameObject);
                    }
                }
                else if (TTile)
                {

                    if (TilesX < 24)
                    {
                        if (TilesX == 4 || TilesX == 9 || TilesX == 14 || TilesX == 19)
                        {

                        }
                        else
                        {
                            ConnectingTiles.Add(Tiles[TilesX + 1].gameObject);
                            //Debug.Log(gameObject.name + " is connected to " + Tiles[TilesX + 1] + " from the left");
                        }
                        // ConnectingTiles.Add(Tiles[TilesX + 1].gameObject);
                    }

                    if (TilesX > 4)
                    {
                        ConnectingTiles.Add(Tiles[TilesX - 5].gameObject);
                        // Debug.Log(gameObject.name + " is connected to " + Tiles[TilesX - 5] + " from the bottom");
                    }
                    if (TilesX < 20)
                    {
                        ConnectingTiles.Add(Tiles[TilesX + 5].gameObject);
                        // Debug.Log(gameObject.name + " is connected to " + Tiles[TilesX + 5]  + " from the top");
                    }


                }
                else if (ArmTile)
                {

                    if (TilesX < 24)
                    {
                        if (TilesX == 4 || TilesX == 9 || TilesX == 14 || TilesX == 19)
                        {

                        }
                        else
                        {
                            ConnectingTiles.Add(Tiles[TilesX + 1].gameObject);

                        }
                    }
                    if (TilesX < 20)
                    {
                        ConnectingTiles.Add(Tiles[TilesX + 5].gameObject);
                    }

                }

                // }

            }
            else if (RotateInt == 2)
            {

                //Debug.Log(gameObject.name + " should be rotated 180 degrees");
                //if (transform.rotation.z < 0)
                // {
                //   transform.rotation = new Quaternion(0, 0, transform.rotation.z * -1, 1);
                // }
                // if (EndTile)
                //{
                //  if (TilesX > 4)
                //    {
                //       ConnectingTiles.Add(Tiles[TilesX - 5].gameObject);
                //    }
                //  }
                // else
                //  {
                Quaternion newRotation = new Quaternion(0, 0, 180, 1);
                // transform.eulerAngles = new Vector3(0, 0, 180);
                //transform.rotation = newRotation;
                if (manual)
                {

                }
                else
                {
                transform.Rotate(0, 0, 180);
                    
                }
                manualRotationInt = RotateInt;
                if (StraightTile)
                {
                    if (TilesX > 0)
                    {
                        if (TilesX == 5 || TilesX == 10 || TilesX == 15 || TilesX == 20)
                        {

                        }
                        else
                        {
                            ConnectingTiles.Add(Tiles[TilesX - 1].gameObject);
                        }
                    }
                    if (TilesX < 24)
                    {
                        if (TilesX == 4 || TilesX == 9 || TilesX == 14 || TilesX == 19)
                        {

                        }
                        else
                        {
                            ConnectingTiles.Add(Tiles[TilesX + 1].gameObject);
                        }
                    }
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
                            ConnectingTiles.Add(Tiles[TilesX - 1].gameObject);
                            // Debug.Log(gameObject.name + " is connected to " + Tiles[TilesX - 1] + " from the right");
                        }
                    }
                    if (TilesX < 24)
                    {
                        if (TilesX == 4 || TilesX == 9 || TilesX == 14 || TilesX == 19)
                        {

                        }
                        else
                        {
                            ConnectingTiles.Add(Tiles[TilesX + 1].gameObject);
                            // Debug.Log(gameObject.name + " is connected to " + Tiles[TilesX + 1] + " from the left");
                        }
                    }
                    if (TilesX > 4)
                    {
                        ConnectingTiles.Add(Tiles[TilesX - 5].gameObject);
                        //  Debug.Log(gameObject.name + " is connected to " + Tiles[TilesX - 5] + " from the bottom");
                    }
                }
                else if (ArmTile)
                {
                    if (TilesX > 4)
                    {

                        ConnectingTiles.Add(Tiles[TilesX - 5].gameObject);


                    }
                    if (TilesX < 24)
                    {
                        if (TilesX == 9 || TilesX == 14 || TilesX == 19)
                        {

                        }
                        else
                        {
                            ConnectingTiles.Add(Tiles[TilesX + 1].gameObject);

                        }
                    }



                }

                //   }

            }
            else if (RotateInt == 3)
            {

                //transform.rotation = newRotation;
                //if (transform.rotation.z < 0)
                //{
                //   transform.rotation = new Quaternion(0, 0, transform.rotation.z * -1, 1);
                // }
                //  Debug.Log(gameObject.name + " should be rotated 270");
                // if (EndTile)
                // {
                //     if (TilesX > 0)
                //     {
                //        ConnectingTiles.Add(Tiles[TilesX - 1].gameObject);
                //      }
                //  }
                // else
                //  {
                Quaternion newRotation = new Quaternion(0, 0, 270, 1);
                // transform.eulerAngles=new Vector3(0, 0, 270);
                if (manual)
                {

                }
                else
                {
                    
                transform.Rotate(0, 0, 270);
                }
                manualRotationInt = RotateInt;
                if (StraightTile)
                {
                    if (TilesX > 4)
                    {
                        ConnectingTiles.Add(Tiles[TilesX - 5].gameObject);
                    }
                    if (TilesX < 20)
                    {
                        ConnectingTiles.Add(Tiles[TilesX + 5].gameObject);
                    }
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
                            ConnectingTiles.Add(Tiles[TilesX - 1].gameObject);
                            //  Debug.Log(gameObject.name + " is connected to " + Tiles[TilesX - 1] + " from the right");
                        }
                        // ConnectingTiles.Add(Tiles[TilesX - 1].gameObject);
                    }

                    if (TilesX > 4)
                    {
                        ConnectingTiles.Add(Tiles[TilesX - 5].gameObject);
                        // Debug.Log(gameObject.name + " is connected to " + Tiles[TilesX - 5] + " from the bottom");
                    }
                    if (TilesX < 20)
                    {
                        ConnectingTiles.Add(Tiles[TilesX + 5].gameObject);
                        // Debug.Log(gameObject.name + " is connected to " + Tiles[TilesX + 5]  + " from the top");
                    }
                }
                else if (ArmTile)
                {
                    if (TilesX > 4)
                    {

                        ConnectingTiles.Add(Tiles[TilesX - 5].gameObject);

                    }

                    if (TilesX > 0)
                    {
                        if (TilesX == 5 || TilesX == 10 || TilesX == 15 || TilesX == 20)
                        {

                        }
                        else
                        {
                            ConnectingTiles.Add(Tiles[TilesX - 1].gameObject);

                        }
                    }


                }

                //  }
            }
            //  }
            //Put the following on the rotate code 
           /* for (int i = 0; i < ConnectingTiles.Count; i++)
            {
                if (ConnectingTiles[i].GetComponent<PipePuzzleTile>().ConnectingTiles.Contains(gameObject))
                {
                    Debug.Log(gameObject.name + " is connected to " + ConnectingTiles[i].name + " fully.");
                    if (ConnectingTiles[i].GetComponent<PipePuzzleTile>().watered)
                    {
                        watered = true;
                        //put the code for the water animation here
                    }
                }
            }*/

        }
    }
    public void Rotate()
    {
        if (!EndTile)
        {
            Debug.Log(manualRotationInt);
            if (manualRotationInt < 3)
            {
                manualRotationInt++;
                ConnectingTiles.Clear();
                SetTile(manualRotationInt, true);
                //transform.Rotate(0, 0, -90);
            }
            if (manualRotationInt == 3)
            {
                manualRotationInt = 0;
                ConnectingTiles.Clear();
                SetTile(manualRotationInt, true);
                //transform.Rotate(0, 0, -90);
            }
            transform.Rotate(0, 0, 180/2, Space.Self);
            //transform.Rotate(0, 0, 180,Space.Self);
            //SetTile();
            //for some reason, putting (transform.rotation = Quaternion.Euler(0, 0, (transform.rotation.z + 90))) doesnt work
        }
    }

    // Update is called once per frame
    void Update()
    {
        //  if (watered)
        // {

        //   Child.GetComponent<Image>().fillAmount+=.10f;
        //  }

    }
}
