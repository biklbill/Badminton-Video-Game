using System;
using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour
{
    public Stats stats;
    public PlayerHitShuttle playerHitShuttle;
    public BotMovement botMovement;

    public TMP_Text playerScoreText;
    public TMP_Text botScoreText;
    public TMP_Text resultText;

    public GameObject nextRoundCanvas;

    public Rigidbody shuttlecock;

    public bool roundActive = true;

    private Vector3 collisionPoint;

    public int playerScore = 0;
    public int botScore = 0;

    private float side;
    private float back;

    private void Start()
    {
        side = 12;
        back = 26;
    }

    private void OnCollisionEnter(Collision collision)
    {
        collisionPoint = collision.GetContact(0).point;

        if (collision.gameObject.name != "Net")
        {
            if (roundActive)
            {
                if (playerHitShuttle.playerServing == false)
                {
                    if (playerHitShuttle.playerTurn)
                    {
                        if (collisionPoint[0] >= -side && collisionPoint[0] <= side && collisionPoint[2] >= -back && collisionPoint[2] <= 0)
                        {
                            botScore += 1;
                            botScoreText.text = Convert.ToString(botScore);
                            resultText.text = "Bot Won";
                            stats.winner = "bot";
                            roundActive = false;
                        }
                        else
                        {
                            playerScore += 1;
                            playerScoreText.text = Convert.ToString(playerScore);
                            resultText.text = "Player Won";
                            stats.winner = "player";
                            roundActive = false;
                        }
                    }
                    else
                    {
                        if (collisionPoint[0] >= -side && collisionPoint[0] <= side && collisionPoint[2] <= back && collisionPoint[2] >= 0)
                        {
                            playerScore += 1;
                            playerScoreText.text = Convert.ToString(playerScore);
                            resultText.text = "Player Won";
                            stats.winner = "player";
                            roundActive = false;
                        }
                        else
                        {
                            botScore += 1;
                            botScoreText.text = Convert.ToString(botScore);
                            resultText.text = "Bot Won";
                            stats.winner = "bot";
                            roundActive = false;
                        }
                    }


                    shuttlecock.linearVelocity = Vector3.zero;
                    botMovement.moving = false;
                    nextRoundCanvas.SetActive(true);
                    playerHitShuttle.forehand = false;
                    playerHitShuttle.backhand = false;
                }
            }
        }  
    }
}