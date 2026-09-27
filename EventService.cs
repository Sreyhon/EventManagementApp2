using EventManagementApp.Models;

namespace EventManagementApp.Services
{
    public class EventService
    {
        private readonly List<Event> events = new()
        {
            new Event
            {
                Id = 1,
                Name = "Web Development Workshop",
                Description = "Learn modern web development techniques.",
                Location = "Computer Lab A",
                Date = DateTime.Now.AddDays(7),
                MaxAttendees = 30
            },

            new Event
            {
                Id = 2,
                Name = "Blazor Seminar",
                Description = "Introduction to building applications with Blazor.",
                Location = "Conference Room",
                Date = DateTime.Now.AddDays(14),
                MaxAttendees = 50
            },

            new Event
            {
                Id = 3,
                Name = "Programming Workshop",
                Description = "Practical programming and problem solving.",
                Location = "Computer Lab B",
                Date = DateTime.Now.AddDays(21),
                MaxAttendees = 25
            }
        };

        private readonly List<Registration> registrations = new();

        public List<Event> GetEvents()
        {
            foreach (var item in events)
            {
                item.RegisteredCount =
                    registrations.Count(x => x.EventId == item.Id);
            }

            return events;
        }

        public Event? GetEvent(int id)
        {
            return events.FirstOrDefault(x => x.Id == id);
        }

        public List<Registration> GetRegistrations()
        {
            return registrations;
        }

        public bool Register(Registration registration)
        {
            var eventItem = GetEvent(registration.EventId);

            if (eventItem == null)
                return false;

            var count = registrations.Count(
                x => x.EventId == registration.EventId);

            if (count >= eventItem.MaxAttendees)
                return false;

            registration.Id = registrations.Count + 1;

            registrations.Add(registration);

            return true;
        }

        public void UpdateAttendance(
            int registrationId,
            bool isPresent)
        {
            var registration =
                registrations.FirstOrDefault(
                    x => x.Id == registrationId);

            if (registration != null)
            {
                registration.IsPresent = isPresent;
            }
        }
    }
}