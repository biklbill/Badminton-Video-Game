using UnityEngine;

public class BotChooseTarget : MonoBehaviour
{
    public Stats stats;

    public Vector3 ChooseTarget(int score, float difficulty, bool serving)
    {
        if (serving)
        {
            if (score % 2 == 0)
            {
                return new Vector3(Random.Range(stats.evenServeCentre[0] - difficulty / 2, stats.evenServeCentre[0] + difficulty / 2), 0.1f, Random.Range(stats.evenServeCentre[2] - difficulty / 2, stats.evenServeCentre[2] + difficulty / 2));
            }
            else
            {
                return new Vector3(Random.Range(stats.oddServeCentre[0] - difficulty / 2, stats.oddServeCentre[0] + difficulty / 2), 0.1f, Random.Range(stats.oddServeCentre[2] - difficulty / 2, stats.oddServeCentre[2] + difficulty / 2));
            }
        }
        else
        {
            return new Vector3(Random.Range(stats.targetCourtCentre[0] - difficulty, stats.targetCourtCentre[0] + difficulty), 0, Random.Range(stats.targetCourtCentre[2] - difficulty, stats.targetCourtCentre[2] + difficulty));
        }
    }
}
