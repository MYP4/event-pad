﻿using EventPad.Context.Entities;

namespace EventPad.Api.Controllers.Events;

public class UpdateEventRequest
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public float Price { get; set; }
    public string Address { get; set; }
    public string Status { get; set; }
    public EventType Type { get; set; }
    public string? MainPhoto { get; set; }
}

