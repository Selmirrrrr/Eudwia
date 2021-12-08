﻿namespace MosqueLife.Shared.Models.Authentication;

public class RegisterResult
{
    public bool Successful { get; set; }
    public IEnumerable<string> Errors { get; set; } = new List<string>();
}
