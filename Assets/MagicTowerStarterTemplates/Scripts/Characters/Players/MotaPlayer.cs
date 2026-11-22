using UnityEngine;

public class MotaPlayer : MotaCharacter
{
    public override void OnDamageReceived(int damage)
    {
        base.OnDamageReceived(damage);
        Debug.Log($"Remaining HP: {Stat.HP}");
    }
    
    protected override void Die()
    {
        Debug.Log("Player died");
        base.Die();
    }
}
