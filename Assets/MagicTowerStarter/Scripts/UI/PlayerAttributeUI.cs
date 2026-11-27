using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class PlayerAttributeUI : MonoBehaviour
{
    [SerializeField] private MotaAttributeType attributeType;

    private CharacterAttributes _playerAttributes;
    private string _attributeName;
    private float _attributeValue;

    private TMP_Text _text;

    private void SetUI(string name, float value) => _text.SetText($"{name}: {value}");

    private void Awake() 
    {
        _text = GetComponent<TMP_Text>();
        _playerAttributes = FindAnyObjectByType<MotaPlayer>().Attributes;
        
        if (!_playerAttributes)
        {
            Debug.LogError("The player's attributes SO is not defined");
            return;
        }

        _attributeName = _playerAttributes.AttributeTypeToName(attributeType);
    }

    private void Update() 
    {
        if (!_playerAttributes || _attributeName == null) return;

        float attribute = _playerAttributes.Data.GetAttributeValue(_attributeName, out bool found);

        if (_attributeValue == attribute) return;

        if (!found) 
        {
            Debug.LogError($"The attribute {_attributeName} is not found", this);
            return;
        }

        _attributeValue = attribute;
        SetUI(_attributeName, _attributeValue);
    }
}
