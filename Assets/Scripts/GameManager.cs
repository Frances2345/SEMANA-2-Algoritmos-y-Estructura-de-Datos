using System.Collections.Generic;
using UnityEngine;
using Sowtank.Utils;
using System;

public class GameManager : MonoBehaviour
{
    private Inventory<string> inventory = new();
    private Inventory<int> inventory2 = new();
    private Player player;

    void Start()
    {
        GameUtils.Process<string>
            ("12", x => Debug.Log(x));

        GameUtils.Process<Player>(player, x => x.Move());

        //LAMBDA EXPRESSION
     
       
       


        Action test1 = () => Debug.Log("ayuda!");

        Action<string> test2 = (value) => { Debug.Log(value); };


       Action<int,int> test = (value1 ,value2) => Debug.Log(value1 +value2);

        test1?.Invoke(   );//PARAMETROS
        test2?.Invoke("ya no necesito ayuda B)");
        test?.Invoke(1,2);

        //LO QUE ESTA RETORNANDO
        Func<string,int> suma = (value) => 12;

        Func<Player, int> getPlayer = GetPlayerLife;


        int Value = GameUtils.Transform<Player, int>(player, (x) => x.Life);

        int Value2 = GetPlayerLife(player);


        TestTakeDamage<Player>(player, 15);

        int simpleReturn = ReturnSimple(out string obj);
        print(obj);

        int simpleReturn2 = ReturnSimple(out _);
    }


    public int GetPlayerLife(Player player)
    {
        return player.Life;
    }
    public int TestFunc(string value)
    {
       return 12;
    }
    public void TestTakeDamage<T>( T value,int damage) where T : IDamageable
    {
        value.TakeDamage(damage);
    }

    public int ReturnSimple(out string value)
    {
        value = "Ayuda!!";

        return 1;
      
    }
}
