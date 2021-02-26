using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieDefence.Managers
{
    public class GameManager : MonoBehaviour
    {
        private LevelManager _levelManager;
        
        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            Debug.Log("Game Manager Initialize");
            
            DontDestroyOnLoad(this);

            GetReferences();
        }

        private void GetReferences()
        {
            Debug.Log("Game Manager References");
        }
    }
}
