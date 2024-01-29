using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class GameState : MonoBehaviour
    {
        public List<GameObject> views;
        public void Enter()
        {
            gameObject.SetActive(true);
        }
        public void Exit()
        {
            gameObject.SetActive(false);
        }
        protected virtual void OnEnable()
        {
            foreach (var item in views)
            {
                item.SetActive(true);
            }
        }
        protected virtual void OnDisable()
        {
            foreach (var item in views)
            {
                item.SetActive(false);
            }
        }
    }
}
