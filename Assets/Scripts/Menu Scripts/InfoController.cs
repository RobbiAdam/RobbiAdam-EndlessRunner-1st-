using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoController : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _infoMenu;

    private void Update()
    {
        if(Input.anyKeyDown)
        {
            _mainMenu.SetActive(true);
            _infoMenu.SetActive(false);
        }
    }
    // Start is called before the first frame update
}
