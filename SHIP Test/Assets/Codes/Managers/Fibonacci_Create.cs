using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fibonacci_Create : MonoBehaviour
{   
    [Header("Pool Reference")]
    [SerializeField] ObjectPooling poolObjects;

    [Space(25)]

    [Header("Fibonacci Settings")]
    private int current_Value = 0, previous_Value = 0, repeat_Value_Count = 0, loop_Index;

    // Start is called before the first frame update
    void Start()
    {
        print("Sequência de Fibonacci com Naves Criadas! ");
        StartCoroutine(Fibonacci_Loop());
    }


    IEnumerator Fibonacci_Loop()
    {
        loop_Index = 0;
        yield return new WaitForSeconds(1f);

        if(current_Value == 0)
        {
            current_Value = 1;
            print("Sequência: " + loop_Index); 
            StartCoroutine(Fibonacci_Loop());
        }
        else
        {
            if (repeat_Value_Count < 2)
            {
                previous_Value = current_Value;
                repeat_Value_Count++;
                Create_Ships();
            }
            else
            {
                current_Value += previous_Value;
                previous_Value = current_Value - previous_Value;
                Create_Ships();
            }
        } 
    }


    void Create_Ships()
    {
        //acabou espaço da lista para criar naves
        if(current_Value > poolObjects.allShips.Count)
        {
            print("não tem mais espaço");
            return;
        }

        //ativa o objeto da pool e remove ele dela
        if(loop_Index < current_Value)
        {
            GetComponent<Respawn_System>().RespawnShip(poolObjects.allShips[loop_Index]);
            poolObjects.allShips.Remove(poolObjects.allShips[loop_Index]);
            loop_Index++;
            Create_Ships();
            return;
        }

        //continua a sequencia de Fibonacci
        print("Sequência: " + loop_Index);
        StartCoroutine(Fibonacci_Loop());
    }

}
