namespace Coevent.Dal.Services;

using Coevent.Entities;
using Coevent.Dal.Repositories;
using Coevent.Dal.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

public class EventService : BaseCrudRepository<Event>, IEventService
{
    #region Variables
    #endregion

    #region Constructors
    public EventService(CoeventContext context, IHttpContextAccessor httpContextAccessor, ILogger<EventService> logger) : base(context, httpContextAccessor, logger)
    {
    }
    #endregion

    #region Methods
    /// <summary>
    /// Get all the event occurrences for the specified 'eventId' and date range.
    /// </summary>
    /// <param name="eventId">Event ID.</param>
    /// <param name="startOn">Date range to start looking for occurrences (inclusive).</param>
    /// <param name="endOn">Date range to stop looking for occurrences (inclusive).</param>
    /// <returns></returns>
    public IEnumerable<EventOccurrence> GetOccurrences(long eventId, DateTime startOn, DateTime endOn)
    {
        var occurrences = this.Context.EventOccurrences.AsNoTracking().Where(e => e.EventId == eventId && e.StartOn >= startOn && e.StartOn <= endOn);

        return occurrences.ToArray();
    }

    /// <summary>
    /// Generate event occurrences for the specified event, based on the schedule.
    /// </summary>
    /// <param name="cevent"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public Event GenerateOccurrences(Event cevent)
    {
        if (cevent == null) throw new ArgumentNullException(nameof(cevent));

        var aevent = this.Context.Events.Include(e => e.Schedule).Include(e => e.Openings).First(e => e.Id == cevent.Id);
        var schedule = aevent.Schedule ?? throw new InvalidDataException("Event schedule is required.");
        var date = cevent.StartOn;
        var count = 0;

        while (date <= aevent.EndOn || (schedule.RepeatSize > 0 && count > schedule.RepeatSize))
        {
            if (VerifyDayOfWeek(date, schedule) && VerifyMonth(date, schedule))
            {
                // Create a new occurrence.
                var occurrence = new EventOccurrence(aevent)
                {
                    StartOn = new DateTime(date.Year, date.Month, date.Day).AddSeconds(schedule.StartOnTime.TotalSeconds),
                    EndOn = new DateTime(date.Year, date.Month, date.Day).AddSeconds(schedule.EndOnTime.TotalSeconds)
                };

                // Create opening occurrences.
                foreach (var opening in aevent.Openings)
                {
                    var oOccurrence = new OpeningOccurrence(opening, occurrence);
                    occurrence.OpeningOccurrences.Add(oOccurrence);
                }

                this.Context.EventOccurrences.Add(occurrence);
                count++;

                // Move the date based on the schedule.
                date = schedule.RepeatType switch
                {
                    RepeatType.Daily => date.AddDays(1),
                    RepeatType.Weekly => date.AddDays(7),
                    // TODO: Deal with different size months.
                    RepeatType.Monthly => date.AddMonths(1),
                    RepeatType.Annually => date.AddYears(1),
                    // TODO: Deal with event occuring more than once in a day.
                    _ => schedule.RepeatSize == 0 ? aevent.EndOn.AddDays(1) : date,
                };
            }
            else
            {
                // Increment one day at a time until the schedule finds a valid date.
                date = date.AddDays(1);
            }

        }

        // Save all events at once.
        this.Context.SaveChanges();

        return aevent;
    }

    private static DaysOfWeek GetDayOfWeek(DateTime date)
    {
        return date.DayOfWeek switch
        {
            DayOfWeek.Sunday => DaysOfWeek.Sunday,
            DayOfWeek.Monday => DaysOfWeek.Monday,
            DayOfWeek.Tuesday => DaysOfWeek.Tuesday,
            DayOfWeek.Wednesday => DaysOfWeek.Wednesday,
            DayOfWeek.Thursday => DaysOfWeek.Thursday,
            DayOfWeek.Friday => DaysOfWeek.Friday,
            DayOfWeek.Saturday => DaysOfWeek.Saturday,
            _ => DaysOfWeek.None,
        };
    }

    private static bool VerifyDayOfWeek(DateTime date, Schedule schedule)
    {
        var dayOfWeek = GetDayOfWeek(date);
        return dayOfWeek == DaysOfWeek.None || (schedule.DaysOfWeek & dayOfWeek) != 0;
    }

    private static Months GetMonths(DateTime date)
    {
        return date.Month switch
        {
            1 => Months.January,
            2 => Months.February,
            3 => Months.March,
            4 => Months.April,
            5 => Months.May,
            6 => Months.June,
            7 => Months.July,
            8 => Months.August,
            9 => Months.September,
            10 => Months.October,
            11 => Months.November,
            12 => Months.December,
            _ => Months.None
        };
    }

    private static bool VerifyMonth(DateTime date, Schedule schedule)
    {
        var month = GetMonths(date);
        return schedule.Months == Months.None || (schedule.Months & month) != 0;
    }
    #endregion
}
