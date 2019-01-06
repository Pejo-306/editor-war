using System.Collections.Generic;
using UnityEngine;

public class ViBehaviorPatterns : MonoBehaviour
{
    public ViBossMovement viMovementComponent;
    public GameObject viBasicDamageProjectileShooter;
    public GameObject viMotionProjectileShooter;
    public GameObject viLineDamageProjectileShooter;
    public float minCooldownTime = 5f;
    public float maxCooldownTime = 15f;

    private float nextPatternTime;
    private delegate void BehaviorPattern();

    private List<BehaviorPattern> behaviorPatterns = new List<BehaviorPattern>();

    void Awake()
    {
        behaviorPatterns.Add(DamageAndMotionProjectilesBarrage);
        behaviorPatterns.Add(LineDamageProjectilesBarrage);
        behaviorPatterns.Add(FastDamageProjectilesBarrage); 
        behaviorPatterns.Add(MotionAndLineDamageProjectilesBarrage);
    }

    void Update()
    {
        int chosenPattern;

        if (Time.time > nextPatternTime)
        {
            ResetAfterPattern();
            chosenPattern = Random.Range(0, behaviorPatterns.Count);
            behaviorPatterns[chosenPattern]();
            nextPatternTime = Time.time + Random.Range(minCooldownTime, maxCooldownTime);
        }
    }

    private void DamageAndMotionProjectilesBarrage()
    {
        // movement
        viMovementComponent.enabled = true;
        viMovementComponent.movementRate = 6;
        
        // basic damage projectiles
        viBasicDamageProjectileShooter.SetActive(true);
        viBasicDamageProjectileShooter.GetComponent<Weapon>().shotsPerSecond = 4;

        // motion projectiles
        viMotionProjectileShooter.SetActive(true);
        viMotionProjectileShooter.GetComponent<Weapon>().shotsPerSecond = 8;
    }

    private void LineDamageProjectilesBarrage()
    {
        // movement
        viMovementComponent.enabled = true;
        viMovementComponent.movementRate = 12;

        // line damage projectiles
        viLineDamageProjectileShooter.SetActive(true);
    }

    private void MotionAndLineDamageProjectilesBarrage()
    {
        // motion projectiles
        viMotionProjectileShooter.SetActive(true);
        viMotionProjectileShooter.GetComponent<Weapon>().shotsPerSecond = 24;

        // line damage projectiles
        viLineDamageProjectileShooter.SetActive(true);
    }

    private void FastDamageProjectilesBarrage()
    {
        // basic damage projectiles
        viBasicDamageProjectileShooter.SetActive(true);
        viBasicDamageProjectileShooter.GetComponent<Weapon>().shotsPerSecond = 24;
    }

    private void ResetAfterPattern()
    {
        viMovementComponent.enabled = false;
        viBasicDamageProjectileShooter.SetActive(false);
        viMotionProjectileShooter.SetActive(false);
        viLineDamageProjectileShooter.SetActive(false);
    }
}

