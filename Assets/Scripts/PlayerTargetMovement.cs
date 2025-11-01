using UnityEngine;

public class PlayerTargetMovement : MonoBehaviour
{
    public Stats stats;
    public PlayerHitShuttle playerHitShuttle;
    public Scoring scoring;

    public MeshRenderer playerTargetMesh;

    public LineRenderer playerClearRange;
    public LineRenderer playerNetRange;
    public LineRenderer playerSmashRange;
    public LineRenderer playerEvenServeRange;
    public LineRenderer playerOddServeRange;

    private void Update()
    {
        if (playerHitShuttle.playerServing)
        {
            if (scoring.playerScore % 2 == 0)
            {
                if (playerEvenServeRange.enabled == false)
                {
                    transform.position = new Vector3(-2, 0.1f, 10);
                }
                playerEvenServeRange.enabled = true;   
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, -12, 0), 0.1f, Mathf.Clamp(transform.position.z, 8, 26));
            }
            else
            {
                if (playerOddServeRange.enabled == false)
                {
                    transform.position = new Vector3(2, 0.1f, 10);
                }
                playerOddServeRange.enabled = true;
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0, 12), 0.1f, Mathf.Clamp(transform.position.z, 8, 26));
            }

            playerTargetMesh.enabled = true;
        }
        else
        {
            if (playerEvenServeRange.enabled || playerOddServeRange.enabled)
            {
                playerEvenServeRange.enabled = false;
                playerOddServeRange.enabled = false;
                playerTargetMesh.enabled = false;
            }

            if (Input.GetButtonDown("Fire1"))
            {
                if (playerClearRange.enabled)
                {
                    playerClearRange.enabled = false;
                    playerTargetMesh.enabled = false;
                }
                else
                {
                    transform.position = new Vector3(0, 0.1f, 23);
                    playerClearRange.enabled = true;
                    playerNetRange.enabled = false;
                    playerSmashRange.enabled = false;
                    playerTargetMesh.enabled = true;
                }
            }

            if (Input.GetButtonDown("Fire2"))
            {
                if (playerNetRange.enabled)
                {
                    playerNetRange.enabled = false;
                    playerTargetMesh.enabled = false;
                }
                else
                {
                    transform.position = new Vector3(0, 0.1f, 7);
                    playerClearRange.enabled = false;
                    playerNetRange.enabled = true;
                    playerSmashRange.enabled = false;
                    playerTargetMesh.enabled = true;
                }
            }      

            if (Input.GetButtonDown("Fire3"))
            {
                if (playerSmashRange.enabled)
                {
                    playerSmashRange.enabled = false;
                    playerTargetMesh.enabled = false;
                }
                else
                {
                    transform.position = new Vector3(0, 0.1f, 16);
                    playerClearRange.enabled = false;
                    playerNetRange.enabled = false;
                    playerSmashRange.enabled = true;
                    playerTargetMesh.enabled = true;
                }
            }
            
            if (playerClearRange.enabled)
            {
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, -12, 12), 0.1f, Mathf.Clamp(transform.position.z, 20, 26));
            }

            if (playerNetRange.enabled)
            {
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, -12, 12), 0.1f, Mathf.Clamp(transform.position.z, 2, 12));
            }

            if (playerSmashRange.enabled)
            {
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, -12, 12), 0.1f, Mathf.Clamp(transform.position.z, 6, 26));
            }
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * stats.playerTargetSpeed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * Time.deltaTime * stats.playerTargetSpeed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * stats.playerTargetSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * stats.playerTargetSpeed);
        }
    }
}