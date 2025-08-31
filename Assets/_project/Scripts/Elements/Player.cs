using System;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameManager gameDirector;
    public float speed;
    public Transform cameraHolder;
    public float sensitivity;
    public float maxWith;
     

    private float _initalXPos;
    private float _horizontalInput;
    private void Update()
    {
        print(transform.position);
        //transform.position = new Vector3(10, 10, 10);

        //transform.position +=Vector3.forward * Time.deltaTime*speed;

        

        if(Input.GetMouseButtonDown(0))
        {
            _initalXPos = transform.position.x;
            //print(_initalXPos);

        }
        if(Input.GetMouseButton(0))
        {
            _horizontalInput += Input.GetAxis("Mouse X")/Screen.width;//Her cihazýn büyüklüðüne göre x deðerleri farklý olacaðý için 
            var pos = transform.position;
            pos.x = _initalXPos + _horizontalInput*sensitivity;
            transform.position = pos;

            CalmPlayerPosition();
        }
        if (Input.GetMouseButtonUp(0))
        {
            _horizontalInput = 0;
        }

        
        transform.position += Vector3.forward * Time.deltaTime * speed;

        var cameraPos = transform.position;
        cameraPos.x = 0;
        cameraHolder.position = cameraPos;

        if(gameDirector.levelManager.GetLastTilePosition()-transform.position.z<100)
        {
            gameDirector.levelManager.CreateTiles(1);
        }

    }

    private void CalmPlayerPosition()
    {//sýnýrlarý belirlemek için hareketin
        var pos = transform.position;
        pos.x=Mathf.Clamp(pos.x,-maxWith,maxWith);
        transform.position = pos;
    }
}
