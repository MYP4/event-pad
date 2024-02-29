using AutoMapper;
using EventPad.Context.Entities;
using EventPad.Services.Specific;

namespace EventPad.Api.Controllers.Specific;

public class SpecificResponse
{
    public Guid Id { get; set; }
    public Guid EventId { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public string Address { get; set; }
    public DayOfWeek? DayOfWeek { get; set; }
    public DateTime? DateTime { get; set; }
    public bool Private { get; set; }
    public string ArticleNumber { get; set; }
    public EventStatus Status { get; set; }
}


public class SpecificResponceProfile : Profile
{
    public SpecificResponceProfile()
    {
        CreateMap<SpecificEventModel, SpecificResponse>();
    }
}
