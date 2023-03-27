using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehaviour : MonoBehaviour
{
    [Header("Possible Random Speed")]
    [SerializeField] int Min_speed; 
    [SerializeField] int Max_Speed;

    [Header("Ship Atributtes")]
    [SerializeField] float acceleration;
    private float speed;

    void OnEnable()
    {
        SetRandomAtributtes();
    }

    public void SetRandomAtributtes()
    {
        speed = Random.Range(Min_speed, Max_Speed);
    }

    void Update () 
    {
        // aumenta a velocidade da nave a cada quadro
        speed += acceleration * Time.deltaTime;

        // move a nave na direção da frente
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }

    void OnDestroy()
    {
        HUD_Manager.singleton.DecreaseShips();
    }


    
}
