﻿namespace SamuraiApp.Domain;

public class Battle
{
    public int BattleId { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}