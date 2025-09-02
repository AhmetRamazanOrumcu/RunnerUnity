using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject obstacle;
   public void SetObstacle(bool haveObstacle)
    {
        if(haveObstacle)
        {
            obstacle.SetActive(true);
            obstacle.transform.localPosition=new Vector3(Random.Range(-2f,2f),.5f,0);
            obstacle.transform.localScale = new Vector3(Random.Range(.5f, 2f), 1, 1);
        }
        else
        {
            obstacle.SetActive(false);
        }
    }
}
