﻿
namespace WarCroft.Entities.Characters.Contracts
{
    using System;
    
    using WarCroft.Constants;
    public abstract class Character
    {
		// TODO: Implement the rest of the class.

		public bool IsAlive { get; set; } = true;

		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}
	}
}