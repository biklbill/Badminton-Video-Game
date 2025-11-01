using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerHitShuttle : MonoBehaviour
{
    public Stats stats;
    public Trajectory trajectory;
    public Scoring scoring;
    public BotMovement botMovement;
    public BotTargetMovement botTargetMovement;
    public ClearDetection clearDetection;
    public SmashDetection smashDetection;
    public AnimationDetection animationDetection;
    public Refresh refresh;

    public GameObject player;
    public GameObject playerTarget;
    public GameObject shuttle;

    public MeshRenderer botTargetRender;

    public Rigidbody shuttlecock;

    public Rig racketRig;

    public bool playerTurn = true;
    public bool playerServing = true;
    public bool forehand = false;
    public bool backhand = false;

    public string type = "";

    private float vAngle;
    private float speed;
    private float timer;

    private bool timerActive = false;

    private void Start()
    {
        refresh.Serve();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (type == "clear")
            {
                type = "";
            }
            else
            {
                type = "clear";
            }
        }

        if (Input.GetButtonDown("Fire2"))
        {
            if (type == "net")
            {
                type = "";
            }
            else
            {
                type = "net";
            }
        }

        if (Input.GetButtonDown("Fire3"))
        {
            if (type == "smash")
            {
                type = "";
            }
            else
            {
                type = "smash";
            }
        }

        if (scoring.roundActive && playerTurn && timerActive == false)
        {
            if (animationDetection.animationDetect)
            {
                if (type != "")
                {
                    if (shuttle.transform.position[0] + 1.5f > player.transform.position[0])
                    {
                        forehand = true;
                    }
                    else
                    {
                        backhand = true;
                    }

                    if (animationDetection.animationDetect)
                    {
                        racketRig.weight += Time.deltaTime * 0.25f;
                    }
                }
            }
            else
            {
                racketRig.weight = 0;
            }

            if (clearDetection.clearDetect)
            {
                if (type == "clear")
                {
                    vAngle = 50 + shuttle.transform.position[2];
                }

                if (type == "net")
                {
                    if (shuttle.transform.position[1] > 8)
                    {
                        vAngle = 90;
                    }
                    else
                    {
                        vAngle = 90 - Mathf.Atan((8.5f - shuttle.transform.position[1]) / -shuttle.transform.position[2]) * (180 / Mathf.PI);
                    }
                }

                if (type == "clear" || type == "net")
                {
                    var shot = trajectory.CalcClearNet(shuttle.transform.position, playerTarget.transform.position, vAngle, stats.gravitySet);
                    speed = shot.Item1;
                    shuttle.transform.eulerAngles = new Vector3(vAngle, shot.Item2, 0);
                    timerActive = true;
                }
            }

            if (type == "smash" && smashDetection.smashDetect)
            {
                var angles = trajectory.CalcSmash(shuttle.transform.position, playerTarget.transform.position, "smash", stats.playerSmashSpeed, stats.gravitySet);
                shuttle.transform.eulerAngles = new Vector3(angles.Item2, angles.Item1, 0);
                timerActive = true;
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
                shuttlecock.AddRelativeForce(new Vector3(0, stats.playerSmashSpeed, 0), ForceMode.VelocityChange);
            }
            else
            {
                shuttlecock.AddRelativeForce(new Vector3(0, speed, 0), ForceMode.VelocityChange);
            }

            botMovement.playerTargetPosition = playerTarget.transform.position;
            botTargetMovement.aim = true;
            shuttlecock.freezeRotation = false;
            botTargetRender.enabled = false;
            playerTurn = false;
            timerActive = false;
            botMovement.moving = true;
            Physics.gravity = new Vector3(0, stats.gravitySet, 0);
            shuttle.transform.eulerAngles = Vector3.zero;
            timer = 0;
            forehand = false;
            backhand = false;

            if (playerServing)
            {
                type = "";
                playerServing = false;
            }
        }
    }
}