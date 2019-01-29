using System.Collections.Generic;
using UnityEngine;

/*
 * Describes the movement patterns of Vi.
 *
 * The way Vi moves is by applying motion commands which consist of a direction
 * and a count that multiplies the effect of the movement. These motion
 * commands are generated randomly. The commands' behaviour is packaged in 
 * an inner class. Moreover, they may also be applied to any game object and 
 * therefore may be used in outside scripts.
 *
 * As to how Vi is kept inside the camera's view, the boss has a light copy
 * of itself called 'ViMovementTester'. The latter is an invisible object with
 * the same dimensions as Vi. The movement tester interacts only with invisible
 * walls. The copy executes the generated motion command before Vi and
 * checks whether it has collided with the invisible encompasing field. If yes,
 * the motion command is reverted which leads to the boss standing still for 
 * a moment.
 */
public class ViMovement : MonoBehaviour
{
    /*
     * A Vi movement command.
     *
     * A movement command is described as having a 'motion' and a 'count'. 
     * The former is the direction of the movement, whilst the latter is an
     * integer which multiplies the effect of the command.
     */
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

        /*
         * Apply the effects of the movement comand.
         */
        public void Execute(Transform objectTransform, float motionUnit)
        {
            objectTransform.position += motionOffsets[motion] * motionUnit * count;
        }

        /*
         * Apply the opposite effects of the movement comand.
         */
        public void ExecuteOpposite(Transform objectTransform, float motionUnit)
        {
            objectTransform.position -= motionOffsets[motion] * motionUnit * count;
        }

        public override string ToString()
        {
            return string.Format("{0}{1}", count, GetMotionAsString(motion));
        }

        /*
         * Pick a random motion.
         */
        public static Motion PickRandomMotion()
        {
            System.Random random = new System.Random();
            System.Array values = System.Enum.GetValues(typeof(Motion));
            Motion randomMotion = (Motion)values.GetValue(random.Next(values.Length));

            return randomMotion;
        }

        /*
         * Return a letter, representing the motion of the command.
         */
        public static string GetMotionAsString(Motion motion)
        {
            switch (motion)
            {
                case Motion.Left:
                    return "h";
                case Motion.Down:
                    return "j";
                case Motion.Up:
                    return "k";
                case Motion.Right:
                    return "l";
            }
            return null;
        }
    }

    // The movement tester - light copy of Vi.
    public ViMovementTester movementTester;

    // The number of movement commands per second.
    public float movementRate = 6f;

    // The Unity engine units that are traversed in a movement command 
    // (with count = 1).
    public float motionUnit = 0.5f;

    // Minimum count that may be chosen at random.
    public int minMotionCount = 1;

    // Maximum count that may be chosen at random.
    public int maxMotionCount = 3;

    // The movement to be executed on the next update cycle. Used by the
    // movement tester to test the movement preemptively.
    [HideInInspector]
    public Movement nextMovement;

    // The period of time in which one movement command is executed.
    private float movementPeriod;

    // Indicates whether another movement command may be generated.
    private bool isInMotion;

    void Start()
    {
        movementPeriod = 1 / movementRate;
        isInMotion = false;
    }

    /*
     * Move Vi via a movement command.
     *
     * A command may only be generated if the boss is currently not in motion.
     * The command itself is generated and applied at a random point in time 
     * within the movement period.
     */
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

    /*
     * Generate and apply a movement command.
     *
     * The new movement command is preemptively applied to the movement tester.
     * If the latter collides with the hidden collision field, the movement
     * command is reset and then deleted, resulting in Vi standing still until
     * the next generated command.
     */
    private void Move()
    {
        if (nextMovement != null)
        {
            nextMovement.Execute(transform, motionUnit);
        }
        nextMovement = new Movement(minMotionCount, maxMotionCount);
        movementTester.ApplyMovement();
    }

    /*
     * Allow another movement command to be generated.
     */
    private void ResetMotion()
    {
        isInMotion = false;
    }
}

