using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace TheKiwiCoder {

    // This is the blackboard container shared between all nodes.
    // Use this to store temporary data that multiple nodes need read and write access to.
    // Add other properties here that make sense for your specific use case.
    [System.Serializable]
	public class Blackboard
	{
		public Transform target;
		public Vector3 moveToPosition;
        public float attackRange = 8f;
        public float reserveAttackRange = 8f;
        [Header("Boss")]
        public string typeOfAttack;
        public bool hasChangedTypeOfAttack = false;
	}
}