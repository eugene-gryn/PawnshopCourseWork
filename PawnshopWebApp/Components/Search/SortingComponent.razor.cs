using Microsoft.AspNetCore.Components;

namespace PawnshopWebApp.Components.Search;

public partial class SortingComponent {
    [Parameter]
    public List<string> Filters { get; set; }

    [Parameter]
    public int SelectedIndex { get; set; }

    [Parameter]
    public EventCallback<int> OnFilterChanged { get; set; }
    

    public void OnChangedIndex(string attr) {
        var index = Filters.IndexOf(attr);
        SelectedIndex = index;
        OnFilterChanged.InvokeAsync(index);
    }
}