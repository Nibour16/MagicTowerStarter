using UnityEngine;

public static class DamageCalculator
{
    public static int GetDamageOnTurn(int atk, int def) 
    {
        return Mathf.Max(atk - def, 0);
    }

    public static int PredictBattleDamage(int hpA, int atkA, int defA, int atkB, int defB) 
    {
        int currentHealth = hpA;
        int damage = 0;

        while(currentHealth > 0) 
        {
            currentHealth -= GetDamageOnTurn(atkB, defA);

            if (currentHealth > 0)
                damage += GetDamageOnTurn(atkA, defB);
        }

        return damage;
    }
}
