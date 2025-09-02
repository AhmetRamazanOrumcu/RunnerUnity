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
        }
        else
        {
            obstacle.SetActive(false);
        }
    }
}
