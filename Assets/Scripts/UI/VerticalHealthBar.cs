using UnityEngine;

public class VerticalHealthBar : MonoBehaviour
{
    public GameObject displayedObject;
    public int maxHealth;
    public float maxHeight;

    private RectTransform healthBarTransform;
    private EntityHealth healthComponent;

    void Awake()
    {
        healthBarTransform = GetComponent<RectTransform>();
        healthComponent = displayedObject.GetComponent<EntityHealth>();
    }

    void Update()
    {
        float width = healthBarTransform.sizeDelta.x;
        float height = ((float)healthComponent.health / maxHealth) * maxHeight;

        healthBarTransform.sizeDelta = new Vector2(width, height);
    }
}

