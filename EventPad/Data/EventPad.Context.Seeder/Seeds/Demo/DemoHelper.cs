namespace EventPad.Context.Seeder;

using EventPad.Context.Entities;

public class DemoHelper
{
    public IEnumerable<Event> GetEvents = new List<Event>
    {
        new Event()
        {
            Id = 0,
            Uid = Guid.NewGuid(),
            Name = "Volleyball",
            Description = "1 hour",
            Price = 100,
            Address = "VSU",
            Status = EventStatus.Started,
            Type = EventType.Multiple,
            MainPhoto = "None",
            Admin = new User()
                {
                    Id = 0,
                    FirstName = "Igor",
                    SecondName = "Kononov",
                    Uid = Guid.NewGuid(),
                    Account = new UserAccount()
                    {
                       Balance = 0,
                       AccountNumber = "2221234567891234"
                    }
                },
            EventAccount = new EventAccount()
            {
                Balance = 0,
                AccountNumber = "0001234567891234"
            }
        },
        new Event()
        {
            Id = 1,
            Uid = Guid.NewGuid(),
            Name = "Volleyball",
            Description = "1 hour",
            Price = 100,
            Address = "VSU",
            Status = EventStatus.Started,
            Type = EventType.Single,
            MainPhoto = "None",
            Admin = new User()
                {
                    Id = 1,
                    FirstName = "Olga",
                    SecondName = "Shishkina",
                    Uid = Guid.NewGuid(),
                    Account = new UserAccount()
                    {
                       Balance = 0,
                       AccountNumber = "3331234567891234"
                    }
                },
            EventAccount = new EventAccount()
            {
                Balance = 0,
                AccountNumber = "1111234567891235"
            }
        }
    };
}
