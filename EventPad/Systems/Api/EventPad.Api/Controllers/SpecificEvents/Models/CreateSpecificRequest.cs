using AutoMapper;
using EventPad.Services.Specific;

namespace EventPad.Api.Controllers.Specific;

public class CreateSpecificRequest
{
    public Guid EventId { get; set; }

    public string? Description { get; set; }
    public float Price { get; set; }
    public string Address { get; set; }
    public DayOfWeek? DayOfWeek { get; set; }
    public DateTime? DateTime { get; set; }
    public bool Private { get; set; }
}

public class SpecificCreateProfile : Profile
{
    public SpecificCreateProfile()
    {
        CreateMap<CreateSpecificRequest, CreateSpecificEventModel>();
    }
}