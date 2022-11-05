using Microsoft.AspNetCore.Components;
using UIWeb.Shared.DTOs;

namespace UIWeb.Client.Pages.ModelPages;

public class PawnshopModelPageBase : PawnshopBaseComponent {
    public enum PageStates {
        Create,
        Read,
        Update,
        CityAdd
    }

    public List<CityDto> Cities = new();

    public PawnshopDto Model;

    protected int ModelId;

    protected PageStates State;


    protected bool? WrongPage;

    public CityDto City { get; set; }

    [Parameter] public string Identifier { get; set; }


    protected override async Task<Task> OnParametersSetAsync() {
        try {
            var nums = Identifier.Split('-');

            if (nums.Length == 2) {
                ModelId = int.Parse(nums[0]);
                State = (PageStates) int.Parse(nums[1]);
            }

            Console.WriteLine(ModelId);
            Console.WriteLine(State);

            if (State is PageStates.Update or PageStates.Create) {
                var cities = await Server.GetCitiesList();

                if (cities != null) {
                    Cities.Clear();
                    Cities.AddRange(cities);
                }

                Console.WriteLine("Cities added");
            }


            if (ModelId == 0 && State != PageStates.Create && State != PageStates.CityAdd) {
                WrongPage = true;
                Console.WriteLine("Wrong id on page creation!");
                return Task.CompletedTask;
            }

            if (State is PageStates.CityAdd) {
                City = new CityDto();
                WrongPage = false;
                Console.WriteLine("You creating the city!");
                return Task.CompletedTask;
            }

            if (State is PageStates.Read or PageStates.Update) {
                var model = await Server.PawnshopById(ModelId);

                if (model == null) {
                    Console.WriteLine("null model");
                    WrongPage = true;
                    return Task.CompletedTask;
                }
                
                Console.WriteLine("Updating!");
                
                Model = model;

                City = ((await Server.GetCityById(Model.CityId))!);
            }
            else {
                Model = new PawnshopDto();
                Console.WriteLine("Creating!");
            }

            WrongPage = false;
            return Task.CompletedTask;
        }
        catch (Exception e) {
            Console.WriteLine("Exception ->" + e.Message);
            WrongPage = true;
            return Task.CompletedTask;
        }
    }

    protected async Task CreateNewModel(TimeSpan o, TimeSpan c) {
        Model.TimeOpen = o;
        Model.TimeClose = c;
        Model.CityId = City.Id;

        await Server.PawnshopAdd(Model);

        AuthorizeS.Navigation.NavigateTo(AuthorizeS.Navigation.BaseUri);
    }

    protected async Task UpdateNewModel(TimeSpan o, TimeSpan c) {
        Model.TimeOpen = o;
        Model.TimeClose = c;
        Model.CityId = City.Id;

        await Server.PawnshopUpdate(Model);

        AuthorizeS.Navigation.NavigateTo(AuthorizeS.Navigation.BaseUri);
    }

    protected async Task AddNewCity() {
        await Server.CityAdd(City);

        AuthorizeS.Navigation.NavigateTo(AuthorizeS.Navigation.BaseUri);
    }

    public async Task DeleteModel() {
        Console.WriteLine("Deleting....");

        await Server.PawnshopDelete(ModelId);

        AuthorizeS.Navigation.NavigateTo(AuthorizeS.BasePage);
    }
}