using UnityEngine;

public abstract class MotaCharacter : MonoBehaviour
{
    [SerializeField] private CharacterAttributes attributes;
    public CharacterAttributes Attributes => attributes;

    public virtual void OnDamageReceived(int damage)
    {
        attributes.HP -= damage;

        if (attributes.HP <= 0)
            Die();
    }

    protected virtual void Die() 
    {
        Destroy(gameObject);
    }
}
