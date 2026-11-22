using UnityEngine;

public abstract class MotaCharacter : MonoBehaviour
{
    [SerializeField] private CharacterAttributes stat;
    public CharacterAttributes Stat => stat;

    public virtual void OnDamageReceived(int damage)
    {
        stat.HP -= damage;

        if (stat.HP <= 0)
            Die();
    }

    protected virtual void Die() 
    {
        Destroy(gameObject);
    }
}
