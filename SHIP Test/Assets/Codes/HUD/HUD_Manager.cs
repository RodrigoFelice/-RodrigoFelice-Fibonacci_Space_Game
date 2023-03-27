using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD_Manager : MonoBehaviour
{
    public static HUD_Manager singleton;

    void Awake() => singleton= this;

    [Header("Main HUD Variables")]
    public TMP_Text shipsCreated_Text;
    [Space(25)]
    public TMP_Text shipsDestroyed_Text;

    int numberOf_Ships_Created, numberOf_Ships_Destroyed;


    public void IncreaseShips()
    {
        numberOf_Ships_Created++;
        shipsCreated_Text.text = "Naves Criadas: " + numberOf_Ships_Created;
    }

    public void DecreaseShips()
    {
        numberOf_Ships_Destroyed++;
        shipsDestroyed_Text.text = "Naves Destruidas: " + numberOf_Ships_Destroyed;
    }
   
}
