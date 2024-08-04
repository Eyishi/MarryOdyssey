﻿using UnityEngine;

namespace PLAYERTWO.PlatformerProject
{
    [RequireComponent(typeof(Collider))]
    [AddComponentMenu("PLAYER TWO/Platformer Project/Entity/Entity Volume Effector")]
    public class EntityVolumeEffector : MonoBehaviour
    {
        public float velocityConversion = 1f; //速度转换
        public float accelerationMultiplier = 1f;//速率
        public float topSpeedMultiplier = 1f;//加速倍率
        public float decelerationMultiplier = 1f;//减速倍率
        public float turningDragMultiplier = 1f; //转速拖拽倍率
        public float gravityMultiplier = 1f;

        protected Collider m_collider;

        protected virtual void Start()
        {
            m_collider = GetComponent<Collider>();
            m_collider.isTrigger = true;
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Entity entity))
            {
                entity.velocity *= velocityConversion;
                entity.accelerationMultiplier = accelerationMultiplier;
                entity.topSpeedMultiplier = topSpeedMultiplier;
                entity.decelerationMultiplier = decelerationMultiplier;
                entity.turningDragMultiplier = turningDragMultiplier;
                entity.gravityMultiplier = gravityMultiplier;
            }
        }

        protected virtual void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Entity entity))
            {
                entity.accelerationMultiplier = 1f;
                entity.topSpeedMultiplier = 1f;
                entity.decelerationMultiplier = 1f;
                entity.turningDragMultiplier = 1f;
                entity.gravityMultiplier = 1f;
            }
        }
    }
}