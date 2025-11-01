using UnityEngine;

public class AnimationDetection : MonoBehaviour
{
    public bool animationDetect = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Badminton Shuttlecock")
        {
            animationDetect = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name == "Badminton Shuttlecock")
        {
            animationDetect = false;
        }
    }
}