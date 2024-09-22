using eventManagementAPI.DTOs.LocationDTOs;
using System.ComponentModel.DataAnnotations;

namespace eventManagementAPI.DTOs.EventDTOs
{
    public class CreateEventDTO
    {
        //detalles basicos evento

        [Required(ErrorMessage = "Event name is required.")]
        [StringLength(50, ErrorMessage = "Event name can't be longer than 50 characters.")]
        public string name { get; set; }

        public string? description { get; set; }

        public string? details { get; set; }

        //detalles de lugar

        [Required(ErrorMessage = "Event exact place is required.")]
        [StringLength(100, ErrorMessage = "Event exact place can't be longer than 100 characters.")]
        public string exactPlace { get; set; }

        [Required(ErrorMessage = "Province ID is required.")]
        public int provinceId { get; set; }

        [Required(ErrorMessage = "Canton ID is required.")]
        public int cantonId { get; set; }

        [Required(ErrorMessage = "District ID is required.")]
        public int districtId { get; set; }


        // Detalles de hora y día
        [Required(ErrorMessage = "Starting time is required.")]
        public TimeSpan startingTime { get; set; }

        [Required(ErrorMessage = "Finishing time is required.")]
        public TimeSpan finishingTime { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        public DateTime startDate { get; set; }

        [Required(ErrorMessage = "End date is required.")]
        public DateTime endDate { get; set; }

        // Validación personalizada
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            // Validar que la hora de inicio sea anterior a la hora de finalización
            if (startingTime >= finishingTime)
            {
                validationResults.Add(new ValidationResult(
                    "Starting time must be earlier than finishing time.",
                    new[] { nameof(startingTime), nameof(finishingTime) }
                ));
            }

            // Validar que la fecha de inicio sea anterior o igual a la fecha de finalización
            if (startDate > endDate)
            {
                validationResults.Add(new ValidationResult(
                    "Start date must be earlier than or equal to the end date.",
                    new[] { nameof(startDate), nameof(endDate) }
                ));
            }

            // Validar que las fechas no estén en el pasado (opcional)
            if (startDate < DateTime.Now.Date)
            {
                validationResults.Add(new ValidationResult(
                    "Start date cannot be in the past.",
                    new[] { nameof(startDate) }
                ));
            }

            return validationResults;
        }
    }
}
