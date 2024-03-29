﻿namespace Eudwia.Shared.Features.Authentication.Register;

public record RegisterResult
{
    public bool Successful { get; set; }
    public IEnumerable<string> Errors { get; set; } = new List<string>();
}