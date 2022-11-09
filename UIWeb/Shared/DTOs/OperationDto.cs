using System.ComponentModel.DataAnnotations;

namespace UIWeb.Shared.DTOs;

#nullable disable
public class OperationDto {

    public OperationDto() {
        
    }

    public OperationDto(OperationDto dto) {
        Id = dto.Id;
        Created = dto.Created;
        Description = dto.Description;
        Sum = dto.Sum;
        OperationTypeId = dto.OperationTypeId;
        OperationType = dto.OperationType;
        CustomerId = dto.CustomerId;
        Customer = dto.Customer;
        WorkerId = dto.WorkerId;
        Worker = dto.Worker;
        PawnshopId = dto.PawnshopId;
        Pawnshop = dto.Pawnshop;
    }

    public int Id { get; set; }

    public DateTime Created { get; set; } = DateTime.UtcNow;
    [StringLength(200)] public string Description { get; set; }
    public int? Sum { get; set; }

    [Required] public int OperationTypeId { get; set; }
    [Required] public OperationTypeDto OperationType { get; set; }

    public int? CustomerId { get; set; }
    public CustomerDto? Customer { get; set; }

    public int? WorkerId { get; set; }
    public WorkerDto? Worker { get; set; }

    [Required] public int PawnshopId { get; set; }
    public PawnshopDto Pawnshop { get; set; }

    public void Restore(OperationDto dto) {
        dto.Id = Id;
        dto.Created = Created;
        dto.Description = Description;
        dto.Sum = Sum;
        dto.OperationTypeId = OperationTypeId;
        dto.OperationType = OperationType;
        dto.CustomerId = CustomerId;
        dto.Customer = Customer;
        dto.WorkerId = WorkerId;
        dto.Worker = Worker;
        dto.PawnshopId = PawnshopId;
        dto.Pawnshop = Pawnshop;
    }
}