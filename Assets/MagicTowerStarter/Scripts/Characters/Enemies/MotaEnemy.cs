using UnityEngine;
using UnityGameStarter.Gameplay.GridSystem;

public class MotaEnemy : MotaCharacter, IGridCollideEvent
{
    public void OnHit(GameObject other)
    {
        if (!other.TryGetComponent<MotaPlayer>(out var player)) return;

        int damage = DamageCalculator.PredictBattleDamage(Attributes, player.Attributes);

        if (player.Attributes.HP > damage)
        {
            player.OnDamageReceived(damage);
            Die();
        }
        else
            Debug.Log($"Unable to defeat {Attributes.name}");
    }
}
