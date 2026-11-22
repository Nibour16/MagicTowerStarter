using System.Collections.Generic;
using UnityEngine;
using UnityGameStarter.DataStructure;
using UnityMotaStarter.Characters;

[CreateAssetMenu(
    fileName = "New Character", menuName = "Scriptable Objects/Mota Game Starter/Character Attributes")]
public class CharacterAttributes : ScriptableObject
{   
    #region Keep track of all base attributes
    [SerializeField, Min(1)] private int hp = 100;
    [SerializeField, Min(0)] private int atk = 10;
    [SerializeField, Min(0)] private int def = 10;
    [SerializeField, Min(0)] private int gold = 0;
    #endregion

    #region Keep track of attribute tags
    public readonly string hpTag = "Health";
    public readonly string atkTag = "Attack";
    public readonly string defTag = "Defense";
    public readonly string goldTag = "Gold";
    #endregion

    #region Properties of all attributes
    public int HP
    {
        get => (int)Data.GetAttributeValue(hpTag);
        set => Data.SetAttributeValue(hpTag, value);
    }
    public int ATK 
    {
        get => (int)Data.GetAttributeValue(atkTag);
        set => Data.SetAttributeValue(atkTag, value);
    }
    public int DEF
    {
        get => (int)Data.GetAttributeValue(defTag);
        set => Data.SetAttributeValue(defTag, value);
    }
    public int GOLD
    {
        get => (int)Data.GetAttributeValue(goldTag);
        set => Data.SetAttributeValue(goldTag, value);
    }
    #endregion

    #region Data Reference & Initialization
    private bool _isDataInitialized = false;
    private CharacterAttributeData _data;

    /// <summary>
    /// Class reference purpose only, for attribute get or set, use the following properties instead
    /// </summary>
    public CharacterAttributeData Data
    {
        get
        {
            if (!_isDataInitialized)
                InitializeData();

            return _data;
        }

        private set => _data = value;
    }

    protected virtual Dictionary<string, float> ExtraData { private get; set; }
    
    private void InitializeData() 
    {
        var data = new Dictionary<string, float>()
        {
            {hpTag, hp },
            {atkTag, atk },
            {defTag, def },
            {goldTag, gold }
        };

        if (ExtraData != null && ExtraData.Count > 0)
            data.AddRangeSafe(ExtraData);

        Data = new CharacterAttributeData(name, data);
        _isDataInitialized = true;
    }
    #endregion
}
