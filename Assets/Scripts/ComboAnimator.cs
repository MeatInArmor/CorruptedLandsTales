using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShadowChimera
{
    public class ComboAnimator : MonoBehaviour
    {
        public Animator anim;
        public int noOfClicks;
        float lastClickedTime;
        public float maxComdoDelay;
                
        void Start()
        {
            anim = gameObject.GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            //if (Time.time - lastClickedTime > maxComdoDelay)
            //{
            //    noOfClicks = 0;
            //}
            if (Input.GetMouseButtonDown(0))
            {
                //lastClickedTime = Time.time;
                noOfClicks++;
                if (noOfClicks == 1)
                {
                    anim.SetBool("IsAttack", true);
                }
                noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);
            }

        }

        public void attack1()
        {
            if (noOfClicks < 2)
            {
                anim.SetBool("IsAttack", false);
                noOfClicks = 0;
            }
        }

        public void attack2()
        {
            if (noOfClicks < 3)
            {
                anim.SetBool("IsAttack", false);
                noOfClicks = 0;
            }            
        }

        public void attack3()
        {
            anim.SetBool("IsAttack", false);            
            noOfClicks = 0;
        }
    }
}
