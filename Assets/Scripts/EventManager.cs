using System;
using System.Collections;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField]private BoxController _boxController;
    [SerializeField] private GameObject _prefabDie;
    [SerializeField] private GameObject _prefabLive;
    private void Start()
    {
        _boxController.LoseEvent += OnPlaeyrDie;
        _boxController.WinEvent += OnPlaeyrLive;
    }

    private void OnPlaeyrDie()
    {
        _prefabDie.SetActive(true);
    }
    private void  OnPlaeyrLive()
    {
       _prefabLive.SetActive(true);
    }
    private void OnDestroy()
    {
        _boxController.LoseEvent -= OnPlaeyrDie;
        _boxController.WinEvent -= OnPlaeyrLive;
    }
    
}