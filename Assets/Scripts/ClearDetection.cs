using UnityEngine;

public class ClearDetection : MonoBehaviour
{
    public bool clearDetect = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Badminton Shuttlecock")
        {
            clearDetect = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name == "Badminton Shuttlecock")
        {
            clearDetect = false;
        }
    }
}