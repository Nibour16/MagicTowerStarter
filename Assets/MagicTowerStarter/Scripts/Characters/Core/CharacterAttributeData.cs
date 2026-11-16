using System.Collections.Generic;
using UnityEngine;

namespace UnityMotaStarter.Characters 
{
    public class CharacterAttributeData
    {
        private readonly Dictionary<string, float> _attributes = new();

        public CharacterAttributeData(Dictionary<string, float> attributes)
        {
            if (attributes == null) 
            {
                Debug.LogError("Input attributes array is not assigned");
                return;
            }
            
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
    }
}