// -----------------------------------------------------------------------
// <copyright file="ReceivingEffectEventArgs.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.EventArgs
{
    using System;

    using CustomPlayerEffects;

    using Exiled.API.Features;

    /// <summary>
    /// Contains all information before a player receives a <see cref="PlayerEffect"/>.
    /// </summary>
    public class ReceivingEffectEventArgs : EventArgs
    {
        private byte state;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReceivingEffectEventArgs"/> class.
        /// </summary>
        /// <param name="player">The <see cref="Player"/> receiving the effect.</param>
        /// <param name="effect">The <see cref="PlayerEffect"/> being added to the player.</param>
        /// <param name="state">The state the effect is being changed to.</param>
        /// <param name="currentState">The current state of the effect being changed.</param>
        public ReceivingEffectEventArgs(Player player, PlayerEffect effect, byte state, byte currentState)
        {
            Player = player;
            Effect = effect;
            this.state = state;
            CurrentState = currentState;
        }

        /// <summary>
        /// Gets the <see cref="Player"/> receiving the effect.
        /// </summary>
        public Player Player { get; }

        /// <summary>
        /// Gets the <see cref="PlayerEffect"/> being received.
        /// </summary>
        public PlayerEffect Effect { get; }

        /// <summary>
        /// Gets or sets a value indicating whether or not the effect will be applied.
        /// </summary>
        public bool IsAllowed { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating how long the effect will last.
        /// </summary>
        public float Duration { get; set; } = 0.0f;

        /// <summary>
        /// Gets or sets the value of the new state of the effect. Setting this to <c>0</c> is the same as setting IsAllowed to <see langword="false"/>.
        /// </summary>
        public byte State
        {
            get => state;
            set
            {
                state = value;
                if (state == 0)
                    IsAllowed = false;
            }
        }

        /// <summary>
        /// Gets the value of the current state of this effect on the player.
        /// </summary>
        public byte CurrentState { get; }
    }
}
