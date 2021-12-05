namespace Coevent.Dal.Services.Interfaces;

using Coevent.Entities;

public interface IEventService : IBaseService<Event>
{
    /// <summary>
    /// Get all the event occurrences for the specified 'eventId' and date range.
    /// </summary>
    /// <param name="eventId">Event ID.</param>
    /// <param name="startOn">Date range to start looking for occurrences (inclusive).</param>
    /// <param name="endOn">Date range to stop looking for occurrences (inclusive).</param>
    /// <returns></returns>
    IEnumerable<EventOccurrence> GetOccurrences(long eventId, DateTime startOn, DateTime endOn);

    /// <summary>
    /// Generate event occurrences for the specified event, based on the schedule.
    /// </summary>
    /// <param name="cevent"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    Event GenerateOccurrences(Event cevent);
}
