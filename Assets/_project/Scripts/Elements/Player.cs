using System;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameManager gameDirector;
    public float speed;
    public Transform cameraHolder;
    public float sensitivity;
    public float maxWith;
    public float jumpPower;
    private Rigidbody _rb;

    private Animator _animator;
    private bool _isDead;

    private bool _isLevelFinished;

    private bool _isJump;

    private int score;

    private bool _isFinishedCreate;


    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _rb = GetComponent<Rigidbody>();
    }
    private float _initalXPos;
    private float _horizontalInput;

    void RestartScene()
    {
        SceneManager.LoadScene(0);
    }
    private void Update()
    {
        score = (int)transform.position.z;

        if (gameDirector.levelManager.scoreTMP!=null) 
        {
            gameDirector.levelManager.scoreTMP.text = "SCORE:"+score.ToString();
        }
        print("Gittiði Mesafe:"+transform.position.z);

        if(_isDead)
        {
            return;
        }
        if ( _isLevelFinished)
        {
            return;
        }

        if (Input.GetMouseButtonUp(0)&& !_isJump)
        {
           _animator.SetTrigger("JumpNaruto");//animasyon parametresine göre yazýyoruz.
            _rb.linearVelocity = new Vector3(_rb.linearVelocity.x, jumpPower, _rb.linearVelocity.z);
            _isJump = true;
            }

        
    }
    
    private void FixedUpdate()
    {
        //print(transform.position);
        //transform.position = new Vector3(10, 10, 10);

        //transform.position +=Vector3.forward * Time.deltaTime*speed;

        if(_isDead || _isLevelFinished)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            _initalXPos = _rb.position.x;
            //print(_initalXPos);
            
        }
        if (Input.GetMouseButton(0))
        {
            _horizontalInput += Input.GetAxis("Mouse X") / Screen.width;//Her cihazýn büyüklüðüne göre x deðerleri farklý olacaðý için 
            var pos = _rb.position;
            pos.x = _initalXPos + _horizontalInput * sensitivity;
            _rb.position = pos;

            CalmPlayerPosition();
        }
        if (Input.GetMouseButtonUp(0))
        {
            _horizontalInput = 0;
            
        }


        _rb.position += Vector3.forward * Time.deltaTime * speed;

        var cameraPos = _rb.position;
        cameraPos.x = 0;
        cameraHolder.position = cameraPos;



        int difficultyDistance = UnityEngine.Random.Range(145, 536);

        if (gameDirector.levelManager.GetLastTilePosition() - _rb.position.z < 100)
        {
            if(transform.position.z !< difficultyDistance) 
            { 
            gameDirector.levelManager.MoveTile();
            }
            else if(!_isFinishedCreate)
            {
                _isFinishedCreate = true;
                gameDirector.levelManager.FinishedTile();
                gameDirector.levelManager.GetLastTilePositionPlus();
            }

        }
        
    }

    private void CalmPlayerPosition()
    {//sýnýrlarý belirlemek için hareketin
        var pos = _rb.position;
        pos.x = Mathf.Clamp(pos.x, -maxWith, maxWith);
        _rb.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Obstacle"))
        {
            _isDead = true;
            _animator.SetTrigger("FallBack");
        }
        if (other.CompareTag("FinishBlock"))
        {

            _isLevelFinished = true;
            _animator.SetTrigger("Finished");
        }
        

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            _isJump = false;
        }
    }


}
