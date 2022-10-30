using Microsoft.AspNetCore.Components;

namespace PawnshopWebApp.Components.Search;

public partial class SearchComponent {
    [Parameter]
    public List<string> Filters { get; set; }

    [Parameter]
    public int SelectedIndex { get; set; }

    [Parameter]
    public EventCallback<int> OnFilterChanged { get; set; }

    [Parameter]
    public EventCallback<string?> OnQueryChanged { get; set; }


    public void OnChangedIndex(string element) {
        var index = Filters.IndexOf(element);
        SelectedIndex = index;
        OnFilterChanged.InvokeAsync(index);
    }

    public void OnChangedInputQuery(string? query) {
        OnQueryChanged.InvokeAsync(query);
    }
}