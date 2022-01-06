using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public static PlayerManager Instance
    {
        get;
        private set;
    }

    private PlayerManager _playerManager;

    [SerializeField] DetectGround _detectGround;
    [SerializeField] Movement _playerMovement;

    private void Awake()
    {
        if(_playerManager == null)
        {
            _playerManager = this;
        }
    }

    private void Start()
    {
        
    }
}
