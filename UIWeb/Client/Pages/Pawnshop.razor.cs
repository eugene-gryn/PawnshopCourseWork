using UIWeb.Shared.DTOs;

namespace UIWeb.Client.Pages;

public class MainMenuBase : PawnshopBaseComponent {
    public int CountPawnshopsOnLoad { get; set; } = 6;
    public int OffsetPawnshops { get; set; }
    public List<PawnshopDto>? Pawnshops { get; set; }


    protected override async Task<Task> OnParametersSetAsync() {
        try {
            Pawnshops = await Server.PawnshopList(CountPawnshopsOnLoad, OffsetPawnshops);
        }
        catch (Exception) {
            throw new Exception("Request failed! ");
        }

        return base.OnParametersSetAsync();
    }

    public async Task LoadMoreAsync() {
        OffsetPawnshops += CountPawnshopsOnLoad;

        var nextList = await Server.PawnshopList(CountPawnshopsOnLoad, OffsetPawnshops);

        if (nextList != null) Pawnshops?.AddRange(nextList);
    }
}