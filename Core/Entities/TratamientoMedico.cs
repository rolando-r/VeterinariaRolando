namespace Core.Entities;
public class TratamientoMedico : BaseEntity
{
    public int IdCita { get; set; }
    public Cita Cita { get; set; }
    public int IdMedicamento { get; set; }
    public Medicamento Medicamento { get; set; }
    public string Dosis { get; set; }
    public DateTime FechaAdministracion { get; set; }
    public string Observacion { get; set; }
}