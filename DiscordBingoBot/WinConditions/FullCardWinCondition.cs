﻿using System;
using System.Collections.Generic;
using System.Text;
using DiscordBingoBot.Models;

namespace DiscordBingoBot.WinConditions
{
    public class FullCardWinCondition : IWinCondition
    {
        public string Description { get; } = "A full board is required";

        public bool ConditionMet(Grid grid)
        {
            for (int i = 0; i < grid.Rows.Length; i++)
            {
                for (int j = 0; j < grid.Rows[i].Items.Length; j++)
                {
                    if (grid.IsMarked(i,j) == false)
                    if (grid.IsMarked(i,j) == false)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
