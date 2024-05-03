namespace Car_Rental.DTOs.CarDTOs;

public class CarDto
{
    public int CarId { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string LocationCity { get; set; }
    public string LocationCountry { get; set; }
}