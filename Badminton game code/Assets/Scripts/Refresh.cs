using UnityEngine;

public class Refresh : MonoBehaviour
{
    public Stats stats;
    public Scoring scoring;
    public BotMovement botMovement;
    public BotTargetMovement botTargetMovement;
    public PlayerHitShuttle playerHitShuttle;
    public BotHitShuttle botHitShuttle;

    public GameObject nextRoundCanvas;
    public GameObject player;
    public GameObject playerTarget;
    public GameObject bot;
    public GameObject shuttle;

    public MeshRenderer playerTargetRenderer;
    public MeshRenderer botTargetRenderer;


    public LineRenderer playerClearRange;
    public LineRenderer playerNetRange;
    public LineRenderer playerSmashRange;

    public Rigidbody shuttlecock;

    public void Serve()
    {
        nextRoundCanvas.SetActive(false);
        scoring.roundActive = true;

        if (stats.winner == "player")
        {
            if (scoring.playerScore % 2 == 0)
            {
                player.transform.position = new Vector3(2, 0, -10);
                playerTarget.transform.position = new Vector3(-1, 0, 8);
                bot.transform.position = new Vector3(-2, 0, 10);
                shuttle.transform.position = new Vector3(1.25f, 4.5f, -7.5f);
            }
            else
            {
                player.transform.position = new Vector3(-2, 0, -10);
                playerTarget.transform.position = new Vector3(1, 0, 8);
                bot.transform.position = new Vector3(2, 0, 10);
                shuttle.transform.position = new Vector3(-1.25f, 4.5f, -7.5f);
            }

            playerHitShuttle.playerTurn = true;
            playerHitShuttle.playerServing = true;
        }
        else
        {
            if (scoring.botScore % 2 == 0)
            {
                player.transform.position = new Vector3(2, 0, -10);
                bot.transform.position = new Vector3(-2, 0, 10);
                shuttle.transform.position = new Vector3(-1.25f, 4.5f, 7.5f);
            }
            else
            {
                player.transform.position = new Vector3(-2, 0, -10);
                bot.transform.position = new Vector3(2, 0, 10);
                shuttle.transform.position = new Vector3(1.25f, 4.5f, 7.5f);
            }

            playerHitShuttle.playerTurn = false;
            playerTargetRenderer.enabled = false;
            botHitShuttle.botServing = true;

        }

        shuttle.transform.eulerAngles = Vector3.zero;

        playerClearRange.enabled = false;
        playerNetRange.enabled = false;
        playerSmashRange.enabled = false;

        playerHitShuttle.smashDetection.smashDetect = false;
        botHitShuttle.smashDetection.smashDetect = false;

        playerHitShuttle.type = "";
        botHitShuttle.type = "";

        botTargetRenderer.enabled = false;
        botMovement.moving = false;
        botTargetMovement.aim = true;
        
        shuttlecock.linearVelocity = Vector3.zero;
        Physics.gravity = Vector3.zero;
    }
}