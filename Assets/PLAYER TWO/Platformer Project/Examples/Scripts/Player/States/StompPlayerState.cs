﻿using UnityEngine;

//脚踏的状态
namespace PLAYERTWO.PlatformerProject
{
    public class StompPlayerState : PlayerState
    {
        protected float m_airTimer;//空中时间
        protected float m_groundTimer;//地上时间

        protected bool m_falling; //是不是掉落
        protected bool m_landed;//是不是陆地
        protected override void OnEnter(Player player)
        {
            m_landed = m_falling = false;
            m_airTimer = m_groundTimer = 0;
            player.velocity = Vector3.zero;
            player.playerEvents.OnStompStarted?.Invoke();
        }

        protected override void OnExit(Player player)
        {
            player.playerEvents.OnStompEnding?.Invoke();
        }

        protected override void OnStep(Player player)
        {
            if (!m_falling)
            {
                m_airTimer += Time.deltaTime;

                if (m_airTimer >= player.stats.current.stompAirTime)
                {
                    m_falling = true;
                    player.playerEvents.OnStompFalling.Invoke();
                }
            }
            else
            {
                player.verticalVelocity += Vector3.down * player.stats.current.stompDownwardForce;
            }

            if (player.isGrounded)
            {
                if (!m_landed) //以player的为准
                {
                    m_landed = true;
                    player.playerEvents.OnStompLanding?.Invoke();
                }

                if (m_groundTimer >= player.stats.current.stompGroundTime)
                {
                    player.verticalVelocity = Vector3.up * player.stats.current.stompGroundLeapHeight;
                    player.states.Change<FallPlayerState>();
                }
                else
                {
                    m_groundTimer += Time.deltaTime;
                }
            }
        }

        public override void OnContact(Player player, Collider other)
        {
         
        }
    }
}