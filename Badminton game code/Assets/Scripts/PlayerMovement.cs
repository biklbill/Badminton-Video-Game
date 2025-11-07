using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Stats stats;
    public Scoring scoring;
    public PlayerHitShuttle playerHitShuttle;

    public GameObject player;
    public GameObject shuttle;

    public Rigidbody shuttlecock;

    private void Update()
    {
        if (scoring.roundActive)
        {
            if (playerHitShuttle.playerServing)
            {
                shuttlecock.linearVelocity = Vector3.zero;
                if (Input.GetKey(KeyCode.W))
                {
                    player.transform.Translate(Vector3.forward * Time.deltaTime * stats.playerSpeed);
                    shuttle.transform.Translate(Vector3.forward * Time.deltaTime * stats.playerSpeed);
                    shuttle.transform.eulerAngles = Vector3.zero;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    player.transform.Translate(Vector3.back * Time.deltaTime * stats.playerSpeed);
                    shuttle.transform.Translate(Vector3.back * Time.deltaTime * stats.playerSpeed);
                    shuttle.transform.eulerAngles = Vector3.zero;
                }
                if (Input.GetKey(KeyCode.A))
                {
                    player.transform.Translate(Vector3.left * Time.deltaTime * stats.playerSpeed);
                    shuttle.transform.Translate(Vector3.left * Time.deltaTime * stats.playerSpeed);
                    shuttle.transform.eulerAngles = Vector3.zero;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    player.transform.Translate(Vector3.right * Time.deltaTime * stats.playerSpeed);
                    shuttle.transform.Translate(Vector3.right * Time.deltaTime * stats.playerSpeed);
                    shuttle.transform.eulerAngles = Vector3.zero;
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.W))
                {
                    player.transform.Translate(Vector3.forward * Time.deltaTime * stats.playerSpeed);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    player.transform.Translate(Vector3.back * Time.deltaTime * stats.playerSpeed);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    player.transform.Translate(Vector3.left * Time.deltaTime * stats.playerSpeed);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    player.transform.Translate(Vector3.right * Time.deltaTime * stats.playerSpeed);
                }
            }
        }
    }
}