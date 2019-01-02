using System.Collections.Generic;
using UnityEngine;

public class ViBossMovement : MonoBehaviour
{
    public class Movement 
    {
        public enum Motion : byte { Left, Down, Up, Right };

        private static Dictionary<Motion, Vector3> motionOffsets = new Dictionary<Motion, Vector3>() 
        {
            { Motion.Left, new Vector3(-1, 0, 0) },
            { Motion.Down, new Vector3(0, -1, 0) },
            { Motion.Up, new Vector3(0, 1, 0) },
            { Motion.Right, new Vector3(1, 0, 0) }
        };

        public Motion motion;
        public int count;

        public Movement(int minCount, int maxCount)
        {
            motion = PickRandomMotion();
            count = Random.Range(minCount, maxCount + 1);
        }

        public void Execute(Transform objectTransform, float motionUnit)
        {
            objectTransform.position += motionOffsets[motion] * motionUnit * count;
        }

        public void ExecuteOpposite(Transform objectTransform, float motionUnit)
        {
            objectTransform.position -= motionOffsets[motion] * motionUnit * count;
        }

        public static Motion PickRandomMotion()
        {
            System.Random random = new System.Random();
            System.Array values = System.Enum.GetValues(typeof(Motion));
            Motion randomMotion = (Motion)values.GetValue(random.Next(values.Length));

            return randomMotion;
        }
    }

    public ViBossMovementTester movementTester;
    public float movementRate = 2f;
    public float motionUnit = 0.5f;
    public int minMotionCount = 1;
    public int maxMotionCount = 3;
    public Movement nextMovement;
    private float movementPeriod;
    private bool isInMotion;

    void Start()
    {
        movementPeriod = 1 / movementRate;
        isInMotion = false;
    }

    void Update()
    {
        float movementDelayTime;

        if (!isInMotion)
        {
            movementDelayTime = Random.Range(0f, movementPeriod);
            Invoke("Move", movementDelayTime);
            isInMotion = true;
            Invoke("ResetMotion", movementPeriod);
        }
    }

    private void Move()
    {
        if (nextMovement != null)
        {
            nextMovement.Execute(transform, motionUnit);
        }
        nextMovement = new Movement(minMotionCount, maxMotionCount);
        movementTester.ApplyMovement();
    }

    private void ResetMotion()
    {
        isInMotion = false;
    }
}

