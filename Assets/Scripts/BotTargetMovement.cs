using UnityEngine;

public class BotTargetMovement : MonoBehaviour
{
    public Stats stats;
    public BotHitShuttle botHitShuttle;
    public BotChooseTarget botChooseTarget;
    public Scoring scoring;

    public GameObject player;

    public bool aim;

    private Vector3 botTargetPosition;

    private void Update()
    {
        if (aim)
        {
            botTargetPosition = botChooseTarget.ChooseTarget(scoring.botScore, stats.difficulty, botHitShuttle.botServing);
            aim = false;
        }

        transform.position = botTargetPosition;
    }
}