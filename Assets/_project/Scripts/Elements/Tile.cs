using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject obstacle;
   public void SetObstacle(bool haveObstacle)
    {
        if(haveObstacle)
        {
            obstacle.SetActive(true);
        }
        else
        {
            obstacle.SetActive(false);
        }
    }
}
