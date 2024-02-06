using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShadowChimera
{
    public class ComboAnimator : MonoBehaviour
    {
        //[SerializeField] private List<Slash> slashes;
        public Animator anim;
        public int noOfClicks;
        float lastClickedTime;
        public float maxComdoDelay;
        void Start()
        {
            anim = gameObject.GetComponentInParent<Animator>();
        }

        
        void Update()
        {
            if (noOfClicks == 1)
            {
                anim.SetBool("IsAttack", true);
            }
            noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);
            

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
            else
            {
                //characterController.enabled = false;
            }
        }

        public void attack3()
        {
            anim.SetBool("IsAttack", false);
            noOfClicks = 0;
        }

        public void ClickAttack()
        {
            noOfClicks++;
        }
    }
}
