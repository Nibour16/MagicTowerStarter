using System.Collections.Generic;
using UnityEngine;

public class CharacterAttributeData
{
    public readonly string characterName;
    private readonly Dictionary<string, float> _attributes = new();

    public CharacterAttributeData(string attributeName, Dictionary<string, float> attributes)
    {
        if (attributes == null) 
        {
            Debug.LogError("Input attributes array is not assigned");
            return;
        }

        characterName = attributeName;

        foreach (var attribute in attributes) 
        {
            if (!_attributes.TryAdd(attribute.Key, attribute.Value))
                Debug.LogWarning("Duplicated attribute detected");
        }
    }

    public float GetAttributeValue(string name, out bool isFound) 
    {
        isFound = _attributes.TryGetValue(name, out var value);
        return isFound? value : 0;
    }

    public float GetAttributeValue(string name) => GetAttributeValue(name, out _);

    public bool SetAttributeValue(string name, float value) 
    {
        if (!_attributes.ContainsKey(name)) return false;

        _attributes[name] = value;
        return true;
    }   
}