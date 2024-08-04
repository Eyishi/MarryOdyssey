﻿using System;
using UnityEngine.Events;

namespace PLAYERTWO.PlatformerProject
{
    [Serializable]
    public class PlayerEvents
    {
        /// <summary>
        /// 跳跃
        /// </summary>
        public UnityEvent OnJump;

        /// <summary>
        /// 受伤
        /// </summary>
        public UnityEvent OnHurt;

        /// <summary>
        /// 死亡
        /// </summary>
        public UnityEvent OnDie;

        /// <summary>
        /// 攻击
        /// </summary>
        public UnityEvent OnSpin;

        /// <summary>
        /// 拾取物品
        /// </summary>
        public UnityEvent OnPickUp;

        /// <summary>
        /// 投掷物品
        /// </summary>
        public UnityEvent OnThrow;

        /// <summary>
        /// Called when the Player started the Stomp Attack.
        /// </summary>
        public UnityEvent OnStompStarted;

        /// <summary>
        /// Called when the Player starts moving down with Stomp Attack.
        /// </summary>
        public UnityEvent OnStompFalling;

        /// <summary>
        /// Called when the Player landed from the Stomp Attack.
        /// </summary>
        public UnityEvent OnStompLanding;

        /// <summary>
        /// Called when the Player finished the Stomp Attack.
        /// </summary>
        public UnityEvent OnStompEnding;

        /// <summary>
        /// Called when the player grabs onto a ledge.
        /// </summary>
        public UnityEvent OnLedgeGrabbed;

        /// <summary>
        /// Called when the Player climbs a ledge.
        /// </summary>
        public UnityEvent OnLedgeClimbing;

        /// <summary>
        /// Called when the Player air dives.
        /// </summary>
        public UnityEvent OnAirDive;

        /// <summary>
        /// Called when the Player performs a backflip.
        /// </summary>
        public UnityEvent OnBackflip;

        /// <summary>
        /// Called when the Player starts gliding.
        /// </summary>
        public UnityEvent OnGlidingStart;

        /// <summary>
        /// Called when the Player stops glidig.
        /// </summary>
        public UnityEvent OnGlidingStop;

        /// <summary>
        /// Called when the Player starts dashing.
        /// </summary>
        public UnityEvent OnDashStarted;

        /// <summary>
        /// Called when the Player finishes dashing.
        /// </summary>
        public UnityEvent OnDashEnded;
    }
}