using System.ComponentModel.DataAnnotations;

namespace UIWeb.Shared.DTOs;
#nullable disable
public class MakeDto {
    public MakeDto() {
        
    }

    public MakeDto(MakeDto copy) {
        Id = copy.Id;
        Name = copy.Name;
        Value = copy.Value;
        IssuancePercent = copy.IssuancePercent;
        Income = copy.Income;
        Close = copy.Close;
        IsClosed = copy.IsClosed;
        IsSold = copy.IsSold;
        PawnshopId = copy.PawnshopId;
        Pawnshop = copy.Pawnshop;
        WorkerId = copy.WorkerId;
        Worker = copy.Worker;
        CustomerId = copy.CustomerId;
        Customer = copy.Customer;
    }

    public int Id { get; set; }

    [Required] public string Name { get; set; }

    [Required] public int Value { get; set; }

    public float IssuancePercent { get; set; } = 80.0f;
    public DateTime? Income { get; set; } = DateTime.UtcNow;
    [Required] public DateTime? Close { get; set; }
    public bool IsClosed { get; set; }
    public bool IsSold { get; set; }

    [Required] public int PawnshopId { get; set; }
    public PawnshopDto Pawnshop { get; set; }

    public int? WorkerId { get; set; }
    public WorkerDto? Worker { get; set; }

    public int? CustomerId { get; set; }
    public CustomerDto? Customer { get; set; }

    public void Restore(MakeDto obj) {
        obj.Id = Id;
        obj.Name = Name;
        obj.Value = Value;
        obj.IssuancePercent = IssuancePercent;
        obj.Income = Income;
        obj.Close = Close;
        obj.IsClosed = IsClosed;
        obj.IsSold = IsSold;
        obj.PawnshopId = PawnshopId;
        obj.Pawnshop = Pawnshop;
        obj.WorkerId = WorkerId;
        obj.Worker = Worker;
        obj.CustomerId = CustomerId;
        obj.Customer = Customer;
    }
}