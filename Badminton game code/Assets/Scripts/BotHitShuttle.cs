using System;
using UnityEngine;
using TMPro;

public class BotHitShuttle : MonoBehaviour
{
    public Stats stats;
    public Trajectory trajectory;
    public Scoring scoring;
    public PlayerHitShuttle playerHitShuttle;
    public BotMovement botMovement;
    public ClearDetection clearDetection;
    public SmashDetection smashDetection;

    public TMP_Text countdownText;

    public GameObject bot;
    public GameObject botTarget;
    public GameObject shuttle;
    public GameObject countdownCanvas;

    public MeshRenderer botTargetRender;

    public Rigidbody shuttlecock;

    public string type = "";

    public bool botServing;
    public bool forehand = false;
    public bool backhand = false;

    private int randNum;

    private float vAngle;
    private float speed;
    private float timer;
    private float serveTimer;

    private bool smashGenerated = false;
    private bool netGenerated = false;
    private bool timerActive = false;

    private void Update()
    {
        if (scoring.roundActive && playerHitShuttle.playerTurn == false)
        {
            if (botServing)
            {
                serveTimer += Time.deltaTime;
                countdownCanvas.SetActive(true);
                countdownText.text = Convert.ToString(3 - Convert.ToInt16(serveTimer));
                shuttlecock.linearVelocity = Vector3.zero;
                shuttlecock.freezeRotation = true;
                Physics.gravity = Vector3.zero;

                if (serveTimer > 3)
                {
                    countdownCanvas.SetActive(false);
                    shuttle.transform.position = GameObject.Find("Badminton Shuttlecock").transform.position;

                    if (netGenerated == false)
                    {
                        randNum = UnityEngine.Random.Range(1, 100);
                        netGenerated = true;
                    }

                    if (stats.botNetChance >= randNum)
                    {
                        vAngle = 90 - (Mathf.Atan((8.5f - shuttle.transform.position[1]) / shuttle.transform.position[2]) * (180 / Mathf.PI));
                        type = "net";
                    }
                    else
                    {
                        vAngle = 50 - shuttle.transform.position[2];
                        type = "clear";
                    }

                    var shot = trajectory.CalcClearNet(shuttle.transform.position, botTarget.transform.position, vAngle, stats.gravitySet);
                    speed = shot.Item1;
                    shuttle.transform.eulerAngles = new Vector3(-vAngle, shot.Item2, 0);
                    timerActive = true;
                    serveTimer = 0;
                    botServing = false;
                }
            }
            else
            {
                if (smashDetection.smashDetect && type != "clear")
                {
                    if (smashGenerated == false)
                    {
                        randNum = UnityEngine.Random.Range(1, 100);
                        smashGenerated = true;
                    }

                    if (stats.botSmashChance >= randNum)
                    {
                        var angles = trajectory.CalcSmash(shuttle.transform.position, botTarget.transform.position, "smash", stats.botSmashSpeed, stats.gravitySet);
                        shuttle.transform.eulerAngles = new Vector3(-angles.Item2, angles.Item1, 0);
                        timerActive = true;
                        type = "smash";

                        if (shuttle.transform.position[0] - 1.5f < bot.transform.position[0])
                        {
                            forehand = true;
                        }
                        else
                        {
                            backhand = true;
                        }
                    }
                }

                if (clearDetection.clearDetect && type != "smash")
                {
                    if (netGenerated == false)
                    {
                        randNum = UnityEngine.Random.Range(1, 100);
                        netGenerated = true;
                    }

                    if (stats.botNetChance >= randNum)
                    {
                        if (shuttle.transform.position[1] > 8)
                        {
                            vAngle = 90;
                        }
                        else
                        {
                            vAngle = 90 - Mathf.Atan((8.5f - shuttle.transform.position[1]) / shuttle.transform.position[2]) * (180 / Mathf.PI);
                        }

                        type = "net";
                    }
                    else
                    {
                        vAngle = 50 - shuttle.transform.position[2];
                        type = "clear";
                    }

                    var shot = trajectory.CalcClearNet(shuttle.transform.position, botTarget.transform.position, vAngle, stats.gravitySet);
                    speed = shot.Item1;
                    shuttle.transform.eulerAngles = new Vector3(-vAngle, shot.Item2, 0);
                    timerActive = true;

                    if (shuttle.transform.position[0] - 1.5f < bot.transform.position[0])
                    {
                        forehand = true;
                    }
                    else
                    {
                        backhand = true;
                    }
                }
            }

            if (timerActive)
            {
                timer += Time.deltaTime;
                shuttlecock.linearVelocity = Vector3.zero;
                shuttlecock.freezeRotation = true;
                Physics.gravity = Vector3.zero;
            }

            if (timer > 0.1)
            {
                if (type == "smash")
                {
                    shuttlecock.AddRelativeForce(new Vector3(0, stats.botSmashSpeed, 0), ForceMode.VelocityChange);
                }
                else
                {
                    shuttlecock.AddRelativeForce(new Vector3(0, speed, 0), ForceMode.VelocityChange);
                }

                botMovement.playerTargetPosition = stats.receivePosition;
                shuttlecock.freezeRotation = false;
                botTargetRender.enabled = true;
                playerHitShuttle.playerTurn = true;
                netGenerated = false;
                smashGenerated = false;
                timerActive = false;
                botMovement.moving = true;
                Physics.gravity = new Vector3(0, stats.gravitySet, 0);
                shuttle.transform.eulerAngles = Vector3.zero;
                type = "";
                timer = 0;
                forehand = false;
                backhand = false;
            }
        }
    }
}