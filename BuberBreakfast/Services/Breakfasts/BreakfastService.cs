namespace BuberBreakfast.Services.Breakfasts;
using BuberBreakfast.Models;

public class BreakfastService : IBreakfastService
{
    // temporarily using a dictionary as db
    // static to prevent this _breakfasts from being re-instantiated on each request
    // the static keyword is used to declare members of a class that belong to the type itself rather than to instances of the type.
    private readonly static Dictionary<Guid, Breakfast> _breakfasts = new();

    public void CreateBreakfast(Breakfast breakfast)
    {
        _breakfasts.Add(breakfast.Id, breakfast);
    }

    public Breakfast? GetBreakfast(Guid id)
    {
        Breakfast? breakfast;
        if (_breakfasts.TryGetValue(id, out breakfast))
        {
            return breakfast;
        }
        return breakfast;
    }

    public bool UpsertBreakfast(Guid id, Breakfast breakfast)
    {
        Breakfast? prevBreakfast;
        if (_breakfasts.TryGetValue(id, out prevBreakfast))
        {
            _breakfasts[id] = new Breakfast(
                prevBreakfast.Id,
                breakfast.Name,
                breakfast.Description,
                prevBreakfast.StartDateTime,
                prevBreakfast.EndDateTime,
                DateTime.UtcNow,
                breakfast.Savory,
                breakfast.Sweet
            );
            return false;
        }
        
        _breakfasts.Add(breakfast.Id, breakfast);
        return true;
    }

    public void DeleteBreakfast(Guid id)
    {
        _breakfasts.Remove(id);
    }

    public Breakfast?[] ListBreakfast()
    {
        return _breakfasts.Values.ToArray();
    }
}