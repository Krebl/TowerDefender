using UnityEngine;

namespace Utils
{
    public static class ClampUtils
    {
        public static Vector3 ClampVector(Vector3 currentPosition, Vector3 minPosition, Vector3 maxPosition)
        {
            float x = Clamp(currentPosition.x, minPosition.x, maxPosition.x);
            float y = Clamp(currentPosition.y, minPosition.y, maxPosition.y);
            float z = Clamp(currentPosition.z, minPosition.z, maxPosition.z);
            
            return new Vector3(x, y, z);
        }

        public static float Clamp(float currentValue, float min, float max)
        {
            if (min < max)
            {
                return Mathf.Clamp(currentValue, min, max);
            }
            else
            {
                return Mathf.Clamp(currentValue, max, min);
            }
        }
    }
}

