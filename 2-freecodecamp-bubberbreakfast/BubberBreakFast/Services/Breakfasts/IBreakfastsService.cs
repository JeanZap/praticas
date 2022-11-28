using BubberBreakFast.Models;

public interface IBreakfastsService
{
    void CreateBreakFast(Breakfast breakfast);
    void DeleteBreakfast(Guid id);
    Breakfast GetBreakfast(Guid id);
    void UpsertBreakfast(Breakfast breakfast);
}