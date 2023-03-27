using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn_System : MonoBehaviour
{
    [Header("Position X")]
    public float min_PosX, max_PosX;

    [Header("Position Y")]
    public float min_PosY, max_PosY;

    [Header("Position Z")]
    public float min_PosZ, max_PosZ;


    public void RespawnShip(GameObject object_Choosen)
    {
        //poolObjects.allShips[loop_Index].SetActive(true);
        float random_PosX = Random.Range(min_PosX, max_PosX);
        float random_PosY = Random.Range(min_PosY, max_PosY);
        float random_PosZ = Random.Range(min_PosZ, max_PosZ);

        object_Choosen.transform.position = new Vector3(random_PosX, random_PosY, random_PosZ);
        object_Choosen.transform.rotation = Quaternion.Euler(-90.96f, 0f, 0f);

        object_Choosen.SetActive(true);
        HUD_Manager.singleton.IncreaseShips();
    }
}
