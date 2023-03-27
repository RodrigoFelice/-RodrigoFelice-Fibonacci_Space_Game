using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [Header("Pool Settings")]
    [SerializeField] private int poolSize = 10;
    [SerializeField] private int actualSize = 0;
    
    [Space(25)]

    [Header("Ship Models")]
    [SerializeField] GameObject modelPrefab;
    GameObject emptyGameObject;

    [Space(25)]

    [Header("All Ships List")] 
    public List<GameObject> allShips = new List<GameObject>();

    [Space(25)]

    [Header("Trash List")]
    public List<GameObject> shipsToDestroy = new List<GameObject>();


    public void Begin_Spawn() 
    {    
        CreateShips();
        StartCoroutine(DestroyShips(5f));
    }

    void CreateShips()
    {
        if (actualSize < poolSize)
        {
            emptyGameObject = Instantiate(modelPrefab, transform.position, transform.rotation, transform);
            emptyGameObject.SetActive(false);
            allShips.Add(emptyGameObject);
            shipsToDestroy.Add(emptyGameObject);
            actualSize++;
            CreateShips();
            return;
        }
       
    }

    public void Call_DestroyShips()
    {
        if(shipsToDestroy.Count > 0)
        {
            StartCoroutine(DestroyShips(1f));
        }
    }

    IEnumerator DestroyShips(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(shipsToDestroy[0]);
        shipsToDestroy.RemoveAt(0);
        Call_DestroyShips();
    }
}
