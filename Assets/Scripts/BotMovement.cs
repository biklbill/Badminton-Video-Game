using UnityEngine;

public class BotMovement : MonoBehaviour
{
    public Stats stats;
    public Scoring scoring;

    public GameObject bot;

    public Vector3 playerTargetPosition;

    public int directionX;
    public int directionY;

    public bool moving;

    private bool receiving = false;

    private void Update()
    {
        if (scoring.roundActive && moving)
        {
            if (playerTargetPosition == stats.receivePosition)
            {
                bot.transform.position = Vector3.MoveTowards(bot.transform.position, playerTargetPosition, stats.botSpeed * Time.deltaTime);
                receiving = true;
            }
            else
            {
                if (Vector3.Distance(playerTargetPosition, bot.transform.position) > stats.botStopDistance)
                {
                    bot.transform.position = Vector3.MoveTowards(bot.transform.position, playerTargetPosition, stats.botSpeed * Time.deltaTime);
                }
                else
                {
                    moving = false;
                }
            }

            if (receiving)
            {
                if (bot.transform.position == stats.receivePosition)
                {
                    receiving = false;
                    moving = false;
                }
            }

            if (moving)
            {
                if (playerTargetPosition[0] - bot.transform.position[0] > 0)
                {
                    directionX = -1;
                }
                else
                {
                    directionX = 1;
                }

                if (playerTargetPosition[2] - bot.transform.position[2] > 0)
                {
                    directionY = -1;
                }
                else
                {
                    directionY = 1;
                }
            }
            else
            {
                directionX = 0;
                directionY = 0;
            }
        }
    }
}