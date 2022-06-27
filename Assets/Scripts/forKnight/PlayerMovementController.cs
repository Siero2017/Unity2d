using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public static class Params
    {
        public const string Speed = "Speed";
        public const string Jump = "Jump";
    }

    public static class States
    {
        public const float Walk = 1f;
        public const float Idle = 0f;
        public const bool InTheAir = true;
        public const bool OnTheGround = false;
    }
}
