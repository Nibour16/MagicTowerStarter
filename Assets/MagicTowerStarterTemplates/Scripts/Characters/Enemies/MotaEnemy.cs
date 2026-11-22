using UnityEngine;
using UnityGameStarter.Gameplay.GridSystem;

public class MotaEnemy : MotaCharacter, IGridCollideEvent
{
    public void OnHit(GameObject other)
    {
        if (!other.TryGetComponent<MotaPlayer>(out var player)) return;

        int damage = DamageCalculator.PredictBattleDamage(Stat, player.Stat);

        if (player.Stat.HP > damage)
        {
            player.OnDamageReceived(damage);
            Die();
        }
        else
            Debug.Log($"Unable to defeat {Stat.name}");
    }
}
