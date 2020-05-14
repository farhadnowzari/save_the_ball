using UnityEngine;
namespace Utils.MovementUtils {
    public static class MovementUtils {
        public static bool IsObjectFalling(GameObject target) {
            var rigidBody = target.GetComponent<Rigidbody2D>();
            if(rigidBody == null) return false;
            return rigidBody.velocity.y < -0.1;
        }
    }
}