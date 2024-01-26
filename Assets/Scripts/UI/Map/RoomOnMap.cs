using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptedLandTales
{
    public class RoomOnMap : MonoBehaviour
    {
        public HealingRoomOnMap healingRoomOnMap;
        public BossIconOnMap bossIconOnMap;
        public RoomFieldOnMap roomFieldOnMap;

        private void Awake()
        {
            healingRoomOnMap = GetComponentInChildren<HealingRoomOnMap>();
            bossIconOnMap = GetComponentInChildren<BossIconOnMap>();
            roomFieldOnMap = GetComponentInChildren<RoomFieldOnMap>();
            if (healingRoomOnMap != null)
                healingRoomOnMap.gameObject.SetActive(false);
            if (bossIconOnMap != null)
                bossIconOnMap.gameObject.SetActive(false);
            if (roomFieldOnMap != null)
                roomFieldOnMap.gameObject.SetActive(false);

        }
        private void Start()
        {
           
        }
    }
}
