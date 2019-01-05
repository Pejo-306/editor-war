using UnityEngine;

public class ViMotionProjectile : MonoBehaviour
{
    public string tagToHit;

    private ViBossMovement.Movement movement;
    private float motionUnit;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tagToHit))
        {
            Destroy(gameObject);
            movement.Execute(collision.gameObject.transform, motionUnit);
        }
    }

    public void InstantiateMovement(int minCount, int maxCount, float motionUnit)
    {
        string motionSpritePath = ProjectPaths.viSpritesRPath + "Projectiles/";
        Sprite motionSprite;

        this.motionUnit = motionUnit;
        movement = new ViBossMovement.Movement(minCount, maxCount);

        motionSpritePath += string.Format("Vi_motion_projectile_{0}", movement.ToString());
        motionSpritePath = ProjectPaths.EscapePath(motionSpritePath);
        motionSprite = Resources.Load<Sprite>(motionSpritePath);
        GetComponent<SpriteRenderer>().sprite = motionSprite;
    }
}

