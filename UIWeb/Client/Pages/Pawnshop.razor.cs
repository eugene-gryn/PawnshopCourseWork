using Radzen;
using UIWeb.Shared.DTOs;

namespace UIWeb.Client.Pages;

public class MainMenuBase : PawnshopBaseComponent {
    public int CountPawnshopsOnLoad { get; set; } = 6;
    private int _limitPawnshops = 6;
    public List<PawnshopDto>? Pawnshops { get; set; }


    protected override async Task<Task> OnParametersSetAsync() {
        try {
            Pawnshops = await Server.PawnshopList(_limitPawnshops, 0);
        }
        catch (Exception) {
            throw new Exception("Request failed! ");
        }

        return base.OnParametersSetAsync();
    }

    public async Task LoadMoreAsync() {
        _limitPawnshops += CountPawnshopsOnLoad;

        var nextList = await Server.PawnshopList(_limitPawnshops, 0);

        if (nextList != null) Pawnshops?.AddRange(nextList);
    }

    public async Task Sort(int indexAttribute) {
        string attribute = string.Empty;
        switch (indexAttribute) {
            case 0:
                attribute = "Name";
                break;
            case 1:
                attribute = "Address";
                break;
            case 2:
                attribute = "MoneyAvailable";
                break;
        }

        Pawnshops = await Server.PawnshopSortByAttribute(attribute, _limitPawnshops, 0);

        Console.WriteLine($"By {attribute} from {0} to {_limitPawnshops}");

    }

    public async Task Search(int indexAttribute, string query) {
        string attribute = string.Empty;
        switch (indexAttribute)
        {
            case 0:
                attribute = "Name";
                break;
            case 1:
                attribute = "Address";
                break;
            case 2:
                attribute = "MoneyAvailable";
                break;
        }

        Pawnshops = await Server.PawnshopSearchByAttribute(attribute, query, _limitPawnshops, 0);

        Console.WriteLine($"{attribute} : {query} from {0} to {_limitPawnshops}");

    }
}