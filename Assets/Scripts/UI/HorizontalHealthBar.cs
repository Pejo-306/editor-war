using UnityEngine;

public class HorizontalHealthBar : MonoBehaviour 
{
    public GameObject displayedObject;
    public int maxHealth;
    public float maxWidth;

    private RectTransform healthBarTransform;
    private EntityHealth healthComponent;

    void Awake()
    {
        healthBarTransform = GetComponent<RectTransform>();
        healthComponent = displayedObject.GetComponent<EntityHealth>();
    }

    void Update()
    {
        float width = ((float)healthComponent.health / maxHealth) * maxWidth;
        float height = healthBarTransform.sizeDelta.y;

        healthBarTransform.sizeDelta = new Vector2(width, height);
    }
}

