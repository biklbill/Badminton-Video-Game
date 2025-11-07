using UnityEngine;

public class SmashDetection : MonoBehaviour
{
    public bool smashDetect = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Badminton Shuttlecock")
        {
            smashDetect = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name == "Badminton Shuttlecock")
        {
            smashDetect = false;
        }
    }
}