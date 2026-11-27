using UnityEngine;

public class MotaPlayer : MotaCharacter
{
    protected override void Die()
    {
        Debug.Log("Player died");
        base.Die();
    }
}
