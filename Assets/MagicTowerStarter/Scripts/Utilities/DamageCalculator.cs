using UnityEngine;

public static class DamageCalculator
{
    private const int _minDamage = 0;
    private const int _maxDamage = int.MaxValue;
    
    /// <summary>
    /// A is the attacker, B is the defender
    /// </summary>
    public static int GetDamageOnTurn(int atkA, int defB) 
    {
        return Mathf.Clamp(atkA - defB, _minDamage, _maxDamage);
    }

    /// <summary>
    /// A is the attacker (i.e. enemy), B is the defender (i.e. player)
    /// </summary>
    public static int PredictBattleDamage(CharacterAttributes attributesA, CharacterAttributes attributesB,
        bool failIfZeroDamageAtFirstTurn = false, int maxTurns = 1000) 
    {
        var dataA = attributesA.Data;
        var dataB = attributesB.Data;

        int currentHealth = (int)dataA.GetAttributeValue(attributesA.hpTag);
        int currentTurnPast = 0;
        int damage = 0;

        while (currentHealth > 0) 
        {
            if (++currentTurnPast > maxTurns) return _maxDamage;

            int atkA = (int)dataA.GetAttributeValue(attributesA.atkTag);
            int defA = (int)dataA.GetAttributeValue(attributesA.defTag);
            int atkB = (int)dataB.GetAttributeValue(attributesB.atkTag);
            int defB = (int)dataB.GetAttributeValue(attributesB.defTag);

            int turnDamage = GetDamageOnTurn(atkB, defA);

            if (failIfZeroDamageAtFirstTurn && turnDamage <= 0) return _maxDamage;

            currentHealth -= turnDamage;

            if (currentHealth > 0)
                damage += GetDamageOnTurn(atkA, defB);
        }

        return Mathf.Clamp(damage, _minDamage, _maxDamage);
    }
}
