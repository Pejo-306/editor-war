using UnityEngine;

public class SpriteFlasher : MonoBehaviour 
{
    public float flashTime = 0.1f;
    private SpriteRenderer spriteRenderer;
    private bool isFlashing;

	void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();	
        isFlashing = false;
	}

    public void StartFlashing()
    {
        isFlashing = true;
        ConcealSprite();
    }

    public void StopFlashing()
    {
        isFlashing = false;
        RevealSprite();
    }

    private void ConcealSprite()
    {
        if (isFlashing)
        {
            spriteRenderer.enabled = false;  // hide sprite
            Invoke("RevealSprite", flashTime);
        }
    }

    private void RevealSprite()
    {
        spriteRenderer.enabled = true;  // render sprite
        if (isFlashing)
        {
            Invoke("ConcealSprite", flashTime);
        }
    }
}

