using UnityEngine;
namespace Utils.InputUtils {
    public enum InputAxes {
        Horizontal
    }
    public static class InputUtils {
        public static bool GoingRight() {
            var horizontalAxis = Input.GetAxisRaw(InputAxes.Horizontal.ToString());
            return horizontalAxis > 0 || TouchingRight();
        }

        public static bool GoingLeft() {
            var horizontalAxis = Input.GetAxisRaw(InputAxes.Horizontal.ToString());
            return horizontalAxis < 0 || TouchingLeft();
        }

        public static bool MovingHorizontaly() {
            return InputUtils.GoingRight() || InputUtils.GoingLeft();
        }

        public static bool TouchingLeft() {
            if(!Touching()) return false;
            var touch = Input.GetTouch(0);
            return touch.position.x < Screen.width / 2;
        }
        public static bool TouchingRight() {
            if(!Touching()) return false;
            var touch = Input.GetTouch(0);
            return touch.position.x > Screen.width / 2;
        }

        public static bool Touching() {
            return Input.touchCount > 0;
        }
    }
}