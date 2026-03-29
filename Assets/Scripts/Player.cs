using UnityEngine;

public class Player :IDamageable
{
    public string Name;
    public int Life;


    public void Move()
    {
        Debug.Log("Player is moving");
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Recibi daño!");
    }
}
