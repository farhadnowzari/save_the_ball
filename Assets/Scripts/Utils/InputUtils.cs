using UnityEngine;
namespace Utils.InputUtils {
    public enum InputAxes {
        Horizontal
    }
    public static class InputUtils {
        public static bool GoingRight() {
            var horizontalAxis = Input.GetAxisRaw(InputAxes.Horizontal.ToString());
            return horizontalAxis > 0;
        }

        public static bool GoingLeft() {
            var horizontalAxis = Input.GetAxisRaw(InputAxes.Horizontal.ToString());
            return horizontalAxis < 0;
        }

        public static bool MovingHorizontaly() {
            return InputUtils.GoingRight() || InputUtils.GoingLeft();
        }
    }
}