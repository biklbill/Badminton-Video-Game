using UnityEngine;

public class Trajectory : MonoBehaviour
{
    public (float, float) CalcSmash(Vector3 contactPosition, Vector3 targetPosition, string type, float speed, float gravitySet)
    {
        float hDistance = Vector3.Distance(targetPosition, new Vector3(contactPosition[0], 0, contactPosition[2]));
        float vDistance = -contactPosition[1];

        float quadA = -gravitySet * Mathf.Pow(hDistance, 2);
        float quadB = -2 * Mathf.Pow(speed, 2) * hDistance;
        float quadC = -gravitySet * Mathf.Pow(hDistance, 2) + 2 * vDistance * Mathf.Pow(speed, 2);

        float vTan = (-quadB - Mathf.Sqrt(Mathf.Pow(quadB, 2) - 4 * quadA * quadC)) / (2 * quadA);
        float hAngle = Mathf.Atan((targetPosition[0] - contactPosition[0]) / (targetPosition[2] - contactPosition[2])) * (180 / Mathf.PI);
        float vAngle = 90 - Mathf.Atan(vTan) * (180 / Mathf.PI);

        return (hAngle, vAngle);
    }

    public (float, float) CalcClearNet(Vector3 contactPosition, Vector3 targetPosition, float angle, float gravitySet)
    {
        float hDistance = Vector3.Distance(new Vector3(targetPosition[0], 0, targetPosition[2]), new Vector3(contactPosition[0], 0, contactPosition[2]));
        float vDistance = contactPosition[1] - 0.2534f;
        float radAngle = (90 - angle) * (Mathf.PI / 180);

        float speed = hDistance * Mathf.Sqrt(-gravitySet / (2 * hDistance * Mathf.Sin(radAngle) * Mathf.Cos(radAngle) + 2 * vDistance * Mathf.Pow(Mathf.Cos(radAngle), 2)));

        float hAngle = Mathf.Atan((targetPosition[0] - contactPosition[0]) / (targetPosition[2] - contactPosition[2])) * (180 / Mathf.PI);

        return (speed, hAngle);
    }
}