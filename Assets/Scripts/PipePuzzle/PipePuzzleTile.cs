using UnityEngine;

public class PipePuzzleTile : MonoBehaviour
{
    public bool watered;
    public GameObject[] ConnectingTiles;
    public bool EndTile;
    public bool StraightTile, TTile, ArmTile;
   // public bool TileChild;
    public GameObject Child;
    //
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int RotateInt = Random.Range(0, 4);

        foreach(GameObject Tile in ConnectingTiles)
        {
            Debug.Log(Tile.name);
        }
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
        if (!EndTile)
        {
            switch(RotateInt)
        {
            case 0:
                //Debug.Log(RotateInt);
                //transform.rotation = new Vector3(0, 0, 90);
                transform.rotation  = Quaternion.Euler(0, 0, 90);
                break;
            case 1:
                //transform.rotation = new Vector3(0, 0, 180);
                transform.rotation = Quaternion.Euler(0, 0, 180);
                //Debug.Log(RotateInt);
                break;
            case 2:
                //transform.rotation = new Vector3(0, 0, 270);
                transform.rotation = Quaternion.Euler(0, 0, 270);
                //Debug.Log(RotateInt);
                break;
            case 3:
                //transform.rotation = new Vector3(0, 0, 0);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                //Debug.Log(RotateInt);
                break;
        }
        }
        if (transform.rotation.z == 90)
        {

        }
        else if (transform.rotation.z == 180)
        {

        }
        else if (transform.rotation.z == 0)
        {

        }
        else if (transform.rotation.z == 270)
        {

        }
        
    }
    public void SetConnectingTiles(GameObject Tile)
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
        
    }
    public void Rotate()
    {
        if (!EndTile)
        {
            if (transform.rotation.z == 270)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                Debug.Log("Rotate from 270");
            }
            else if (transform.rotation.z  == 0)
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
                transform.rotation = Quaternion.Euler(0, 0, 270);
                Debug.Log("Rotate from 180");
            }
            //for some reason, putting (transform.rotation = Quaternion.Euler(0, 0, (transform.rotation.z + 90))) doesnt work
        }
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
