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
                //Debug.Log(gameObject.name + " should not be rotated");
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
                        if (TilesX == 4 || TilesX == 9 || TilesX == 14 || TilesX == 19 || TilesX == 24)
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
            }
            else if (RotateInt == 1)
            {
                Quaternion newRotation = new Quaternion(0, 0, 90, 1);
                // transform.eulerAngles= new Vector3(0, 0, 90);
                // transform.rotation = newRotation;
                transform.Rotate(0, 0, 90);
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
                       // Debug.Log(gameObject.name + " is connected to " + Tiles[TilesX - 5].gameObject.name);
                    }
                    if (TilesX < 20)
                    {
                        ConnectingTiles.Add(Tiles[TilesX + 5].gameObject);
                       // Debug.Log(gameObject.name + " is connected to " + Tiles[TilesX + 5].gameObject.name);
                    }
                }
                else if (TTile)
                {



                }
                else if (ArmTile)
                {

                    if (TilesX < 24)
                    {
                        if (TilesX == 9 || TilesX == 14 || TilesX == 19 || TilesX == 24)
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
            }
            else if (RotateInt == 2)
            {
                Quaternion newRotation = new Quaternion(0, 0, 180, 1);
                // transform.eulerAngles = new Vector3(0, 0, 180);
                //transform.rotation = newRotation;
                transform.Rotate(0, 0, 180);
                //Debug.Log(gameObject.name + " should be rotated 180 degrees");
                //if (transform.rotation.z < 0)
                // {
                //   transform.rotation = new Quaternion(0, 0, transform.rotation.z * -1, 1);
                // }

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
                        if (TilesX == 4 || TilesX == 9 || TilesX == 14 || TilesX == 19 || TilesX == 24)
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

                }
                else if (ArmTile)
                {
                    if (TilesX > 4)
                    {

                        ConnectingTiles.Add(Tiles[TilesX - 5].gameObject);


                    }
                    if (TilesX < 24)
                    {
                        if (TilesX == 9 || TilesX == 14 || TilesX == 19 || TilesX == 24)
                        {

                        }
                        else
                        {
                            ConnectingTiles.Add(Tiles[TilesX + 1].gameObject);

                        }
                    }



                }
            }
            else if (RotateInt == 3)
            {
                Quaternion newRotation = new Quaternion(0, 0, 270, 1);
                // transform.eulerAngles=new Vector3(0, 0, 270);
                transform.Rotate(0, 0, 270);
                //transform.rotation = newRotation;
                //if (transform.rotation.z < 0)
                //{
                //   transform.rotation = new Quaternion(0, 0, transform.rotation.z * -1, 1);
                // }
                //  Debug.Log(gameObject.name + " should be rotated 270");
                if (StraightTile)
                {
                    if (TilesX > 4)
                    {
                        ConnectingTiles.Add(Tiles[TilesX - 5].gameObject);
                      //  Debug.Log(gameObject.name + " is connected to " + Tiles[TilesX - 5].gameObject.name);
                    }
                    if (TilesX < 20)
                    {
                        ConnectingTiles.Add(Tiles[TilesX + 5].gameObject);
                       // Debug.Log(gameObject.name + " is connected to " + Tiles[TilesX + 5].gameObject.name);
                    }
                }
                else if (TTile)
                {

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
            }
        }
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
        }
*/
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
