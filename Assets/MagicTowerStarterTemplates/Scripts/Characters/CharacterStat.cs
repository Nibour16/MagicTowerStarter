using System.Collections.Generic;
using UnityEngine;
using UnityGameStarter.DataStructure;
using UnityMotaStarter.Characters;

public class CharacterStat : ScriptableObject, ICharacterAttributes
{
    [SerializeField] private int hp = 100;
    [SerializeField] private int atk = 10;
    [SerializeField] private int def = 10;
    [SerializeField] private int gold = 0;

    private CharacterAttributeData _data;

    public CharacterAttributeData Data => _data;
    protected virtual Dictionary<string, float> ExtraData { private get; set; }

    protected virtual void Awake() 
    {
        var data = new Dictionary<string, float>()
        {
            {"Health", hp },
            {"Attack", atk },
            {"Defense", def },
            {"Gold", gold }
        };

        data.AddRangeSafe(ExtraData);
        _data = new CharacterAttributeData(data);
    } 
}
