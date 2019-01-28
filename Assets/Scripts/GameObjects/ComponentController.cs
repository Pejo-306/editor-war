using UnityEngine;

public class ComponentController : MonoBehaviour
{
    [System.Serializable]
    public class ComponentGroup
    {
        public string groupName;
        
        public MonoBehaviour[] components;
    }

    public ComponentGroup[] componentGroups;

    public void EnableComponents(string groupName)
    {
        var componentGroup = GetComponentGroup(groupName);

        foreach (var component in componentGroup.components)
        {
            component.enabled = true;
        }
    }

    public void DisableComponents(string groupName)
    {
        var componentGroup = GetComponentGroup(groupName);

        foreach (var component in componentGroup.components)
        {
            component.enabled = false;
        }
    }

    private ComponentGroup GetComponentGroup(string groupName)
    {
        foreach (var componentGroup in componentGroups)
        {
            if (componentGroup.groupName == groupName)
            {
                return componentGroup;
            }
        }
        return null;
    }
}

