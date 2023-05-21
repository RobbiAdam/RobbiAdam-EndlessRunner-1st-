using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private float _speed = 5f;
    private PlayerController _player;
    private Vector3 _startPos;
    private float _repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
        _startPos = transform.position;
        _repeatWidth = GetComponent<BoxCollider>().size.x / 2;


    }

    // Update is called once per frame
    void Update()
    {
        if (_player._isGameOver == false)
        {
            MoveToLeft();
        }
        ResetBackground();
    }

    void MoveToLeft()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }

    void ResetBackground()
    {
        if (transform.position.x < _startPos.x - _repeatWidth)
        {
            transform.position = _startPos;
        }
    }
}
