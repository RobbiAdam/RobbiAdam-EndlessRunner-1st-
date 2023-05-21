using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float _speed = 11f;
    private float _leftBound = -20f;
    private PlayerController _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveToLeft();
        CheckIfOutOfBounds();
    }

    void MoveToLeft()
    {
        if (!_player._isGameOver)
        {
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
        }

    }

    void CheckIfOutOfBounds()
    {
        if (transform.position.x < _leftBound)
        {
            Destroy(gameObject);
        }
    }
}
